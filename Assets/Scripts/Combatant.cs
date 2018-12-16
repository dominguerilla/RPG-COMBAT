using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents the GameObject of a participant in a battle.
/// Triggers animations, generates battle data from combatant's stats,
/// keeps track of current status of combatant.
/// </summary>
public class Combatant {
    
    CombatantData combatantData;
    GameObject combatantGO;
    int linePosition;
    string status;
    int hp;
    int mp;
    string buffs;

    Animator anim;

    public Combatant(int linePosition, CombatantData combatantData){
        this.linePosition = linePosition;
        this.combatantData = combatantData;
    }

    public CombatantData GetData(){
        return combatantData;
    }

    public void SetGameObject(GameObject GO) {
        this.combatantGO = GO;
    }

    public GameObject GetGameObject() {
        return this.combatantGO;
    }

    public void SetStatus(string status) {
        this.status = status;
    }

    public string GetStatus() {
        return status;
    }

    
}
