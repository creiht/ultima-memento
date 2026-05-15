# Parrying

Parrying lets you raise your shield to absorb incoming melee and magic damage for a short duration.

## Overview

| Property | Value |
|---|---|
| **Primary Stat** | Dexterity |
| **Usage** | Active |
| **Skill Type** | Combat |
| **Skill Check** | 0.5 passive gain on use |

## Description

Parrying grants temporary melee and magic damage absorption when used with a shield equipped. The absorbed amount scales with your Parry skill and Dexterity. Parrying also passively improves your dodge chance and increases effective shield armor rating.

## How It Works

### Active Absorption Buff

Using Parry with a shield equipped grants temporary **melee and magic damage absorption**. The absorbed amount is based on your Parry skill and Dexterity.

**Base formula:**

```
Base Value = Parry Skill / 3
```

If your Parry skill is below 125 **or** your Dexterity is below 80, a penalty is applied:

```
Value = Base Value * (Dexterity / 80)
```

The final amount (minimum 1) is added to both your `MagicDamageAbsorb` and `MeleeDamageAbsorb` pools.

| Parry Skill | Dex 80+ Absorb | Dex 40 Absorb |
|---|---|---|
| 60 | 20 | 10 |
| 90 | 30 | 15 |
| 125 | 42 | 21 |

The absorption buff lasts **5 seconds**. After that, any remaining absorb points are removed and you "relax your stance" (`BaseWeapon.cs:1204`).

### Requirements

- You **must** have a shield equipped (`Layer.TwoHanded BaseShield`).
- Parrying is a revealing action (breaks hiding).
- Using the skill provides a passive skill gain check against 0.5 difficulty.

### Passive Dodge Check

When you are hit, `CheckParry()` at `BaseWeapon.cs:1204` performs a passive parry/dodge check:

- With shield equipped: dodge chance = `(Parry Skill - Bushido Non-Racial) / 400`. At 100+ Parry or 100+ Bushido, +5% bonus.
- Without shield: uses a separate formula based on Bushido interaction.
- Low Dexterity (<80) reduces chance by factor of `(20 + Dex) / 100` (`BaseWeapon.cs:1231`).
- [Evasion](../magic/bushido.md) spell modifies the parry chance via `GetParryScalar()`.

### Shield Armor Rating

Shield Armor Rating is scaled by your Parry skill (`BaseShield.cs:33`):

```
Effective AR = ((Parry * baseAR) / 200) + 1
```

Higher Parry = higher effective shield AR.

### Melee Damage Reflect

When you have active `MeleeDamageAbsorb` (from Parrying ability or other sources), melee attacks absorb up to half the absorbed amount, damaging the attacker instead (`BaseMeleeWeapon.cs:16`).

## How to Train

Use the skill with a shield equipped. The passive gain check uses a 50% success threshold, so gains are relatively steady. Combat scenarios where you actually take hits while the buff is active help maximize utility.

## What It Affects

### Combat & Defense
- `BaseWeapon.cs:1204` — `CheckParry()`: Passive dodge check when hit. With shield: dodge chance = `(Parry Skill - Bushido Non-Racial) / 400` (+5% bonus at 100+ Parry or 100+ Bushido). Low Dex (<80) applies `(20 + Dex) / 100` penalty.
- `BaseShield.cs:33` — Shield AR scaled: `((Parry * baseAR) / 200) + 1`.
- `BaseMeleeWeapon.cs:16` — Melee attacks with active `MeleeDamageAbsorb` reflect up to half the absorbed amount to the attacker.
- `BaseWeapon.cs:1231` — Dexterity penalty threshold (`DEXTERITY_PENALTY_THRESHOLD = 80`) applies to both active Parrying buff and passive `CheckParry()`.

### Magic Systems
- `SanctifySpell.cs:78` — Holy Man spell `Sanctify` grants `DefaultSkillMod` to Parry = `(Healing / 25) + (Spiritualism / 25)`, scaled by player level mods.

### Crafting & Alchemy
- `DefAlchemy.cs:341` — **Elixir of Parrying**: requires 60-120 Alchemy. Ingredients: Brimstone (x3), Bottle, Nox Crystal, Amber.
- `Elixirs.cs:3340` — `ElixirParry`: temporarily boosts Parry skill via `SkillMod`. Duration/strength from Cooking, Tasting, and Alchemy.

### Items & Equipment
- `HiddenTrap.cs:1075` — `IAmShielding()`: Shielded characters check Parry vs trap skill to shield from hidden traps.
- `HiddenTrap.cs:1083` — Players with shields use Parry to check if shielded from hidden traps.
- **Aegis Artifact Set**: `Artifact_HelmOfAegis.cs:23` (+5), `Artifact_GorgetOfAegis.cs:23` (+5), `Artifact_ArmsOfAegis.cs:23` (+5), `Artifact_GlovesOfAegis.cs:23` (+5), `Artifact_LegsOfAegis.cs:23` (+5), `Artifact_TunicOfAegis.cs:23` (+10), `Artifact_Aegis.cs:19` (+10 shield)
- `Artifact_AchillesShield.cs:16` — +25 Parry (highest single-item bonus)
- `Artifact_DupresShield.cs:25` — +10 Parry
- `GuildRing.cs:43` — Warriors Guild ring: +10 Parry
- `ResourceMods.cs:345-349` — Sigils on shields: if slot value is 99, applied as Parry bonus instead of Alchemy.
- `ManualOfItems.cs:653` — Manual of Items on shields: if skill value is 99, applied as Parry bonus.
- `PowerScroll.cs:14` — Parrying is one of 22 skills that can gain a power scroll (permanent stat cap increase + 10 skill points).

### Weapon Abilities
- `WeaponAbility.cs:71` — Parry is part of the total skill pool that reduces mana cost for weapon special moves (200-299 total = -5 mana, 300+ = -10 mana, combined with Swords, Bludgeoning, Fencing, Marksmanship, Lumberjacking, Stealth, Fist Fighting, Poisoning, Bushido, Ninjitsu).
- `AbilityBook.cs:59` — Same mana reduction mechanic documented in-game.
- `MeleeProtection.cs:22` — Sets `MeleeDamageAbsorb = 15` on hit.
- `MagicProtection.cs:22` — Sets `MagicDamageAbsorb = 6` on hit.
- `MeleeProtection2.cs:22` — Variant sets `MeleeDamageAbsorb = 30`.
- `MagicProtection2.cs:22` — Variant sets `MagicDamageAbsorb = 8`.

### NPCs
- `Behavior.cs:6239` — Parry listed in keyword table for tamed pets.
- `WarriorGuildmaster.cs:22` — 85-100 Parry
- `Garth.cs:31` — 61-93 Parry
- `Blacksmith.cs:25` — 61-93 Parry
- `IronWorker.cs:26` — 61-93 Parry
- `KungFu.cs:30` — 64-80 Parry
- `Fighter.cs:23` — 45-68 Parry
- `Adventurers.cs:97` — Scales with CitizenLevel (28 + CitizenLevel * 7)
- `HenchmanFighter.cs:73`, `HenchmanArcher.cs:72`, `HenchmanMonster.cs:57/94` — Henchmen have Parry skill

### Guild Benefits
- `SkillCheck.cs:255` — Warriors Guild members receive **faster skill gain** for Parrying.

### Character Creation
- `CharacterCreation.cs:918` — New characters start with **30 Parry** skill.

### Player Display
- `Players.cs:972` — Both `MagicDamageAbsorb` and `MeleeDamageAbsorb` values are displayed on the stat panel.

## Related Systems & Skills

### Synergies
- [Evasion](../magic/bushido.md): Bushido's Evasion spell checks `CheckParry()` — if both are active and parry check succeeds, the attacker completely misses.
- [Alchemy](../crafting/alchemy.md): Elixir of Parrying temporarily boosts Parry skill.
- [Weapon Abilities](weapon-abilities.md): Block and Defense Mastery set `MeleeDamageAbsorb` and `MagicDamageAbsorb` values.
- [Holy Man](../magic/holy-man.md): Sanctify spell grants a temporary Parry skill bonus.

### Prerequisites / Co-requisites
- [Shield](arms-lore.md): Parrying requires a shield equipped. Arms Lore helps with shield selection.
- [Dexterity](../systems/attributes.md): Primary stat for both active absorption and passive dodge chance.

## Notes
- Parrying breaks hiding — using it reveals your position.
- The 5-second absorption window means timing matters; use it just before taking heavy hits.
- Low Dexterity (<80) significantly reduces absorption values via the `(Dex / 80)` penalty.
- The Aegis Artifact Set provides up to +50 total Parry across all pieces (Tunic +50 for the full set).
