using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LIMB {
    public class Equipment : ScriptableObject {
        public List<StatBuff> StatBuffs;

        public void AddBuff(StatBuff buff) {
            if(StatBuffs == null)
                StatBuffs = new List<StatBuff>();

            StatBuffs.Add(buff);
        }

        /// <summary>
        /// Returns all the buffs pertaining to a given stat.
        /// </summary>
        public List<StatBuff> GetBuffs(Stats.STAT stat) {
            List<StatBuff> buffs = new List<StatBuff>();
            foreach(StatBuff buff in this.StatBuffs) {
                if(buff.Stat == stat) {
                    buffs.Add(buff);
                }
            }

            if(buffs.Count > 0) {
                return buffs;
            }else {
                return null;
            }
        }
    }
}
