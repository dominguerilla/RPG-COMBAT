using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for attacks made with equipped weapons.
/// </summary>
[CreateAssetMenu(fileName = "New BasicAttack", menuName = "Basic Attack", order = 51)]
public class BasicAttack : ActionDefinition {

    public Damage damage;

    public override bool CanTarget(Combatant actor, Combatant target, Combatant[] actorParty = null, Combatant[] enemyParty = null) {
        if(target.IsAlive() && actor != target){
            return true;
        }
        return false;
    }

    public override void Execute(Combatant[] actorParty, Combatant[] enemyParty, Combatant actor, Combatant[] targets, string limbName = null) {
        foreach(Combatant target in targets) {
            target.InflictDamage(damage, limbName);
        }
    }
}
