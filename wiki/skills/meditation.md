# Meditation

Meditation allows you to enter a trance to regenerate mana at an increased rate.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Intelligence |
| Usage | Active |
| Cooldown | 10 seconds |
| Skill Check | 0 - 100 |

## How It Works

Using Meditation attempts to enter a meditative trance, which boosts your mana regeneration rate.

### Success Chance

```
Chance = (50 + (Skill - (Current Mana / Max Mana)) * 2) / 100
```

The lower your current mana relative to your max, the easier it is to meditate.

### Requirements

- You must not already be at full mana.
- **Armor interferes with meditation.** If you have too much armor, you receive the message "Regenerative forces cannot penetrate your armor!" Heavy armor prevents meditation entirely.
- You cannot meditate while targeting something.
- Items not compatible with meditation are automatically unequipped (moved to backpack).

### Compatible Held Items

The following items can be held while meditating:
- Spellbooks, Magic Rune Bags
- Tools and Harvest Tools
- Trinkets, Equippable Lights
- Weapons/Armor with the **Spell Channeling** property

### Using the Skill

On success, you enter a meditative trance (shown as a buff icon). A sound plays and your mana regeneration increases. On failure, "You cannot focus your concentration."

## How to Train

Use the skill whenever your mana is not full. The skill check is against 0-100. Having low mana makes success more likely, providing better training opportunities after casting spells.

## Related Skills

- [Psychology](psychology.md) - Evaluate intelligence and mana.
- [Spiritualism](spiritualism.md) - Restores HP/Stamina using mana or corpses.
