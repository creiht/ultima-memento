# Discordance

Discordance lets you play jarring music to weaken a target, reducing their resistances, skills, combat speed, and damage output.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Intelligence |
| Usage | Active (targeted, requires instrument) |
| Cooldown | 3 seconds (on use) |
| Skill Check | Variable, based on target difficulty |
| Buff Icon | Discordance (1063662) |

## How It Works

1. Use the skill to select an instrument from your pack.
2. Target a creature or player (cannot target another player directly in some cases).
3. A Musicianship check is performed first. If that fails, you play poorly with no effect.
4. A Discordance skill check determines the outcome:
    - **Success:** Full effect applied for **10 seconds** per successful use (stacking duration).
    - **Failure:** Reduced "daze" effect applied for **4 seconds**.

### Effect Calculation

The debuff strength is based on your Discordance skill:

```
effect = -(Discordance skill / 5)
```

Against difficult creatures (bard difficulty 160+), the effect is **halved**.

### Effect Table

| Discordance | Resistance / Skill Reduction |
|---|---|
| 50.0 | ~10% all resistances, ~10% all skills |
| 75.0 | ~15% all resistances, ~15% all skills |
| 100.0 | ~20% all resistances, ~20% all skills |
| 120.0 | ~24% all resistances, ~24% all skills |

The effect reduces:
- All five resistances (Physical, Fire, Cold, Poison, Energy)
- All of the target's skills by a percentage scalar

**Discordance no longer reduces the target's stats** (Str/Dex/Int) — these lines were commented out in the source.

### Duration & Stacking

Repeated successful uses extend the duration by 10 seconds (or 4 seconds on failure). The effect ends if:
- The target dies or is deleted
- The bard dies or hides
- The bard moves out of range
- The duration expires

### Musicianship Bonus

Musicianship above 100 reduces the difficulty by `(Musicianship - 100) * 0.5`.

### Player Resistance

Players can resist discordance if their Magic Resist skill check succeeds against a random 0–125 roll.

### Buff Display

Discordance displays `BuffIcon.Discordance` (icon 1063662) on the affected target's paperdoll. The buff args are formatted as `"{effect}\t0\t0\t0\t{scalar}"`.

## How to Train

Target progressively harder creatures. The difficulty is based on the instrument's `GetDifficultyFor` method minus 10. You need at least `(difficulty - 25)` skill to attempt a target.

## What It Affects

### Combat & Weapons

Discordance applies three combat debuffs to an affected target simultaneously:

- `World/Source/Scripts/Items/Weapons/BaseWeapon.cs:992-996` — **Defense bonus**: When attacker is under Discordance, the attacker's defense bonus is reduced by `discordanceEffect` (up to ~28%). This makes the attacker harder to dodge.
- `World/Source/Scripts/Items/Weapons/BaseWeapon.cs:1056-1060` — **Swing speed**: Discordance reduces swing speed bonus by `discordanceEffect` (up to ~28%). At 100 Discordance this is a 28% swing speed penalty.
- `World/Source/Scripts/Items/Weapons/BaseWeapon.cs:2446-2450` — **Damage output**: Discordance reduces damage bonus by `discordanceEffect * 2` (up to ~48%). At 100 Discordance this is a 40% damage penalty.

### Magic Systems

- `World/Source/Scripts/Engines and Systems/Magic/Bard/SongSpells.cs:63` — Discordance is one of four skills summed in `MusicSkill()`: `Musicianship + Provocation + Discordance + Peacemaking`. This combined total powers all bard song effects (buff amounts, durations, and damage).
- `World/Source/Scripts/Engines and Systems/Magic/Knight/RemoveCurse.cs:71` — The Knight spell RemoveCurse removes the Discordance buff (`BuffIcon.Discordance`) from the target.

### Crafting & Harvest

- `World/Source/Scripts/Engines and Systems/Trades/Crafting/DefAlchemy.cs:273-276` — **Elixir of Discordance** is crafted via Alchemy at **60.0–120.0 skill**, using 3 Gargoyle Ears, 1 Empty Bottle, 1 Black Pearl, and 1 Amber. Adds a temporary flat Discordance skill boost.

### Items

| Item | Effect |
|---|---|
| `ElixirDiscordance` (`Elixirs.cs:1363-1441`) | Temporary Discordance skill boost via `DefaultSkillMod`. Duration and strength scale with Cooking + Tasting + Alchemy. |
| `ElixirMusicianship` (`Elixirs.cs:3236-3336`) | Boosts Musicianship and the other three bard skills (Discordance, Peacemaking, Provocation) proportionally. |
| `SongBook` (`SongBook.cs:60`) | Stores 16 bard songs; Discordance feeds into `MusicSkill()` for all song effects. |

### AI & NPCs

- `World/Source/Scripts/System/Misc/Talk.cs:128` — NPC Bard dialogue mentions Discordance as one of the four key bardic performance skills ("good at musicianship, provocation, discordance, and peacemaking").

### Quests & Achievements

- `World/Source/Scripts/Engines and Systems/Quests/Bards Tale/MangarsRewards.cs:124` — The **Bardic Feathered Cap** quest reward from the Bards Tale gives **+10 Discordance** (alongside +10 each of Musicianship, Provocation, and Peacemaking).
- `World/Source/Scripts/Engines and Systems/Quests/Codex/CodexWisdom.cs:77,401` — Codex Wisdom can teach Discordance (skill index 16) as one of ~27 available skills.

### Avatar / Leveling

- `World/Source/Scripts/Engines and Systems/Avatar/SkillArchive.cs:59-60` — Discordance is tracked in the Avatar system's `SkillArchive` property `Discordance` for leveling purposes.

## Related Skills

### Synergies

| Skill | Relationship |
|---|---|
| [Musicianship](musicianship.md) | Every Discordance use requires a successful Musicianship instrument check first. Musicianship above 100 reduces Discordance difficulty by 0.5 per point above 100. |
| [Peacemaking](peacemaking.md) | Shares the same Musicianship gate. Discordance is one of four skills summed in `MusicSkill()` for bard song effects. |
| [Provocation](provocation.md) | Shares the same instrument-check mechanism and difficulty scaling. All three bard combat skills feed into `MusicSkill()`. |

### Prerequisites

- Discordance requires an **instrument** in the backpack to use.
- A successful **Musicianship instrument check** is a prerequisite for every Discordance attempt.
- Minimum Discordance skill required = `(instrument difficulty for target - 25)`.
- Against difficult creatures (bard difficulty 160+), the Discordance effect is halved.
