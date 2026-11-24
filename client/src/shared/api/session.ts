import { http } from './http';
import { ApiError } from './errors';
import { broadcastAuthEvent, sessionState } from './session-state';

export interface CurrentUser {
  id: string;
  email: string;
  emailVerified: boolean;
}

interface SessionResponse {
  user: CurrentUser;
  csrfToken: string;
  expiresAt: string;
}

export interface LoadedSession {
  user: CurrentUser;
  expiresAt: Date;
}

export async function loadSession(): Promise<LoadedSession | null> {
  try {
    const session = await http.get<SessionResponse>('/auth/session', {
      skipUnauthorizedHandler: true,
    });

    sessionState.setCsrfToken(session.csrfToken);
    return { user: session.user, expiresAt: new Date(session.expiresAt) };
  } catch (error) {
    if (error instanceof ApiError && error.isUnauthorized) {
      sessionState.setCsrfToken(null);
      return null;
    }
    throw error;
  }
}

export async function logout(): Promise<void> {
  try {
    await http.post<void>('/auth/logout', undefined, { skipUnauthorizedHandler: true });
  } finally {
    sessionState.setCsrfToken(null);
    broadcastAuthEvent({ type: 'logged-out' });
  }
}