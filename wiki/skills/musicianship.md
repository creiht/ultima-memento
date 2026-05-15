# Musicianship

Musicianship is the foundation of all bardic skills and the Bard (Song) magic system.

## Overview

| Property | Value |
|---|---|
| **Primary Stat** | Dexterity |
| **Usage** | Passive (checked on every bard action) |
| **Skill Type** | Bard gatekeeper / Bard magic caster |
| **Skill Check** | 0.0 – 120.0 |

## Description

Musicianship is the gatekeeper skill for all three bard combat skills (Discordance, Peacemaking, Provocation) and serves as the casting skill, damage skill, and scaler for all 17 bard songs. Every bard action requires a successful Musicianship check before it can succeed.

## How It Works

### Instrument Check

`BaseInstrument.CheckMusicianship(from)` is called at the start of every Discordance, Peacemaking, and Provocation attempt:

```
success = (Musicianship / 100) > RandomDouble()
```

A failure fizzles the entire bard action — the instrument use is consumed but has no effect.

### Difficulty Reduction

Each point of Musicianship **above 100** reduces the target difficulty of bard skills by **0.5**. At 125 Musicianship this is a −12.5 reduction on the effective difficulty range.

### Peacemaking Duration

The duration of an area-Peacemaking effect scales directly:

```
Duration = Musicianship / 10 seconds
```

### SongBook (Bard Magic)

Musicianship is both the **casting skill** and **damage skill** for all spells in the Bard magic system:

- Equipping a *SongBook* requires **30+ base Musicianship**.
- Spell power and success rate scale with Musicianship throughout the song table.
- See [Bard magic](../magic/bard.md) for the full song list.

## How to Train

Double-clicking an instrument fires a `CheckSkill(Musicianship, 0.0, 120.0)` check. Every Discordance, Peacemaking, and Provocation attempt also contributes. Equip an instrument and play regularly.

## What It Affects

### Combat & Weapons

- `FireHorn.cs:69-74` — The Fire Horn artifact uses `CheckSkill(Musicianship)` with a difficulty formula of `(500 + (music - 775) * 2) / 1000`. Music above 77.5 (in base points) increases the success chance. Damage scales from Musicianship, Provocation, Discordance, and Peacemaking combined.
- `BaseInstrument.cs:857-861` — `CheckMusicianship()` calls `CheckSkill(Musicianship, 0.0, 120.0)` and checks `(Musicianship.Value / 100) > RandomDouble()` to determine success. Failure plays bad instrument sound and consumes the use.

### Bardic Skills

Musicianship is the **gatekeeper skill** for all three bard combat skills. Each skill calls `BaseInstrument.CheckMusicianship()` before attempting its own check:

- `System/Skills/Discordance.cs:183-200` — Discordance reads `Musicianship.Value` to reduce target difficulty by `0.5` per point above 100. Then calls `CheckMusicianship()` to verify the bard can play well enough.
- `System/Skills/Peacemaking.cs:70,88,106` — Area peacemaking reads Musicianship for duration (`Musicianship / 10` seconds) and difficulty reduction. Single-target pacify also uses it for duration scaling.
- `System/Skills/Provocation.cs:118,134,173,189` — Provocation uses Musicianship for difficulty reduction and calls `CheckMusicianship()` as a prerequisite.

### Magic Systems

Musicianship is the **cast skill**, **damage skill**, and **duration/damage scaler** for all 17 bard songs. Every `Song` class declares `CastSkill` and `DamageSkill` as `SkillName.Musicianship`.

A combined `MusicSkill()` function is used by most songs, which sums **Musicianship + Provocation + Discordance + Peacemaking** values:

```
MusicSkill = Musicianship + Provocation + Discordance + Peacemaking
```

#### Song List (see [Bard magic](../magic/bard.md))

| Song | Required Skill | Mana | Effect | Key Musicianship Usage |
|---|---|---|---|---|
| Army's Paeon | 55.0 | 15 | AoE HP regen | `rounds = Musicianship * 0.16` (tick count) |
| Enchanting Etude | 60.0 | 20 | +Int to allies | `duration = 0.24 * MusicSkill + 30` |
| Energy Carol | 50.0 | 12 | +Energy resist to allies | `amount = MusicSkill / 16` |
| Energy Threnody | 70.0 | 25 | -Energy resist on target | `amount = MusicSkill / 16`, `duration = 0.24 * MusicSkill + 30` |
| Foe Requiem | 50.0 | 30 | Damage over time to target | `damage = MusicSkill / 10`, double vs slayer targets |
| Fire Carol | 50.0 | 12 | +Fire resist to allies | `amount = MusicSkill / 16` |
| Fire Threnody | 70.0 | 25 | -Fire resist on target | `amount = MusicSkill / 16` |
| Ice Carol | 50.0 | 12 | +Cold resist to allies | `amount = MusicSkill / 16` |
| Ice Threnody | 70.0 | 25 | -Cold resist on target | `amount = MusicSkill / 16` |
| Knight's Minne | 50.0 | 12 | +Physical resist to allies | `amount = MusicSkill / 16` |
| Mage's Ballad | 55.0 | 15 | AoE mana regen | `rounds = Musicianship * 0.16`, `tick = 5 + MusicSkill/120` |
| Magic Finale | 90.0 | 35 | Dispels all summons/enemies | Highest cost/requirement song |
| Poison Carol | 50.0 | 12 | +Poison resist to allies | `amount = MusicSkill / 16` |
| Poison Threnody | 70.0 | 25 | -Poison resist on target | `amount = MusicSkill / 16` |
| Shepherd's Dance | 60.0 | 20 | +Dex to allies | `duration = 0.24 * MusicSkill + 30`, `amount = MusicSkill / 16` |
| Sinewy Etude | 60.0 | 20 | +Str to allies | `duration = 0.24 * MusicSkill + 30`, `amount = MusicSkill / 16` |

**Duration formula** (for buff songs): `Duration = 0.24 * MusicSkill + 30 seconds`. At 200 total music skill this is ~78 seconds. At 400 it is ~99 seconds (capped).

**Buff amount formula** (for stat/resist songs): `Amount = MusicSkill / 16`. At 200 total this is +12. At 400 it is +25.

**Tick counts** (for regen songs): `Rounds = Musicianship * 0.16`. At 100 Musicianship that's 16 ticks. **Each tick** grants a chance to gain Musicianship skill via `CheckSkill(Musicianship, 0.5)` (`MagesBalladSong.cs:98`, `ArmysPaeonSong.cs:98`, `FoeRequiemSong.cs:140`).

### Crafting & Harvest

- `Trades/Crafting/DefTinkering.cs:179-180` — Crafting a **Trumpet** requires **45.0–50.0 Musicianship** in addition to 57.8–82.8 Tinkering and 20 Iron Ingots.
- `System/Misc/ResourceMods.cs:535` — Runic instruments can have a skill bonus of +1–20 to Musicianship (or Provocation/Peacemaking/Discordance) applied via runic focus.

### Items

| Item | Effect |
|---|---|
| `SongBook.cs:60` | Requires **30 base Musicianship** to wield. Stores and displays 16 bard songs. |
| `FireHorn.cs:69,74` | Artifact horn that checks Musicianship for success. Damage formula: `(musicScaled + provScaled*3 + discScaled*3 + peaceScaled) / 80` weighted average (AOS). |
| `Elixirs.cs:3236-3336` | Alchemy elixir that temporarily boosts Musicianship via `DefaultSkillMod`. Duration scales with Cooking (40%) + Tasting (40%) + Alchemy (20%). Strength scales same way (+10 to +60). Sold at Alchemy market for 70–95 gold. |
| `Artifact_GwennosHarp.cs:27` | +10 Musicianship |
| `Artifact_HornOfKingTriton.cs:26` | +10 Musicianship |
| `Artifact_SongWovenMantle.cs:18` | +25 Musicianship |
| `GuildRing.cs:69` | +10 Musicianship when worn |
| `ResourceMods.cs:535` | Runic instruments: +1–20 Musicianship via runic focus |

### AI & NPCs

| Creature | Musicianship Range | Notes |
|---|---|---|
| `Minstrel.cs:58` | 65.0–87.5 | Humanoid merchant NPC |
| `ElfMinstrel.cs:53` | 65.0–87.5 | Elf variant |
| `BardGuildmaster.cs:23` | 80.0–100.0 | Guild NPC |
| `Bard.cs:29` | 64.0–100.0 | Merchant NPC |
| `HarpyElder.cs:41` | 60.1–80.0 | Harpy boss type |
| `HarpyHen.cs:40` | 85.1–95.0 | Strongest harpy |
| `Satyr.cs:40`, `xDryad.cs:42`, `Xatyr.cs:41` | 60.0–80.0 | Mystical creatures |
| `MLDryad.cs:41` | 60.0–80.0 | Mythic Lord variant |
| `Harpy.cs:37` | 30.1–50.0 | Base harpy |
| `StoneHarpy.cs:40`, `SnowHarpy.cs:40` | 40.1–60.0 | Variant harpies |
| `BaseSailor.cs:36` | level/3 | Scales with sailor level |
| `BaseCreature.cs:7920` | Reads `this.Skills.Musicianship.Value` | Creatures with Musicianship can pacify players (`PeacedUntil`) or suppress player skills (-28% all skills for 20-80 seconds) |

**Creature AI effects** (`BaseCreature.cs:7915-7943`): A creature with Musicianship can pacify a nearby player (30-second cooldown window). Success check: `RandomMinMax(bard-20, bard) < RandomMinMax(resist-20, resist)`. Duration: `10 * (bard/100)` to `25 * (bard/100)` seconds.

**Suppress ability** (`BaseCreature.cs:7946-7987`): Creatures with Musicianship can suppress a target, reducing **all skills by 28%** for 20–80 seconds. Resist check same as pacify.

### Quests & Achievements

- `Engines and Systems/Quests/Bards Tale/MangarsRewards.cs:122` — The **Bardic Feathered Cap** quest reward from the Bards Tale quest gives +10 Musicianship, +10 Provocation, +10 Discordance, +10 Peacemaking, +10 RegenMana, +10 BonusDex.
- `Mobiles/Unique/Mangar.cs:334` — Mangar checks `Musicianship.Base > 0` as one of the four class requirements (Necromancy, Magery, Musicianship, Elementalism) for the Chest of Mangar Relics reward.
- `Engines and Systems/Quests/Codex/CodexWisdom.cs:97,420` — Codex Wisdom skill training can teach Musicianship (skill index 35).
- `System/Misc/CharacterCreation.cs:328,949` — Character creation includes Musicianship with a minimum of 30.0 base skill required for bard-type characters.
- `Items/Books/PowerScroll.cs:38` — Musicianship has a power scroll (max 120.0) available for training beyond 100.0.

## Related Systems & Skills

### Synergies

- `[Discordance](discordance.md)`: Every Discordance check requires a successful Musicianship check first. Each point of Musicianship above 100 reduces Discordance difficulty by 0.5.
- `[Peacemaking](peacemaking.md)`: Area peacemaking duration = `Musicianship / 10` seconds. Difficulty reduced by 0.5 per point above 100.
- `[Provocation](provocation.md)`: Provocation checks require successful Musicianship check. Difficulty reduced by 0.5 per point above 100.
- `[Mage's Ballad / Army's Paeon](../magic/bard.md)`: Both regen songs tick at `Musicianship * 0.16` rounds. Each tick grants Musicianship skill gain chance.
- `[Foe Requiem](../magic/bard.md)`: Damage = `MusicSkill / 10`. Each tick grants Musicianship skill gain chance.

### Prerequisites / Co-requisites

- **SongBook** requires 30.0 base Musicianship to equip (`SongBook.cs:60`).
- All bard songs have individual Musicianship requirements (50.0–90.0) — see [Bard magic](../magic/bard.md).
- All three bard combat skills (Discordance, Peacemaking, Provocation) require a successful Musicianship instrument check as a prerequisite.

## Notes

- Musicianship is the only bard skill that is checked *before* any other bard skill — it gates all bard actions.
- The `MusicSkill()` combined total (Musicianship + Provocation + Discordance + Peacemaking) is the most important single number for bard effectiveness, powering all song effects.
- Power scrolls exist for Musicianship, capping at 120.0 (`PowerScroll.cs:38`).
