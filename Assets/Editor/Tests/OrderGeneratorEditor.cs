using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(OrderGenerator))]
public class OrderGeneratorEditor : Editor {

    public override void OnInspectorGUI() {
        OrderGenerator og = (OrderGenerator)target;
        if(Application.isPlaying){
            if(GUILayout.Button("Generate Orders")){
                og.GenerateOrders();
            }
        }
        base.OnInspectorGUI();
    }

}
