# Veterinary

Veterinary is the healing and resurrection skill for animals and monsters. It mirrors the relationship between Healing and Anatomy, but for creatures.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Intelligence |
| Usage | Active (bandage on animal/monster) |
| Cooldown | Bandage timer |

## How It Works

### Bandaging Animals and Monsters

Apply bandages to any non-player creature that is classified as a monster or animal. The server uses **Veterinary as primary skill** and **Druidism as secondary skill** for the heal check — exactly mirroring how Healing uses Anatomy for players.

### Pet Resurrection

Dead pets can be brought back to life with bandages when **both** of the following conditions are met:

- **Veterinary ≥ 80**
- **Druidism ≥ 80**

Both must be satisfied simultaneously. Meeting one threshold alone is not enough.

### Druidism Spell Scaling

Several Druidism spells scale their power from Veterinary:

- **Lurestone Spell** — effect radius or potency × `Vet / 100`.
- **Treefellow Spell** — summoned companion quality × `Vet / 100`.

### Herbalist Shoppe

The range of stock available from the Herbalist Shoppe scales with:

```
Stock level = (Druidism skill + Veterinary skill) / 2
```

### Egg Hatch Quality

Dragon and alien eggs hatch at a quality level that scales with Veterinary.

### Beastmaster Title

Hitting combined thresholds of 60/90/120 across **Herding, Veterinary, Druidism, and Taming** simultaneously unlocks three tiers of the **Beastmaster** player title. See [Herding](herding.md) for the full table.

## How to Train

Apply bandages to injured animals and monsters. Gain fires passively on each application.

## Related Skills

- [Druidism](druidism.md) — animal knowledge; co-requisite for pet resurrection and Beastmaster title.
- Druidism magic system: [wiki/magic/druidism.md](../magic/druidism.md).
- [Taming](taming.md) — bond with pets; required for the Beastmaster title.
- [Herding](herding.md) — move and assist pets; shares the Beastmaster gate.
