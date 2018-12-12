using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combatant {
    
    CombatantData combatantData;
    int linePosition;
    string status;
    int hp;
    int mp;
    string buffs;

    public Combatant(int linePosition, CombatantData combatantData){
        this.linePosition = linePosition;
        this.combatantData = combatantData;
    }

    public CombatantData GetData(){
        return combatantData;
    }

    
}
