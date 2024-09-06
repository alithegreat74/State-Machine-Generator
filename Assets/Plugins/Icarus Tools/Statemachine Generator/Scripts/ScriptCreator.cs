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


        //Reading the script Template
        try
        {
            using(var stream=new FileStream(templatePath, FileMode.Open))
            {
                using(var reader=new StreamReader(stream))
                {
                    scriptText = reader.ReadToEnd();
                }
            }
        }
        catch(System.Exception e)
        {
            Debug.LogError(e);
        }


        //Creating the script and importing the code
        try
        {
            using(var stream=new FileStream(generationPath, FileMode.Create))
            {
                using (var writer = new StreamWriter(stream))
                {
                    writer.Write(scriptText);
                }
            }
        }
        catch(System.Exception e)
        {
            Debug.LogError(e);
        }
    }

}
