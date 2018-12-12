using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Executes the transition between the field and a battle.
/// Initializes battle 'stage', instantiates the combatant models, destroys stage after battle ends.
/// </summary>
public class SceneTransitioner : MonoBehaviour {
    
    public Transform scenePosition;

    GameObject activeBattleScene;

    public void CreateBattleScene(Combatant[] leftParty, Combatant[] rightParty, GameObject battleScene){
        GameObject newScene = Instantiate(battleScene, scenePosition.position, scenePosition.rotation) as GameObject;
        activeBattleScene = newScene;

        GameObject leftPartyParent = newScene.transform.Find("LeftParty").gameObject;
        GameObject rightPartyParent = newScene.transform.Find("RightParty").gameObject;

        Debug.Log("Left positions");
        Transform[] leftPositions = GetPositions(leftPartyParent);
        SpawnParty(leftParty, leftPositions, leftPartyParent.transform);

        Debug.Log("Right positions");
        Transform[] rightPositions = GetPositions(rightPartyParent);
        SpawnParty(rightParty, rightPositions, rightPartyParent.transform);
    }

    public void DestroyBattleScene(){
        Destroy(activeBattleScene);
        activeBattleScene = null;
    }

    public Transform[] GetPositions(GameObject parentObj){
        List<Transform> positions = new List<Transform>();
        foreach (Transform t in parentObj.transform){
            if(t.gameObject.name.StartsWith("Position")){
                positions.Add(t);
            }
        }
        return positions.ToArray();
    }

    public void SpawnParty(Combatant[] party, Transform[] positions, Transform parent = null){
        for(int i = 0; i < party.Length; i++){
            if(i >= positions.Length){
                break;
            }
            GameObject.Instantiate<GameObject>(
                party[i].GetData().GetModel(), 
                positions[i].transform.position,
                positions[i].transform.rotation,
                parent );
        }
    }
}
