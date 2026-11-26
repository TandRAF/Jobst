from contextlib import asynccontextmanager
from pathlib import Path
from typing import List, Optional

import joblib
import numpy as np
import spacy
from fastapi import FastAPI, HTTPException
from pydantic import BaseModel, Field
from sklearn.feature_extraction.text import TfidfVectorizer
from sklearn.linear_model import LogisticRegression
from sklearn.metrics.pairwise import cosine_similarity

ARTIFACTS_DIR = Path(__file__).resolve().parent.parent / "artifacts"


class CandidateInput(BaseModel):
    name: str
    cv_text: str
    job_experience_years: int = Field(ge=0)
    education_level: str
    known_technologies: List[str] = []
    languages: List[str] = []
    project_area: str = ""


class JobInput(BaseModel):
    job_id: str
    title: str
    team_id: str
    description: str
    req_experience_years: int = Field(ge=0)
    req_education: str
    req_technologies: List[str] = []
    req_languages: List[str] = []
    req_project_area: str = ""
    team_profiles: List[str] = []


class MatchRequest(BaseModel):
    candidate: CandidateInput
    jobs: List[JobInput]


class MatchResultItem(BaseModel):
    job_id: str
    job_title: str
    nlp_match_pct: float
    tech_fit_pct: float
    team_fit_pct: float
    edu_fit_pct: float
    total_suitability_pct: float
    predicted_hire_prob_pct: Optional[float] = None


class MatchResponse(BaseModel):
    candidate: str
    action_verbs: List[str]
    extracted_entities: List[str]
    matches: List[MatchResultItem]


def clean_text(nlp, text: str) -> str:
    doc = nlp(text)
    return " ".join(
        token.lemma_.lower() for token in doc if not token.is_stop and token.is_alpha
    )


def calculate_tech_match(cand_techs: List[str], req_techs: List[str]) -> float:
    if not req_techs:
        return 1.0
    cand_set, req_set = set(cand_techs), set(req_techs)
    base_score = len(cand_set.intersection(req_set)) / len(req_set)
    bonus = len(cand_set - req_set) * 0.05
    return min(base_score + bonus, 1.25)


def calculate_lang_match(cand_langs: List[str], req_langs: List[str]) -> float:
    if not req_langs:
        return 1.0
    return 1.0 if set(cand_langs).intersection(set(req_langs)) else 0.0


def calculate_exp_match(cand_exp: int, req_exp: int) -> float:
    if req_exp == 0:
        return 1.0
    if cand_exp > req_exp:
        return min(1.0 + ((cand_exp - req_exp) * 0.05), 1.20)
    return cand_exp / req_exp


def calculate_edu_match(cand_edu: str, req_edu: str) -> float:
    edu_levels = {"High School": 0, "Bachelors": 1, "Masters": 2, "PhD": 3}
    diff = edu_levels.get(cand_edu, 0) - edu_levels.get(req_edu, 0)
    if diff == 0:
        return 1.0
    if diff > 0:
        return 1.0 + (diff * 0.1)
    if diff == -1:
        return 0.7
    return 0.3


@asynccontextmanager
async def lifespan(app: FastAPI):
    nlp = spacy.load("en_core_web_sm")
    hire_model = None
    tfidf = None

    clf_path = ARTIFACTS_DIR / "hire_model.joblib"
    vec_path = ARTIFACTS_DIR / "tfidf.joblib"

    if clf_path.exists():
        hire_model = joblib.load(clf_path)
    if vec_path.exists():
        tfidf = joblib.load(vec_path)

    app.state.nlp = nlp
    app.state.hire_model = hire_model
    app.state.tfidf = tfidf
    try:
        yield
    finally:
        pass


app = FastAPI(
    title="JOBST Analytics Service",
    version="1.0.0",
    lifespan=lifespan,
)


@app.get("/health")
def health():
    return {
        "status": "ok",
        "model_loaded": app.state.hire_model is not None,
        "tfidf_loaded": app.state.tfidf is not None,
    }


@app.post("/api/v1/matching/score", response_model=MatchResponse)
def score_candidate(payload: MatchRequest):
    nlp = app.state.nlp
    if nlp is None:
        raise HTTPException(status_code=503, detail="NLP model not initialized")

    cand = payload.candidate
    clean_cv = clean_text(nlp, cand.cv_text)

    doc = nlp(cand.cv_text)
    action_verbs = [token.text for token in doc if token.pos_ == "VERB"]
    entities = [
        ent.text for ent in doc.ents if ent.label_ in {"ORG", "PRODUCT", "PERSON"}
    ]

    cleaned_jobs = [clean_text(nlp, job.description) for job in payload.jobs]
    cleaned_teams = [
        clean_text(nlp, profile)
        for job in payload.jobs
        for profile in job.team_profiles
    ]

    vectorizer = app.state.tfidf
    if vectorizer is None:
        corpus = [clean_cv] + cleaned_jobs + cleaned_teams
        vectorizer = TfidfVectorizer()
        vectorizer.fit(corpus)

    cand_vec = vectorizer.transform([clean_cv])
    job_matrix = vectorizer.transform(cleaned_jobs)

    matches: List[MatchResultItem] = []
    for idx, job in enumerate(payload.jobs):
        nlp_score = float(cosine_similarity(cand_vec, job_matrix[idx])[0][0])

        if job.team_profiles:
            clean_team_docs = [clean_text(nlp, profile) for profile in job.team_profiles]
            team_vecs = vectorizer.transform(clean_team_docs)
            team_centroid = np.asarray(team_vecs.mean(axis=0))
            team_score = float(cosine_similarity(cand_vec, team_centroid)[0][0])
        else:
            team_score = 0.0

        tech_score = calculate_tech_match(
            cand.known_technologies, job.req_technologies
        )
        lang_score = calculate_lang_match(cand.languages, job.req_languages)
        exp_score = calculate_exp_match(
            cand.job_experience_years, job.req_experience_years
        )
        edu_score = calculate_edu_match(cand.education_level, job.req_education)
        area_score = 1.0 if cand.project_area == job.req_project_area else 0.0

        final_score = (
            (tech_score * 0.30)
            + (team_score * 0.20)
            + (nlp_score * 0.15)
            + (exp_score * 0.15)
            + (edu_score * 0.10)
            + (area_score * 0.05)
            + (lang_score * 0.05)
        )

        hire_prob: Optional[float] = None
        model: Optional[LogisticRegression] = app.state.hire_model
        if model is not None:
            features = np.array(
                [[
                    round(nlp_score * 100, 1),
                    round(tech_score * 100, 1),
                    round(team_score * 100, 1),
                    round(edu_score * 100, 1),
                ]]
            )
            hire_prob = round(float(model.predict_proba(features)[0][1]) * 100, 1)

        matches.append(
            MatchResultItem(
                job_id=job.job_id,
                job_title=job.title,
                nlp_match_pct=round(nlp_score * 100, 1),
                tech_fit_pct=round(tech_score * 100, 1),
                team_fit_pct=round(team_score * 100, 1),
                edu_fit_pct=round(edu_score * 100, 1),
                total_suitability_pct=round(final_score * 100, 1),
                predicted_hire_prob_pct=hire_prob,
            )
        )

    matches.sort(key=lambda item: item.total_suitability_pct, reverse=True)
    return MatchResponse(
        candidate=cand.name,
        action_verbs=action_verbs,
        extracted_entities=entities,
        matches=matches,
    )