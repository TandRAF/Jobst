import { loadSession, logout as apiLogout } from "../shared/api/session";
import {
  sendVerificationCode,
  verifyEmailCode,
} from "../shared/api/verification";

export const authService = {
  getSession: loadSession,
  requestCode: sendVerificationCode,
  verifyCode: verifyEmailCode,
  logout: apiLogout,
};