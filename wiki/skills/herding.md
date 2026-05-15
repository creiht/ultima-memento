# Herding

Herding lets you direct tamable animals with a shepherd's crook, assists with pet loyalty control, and amplifies pet experience gain.

## Overview

| Property | Value |
|---|---|
| **Primary Stat** | Strength |
| **Usage** | Active (Shepherd's Crook) + Passive (pet checks) |
| **Skill Type** | Pet / Utility |
| **Skill Check** | Varies (creature-specific; see formulas below) |
| **Cooldown** | None |

## Description

Herding is used to move tamable creatures via a Shepherd's Crook, assist pet loyalty checks, and boost pet experience gain. It works in tandem with Taming, Druidism, and Veterinary to unlock Beastmaster tiers that increase maximum followers and stable slots.

## How It Works

### Moving Animals

Double-click a *Shepherd's Crook*, target a tamable (non-paragon) creature, then target a destination tile. The skill check uses:

```
CheckTargetSkill(Herding, creature,
    MinTameSkill - 30,
    MinTameSkill + 30 + rand(0, 10))
```

Higher taming-difficulty creatures are harder to herd.

### Pet Loyalty Assist

Inside `BaseCreature.CheckControlChance()`, Herding fires a passive loyalty save:

- On roughly **15% of successful control checks**, a Herding gain check fires.
- On **loyalty failure**, the server rolls `CheckSkill(Herding, MinTameSkill-25, MinTameSkill+25)` — a success prevents the loyalty drop.

### Pet XP Multiplier

Pet experience earned is multiplied by up to:

```
Pet XP × (1 + Herding / 500)
```

At 100 Herding this is a **+20% bonus**; at the 125 cap it reaches **+25%**.

### Beastmaster Title

Reaching the following combined thresholds simultaneously unlocks the **Beastmaster** player title:

| Tier | Required Skill Level (Herding + Veterinary + Druidism + Taming) |
|---|---|
| Tier 1 | All four skills ≥ 60 |
| Tier 2 | All four skills ≥ 90 |
| Tier 3 | All four skills ≥ 120 |

## How to Train

Use a Shepherd's Crook on tamable creatures. Herding also gains passively during pet control and loyalty events when you have a pet out.

## What It Affects

### Pet Control & Loyalty
- `BaseCreature.cs:1958` — On ~15% of successful control checks, a Herding gain check fires: `CheckSkill(Herding, 0, MinTameSkill + 25)`.
- `BaseCreature.cs:1971` — On loyalty failure, `CheckSkill(Herding, MinTameSkill - 25, MinTameSkill + 25)` can prevent the loyalty drop entirely.

### Pet Experience Bonus
- `BaseCreature.cs:10081-10082` — Pet XP earned in combat is multiplied: `experience += experience * Skills[Herding].Value / 500` (up to +25% at 125 Herding).

### Pet Movement (CheckHerding)
- `Behavior.cs:7155-7173` — `CheckHerding()` moves a herded creature toward its `TargetLocation` each tick while distance is between 1-15 tiles. Called from `DoOrderFollow()` (line 7177), `OnOrderResponse()` (lines 6797, 6843, 6862), and `OnMovement()` (line 7708).

### Max Followers (Beastmaster Gates)
- `PlayerMobile.cs:641-642` — `OnSkillInvalidated()` calls `UpdateFollowers()` when Herding changes.
- `PlayerMobile.cs:653-663` — Combined thresholds of Herding + Veterinary + Druidism + Taming set `FollowersMax`:
  - All ≥ 60 → 6 followers
  - All ≥ 90 → 7 followers
  - All ≥ 120 → 8 followers

### Max Stabled Pets
- `AnimalTrainer.cs:240-276` — `GetMaxStabled()` uses Herding in a four-skill sum (Taming + Druidism + Veterinary + Herding) for base capacity tiers (2-7 stables). At 100+ Herding, adds `(Herding - 90) / 10` extra slots.

### Shepherd's Crook Items
- `ShepherdsCrook.cs:57-151` — Double-click to herd tamable (non-paragon) creatures. Uses `CheckTargetSkill(Herding, creature, MinTameSkill - 30, MinTameSkill + 30 + random(10))`.
- `LevelShepherdsCrook.cs:60-132` — Enhanced variant with `CheckTargetSkill(Herding, creature, 0, 125)`.
- `GiftShepherdsCrook.cs:60-132` — Gift variant with same mechanics as Level variant.

### Elixir of Herding
- `Elixirs.cs:2195-2294` — Adds a temporary `DefaultSkillMod` to Herding. Crafted via Alchemy.
- `DefAlchemy.cs:297` — Recipe requires Pixie Skull, Sulfurous Ash, and Empty Bottle at 60.0–120.0 Alchemy.
- `ItemSales.cs:3981` — Sold at the Alchemy market for 95 gold.

### Bard Spell: Shepherd's Dance
- `SheepfoeMamboSong.cs:8-83` — Requires 60 Music skill, costs 20 mana. Grants Dex bonus to nearby friends: `Dex += PlayerLevelMod(MusicSkill / 16, caster)`. Duration: `0.24 * MusicSkill + 30` seconds. Applies `BuffIcon.ShephardsDance` buff.

### BreakDown Material Yield
- `BreakDown.cs:644` — ShepherdsCrook breaks down to 7 materials.

### Dinosaur Scales Crafting Modifier
- `ResourceInfo.cs:1323` — Dinosaur Scales armor requires Herding 24.0 (Skill3Val = 1) alongside Taming 53.0 and Tactics 4.0.

### Runic Tool Affinity
- `BaseRunicTool.cs:207` — Herding is a valid skill for runic tool creation (listed alongside 40+ other skills).

### NPC Vendors & Trainers
- `Shepherd.cs:13-564` — Stable NPC; offers pet stabling (30g/pet) and claimed pets. Has context menu entries for stabling, claiming, and riding gumps. Responds to `*stable*` and `*claim*` speech keywords.
- `Druid.cs:27` — Sets Herding 80-100; sells ShepherdsCrook (slot 5).
- `DruidTree.cs:34` — Sets Herding 80-100.
- `DruidGuildmaster.cs:25` — Sets Herding 80-100; sells ShepherdsCrook (slot 5).
- `Rancher.cs:24` — Sets Herding 64-100.
- `RangerGuildmaster.cs:30` — Sets Herding 36-68.
- `AnimalTrainer.cs:243-244` — Herding factored into max stabled calculation alongside Taming, Druidism, Veterinary.
- `Fighter.cs:189` — Sells ShepherdsCrook as slot 36 equipment.

### Character Creation & Display
- `CharacterCreation.cs:269-270` — Players who choose Herding as a favorite skill receive a ShepherdsCrook.
- `CharacterCreation.cs:963` — Herding listed at value 30 in skill selection.
- `SkillCheck.cs:36` — Herding is flagged as a gainable skill (index 20).
- `Talk.cs:167` — Shepherd vendor dialogue mentions herding helps manage more pets.

## Related Systems & Skills

### Synergies
- [Taming](taming.md): Primary skill for bonding with and controlling pets.
- [Veterinary](veterinary.md): Healing/resurrection for animals; shares the Beastmaster gate.
- [Druidism](druidism.md): Animal knowledge skill; also required for the Beastmaster title and pet resurrection.
- [Alchemy](../crafting/alchemy.md): Elixir of Herding crafting profession.

### Prerequisites / Co-requisites
- [Tactics](tactics.md): Combined with animal skills for Dinosaur Scales crafting modifier.
- [Musicianship](musicianship.md): Shepherd's Dance is a bard song spell.
- [Druidism](../magic/druidism.md): Druidism magic system.

## Notes

- Herding is one of four "pet skills" (with Taming, Druidism, Veterinary) that jointly determine Beastmaster tiers, max followers, and max stabled pets.
- The Shepherd's Crook only works on non-paragon tamable creatures.
- At 125 Herding (the skill cap), the pet XP multiplier reaches its maximum of +25%.
