using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LIMB {
    /// <summary>
    /// The innate stats that a combat entity has.
    /// These stats are used to calculate damage dealt, given, etc.
    /// </summary>
    [CreateAssetMenu(fileName = "New CombatantData", menuName = "Combatant Data", order = 51)]
    public class CombatantData : ScriptableObject {

        float defaultStatValue = 10.0f;

        [SerializeField]
        string combatantName;

        [SerializeField]
        GameObject modelPrefab;

        [SerializeField]
        List<StatValue> baseStats;

        [SerializeField]
        List<Limb> anatomy;
       
        public CombatantData(string name, List<StatValue> baseStats, List<Limb> anatomy, GameObject modelPrefab = null) {
            this.combatantName = name;
            this.baseStats = baseStats;
            this.anatomy = anatomy;
            this.modelPrefab = modelPrefab;
        }
        
        /// <summary>
        /// To initialize data after using ScriptableObject.CreateInstance to create this.
        /// </summary>
        public void InitializeData(string name, List<StatValue> baseStats, List<Limb> anatomy, GameObject modelPrefab = null){
            this.combatantName = name;
            this.baseStats = baseStats;
            this.anatomy = anatomy;
            this.modelPrefab = modelPrefab;
        }

        /// <summary>
        /// Returns the specified limb, or null if there is no limb with that name found.
        /// </summary>
        public Limb GetLimb(string limbName) {
            // TODO: probably better way to do this...
            if(anatomy.Exists(x => x.name == limbName)) {
                return anatomy.Find(x => x.name == limbName);
            }else {
                Debug.LogError("Limb " + limbName + " not found on " + combatantName + ".");
                return null;
            }
        }

        /// <summary>
        /// Returns the base stat specified, or of the limb if it exists.
        /// </summary>
        /// <param name="stat"></param>
        /// <param name="limb"></param>
        /// <returns></returns>
        public float GetStat(Stats.STAT stat, string limb = null){
            // if limb is null, return base stat
            List<StatValue> searchStats;
            if (limb != null) {
                Limb l = GetLimb(limb);
                searchStats = l.limbStats;
            }else {
                searchStats = this.baseStats;
            }

            // TODO: probably better way to do this...
            if(searchStats.Exists(x => x.Stat == stat)){
                return searchStats.Find(x => x.Stat == stat).Value;
            }else{
                return defaultStatValue;
            }
        }

        public GameObject GetModel(){
            return modelPrefab;
        }

        public string GetName(){
            return this.combatantName;
        }

        public List<Limb> GetAnatomy(){
            return anatomy;
        }

        
    }
}
