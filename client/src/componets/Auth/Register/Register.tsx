import React, { useState } from "react";
import { useAuth } from "../../../Context/useAuth";


type RegisterFormsInputs = {
    email:string;
    userName: string;
    role: string;
    password: string;
};

const Register = () => {
  const { registerUser } = useAuth();
  const [formData, setFormData] = useState<RegisterFormsInputs> ({
     email: '',
     userName: '',
     role: 'User',
     password: ''
   });
  const handleChange = (e: React.ChangeEvent<HTMLInputElement| HTMLSelectElement>) => {
     const {name, value} = e.target;
     setFormData(prevData => ({...prevData, [name]: value}))
   }
  const handleSubmit = async (e: React.ChangeEvent<HTMLFormElement>) => {
     e.preventDefault();
     try {
       const response = registerUser(formData.email,formData.userName,formData.role,formData.password);
       console.log(response,formData);
     }catch (error) {
       console.error(error);
     }
   } 
 return(
  <form onSubmit={handleSubmit}>
    <div>
      <label htmlFor="userName">User Name</label>
      <input type="text" name="userName" onChange={handleChange} value={formData.userName} id="userName" />
    </div>
     <div>
      <label htmlFor="eamil">Email</label>
      <input type="text" name="email" onChange={handleChange} value={formData.email} id="email" />
    </div>
     <div>
      <label htmlFor="role">Role</label>
      <select name="role" onChange={handleChange} value={formData.role} id="role">
          <option value="User">User</option>
          <option value="Company">Company</option>
    </select>
    </div>
     <div>
      <label htmlFor="password">Password</label>
      <input type="password" name="password" onChange={handleChange} value={formData.password} id="password" placeholder="Text" />
    </div>
    <button>Sign Up</button>
  </form>
 )
};
export default Register;