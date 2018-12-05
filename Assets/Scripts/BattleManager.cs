using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {
    
    SceneTransitioner transitioner;
    bool inBattle;

    private void Awake() {
        transitioner = GetComponent<SceneTransitioner>();
    }

    public void StartBattle(Combatant[] leftParty, Combatant[] rightParty, GameObject battleScenePrefab){
        if(!inBattle){
            inBattle = true;
            Debug.Log("Battle started!");
            transitioner.CreateBattleScene(leftParty, rightParty, battleScenePrefab);
        }
    }

    public void EndBattle(){
        if(inBattle){
            inBattle = false;
            Debug.Log("Battle ended!");
            transitioner.DestroyBattleScene();
        }
    }

    public bool InBattle(){
        return inBattle;
    }
}
