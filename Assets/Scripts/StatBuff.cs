using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LIMB {
    [System.Serializable]
    public class StatBuff {

        // for ease of design
        public enum DIRECTION{
            UP = 1,
            DOWN = -1
        }

        public enum MAGNITUDE{
            FLAT,
            MINIMAL,
            LIGHT,
            SMALL,
            MEDIUM,
            LARGE,
            HEAVY,
            MASSIVE,
        }

        public MAGNITUDE Magnitude;
        public DIRECTION Direction;
        public Stats.STAT Stat;
        public float flatBuff = 1.0f;
    }
}
