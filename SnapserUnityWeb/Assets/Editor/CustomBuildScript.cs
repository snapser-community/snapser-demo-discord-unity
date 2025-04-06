using UnityEditor;
using UnityEngine;

public class CustomBuildScript : MonoBehaviour
{
  [MenuItem("Build/Build WebGL No Compression")]
  public static void BuildWebGLNoCompression()
  {
    // Set the build options
    BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
    buildPlayerOptions.scenes = new[] { "Assets/Resources/Scenes/MainScene.unity" }; // Update this with your actual scenes
    buildPlayerOptions.locationPathName = "WebGL_Build";
    buildPlayerOptions.target = BuildTarget.WebGL;
    buildPlayerOptions.options = BuildOptions.None;

    // Set the build configuration to disable compression
    PlayerSettings.WebGL.compressionFormat = WebGLCompressionFormat.Disabled;

    // Build the player
    BuildPipeline.BuildPlayer(buildPlayerOptions);
  }
}
