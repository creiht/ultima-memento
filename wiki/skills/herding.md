# Herding

Herding lets you direct tamable animals with a shepherd's crook, assists with pet loyalty control, and amplifies pet experience gain.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Strength |
| Usage | Active (Shepherd's Crook) + Passive (pet checks) |
| Cooldown | None |

## How It Works

### Moving Animals

Double-click a *Shepherd's Crook*, target a tamable (non-paragon) creature, then target a destination tile. The skill check uses:

```
CheckTargetSkill(Herding, creature,
    MinTameSkill - 30,
    MinTameSkill + 30 + rand(0, 10))
```

Higher taming-difficulty creatures are harder to herd.

### Pet Loyalty Assist

Inside `BaseCreature.CheckControlChance()`, Herding fires a passive loyalty save:

- On roughly **15% of successful control checks**, a Herding gain check fires.
- On **loyalty failure**, the server rolls `CheckSkill(Herding, MinTameSkill-25, MinTameSkill+25)` — a success prevents the loyalty drop.

### Pet XP Multiplier

Pet experience earned is multiplied by up to:

```
Pet XP × (1 + Herding / 500)
```

At 100 Herding this is a **+20% bonus**; at the 125 cap it reaches **+25%**.

### Beastmaster Title

Reaching the following combined thresholds simultaneously unlocks the **Beastmaster** player title:

| Tier | Required Skill Level (Herding + Veterinary + Druidism + Taming) |
|---|---|
| Tier 1 | All four skills ≥ 60 |
| Tier 2 | All four skills ≥ 90 |
| Tier 3 | All four skills ≥ 120 |

## How to Train

Use a Shepherd's Crook on tamable creatures. Herding also gains passively during pet control and loyalty events when you have a pet out.

## Related Skills

- [Taming](taming.md) — primary skill for bonding with and controlling pets.
- [Veterinary](veterinary.md) — healing/resurrection for animals; shares the Beastmaster gate.
- [Druidism](druidism.md) — animal knowledge skill; also required for the Beastmaster title and pet resurrection.
- Druidism magic system: [wiki/magic/druidism.md](../magic/druidism.md).
