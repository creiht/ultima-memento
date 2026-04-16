# Musicianship

Musicianship is the foundation of all bardic skills and the Bard (Song) magic system. Every bard action passes through a Musicianship check before it can succeed.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Dexterity |
| Usage | Passive (checked on every bard action) |
| Cooldown | None |

## How It Works

### Instrument Check

`BaseInstrument.CheckMusicianship(from)` is called at the start of every Discordance, Peacemaking, and Provocation attempt:

```
success = (Musicianship / 100) > RandomDouble()
```

A **failure fizzles the entire bard action** — the instrument use is consumed but has no effect.

### Difficulty Reduction

Each point of Musicianship **above 100** reduces the target difficulty of bard skills by **0.5**. At 125 Musicianship this is a −12.5 reduction on the effective difficulty range.

### Peacemaking Duration

The duration of an area-Peacemaking effect scales directly:

```
Duration = Musicianship / 10 seconds
```

### SongBook (Bard Magic)

Musicianship is both the **casting skill** and **damage skill** for all spells in the Bard magic system:

- Equipping a *SongBook* requires **30+ base Musicianship**.
- Spell power and success rate scale with Musicianship throughout the song table.
- See [Bard magic](../magic/bard.md) for the full song list.

## How to Train

Double-clicking an instrument fires a `CheckSkill(Musicianship, 0.0, 120.0)` check. Every Discordance, Peacemaking, and Provocation attempt also contributes. Equip an instrument and play regularly.

## Related Skills

- [Discordance](discordance.md) — lowers a target's resistances and skills.
- [Peacemaking](peacemaking.md) — pacifies hostile creatures.
- [Provocation](provocation.md) — incites one creature to attack another.
- Bard songs (magic system): [wiki/magic/bard.md](../magic/bard.md).
