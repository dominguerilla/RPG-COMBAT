using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

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

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator DamageInflictTestWithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        yield return null;
    }
}
