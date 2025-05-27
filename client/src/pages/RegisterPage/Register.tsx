import React from "react";
import { yupResolver } from "@hookform/resolvers/yup";
import * as Yup from "yup";
import { useAuth } from "../../Context/useAuth";
import { useForm } from "react-hook-form";


type RegisterFormsInputs = {
    email:string;
    username: string;
    role: string;
    password: string;
};

const validation = Yup.object().shape({
  email: Yup.string().required("Email is required"),
  userName: Yup.string().required("Username is required"),
  role: Yup.string().required("Role is required"),
  password: Yup.string().required("Password is required"),
});


const Register = () => {
  const { registerUser } = useAuth();
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<RegisterFormsInputs>({ resolver: yupResolver(validation) });


  const handleRegister = (form: RegisterFormsInputs) => {
    registerUser(form.email, form.username,form.role, form.password);
  };
  return (
    <section >
            <h1 >
              Sign in to your account
            </h1>
            <form onSubmit={handleSubmit(handleRegister)}>
                <label htmlFor="email">
                </label>
                Email
                <input
                 type="text" id="email"
                  placeholder="Email"
                  {...register("email")}
                />
                {errors.email ? (
                  <p >{errors.email.message}</p>
                ) : (
                  ""
                )}
                <label htmlFor="username">
                  Username
                </label>
                <input
                  type="text"
                  name="UserName"
                  id="username"
                  placeholder="Username"
                  {...register("username")}
                />
                {errors.username ? (
                  <p className="text-white">{errors.username.message}</p>
                ) : (
                  ""
                )}
                <label htmlFor="password">
                  Passwcord
                </label>
                <input
                  type="password"
                  id="password"
                  placeholder="••••••••"
                  {...register("password")}
                />
                {errors.password ? (
                  <p className="text-white">{errors.password.message}</p>
                ) : (
                  ""
                )}
                <select name="select" id=""
                 {...register("role")}
                >
                  <option value="User">User</option>
                  <option value="Company">Company</option>
                </select>
                <a href="#">
                  Forgot password?
                </a>
              <button
                type="submit"
              >
                Sign in
              </button>
              <p>
                Don’t have an account yet?{" "}
                <a
                  href="#"
                >
                  Sign up
                </a>
              </p>
            </form>
    </section>
  );
};
export default Register;