using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LIMB {
    [System.Serializable]
    public class Limb{
        public string name;

        [Tooltip("Uses the combatant's base stats by default.")]
        public List<StatValue> limbStats;

        public Limb() { }

        public Limb(string name, List<StatValue> limbStats = null) {
            this.name = name;
            this.limbStats = limbStats;
        }
    }
}
