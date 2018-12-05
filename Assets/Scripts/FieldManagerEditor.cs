using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FieldManager))]
public class FieldManagerEditor : Editor {

    public override void OnInspectorGUI() {
        if(Application.isPlaying){
            if(GUILayout.Button("Start Battle")){
                FieldManager manager = (FieldManager)target;
                manager.StartBattle();
            }
            if(GUILayout.Button("End Battle")){
                FieldManager manager = (FieldManager)target;
                manager.EndBattle();
            }
        }

        DrawDefaultInspector();
    }
}
