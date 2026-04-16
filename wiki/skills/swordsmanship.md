# Swordsmanship

Swordsmanship is the hit skill for bladed melee weapons and the default fallback weapon skill. It also serves as the damage and aggro skill for the Jedi and Syth magic systems.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Strength |
| Usage | Passive (every swing / every Jedi or Syth cast) |
| Cooldown | None |

## How It Works

### Weapons That Use Swordsmanship

Any weapon that does not explicitly declare a different `DefSkill` falls back to Swordsmanship. This covers long swords, katanas, Viking swords, broadswords, scimitars, and many other bladed weapons.

### Hit Chance

Hit chance for both the attacker and the defender is resolved using `GetUsedSkill()` on each side. Tactics and Strength contribute damage; Dexterity affects swing speed.

### Jedi and Syth Magic

Swordsmanship is the **damage skill** for both the Jedi and Syth magic systems:

- Spell damage scales from Swordsmanship value.
- Aggro generation = `Tactics + Swordsmanship`.
- **Minimum requirements to use any Jedi or Syth spell:** 10 Swordsmanship + 10 Tactics + 10 Psychology.

See [Jedi](../magic/jedi.md) and [Syth](../magic/syth.md) for full spell lists.

## How to Train

Swordsmanship gains passively on every swing with a sword-type weapon. Casting Jedi/Syth spells also triggers gain checks.

## Related Skills

- [Tactics](tactics.md) — damage amplifier; required for weapon ability tiers and Jedi/Syth threshold.
- [Parrying](parrying.md) — defensive complement to any weapon skill.
- [Psychology](psychology.md) — third prerequisite for Jedi/Syth casting.
- Jedi magic: [wiki/magic/jedi.md](../magic/jedi.md).
- Syth magic: [wiki/magic/syth.md](../magic/syth.md).
