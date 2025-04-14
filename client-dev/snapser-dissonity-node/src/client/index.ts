
import { setupSdk } from "snapser-dissonity";


window.addEventListener('DOMContentLoaded', () => {

  setupSdk({
    clientId: process.env.PUBLIC_CLIENT_ID!,
    scope: ["identify"],
    tokenRoute: "/v1/auth/discord/login",
    method: process.env.PUBLIC_METHOD!,
  });
});