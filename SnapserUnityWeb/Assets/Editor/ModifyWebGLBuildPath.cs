using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

public class ModifyWebGLBuildPath
{
  [PostProcessBuild(1)]
  public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
  {
    if (target != BuildTarget.WebGL) return;

#if DISCORD_BUILD
    // Define the paths
    string rootPath = pathToBuiltProject;
    // string buildFolder = Path.Combine(rootPath, "Build");
    string indexHtmlPath = Path.Combine(rootPath, "index.html");

    // Move files from Build to root
    // if (Directory.Exists(buildFolder))
    // {
    //     string[] files = Directory.GetFiles(buildFolder);
    //     foreach (string file in files)
    //     {
    //         string fileName = Path.GetFileName(file);
    //         string destFile = Path.Combine(rootPath, fileName);
    //         File.Move(file, destFile);
    //     }

    //     // Optionally, delete the now empty Build folder
    //     Directory.Delete(buildFolder, true);
    // }

    // Update index.html to reflect new paths
    if (File.Exists(indexHtmlPath))
    {
      string htmlContent = File.ReadAllText(indexHtmlPath);
      htmlContent = htmlContent.Replace("var buildUrl = \"Build\";", "var buildUrl = \"/.proxy/Build\";");
      File.WriteAllText(indexHtmlPath, htmlContent);
    }

    // Refresh the AssetDatabase after the move
    AssetDatabase.Refresh();
#endif
  }
}
