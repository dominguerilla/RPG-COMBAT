using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections.Generic;
using LIMB;

public class EquipmentTest {

    CombatantData cData;
    Combatant com;


    [SetUp]
    public void Setup() {
        cData = ScriptableObject.CreateInstance<CombatantData>();
    }

    [Test]
    public void EquipArmorLightBuff() {
        // creating helmet
        Equipment helmet = ScriptableObject.CreateInstance<Equipment>();
        StatBuff buff = new StatBuff();
        buff.Direction = StatBuff.DIRECTION.UP;
        buff.Magnitude = StatBuff.MAGNITUDE.LIGHT;
        buff.Stat = Stats.STAT.PHYS_DEF;
        helmet.AddBuff(buff);
        
        // creating hero
        StatValue baseDef = new StatValue(Stats.STAT.PHYS_DEF, 5f);
        StatValue headDef = new StatValue(Stats.STAT.PHYS_DEF, 5f);
        Limb head = new Limb("Head", headDef);

        cData.SetName("Hero");
        cData.SetBaseStats(baseDef);
        cData.SetAnatomy(head);
        
        com = new Combatant(cData);
        float initialDef = com.GetTotalStat(Stats.STAT.PHYS_DEF, "Head");
        Debug.Log("Initial Def: " + initialDef);
        com.Equip("Head", helmet);
        float afterDef = com.GetTotalStat(Stats.STAT.PHYS_DEF, "Head");
        Debug.Log("After Def: " + afterDef);
        Assert.Less(initialDef, afterDef);
    }

    [Test]
    public void EquipArmorMediumDebuff() {
        Equipment cursedRing = ScriptableObject.CreateInstance<Equipment>();
        StatBuff curse = new StatBuff();
        curse.Direction = StatBuff.DIRECTION.DOWN;
        curse.Magnitude = StatBuff.MAGNITUDE.MEDIUM;
        curse.Stat = Stats.STAT.DARK_DEF;
        cursedRing.AddBuff(curse);

        StatValue baseDef = new StatValue(Stats.STAT.DARK_DEF, 3f);
        StatValue handDef = new StatValue(Stats.STAT.DARK_DEF, 2f);
        Limb hand = new Limb("Hand", handDef);

        cData.SetName("Mage");
        cData.SetBaseStats(baseDef);
        cData.SetAnatomy(hand);

        com = new Combatant(cData);
        float initialDef = com.GetTotalStat(Stats.STAT.DARK_DEF, "Hand");
        Debug.Log("Initial dark def: " + initialDef);
        com.Equip("Hand", cursedRing);
        float afterDef = com.GetTotalStat(Stats.STAT.DARK_DEF, "Hand");
        Debug.Log("After dark def: " + afterDef);
        Assert.Less(afterDef,initialDef);
    }

    [Test]
    public void EquipArmorThreeSmallBuffs() {
        Assert.IsTrue(false);
    }

    [Test]
    public void EquipThreeEquipsAllDifferentBuffs() {
        Assert.IsTrue(false);
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
