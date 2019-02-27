﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LIMB {
    [System.Serializable]
    public class StatValue {

        [SerializeField]
        Stats.DERIVED_STAT Stat;

        [SerializeField]
        float Value;

        public StatValue(Stats.DERIVED_STAT stat, float value) {
            this.Stat = stat;
            this.Value = value;
        }

        public Stats.DERIVED_STAT GetStat(){
            return Stat;
        }

        public float GetValue(){
            return Value;
        }
    }
}
