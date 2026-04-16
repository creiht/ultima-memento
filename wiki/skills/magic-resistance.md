# Magic Resistance

Magic Resistance is a passive skill that gives you a chance to reduce or completely ignore the debuff component of hostile spells.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Intelligence |
| Usage | Passive (automatic on spell receipt) |
| Cooldown | None |

## How It Works

### Spell Resist Formula

Every hostile spell from Magery, Elementalism, Jedi, or Syth calls `CheckResisted()` using two competing percentages:

```
firstPercent  = MagicResist / 5.0
secondPercent = MagicResist - ((CasterSkill - 20) / 5) - (1 + circle) * 5
resistChance  = max(firstPercent, secondPercent) / 2.0
```

A successful resist **cancels the debuff or effect** but does not reduce direct damage. The second formula is suppressed at high spell circles, ensuring higher-level spells remain threatening even against skilled resisters.

### Bard Skill Resist

Resist also protects against bard skills:

- **Discordance** on players: `MagicResist > RandomMinMax(0, 125)` cancels the debuff.
- **Peacemaking** on NPCs: same formula.

### Passive Training Threshold

A gain check fires when an incoming spell circle satisfies:

```
MagicResist < (1 + circle) * 10
```

This means higher-circle spells keep triggering gains at higher skill levels.

## How to Train

Stand in low-risk situations where hostile spellcasters target you with mid-to-high circle spells. Each incoming spell whose circle threshold exceeds your current skill fires a gain check automatically — no action required on your part.

## Related Skills

- [Meditation](meditation.md) — mana regeneration; pairs well for magic-focused characters.
- [Psychology](psychology.md) — evaluating caster skill levels to predict resist chance.
