import {
  createContext,
  useCallback,
  useContext,
  useEffect,
  useMemo,
  useState,
  type ReactNode,
} from "react";
import { authService } from "../services/AuthService";
import { getErrorMessages } from "../shared/api/errors";
import { setUnauthorizedHandler } from "..//shared/api/http";
import {
  broadcastAuthEvent,
  onAuthEvent,
  sessionState,
} from "../shared/api/session-state";
import type {
  AuthContextType,
  AuthUser,
  VerificationPurpose,
} from "../types/auth";

const AuthContext = createContext<AuthContextType | undefined>(undefined);

export const AuthProvider = ({ children }: { children: ReactNode }) => {
  const [user, setUser] = useState<AuthUser | null>(null);
  const [isLoading, setIsLoading] = useState<boolean>(true);
  const [isSubmitting, setIsSubmitting] = useState<boolean>(false);
  const [error, setError] = useState<string[] | null>(null);

  useEffect(() => {
    let active = true;

    authService
      .getSession()
      .then((session) => {
        if (active) setUser(session?.user ?? null);
      })
      .catch(() => {
        if (active) setUser(null);
      })
      .finally(() => {
        if (active) setIsLoading(false);
      });

    return () => {
      active = false;
    };
  }, []);

  useEffect(() => {
    const removeHandler = setUnauthorizedHandler(() => {
      sessionState.setCsrfToken(null);
      setUser(null);
    });

    const removeListener = onAuthEvent((event) => {
      if (event.type === "logged-out") {
        sessionState.setCsrfToken(null);
        setUser(null);
      }
      if (event.type === "logged-in") {
        authService
          .getSession()
          .then((session) => setUser(session?.user ?? null))
          .catch(() => setUser(null));
      }
    });

    return () => {
      removeHandler();
      removeListener();
    };
  }, []);

  const runAction = useCallback(async <T,>(action: () => Promise<T>): Promise<T> => {
    setIsSubmitting(true);
    setError(null);
    try {
      return await action();
    } catch (err) {
      setError(getErrorMessages(err));
      throw err;
    } finally {
      setIsSubmitting(false);
    }
  }, []);

  const requestCode = useCallback(
    (email: string, purpose: VerificationPurpose) =>
      runAction(() => authService.requestCode(email, purpose)),
    [runAction],
  );

  const verifyCode = useCallback(
    (email: string, code: string, purpose: VerificationPurpose) =>
      runAction(async () => {
        await authService.verifyCode(email, code, purpose);

        const session = await authService.getSession();
        if (!session) throw new Error("Sesiunea nu a putut fi creată.");

        setUser(session.user);
        broadcastAuthEvent({ type: "logged-in" });
      }),
    [runAction],
  );

  const logout = useCallback(async () => {
    try {
      await authService.logout();
    } finally {
      setUser(null);
    }
  }, []);

  const clearError = useCallback(() => setError(null), []);

  const value = useMemo<AuthContextType>(
    () => ({
      user,
      isAuthenticated: !!user,
      isLoading,
      isSubmitting,
      error,
      requestCode,
      verifyCode,
      logout,
      clearError,
    }),
    [user, isLoading, isSubmitting, error, requestCode, verifyCode, logout, clearError],
  );

  return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>;
};

// eslint-disable-next-line react-refresh/only-export-components
export const useAuth = () => {
  const context = useContext(AuthContext);
  if (!context) throw new Error("useAuth trebuie folosit în interiorul unui AuthProvider");
  return context;
};