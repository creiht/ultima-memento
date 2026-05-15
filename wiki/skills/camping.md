# Camping

Camping is a survival skill for lighting fires, sleeping in bedrolls, and pitching tents in the wilderness. It also enables bypassing hunger and thirst decay while resting.

## Overview

| Property | Value |
|---|---|
| **Primary Stat** | Dexterity |
| **Usage** | Active (triggered by item use) |
| **Skill Type** | Trade / Survival |
| **Skill Check** | 0 - 125 |

## Description

Camping allows players to set up temporary shelters in the wilderness. By lighting campfires, sleeping in bedrolls, and using camping tents, players can restore HP and stamina while bypassing hunger and thirst decay. Camping also gates access to Ranger Outpost housing and certain wilderness activities.

## How It Works

### Campfire

Double-click a piece of *Kindling* to attempt to light a campfire. The skill check range is 0–100. A burning campfire restores **+2 HP and +2 Stamina per second** to nearby players who are not hungry or thirsty.

### Bedroll

Using a *Bedroll* near a campfire performs a skill check (range 0–125) to allow rest. Successful rest can bypass hunger decay, rolling `Camping` against a random value of 1–200.

### Camping Tent

A *Camping Tent* teleports you to a private instanced tent room outdoors:
- Requires **40+ Camping** to use in the open world.
- Requires **90+ Camping** to use in dungeons.

The 90+ threshold also gates **Ranger Outpost** player housing placement in outdoor regions.

### Training Cadence

Each fire light, bedroll use, or tent entry calls `RaiseCamping()`, which bursts **10 `CheckSkill` calls** at once — making skill gain fast when actively using the skill.

## How to Train

Use Kindling, a Bedroll, or a Camping Tent repeatedly. Each item use fires a burst of skill checks, so gains happen quickly even at higher skill levels.

## What It Affects

### Survival & Regeneration

- `FoodDecay.cs:63` — Hunger decay bypass: if `Camping.Value >= random(1, 200)`, hunger does not decrease that tick.
- `FoodDecay.cs:126` — Thirst decay bypass: same check applies to thirst.
- `Campfire.cs:131` — Resting on a campfire performs `CheckSkill(Camping, 0, 125)` per tick while HP/Stamina are restored.
- `BedrolledOut.cs:102` — Resting on a placed bedroll also performs `CheckSkill(Camping, 0, 125)` per tick.

### Item Usage Checks

| Item | Skill Check | Threshold | File:Line |
|---|---|---|---|
| Kindling (light fire) | `CheckSkill` | 0–100 | `Kindling.cs:144` |
| Kindling (success) | `RaiseCamping` → 10× `CheckSkill` | 0–125 | `Kindling.cs:91-99` |
| Bedroll (place) | `CheckSkill` | 0–125 | `Bedroll.cs:91` |
| Bedroll (success) | `RaiseCamping` → 10× `CheckSkill` | 0–125 | `Bedroll.cs:98` |
| Small Tent | `CheckSkill` | 0–50 | `SmallTent.cs:81` |
| Small Tent (requirement) | `Skills[Camping].Value` | ≥10 | `SmallTent.cs:109` |
| Camping Tent (outdoors) | `Skills[Camping].Value` | ≥40 | `CamperTent.cs:65` |
| Camping Tent (dungeons) | `Skills[Camping].Value` | ≥90 | `CamperTent.cs:90` |
| Hitching Post (stable) | `Skills[Camping].Base` | ≥100 (Grandmaster) | `StableStone.cs:122,275` |

### Region & Housing Gates

- `OutDoorRegion.cs:23` — Ranger Outpost housing placement requires `Camping >= 90` or `Tracking >= 90`.
- `MagicForges.cs:744` — Altar of Golden Rangers / Ranger Outpost access requires `Camping >= 90` or `Tracking >= 90`.
- `GoldenFeathers.cs:53` — Phoenix/Harpy kills grant Golden Feathers drop only if killer has `Camping >= 90` (or `Tracking >= 90`) and carries a `GoldenRangers` item.

### Elixirs

- `Elixirs.cs:843-943` — **Elixir of Camping** (`ElixirCamping`) grants a temporary `DefaultSkillMod` bonus to Camping when consumed. Usable as a keg from `PotionKeg.cs:380`.

### Items That Grant Camping Bonuses

| Item | Bonus | Source |
|---|---|---|
| Barbaric Talisman (SavageTalisman) | Camping +80, Cooking +50 (default) | `SavageTalisman.cs:26` |
| Rangers Guild Ring | Camping +25 | `GuildRing.cs:53` |

### NPCs with Camping Skill

| NPC | Camping Range | File:Line |
|---|---|---|
| Ranger Guildmaster | 75–98 | `RangerGuildmaster.cs:22` |
| Druid Guildmaster | 80–100 | `DruidGuildmaster.cs:26` |
| Wandering Healer | 80–100 | `WanderingHealer.cs:39` |
| Merchant (base) | 65–88 | `Merchant.cs:27` |
| Provisioner | 65–88 | `Provisioner.cs:30` |
| Ranger | 65–88 | `Ranger.cs:23` |
| Druid | 80–100 | `Druid.cs:28` |
| Druid Tree | 80–100 | `DruidTree.cs:35` |
| Furtrader | 55–78 | `Furtrader.cs:28` |

All of these NPCs sell camping-related gear through their vendor stock (`Market.Ranger` / `Market.Supplies` categories).

## Related Systems & Skills

### Synergies

- [Cooking](../crafting/cooking.md): Campfires enable food cooking; Barbaric Talisman bonds Camping + Cooking together (+80/+50).
- [Tracking](tracking.md): Shares the 90+ requirement for Ranger Outpost housing and Golden Feathers drops.
- [Hiding](hiding.md) / [Stealth](stealth.md): All three skills are bonded for Assassin's Guild ring members. Safe camping requires no enemies nearby (`EnemiesNearby` check in `Kindling.cs:44-56`).
- [Taming](taming.md) / [Veterinary](veterinary.md): Rangers and Druids (who have high Camping) also have Taming/Veterinary; the Hitching Post (100+ Camping) lets you stable pets at home.

### Prerequisites / Co-requisites

- **Ranger Outpost Housing**: Requires `Camping >= 90` or `Tracking >= 90` (`OutDoorRegion.cs:23`).

## Notes
- Each Kindling, Bedroll, or Tent use fires 10 `CheckSkill` calls at once, making Camping one of the fastest skills to train.
- Safe camping requires no enemies nearby (`EnemiesNearby` check in `Kindling.cs:44-56`).
- The Hitching Post at Grandmaster Camping (100+) lets you stable pets at home without a stable master.

