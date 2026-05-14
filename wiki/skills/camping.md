# Camping

Camping is a survival skill for lighting fires, sleeping in bedrolls, and pitching tents in the wilderness.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Dexterity |
| Usage | Passive (triggered by item use) |
| Cooldown | None |

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

### Elixir

- `Elixirs.cs:843-943` — `Elixir of Camping` (`ElixirCamping`) grants a temporary `DefaultSkillMod` bonus to Camping when consumed. Usable as a keg from `PotionKeg.cs:380`.

## Items That Grant Camping Bonuses

| Item | Bonus | Source |
|---|---|---|
| Barbaric Talisman (SavageTalisman) | Camping +80, Cooking +50 (default) | `SavageTalisman.cs:26` |
| Rangers Guild Ring | Camping +25 | `GuildRing.cs:53` |

## NPCs with Camping Skill

| NPC | Camping Range | Location / Notes |
|---|---|---|
| Ranger Guildmaster | 75–98 | `RangerGuildmaster.cs:22` |
| Druid Guildmaster | 80–100 | `DruidGuildmaster.cs:26` |
| Wandering Healer | 80–100 | `WanderingHealer.cs:39` |
| Merchant (base) | 65–88 | `Merchant.cs:27` |
| Provisioner | 65–88 | `Provisioner.cs:30` |
| Ranger | 65–88 | `Ranger.cs:23` — talks about camping in gump title "Camping Safely" |
| Druid | 80–100 | `Druid.cs:28` |
| Druid Tree | 80–100 | `DruidTree.cs:35` |
| Furtrader | 55–78 | `Furtrader.cs:28` |

All of these NPCs sell camping-related gear through their vendor stock (`Market.Ranger` / `Market.Supplies` categories).

## Related Skills

- [Tracking](tracking.md) — shares the 90+ requirement for Ranger Outpost housing and Golden Feathers drops.
- [Cooking](cooking.md) — campfires enable food cooking; Barbaric Talisman bonds them together (Camping + Cooking).
- [Taming](taming.md) / [Veterinary](veterinary.md) — Rangers and Druids (who have high Camping) also have Taming/Veterinary; the Hitching Post (100+ Camping) lets you stable pets at home without a stable master.
- [Hiding](hiding.md) / [Stealth](stealth.md) — all three skills are bonded for Assassin's Guild ring members. Safe camping requires no enemies nearby (`EnemiesNearby` check in `Kindling.cs:44-56`).
- [Search](searching.md) — Ranger NPCs stock Searching skill; campfires require line-of-sight placement checks.
- [Rangers Guild](../systems/guilds.md#rangers-guild) — Rangers Guild Ring gives +25 Camping.
