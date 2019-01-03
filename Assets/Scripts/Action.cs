using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Uses an ActionDefinition and specified Combatant to start building an Action, which has a target.
/// </summary>
/// When Actions are performed, all buffs should have already been applied to all characters.
/// Three phases of selecting an Action:
/// 1. Select an actor
/// 2. Select an Action
/// 3. Select a target
public class Action {
    
    ActionDefinition actionDefinition;
    Combatant actor;
    Combatant[] actorParty;
    Combatant[] otherParty;

    Combatant[] registeredTargets;

    public Action(ActionDefinition actionDefinition, 
        Combatant actor, 
        Combatant[] actorParty = null, Combatant[] otherParty = null) {

        this.actionDefinition = actionDefinition;
        this.actor = actor;
        this.actorParty = actorParty;
        this.otherParty = otherParty;
    }

    /// <summary>
    /// For ActionDefinitions with targetType set to GROUP, this would be called with the targeted party.
    /// For ActionDefinitions with targetType set to SINGLE, this would be called only with the single target.
    /// </summary>
    /// <param name="possibleTargets"></param>
    public void RegisterTargets(params Combatant[] possibleTargets) {
        List<Combatant> validTargets = new List<Combatant>();
        foreach(Combatant target in possibleTargets) {
           if(actionDefinition.CanTarget(actor, target, actorParty, otherParty)) {
                validTargets.Add(target);
            } 
        }

        registeredTargets = validTargets.ToArray();    
    }

    /// <summary>
    /// Uses ActionDefinition.Execute() to execute action. Called during the Action phase one at a time.
    /// </summary>
    /// Should check if the action is still valid before executing!
    public void ExecuteAction() {
        throw new System.NotImplementedException();
    }

}
