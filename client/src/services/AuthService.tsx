import axios from "axios";
import { handleError } from "../Helpers/ErrorHendler";
import { UserProfileToken } from "../Models/UserProfileToken";

const api = "http://localhost:5167/api/";

export const loginAPI = async (userName: string, password: string) => {
  try {
    const data = await axios.post<UserProfileToken>(api + "account/login", {
      userName: userName,
      password: password,
    });
    return data;
  } catch (error) {
    handleError(error);
  }
};

export const registerAPI = async (
  email: string,
  userName: string,
  role:string,
  password: string
) => {
  try {
    const data = await axios.post<UserProfileToken>(api + "account/register", {
      email: email,
      userName: userName,
      role:role,
      password: password,
    });
    console.log(data);
    return data;
  } catch (error) {
    handleError(error);
  }
};