using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DamageTester))]
public class DamageTesterEditor :  Editor {

    public override void OnInspectorGUI() {
        DamageTester dt = (DamageTester)target;
        if(Application.isPlaying) {
            if(GUILayout.Button("Inflict Damage")) {
                dt.InflictDamage();
            }
        }
        base.OnInspectorGUI();
    }
}
