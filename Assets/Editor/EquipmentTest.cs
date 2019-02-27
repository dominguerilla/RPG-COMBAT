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
    public void EquipArmorLightLimbBuff() {
        // creating helmet
        Equipment helmet = ScriptableObject.CreateInstance<Equipment>();
        StatBuff buff = new StatBuff(StatBuff.DIRECTION.UP, StatBuff.MAGNITUDE.LIGHT, Stats.DERIVED_STAT.PHYS_DEF);
        helmet.AddBuffs(buff);
        
        // creating hero
        StatValue baseDef = new StatValue(Stats.DERIVED_STAT.PHYS_DEF, 5f);
        StatValue headDef = new StatValue(Stats.DERIVED_STAT.PHYS_DEF, 5f);
        Limb head = new Limb("Head", headDef);

        cData.SetName("Hero");
        cData.SetBaseStats(baseDef);
        cData.SetAnatomy(head);
        
        com = new Combatant(cData);
        float initialDef = com.GetTotalStat(Stats.DERIVED_STAT.PHYS_DEF, "Head");
        com.Equip("Head", helmet);
        float afterDef = com.GetTotalStat(Stats.DERIVED_STAT.PHYS_DEF, "Head");
        Assert.Less(initialDef, afterDef);
        Debug.Log("Initial Def: " + initialDef + ", After Def: " + afterDef);
    }

    [Test]
    public void EquipArmorMediumLimbDebuff() {
        Equipment cursedRing = ScriptableObject.CreateInstance<Equipment>();
        StatBuff curse = new StatBuff(StatBuff.DIRECTION.DOWN, StatBuff.MAGNITUDE.MEDIUM, Stats.DERIVED_STAT.DARK_DEF);
        cursedRing.AddBuffs(curse);

        StatValue baseDef = new StatValue(Stats.DERIVED_STAT.DARK_DEF, 3f);
        StatValue handDef = new StatValue(Stats.DERIVED_STAT.DARK_DEF, 2f);
        Limb hand = new Limb("Hand", handDef);

        cData.SetName("Mage");
        cData.SetBaseStats(baseDef);
        cData.SetAnatomy(hand);

        com = new Combatant(cData);
        float initialDef = com.GetTotalStat(Stats.DERIVED_STAT.DARK_DEF, "Hand");
        Debug.Log("Initial dark def: " + initialDef);
        com.Equip("Hand", cursedRing);
        float afterDef = com.GetTotalStat(Stats.DERIVED_STAT.DARK_DEF, "Hand");
        Debug.Log("After dark def: " + afterDef);
        Assert.Less(afterDef,initialDef);
        Debug.Log("Initial Def: " + initialDef + ", After Def: " + afterDef);
    }

    [Test]
    public void EquipOneNecklaceThreeLimbBuffsSameStat() {
        Equipment necklace = ScriptableObject.CreateInstance<Equipment>();
        StatBuff buff1 = new StatBuff(StatBuff.DIRECTION.UP, StatBuff.MAGNITUDE.SMALL, Stats.DERIVED_STAT.FIRE_DEF);
        StatBuff buff2 = new StatBuff(StatBuff.DIRECTION.UP, StatBuff.MAGNITUDE.SMALL, Stats.DERIVED_STAT.FIRE_DEF);
        StatBuff buff3 = new StatBuff(StatBuff.DIRECTION.UP, StatBuff.MAGNITUDE.SMALL, Stats.DERIVED_STAT.FIRE_DEF);
        necklace.AddBuffs(buff1, buff2, buff3);

        StatValue baseFireDef = new StatValue(Stats.DERIVED_STAT.FIRE_DEF, 5f);
        StatValue chestFireDef = new StatValue(Stats.DERIVED_STAT.FIRE_DEF, 2f);
        Limb chest = new Limb("Chest", chestFireDef);

        cData.SetName("Firefighter");
        cData.SetBaseStats(baseFireDef);
        cData.SetAnatomy(chest);

        com = new Combatant(cData);
        float initialDef = com.GetTotalStat(Stats.DERIVED_STAT.FIRE_DEF, "Chest");
        com.Equip("Chest", necklace);
        float afterDef = com.GetTotalStat(Stats.DERIVED_STAT.FIRE_DEF, "Chest");
        Assert.Less(initialDef, afterDef);
        Debug.Log("Initial Def: " + initialDef + ", After Def: " + afterDef);

    }

    [Test]
    public void DeEquipArmorLimbBuff(){
        Equipment boots = ScriptableObject.CreateInstance<Equipment>();
        boots.SetName("Boots of Earth Def");
        StatBuff defBuff = new StatBuff(StatBuff.DIRECTION.UP, StatBuff.MAGNITUDE.MASSIVE, Stats.DERIVED_STAT.EARTH_DEF);
        boots.AddBuffs(defBuff);

        StatValue baseEarthDef = new StatValue(Stats.DERIVED_STAT.EARTH_DEF, 3f);
        StatValue footEarthDef = new StatValue(Stats.DERIVED_STAT.EARTH_DEF, 1f);
        Limb feet = new Limb("Feet", footEarthDef);

        cData.SetName("Warrior");
        cData.SetBaseStats(baseEarthDef);
        cData.SetAnatomy(feet);

        com = new Combatant(cData);
        float initialDef = com.GetTotalStat(Stats.DERIVED_STAT.EARTH_DEF, "Feet");
        com.Equip("Feet", boots);
        float equippedDef = com.GetTotalStat(Stats.DERIVED_STAT.EARTH_DEF, "Feet");
        Assert.Less(initialDef, equippedDef);
        Debug.Log("Initial Def: " + initialDef);

        com.DeEquip(boots);
        float dequippedDef = com.GetTotalStat(Stats.DERIVED_STAT.EARTH_DEF, "Feet");
        Assert.AreEqual(initialDef, dequippedDef);
        Debug.Log("Equipped Def: " + equippedDef + ", Dequip Def: " + dequippedDef);
    }

    [Test]
    public void EquipArmorTwoBuffsOneDebuffSameLimbStat() {
        Equipment ring = ScriptableObject.CreateInstance<Equipment>();
        StatBuff elecDefBoost1 = new StatBuff(StatBuff.DIRECTION.UP, StatBuff.MAGNITUDE.LIGHT, Stats.DERIVED_STAT.ELECTRIC_DEF);
        StatBuff elecDefBoost2 = new StatBuff(StatBuff.DIRECTION.UP, StatBuff.MAGNITUDE.SMALL, Stats.DERIVED_STAT.ELECTRIC_DEF);
        StatBuff elecDefDebuff = new StatBuff(StatBuff.DIRECTION.DOWN, StatBuff.MAGNITUDE.SMALL, Stats.DERIVED_STAT.ELECTRIC_DEF);
        ring.AddBuffs(elecDefBoost1, elecDefBoost2, elecDefDebuff);

        StatValue baseElecDef = new StatValue(Stats.DERIVED_STAT.ELECTRIC_DEF, 7f);
        StatValue handElecDef = new StatValue(Stats.DERIVED_STAT.ELECTRIC_DEF, 3f);
        Limb hand = new Limb("Hands", handElecDef);

        cData.SetName("Lightning Archer");
        cData.SetBaseStats(baseElecDef);
        cData.SetAnatomy(hand);

        com = new Combatant(cData);
        float initialDef = com.GetTotalStat(Stats.DERIVED_STAT.ELECTRIC_DEF, "Hands");
        com.Equip("Hands", ring);
        float afterDef = com.GetTotalStat(Stats.DERIVED_STAT.ELECTRIC_DEF, "Hands");
        Assert.Less(initialDef,afterDef);
        Debug.Log("Initial Def: " + initialDef + ", After Def: " + afterDef);

    }

    [Test]
    public void EquipTwoEquipsDifferentLimbBuffs() {
        Equipment ring = ScriptableObject.CreateInstance<Equipment>();
        StatBuff ringBuff = new StatBuff(StatBuff.DIRECTION.UP, StatBuff.MAGNITUDE.LIGHT, Stats.DERIVED_STAT.DARK_DEF);
        ring.AddBuffs(ringBuff);

        Equipment diodem = ScriptableObject.CreateInstance<Equipment>();
        StatBuff diodemBuff = new StatBuff(StatBuff.DIRECTION.UP, StatBuff.MAGNITUDE.LIGHT, Stats.DERIVED_STAT.MAG_ATK);
        diodem.AddBuffs(diodemBuff);

        StatValue baseDarkDef = new StatValue(Stats.DERIVED_STAT.DARK_DEF, 5f);
        StatValue handDarkDef = new StatValue(Stats.DERIVED_STAT.DARK_DEF, 2f);
        StatValue baseMagATK = new StatValue(Stats.DERIVED_STAT.MAG_ATK, 5f);
        StatValue headMagATK = new StatValue(Stats.DERIVED_STAT.MAG_ATK, 2f);
        Limb hand = new Limb("Hands", handDarkDef);
        Limb head = new Limb("Head", headMagATK);

        cData.SetName("Lich");
        cData.SetBaseStats(baseDarkDef, baseMagATK);
        cData.SetAnatomy(hand, head);

        com = new Combatant(cData);

        float initialHandDarkDef = com.GetTotalStat(Stats.DERIVED_STAT.DARK_DEF, "Hands");
        float initialHandMagATK = com.GetTotalStat(Stats.DERIVED_STAT.MAG_ATK, "Hands");
        float initialHeadDarkDef = com.GetTotalStat(Stats.DERIVED_STAT.DARK_DEF, "Head");
        float initialHeadMagATK = com.GetTotalStat(Stats.DERIVED_STAT.MAG_ATK, "Head");

        // check if dark def on hands increased
        com.Equip("Hands", ring);
        float afterHandDarkDef = com.GetTotalStat(Stats.DERIVED_STAT.DARK_DEF, "Hands");
        Assert.Less(initialHandDarkDef, afterHandDarkDef);

        // check that dark def on head was not changed
        Assert.AreEqual(initialHeadDarkDef, com.GetTotalStat(Stats.DERIVED_STAT.DARK_DEF, "Head"));

        // check if mag atk on head increased
        com.Equip("Head", diodem);
        float afterHeadMagATK = com.GetTotalStat(Stats.DERIVED_STAT.MAG_ATK, "Head");
        Assert.Less(initialHeadMagATK, afterHeadMagATK);

        // check that mag atk on hands was not changed
        Assert.AreEqual(initialHandMagATK, com.GetTotalStat(Stats.DERIVED_STAT.MAG_ATK, "Hands"));        
    }

    [Test]
    public void BaseDefBuff() {
        Equipment helmet = ScriptableObject.CreateInstance<Equipment>();
        StatBuff baseWaterDefBuff = new StatBuff(StatBuff.DIRECTION.UP, StatBuff.MAGNITUDE.MEDIUM, Stats.DERIVED_STAT.WATER_DEF);
        helmet.AddBuffs(baseWaterDefBuff);
    }

    [Test]
    public void EquipArmorNoBuffs(){
        Equipment mask = ScriptableObject.CreateInstance<Equipment>();

        Limb face = new Limb("Face");
        
        cData.SetName("Ordinary guy");
        cData.SetAnatomy(face);

        com = new Combatant(cData);

        float initialDef = com.GetTotalStat(Stats.DERIVED_STAT.ICE_DEF, "Face");
        com.Equip("Face", mask);
        float afterDef = com.GetTotalStat(Stats.DERIVED_STAT.ICE_DEF, "Face");
        Assert.AreEqual(initialDef, afterDef);
    }
}
