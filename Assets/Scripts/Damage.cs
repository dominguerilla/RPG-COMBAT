using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Damage {
    public enum TYPE{
        NONE,
        BLUNT,
        SLASH,
        STAB,
        FIRE,
        WATER,
        ICE,
        WIND,
        EARTH,
        ELECTRIC,
        PSYCHIC,
        LIGHT,
        DARK,
    }
    
    public enum MAGNITUDE{
        FLAT,
        MINIMAL,
        LIGHT,
        SMALL,
        MEDIUM,
        LARGE,
        HEAVY,
        MASSIVE
    }

    public enum TIMING{
        INSTANT,
        TURN_START,
        TURN_END,
    }

    public TIMING timing;
    public TYPE type;
    public MAGNITUDE magnitude;
    public float flatDamage;
}
