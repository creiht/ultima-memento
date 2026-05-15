# Tracking

Tracking lets you locate creatures and players within a wide area by selecting from a detailed category list, then following them with a quest arrow.

## Overview

| Property | Value |
|---|---|
| **Primary Stat** | Intelligence |
| **Usage** | Active |
| **Skill Type** | Utility / Navigation |
| **Skill Check** | 0-21.1 initial, passive 21.1-100 on use |

## Description

Tracking allows you to search for creatures and players across the game world. You select a category, view matching targets within range, and lock onto one with a quest arrow. Tracking also provides a stalking bonus to your next attack against a moving target.

## How It Works

### Tracking Process

1. Use the skill to open the **Track What** gump.
2. Select a creature category (or subcategory).
3. A list of matching creatures within range is displayed, sorted by distance.
4. Select a specific target to begin tracking with a **quest arrow** pointing to them.

### Tracking Range

```
Range = 25 + (Tracking Skill / 2)
```

| Tracking Skill | Range |
|---|---|
| 50 | 50 tiles |
| 100 | 75 tiles |
| 125 | 87 tiles |

### Creature Categories

| Category | Subcategories |
|---|---|
| Abysmal | Daemons, Devils, Gargoyles |
| Animals | - |
| Arachnids | Arachnoids, Scorpions, Spiders |
| Avians | - |
| Elementals | - |
| Fey | - |
| Giants | - |
| Golems | - |
| Humanoids | Ogres, Orcs, People, Players, Trolls |
| Monsters (General) | - |
| Others | Unclassified creatures |
| Plants | - |
| Reptiles | Dragons, Lizardmen, Serpentoids, Snakes |
| Sea | - |
| Slimy | - |
| Supernatural | - |
| Wizards | - |

### Tracking Hidden Players

Tracking can detect hidden players. The check uses:

```
Chance = 50 * (Tracking * 2 + Searching) / (target Hiding + target Stealth)
```

[Necromancy](../magic/necromancy.md) transformations also affect detection:
- **Horrific Beast:** Easier to track (-200 from hiding+stealth)
- **Vampiric Embrace:** Harder to track (sets minimum hiding+stealth to 500)
- **Wraith Form:** Harder to track (+200 to hiding+stealth)

### Hidden Sea Creatures

Tracking also detects hidden sea monsters (WhisperHue 666 or 999) that would not normally be visible.

### Stalking Bonus

After tracking a target, if they move, you receive a **stalking bonus** to your next attack. The bonus is `2 * distance the target moved` from where you first located them (capped at `10 + Tracking/10` in ML era).

### Location Restrictions

Tracker and target must be in the same land area (both in the major world, or both in the same cave/dungeon) for tracking to work.

## How to Train

Use the skill and select creature types. The initial skill check is against 0-21.1, and passive gains occur from 21.1-100 when selecting from the tracking results.

## What It Affects

### Items
- `MapRanger.cs:79` — **Trail Maps**: require **80 Tracking** (or 80 Cartography) to use. Teleport the player to discovered locations, consume one charge per use.
- `GoldenFeathers.cs:54` — **Golden Feathers**: killing Harpies and Phoenixes awards feathers only if killer has **90 Tracking** (or 90 Camping) and carries a Golden Ranger item.
- `MagicForges.cs:744` — **Altar of Golden Rangers / Ranger Outpost forges**: enchant armor, weapons, and clothing with Gilded Spec resource only if player has **90 Tracking** (or 90 Camping) and carries a Golden Feather.

### Regions & Housing
- `OutDoorRegion.cs:23` — **Ranger Outpost**: requires **90 Tracking** (or 90 Camping) to build housing.

## Related Systems & Skills

### Synergies
- [Searching](searching.md): Assists tracking checks against hidden targets. Formula: `Chance = 50 * (Tracking * 2 + Searching) / (target Hiding + target Stealth)`.

### Prerequisites / Co-requisites
- [Hiding](hiding.md) / [Stealth](stealth.md): The skills tracked targets use to avoid detection. Higher values make players/creatures harder to find.
- [Camping](camping.md): Alternative to Tracking for Ranger Outpost housing access (90), Golden Feather drops, and Golden Rangers enchanting.
- [Cartography](../crafting/cartography.md): Alternative to Tracking for using MapRanger trail maps (80).

## Notes
- Stalking bonus only applies to the **next attack** after tracking — plan accordingly.
- Location restrictions mean you cannot track creatures/dungeons from the overworld (and vice versa).
- Tracking hidden players is a race between your (Tracking + Searching) and their (Hiding + Stealth).
