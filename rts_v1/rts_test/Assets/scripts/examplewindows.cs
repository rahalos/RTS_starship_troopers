using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class examplewindows : EditorWindow
{
    
    public static void ShowWindow ()
    {
        EditorWindow.GetWindow<examplewindows>("Example");

    }


    void OneGUI()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
