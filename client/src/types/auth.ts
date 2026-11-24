import { CurrentUser } from "../shared/api/session";
import { SendCodeResult, VerificationPurpose } from "../shared/api/verification";


export type AuthUser = CurrentUser;
export type { VerificationPurpose };

export interface AuthContextType {
  user: AuthUser | null;
  isAuthenticated: boolean;
  isLoading: boolean;
  isSubmitting: boolean;
  error: string[] | null;
  requestCode: (email: string, purpose: VerificationPurpose) => Promise<SendCodeResult>;
  verifyCode: (email: string, code: string, purpose: VerificationPurpose) => Promise<void>;
  logout: () => Promise<void>;
  clearError: () => void;
}