using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LIMB {
    [System.Serializable]
    public class Limb{
        public string name;

        [Tooltip("Uses the combatant's base stats by default.")]
        public List<StatValue> limbStats;
        public List<Equipment> equipment;

        static float DEFAULT_STAT = 1f;

        public Limb() { }

        public Limb(string name, params StatValue[] limbStats) {
            this.name = name;
            this.limbStats = new List<StatValue>(limbStats);
            equipment = new List<Equipment>();
        }

        public void Equip(Equipment equipment) {
            this.equipment.Add(equipment);
        }

        public float GetBuffedStatus(Stats.STAT stat, float baseStat) {
            float totalStats = baseStat + GetStat(stat);

            List<StatBuff> buffs = new List<StatBuff>();
            float percentageDelta = 0f;
            foreach(Equipment equip in equipment) {
                List<StatBuff> equipBuffs = equip.GetBuffs(stat);
                foreach(StatBuff equipBuff in equipBuffs) {
                    // collect percentages total of all buffs
                    // ex. +10% DEF glove +5% DEF ring -3% DEF wound = +12% DEF
                    // percentageDelta
                }
            }

            float delta = .01f * percentageDelta * totalStats;
            return totalStats + delta;
        }
        

        public float GetStat(Stats.STAT stat) {
            // TODO duplication in CombatantData.GetStat()
            if (limbStats.Exists(x => x.Stat == stat)) {
                return limbStats.Find(x => x.Stat == stat).Value;
            }else {
                return DEFAULT_STAT;
            }
        }

    }
}
