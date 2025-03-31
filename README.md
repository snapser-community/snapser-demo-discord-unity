# snapser-demo-discord-unity
Discord Activity Example using Dissonity


## Setup
### 1. Install Dissonity
1. Go to Window > Package Manager > Add package from git URL
2. Install the package from https://github.com/Furnyr/Dissonity.git?path=/unity#v1

After the installation is done,
- Right click in the hierarchy, Dissonity > Discord Bridge. Add it to the main scene.

You can now build your game for WebGL and put it in your nested iframe. If you're not using the example Node.js project you will need to follow the "Project configuration" guide below.

### 2. Install NuGet as it makes it easier to add other dependencies
1. 1. Go to Window > Package Manager > Add package from git URL
2. Install package from https://github.com/GlitchEnzo/NuGetForUnity.git?path=/src/NuGetForUnity

- You will now see the NuGet button the the top menu

### 3. Install Newtonsoft.Json via Nuget
1. Click on the NuGet package manager
2. Search for the following packages:
- Newtonsoft.Json
- Unity Test Framework