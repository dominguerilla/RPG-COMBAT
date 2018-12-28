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

    #region STATS
    public enum STATS{
        HP,
        MP,
        ACCURACY,
        SPEED,
        CRIT,
        PHYS_ATK,
        PHYS_DEF,
        MAG_ATK,
        MAG_DEF,
        FIRE_ATK,
        FIRE_DEF,
        WATER_ATK,
        WATER_DEF,
        ICE_ATK,
        ICE_DEF,
        WIND_ATK,
        WIND_DEF,
        EARTH_ATK,
        EARTH_DEF,
        ELECTRIC_ATK,
        ELECTRIC_DEF,
        LIGHT_ATK,
        LIGHT_DEF,
        DARK_ATK,
        DARK_DEF,
    }
    float HP;
    float MP;
    float ACCURACY, SPEED, CRIT;
    float PHYS_ATK, PHYS_DEF;
    float MAG_ATK, MAG_DEF;
    float FIRE_ATK, FIRE_DEF;
    float WATER_ATK, WATER_DEF;
    float ICE_ATK, ICE_DEF;
    float WIND_ATK, WIND_DEF;
    float EARTH_ATK, EARTH_DEF;
    float ELECTRIC_ATK, ELECTRIC_DEF;
    float LIGHT_ATK, LIGHT_DEF;
    float DARK_ATK, DARK_DEF;
    #endregion

    // fields relating to GameObject and components
    GameObject combatantGO;
    Animator anim;

    public Combatant(CombatantData combatantData){
        this.combatantData = combatantData;
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
