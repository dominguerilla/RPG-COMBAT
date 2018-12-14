﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The innate stats that a combat entity has.
/// These stats are used to calculate damage dealt, given, etc.
/// </summary>
[CreateAssetMenu(fileName = "New CombatantData", menuName = "Combatant Data", order = 51)]
public class CombatantData : ScriptableObject {

    [SerializeField]
    GameObject modelPrefab;

    [SerializeField]
    int STR;
    [SerializeField]
    int INT;
    [SerializeField]
    int DEX;
    [SerializeField]
    int END;
    [SerializeField]
    int LCK;
    [SerializeField]
    int HP;
    [SerializeField]
    int MP;
    [SerializeField]
    int ATK;
    [SerializeField]
    int DEF;

    public GameObject GetModel(){
        return modelPrefab;
    }
}
