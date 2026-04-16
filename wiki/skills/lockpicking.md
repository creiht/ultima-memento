# Lockpicking

Lockpicking lets you open locked chests, coffers, and dungeon doors using lockpicks.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Dexterity |
| Usage | Active |
| Cooldown | None |

## How It Works

Double-click a *Lockpick*, then target any locked container (`ILockpickable`) or dungeon/sci-fi door.

### Lock Level

| LockLevel | Result |
|---|---|
| 0 | No lock — opens freely |
| −255 | Magic lock — **unpickable** by this skill |
| 1–100+ | `CheckTargetSkill(Lockpicking, item, LockLevel, MaxLockLevel)` |

Doors require **30+ Lockpicking** before any attempt is allowed.

### Lockpick Breakage

Every failed attempt has a **25% chance to break the lockpick**. Keep a stack on hand.

### Treasure Map Chests

Failing on a *Treasure Map Chest* carries an additional penalty: each failed attempt **destroys one random item** (or 1,000 gold) from the chest's contents, replacing it with dust. Open these carefully or raise your skill before attempting.

### Bootstrapping

If your base Lockpicking is 0, the first attempts trigger **10 rapid checks** in quick succession to help get started past the initial hurdle.

## How to Train

Attempt to pick locks repeatedly. Gain fires passively on each attempt, whether or not you succeed.

## Related Skills

- [Remove Trap](remove-trap.md) — chests are often both locked and trapped; disarm before you pick.
- Tinkering (`../crafting/tinkering.md`) — crafts lockpicks.
