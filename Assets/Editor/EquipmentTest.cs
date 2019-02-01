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
        StatBuff buff = new StatBuff(StatBuff.DIRECTION.UP, StatBuff.MAGNITUDE.LIGHT, Stats.STAT.PHYS_DEF);
        helmet.AddBuffs(buff);
        
        // creating hero
        StatValue baseDef = new StatValue(Stats.STAT.PHYS_DEF, 5f);
        StatValue headDef = new StatValue(Stats.STAT.PHYS_DEF, 5f);
        Limb head = new Limb("Head", headDef);

        cData.SetName("Hero");
        cData.SetBaseStats(baseDef);
        cData.SetAnatomy(head);
        
        com = new Combatant(cData);
        float initialDef = com.GetTotalStat(Stats.STAT.PHYS_DEF, "Head");
        com.Equip("Head", helmet);
        float afterDef = com.GetTotalStat(Stats.STAT.PHYS_DEF, "Head");
        Assert.Less(initialDef, afterDef);
        Debug.Log("Initial Def: " + initialDef + ", After Def: " + afterDef);
    }

    [Test]
    public void EquipArmorMediumDebuff() {
        Equipment cursedRing = ScriptableObject.CreateInstance<Equipment>();
        StatBuff curse = new StatBuff(StatBuff.DIRECTION.DOWN, StatBuff.MAGNITUDE.MEDIUM, Stats.STAT.DARK_DEF);
        cursedRing.AddBuffs(curse);

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
        Debug.Log("Initial Def: " + initialDef + ", After Def: " + afterDef);
    }

    [Test]
    public void EquipOneNecklaceThreeBuffsSameStat() {
        Equipment necklace = ScriptableObject.CreateInstance<Equipment>();
        StatBuff buff1 = new StatBuff(StatBuff.DIRECTION.UP, StatBuff.MAGNITUDE.SMALL, Stats.STAT.FIRE_DEF);
        StatBuff buff2 = new StatBuff(StatBuff.DIRECTION.UP, StatBuff.MAGNITUDE.SMALL, Stats.STAT.FIRE_DEF);
        StatBuff buff3 = new StatBuff(StatBuff.DIRECTION.UP, StatBuff.MAGNITUDE.SMALL, Stats.STAT.FIRE_DEF);
        necklace.AddBuffs(buff1, buff2, buff3);

        StatValue baseFireDef = new StatValue(Stats.STAT.FIRE_DEF, 5f);
        StatValue chestFireDef = new StatValue(Stats.STAT.FIRE_DEF, 2f);
        Limb chest = new Limb("Chest", chestFireDef);

        cData.SetName("Firefighter");
        cData.SetBaseStats(baseFireDef);
        cData.SetAnatomy(chest);

        com = new Combatant(cData);
        float initialDef = com.GetTotalStat(Stats.STAT.FIRE_DEF, "Chest");
        com.Equip("Chest", necklace);
        float afterDef = com.GetTotalStat(Stats.STAT.FIRE_DEF, "Chest");
        Assert.Less(initialDef, afterDef);
        Debug.Log("Initial Def: " + initialDef + ", After Def: " + afterDef);

    }

    [Test]
    public void DeEquipArmorBuff(){
        Equipment boots = ScriptableObject.CreateInstance<Equipment>();
        boots.SetName("Boots of Earth Def");
        StatBuff defBuff = new StatBuff(StatBuff.DIRECTION.UP, StatBuff.MAGNITUDE.MASSIVE, Stats.STAT.EARTH_DEF);
        boots.AddBuffs(defBuff);

        StatValue baseEarthDef = new StatValue(Stats.STAT.EARTH_DEF, 3f);
        StatValue footEarthDef = new StatValue(Stats.STAT.EARTH_DEF, 1f);
        Limb feet = new Limb("Feet", footEarthDef);

        cData.SetName("Warrior");
        cData.SetBaseStats(baseEarthDef);
        cData.SetAnatomy(feet);

        com = new Combatant(cData);
        float initialDef = com.GetTotalStat(Stats.STAT.EARTH_DEF, "Feet");
        com.Equip("Feet", boots);
        float equippedDef = com.GetTotalStat(Stats.STAT.EARTH_DEF, "Feet");
        Assert.Less(initialDef, equippedDef);
        Debug.Log("Initial Def: " + initialDef);

        com.DeEquip(boots);
        float dequippedDef = com.GetTotalStat(Stats.STAT.EARTH_DEF, "Feet");
        Assert.AreEqual(initialDef, dequippedDef);
        Debug.Log("Equipped Def: " + equippedDef + ", Dequip Def: " + dequippedDef);
    }

    [Test]
    public void EquipArmorTwoBuffsOneDebuffSameStat() {
        Equipment ring = ScriptableObject.CreateInstance<Equipment>();
        StatBuff elecDefBoost1 = new StatBuff(StatBuff.DIRECTION.UP, StatBuff.MAGNITUDE.LIGHT, Stats.STAT.ELECTRIC_DEF);
        StatBuff elecDefBoost2 = new StatBuff(StatBuff.DIRECTION.UP, StatBuff.MAGNITUDE.SMALL, Stats.STAT.ELECTRIC_DEF);
        StatBuff elecDefDebuff = new StatBuff(StatBuff.DIRECTION.DOWN, StatBuff.MAGNITUDE.SMALL, Stats.STAT.ELECTRIC_DEF);
        ring.AddBuffs(elecDefBoost1, elecDefBoost2, elecDefDebuff);

        StatValue baseElecDef = new StatValue(Stats.STAT.ELECTRIC_DEF, 7f);
        StatValue handElecDef = new StatValue(Stats.STAT.ELECTRIC_DEF, 3f);
        Limb hand = new Limb("Hands", handElecDef);

        cData.SetName("Lightning Archer");
        cData.SetBaseStats(baseElecDef);
        cData.SetAnatomy(hand);

        com = new Combatant(cData);
        float initialDef = com.GetTotalStat(Stats.STAT.ELECTRIC_DEF, "Hands");
        com.Equip("Hands", ring);
        float afterDef = com.GetTotalStat(Stats.STAT.ELECTRIC_DEF, "Hands");
        Assert.Less(initialDef,afterDef);
        Debug.Log("Initial Def: " + initialDef + ", After Def: " + afterDef);

    }

    [Test]
    public void EquipThreeEquipsAllDifferentBuffs() {
        Assert.IsTrue(false);
    }

    [Test]
    public void EquipArmorNoBuffs(){
        Assert.IsTrue(false);
    }
}
