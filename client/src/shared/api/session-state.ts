export type AuthEvent = { type: 'logged-in' } | { type: 'logged-out' };

let csrfToken: string | null = null;

export const sessionState = {
  getCsrfToken: (): string | null => csrfToken,
  setCsrfToken: (token: string | null): void => {
    csrfToken = token;
  },
};

const channel: BroadcastChannel | null =
  typeof BroadcastChannel === 'undefined' ? null : new BroadcastChannel('auth');

export function broadcastAuthEvent(event: AuthEvent): void {
  channel?.postMessage(event);
}

export function onAuthEvent(listener: (event: AuthEvent) => void): () => void {
  if (!channel) return () => {};

  const handler = (message: MessageEvent<AuthEvent>) => listener(message.data);
  channel.addEventListener('message', handler);
  return () => channel.removeEventListener('message', handler);
}