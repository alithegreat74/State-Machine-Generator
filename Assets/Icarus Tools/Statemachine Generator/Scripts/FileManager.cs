using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
namespace StatemachineGenerator
{
    public class FileManager
    {
        public static void GenerateScript(string text, string generationPath)
        {
            try
            {
                using (var stream = new FileStream(generationPath, FileMode.Create))
                {
                    using (var writer = new StreamWriter(stream))
                    {

                        writer.Write(text);
                    }
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
            }
        }
        public static string ReadFile(string templatePath)
        {
            try
            {
                string scriptText = "";
                using (var stream = new FileStream(templatePath, FileMode.Open))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        scriptText = reader.ReadToEnd();
                    }
                }
                return scriptText;

            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
                return null;
            }
        }

    }
}
#endif