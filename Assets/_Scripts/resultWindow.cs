#if(UNITY_EDITOR)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class resultWindow : EditorWindow 
{
    public int Result = 0;

    public int reelOne = 0;
    public string reelOneImage = "";
    public int reelTwo = 0;
    public string reelTwoImage = "";
    public int reelThree = 0;
    public string reelThreeImage = "";

    public int winAmount = 0;
    public int ActiveReelCount = 0;

    public static resultWindow instance { get { return GetWindow<resultWindow>(); } }

    [MenuItem("Window/spinResults")]
    public static void ShowWindow()
    {
        GetWindow<resultWindow>("spinResults");
    }
    private void OnGUI()
    {

        GUILayout.Label("Result: " + Result, EditorStyles.boldLabel);
        GUILayout.Label("reelOne: " + reelOne + " "+ reelOneImage, EditorStyles.boldLabel);
        GUILayout.Label("reelTwo: " + reelTwo + " "+ reelTwoImage, EditorStyles.boldLabel);
        GUILayout.Label("reelThree: " + reelThree + " "+ reelThreeImage, EditorStyles.boldLabel);
        GUILayout.Label("winAmount: " + winAmount, EditorStyles.boldLabel);
        GUILayout.Label("ActiveReelCount: " + ActiveReelCount, EditorStyles.boldLabel);


    }
}
#endif
