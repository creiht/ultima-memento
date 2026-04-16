# Focus

Focus is a passive regeneration skill that accelerates both stamina and mana recovery. It is also one of the three prerequisites for the Mystic (Monk) magic specialization. The character title for this skill is **"Driven"**.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Intelligence |
| Usage | Passive (regen ticks) |
| Cooldown | None |

## How It Works

### Stamina Regeneration

Each regen tick adds a bonus based on Focus:

```
Stam regen bonus = Focus * 0.1
```

At 100 Focus this is **+10 stamina per regen tick**.

### Mana Regeneration

Focus also contributes a smaller mana regen bonus:

```
Mana regen bonus = Focus * 0.05
```

Unlike [Meditation](meditation.md), this bonus is **not blocked by wearing armor**. It applies at all times regardless of equipment.

| Focus Skill | Stam Regen Bonus | Mana Regen Bonus |
|---|---|---|
| 50 | +5.0 | +2.5 |
| 100 | +10.0 | +5.0 |
| 125 | +12.5 | +6.25 |

### Mystic (Monk) Prerequisite

**100 base Focus** is required (alongside 100 base Meditation, 100 base Fist Fighting, and a MysticMonkRobe) to qualify as a Monk and equip a Mystic Spellbook. See [Fist Fighting](fist-fighting.md) for the full prerequisite list.

### Magical Items

Focus is also used as both cast and damage skill by the minor `MagicalSpell` class, which some magic items invoke.

## How to Train

Focus gains passively — each stamina and mana regen tick calls `CheckBonusSkill` automatically. Simply existing and regenerating resources will raise Focus over time. Wearing armor does not interrupt this.

## Related Skills

- [Meditation](meditation.md) — the other co-requisite for Monk status; provides larger active mana regen.
- [Fist Fighting](fist-fighting.md) — the primary Monk combat and spell skill.
- Mystic magic: [wiki/magic/mystic.md](../magic/mystic.md).
