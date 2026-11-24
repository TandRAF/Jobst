const rawBase = import.meta.env.VITE_API_URL ?? '';

export const API_BASE_URL = `${rawBase.replace(/\/+$/, '')}/api`;
export const API_TIMEOUT_MS = 15_000;