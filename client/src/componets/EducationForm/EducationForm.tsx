import React, { useState } from "react";
import axios from "axios";
import { useNavigate, useParams } from "react-router-dom";
import "../../scss/index.scss";

type CvInputs = {
  degreeType: string;
  instituteName: string;
  descriprion: string;
  startDate: string;
  endDate: string;
};

export const CreateEducation = () => {
  const navigate = useNavigate();
  const { cvId } = useParams(); // get route parameter

  const [formData, setFormData] = useState<CvInputs>({
    degreeType: "",
    instituteName: "",
    descriprion: "",
    startDate: "",
    endDate: ""
  });

  const handleChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement|HTMLTextAreaElement>
  ) => {
    const { name, value } = e.target;
    setFormData((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    const formattedData = {
      ...formData,
      startDate: new Date(formData.startDate).toISOString(),
      endDate: new Date(formData.endDate).toISOString()
    };

    try {
      const response = await axios.post(
        `http://localhost:5167/api/Education/${cvId}`,
        formattedData
      );
      console.log(response, formattedData);

      if (response.status === 201) {
        navigate(`/create-cv/${cvId}/2`);
      }
    } catch (error) {
      console.error("Failed to create education:", error);
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <div>
        <label htmlFor="degreeType">Degree Type</label>
        <input
          type="text"
          name="degreeType"
          onChange={handleChange}
          value={formData.degreeType}
          id="degreeType"
          required
        />
      </div>

      <div>
        <label htmlFor="instituteName">Institute Name</label>
        <input
          type="text"
          name="instituteName"
          onChange={handleChange}
          value={formData.instituteName}
          id="instituteName"
          required
        />
      </div>
      <div className="flex-row">
         <div>
        <label htmlFor="startDate">Start Date</label>
        <input
          type="date"
          name="startDate"
          onChange={handleChange}
          value={formData.startDate}
          id="startDate"
          required
        />
      </div>

      <div>
        <label htmlFor="endDate">End Date</label>
        <input
          type="date"
          name="endDate"
          onChange={handleChange}
          value={formData.endDate}
          id="endDate"
          required
        />
      </div>

      </div>

      <div  className="flex-column">
        <label htmlFor="descriprion">Summary</label>
        <textarea
          name="descriprion"
          onChange={handleChange}
          value={formData.descriprion}
          id="descriprion"
          placeholder="Short description..."
          required
        />
      </div>

      <button type="submit">Submit</button>
    </form>
  );
};
