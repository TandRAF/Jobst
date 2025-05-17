import React from "react";
import * as Yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";
import { useAuth } from "../../Context/useAuth";
import { useForm } from "react-hook-form";

type Props = {};

type RegisterFormsInputs = {
    email:string;
    username: string;
    password: string;
};

const validation = Yup.object().shape({
    email: Yup.string().required("Email is required"),
    username: Yup.string().required("Username is required"),
    password: Yup.string().required("Password is required"),
});

const Register = (props: Props) => {
  const { registerUser } = useAuth();
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<RegisterFormsInputs>({ resolver: yupResolver(validation) });

  const handleRegister = (form: RegisterFormsInputs) => {
    registerUser(form.email, form.username, form.password);
  };
  return (
    <section >
      <div >
        <div >
          <div >
            <h1 >
              Sign in to your account
            </h1>
            <form onSubmit={handleSubmit(handleRegister)}>
              <div>
                <label htmlFor="email">
                </label>
                Email
                <input type="text" id="email"
                  placeholder="Email"
                  {...register("email")}
                />
                {errors.email ? (
                  <p >{errors.email.message}</p>
                ) : (
                  ""
                )}
              </div>
              <div>
                <label
                  htmlFor="username"
                >
                  Username
                </label>
                <input
                  type="text"
                  id="username"
                  placeholder="Username"
                  {...register("username")}
                />
                {errors.username ? (
                  <p className="text-white">{errors.username.message}</p>
                ) : (
                  ""
                )}
              </div>
              <div>
                <label
                  htmlFor="password"
                >
                  Password
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
              </div>
              <div >
                <a
                  href="#"
                >
                  Forgot password?
                </a>
              </div>
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
          </div>
        </div>
      </div>
    </section>
  );
};
export default Register;