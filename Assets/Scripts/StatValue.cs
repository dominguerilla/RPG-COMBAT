using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LIMB {
    [System.Serializable]
    public class StatValue {

        [SerializeField]
        Stats.CALCULATED_STAT Stat;

        [SerializeField]
        float Value;

        public StatValue(Stats.CALCULATED_STAT stat, float value) {
            this.Stat = stat;
            this.Value = value;
        }

        public Stats.CALCULATED_STAT GetStat(){
            return Stat;
        }

        public float GetValue(){
            return Value;
        }
    }
}
