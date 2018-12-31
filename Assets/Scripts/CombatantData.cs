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

        [Tooltip("Uses the combatant's base stats by default.")]
        public List<StatValue> limbStats;
    }

    [SerializeField]
    GameObject modelPrefab;

    [SerializeField]
    List<StatValue> baseStats;

    float defaultStatValue = 10.0f;

    public float GetStat(Stats.STAT stat){
        // TODO: probably better way to do this...
        if(baseStats.Exists(x => x.Stat == stat)){
            return baseStats.Find(x => x.Stat == stat).Value;
        }else{
            return defaultStatValue;
        }
    }
    
    [SerializeField]
    Limb[] anatomy;
    
    public Limb[] GetAnatomy(){
        return anatomy;
    }

    public GameObject GetModel(){
        return modelPrefab;
    }
}
