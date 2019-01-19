using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Generates a list of orders based on input actors and order definitions.
/// </summary>
public class OrderGenerator : MonoBehaviour {

    [SerializeField]
    CombatantData[] actors;
    
    [SerializeField]
    ActionDefinition[] orders;

    Combatant[] combatants;
    Action[] generatedActions;
	// Use this for initialization
	void Start () {
		this.combatants = GenerateCombatants(this.actors);
        this.generatedActions = GenerateOrders(this.combatants, this.orders);
	}
    
    Combatant[] GenerateCombatants(CombatantData[] actors){
        Combatant[] combatants = new Combatant[actors.Length];
        for(int i = 0; i < combatants.Length; i++){
            combatants[i] = new Combatant(actors[i]);
        }
        return combatants;
    }

    Action[] GenerateOrders(Combatant[] actors, ActionDefinition[] definitions){
        if(actors.Length != definitions.Length){
            Debug.LogWarning("Number of actors different than number of definitions!");
        }

        Action[] orders = new Action[definitions.Length];
        for(int i = 0; i < actors.Length; i++){
            Action action = new Action(definitions[i], actors[i]);

            if(definitions[i].targetType == ActionDefinition.TARGET_TYPE.GROUP){
                action.RegisterTargets(actors);
            }else{
                int randomTarget = (int)Random.Range(0f, actors.Length-1);
                action.RegisterTargets(actors[randomTarget]);
            }

            orders[i] = action;
        }
        return orders;
    }

    public List<Action> GetOrders(){
        return new List<Action>(this.generatedActions);
    }

    public void PrintOrders(){
        for(int i = 0; i < generatedActions.Length; i++){
            Debug.Log(generatedActions[i].ToString());
        }
    }
}
