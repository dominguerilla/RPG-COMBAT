using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Stats{
    
    public enum STAT{
        LVL,
        HP,
        MP,
        ACCURACY,
        SPEED,
        CRIT,
        PHYS_ATK,
        PHYS_DEF,
        MAG_ATK,
        MAG_DEF,
        FIRE_ATK,
        FIRE_DEF,
        WATER_ATK,
        WATER_DEF,
        ICE_ATK,
        ICE_DEF,
        WIND_ATK,
        WIND_DEF,
        EARTH_ATK,
        EARTH_DEF,
        ELECTRIC_ATK,
        ELECTRIC_DEF,
        LIGHT_ATK,
        LIGHT_DEF,
        DARK_ATK,
        DARK_DEF,
    }

    /// <summary>
    /// Returns the resistance for the specified damage type.
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static STAT GetResistance(Damage.TYPE type) {
        switch(type) {
            case Damage.TYPE.BLUNT:
            case Damage.TYPE.SLASH:
            case Damage.TYPE.STAB:
                return STAT.PHYS_DEF;
            default:
                throw new System.MissingFieldException("Damage type " + type.ToString() + " has no resistance.");
        }
    }

}
