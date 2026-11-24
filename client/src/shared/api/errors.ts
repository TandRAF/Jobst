export type FieldErrors = Record<string, string[]>;

const FALLBACK_MESSAGE = 'An unexpected error occurred.';

interface ApiErrorOptions {
  code?: string;
  fieldErrors?: FieldErrors;
  body?: unknown;
}

export class ApiError extends Error {
  readonly status: number;
  readonly code: string | undefined;
  readonly fieldErrors: FieldErrors;
  readonly body: unknown;

  constructor(status: number, message: string, options: ApiErrorOptions = {}) {
    super(message);
    this.name = 'ApiError';
    this.status = status;
    this.code = options.code;
    this.fieldErrors = options.fieldErrors ?? {};
    this.body = options.body;
  }

  get isNetworkError(): boolean {
    return this.status === 0;
  }

  get isUnauthorized(): boolean {
    return this.status === 401;
  }
}

interface ProblemPayload {
  code?: unknown;
  detail?: unknown;
  message?: unknown;
  errors?: unknown;
}

const firstString = (value: unknown): string | undefined =>
  typeof value === 'string' && value.trim() !== '' ? value : undefined;

function normalizeFieldErrors(raw: unknown): FieldErrors {
  if (typeof raw !== 'object' || raw === null) return {};

  return Object.fromEntries(
    Object.entries(raw).map(([field, messages]) => [
      field,
      Array.isArray(messages) ? messages.map(String) : [String(messages)],
    ]),
  );
}

export function toApiError(status: number, payload: unknown): ApiError {
  const problem = (typeof payload === 'object' && payload !== null ? payload : {}) as ProblemPayload;
  const fieldErrors = normalizeFieldErrors(problem.errors);
  const firstFieldError = Object.values(fieldErrors).flat()[0];

  const message =
    firstString(problem.detail) ??
    firstString(problem.message) ??
    firstFieldError ??
    FALLBACK_MESSAGE;

  return new ApiError(status, message, {
    code: firstString(problem.code),
    fieldErrors,
    body: payload,
  });
}

export function getErrorMessages(error: unknown): string[] {
  if (error instanceof ApiError) {
    const fieldMessages = Object.values(error.fieldErrors).flat();
    return fieldMessages.length > 0 ? fieldMessages : [error.message];
  }
  return [FALLBACK_MESSAGE];
}