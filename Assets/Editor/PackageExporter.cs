using System.IO;
using UnityEditor;
using UnityEngine;

public static class PackageExporter
{
    /// <summary>
    /// Export Unity Package
    /// </summary>
    [MenuItem("Tools/Export Unitypackage")]
    public static void Export()
    {
        var applicationDataPath = Path.GetDirectoryName(Application.dataPath);
        if (applicationDataPath == null)
        {
            Debug.Log("directory not exist");
            return;
        }

        var outputPath = Path.Combine(applicationDataPath, "LocalDataSaver.unitypackage");
        AssetDatabase.ExportPackage("Assets/LocalDataSaver", outputPath, ExportPackageOptions.Recurse);
        Debug.Log("Finish Exporting Package!");
    }
}
