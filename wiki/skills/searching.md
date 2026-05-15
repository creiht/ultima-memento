# Searching

Searching (Detect Hidden) lets you reveal hidden players, uncover traps, find secret doors, and discover hidden treasure chests.

## Overview

| Property | Value |
|---|---|
| **Primary Stat** | Intelligence |
| **Usage** | Active (targeted location) |
| **Skill Type** | Active |
| **Skill Check** | 0–125 |

## Description

Use the skill and target a location. Everything hidden within your detection range centered on that point is checked. Your Searching skill (+/- random 10) is compared against the target's Hiding skill (+/- random 10). If yours is higher, they are revealed. Party members are ignored.

Searching detects hidden traps, opens secret doors when found, and uncovers hidden treasure chests whose quality depends on your skill level. Even if a normal skill check fails, the Night Sight equipment attribute provides an additional chance to spot traps and hidden objects in the dark. Multiple items in range are checked, with the first `Searching Skill / 10` items getting a full skill check and the rest relying on passive detection only.

## How to Train

Use the skill in areas with hidden creatures, traps, or objects. Dungeons with traps are ideal. The skill check is 0-125, allowing gains at any level. Searching has anti-macro protection enabled, meaning skill gains require actual movement and legitimate use rather than rapid repeated clicks.

## How It Works

### Detection Range

```
Range = Searching Skill / 10
```

On a failed skill check, the range is halved. Inside a house where you are a Friend, the range is always 22 tiles.

| Searching Skill | Range (Success) | Range (Failure) |
|---|---|---|
| 50 | 5 tiles | 2 tiles |
| 100 | 10 tiles | 5 tiles |
| 125 | 12 tiles | 6 tiles |

### What You Can Find

#### Hidden Players

Your Searching skill (+/- random 10) is compared against the target's Hiding skill (+/- random 10). If yours is higher, they are revealed. Party members are ignored.

#### Traps

Detects various trap types within range:
- Fire Column Traps, Flame Spurt Traps
- Poison Gas Traps, Giant Spike Traps
- Saw Blade Traps, Spike Traps
- Stone Face Traps, Odd Mushrooms
- Hidden Floor Traps (also marks them as discovered)
- Killer Tiles ("It's a trap! Death awaits.")

#### Hidden Doors

Secret doors within range are automatically opened when detected.

#### Hidden Chests

Hidden treasure chests can be uncovered. The quality of discovered chests depends on:
- `Searching Skill / 20` (max 6 levels)
- Plus area difficulty bonus (max 4 levels)
- Total level capped at 1-10

### Passive Trap Detection

Walking over a hidden floor trap with 5+ Searching triggers a passive check (`CheckSkill 0-125`). If successful, the trap becomes visible with a warning message and disappears after 5 minutes.

### Night Sight Bonus

Even if a normal skill check fails, the Night Sight equipment attribute provides an additional chance to spot traps and hidden objects in the dark.

## What It Affects

### Hidden Chests
The quality of discovered treasure chests scales with Searching skill. Chest level = `floor(Searching / 20)` (max 6), plus up to 4 bonus levels from area difficulty, capped at 10 total. Higher levels yield more gold and better loot.
- `HiddenChest.cs:40` — `FoundBox()` uses level for loot generation.

### Passive Trap Detection
Walking over a hidden floor trap with 5+ Searching triggers a passive check. If successful, the trap becomes visible with a warning message and disappears after 5 minutes.
- `HiddenTrap.cs:1202` — `PassiveSearching()` requires `Skills.Searching.Value >= 5`.

### Anti-Macro Protection
Searching has anti-macro protection enabled, meaning skill gains require actual movement and legitimate use rather than rapid repeated clicks.
- `SkillCheck.cs:30` — `true` (anti-macro enabled).

### Items Affected by Searching
- **Detective Boots of the Royal Guard** — Provides +10 to +25 bonus to Searching as a skill bonus slot.
  - `Artifact_DetectiveBoots.cs:14`
- **Elixir of Detect Hidden** — Temporarily buffs Searching with a skill mod.
  - `Elixirs.cs:1312`
- **Runic Tools** — Searching is among the skills that can appear on runic tools.
  - `BaseRunicTool.cs:197`

### Creature AI Searching
When `S_CreaturesSearching` is enabled (default), NPCs in the Omni AI system can detect hidden player characters. The detection chance formula:

```
chance = Searching / 1.2 - min(Hiding / 2.9, Stealth / 1.8)
```

Minimum chance is `Searching / 10`. This runs periodically on AI-controlled creatures with 10+ Searching.
- `Settings.cs:429` — `S_CreaturesSearching = true` (default).
- `Behavior.cs:8797` — `Searching()` AI method.
- `Behavior.cs:8977` — Cooldown trigger for AI searching.

### Tracking Synergy
When tracking a hidden player, both Tracking and Searching are combined against the target's Hiding and Stealth:

```
divisor = Hiding + Stealth
```

Necromancy transformations modify this divisor (Horrific Beast reduces it by 200, Vampiric Embrace caps it at 500, Wraith Form adds 200).
- `Tracking.cs:345` — `from.Skills[SkillName.Searching].Fixed`.
- `Tracking.cs:341` — Comment: "Tracking players uses tracking and searching vs. hiding and stealth".

## Related Systems & Skills

### Synergies
- [Hiding](hiding.md) — Directly opposed: Searching checks compare Searching + random(-10,10) vs Hiding + random(-10,10). Also used in Tracking, Reveal, Mind's Eye, and Eagle Eye detection formulas.
- [Tracking](tracking.md) — Combined with Searching for tracking hidden players using the formula `50 * (2*Tracking + Searching) / (Hiding + Stealth)`.
- [Reveal](../magic/magery.md) — Magery spell that replicates Searching's detection: `50 * (Magery + Searching) / (Hiding + Stealth)`. Chest level from `Magery / 16` (max 6).
- [Mind's Eye](../magic/jedi.md) — Jedi spell that replicates Searching: `50 * (JediPower + Psychology) / (Hiding + Stealth)`. Chest level from `GetJediDamage() / 50` (max 6).
- [Eagle Eye](../magic/shinobi.md) — Shinobi spell: `50 * (Ninjitsu + Searching) / (Hiding + Stealth)`. Chest level from `Ninjitsu / 16` (max 6).
- [Gem of Seeing](../items/magical.md) — Artifact that detects hidden players using `Hiding + random(-10, 10)`. Always uses Night Sight.
- [Night Sight](../magic/magery.md) — The Night Sight equipment attribute (`AosAttribute.NightSight`) provides a 2% chance per point to detect hidden items even on failed skill checks. Spell/potion Night Sight adds a further 2%.

### Prerequisites / Co-requisites
- [Remove Trap](remove-trap.md) — Disarms traps after finding them; does not share the passive detection mechanic.
- [Stealth](stealth.md) — Combined with Hiding to resist Searching detection.
- [Snooping](snooping.md) — Similar rogue skill for container inspection.
- [Stealing](stealing.md) — Another rogue skill with comparable AI behavior patterns.

## Notes
- Searching has anti-macro protection: skill gains require actual movement and legitimate use.
- Inside a house where you are a Friend, detection range is always 22 tiles regardless of skill.
- On a failed skill check, the detection range is halved.
- Multiple items in range are checked, with the first `Searching Skill / 10` items getting a full skill check and the rest relying on passive detection only.
- Night Sight equipment attribute provides additional detection chance even on failed skill checks.
