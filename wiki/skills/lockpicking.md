# Lockpicking

Lockpicking lets you open locked chests, coffers, and dungeon doors using lockpicks.

## Overview

| Property | Value |
|---|---|
| **Primary Stat** | Dexterity |
| **Usage** | Active |
| **Skill Type** | Physical |
| **Skill Check** | 0–125 |

## Description

Lockpicking allows you to open locked containers, dungeon doors, and sci-fi tech locks using lockpicks as a consumable tool. Difficulty scales with the lock level of the target, and failed attempts can break the lockpick.

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

## What It Affects

### Containers & Items

- `LockPick.cs:198,227` — `CheckTargetSkill(Lockpicking, item, LockLevel, MaxLockLevel)` is the core lock-picking check
- `LockPick.cs:86` — doors require **30+ Lockpicking** before any attempt is allowed
- `LockPick.cs:215` — if `(SkillValue + 2) < RequiredSkill`, the pick attempt is blocked entirely
- `LockableContainer.cs:332` — on success, `LockPick()` opens the container and triggers `TrapOnLockpick` traps
- `LockableContainer.cs:363,373` — **Tinkering** quality determines lock level when crafting lockable items: `level = (int)(tinkering * 0.8)`, then `LockLevel = level - 14`
- `PickableDoor.cs:57-59` — dungeon doors spawn with `LockLevel=80, MaxLockLevel=110, RequiredSkill=100`
- `PickBox.cs` — 5 training pickboxes (Easy 1→25, Normal 20→35, Difficult 30→45, Challenging 40→55, Hard 50→65); relock themselves after picking

### Technology & Sci-Fi

- `PowerGenerator.cs:329,368-375` — at **65+ Lockpicking**, a button appears to decipher circuit paths: check is `40 + random(0–80) < SkillValue`
- `LockPick.cs:132-135` — sci-fi containers with access card (`0x3A75`) use the same lockpicking timer
- `SkeltonsKey.cs:166` / `MasterSkeltonsKey.cs:168` / `MagicSkeltonsKey.cs:168` — skeleton/magic key cards can open tech locks (bypass skill check entirely, consumable)

### Special Systems

- `PuzzleGump.cs:76-368` — **Puzzle Chests** give lockpicking hints based on skill:
  - **60+**: hints section appears
  - **70+**: second cylinder hint added
  - **80+**: first slot cylinder revealed + "used in unknown slot" hint
  - **90+**: second hint cylinder shown
  - **100+**: third hint cylinder shown
- `TreasureMapChest.cs:148` — on Level 0 treasure map chests, `LockPick()` is called automatically via `CheckLocked()`; failure destroys a random item (or 1,000 gold) as dust
- `LockPick.cs:191-199` — **bootstrap**: if `SkillBase < 1`, 10 rapid `CheckTargetSkill` checks fire in quick succession

### Consumables & Alternatives

- `BottleOfAcid.cs:133` — acid bypasses locks where `RequiredSkill <= 100`; also converts magic locks (`LockLevel == -255`) to regular ones
- `BottleOfAcid.cs:128` — acid has **no effect** on Treasure Map Chests
- `Elixirs.cs:2611-2689` — **Elixir of Lockpicking** adds a temporary skill mod via `DefaultSkillMod`; crafted by Alchemy (`DefAlchemy.cs:309`): requires 60–120 Alchemy + Butterfly Wings
- `ResearchConjure.cs:64` — **Research** magic can conjure a lockpick (case 19 of the conjure list)

### Player Commands

- `Skills.cs:67` — `[help lockpicking]` description text
- `SkillName.cs:53` — command shortcut: `[skipl 1]` or `lockpicking` in skill listing

## Related Systems & Skills

### Synergies
- [Tinkering](../crafting/tinkering.md): Crafts lockpicks and determines lock levels on crafted containers.
- [Stealing](stealing.md): Both are rogue/thief skills; key cards often appear as thief loot.
- [Alchemy](../crafting/alchemy.md): Creates the Elixir of Lockpicking.
- [Research](../magic/research.md): Conjuration can produce lockpicks.

### Prerequisites / Co-requisites
- [Remove Trap](remove-trap.md): Chests are often both locked and trapped; disarm before you pick.
- [Lockpick](../items/lockpick.md): Consumable tool required for all lockpicking attempts.

## Notes

- Doors require 30+ Lockpicking before any attempt is allowed.
- Every failed attempt has a 25% chance to break the lockpick.
- Failing on Treasure Map Chests destroys random items from the chest's contents — raise your skill first.
- Bottstrap mechanic: if base Lockpicking is 0, 10 rapid checks fire to help get past the initial hurdle.
- Acid bottles bypass most locks but have no effect on Treasure Map Chests.
