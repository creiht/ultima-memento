# Spiritualism

Spiritualism (Spirit Speak) lets you channel spiritual energy to heal yourself, restore stamina, and communicate with the dead.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Intelligence |
| Usage | Active |
| Cooldown | 5 seconds |
| Mana Cost | 10 (without corpse), 0 (with nearby corpse) |

## How It Works

Spiritualism has two modes depending on whether a nearby corpse is available.

### With a Nearby Corpse (within 3 tiles)

If an unchanneled, non-animated corpse is nearby, you draw energy from it:
- The corpse turns grey (hue 0x835) and is marked as channeled.
- You **heal HP** and **restore Stamina** by a random amount.
- You also **gain 25% of the roll as Mana**.
- **No mana cost.**

### Without a Corpse

You channel your own spiritual energy:
- Costs **10 mana**.
- You **heal HP** and **restore Stamina** by a random amount.

### Heal Formula

```
Min = 1 + (Spiritualism Skill * 0.25) + (Fist Fighting Skill * 0.15)
Max = Min + 4
```

Both min and max are further modified by the player level system (`PlayerLevelMod`).

### Success Chance

```
Success Rate = Spiritualism Skill / 100
```

At 100 skill you always succeed; at 50 skill you succeed 50% of the time.

### Mantras and Effects

Your character speaks a mantra when channeling:
- **Positive karma:** "Anh Mi Sah Ko" (with a gentle sound and golden particles)
- **Negative karma:** "Xtee Mee Glau" (with a harsh sound and dark particles)

### Hear Ghosts (Legacy Mode)

In non-AOS mode, successful use grants the ability to **hear ghosts** (dead players' speech) for a duration based on skill: `(Skill / 50) * 90` seconds (minimum 15 seconds, maximum ~3 minutes).

### Restrictions

- Cannot use while poisoned.
- Cannot use while starving (Hunger < 1) or dying of thirst (Thirst < 1).
- Must have enough mana (10) when no corpse is available.

## How to Train

Use the skill regularly, ideally near corpses to avoid the mana cost. The skill check is 0-120 for gains.

## Related Skills

- [Healing](healing.md) - Alternative self-healing that cures poison/bleeding.
- [Meditation](meditation.md) - Mana regeneration.
