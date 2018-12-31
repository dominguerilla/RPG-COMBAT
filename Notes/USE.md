# Combatant RPG Battle System
--intro here--
All participants in the Combatant RPG Battle System are referred to as 'fighters'.
The implementer of the system is referred to as the 'designer'.

## Installation

## Stats
All fighters in the battle system have stats that the designer specifies. However, the fighter has two values for each stat: intrinsic and extrinsic. *Intrinsic* stat values are the base values that a fighter has. *Extrinsic* stat values are calculated from its intrinsic values, equipment bonuses, and any buffs/debuffs that the fighter is affected by.


## CombatantData 
The CombatantData (CD) ScriptableObject gives details on a fighter, and all fighters should have a CD asset of their own. Each CD contains:
* The 3D model gameobject prefab
* Intrinsic stats
* The list of Limbs

### Should this class be inherited?
Not necessary. Suppose there was a Green Slime CD that the designer made, and he wants to create a new Red Slime that was identical to the green, except it had higher attack. It would be enough to duplicate the Green Slime CD and change the intrinsic attack value, as well as its 3D model prefab.

## Combatants
Given a CombatantData instance, the Combatant class represents a combatant's status during battle. The status includes:
* Extrinsic stat values
* Any buffs/debuffs
* Currently equipped items
If the CD represents the 'base status' of the fighter, the Combatant represents its 'current status'.

### Should this class be inherited?
Not necessary. (For now.)

## StatCalculator
The StatCalculator is an abstract class that the designer must implement. Given a Combatant and a desired stat, StatCalculators should return the extrinsic value of the desired stat based on the Combatant's intrinsic stats, current equipment, and current buffs/debuffs.

For instance, a CD for a Goblin monster may have an innate value for HP, but its actual 'extrinsic' HP is higher because of a Fortify buff that was cast by his ally, as well as a bonus from the leather chestplate it is wearing. 

### Should this class be inherited?
Yes. It is up to the designer to implement the stat calculation formulae.
