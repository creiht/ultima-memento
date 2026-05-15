# Seafaring

Seafaring governs fishing, sailing, and maritime combat. It is the primary skill for all ocean-based activities in Ultima Memento.

## Overview

| Property | Value |
|---|---|
| **Primary Stat** | Dexterity |
| **Usage** | Passive (fishing / sailing actions) |
| **Skill Type** | Trade / Exploration |
| **Skill Check** | 0 - 125 |

## Description

Seafaring is the primary skill for maritime activities. It governs fishing, sailing speed, harpoon damage, boat access, salvage operations, and special sea-based loot tables. At higher tiers, Seafaring also enables unique capabilities such as docking anywhere and unlocking rare fishing mutates.

## How It Works

### Fishing

Seafaring is the sole skill checked on every fishing attempt. Below 50 skill you may fish from land; at **50 or higher** you must be aboard a boat to fish in open water.

### Boat Speed

Higher Seafaring unlocks faster sailing speeds through movement tick reductions:

| Seafaring Skill | Speed Tier |
|---|---|
| 0–49 | Base speed |
| 50–74 | −25 ms per movement tick |
| 75–99 | −50 ms per movement tick |
| 100–124 | −75 ms per movement tick |
| 125 | −100 ms per movement tick |

### Sunken Ship Loot

Killing a sea creature or pirate adds `Seafaring / 25` bonus loot levels to any sunken ship treasures in the area.

### Harpoon Damage Bonus

The Harpoon weapon gains a damage bonus based on Seafaring:

```
Harpoon bonus = GetBonus(Seafaring, 0.20, 100.0, 10.0)
```

This stacks with the standard Marksmanship hit chance.

### Boat Access

- At **90+ Seafaring**, the boat door becomes visible to you from outside.
- At **Grandmaster (100+)**, you may dock your boat anywhere rather than at official docks only.

## How to Train

Seafaring gains passively on each fishing action and each sailing movement. Fish regularly and sail frequently to raise it.

## What It Affects

### Fishing & Harvest

- `Fishing.cs:58` — Fishing harvest system uses Seafaring as its sole skill check (`fish.Skill = SkillName.Seafaring`).
- `Fishing.cs:109-119` — `FinishHarvesting()` blocks Seafaring gains on land once skill reaches 50, forcing players to fish from boats for further training.
- `Fishing.cs:129-136` — `FishingSkill()` calls `CheckSkill(SkillName.Seafaring, 0, 125)` for skill gain on each fish.
- `Fishing.cs:139-146` — `SailorSkill()` calls `CheckSkill(SkillName.Seafaring, 0, 125)` when piloting a boat.
- `Fishing.cs:165-173` — Mutate table: high-sea fishing (on boat, far from town) unlocks rare items like `SpecialFishingNet`, `PearlSkull`, `FabledFishingNet`, `TreasureMap`, `MessageInABottle` at 80–90 skill.
- `Fishing.cs:212-287` — `IsNearHugeShipWreck()` checks 30+ coordinates across all maps for shipwreck loot.
- `Fishing.cs:290-298` — `IsNearSpaceCrash()` checks 2 coordinates on Sosaria for sci-fi loot drops.
- `Fishing.cs:301-318` — `IsNearUnderwaterRuins()` checks specific map coordinates for fishing up relics.
- `HarvestSystem.cs:396-404` — At special locations (shipwrecks, space crash, underwater ruins), fishing poles check Seafaring 1–250 for special loot.

### Containers & Salvage

- `WaterChest.cs:68-69` — Chopping a water chest (driftboat) checks Seafaring / 10 (capped at 13) for salvage success.
- `WaterChest.cs:74-88` — Success grants random board types (Oak, Pine, Driftwood, Petrified, etc.) scaled by Carpentry.
- `SunkenShip.cs:59-60` — Chopping a sunken ship also checks Seafaring / 10 for salvage.
- `SunkenShip.cs:55-87` — Sunken ship salvage adds wood quantity based on ship weight + Carpentry / 2.
- `BaseBoat.cs:516` — Killing a boat's crew adds `Seafaring / 25` bonus loot levels.
- `Cargo.cs:865` — `CargoFishingGold()` calculates cargo gold as `cargoValue * (Seafaring * 0.01) / 3`.

### Weapon Combat

- `BaseWeapon.cs:2393` — Harpoon damage bonus formula: `GetBonus(Seafaring, 0.20, 100.0, 10.0)` adds to weapon damage.

### Boat Mechanics

- `BaseBoat.cs:946-953` — Boat speed tiers: 0–49 (no boost), 50–74 (+1, −25 ms/tick), 75–99 (+2, −50 ms/tick), 100–124 (+3, −75 ms/tick), 125+ (+4, −100 ms/tick) — absolute max.
- `BaseBoat.cs:213` — At 90+ Seafaring, the boat door becomes visible from outside.
- `BaseBoatDeed.cs:178` — Same 90+ threshold when placing a boat deed.
- `DockingLantern.cs:117` — 100+ Seafaring (Grandmaster) allows docking and launching anywhere, not just at official docks.

### Fishing Nets (Skill-Gated Items)

- `FishingNet.cs:47,83` — Basic fishing net requires 30 Seafaring; used on high seas from a boat.
- `SpecialFishingNet.cs:48,83` — Special fishing net requires 60 Seafaring.
- `FabledFishingNet.cs:45,81` — Fabled fishing net requires 90 Seafaring.
- `NeptunesFishingNet.cs:39,75` — Neptune's fishing net requires 100 Seafaring.
- All nets spawn sea creatures (AquaticGhoul, SeaSnake, WaterElemental, Kraken, etc.) when cast.

### Seaweed Potions

- `SpecialSeaweed.cs:67` — Squeezing seaweed checks `CheckSkill(SkillName.Seafaring, SkillNeeded, 125)` where SkillNeeded ranges from 50 to 95.
- `SpecialSeaweed.cs:27-58` — 31 seaweed varieties each require different skill thresholds and produce potions (healing, poison, mana, invisibility, etc.).
- Skill 50: Seaweed of Nightsight, Lesser Cure, Lesser Poison, Lesser Heal, Lesser Explosion, Lesser Invisibility, Lesser Rejuvenate, Lesser Mana.
- Skill 60: Seaweed of Cure, Agility, Strength, Poison, Refresh, Heal, Explosion, Invisibility, Rejuvenate, Mana.
- Skill 70+: Seaweed of Greater Poison (70), Deadly Poison (80), Lethal Poison (80), Greater varieties (80).
- Skill 95+: Seaweed of Invulnerability (95).

### Elixirs

- `Elixirs.cs:1675-1753` — **Elixir of Seafaring** (`ElixirFishing`) adds a temporary skill mod to Seafaring.
- `Elixirs.cs:1728` — Drink target: `SkillName.Seafaring`, duration scaled by Cooking + Tasting + Alchemy, strength +10 to +60.
- `PotionKeg.cs:526` — Keg version named "keg of seafaring elixir".
- Elixir stacking rule: max 2 active elixirs at once, cannot drink another of the same type.

### Artifacts & Trinkets

| Item | Bonus | Source |
|---|---|---|
| Sword of Sinbad | Seafaring +30 | `Artifact_SinbadsSword.cs:19` |
| Dread Pirate Hat | Seafaring +20 | `Artifact_DreadPirateHat.cs:19` |
| Fishing Hook Talisman | Seafaring +5–20 | `TrinketTalisman.cs:210` |
| Fishermen's Guild Ring | Seafaring +30 | `GuildRing.cs:66` |

### NPCs with Seafaring

| NPC | Seafaring Range | Source |
|---|---|---|
| Fisherman | 75.0–98.0 | `Fisherman.cs:18` |
| Drunken Pirate | 75.0–98.0 | `DrunkenPirate.cs:24` |
| Shipwright | 75.0–98.0 | `Shipwright.cs:32` |
| Devon | 75.0–98.0 | `Devon.cs:33` |
| Fisher Guildmaster | 80.0–100.0 | `FisherGuildmaster.cs:22` |

### Avatar System

- `SkillArchive.cs:183-184` — Seafaring archived as property `Seafaring` (index 19) in the Avatar system.

### Harvest Tools

- `ResourceMods.cs:189` — Fishing poles can be crafted with Seafaring skill bonuses (slot 4) via `BaseHarvestTool.SkillBonuses.SetValues(4, SkillName.Seafaring, skill)`.

## Related Systems & Skills

### Synergies

- [Marksmanship](marksmanship.md): The Harpoon uses both Seafaring (damage bonus) and Marksmanship (hit chance).
- [Tracking](tracking.md): Can detect hidden sea creatures that Seafaring alone cannot reveal.
- [Mercantile](mercantile.md): Increases gold received when selling caught fish and cargo to merchants.
- [Carpentry](../crafting/carpentry.md): Affects quality of boards salvaged from driftboats and sunken ships.
- [Begging](begging.md): Begging demeanor provides bonus gold when selling cargo.

### Prerequisites / Co-requisites

- None.

## Notes

- At skill 50, fishing from land is blocked; you must be aboard a boat to gain Seafaring on further fishing attempts.
- Grandmaster Seafaring (100+) grants the unique ability to dock anywhere, bypassing official docks entirely.
- The Harpoon is the only weapon that uses Seafaring for its damage bonus — it combines Seafaring (damage) with Marksmanship (hit chance).
- Seafaring contributes to Elixir of Seafaring duration and strength, scaled by Cooking + Tasting + Alchemy.
