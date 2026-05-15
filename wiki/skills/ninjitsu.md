# Ninjitsu

Ninjitsu is the shadow-art skill covering stealth strikes, shapeshifting, and misdirection through the Ninjitsu ability set cast from a Book of Ninjitsu.

## Overview

| Property | Value |
|---|---|
| **Primary Stat** | Dexterity |
| **Usage** | Active |
| **Skill Type** | Combat / Magic |
| **Skill Check** | 2x gain rate (weighted) |

## Description

Ninjitsu governs a set of shadow-based abilities including Focus Attack, Death Strike, Animal Form transformations, and various stealth strikes. The skill also provides a passive melee damage bonus and interacts with the related [Shinobi](../magic/shinobi.md) magic system, which requires Ninjitsu as its casting skill.

## How It Works

### Ability Mechanics

Ninjitsu abilities do **not** reveal the caster when cast (`RevealOnCast = false`), are **not** interrupted by animal form (`BlockedByAnimalForm = false`), and are **not** affected by Faster Casting items.

### Melee Damage Bonus

Ninjitsu provides a passive melee damage bonus identical to Bushido, Tactics, and Necromancy: `GetBonus(Skills.Ninjitsu.Value, 0.625, 100.0, 6.25)` — applied to all melee attacks.

### Mirror Image Diversion

When attacking a target with Mirror Image clones, the chance to be diverted to a clone is `defender.Skills.Ninjitsu.Value / 150.0` (75% at 112.5 Ninjitsu, 100% at 150) — `BaseWeapon.cs:1413`.

### Regen Rates

In Dog or Cat Animal Form, Hits regeneration bonus = `Skills.Ninjitsu.Fixed / 30` — `RegenRates.cs:76`.

### Death Strike Trigger

Every movement tick calls `DeathStrike.AddStep()` on both NPCs and players. Death Strike triggers after 3 movement steps or after 5 seconds, whichever comes first — `WeightOverloading.cs:67,105`.

## Ability List

| Ability | Mana | Min Skill | Requires Stealth | Notes |
|---------|------|-----------|-------------------|-------|
| Animal Form | 0 | 10.0 | No | Transform into an animal; opens gump with 16 forms |
| Mirror Image | 10 | 40.0 | No | Creates a clone that follows you; duration = `30 + Ninjitsu.Fixed / 40` seconds |
| Backstab | 30 | 20.0 | **Yes** | Ignores armor if attacker is behind target; also applies Paralyzing Blow |
| Surprise Attack | 20 | 30.0 | **Yes** | Applies a malus to defender's defense for 30 seconds: `ninjitsu/60 + Tracking.GetStalkingBonus` |
| Shadow Jump | 15 | 50.0 | **Yes** | Teleport to target location while remaining hidden |
| Ki Attack | 25 | 80.0 | No (explicitly disabled) | Melee only; damage bonus based on distance traveled (max 20 tiles in 2 seconds) |
| Focus Attack | 20 | 60.0 | No | Damage scalar = `1.0 + (ninjitsu² / 43636)`; property bonus = `1.0 + (bonus * 3 + 0.01)` |
| Death Strike | 30 | 85.0 | No | Delayed lethal strike; chance = `30 + (ninjitsu - 85) * 2.2` (below 100) or `63 + (ninjitsu - 100) * 1.1` (above 100); applies Mortal Strike + paralysis |

## Animal Form Transforms

| Form | Min Skill | Bonus |
|------|-----------|-------|
| Rat | 0.0 | +20 Stealth |
| Rabbit | 20.0 | +20 Stealth |
| Cat | 40.0 | None |
| Dog | 40.0 | None |
| Ferret | 40.0 | +10 Stealing |
| Giant Serpent | 50.0 | None |
| Bull Frog | 50.0 | None |
| Llama | 70.0 | Speed boost |
| Forest Ostard | 70.0 | Speed boost |
| Grey Wolf | 82.5 | Speed boost |
| Mystical Fox | 82.5 | Speed boost |
| Reptalon | 90.0 | Speed boost + breath attack (20 damage) |
| Unicorn | 100.0 | Speed boost |
| Kirin | 100.0 | Speed boost + improved Hits regen |

> **Note:** Animal Form requires a [Form Talisman](../items/form-talisman.md) to access higher-tier creatures. The base spell comes with Rat, Rabbit, Cat, Dog, Giant Serpent, and Bull Frog unlocked.

## How to Train

- Activate Ninjitsu abilities from a Book of Ninjitsu; each use rolls a skill gain check via `CheckSkill(MoveSkill, RequiredSkill - 12.5, RequiredSkill + 37.5)`.
- Gain checks are weighted: Ninjitsu has a `true` (2x) gain rate — `SkillCheck.cs:69`.
- Animal Form has no mana cost and is an easy low-skill ability to train early.
- Train alongside [Hiding](hiding.md) and [Stealth](stealth.md) — several abilities (Backstab, Surprise Attack, Shadow Jump) require being hidden.
- Backstab and Ki Attack provide strong training opportunities at mid-skill levels.

## How to Obtain the Spellbook

- At character creation, selecting Ninjitsu as a primary skill grants a Book of Ninjitsu.
- Can be purchased from Monks (`Talk.cs:71` — the Monk NPC sells exotic items including Ninjitsu tomes).
- Listed in `ItemSales.cs:2075` at price 140 gold, sold by Market.Monk.

## What It Affects

### Cross-Skill & Ability Mechanics

- `BaseWeapon.cs:2394` — Ninjitsu provides a damage bonus identical to Bushido, Tactics, and Necromancy: `GetBonus(Skills.Ninjitsu.Value, 0.625, 100.0, 6.25)`. This applies to all melee attacks.
- `BaseWeapon.cs:1413` — When attacking a target with Mirror Image clones, the chance to be diverted to a clone is `defender.Skills.Ninjitsu.Value / 150.0` (75% at 112.5 Ninjitsu, 100% at 150).
- `Feint.cs:41` — Feint uses `Math.Max(Ninjitsu.Value, Bushido.Value)` to calculate its damage reduction bonus: `20 + 3.0 * (skill - 50.0) / 7.0`.
- `RegenRates.cs:76` — In Dog or Cat Animal Form, Hits regeneration bonus = `Skills.Ninjitsu.Fixed / 30`.
- `WeightOverloading.cs:67,105` — Every movement tick calls `DeathStrike.AddStep()` on both NPCs and players. Death Strike triggers after 3 movement steps or after 5 seconds, whichever comes first.

### Items & Spellbook

- `BookOfNinjitsu.cs` — The spellbook for Ninjitsu abilities; equips to the Trinket layer.
- `ShinobiScroll.cs` — Shinobi scroll that stores learned Shinobi abilities; requires Ninjitsu skill to cast.
- `ShinobiGarb.cs` — Shinobi-specific leather armor.
- `GiftShinobiGarb.cs` / `LevelShinobiGarb.cs` — Gift/level variants of Shinobi armor.
- `ResourceMods.cs:440` — Book of Ninjitsu can roll skill bonuses for Ninjitsu, Stealth, Tracking, and other skills.
- `BaseRunicTool.cs:220,327` — Runic tools can apply Ninjitsu-related enchantments.
- `Spellbook.cs:102,711,764,1016` — Spellbook system checks for BookOfNinjitsu type; requires 30 Ninjitsu to equip.

### NPC Behavior

- `OmniAI Ninjitsu.cs:63-65` — NPCs with `Skills.Ninjitsu.Base > 10.0` can use Ninjitsu abilities in combat.
- `OmniAI Ninjitsu.cs:87-92` — Hidden NPC ninja strikes: Ki Attack (>= 80), Surprise Attack (>= 30), Backstab (>= 20).
- `OmniAI Ninjitsu.cs:102-105` — Normal NPC ninja strikes: Death Strike (>= 85), Focus Attack (>= 60).
- `OmniAI Ninjitsu.cs:120-129` — NPC shuriken throws apply escalating poison by skill: Lesser (50+), Regular (70+), Greater (100+), Deadly (101+), Lethal (120+).

### Quests & Achievements

- `Titles.cs:250` — Ninjitsu has its own separate fame/karma title table (type 2, same as Bushido).
- `CharacterCreation.cs:938` — Ninjitsu is available as a starter skill with 30 initial skill points and a Book of Ninjitsu.
- `ChangeLog.cs:76,196` — Historical: tracking bonus for Ninjitsu builds 2x fast; Ninjitsu is 50% more likely to gain.
- `SkillArchive.cs:155-156` — Ninjitsu is tracked as `SkillArchive.Ninjitsu` property in the Avatar system.

### Other Magic Systems

- `AOS.cs:950` — Animal Form context is removed if `Skills.Ninjitsu.Value < entry.ReqSkill` (e.g., unequipping a talisman).
- `AOS.cs:974` — Deception (Shinobi) is removed if `Skills.Ninjitsu.Value < 30.0`.
- `MirrorImage.cs:167` — Clone duration: `30 + caster.Skills.Ninjitsu.Fixed / 40` seconds (range 30–37.5s).
- `Projection.cs:11`, `Mirage.cs:11`, `SpellHelper.cs:13`, `Spell.cs:9`, `SpecialMove.cs:7` — Various other magic systems import `Server.Spells.Ninjitsu` namespace.
- `DeadRegion.cs:12`, `World.cs:18`, `BargeDeadRegion.cs:12` — Region systems import Ninjitsu namespace.

## Related Systems & Skills

### Synergies
- [Hiding](hiding.md): Required for Backstab, Surprise Attack, and Shadow Jump. Death Strike damage is also boosted by combined Hiding + Stealth value (`scalar = (Hiding + Stealth) / 220`, max 1.0).
- [Stealth](stealth.md): Required to enter hidden state for several abilities. Combined with Hiding for Death Strike scalar.
- [Tracking](tracking.md): `Tracking.GetStalkingBonus()` adds to Backstab damage, Surprise Attack malus, and Death Strike damage.
- [Bushido](bushido.md): Feint weapon ability uses the better of Ninjitsu or Bushido. Damage bonus formulas are identical.
- [Shinobi](../magic/shinobi.md): All Shinobi spells use Ninjitsu as their `CastSkill` and `DamageSkill`. Deception requires at least 30 Ninjitsu.
- [Tactics](tactics.md): Works alongside Ninjitsu damage bonus for total melee damage output.
- [Anatomy](anatomy.md): Adds to total melee damage alongside Ninjitsu.

### Conflicts
- Animal Form conflicts with [Polymorph](../magic/polymorph.md) spells (cannot be polymorphed and use Animal Form simultaneously).
- Animal Form conflicts with [Deception](../magic/shinobi.md) (cannot disguise while in Animal Form).
- Mirror Image does not count toward follower cap (checked via `Followers + 1 > FollowersMax`).
- Ki Attack cannot be used while hidden (explicitly blocked).
- Ki Attack cannot be used with ranged weapons (ML restriction).

## Notes

- Ninjitsu has a 2x skill gain rate (`SkillCheck.cs:69`), making it faster to train than most skills.
- Ninjitsu is available as a starter skill with 30 initial skill points at character creation.
- The skill is listed as expansion-required (Samurai Empire / SE) but functions fully in the current server configuration.
