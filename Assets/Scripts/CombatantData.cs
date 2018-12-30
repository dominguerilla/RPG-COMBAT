using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The innate stats that a combat entity has.
/// These stats are used to calculate damage dealt, given, etc.
/// </summary>
[CreateAssetMenu(fileName = "New CombatantData", menuName = "Combatant Data", order = 51)]
public class CombatantData : ScriptableObject {

    [System.Serializable]
    public class Limb{
        public string name;
        public float PHYS_DEF;
        public float MAG_DEF;
    }

    [SerializeField]
    GameObject modelPrefab;

    public int LVL;
    public int STR;
    public int INT;
    public int DEX;
    public int END;
    public int LCK;
    public int HP;
    public int MP;
    public int ATK;
    public int DEF;
    
    [SerializeField]
    Limb[] ANATOMY;
    
    public Limb[] GetAnatomy(){
        return ANATOMY;
    }

    public GameObject GetModel(){
        return modelPrefab;
    }
}
