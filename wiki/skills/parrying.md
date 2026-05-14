# Parrying

Parrying allows you to raise your shield to absorb incoming melee and magic damage for a short duration.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Dexterity |
| Usage | Active (requires shield) |
| Duration | 5 seconds |

## How It Works

Using Parry with a shield equipped grants you temporary **melee and magic damage absorption**. The absorbed amount is based on your Parry skill and Dexterity.

### Absorption Formula

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

### Duration

The absorption buff lasts **5 seconds**. After that, any remaining absorb points are removed and you "relax your stance."

### Requirements

- You **must** have a shield equipped (Layer.TwoHanded BaseShield).
- Parrying is a revealing action (breaks hiding).
- Using the skill provides a passive skill gain check against 0.5 difficulty.

## How to Train

Use the skill with a shield equipped. The passive gain check uses a 50% success threshold, so gains are relatively steady. Combat scenarios where you actually take hits while the buff is active help maximize utility.

## What It Affects

### Combat & Defense

- `BaseWeapon.cs:1204` - `CheckParry()`: Passive parry/dodge check when you are hit. Determines if you successfully dodge an incoming melee attack.
  - With shield equipped: dodge chance = `(Parry Skill - Bushido Non-Racial) / 400`. At 100+ Parry or 100+ Bushido, +5% bonus.
  - Without shield: uses a separate formula based on Bushido interaction.
  - Low Dexterity (<80) reduces chance by factor of `(20 + Dex) / 100`.
  - [Evasion](../magic/bushido.md) spell modifies the parry chance via `GetParryScalar()`.
- `BaseShield.cs:33` - Shield Armor Rating is scaled by your Parry skill: `((Parry * baseAR) / 200) + 1`. Higher Parry = higher effective shield AR.
- `BaseMeleeWeapon.cs:16` - When you have active `MeleeDamageAbsorb` (from Parrying ability or other sources), melee attacks absorb up to half the absorbed amount, damaging the attacker instead.
- `BaseWeapon.cs:1231` - Dexterity penalty threshold (`DEXTERITY_PENALTY_THRESHOLD = 80`) applies to both the active Parrying buff and passive `CheckParry()`.

### Magic Systems

- `SanctifySpell.cs:78` - Holy Man spell `Sanctify` grants a temporary `DefaultSkillMod` to Parry equal to `(Healing / 25) + (Spiritualism / 25)`, scaled by player level mods.

### Crafting & Alchemy

- `DefAlchemy.cs:341` - Alchemy recipe for **Elixir of Parrying**: requires 60-120 Alchemy skill. Ingredients: Brimstone (x3), Bottle, Nox Crystal, Amber.
- `Elixirs.cs:3340` - `ElixirParry` class: temporarily boosts Parry skill using a `SkillMod`. Duration and strength determined by Cooking, Tasting, and Alchemy skills.

### Items & Equipment

- `HiddenTrap.cs:1075` - `IAmShielding()`: If you have a shield equipped, Parry skill is checked against trap skill to determine if you can shield yourself from a hidden trap.
- **Aegis Artifact Set** grants Parry bonuses:
  - `Artifact_HelmOfAegis.cs:23` - +5 Parry
  - `Artifact_GorgetOfAegis.cs:23` - +5 Parry
  - `Artifact_ArmsOfAegis.cs:23` - +5 Parry
  - `Artifact_GlovesOfAegis.cs:23` - +5 Parry
  - `Artifact_LegsOfAegis.cs:23` - +5 Parry
  - `Artifact_TunicOfAegis.cs:23` - +10 Parry
  - `Artifact_Aegis.cs:19` - Shield: +10 Parry
- `Artifact_AchillesShield.cs:16` - +25 Parry (highest single-item Parry bonus)
- `Artifact_DupresShield.cs:25` - +10 Parry
- `GuildRing.cs:43` - Warriors Guild ring: +10 Parry
- `ResourceMods.cs:345-349` - Sigils on shields: if a sigil slot value is 99 and the item is a shield, the sigil value is applied as a Parry bonus instead of Alchemy.
- `ManualOfItems.cs:653` - Manual of Items on shields: if skill value is 99, applies it as Parry bonus.
- `PowerScroll.cs:14` - Parrying is one of 22 skills that can gain a power scroll (permanent stat cap increase + 10 skill points).

### Weapon Abilities

- `WeaponAbility.cs:71` - Parry skill is part of the total skill pool that reduces mana cost for weapon special moves. Combined with Swords, Bludgeoning, Fencing, Marksmanship, Lumberjacking, Stealth, Fist Fighting, Poisoning, Bushido, and Ninjitsu: 200-299 total = -5 mana, 300+ = -10 mana.
- `AbilityBook.cs:59` - Same mana reduction mechanic documented in the in-game Ability Book.
- `MeleeProtection.cs:22` - Weapon ability sets `MeleeDamageAbsorb = 15` on hit.
- `MagicProtection.cs:22` - Weapon ability sets `MagicDamageAbsorb = 6` on hit.
- `MeleeProtection2.cs:22` - Weapon ability variant sets `MeleeDamageAbsorb = 30`.
- `MagicProtection2.cs:22` - Weapon ability variant sets `MagicDamageAbsorb = 8`.

### Bushido Interaction

- `Evasion.cs:87` - Bushido's **Evasion** spell checks `CheckParry()` when a shielded character is attacked. If both Evasion is active AND parry check succeeds, the attacker completely misses.

### Hidden Traps

- `HiddenTrap.cs:1083` - Players with shields can use Parry skill to check if they are shielded from a hidden trap. Higher Parry = better chance to block.

### AI & NPCs

- `Behavior.cs:6239` - Parry is listed in the keyword table for tamed pets. NPCs with Parry skill may respond to it as an emote command.
- **NPC skill ranges**:
  - `WarriorGuildmaster.cs:22` - 85-100 Parry
  - `Garth.cs:31` - 61-93 Parry
  - `Blacksmith.cs:25` - 61-93 Parry
  - `IronWorker.cs:26` - 61-93 Parry
  - `KungFu.cs:30` - 64-80 Parry
  - `Fighter.cs:23` - 45-68 Parry
  - `Adventurers.cs:97` - Scales with CitizenLevel (28 + CitizenLevel * 7)
  - `HenchmanFighter.cs:73`, `HenchmanArcher.cs:72`, `HenchmanMonster.cs:57/94` - Henchmen have Parry skill

### Guild Benefits

- `SkillCheck.cs:255` - Warriors Guild members receive **faster skill gain** for Parrying (guild skill bonus).

### Character Creation

- `CharacterCreation.cs:918` - New characters start with **30 Parry** skill.

### Player Display

- `Players.cs:972` - Both `MagicDamageAbsorb` and `MeleeDamageAbsorb` values are displayed on the character stat panel.

## Related Skills

- [Hiding](hiding.md) - Note that Parrying reveals you.
- [Weapon Abilities](weapon-abilities.md) - Block and Defense Mastery are shield-related weapon abilities.
- [Bushido](../magic/bushido.md) - Evasion spell synergizes with Parry for complete attack avoidance.
- [Combat](../systems/combat.md) - Parry skill affects passive dodge chance and shield AR.
- [Alchemy](../crafting/alchemy.md) - Elixir of Parrying temporarily boosts Parry skill.
- [Arms Lore](arms-lore.md) - Used by shields to avoid durability hits via `AvoidDurabilityHit()`.
