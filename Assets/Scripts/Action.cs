using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a single action that a combatant performs during a turn.
/// When Actions are performed, all buffs should have already been applied to all characters.
/// </summary>
public abstract class Action : ScriptableObject{
    
    /// <summary>
    /// Specifies the UI menu that this action should belong to
    /// </summary>
    public enum MENU_CATEGORY{
        ATTACK,
        DEFEND,
        SKILL,
        ITEM,
        ESCAPE
    }
    
    public MENU_CATEGORY category;

    /// <summary>
    /// Returns true if this Action can be performed.
    /// For example, if the actor combatant has no mana, it shouldn't be able to use
    /// mana-based skills.
    /// </summary>
    public virtual bool CanBeCast(Combatant[] actorParty, Combatant[] enemyParty,
                                    Combatant actor){
        return true;
    }

    /// <summary>
    /// Returns true if this Action can be executed by the actor on the target.
    /// For example, perhaps a 'Sleep Kill' skill could only be performed on a sleeping target.
    /// </summary>
    public virtual bool CanTarget(Combatant[] actorParty, Combatant[] enemyParty,
                                    Combatant actor, Combatant target){
        return true;
    }
    
    /// <summary>
    /// Change the state of the actor/target combatants. 
    /// Do the damage calculation here.
    /// </summary>
    public abstract void Execute(Combatant[] actorParty, Combatant[] enemyParty,
                                    Combatant actor, Combatant[] targets);    
    
}
