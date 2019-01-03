using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines an Action that a combatant performs during a turn.
/// When Actions are performed, all buffs should have already been applied to all characters.
/// 
/// Three phases of selecting an Action:
/// 1. Select an actor
/// 2. Select an Action
/// 3. Select a target
/// </summary>
public abstract class ActionDefinition : ScriptableObject{
    
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

    public enum TARGETABLE {
        ALL,
        ALLIES,
        ENEMIES
    }

    public enum TARGET_TYPE {
        SINGLE,
        GROUP
    }
    
    public MENU_CATEGORY category;
    public TARGETABLE targetable;
    public TARGET_TYPE targetType;

    /// <summary>
    /// Returns true if this Action can be performed.
    /// For example, if the actor combatant has no mana, it shouldn't be able to use
    /// mana-based skills.
    /// Called at the beginning of the 'Order' phase.
    /// </summary>
    public virtual bool CanBeCast(Combatant[] actorParty, Combatant[] enemyParty,
                                    Combatant actor){
        if(actor.IsAlive()) {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Returns true if this Action can be executed by the actor on the target.
    /// For example, perhaps a 'Sleep Kill' skill could only be performed on a sleeping target.
    /// Called at the start of the 'Select Target' phase of Action queuing.
    /// </summary>
    public virtual bool CanTarget(Combatant[] actorParty, Combatant[] enemyParty,
                                    Combatant actor, Combatant target){
        if(target.IsAlive()) {
            return true;
        }
        return false;
    }
    
    /// <summary>
    /// Change the state of the actor/target combatants. 
    /// Do the damage calculation here.
    /// </summary>
    public abstract void Execute(Combatant[] actorParty, Combatant[] enemyParty,
                                    Combatant actor, Combatant[] targets);    
    
}
