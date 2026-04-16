# Chest Containers

Lockable chests are the main non-creature source of loot. They use the [treasure pack](treasure-packs.md) system, with chest level determining which tiers are eligible.

**Source:** `World/Source/Scripts/Items/Containers/ContainerFunctions.cs`

[Back to Loot Tables](README.md)

---

## Chest Level System

Chest levels range from **1 to 12**. Higher levels map to higher treasure tiers and more fill cycles.

### Trap and Lock

`ContainerFunctions.LockTheContainer()` applies:
- **Trap type**: Randomly selected (Dart Trap, Explosion Trap, Magic Trap, Poison Trap, or None). TreasureMapChests always get Explosion Trap.
- **Trap power**: `level × (20–30) + 1–10`
- **Lock level**: `1 + level × 10` (cap 90); required skill = lock level; +20 for max lock level
- **TreasureMapChests and ParagonChests are always locked.**

### Fill Logic

`FillTheContainer(level, box, opener)` runs:
1. **Gold**: `AddGoldToContainer(0, box, opener, level)` — amount scales with level
2. **Treasure items**: `GenerateTreasure(level, box, opener)` loops `FillCycle(level)` times

`FillCycle(level)` returns `level/2` to `level/2 + 2` (minimum 1), so:
- Level 1 → 1–3 fill iterations
- Level 6 → 3–5 fill iterations
- Level 12 → 6–8 fill iterations

Each fill iteration rolls a pack based on `Utility.RandomMinMax(max(1, level−4), level)`:

| Roll | Pack selected |
|------|--------------|
| 1 | [TPoor](treasure-packs.md#tpoor) |
| 2 | TPoor or [TMeager](treasure-packs.md#tmeager) |
| 3 | TMeager or [TAverage](treasure-packs.md#taverage) |
| 4 | [TRich](treasure-packs.md#trich) or TAverage |
| 5 | TRich |
| 6 | TRich or [TFilthyRich](treasure-packs.md#tfilthyrich) |
| 7 | TFilthyRich |
| 8 | TFilthyRich or [TUltraRich](treasure-packs.md#tultrarich) |
| 9 | TUltraRich |
| 10 | TUltraRich or [TMegaRich](treasure-packs.md#tmegarich) |
| 11–12 | TMegaRich |

### Bonus Items

After each pack generation (for non-special chests), `AddTreasure` also:
- Rolls `level` times: each has a 25% chance to add a `RandomItem` (additional random item mutated by `ChangeItem`)
- Then a `level/24` chance to add a `RandomTreasure` item

---

## Treasure Map Chests

Treasure map chests (`TreasureMapChest`) are dug up from treasure maps and call `FillTheContainer` **multiple times**:

| Condition | Fill call |
|-----------|-----------|
| Always | 1st fill at map level |
| Map level > 3 | 2nd fill |
| Map level > 7 | 3rd fill |
| Luck bonus (possible) | Additional fill |

This means a Level 7 treasure map chest gets at least 2 fills, and a Level 8+ chest gets at least 3 fills plus a possible luck bonus fill.

> **Trap note:** TreasureMapChests always have an Explosion Trap and are always locked.

---

## Container Types

| Container | How Filled | Chest Level |
|-----------|-----------|-------------|
| `LootChest` | `FillTheContainer` | 1–10 (set at creation) |
| `TreasureMapChest` | Multiple `FillTheContainer` calls | 1–7 (map level) |
| `ParagonChest` | `FillTheContainer` | Paragon's level |
| `SunkenChest` | `FillTheContainer` | 1–5 |
| `BuriedChest` | `FillTheContainer` | 1–5 |
| `BuriedBody` | `FillTheContainer` | 1–5 |
| `GraveChest` | `FillTheContainer` | 1–4 |
| `CorpseChest` | `FillTheContainer` | 1–10 (fame-based) |
| `CorpseSailor` | `FillTheContainer` | 1–10 (fame-based) |

Puzzle Chests use the same system — see [Puzzle Chests](../puzzle-chests.md).

---

## Appearance Variation

`ContainerFunctions.BuildContainer()` assigns a random visual appearance and gump based on environment:
- **Normal dungeons**: Wooden chest, iron chest, crates, bags
- **Sea dungeons**: Sea-themed chests
- **Sci-fi (Spaceship)**: Metal crates — `Catalog = Catalogs.SciFi`
- **Hall of the Mountain King**: Stone-themed
- **Destard**: Dragon-themed variants
