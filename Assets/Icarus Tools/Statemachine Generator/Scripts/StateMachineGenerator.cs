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
    private int _selectedTab = 0;
    private string _baseClassPath;
    private const string _baseClassTemplateFolder = "Assets/Icarus Tools/Statemachine Generator/Script Templates/Base Classes";


    [MenuItem("Tools/IcarusTools/State Machine Generator")]
    public static void OpenWindow()
    {
        GetWindow<StateMachineGenerator>("State Machine Generator");
    }
    private void OnGUI()
    {
        _selectedTab = GUILayout.Toolbar(_selectedTab, new string[] { "Create Base Structure", "Add New Entity" });

        // Display the appropriate panel based on the selected tab
        switch (_selectedTab)
        {
            case 0:
                CreateBaseClass_UI();
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
}

#endif
