using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using LIMB;

public class DamageInflictTest {

    CombatantData combData;
    Combatant comb;
    Damage dmg;
    List<StatValue> stats;
    List<Limb> anatomy;

    [SetUp]
    public void setUp() {
        this.stats = new List<StatValue>();
        this.anatomy = new List<Limb>();
    }

    [Test]
    public void DamageInflict1FlatDamage() {
        StatValue def = new StatValue(Stats.STAT.PHYS_DEF, 3.0f);
        StatValue health = new StatValue(Stats.STAT.HP, 5.0f);
        stats.Add(def);
        stats.Add(health);
        Limb core = new Limb("Core");
        Limb body = new Limb("Body");
        anatomy.Add(core);
        anatomy.Add(body);

        combData = new CombatantData("Slime", stats, anatomy);
        comb = new Combatant(combData);
        dmg = new Damage(Damage.TIMING.INSTANT, Damage.TYPE.BLUNT, Damage.MAGNITUDE.FLAT, 1.0f );
        float originalHealth = comb.GetCurrentHealth();

        comb.InflictDamage(dmg);

        // Use the Assert class to test conditions.
        Assert.Less(comb.GetCurrentHealth(), originalHealth);
    }

    [Test]
    public void DifferentLimbResistanceDamage(){
        // create Core stats
        List<StatValue> coreStats = new List<StatValue>();
        StatValue coreDef = new StatValue(Stats.STAT.PHYS_DEF, 1.0f);
        coreStats.Add(coreDef);
        Limb core = new Limb("Core", coreStats);
        List<StatValue> bodyStats = new List<StatValue>();
        anatomy.Add(core);

        // create Body stats
        StatValue bodyDef = new StatValue(Stats.STAT.PHYS_DEF, 3.0f);
        bodyStats.Add(bodyDef);
        Limb body = new Limb("Body", bodyStats);
        anatomy.Add(body);

        // create Base stats
        StatValue baseDef = new StatValue(Stats.STAT.PHYS_DEF, 3.0f);
        StatValue health = new StatValue(Stats.STAT.HP, 100.0f);
        stats.Add(health);
        stats.Add(baseDef);

        combData = ScriptableObject.CreateInstance<CombatantData>();
        combData.InitializeData("Slime", stats, anatomy);
        comb = new Combatant(combData);
        dmg = new Damage(Damage.TIMING.INSTANT, Damage.TYPE.BLUNT, Damage.MAGNITUDE.FLAT, 10.0f);

        float coreDamage = comb.InflictDamage(dmg, "Core");
        float bodyDamage = comb.InflictDamage(dmg, "Body");
        float baseDamage = comb.InflictDamage(dmg);

        Assert.Less(bodyDamage, baseDamage);
        Assert.Less(baseDamage, coreDamage);

    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator DamageInflictTestWithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        yield return null;
    }
}
