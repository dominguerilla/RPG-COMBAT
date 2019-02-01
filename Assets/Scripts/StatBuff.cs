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

        public float PercentValue() {
            switch(Magnitude) {
                case MAGNITUDE.MINIMAL:
                    return 5f;
                case MAGNITUDE.LIGHT:
                    return 10f;
                case MAGNITUDE.SMALL:
                    return 15f;
                case MAGNITUDE.MEDIUM:
                    return 25f;
                case MAGNITUDE.LARGE:
                    return 45f;
                case MAGNITUDE.HEAVY:
                    return 65f;
                case MAGNITUDE.MASSIVE:
                    return 80f;
                default:
                    return flatBuff;

            }
        }
    }
}
