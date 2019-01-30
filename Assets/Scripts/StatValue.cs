using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatValue {

    public Stats.STAT Stat;
    public float Value;

    public StatValue(Stats.STAT stat, float value) {
        this.Stat = stat;
        this.Value = value;
    }
}
