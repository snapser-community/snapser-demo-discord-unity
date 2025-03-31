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

### Code Stripping
- We want to avoid WebGL builds from aggressively trying to code strip. It has been observed that some WebGL builds end up stripping some methods from Newtonsoft. Hence go ahead and add this file to the `Assets/` folder.
```xml
<linker>
    <assembly fullname="Newtonsoft.Json">
        <type fullname="Newtonsoft.Json.*" preserve="all"/>
    </assembly>
</linker>
```

## Build
1. Go to Unity Build settings and make sure you have selected WebGl.
2. Click build and pick a folder to place the output of the build.
3. You will see the following folder structure
- **index.html**:
  - Primary Entry Point: This is the main HTML file that browsers load to start the game. It references the necessary scripts and styles from the Build and TemplateData folders.

  - Canvas and Loader Setup: It sets up the HTML canvas element where the Unity game renders its graphics, and includes scripts for loading the game's assets and code effectively.

- **Build Folder**:
  - Game Data and Code: This folder includes the compiled game code and data files. These files are necessary for the game to run as they contain the executable code and asset data (like textures, sounds, and models) that Unity has packaged for the web platform.

  - JavaScript Files: Unity generates JavaScript files that handle the loading and running of the game within the web browser. These files also manage interactions between the Unity engine and the browser's WebGL context.

- **TemplateData Folder**:
  - Stores Supporting Files: This folder contains additional files that support the game's user interface on the web. These can include icons, images, style sheets (CSS), and configuration files that control how the game is presented in the browser (such as the appearance of the loading screen).

  - HTML and CSS Assets: These are used to style and configure elements outside the actual game canvas, providing a better user experience and integrating game elements with the web page’s overall design.

## Run
Unity Provides a Build and Run option allowing you to view your WebGL game.