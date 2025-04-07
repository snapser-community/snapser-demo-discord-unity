
import { setupSdk } from "snapser-dissonity";


window.addEventListener('DOMContentLoaded', () => {

  setupSdk({
    clientId: process.env.PUBLIC_CLIENT_ID!,
    scope: ["identify"],
    tokenRoute: "/v1/byosnap-discord/auth/token",
    method: process.env.PUBLIC_METHOD!,
    apiKey: process.env.PUBLIC_API_KEY!,
  });
});