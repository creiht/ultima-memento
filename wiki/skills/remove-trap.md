# Remove Trap

Remove Trap allows you to disarm traps on containers and hidden floor traps.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Dexterity |
| Usage | Active (targeted) |
| Range | 2 tiles |
| Cooldown | 5 seconds |

## How It Works

Use the skill and target a trapped object.

### Trapped Containers (TrapableContainer)

For trapped containers, the difficulty is based on the trap level:

| Trap Level | Required Skill | Skill Check Max |
|---|---|---|
| 1 | 10 | 30 |
| 2 | 20 | 40 |
| 3 | 30 | 50 |
| 4 | 40 | 60 |
| 5 | 50 | 70 |

If your Remove Trap skill is below `TrapLevel * 10`, the trap "looks too complicated for you." On success, the trap is completely removed (type, level, and power all reset to zero). On failure, the trap remains but does **not** go off.

### Hidden Floor Traps (HiddenTrap)

Hidden traps found by [Searching](searching.md) can be disarmed with Remove Trap. The skill check is against 0-125. Light traps (weight < 5.0) can be disarmed; heavier ones cannot.

### Restrictions

- Cannot be used on mobiles.
- If the target is not trapped, you receive "That doesn't appear to be trapped."

## How to Train

Find trapped containers in dungeons and disarm them. The skill check scales with trap level, so you need progressively harder traps for gains at higher skill levels. Hidden floor traps provide a 0-125 check that works at any skill level.

## Related Skills

- [Searching](searching.md) - Detects hidden traps and doors.
- [Forensics](forensics.md) - Identifies who picked a lock.
