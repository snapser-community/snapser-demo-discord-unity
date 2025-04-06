
import { setupSdk } from "dissonity";


window.addEventListener('DOMContentLoaded', () => {

  setupSdk({
    clientId: process.env.PUBLIC_CLIENT_ID!,
    scope: ["identify"],
    tokenRoute: "/v1/byosnap-discord/auth/token",
  });
});