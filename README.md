# snapser-demo-discord-unity
Discord Activity Example using Dissonity


## Setup
### Install Libraries
#### 1. Install Dissonity
1. Go to Window > Package Manager > Add package from git URL
2. Install the package from https://github.com/Furnyr/Dissonity.git?path=/unity#v1

After the installation is done,
- Right click in the hierarchy, Dissonity > Discord Bridge. Add it to the main scene.

You can now build your game for WebGL and put it in your nested iframe. If you're not using the example Node.js project you will need to follow the "Project configuration" guide below.

#### 2. Install NuGet as it makes it easier to add other dependencies
1. 1. Go to Window > Package Manager > Add package from git URL
2. Install package from https://github.com/GlitchEnzo/NuGetForUnity.git?path=/src/NuGetForUnity

- You will now see the NuGet button the the top menu

#### 3. Install Newtonsoft.Json via Nuget
1. Click on the NuGet package manager
2. Search for the following packages:
- Newtonsoft.Json
- Unity Test Framework (Only if you want to add tests)

### Install Snapser SDK
#### 1. Download the SDK
1. Go to your Snapend home page and find the Client SDK download widget.
2. Select Unity C# for the Platform and pick **unitywebrequest** for the HTTP type.
3. Click generate.

You will now get a Zip file that you should save it to your machine.

#### 2. Integrate the Snapser SDK
1. After opening the Zip file you should see a `src/Snapser` folder.
2. Copy the `src/Snapser` folder and paste it inside Unity repo roots `Assets/Scripts` folder.

- You are now ready to start integrating with your backend.