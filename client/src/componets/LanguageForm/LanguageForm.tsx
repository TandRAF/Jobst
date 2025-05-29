import React, { useState } from "react";
import axios from "axios";
import { useNavigate, useParams } from "react-router-dom";

type CvInputs = {
  languageName: string;
  level: string;
};

export const CreateLanguage = () => {
  const navigate = useNavigate();
  const { cvId } = useParams(); // get route param

  const [formData, setFormData] = useState<CvInputs>({
    languageName: "",
    level: ""
  });

  const handleChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>
  ) => {
    const { name, value } = e.target;
    setFormData((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    try {
      const response = await axios.post(
        `http://localhost:5167/api/Language/${cvId}`,
        formData
      );
      console.log(response, formData);
      if (response.status === 201) {
        navigate("/"); 
      }
    } catch (error) {
      console.error("Failed to submit language info:", error);
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <div>
        <label htmlFor="languageName">Language Name</label>
        <input
          type="text"
          name="languageName"
          onChange={handleChange}
          value={formData.languageName}
          id="languageName"
          required
        />
      </div>

      <fieldset name="language">
        <legend>Choose Level</legend>
        <div className="level-container">
        {["A1", "A2", "B1", "B2", "C1", "C2"].map((level) => (
          <label htmlFor={level} key={level}>
            <input
              name="level"
              id={level}
              type="radio"
              value={level}
              onChange={handleChange}
              checked={formData.level === level}
              required
            />
            <div className="checker">{level}</div>
          </label>
        ))}
        </div>
      </fieldset>

      <button type="submit">Submit</button>
    </form>
  );
};
