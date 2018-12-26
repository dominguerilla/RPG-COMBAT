using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {
    
    SceneTransitioner transitioner;
    bool inBattle;

    private void Awake() {
        transitioner = GetComponent<SceneTransitioner>();
    }

    public void StartBattle(NPCParty leftParty, NPCParty rightParty, GameObject battleScenePrefab){
        if(!inBattle){
            inBattle = true;
            Combatant[] lCombatants = GenerateCombatants(leftParty);
            Combatant[] rCombatants = GenerateCombatants(rightParty);
            Debug.Log("Battle started!");
            transitioner.CreateBattleScene(lCombatants, rCombatants, battleScenePrefab);
        }
    }

    public void EndBattle(){
        if(inBattle){
            inBattle = false;
            Debug.Log("Battle ended!");
            transitioner.DestroyBattleScene();
        }
    }

    Combatant[] GenerateCombatants(NPCParty party){
        CombatantData[] data = party.GetData();
        Combatant[] combatants = new Combatant[data.Length];
        for (int i = 0; i < combatants.Length; i++){

            Combatant combatant = new Combatant(data[i]);
            combatants[i] = combatant;
        }
        return combatants;
    }

    public bool InBattle(){
        return inBattle;
    }
}
