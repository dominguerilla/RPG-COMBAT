using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTester : MonoBehaviour {

    public bool DebugMode;

    [SerializeField]
    GameObject battleScenePrefab;
    [SerializeField]
    NPCParty leftParty;
    [SerializeField]
    NPCParty rightParty;

    BattleManager bManager;

    private void Awake() {
        bManager = GetComponent<BattleManager>();    
    }

    public void StartBattle(){
        bManager.StartBattle(leftParty, rightParty, battleScenePrefab);
    }

    public void EndBattle(){
        bManager.EndBattle();
    }
}
