using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Effect", menuName = "Effect", order = 53)]
public class Effect : ScriptableObject {
    public string Name;
    public string Description;
    public int Duration;
    public StatBuff[] Buffs;
    public Damage[] Damage;
}
