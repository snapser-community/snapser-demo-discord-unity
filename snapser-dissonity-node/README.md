## Dissonity base Node.js app


## Project structure

- `src/`: Where the main code of the project is.
- `src/client/`: Where the client code is, here you can set up your Dissonity config.
- `src/client/nested/`: Where you need to put your Unity WebGL build.
- `src/server/`: Where the server code is, here the client is served to Discord on request. (Colyseus rooms are also defined here!)
- `src/server/utils`: Utility files for the server, mainly used to code the multiplayer part (Colyseus).

### package.json scripts
- `npm run colyseus`(Only needed with Colyseus): Generate the Colyseus C# classes for Unity inside `_unity_colyseus`.
- `npm run build`: Compile to JavaScript the TypeScript files so they can be executed.
- `npm run execute`: Run the server.
- `npm run start`: Build the project, then run the server.

## Updating

When a new version is released, you can simply update the npm and unity packages and you should be good to go!

##

> [!IMPORTANT]
> Don't forget to set your env variables inside a .env file!

> [!WARNING]
> This base project only supports the Unity WebGL Template set to Minimal.

# Relevant links

- [Colyseus GitHub](https://github.com/colyseus/colyseus)
- [Colyseus Documentation](https://docs.colyseus.io)