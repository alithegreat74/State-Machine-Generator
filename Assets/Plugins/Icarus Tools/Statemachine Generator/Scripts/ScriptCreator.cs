using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScriptGenerator
{
    public static void GenerateScript(string templatePath,string generationPath)
    {

        Debug.Log($"Generating {generationPath}");
        string scriptText = "";

        try
        {
            scriptText = File.ReadAllText(templatePath);
            File.WriteAllText(generationPath, scriptText);
        }
        catch(System.Exception e)
        {
            Debug.LogError(e);
        }


       
    }

}
