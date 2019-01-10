using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CameraTester))]
public class CameraTesterEditor : Editor{

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        CameraTester ct = (CameraTester)target;
        if(Application.isPlaying){
            if(GUILayout.Button("Zoom In")){
                ct.ZoomIn();
            }
            if(GUILayout.Button("Zoom Out")){
                ct.ZoomOut();
            }
        }
    }
}
