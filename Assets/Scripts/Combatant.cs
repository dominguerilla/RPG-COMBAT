using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Represents the GameObject of a participant in a battle.
/// Triggers animations, generates battle data from combatant's stats,
/// keeps track of current status of combatant.
/// </summary>
/// <remarks>
/// The data flow of spawning a combatant:
/// 1. Designer (you!) creates a CombatantData asset and fills out the fields
/// 2. Whatever AI system that generates enemy parties uses CombatantData to generate a Combatant, and passes Combatants to the BattleManager to start a battle
/// 3. BattleManager calculates the status of the Combatant based on its Data (hp, mp, attack, etc.) and then passes Combatant to SceneTransitioner
/// 4. SceneTransitioner spawns the prefab model specified by the CombatantData of each Combatant, and registers the newly spawned GameObject to the Combatant class
/// </remarks>
public class Combatant {
    
    CombatantData combatantData;
    string status;
    Effect[] currentEffects;


    // fields relating to GameObject and components
    GameObject combatantGO;
    Animator anim;
    bool isAlive = true;
    float currentHealth;

    public Combatant(CombatantData combatantData){
        this.combatantData = combatantData;
        this.currentHealth = combatantData.GetStat(Stats.STAT.HP);
    }


    // Used to initialize the component fields of this combatant with what's found in the combatantGO
    public void InitializeCombatantComponents() {
        if(!combatantGO) {
            Debug.LogError("Combatant does not have associated GameObject!");
        }else {
            this.anim = combatantGO.GetComponent<Animator>();
        }
    }

    public void PlayAnimation(string trigger) {
        this.anim.SetTrigger(trigger);
    }

    public CombatantData GetData(){
        return combatantData;
    }

    public void SetGameObject(GameObject GO) {
        this.combatantGO = GO;
    }

    public bool IsAlive() {
        return isAlive;
    }

    /// <summary>
    /// Inflicts damage on a given limb, calculating based on resistances of limb and type/magnitude of damage.
    /// If limbName is null, uses base stat resistances.
    /// </summary>
    /// <returns>Net damage inflicted on this combatant.</returns>
    public float InflictDamage(Damage dmg, string limbName = null) {
        
        // ** super dumb damage calculation ** //
        // get damage magnitude
        float damageMagnitude = 0.0f;
        switch (dmg.magnitude) {
            case Damage.MAGNITUDE.FLAT:
                damageMagnitude = dmg.flatDamage;
                break;
            default:
                Debug.LogError("Damage type " + dmg.magnitude.ToString() + " unsupported.");
                damageMagnitude = 0.0f;
                break;
        }
        
        float totalLimbResistance = GetTotalLimbResistance(dmg.type, limbName);

        // Damage calculation!!!
        float totalDamage = damageMagnitude - totalLimbResistance;

        this.currentHealth -= totalDamage;
        if(this.currentHealth <= 0.0f) {
            this.isAlive = false;
        }

        return totalDamage;
    }

    /// <summary>
    /// Returns the current resistance value specified for the limb, taking into account the combatant's base stats and its equipment/skill/buffs
    /// For now, returns base resistance.
    /// </summary>
    /// <returns></returns>
    public float GetTotalLimbResistance(Damage.TYPE type, string limbName) {
        Stats.STAT stat = Stats.GetResistance(type);
        return this.combatantData.GetStat(stat, limbName);
    }


    public override string ToString() {
        return combatantData.GetName();
    }
}
