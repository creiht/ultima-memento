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

## Related Skills

- [Tracking](tracking.md) — shares the Ranger Outpost placement requirement (90+ Camping).
