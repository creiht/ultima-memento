# Healing

Healing allows you to mend your own wounds, cure poison, and stop bleeding without bandages or reagents.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Intelligence |
| Usage | Active (self-only) |
| Cooldown | 15 seconds (when healing), 1 second (when full health) |

## How It Works

Using the Healing skill on yourself has different effects depending on your current condition:

### Priority Order

1. **Cure Poison & Stop Bleeding** - If you are poisoned or bleeding, healing will cure the poison and/or stop the bleeding. Both conditions can be cured in a single use.
2. **Heal Hit Points** - If you are injured but not poisoned/bleeding, you heal a calculated amount of HP.
3. **Already Healthy** - If you are at full health, you receive the message "You already feel healthy."

### Heal Amount Formula

```
Base Amount = 2 + (Healing Skill / 5)
If skill > 100: Amount += 3 * (Skill - 100) / 5
```

| Healing Skill | Base Heal Amount |
|---|---|
| 50 | 12 |
| 100 | 22 |
| 125 | 37 |

On a **failed** skill check (checked against -50 to 99.9), the heal amount is reduced to **75%** of normal.

### Restrictions

- **Cannot heal while starving** (Hunger < 6).
- **Cannot heal under Mortal Strike** (the wound prevents healing).

## How to Train

Use the skill whenever you are injured. The skill check range is -50 to 99.9, meaning you can gain at any skill level as long as you have damage to heal.

## Related Skills

- [Anatomy](anatomy.md) - Evaluate targets' physical condition.
- [Spiritualism](spiritualism.md) - Alternative self-healing using spiritual energy.
