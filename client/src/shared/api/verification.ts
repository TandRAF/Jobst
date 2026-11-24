import { ApiError } from "./errors";
import { http } from "./http";

export type VerificationPurpose = 'signup' | 'login';

export interface SendCodeResult {
  expiresInSeconds: number;
  resendAvailableInSeconds: number;
}

export interface VerifyCodeResult {
  emailVerified: boolean;
}

const CODE_PATTERN = /^\d{6}$/;

export const normalizeEmail = (email: string): string => email.trim().toLowerCase();

export function sendVerificationCode(
  email: string,
  purpose: VerificationPurpose,
): Promise<SendCodeResult> {
  return http.post<SendCodeResult>('/auth/verification-codes', {
    email: normalizeEmail(email),
    purpose,
  });
}

export async function verifyEmailCode(
  email: string,
  code: string,
  purpose: VerificationPurpose,
): Promise<VerifyCodeResult> {
  const trimmed = code.trim();

  if (!CODE_PATTERN.test(trimmed)) {
    const message = 'Enter the 6-digit code from your email.';
    throw new ApiError(422, message, { fieldErrors: { code: [message] } });
  }

  return http.post<VerifyCodeResult>(
    '/auth/verification-codes/verify',
    { email: normalizeEmail(email), code: trimmed, purpose },
    { skipUnauthorizedHandler: true },
  );
}