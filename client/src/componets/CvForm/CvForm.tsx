import React, { useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";

type CvInputs = {
  name: string;
  surname: string;
  email: string;
  phonePrefix: string;
  phoneNumber: string;
  summary: string;
};


export const CreateCv = () => {
  const navigate = useNavigate();

  const [formData, setFormData] = useState<CvInputs>({
    name: "",
    surname: "",
    email: "",
    phonePrefix: "+40",
    phoneNumber: "",
    summary: "",
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

    const fullPhoneNumber = `${formData.phonePrefix}${formData.phoneNumber}`;
    const payload = {
      ...formData,
      phoneNumber: fullPhoneNumber, // send combined phone number
    };

    try {
      const response = await axios.post("http://localhost:5167/api/CV", payload);
      console.log(response,formData);
      if (response.status === 201) {
        navigate(`/create-cv/${response.data.id}/1`);
      }
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <div>
        <label htmlFor="name">Name</label>
        <input
          type="text"
          name="name"
          onChange={handleChange}
          value={formData.name}
          id="name"
        />
      </div>

      <div>
        <label htmlFor="surname">Surname</label>
        <input
          type="text"
          name="surname"
          onChange={handleChange}
          value={formData.surname}
          id="surname"
        />
      </div>

      <div>
        <label htmlFor="email">Email</label>
        <input
          type="text"
          onChange={handleChange}
          value={formData.email}
          id="email"
        />
      </div>

      <div>
        <label htmlFor="phoneNumber">Phone Number</label>
        <fieldset name="tel">
          <select
            name="phonePrefix"
            onChange={handleChange}
            value={formData.phonePrefix}
          >
            <option value="+40">+40</option>
            <option value="+373">+373</option>
          </select>
          <input
            type="tel"
            name="phoneNumber"
            placeholder="123456789"
            pattern="[0-9]{9}"
            value={formData.phoneNumber}
            onChange={handleChange}
            required
          />
        </fieldset>
      </div>

      <div className="flex-column">
        <label htmlFor="summary">Summary</label>
        <textarea
          name="summary"
          onChange={handleChange}
          value={formData.summary}
          id="summary"
          placeholder="Short description..."
        />
      </div>

      <button type="submit">Sign Up</button>
    </form>
  );
};
