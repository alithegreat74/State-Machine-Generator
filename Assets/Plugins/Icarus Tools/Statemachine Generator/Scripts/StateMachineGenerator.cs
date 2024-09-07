using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

/// <summary>
/// This is an editor window class that manages the input of the user when creating the statemachine
/// </summary>

#if UNITY_EDITOR
public class StateMachineGenerator : EditorWindow
{
    private List<string> _states = new List<string>();
    private Vector2 _scrollPos;
    private int _selectedTab = 0;
    private string _path;
    private const string _baseClassTemplateFolder = "Assets/Plugins/Icarus Tools/Statemachine Generator/Script Templates/Base Classes";
    #region templateNames
    private readonly string[] _baseTemplates = new string[] { $"{_baseClassTemplateFolder}/Entity.txt", $"{_baseClassTemplateFolder}/State.txt", $"{_baseClassTemplateFolder}/Statemachine.txt" };
    private readonly string[] _baseEnemyClass = new string[] { $"{_baseClassTemplateFolder}/Enemy.txt", $"{_baseClassTemplateFolder}/EnemyState.txt" };
    #endregion


    [MenuItem("Tools/IcarusTools/State Machine Generator")]
    public static void OpenWindow()
    {
        GetWindow<StateMachineGenerator>("State Machine Generator");
    }
    private void OnGUI()
    {
        _selectedTab = GUILayout.Toolbar(_selectedTab, new string[] { "Create Base Structure", "Add Player Classes", "Add Enemy Classes", "Create a new Enemy"});

        // Display the appropriate panel based on the selected tab
        switch (_selectedTab)
        {
            case 0:
                CreateBaseClass_UI();
                break;
            case 1:
                CreatePlayerClasses_UI();
                break;
            case 2:
                CreateEnemyClasses_UI();
                break;
        }

    }

    private void CreateBaseClass_UI()
    {

        GUILayout.Label("By Clicking The Create Structure button, the necessary classes like Entity\n, and State And Statemachine will be added to your project");

        GUILayout.Label("Enter the folder you want the scripts be generated (Absolute Path)");
        _path = EditorGUILayout.TextField("", _path);

        if (GUILayout.Button("Create Base Class Structure"))
        {
            GenerateScripts(_baseTemplates,new Dictionary<string, string>());
        }
    }


    private void CreatePlayerClasses_UI()
    {
        GUILayout.Label("By Clicking The Create Player Classes button, the necessary classes like\nPlayer, PlayerState and all the states defined by you here will be added to your project");
        GUILayout.Label("Enter the folder you want the scripts be generated (Absolute Path)");
        _path = EditorGUILayout.TextField("", _path);

        if (_states.Count <= 0)
            _states.Add("");
        GUILayout.Label("Enter Your State Names");

        _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos);

        for (int i = 0; i < _states.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();

            _states[i] = EditorGUILayout.TextField("State Name", _states[i]);

            if (GUILayout.Button("Remove", GUILayout.Width(60)))
            {
                _states.RemoveAt(i);
            }

            EditorGUILayout.EndHorizontal();
        }
        if (GUILayout.Button("Add States", GUILayout.Width(100)))
        {
            _states.Add("");
        }
        EditorGUILayout.EndScrollView();

        if (GUILayout.Button("Create Scripts"))
        {
            GenerateScript($"{_baseClassTemplateFolder}/PlayerState.txt", "PlayerState.cs", new Dictionary<string, string>());

            string stateInitializatoin = "";
            string stateDeclaration = "";
            foreach(var state in _states)
            {
                stateDeclaration += $"public Player{state}State {state}State {{ get; private set;}}\n\t";
                stateInitializatoin += $"{state}State = new Player{state}State(this,statemachine,\"{state}\",this);\n\t\t";
                var dictionary = new Dictionary<string, string>() { { "#StateName", state } };
                GenerateScript($"{_baseClassTemplateFolder}/PlayerTemplateState.txt", $"Player{state}State.cs", dictionary);
            }

            var dict = new Dictionary<string, string>() { { "#StateDeclaration", stateDeclaration }, { "#StatesInitialization", stateInitializatoin }, { "#StatemachineInitialization", $"statemachine.Initialize({_states[0]}State);" } };
            GenerateScript($"{_baseClassTemplateFolder}/Player.txt", "Player.cs", dict);

        }
    }

    private void CreateEnemyClasses_UI()
    {
        GUILayout.Label("By Clicking The Create Structure button, the necessary classes like Enemy\n, and EnemyState will be added to your project");

        GUILayout.Label("Enter the folder you want the scripts be generated (Absolute Path)");
        _path = EditorGUILayout.TextField("", _path);

        if (GUILayout.Button("Create Base Class Structure"))
        {
            GenerateScripts(_baseEnemyClass, new Dictionary<string, string>());   
        }
    }

    private void GenerateScripts(string[] templates, Dictionary<string, string> replacements)
    {
        foreach (var template in templates)
        {
            var filename=new FileInfo(template);
            string fname = filename.Name.Replace(".txt", ".cs");
            GenerateScript(template, fname, replacements);
        }
    }

    private void GenerateScript(string template, string scriptName, Dictionary<string, string> replacements)
    {
        
        var temp = new ScriptTemplate(template);
        FileManager.GenerateScript(temp.ReplaceWords(replacements), $"{_path}/{scriptName}");

        AssetDatabase.Refresh();
    }
}



#endif
