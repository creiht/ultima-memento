# Provocation

Provocation lets you use music to incite one creature to attack another, or to pull a creature's aggression onto yourself.

## Overview

| Property | Value |
|---|---|
| **Primary Stat** | Intelligence |
| **Usage** | Active (two-target, requires instrument) |
| **Skill Type** | Bard combat |
| **Skill Check** | Variable, based on target difficulty |

## Description

Provocation causes a target creature to attack a second target (another creature or yourself). A successful Musicianship instrument check must pass before the Provocation check is attempted. Provocation has a 95% gain chance, the second-highest among all skills.

## How It Works

### Process

1. Use the skill to select an instrument.
2. Target the **first creature** — the one you want to anger.
3. Target the **second creature** (or yourself) — the attack target.

On success, the first creature is provoked to attack the second creature. Both creatures must be within bard range of each other.

### Difficulty

The difficulty is the **higher** of the two creatures' bard difficulties, minus 10. Musicianship above 100 reduces difficulty by `(Musicianship - 100) * 0.5`.

You need at least `(difficulty - 25)` Provocation skill to attempt the combination.

### Provoking Onto Yourself

You can target yourself as the second target. This causes the creature to attack you directly — useful for pulling aggro in group play.

### Restrictions

- Cannot provoke controlled (tamed) creatures.
- Cannot provoke Unprovokable or BardImmune creatures.
- Paragon creatures with bard difficulty 160+ cannot be provoked.
- Cannot tell a creature to attack itself.
- The two creatures must be on the same map and within range.
- A Musicianship check must pass before the Provocation check.
- Instrument uses are consumed on each attempt.

## How to Train

Provoke creatures against each other, starting with weaker ones and working up. The difficulty scales with the hardest creature involved. Success grants a 6-second cooldown; failure only 3 seconds.

## What It Affects

### Magic Systems

- `Engines and Systems/Magic/Bard/SongSpells.cs:63` — `MusicSkill()` sums Musicianship + Provocation + Discordance + Peacemaking to determine total bard magic power for song spells.

### NPC AI

- `Mobiles/Omni AI/OmniAI Bard.cs:42` — Bard-type NPCs randomly choose between Discord, Provocation, and Peacemaking as one of three bard powers.
- `Mobiles/Omni AI/OmniAI Bard.cs:146` — NPC bard `UseProvocation()` tries to provoke a creature to attack its master, or other creatures in the area.
- `Mobiles/Base/Behavior.cs:6259` — Listed in AI skill-use priority lists for general skill activation.

### Merchants

- `Mobiles/Civilized/Merchants/Bard.cs:31` — Standard Bard vendors carry Provocation 60.0–83.0.
- `Mobiles/Civilized/Guilds/BardGuildmaster.cs:25` — Bard Guildmaster has Provocation 80.0–100.0.

### Items

- `Elixirs.cs:3652` — **Elixir of Provocation** provides a temporary +skill mod (duration based on Cooking, Tasting, and Alchemy).
- `Items/Trades/Alchemy/PotionKeg.cs:407` — PotionKeg can produce Elixir of Provocation.
- `Items/Trinkets/GuildRing.cs:71` — **Bard's Guild Ring** grants +10 Provocation.
- `Items/Trades/Misc/FireHorn.cs:110` — **Fire Horn** uses Provocation (along with Musicianship, Discordance, Peacemaking) in its damage calculation formula.
- `Items/Magical/Artifacts/Instruments/Artifact_HornOfKingTriton.cs:28` — **Horn of King Triton** grants +10 Provocation.
- `Items/Magical/Artifacts/Instruments/Artifact_GwennosHarp.cs:29` — **Gwenna's Harp** grants +10 Provocation.
- `Engines and Systems/Quests/Bards Tale/MangarsRewards.cs:123` — **Bardic Feathered Cap** (Bard's Tale quest reward) grants +10 Provocation.
- `Items/Trades/Magical/Tools/BaseRunicTool.cs:224` — Runic tools can be affixed with Provocation bonus (focus==2).
- `System/Misc/ResourceMods.cs:537` — Runic tool crafting can add Provocation via focus value 2.

### Crafting

- `Engines and Systems/Trades/Crafting/DefAlchemy.cs:353` — **Elixir of Provocation** is craftable by Alchemists with Alchemy 60.0–120.0 using Eye of Toad.
- `System/Misc/ItemSales.cs:3995` — Elixir of Provocation sells to vendors for 70–95 gold.

### Luck & Combat

- `System/Misc/MobileUtilities.cs:14` — When a provoked creature is killed, its **BardMaster** (the player who provoked) is considered for luck distribution, potentially receiving full or half luck bonus depending on circumstances.
- `System/Misc/MobileUtilities.cs:65` — `TryGetKillingPlayer()` checks `BardProvoked` flag to trace the killing blow back to the provoking player.

### Gain Chance

- `System/Skills/SkillCheck.cs:38` — Provocation has a **95% gain chance** on use (second-highest among all skills).

### Changelogs

- `System/Misc/ChangeLog.cs:80` — Players can now target themselves for the second target in provocation.
- `System/Misc/ChangeLog.cs:89` — Provocation now indicates if your skill is too low to succeed.
- `System/Misc/ChangeLog.cs:184` — Provocation now uses the higher difficulty between the two targets.
- `System/Misc/ChangeLog.cs:185` — Success cooldown reduced from 10s to 6s.
- `System/Misc/ChangeLog.cs:279` — Provocation is now 1.5x more likely to gain.
- `System/Misc/ChangeLog.cs:280` — Failure cooldown reduced from 5s to 3s.

## Related Systems & Skills

### Synergies

- `[Discordance](discordance.md)`: Weakens a single target. Shares the same instrument-check mechanism and difficulty scaling.
- `[Peacemaking](peacemaking.md)`: Calms creatures instead of enraging them. Shares the same Musicianship gate.
- `[Musicianship](musicianship.md)`: Prerequisite check must pass before Provocation takes effect; also contributes to bard song spell power via `MusicSkill()`.

### Prerequisites / Co-requisites

- Provocation requires an **instrument** in the backpack to use.
- A successful **Musicianship instrument check** is a prerequisite for every Provocation attempt.
- Minimum Provocation skill required = `(instrument difficulty for target - 25)`.
- The two targets must be on the same map and within bard range of each other.

## Notes

- Provocation has a **95% gain chance**, the second-highest among all skills (`SkillCheck.cs:38`).
- Success gives a 6-second cooldown; failure only 3 seconds — failures still grant faster retry opportunities.
- When a provoked creature is killed, the provoking player may receive luck bonuses via the `BardProvoked` flag chain.
