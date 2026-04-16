# Stealth

Stealth lets you move silently while hidden, taking a limited number of steps before being revealed.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Dexterity |
| Usage | Active (while hidden) |
| Cooldown | 2 seconds |
| Minimum Hiding Skill | 30 |

## How It Works

You must be [hidden](hiding.md) before you can activate Stealth. Using the skill performs an armor check and a skill check. On success, you can move a number of steps while remaining invisible.

### Steps Allowed

```
Steps = Stealth Skill / 5
```

| Stealth Skill | Steps |
|---|---|
| 25 | 5 |
| 50 | 10 |
| 75 | 15 |
| 100 | 20 |
| 125 | 25 |

### Armor Restriction

Your total armor rating is compared against your Stealth skill:

```
Armor Check: (ArmorRating - Stealth/5) must be <= 50
```

If your armor is too heavy, "You could not hope to move quietly wearing this much armor." The Stealth skill check difficulty also scales with your armor rating.

### Minimum Hiding Requirements

| Era | Minimum Hiding Skill |
|---|---|
| ML | 30 |
| SE | 50 |
| Pre-SE | 80 |

Below the minimum, you get: "You are not hidden well enough. Become better at hiding."

### Auto-Stealth from Hiding

At **100+ Hiding skill**, successfully hiding will automatically attempt Stealth without requiring a separate skill use.

### Failure

On failure, you are revealed and "You fail in your attempt to move unnoticed." Player-activated stealth attempts reveal you on failure; auto-stealth from hiding does not.

## How to Train

Hide first, then use Stealth. The difficulty scales with your armor rating, so wearing lighter armor makes training easier. Gain skill by making successful and failed attempts.

## Related Skills

- [Hiding](hiding.md) - Must be hidden first before using Stealth.
- [Searching](searching.md) - Used to detect stealthed players.
- [Tracking](tracking.md) - Tracking difficulty factors in a target's Stealth skill.
