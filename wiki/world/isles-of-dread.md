# Isles of Dread

The Isles of Dread are remote and perilous islands featuring icy fortresses, blood temples, and ancient ruins. This land yields slightly more resources than other regions when harvesting.

## Overview

| Property | Value |
|----------|-------|
| Map Index | 4 |
| Size | 1448 × 1448 tiles |
| Season | Spring/Summer |

## Towns & Settlements

| Settlement | Type |
|-----------|------|
| the Cimmeran Hold | Fortified Settlement |

## Dungeons

| Dungeon | Notes |
|---------|-------|
| the Blood Temple | |
| the Glacial Scar | Ice-themed |
| the Ice Queen Fortress | Ice-themed |
| the Sanctum of Saltmarsh | Entrance via Lodoria map |
| the Scurvy Reef | Pirate-themed |
| the Temple of Osirus | Entrance via Lodoria map |

## Special Materials & Harvests

The Isles of Dread have a **boosted harvest yield** for all harvestable resources. Every ore swing, wood chop, fish catch, and sand dig uses the `ConsumedPerIslesDreadHarvest` formula instead of the base amount:

> **Yield formula**: base + ceil(base/2) + 2

This means roughly 50%+ more resources per action compared to other lands.

| Resource | Details |
|---|---|
| Standard Ore (Iron–Valorite) | Boosted yield on all swings |
| Standard Wood (Regular–Walnut) | Boosted yield on all chops |
| Sand | Boosted yield on sand tiles |
| **Shipwreck Fishing** | 4 wreck sites at: (760, 587), (200, 1056), (1232, 387), (528, 233) |

Beyond the yield bonus, the same standard ore and wood mutation rules apply (sea regions → Nepturite/Driftwood if near sea zones).

See [Mining](../crafting/mining.md) and [Lumberjacking](../crafting/lumberjacking.md) for material tier details.

## Unique Features

- **Enhanced Resource Gathering**: The Isles of Dread provide slightly more resources than other lands when harvesting
- **Remote Location**: Requires sea travel or magical transport to reach
- **Ice and Blood Themes**: Dungeons range from frozen fortresses to unholy blood temples
- **Land-Specific Resources**: Certain rare materials may only be available from merchants here
