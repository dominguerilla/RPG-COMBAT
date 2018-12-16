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
    Combatant[] leftCombatants, rightCombatants;

    private void Awake() {
        bManager = GetComponent<BattleManager>();    
    }

    public void StartBattle(){
        leftCombatants = GenerateCombatants(leftParty);
        Debug.Log("Left party: " + leftCombatants.Length);

        rightCombatants = GenerateCombatants(rightParty);
        Debug.Log("Right party: " + rightCombatants.Length);

        bManager.StartBattle(leftCombatants, rightCombatants, battleScenePrefab);
    }

    public void EndBattle(){
        leftCombatants = null;
        rightCombatants = null;
        bManager.EndBattle();
    }

    Combatant[] GenerateCombatants(NPCParty party){
        CombatantData[] data = party.GetData();
        Combatant[] combatants = new Combatant[data.Length];
        for (int i = 0; i < combatants.Length; i++){

            Combatant combatant = new Combatant(i, data[i]);
            combatants[i] = combatant;
        }
        return combatants;
    }
}
