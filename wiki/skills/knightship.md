# Knightship

Knightship is the combat-faith skill shared by holy Paladins and dark Death Knights, serving as the casting and damage skill for both the [Knight (Chivalry)](../magic/knight.md) and [Death Knight](../magic/death-knight.md) magic systems.

## Overview

| Property | Value |
|---|---|
| **Primary Stat** | Strength |
| **Usage** | Active |
| **Skill Type** | Magic / Combat |
| **Skill Check** | 70.0 (100.0 with power scrolls) |

## Description

Knightship determines the success chance and potency of Paladin (Chivalry) and Death Knight spell abilities. Which spellbook you can access is determined by your **Karma** (positive = Paladin, negative = Death Knight), not by the skill itself. The skill also governs melee mounted attack damage, crafting item requirements, and NPC behavior patterns.

## How It Works

### Spell Casting

Knightship provides the success chance calculation for all spells in both the Chivalry and Death Knight spellbooks. Death Knight abilities additionally require trapped souls from a Soul Lantern.

Power values for Death Knight spells use the formula: `sqrt(|Karma| + 20000 + Knightship × 10) / divisor`.

- If Knightship > 0, you need **70.0 Magery** to cast Magery spells (cross-school gating) — [`Spell.cs:776`]

### Karma-Based Branching

Your Karma value determines whether you access the Paladin or Death Knight spellbook. This branching is enforced at the system level, not at the skill level.

## How to Train

Activate Knightship spells from your applicable spellbook (Chivalry or Death Knight). Skill gains occur on successful spell casts.

## What It Affects

### Paladin (Chivalry) Spells

All Chivalry abilities use Knightship for success chance and scale with Karma:

| Spell | Min Skill | Tithing | Effect |
|-------|-----------|---------|--------|
| Cleanse By Fire | 5.0 | 10 | Cure poison; success chance = `10000 + (Knightship × 75) - ((poisonLevel+1) × 2000)` |
| Remove Curse | 5.0 | 10 | Removes debuffs from targets and cursed items (BookBoxes, CurseItems) |
| Sacred Journey | 15.0 | 10 | Teleport to marked rune; also gated in [Runebook](../systems/runebook.md) UI |
| Consecrate Weapon | 15.0 | 10 | Weapon deals damage in target's weakest resistance; duration = **Knightship seconds** |
| Divine Fury | 25.0 | 10 | Increased attack speed and damage |
| Enemy of One | 45.0 | 10 | Greatly increased damage against one creature type |
| Holy Light | 55.0 | 10 | Energy AoE damage to nearby enemies |
| Noble Sacrifice | 65.0 | 30 | Heals, cures, and resurrects allies at personal cost |

### Death Knight Spells

Death Knight abilities consume trapped souls from a Soul Lantern in addition to mana and stamina:

| Spell | Min Skill | Tithing (Souls) | Mana | Effect |
|-------|-----------|-----------------|------|--------|
| Hag Hand | 5.0 | 7 | 8 | Remove curses from targets and items |
| Demonic Touch | 15.0 | 21 | 16 | Heal target using `|Karma|/2` power |
| Strength of Steel | 20.0 | 14 | 8 | Increase target's Strength temporarily |
| Lucifer's Bolt | 25.0 | 35 | 24 | Paralyze target for `7 + (karmaPower × 0.2)` seconds |
| Grim Reaper | 30.0 | 42 | 28 | Mark target; increased damage to it, extra damage taken from others |
| Succubus Skin | 35.0 | 14 | — | Regenerate health over time |
| Banish | 40.0 | 56 | 36 | Dispel summoned creatures; success scales with Knightship vs. dispel difficulty |
| Soul Reaper | 45.0 | — | — | Drain enemy mana |
| Hellfire | 70.0 | 84 | 52 | Damage + burn effect (5–10 per tick, ×2 vs NPCs) |
| Shield of Hate | 60.0 | — | — | Physical damage barrier |
| Orb of Orcus | 80.0 | 200 | 56 | Reflect magic damage = `karmaPower / 4` |
| Devil Pact | 90.0 | 98 | 60 | Summon a Devil; duration = `90 + (Knightship / 2)` seconds |

### Crafting & Items

- [`DefInscription.cs:470`] — Inscription: **Knightship Book** requires 50.0–126.0 SK and 8×Leather
- [`ConsecratedWeightingStone.cs:29`] — Requires **80.0 Knightship** + 100.0 Blacksmithy
- [`ConsecratedSharpeningStone.cs:29`] — Requires **80.0 Knightship** + 100.0 Blacksmithy
- [`ConsecratedBowString.cs:29`] — Requires **80.0 Knightship** + 100.0 Bowcraft

### Artifacts & Equipment (Skill Bonuses)

| Item | Bonus |
|------|-------|
| [Excalibur](../items/artifacts.md#excalibur) | +20% Knightship |
| [Samaritan Robe](../items/artifacts.md#samaritan-robe) | +20% Knightship |
| [Luna Lance](../items/artifacts.md#luna-lance) | +10% Knightship |
| Holy Knight's Breastplate | +5% Knightship |
| Holy Knight's Gorget | +5% Knightship |
| Holy Knight's Arms | +5% Knightship |
| Holy Knight's Helm | +5% Knightship |
| Holy Knight's Leggings | +5% Knightship |
| Holy Knight's Gloves | +5% Knightship |

### Mounts

| Mount | Requirement |
|-------|-------------|
| Paladin Warhorse | **100.0 Knightship** + Karma ≥ 0 |
| Death Knight Warhorse | **100.0 Knightship** + Karma ≤ 0 |

Death Knight Warhorse is purchasable from the DeathKnightDemon (`DeathKnightDemon.cs:67`) for 10,000 gold.

### NPC Behavior & Area Restrictions

- [`OmniAI Core.cs:50`] — NPC AI uses Chivalry abilities when **Knightship > 10.0**
- [`OmniAI Magery.cs:203`] — NPC mages avoid players with **Knightship > 35.0**
- [`Behavior.cs:1124`] — Death Knights (Knightship ≥ 50 + Karma ≤ -5000) are barred from settlements except Umbra and Ravendark
- [`Players.cs:570`] — Players with **Knightship ≥ 50 + Karma ≤ -5000** are flagged as Death Knights (evil status)

### Combat & Weapon Abilities

- [`RidingAttack.cs:30-36`] — Mounted attack damage = `10 + (10 × Knightship / 70) + 5`

### Spell Gating & UI

- [`RunebookGump.cs:357`] — Having any Knightship unlocks the **Sacred Journey** option in the runebook
- [`HelpGump.cs:378`] — Having any Knightship unlocks Knightship help content

### Avatar / Leveling

- [`SkillArchive.cs:107`] — Knightship tracked in Avatar system

## Related Systems & Skills

### Synergies
- [Knight (Chivalry) magic system](../magic/knight.md): Paladin abilities, Tithing Points
- [Death Knight magic system](../magic/death-knight.md): dark counterpart, Soul Lantern fuel
- [Tactics](tactics.md): damage amplifier for melee between casts
- [Parrying](parrying.md): defensive complement for shielded combat
- [Power Scrolls](../systems/power-scrolls.md): increases max Knightship beyond 70.0

### Prerequisites / Co-requisites
- [Karma](../getting-started/alignment.md): alignment determines which spellbook (Paladin or Death Knight) you can use
- [Runebook](../systems/runebook.md): gates Sacred Journey behind Knightship

## Notes

- Knightship max base is 100.0 (70.0 without power scrolls, skill index 13).
- Character title "Knight" is granted by this skill.
- Negative Karma is required to access Death Knight spells; positive Karma for Paladin spells.
