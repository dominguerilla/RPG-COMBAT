using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LIMB {
    public class Equipment : ScriptableObject {
        public List<StatBuff> StatBuffs;

        public void AddBuffs(params StatBuff[] buffs) {
            if(StatBuffs == null)
                StatBuffs = new List<StatBuff>();

            foreach(StatBuff buff in buffs){
                StatBuffs.Add(buff);
            }
        }

        /// <summary>
        /// Returns all the buffs pertaining to a given stat.
        /// </summary>
        public List<StatBuff> GetBuffs(Stats.DERIVED_STAT stat) {
            if(this.StatBuffs == null)
                this.StatBuffs = new List<StatBuff>();

            List<StatBuff> buffs = new List<StatBuff>();
            foreach(StatBuff buff in this.StatBuffs) {
                if(buff.Stat == stat) {
                    buffs.Add(buff);
                }
            }

            return buffs;
        }

        public void SetName(string name){
            this.name = name;
        }
    }
}
