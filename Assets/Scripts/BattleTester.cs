using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTester : MonoBehaviour {

    public bool DebugMode;

    [SerializeField]
    NPCParty leftParty;
    [SerializeField]
    NPCParty rightParty;
    FieldManager fManager;

    private void Awake() {
        fManager = GetComponent<FieldManager>();    
    }

    public void StartBattle(){
        Combatant[] leftCombatants = GenerateCombatants(leftParty);
        Debug.Log("Left party: " + leftCombatants.Length);

        Combatant[] rightCombatants = GenerateCombatants(rightParty);
        Debug.Log("Right party: " + rightCombatants.Length);

        fManager.StartBattle(leftCombatants, rightCombatants);
    }

    public void EndBattle(){
        fManager.EndBattle();
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
