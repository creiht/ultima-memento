# Knightship

Knightship is the combat-faith skill shared by holy Paladins and dark Death Knights. It is the casting and damage skill for both the [Knight (Chivalry)](../magic/knight.md) and [Death Knight](../magic/death-knight.md) magic systems — which branch you follow is determined by your **Karma**, not by the skill itself.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Strength |
| Usage | Active (cast Paladin or Death Knight abilities) |
| Type | Magic / Combat |
| Max Base | 100.0 (70.0 without power scrolls) |
| Power Scroll | Yes (skill index 13) |
| Character Title | Knight |

## What It Affects

### Magic Systems — Paladin (Chivalry) Spells

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

### Magic Systems — Death Knight Spells

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

Power values for Death Knight spells: `sqrt(|Karma| + 20000 + Knightship × 10) / divisor`

### Crafting & Items

- `World/Source/Scripts/Engines and Systems/Trades/Crafting/DefInscription.cs:470` — Inscription: **Knightship Book** requires 50.0–126.0 SK and 8×Leather
- `World/Source/Scripts/Items/Sharpening/WeightingStones/ConsecratedWeightingStone.cs:29` — Requires **80.0 Knightship** + 100.0 Blacksmithy
- `World/Source/Scripts/Items/Sharpening/SharpeningStones/ConsecratedSharpeningStone.cs:29` — Requires **80.0 Knightship** + 100.0 Blacksmithy
- `World/Source/Scripts/Items/Sharpening/BowStrings/ConsecratedBowString.cs:29` — Requires **80.0 Knightship** + 100.0 Bowcraft

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

Death Knight Warhorse is purchasable from the DeathKnightDemon (`World/Source/Scripts/Mobiles/Civilized/DeathKnightDemon.cs:67`) for 10,000 gold.

### Spell Gating & UI

- `World/Source/Scripts/System/Gumps/RunebookGump.cs:357` — Having any Knightship unlocks the **Sacred Journey** option in the runebook
- `World/Source/Scripts/System/Help/HelpGump.cs:378` — Having any Knightship unlocks Knightship help content
- `World/Source/Scripts/Engines and Systems/Magic/Base/Spell.cs:776` — If Knightship > 0, you need **70.0 Magery** to cast Magery spells (cross-school gating)

### NPC Behavior & Area Restrictions

- `World/Source/Scripts/Mobiles/Omni AI/OmniAI Core.cs:50` — NPC AI uses Chivalry abilities when **Knightship > 10.0**
- `World/Source/Scripts/Mobiles/Omni AI/OmniAI Magery.cs:203` — NPC mages avoid players with **Knightship > 35.0**
- `World/Source/Scripts/Mobiles/Base/Behavior.cs:1124` — Death Knights (Knightship ≥ 50 + Karma ≤ -5000) are barred from settlements except Umbra and Ravendark
- `World/Source/Scripts/System/Misc/Players.cs:570` — Players with **Knightship ≥ 50 + Karma ≤ -5000** are flagged as Death Knights (evil status)

### Combat & Weapon Abilities

- `World/Source/Scripts/System/Skills/Weapon Abilities/Extra/RidingAttack.cs:30-36` — Mounted attack damage = `10 + (10 × Knightship / 70) + 5`

### Avatar / Leveling

- `World/Source/Scripts/Engines and Systems/Avatar/SkillArchive.cs:107` — Knightship tracked in Avatar system

## Related Systems

- [Knight (Chivalry) magic system](../magic/knight.md) — Paladin abilities, Tithing Points
- [Death Knight magic system](../magic/death-knight.md) — dark counterpart, Soul Lantern fuel
- [Tactics](tactics.md) — damage amplifier for melee between casts
- [Parrying](parrying.md) — defensive complement for shielded combat
- [Karma](../getting-started/alignment.md) — alignment determines which spellbook you can use
- [Power Scrolls](../systems/power-scrolls.md) — increases max Knightship beyond 70.0
- [Runebook](../systems/runebook.md) — gates Sacred Journey behind Knightship
