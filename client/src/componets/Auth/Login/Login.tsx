import React, { useState } from "react";
import { useAuth } from "../../../Context/useAuth";


type LoginFormsInputs = {
    userName: string;
    password: string;
};

const Login = () => {
  const { loginUser } = useAuth();
  const [formData, setFormData] = useState<LoginFormsInputs> ({
     userName: '',
     password: ''
   });
  const handleChange = (e: React.ChangeEvent<HTMLInputElement| HTMLSelectElement>) => {
     const {name, value} = e.target;
     setFormData(prevData => ({...prevData, [name]: value}))
   }
  const handleSubmit = async (e: React.ChangeEvent<HTMLFormElement>) => {
     e.preventDefault();
     try {
       const response = loginUser(formData.userName,formData.password);
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
      <label htmlFor="password">Password</label>
      <input type="password" name="password" onChange={handleChange} value={formData.password} id="password" placeholder="Text" />
    </div>
    <button>Sign Up</button>
  </form>
 )
};
export default Login;