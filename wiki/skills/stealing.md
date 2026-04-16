# Stealing

Stealing lets you pilfer items from containers, coffers, dungeon chests, and the backpacks of other creatures and players.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Dexterity |
| Usage | Active (targeted) |
| Range | 1 tile |
| Max Item Weight | 10 stones |

## How It Works

Use the skill and target an item, container, or creature. You must be **empty-handed** (no weapon wielded, though pugilist gloves are allowed).

### Stealing from Creatures/Players

Target a creature to attempt to steal a random item from their backpack. Target a specific item to steal that item directly. Items that are equipped, blessed, or newbied cannot be stolen. Containers cannot be stolen.

The difficulty is based on **item weight**:

```
Difficulty = (Item Weight * 10) +/- ~25
```

For stackable items, you steal a portion based on skill: `Max Amount = (Skill / 10) / Item Weight`.

### Stolen Item Timer

Stolen items are tracked for **2 minutes**. If you die while carrying a stolen item, it is returned to the victim.

### Stealing from Coffers

Target a coffer to steal gold from it. Success gives you all the gold in the coffer. Failure may reveal you, and nearby vendors may shout "Stop! Thief!" (with a [Snooping](snooping.md) check to avoid being spotted).

### Stealing Dungeon Chests

Target a dungeon chest to steal the entire container. On success, you receive a copy of the chest with its contents value. The original chest is replaced with a new spawn. On failure, the chest may be destroyed.

### Stealable Artifacts

Certain rare artifacts in the world can be stolen. Requires **100 Stealing skill** and membership in the **Thieves' Guild**. Each artifact can only be stolen once per character.

### Getting Caught

```
Caught Chance = Skill < Random(150)
```

At 100 skill you have roughly a 33% chance of being noticed. If caught stealing from a player, witnesses within 8 tiles are notified, your disguise is removed, and you may be flagged criminal. You are only **revealed from hiding on failure or when caught**, not on every attempt.

### Restrictions

- Must be empty-handed (no weapons).
- Must be within 1 tile of the target.
- Need Thieves' Guild membership to steal from innocent players.
- Cannot steal from shopkeepers or player vendors.
- Cannot steal while in a blessed state.
- Causes karma loss (-60 for item theft, variable for coffers).

## How to Train

Steal from dungeon chests and coffers. The difficulty scales with item weight, so lighter items are easier. Stealing from coffers uses a 0-100 check.

## Related Skills

- [Snooping](snooping.md) - See what's in a target's backpack before stealing.
- [Hiding](hiding.md) - Stay hidden while stealing.
- [Stealth](stealth.md) - Move silently to approach targets.
