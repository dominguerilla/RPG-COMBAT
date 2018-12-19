using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour {
    
    /// <summary>
    /// Only needed if FieldManager.StartBattle() is being called directly
    /// </summary>
    public GameObject battleScenePrefab;

    public bool DebugMode;
    BattleManager bm;

	// Use this for initialization
	void Awake () {
	    bm = GetComponent<BattleManager>();	
	}
    
    public void StartBattle(){
        Combatant[] left = GetLeftParty();
        Combatant[] right = GetRightParty();
        bm.StartBattle(left, right, battleScenePrefab);
    }
    
    public void EndBattle(){
        bm.EndBattle();
    }

	Combatant[] GetLeftParty(){
        int count = 5;
        Combatant[] party = new Combatant[count];
        for (int i = 0; i < count; i++){
            Combatant combatant = new Combatant(i, null);
            party[i] = combatant;
        }
        Debug.Log("Left party: " + party.Length);
        return party;
    }

    Combatant[] GetRightParty(){
        int count = 4;
        Combatant[] party = new Combatant[count];
        for (int i = 0; i < count; i++){
            Combatant combatant = new Combatant(i, null);
            party[i] = combatant;
        }
        Debug.Log("Right party: " + party.Length);
        return party;
    }
}
