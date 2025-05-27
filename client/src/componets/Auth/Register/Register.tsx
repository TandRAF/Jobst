import React, { useState } from "react";
import axios from "axios";


type RegisterFormsInputs = {
    email:string;
    username: string;
    role: string;
    password: string;
};


const Register = () => {
  const [formData, setFormData] = useState<RegisterFormsInputs> ({
     email: '',
     username: '',
     role: '',
     password: ''
   });
  const handleChange = (e: React.ChangeEvent<HTMLInputElement| HTMLSelectElement>) => {
     const {name, value} = e.target;
     setFormData(prevData => ({...prevData, [name]: value}))
   }
  const handleSubmit = async (e: React.ChangeEvent<HTMLFormElement>) => {
     e.preventDefault();
     try {
       const response = await axios.post('http://localhost:8080/apiv1/signup', formData);
       console.log(response);
     }catch (error) {
       console.error(error);
     }
   } 
 return(
  <form onSubmit={handleSubmit}>
    <div>
      <label htmlFor="username">User Name</label>
      <input type="text" name="username" onChange={handleChange} value={formData.username} id="username" />
    </div>
     <div>
      <label htmlFor="eamil">Email</label>
      <input type="text" name="email" onChange={handleChange} value={formData.email} id="username" />
    </div>
     <div>
      <label htmlFor="role">Role</label>
   <select name="select" onChange={handleChange} id="">
          <option value="User">User</option>
          <option value="Company">Company</option>
    </select>
    </div>
     <div>
      <label htmlFor="username">Password</label>
      <input type="password" name="password" onChange={handleChange} value={formData.password} id="password" placeholder="Text" />
    </div>
    <button>Sign Up</button>
  </form>
 )
};
export default Register;