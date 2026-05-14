# Peacemaking

Peacemaking uses soothing music to calm hostile creatures, forcing them to stop attacking.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Intelligence |
| Usage | Active (targeted, requires instrument) |
| Cooldown | 5-10 seconds |

## How It Works

1. Use the skill to select an instrument.
2. Choose a target - either **yourself** for area-of-effect calming, or a **single creature** for targeted pacification.

### Area Peacemaking (Target Self)

Targets all hostile creatures within bard range. Each creature gets an individual difficulty check. If a creature's check fails, there is a 50% chance your entire song stops. Successful targets are pacified for `Musicianship / 10` seconds.

Some creatures are immune to area peacemaking (AreaPeaceImmune flag).

### Targeted Peacemaking (Target Creature)

Pacifies a single creature for a longer duration:

```
Duration = 100 - (difficulty / 1.5) seconds
(minimum 10, maximum 120 seconds)
```

### Against Players

Targeted peacemaking against players is possible. If the target's Magic Resist check fails, they are **paralyzed** for the calculated duration (with a Peacemaking buff icon).

### Musicianship Bonus

Musicianship above 100 reduces the difficulty by `(Musicianship - 100) * 0.5`.

### Minimum Skill Requirement

The game tells you the minimum Peacemaking skill needed to attempt a target: `difficulty - 25`.

### Restrictions

- Cannot calm Uncalmable creatures.
- Cannot calm an already-pacified creature.
- A Musicianship check must pass before the Peacemaking check.
- Instrument uses are consumed on each attempt.

## How to Train

Target progressively harder creatures. Area peacemaking (targeting yourself) is good for training on groups but riskier. Single-target mode gives longer pacification.

## What It Affects

### Combat & Pacification
- `System/Skills/Peacemaking.cs:76` — Area peacemaking checks `CheckSkill(Peacemaking, 0.0, 120.0)` on self-target.
- `System/Skills/Peacemaking.cs:111` — Per-creature in AoE uses `CheckTargetSkill(Peacemaking, m, diff-25, diff+25)` where difficulty is instrument-based minus 10, reduced further by excess Musicianship.
- `System/Skills/Peacemaking.cs:189` — Single-target mode uses `CheckTargetSkill(Peacemaking, targ, minSkill, maxSkill)` with a minimum skill gate at `diff - 25` (`Peacemaking.cs:183`).
- `System/Skills/Peacemaking.cs:135` — Successful creature pacification calls `BaseCreature.Pacify()` for `Musicianship / 10` seconds (AoE) or `100 - (difficulty / 1.5)` seconds clamped 10–120 (single-target).
- `System/Skills/Peacemaking.cs:219` — Against players with high Magic Resist, target is paralyzed with `BuffIcon.PeaceMaking` buff applied (`Peacemaking.cs:228-229`).

### Bardic Music & Songs
- `Engines and Systems/Magic/Bard/SongSpells.cs:63` — `MusicSkill()` sums Musicianship + Provocation + Discordance + Peacemaking; used for overall bardic power calculations.
- `Items/Trades/Misc/FireHorn.cs:112-123` — Firehorn damage formula weights Peacemaking (along with Provocation and Discordance) at 1/4 the weight of Provocation/Discordance in the average: `(music + prov*3 + disc*3 + peace) / 80`.

### Crafting — Alchemy
- `Engines and Systems/Trades/Crafting/DefAlchemy.cs:345` — `Elixir of Peacemaking` requires 60.0–120.0 Alchemy, crafted from Pixie Skull + Bottle + Sulfurous Ash + Amber. Duration and strength scale with Tasting, Cooking, and Alchemy skills.
- `Items/Trades/Magical/Tools/BaseRunicTool.cs:222,305` — Runic tools can have Peacemaking as a bonus skill.
- `System/Misc/ResourceMods.cs:539` — Resource-modified instruments can award Peacemaking bonuses (var 39).

### Items with Peacemaking Bonuses
- `Items/Magical/Artifacts/Instruments/Artifact_GwennosHarp.cs:28` — Gwenna's Harp gives +10 Peacemaking.
- `Items/Magical/Artifacts/Instruments/Artifact_HornOfKingTriton.cs:27` — Horn of King Triton gives +10 Peacemaking.
- `Items/Trinkets/GuildRing.cs:70` — Bard Guild Ring gives +10 Peacemaking.
- `Engines and Systems/Quests/Bards Tale/MangarsRewards.cs:125` — Bardic Feathered Cap (Bard's Tale quest reward) gives +10 Peacemaking.

### NPC Vendors
- `Mobiles/Civilized/Merchants/Bard.cs:30` — Bard vendor sells black market goods; has 65.0–88.0 Peacemaking.
- `Mobiles/Civilized/Guilds/BardGuildmaster.cs:24` — Bard Guildmaster has 80.0–100.0 Peacemaking.

### AI Behavior
- `Mobiles/Base/Behavior.cs:6250` — Peacemaking is listed in the skills that Behavior AI may use.
- `Mobiles/Omni AI/OmniAI Bard.cs:43,206-231` — Omni AI Bard uses `UsePeacemaking()` in rotation; against player combatants sets `PeacedUntil` to `self.Skills[Peacemaking].Value / 5` seconds; against other targets invokes the target callback.

### Elixirs
- `Items/Potions/Elixirs/Elixirs.cs:3444-3544` — `ElixirPeacemaking` grants a temporary skill mod to Peacemaking. Duration scales with Cooking (40%) + Tasting (40%) + Alchemy (20%). Max 2 active elixirs at once; cannot re-drink same type while active.
- `Items/Trades/Alchemy/PotionKeg.cs:405` — Potion Kegs can produce Elixir of Peacemaking.
- `System/Misc/ItemSales.cs:3993` — Elixir of Peacemaking listed as alchemy market item, price 70 gold.

### Avatar System
- `Engines and Systems/Avatar/SkillArchive.cs:163-164` — Peacemaking tracked as `Peacemaking` property in SkillArchive.

### Character Creation
- `System/Misc/CharacterCreation.cs:217` — Peacemaking available as a selectable starting skill.
- `System/Misc/CharacterCreation.cs:950` — Some character packages include 30.0 starting Peacemaking.

### Power Scrolls
- `Items/Books/PowerScrolls/PowerScroll.cs:18` — Peacemaking has a Power Scroll for raising beyond 100.0.
- `Items/Books/PowerScrolls/PowerScroll.cs:230,286,390` — Power scroll serialization, naming, and lookup for Peacemaking.

### Other Systems
- `System/Skills/SkillCheck.cs:25,304` — Peacemaking counted as a "true" skill in `SkillCheck` (always counts toward skill cap calculations).
- `Mobiles/Races/BaseRace.cs:1309` — Gargoyle racial skill assignment maps index 9 → Peacemaking.
- `Items/Misc/Scrolls/SpecialScroll.cs:67` — Special scroll skill mapping: index 10 → Peacemaking.
- `System/Misc/ChangeLog.cs:88,688` — Peacemaking changelog: displays minimum skill warning; creature pacification duration scales with mob skill.

## Related Skills

- [Discordance](discordance.md) — Weakens targets' resistances instead of pacifying.
- [Provocation](provocation.md) — Turns creatures against each other; Firehorn damage formula weights Provocation/Discordance higher than Peacemaking.
- [Musicianship](musicianship.md) — Required for all bardic skills; area peacemaking duration = Musicianship / 10; Musicianship > 100 reduces difficulty.
- [Begging](begging.md) — Can also pacify creatures without an instrument.
- [Healing](healing.md) — Listed alongside Peacemaking in the Behavior AI skill pool.
