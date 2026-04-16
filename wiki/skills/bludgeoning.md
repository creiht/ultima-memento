# Bludgeoning

Bludgeoning is the hit skill for all blunt weapons — clubs, maces, war hammers, and other bashing weapons. It also receives a unique Mining damage bonus.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Strength |
| Usage | Passive (every bashing swing) |
| Cooldown | None |

## How It Works

### Weapons That Use Bludgeoning

All weapons of `WeaponType.Bashing` declare `DefSkill = Bludgeoning`. This includes clubs, maces, war hammers, mauls, and similar blunt weapons.

### Hit Chance

Hit chance is resolved identically to Swordsmanship — the attacker's Bludgeoning versus the defender's active defence skill. Tactics and Strength contribute damage separately.

### Mining Damage Bonus

Bludgeoning weapons receive a unique bonus that other weapon skills do not:

```
miningBonus = GetBonus(Mining, 0.20, 100.0, 10.0)
```

This bonus is added during `ScaleDamageAOS`. Characters who also train [Mining](../crafting/mining.md) deal extra damage with bludgeoning weapons.

### Player Title

At Grandmaster level the player title is **"Bludgeoner"**. In some NPC social contexts this may display as "Man-at-arms" depending on alignment.

## How to Train

Attack with any bashing weapon. Bludgeoning gains passively on every swing.

## Related Skills

- [Tactics](tactics.md) — damage amplifier and weapon ability tier gate.
- Mining ([crafting](../crafting/mining.md)) — contributes a passive damage bonus to all bashing weapons.
- [Weapon Abilities](weapon-abilities.md) — special moves available on bashing weapons.
