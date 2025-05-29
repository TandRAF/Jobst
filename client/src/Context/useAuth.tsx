import { createContext, useEffect, useState } from "react";
import { UserProfile } from "../Models/UserProfileToken";
import { useNavigate } from "react-router-dom";
import { loginAPI, registerAPI } from "../services/AuthService";
import { toast } from "react-toastify";
import React from "react";
import axios from "axios";

type UserContextType = {
  user: UserProfile | null;
  token: string | null;
  role :string | null;
  registerUser: (email: string, username: string,role:string, password: string) => void;
  loginUser: (username: string, password: string) => void;
  logout: () => void;
  isLoggedIn: () => boolean;
  isUser: () => boolean;
  isCompany: () => boolean;
};

type Props = { children: React.ReactNode };

const UserContext = createContext<UserContextType>({} as UserContextType);

export const UserProvider = ({ children }: Props) => {
  const navigate = useNavigate();
  const [token, setToken] = useState<string | null>(null);
  const [user, setUser] = useState<UserProfile | null>(null);
  const [role, setRole] = useState<string | null>(null);
  const [isReady, setIsReady] = useState(false);

  useEffect(() => {
    const user = localStorage.getItem("user");
    const token = localStorage.getItem("token");
    const role = localStorage.getItem("role");
    if (user && token && role) {
      setUser(JSON.parse(user));
      setToken(token);
      setRole(role);
      axios.defaults.headers.common["Authorization"] = "Bearer " + token;
    }
    setIsReady(true);
    console.log(user);
  }, []);

const registerUser = async (
    email: string,
    username: string,
    role:string,
    password: string
  ) => {
    await registerAPI(email, username, role, password)
      .then((res) => {
        if (res) {
          localStorage.setItem("token", res?.data.token);
          localStorage.setItem("role", res?.data.role);
          const userObj = {
            userName: res?.data.userName,
            role:res?.data.role,
            email: res?.data.email,
          };
          console.log(userObj);
          localStorage.setItem("user", JSON.stringify(userObj));
          setToken(res?.data.token!);
          setUser(userObj!);
          toast.success("Login Success!");
          navigate("/");
        }
      })
      .catch((e) => toast.warning("Server error occured"));
  };

  const loginUser = async (username: string, password: string) => {
    await loginAPI(username, password)
      .then((res) => {
        if (res) {
          localStorage.setItem("token", res?.data.token);
           localStorage.setItem("role", res?.data.role);
          const userObj = {
            userName: res?.data.userName,
            role:res?.data.role,
            email: res?.data.email,
          };
          localStorage.setItem("user", JSON.stringify(userObj));
          setToken(res?.data.token!);
          setUser(userObj!);
          toast.success("Login Success!");
          navigate("/");
        }
      })
      .catch((e) => toast.warning("Server error occured"));
  };

  const isLoggedIn = () => {
    return !!user;
  };

  const isUser = () => {
    return role == "User"
  }
    const isCompnay = () => {
    return role == "Company"
  }

  const logout = () => {
    localStorage.removeItem("token");
    localStorage.removeItem("user");
    setUser(null);
    setToken("");
    navigate("/");
  };

  return (
    <UserContext.Provider
      value={{ loginUser, user, token, logout, isLoggedIn, registerUser,isUser,isCompnay }}>
      {isReady ? children : null}
    </UserContext.Provider>
  );
};

export const useAuth = () => React.useContext(UserContext);