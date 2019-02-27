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
        int LVL=1, STR=1, DEX=1, END=1, INT=1, WIS=1, CHA=1, LCK=1;

        [SerializeField]
        List<StatValue> resistanceBonuses;

        [SerializeField]
        List<Limb> anatomy;

        private void OnEnable() {
            this.resistanceBonuses = new List<StatValue>();
            this.anatomy = new List<Limb>();
        }

        /// <summary>
        /// To initialize data after using ScriptableObject.CreateInstance to create this.
        /// </summary>
        public void InitializeData(string name, List<StatValue> resistanceBonuses, List<Limb> anatomy, GameObject modelPrefab = null){
            this.combatantName = name;
            this.resistanceBonuses = resistanceBonuses;
            this.anatomy = anatomy;
            this.modelPrefab = modelPrefab;
        }

        /// <summary>
        /// Returns the specified limb, or null if there is no limb with that name found.
        /// </summary>
        public Limb GetLimb(string limbName) {
            // TODO: probably better way to do this...
            if(anatomy.Exists(x => x.GetName() == limbName)) {
                return anatomy.Find(x => x.GetName() == limbName);
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
        public float GetStat(Stats.CALCULATED_STAT stat, string limb = null){
            // if limb is null, return base stat
            List<StatValue> searchStats;
            if (limb != null) {
                Limb l = GetLimb(limb);
                searchStats = l.GetLimbStats();
            }else {
                searchStats = this.resistanceBonuses;
            }

            // TODO: probably better way to do this...
            if(searchStats.Exists(x => x.GetStat() == stat)){
                return searchStats.Find(x => x.GetStat() == stat).GetValue();
            }else{
                return defaultStatValue;
            }
        }

        public GameObject GetModel(){
            return modelPrefab;
        }

        public void SetName(string name) {
            this.combatantName = name;
        }

        public string GetName(){
            return this.combatantName;
        }

        public List<Limb> GetAnatomy(){
            return anatomy;
        }

        public void SetAnatomy(params Limb[] limbs) {
            this.anatomy = new List<Limb>(limbs);
        }

        public void SetBaseStats(params StatValue[] stats) {
            this.resistanceBonuses = new List<StatValue>(stats);
        }

        
    }
}
