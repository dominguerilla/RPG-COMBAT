using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections.Generic;
using LIMB;

public class EquipmentTest {

    CombatantData cData;
    Combatant com;
    List<StatValue> baseStats;


    [SetUp]
    public void Setup() {
        cData = ScriptableObject.CreateInstance<CombatantData>();
        baseStats = new List<StatValue>();
    }

    [Test]
    public void EquipArmorFlatBuff() {
        // creating helmet
        Equipment helmet = ScriptableObject.CreateInstance<Equipment>();
        StatBuff buff = new StatBuff();
        buff.Direction = StatBuff.DIRECTION.UP;
        buff.Magnitude = StatBuff.MAGNITUDE.FLAT;
        buff.Stat = Stats.STAT.PHYS_DEF;
        buff.flatBuff = 10.0f;
        helmet.AddBuff(buff);
        
        // creating hero
        StatValue baseDef = new StatValue(Stats.STAT.PHYS_DEF, 10f);
        StatValue headDef = new StatValue(Stats.STAT.PHYS_DEF, 1f);
        Limb head = new Limb("Head", headDef);

        cData.SetName("Hero");
        cData.SetBaseStats(baseDef);
        cData.SetAnatomy(head);
        
        com = new Combatant(cData);
        float initialDef = com.GetRawStat(Stats.STAT.PHYS_DEF, "Head");
        com.Equip(helmet);
        float afterDef = com.GetCalculatedStat(Stats.STAT.PHYS_DEF, "Head");
        Assert.Less(initialDef, afterDef);
    }

    // attacking, equipping a sword to a hand, attacking again
    [Test]
    public void SwordEquipAndAttack() {
        Assert.IsTrue(false);
    }

    // being attacked, equipping armor, being attacked again
    [Test]
    public void ArmorEquipAndDefend() {
        Assert.IsTrue(false);
    }

    // shield that blocks all but 1 damage
    [Test]
    public void SuperShield() {
        Assert.IsTrue(false);
    }

}
