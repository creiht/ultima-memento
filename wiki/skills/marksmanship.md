# Marksmanship

Marksmanship is the hit skill for all ranged weapons including bows, crossbows, throwing gloves, harpoons, and sci-fi firearms.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Dexterity |
| Usage | Passive (every ranged attack) |
| Cooldown | None |

## How It Works

### Weapons That Use Marksmanship

Marksmanship is declared as both `DefSkill` (defence reference skill) and `AccuracySkill` (hit-chance skill) on each of the following weapon families:

- All bows and crossbows (`BaseRanged`)
- Harpoon
- Throwing Gloves and Monster Gloves
- Wizard Staff (ranged mode)
- Kilrathi sci-fi ranged weapons (`BaseKilrathi`)

### Hit Chance

Hit chance is calculated using the attacker's Marksmanship versus the defender's active defence skill using the standard `BaseWeapon` formula. Tactics and Strength contribute to damage separately; Dexterity affects swing speed and stamina cost.

### Skill Gain and Ability Resolution

Ranged skill gain fires on every attack with `checkSkills = true`. All weapon special ability tier thresholds for ranged weapons check Marksmanship alongside Tactics.

### Harpoon Synergy

When using the Harpoon, Marksmanship governs hit chance while Seafaring provides an additional damage bonus. See [Seafaring](seafaring.md) for the formula.

## How to Train

Attack with any ranged weapon. Marksmanship gains passively on every shot.

## Related Skills

- [Tactics](tactics.md) — amplifies ranged damage and gates weapon ability tiers.
- [Seafaring](seafaring.md) — provides Harpoon damage bonus on top of Marksmanship hit chance.
- [Weapon Abilities](weapon-abilities.md) — special moves available on ranged weapons.
