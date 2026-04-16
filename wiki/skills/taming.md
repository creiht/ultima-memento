# Taming

Taming lets you domesticate wild creatures so they serve you as loyal pets and combat companions.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Strength |
| Usage | Active (targeted) |
| Range | 3 tiles (targeting), 6 tiles (during taming) |
| Taming Duration | 3-4 ticks, 3 seconds each (9-12 seconds total) |

## How It Works

1. Use the skill and target a tameable creature.
2. Your character speaks soothing phrases for several rounds.
3. After the taming attempts complete, a final skill check determines success.

### Skill Requirements

Each creature has a **Minimum Tame Skill** (`MinTameSkill`). You must meet or exceed this value. Creatures already owned by you are much easier to re-tame.

### Taming Difficulty

```
Required Skill = MinTameSkill + (Previous Owners * 6) + 24.9
Druidism Bonus: reduces min check by (Druidism Skill / 5)
```

### Taming Effects on Stats

When a creature is tamed for the **first time**, it suffers stat penalties:
- **Skills reduced to 90%** of original (86% if the creature was paralyzed during taming)
- Creatures with `StatLossAfterTame` also lose **25% of their stats**

### Follower Slots

Each tamed creature requires follower slots. You cannot tame a creature if it would exceed your maximum followers.

### Dark Wolf Familiar

Having a Dark Wolf Familiar active grants automatic mastery over wolf-type creatures (Worg, Dire Wolf, Grey Wolf, Timber Wolf, White Wolf, Mystical Fox).

### Conditions That Interrupt Taming

- Moving more than 6 tiles away
- Losing line of sight or path access
- The creature taking damage
- The creature dying or becoming untameable
- Someone else already taming the creature

### Subduing

Some creatures must be **subdued** (reduced below 10% health) before they can be tamed.

### Max Owners

Creatures have a maximum number of previous owners. If the limit is reached, the creature is "too upset" to be tamed by a new owner.

### Angering the Creature

There is a 95% chance that an untamed creature with `CanAngerOnTame` will become hostile when you attempt to tame it, attacking you and potentially breaking pacification.

### Successful Tame

On success:
- The creature becomes your controlled pet
- It loses all fame and karma
- Its fight mode changes to Aggressor
- It starts at Level 1 and is unbonded

## How to Train

Tame progressively harder creatures. Re-taming already-owned creatures gives no skill gain ("That wasn't even challenging"). [Druidism](druidism.md) gains passively during the taming process.

## Related Skills

- [Druidism](druidism.md) - Examine and improve tamed pets; gains passively during taming.
- [Healing](healing.md) - Keep your pets alive.
