using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransitioner : MonoBehaviour {
    
    public Transform scenePosition;

    GameObject activeBattleScene;

    public void CreateBattleScene(Combatant[] leftParty, Combatant[] rightParty, GameObject battleScene){
        GameObject newScene = Instantiate(battleScene, scenePosition.position, scenePosition.rotation) as GameObject;
        activeBattleScene = newScene;

        GameObject leftPartyPositions = newScene.transform.Find("LeftParty").gameObject;
        GameObject rightPartyPositions = newScene.transform.Find("RightParty").gameObject;

        Debug.Log("Left positions");
        Positions(leftPartyPositions);

        Debug.Log("Right positions");
        Positions(rightPartyPositions);
    }

    public void DestroyBattleScene(){
        Destroy(activeBattleScene);
        activeBattleScene = null;
    }

    public Transform[] Positions(GameObject parentObj){
        List<Transform> positions = new List<Transform>();
        foreach (Transform t in parentObj.transform){
            if(t.gameObject.name.StartsWith("Position")){
                Debug.Log(t.gameObject.name);
                positions.Add(t);
            }
        }
        return positions.ToArray();
    }
}
