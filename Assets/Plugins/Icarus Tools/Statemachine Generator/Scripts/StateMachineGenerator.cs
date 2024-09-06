using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// This is an editor window class that manages the input of the user when creating the statemachine
/// </summary>

#if UNITY_EDITOR
public class StateMachineGenerator : EditorWindow
{
    private List<string> _playerStates = new List<string>();
    private Vector2 _scrollPos;
    private int _selectedTab = 0;
    private string _baseClassPath;
    private string _enemyClassPath;
    private string _playerClassPath;
    private const string _baseClassTemplateFolder = "Assets/Icarus Tools/Statemachine Generator/Script Templates/Base Classes";


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
        _baseClassPath = EditorGUILayout.TextField("", _baseClassPath);

        if (GUILayout.Button("Create Base Class Structure"))
        {
            ScriptGenerator.GenerateScript($"{_baseClassTemplateFolder}/Entity.txt",$"{_baseClassPath}/Entity.cs");
            ScriptGenerator.GenerateScript($"{_baseClassTemplateFolder}/State.txt",$"{_baseClassPath}/State.cs");
            ScriptGenerator.GenerateScript($"{_baseClassTemplateFolder}/Statemachine.txt", $"{_baseClassPath}/Statemachine.cs");
        }
    }
    private void CreatePlayerClasses_UI()
    {
        GUILayout.Label("By Clicking The Create Player Classes button, the necessary classes like\nPlayer, PlayerState and all the states defined by you here will be added to your project");
        GUILayout.Label("Enter the folder you want the scripts be generated (Absolute Path)");
        _playerClassPath = EditorGUILayout.TextField("", _playerClassPath);

        if (_playerStates.Count <= 0)
            _playerStates.Add("");
        GUILayout.Label("Enter Your State Names");

        _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos);

        for (int i = 0; i < _playerStates.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();

            _playerStates[i] = EditorGUILayout.TextField("State Name", _playerStates[i]);

            if (GUILayout.Button("Remove", GUILayout.Width(60)))
            {
                _playerStates.RemoveAt(i);
            }

            EditorGUILayout.EndHorizontal();
        }
        if (GUILayout.Button("Add States", GUILayout.Width(100)))
        {
            _playerStates.Add("");
        }
        EditorGUILayout.EndScrollView();
    }

    private void CreateEnemyClasses_UI()
    {
        GUILayout.Label("By Clicking The Create Structure button, the necessary classes like Enemy\n, and EnemyState will be added to your project");

        GUILayout.Label("Enter the folder you want the scripts be generated (Absolute Path)");
        _enemyClassPath = EditorGUILayout.TextField("", _enemyClassPath);

        if (GUILayout.Button("Create Base Class Structure"))
        {
            ScriptGenerator.GenerateScript($"{_baseClassTemplateFolder}/Enemy.txt", $"{_enemyClassPath}/Enemy.cs");
            ScriptGenerator.GenerateScript($"{_baseClassTemplateFolder}/EnemyState.txt", $"{_enemyClassPath}/EnemyState.cs");
        }
    }
}



#endif
