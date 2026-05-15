# Anatomy

Anatomy allows you to evaluate the physical characteristics of another creature or player, revealing their strength, dexterity, and current stamina percentage.

## Overview

| Property | Value |
|---|---|
| **Primary Stat** | Intelligence |
| **Usage** | Active (targeted) |
| **Skill Type** | Evaluation |
| **Skill Check** | 0 - 125 |

## Description

Target a living creature to receive a descriptive message about their strength and dexterity ratings (e.g. "That looks very strong and extremely agile"). At 65.0+ skill, you also learn their current stamina percentage. Your reading has a margin of error that decreases as your skill improves, reaching zero at GM.

## How It Works

Use the Anatomy skill and target a living creature. On success, you receive a descriptive message about the target's **strength** and **dexterity**. At **65.0+ skill**, you also learn their current **stamina percentage**.

### Accuracy

Your reading is not exact. There is a margin of error that decreases as your skill improves:

| Anatomy Skill | Margin of Error |
|---|---|
| 0 | +/- 25 |
| 50 | +/- 13 |
| 100 | 0 |

The displayed stat values are the target's true stats plus a random offset within the margin.

## How to Train

Target creatures or other players with the skill. The difficulty check ranges from 0 to 125, so you can gain skill on any target. Higher-level creatures give better gains at higher skill levels.

## What It Affects

### Combat & Damage
- `BaseWeapon.cs:2389` — Anatomy adds **+0.5x skill value** to base weapon damage (AOS scaling), alongside strength and tactics bonuses.
- `BaseWeapon.cs:2380` — Every successful weapon swing passively checks Anatomy for training gain alongside Tactics.
- `Fists.cs:49-62` — Anatomy contributes to **defend skill value** in fist fighting: `(Anatomy + Psychology + 20) * 0.5`, capped at 120. If this exceeds Fist Fighting skill, it becomes your effective defend skill.
- `Fists.cs:71-87` — **Stun move** requires 80.0 Anatomy + 80.0 Fist Fighting. On success, freezes the target for 4 seconds.
- `BaseAxe.cs:163` / `BaseBashing.cs:49` / `BasePoleArm.cs:131` — At 50% chance (skill/400), two-handed axes and maces deal **1.5x damage** ("crushing blow") and polearms apply a 30-second **-50% Intelligence** concussion debuff on the defender.

### Weapon Abilities
- `Block.cs:35` — Block ability grants armor bonus = `10 * ((max(Tactics, Anatomy) - 50) / 70 + 5)`. Anatomy competes with Tactics for the higher value.
- `DefenseMastery.cs:34` — Defense Mastery physical resistance bonus = `30 * ((max(Tactics, Anatomy) - 50) / 70)`. Higher Anatomy means more resist but proportionally less damage.
- `FrenziedWhirlwind.cs:78` — AoE damage = `10 * ((max(Tactics, Anatomy) - 50) / 70 + 5)`, dealing 5-15 damage. Anatomy again competes with Tactics.
- `ForceArrow.cs:27` — Force Arrow has a chance to suppress the target's warmode: success if `Random < Anatomy/600` (i.e. 50% at 300, ~83% at 500). Also lowers defender's defense via HitLower.

### Healing & Reviving
- `BaseCreature.cs:9318-9319` — Healing formula: min heal = `Anatomy/10 + Healing/6 + 4`, max heal = `Anatomy/8 + Healing/3 + 4`. Anatomy directly scales healing output.
- `BaseCreature.cs:9292-9299` — Curing poison requires **both Healing >= 60 AND Anatomy >= 60**, then checks Healing skill at 60+poisonLevel*10.
- `Bandage.cs:156-214` — Reviving dead henchmen (Fighter, Wizard, Archer, Monster) requires **80 Anatomy + 80 Healing** and consumes a bandage.
- `HenchmanFunctions.cs:231-232` — Henchman auto-healing: min = `Anatomy/4 + Healing/4 + 6`, max = `Anatomy/4 + Healing/2 + 20`.

### Harvest & Loot
- `BaseCreature.cs:4474-4485` — Anatomy contributes **+skill/25 bonus** to harvestable resource amounts (hides, meat, scales, skins, cloth, feathers, wool, rocks, granite, metal, wood, skeletal remains) when Forensics is also checked. Works alongside Forensics at +2 per 50 skill.

### AI & NPCs
- `Behavior.cs:9769` — Smart AI NPCs with 80+ Fist Fighting and 80+ Anatomy will automatically attempt stun attacks on combatants.
- `Druidism.cs:489` — Druidism Animal Form displays Anatomy skill as one of the creature's combat ratings in the info panel.

## Related Systems & Skills

### Synergies
- [Psychology](psychology.md): Evaluates intelligence and mana instead of strength and dexterity. Both skills contribute to the same margin-of-error formula.
- [Healing](healing.md): Anatomy directly scales healing output and poison cure success.
- [Fist Fighting](fist-fighting.md): Anatomy enables the Stun move (80/80 combo) and boosts defend value in unarmed combat.
- [Forensics](forensics.md): Anatomy adds bonus harvestable resources alongside Forensics when skinning creatures.
- [Arms Lore](arms-lore.md): Arms Lore provides a similar +0.5x damage bonus but for different weapon types.

### Prerequisites / Co-requisites
- [Tactics](tactics.md): Anatomy and Tactics compete equally for damage scaling and weapon ability bonuses (whichever is higher is used).

## Notes
- You cannot evaluate yourself ("You know yourself quite well enough already").
- Invulnerable vendors cannot be inspected.
- Items cannot be targeted ("Only living things have anatomies!").
