# Tactics

Tactics amplifies the damage of every melee and ranged attack, and is the gating skill for all weapon special ability tiers.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Strength |
| Usage | Passive (every swing) |
| Cooldown | None |

## How It Works

### Damage Multiplier

Tactics adds a flat damage scalar on top of Strength and weapon-skill contributions:

```
tacticsBonus = GetBonus(Tactics, 0.625, 100.0, 6.25)
```

| Tactics Skill | Bonus Damage |
|---|---|
| 50 | ~3.1 |
| 100 | 6.25 |
| 125 | ~7.8 |

### Weapon Ability Tier Gating

All five weapon ability tiers require the attacker to meet a **minimum Tactics value** alongside the relevant weapon skill. Both must equal or exceed the tier threshold before that ability slot unlocks. Several abilities also scale their effectiveness directly from Tactics:

- **Nerve Strike** — paralysis duration scales with Tactics.
- **Talon Strike** — bleed damage scales with Tactics.
- **Block** — parry bonus scales with Tactics.
- **Frenzied Whirlwind** — AoE radius/damage scales with Tactics.

See [Weapon Abilities](weapon-abilities.md) for the full tier threshold table.

## How to Train

Tactics gains passively on every swing with `checkSkills = true`. Fight regularly and it will rise alongside your weapon skill.

## Related Skills

- [Anatomy](anatomy.md) — also contributes to damage calculations.
- [Swordsmanship](swordsmanship.md), [Bludgeoning](bludgeoning.md), [Fencing](fencing.md), [Fist Fighting](fist-fighting.md), [Marksmanship](marksmanship.md) — each weapon skill pairs with Tactics.
- [Weapon Abilities](weapon-abilities.md) — full list of specials gated by Tactics tiers.
