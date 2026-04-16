# Peacemaking

Peacemaking uses soothing music to calm hostile creatures, forcing them to stop attacking.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Intelligence |
| Usage | Active (targeted, requires instrument) |
| Cooldown | 5-10 seconds |

## How It Works

1. Use the skill to select an instrument.
2. Choose a target - either **yourself** for area-of-effect calming, or a **single creature** for targeted pacification.

### Area Peacemaking (Target Self)

Targets all hostile creatures within bard range. Each creature gets an individual difficulty check. If a creature's check fails, there is a 50% chance your entire song stops. Successful targets are pacified for `Musicianship / 10` seconds.

Some creatures are immune to area peacemaking (AreaPeaceImmune flag).

### Targeted Peacemaking (Target Creature)

Pacifies a single creature for a longer duration:

```
Duration = 100 - (difficulty / 1.5) seconds
(minimum 10, maximum 120 seconds)
```

### Against Players

Targeted peacemaking against players is possible. If the target's Magic Resist check fails, they are **paralyzed** for the calculated duration (with a Peacemaking buff icon).

### Musicianship Bonus

Musicianship above 100 reduces the difficulty by `(Musicianship - 100) * 0.5`.

### Minimum Skill Requirement

The game tells you the minimum Peacemaking skill needed to attempt a target: `difficulty - 25`.

### Restrictions

- Cannot calm Uncalmable creatures.
- Cannot calm an already-pacified creature.
- A Musicianship check must pass before the Peacemaking check.
- Instrument uses are consumed on each attempt.

## How to Train

Target progressively harder creatures. Area peacemaking (targeting yourself) is good for training on groups but riskier. Single-target mode gives longer pacification.

## Related Skills

- [Discordance](discordance.md) - Weakens targets instead of pacifying.
- [Provocation](provocation.md) - Turns creatures against each other.
- [Begging](begging.md) - Can also pacify creatures without an instrument.
