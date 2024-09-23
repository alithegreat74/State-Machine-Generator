
using System.Collections.Generic;
#if UNITY_EDITOR
namespace StatemachineGenerator
{
    public struct ScriptTemplate
    {

        private string _path;

        public ScriptTemplate(string path)
        {
            this._path = path;
        }

        public string ReplaceWords(Dictionary<string, string> vars)
        {
            string text = FileManager.ReadFile(_path);
            foreach (var v in vars)
            {
                text = text.Replace(v.Key, v.Value);
            }
            return text;
        }
    }
}
#endif