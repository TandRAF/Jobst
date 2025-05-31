import "./_jobOffer.scss"

type JobOfferProps = {
    postedAt: string;
    company: string;
    jobTitle: string;
    tags: string[];
    chance: number;
};


export const JobOffer: React.FC<JobOfferProps> = ({ postedAt, company, jobTitle, tags, chance }) => {
    return (
        <div className="offer">
            <div className="offer-title-company-tags">
                    <div className="date-company">
                    <div className="date-name-company">
                        <span className="date">{postedAt}</span>
                        <span className="company">{company}</span>
                    </div>
                    <div className="logo-company">
                        <img src="client/src/assets/Icons/google-icon.png" alt={""} />
                    </div>
                </div>

                <div className="offer-title-tags">
                    <div className="offer-title">{jobTitle}</div>

                    <div className="offer-tags">
                        {tags.map((tag, index) => (
                            <Tag key={index} name={tag} />
                        ))}
                    </div>
                </div>
            </div>

            <div className="separator"></div>

            <div className="chance">
                <div className="chance-border">
                     <span>{chance}%</span>
                </div>
            </div>
        </div>
    );
};

type TagProps = {
    name: string;
};

const Tag: React.FC<TagProps> = ({ name }) => {
    return <div className="tag">{name}</div>;
};