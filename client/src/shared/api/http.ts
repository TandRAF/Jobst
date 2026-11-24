import { API_BASE_URL, API_TIMEOUT_MS } from './config';
import { ApiError, toApiError } from './errors';
import { sessionState } from './session-state';

type Method = 'GET' | 'POST' | 'PUT' | 'PATCH' | 'DELETE';
type QueryValue = string | number | boolean | null | undefined;

const UNSAFE_METHODS: ReadonlySet<Method> = new Set(['POST', 'PUT', 'PATCH', 'DELETE']);

export interface RequestOptions {
  query?: Record<string, QueryValue>;
  headers?: HeadersInit;
  signal?: AbortSignal;
  timeoutMs?: number;
  skipUnauthorizedHandler?: boolean;
}

export type UnauthorizedHandler = (code: string | undefined) => void;

let unauthorizedHandler: UnauthorizedHandler | null = null;

export function setUnauthorizedHandler(handler: UnauthorizedHandler): () => void {
  unauthorizedHandler = handler;
  return () => {
    if (unauthorizedHandler === handler) unauthorizedHandler = null;
  };
}

function buildUrl(path: string, query?: RequestOptions['query']): string {
  const params = new URLSearchParams();

  for (const [key, value] of Object.entries(query ?? {})) {
    if (value !== null && value !== undefined) params.append(key, String(value));
  }

  const qs = params.toString();
  return `${API_BASE_URL}${path}${qs ? `?${qs}` : ''}`;
}

async function parseBody(response: Response): Promise<unknown> {
  if (response.status === 204) return undefined;

  const contentType = response.headers.get('content-type') ?? '';

  if (contentType.includes('application/json')) {
    return response.json().catch(() => undefined);
  }

  const text = await response.text().catch(() => '');
  return text || undefined;
}

async function request<T>(
  method: Method,
  path: string,
  body: unknown,
  options: RequestOptions = {},
): Promise<T> {
  const {
    query,
    headers,
    signal: externalSignal,
    timeoutMs = API_TIMEOUT_MS,
    skipUnauthorizedHandler = false,
  } = options;

  const controller = new AbortController();
  let timedOut = false;

  const timer = setTimeout(() => {
    timedOut = true;
    controller.abort();
  }, timeoutMs);

  const forwardAbort = () => controller.abort();

  if (externalSignal?.aborted) controller.abort();
  externalSignal?.addEventListener('abort', forwardAbort);

  const requestHeaders = new Headers(headers);
  requestHeaders.set('Accept', 'application/json');
  if (body !== undefined) requestHeaders.set('Content-Type', 'application/json');

  if (UNSAFE_METHODS.has(method)) {
    const csrfToken = sessionState.getCsrfToken();
    if (csrfToken) requestHeaders.set('X-CSRF-Token', csrfToken);
  }

  try {
    const response = await fetch(buildUrl(path, query), {
      method,
      headers: requestHeaders,
      body: body === undefined ? undefined : JSON.stringify(body),
      credentials: 'include',
      signal: controller.signal,
    });

    const payload = await parseBody(response);

    if (!response.ok) {
      const error = toApiError(response.status, payload);

      if (error.isUnauthorized && !skipUnauthorizedHandler) {
        sessionState.setCsrfToken(null);
        unauthorizedHandler?.(error.code);
      }

      throw error;
    }

    return payload as T;
  } catch (error) {
    if (error instanceof ApiError) throw error;

    if (externalSignal?.aborted) throw error;

    if (timedOut) throw new ApiError(0, 'The request timed out. Please try again.');

    throw new ApiError(0, 'Network error. Check your connection.');
  } finally {
    clearTimeout(timer);
    externalSignal?.removeEventListener('abort', forwardAbort);
  }
}

export const http = {
  get: <T>(path: string, options?: RequestOptions) =>
    request<T>('GET', path, undefined, options),

  post: <T>(path: string, body?: unknown, options?: RequestOptions) =>
    request<T>('POST', path, body, options),

  put: <T>(path: string, body?: unknown, options?: RequestOptions) =>
    request<T>('PUT', path, body, options),

  patch: <T>(path: string, body?: unknown, options?: RequestOptions) =>
    request<T>('PATCH', path, body, options),

  delete: <T = void>(path: string, options?: RequestOptions) =>
    request<T>('DELETE', path, undefined, options),
} as const;