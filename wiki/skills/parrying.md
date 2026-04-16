# Parrying

Parrying allows you to raise your shield to absorb incoming melee and magic damage for a short duration.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Dexterity |
| Usage | Active (requires shield) |
| Duration | 5 seconds |

## How It Works

Using Parry with a shield equipped grants you temporary **melee and magic damage absorption**. The absorbed amount is based on your Parry skill and Dexterity.

### Absorption Formula

```
Base Value = Parry Skill / 3
```

If your Parry skill is below 125 **or** your Dexterity is below 80, a penalty is applied:

```
Value = Base Value * (Dexterity / 80)
```

The final amount (minimum 1) is added to both your `MagicDamageAbsorb` and `MeleeDamageAbsorb` pools.

| Parry Skill | Dex 80+ Absorb | Dex 40 Absorb |
|---|---|---|
| 60 | 20 | 10 |
| 90 | 30 | 15 |
| 125 | 42 | 21 |

### Duration

The absorption buff lasts **5 seconds**. After that, any remaining absorb points are removed and you "relax your stance."

### Requirements

- You **must** have a shield equipped (Layer.TwoHanded BaseShield).
- Parrying is a revealing action (breaks hiding).
- Using the skill provides a passive skill gain check against 0.5 difficulty.

## How to Train

Use the skill with a shield equipped. The passive gain check uses a 50% success threshold, so gains are relatively steady. Combat scenarios where you actually take hits while the buff is active help maximize utility.

## Related Skills

- [Hiding](hiding.md) - Note that Parrying reveals you.
- [Weapon Abilities](weapon-abilities.md) - Block and Defense Mastery are shield-related weapon abilities.
