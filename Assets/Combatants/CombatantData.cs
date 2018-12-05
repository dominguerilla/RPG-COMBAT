using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CombatantData", menuName = "Combatant Data", order = 51)]
public class CombatantData : ScriptableObject {
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
}
