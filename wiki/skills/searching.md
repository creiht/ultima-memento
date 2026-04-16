# Searching

Searching (Detect Hidden) lets you reveal hidden players, uncover traps, find secret doors, and discover hidden treasure chests.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Intelligence |
| Usage | Active (targeted location) |
| Range | 12 tiles (targeting), variable detection range |
| Cooldown | 6 seconds |
| Skill Check | 0 - 125 |

## How It Works

Use the skill and target a location. Everything hidden within your detection range centered on that point is checked.

### Detection Range

```
Range = Searching Skill / 10
```

On a failed skill check, the range is **halved**. Inside a house where you are a Friend, the range is always **22 tiles**.

| Searching Skill | Range (Success) | Range (Failure) |
|---|---|---|
| 50 | 5 tiles | 2 tiles |
| 100 | 10 tiles | 5 tiles |
| 125 | 12 tiles | 6 tiles |

### What You Can Find

#### Hidden Players
Your Searching skill (+/- random 10) is compared against the target's [Hiding](hiding.md) skill (+/- random 10). If yours is higher, they are revealed. Party members are ignored.

#### Traps
Detects various trap types within range:
- Fire Column Traps, Flame Spurt Traps
- Poison Gas Traps, Giant Spike Traps
- Saw Blade Traps, Spike Traps
- Stone Face Traps, Odd Mushrooms
- Hidden Floor Traps (also marks them as discovered)
- Killer Tiles ("It's a trap! Death awaits.")

#### Hidden Doors
Secret doors within range are automatically opened when detected.

#### Hidden Chests
Hidden treasure chests can be uncovered. The quality of discovered chests depends on:
- `Searching Skill / 20` (max 6 levels)
- Plus area difficulty bonus (max 4 levels)
- Total level capped at 1-10

### Night Sight Bonus

Even if a normal skill check fails, the **Night Sight** equipment attribute provides an additional chance to spot traps and hidden objects in the dark.

Multiple items in range are checked, with the first `Searching Skill / 10` items getting a full skill check and the rest relying on passive detection only.

## How to Train

Use the skill in areas with hidden creatures, traps, or objects. Dungeons with traps are ideal. The skill check is 0-125, allowing gains at any level.

## Related Skills

- [Hiding](hiding.md) - The skill Searching contests against.
- [Remove Trap](remove-trap.md) - Disarm traps after finding them.
- [Tracking](tracking.md) - Locate creatures over longer range by type.
- [Stealth](stealth.md) - Move while hidden to avoid detection.
