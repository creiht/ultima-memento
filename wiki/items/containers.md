# Containers

Containers are items that hold other items. They range from player backpacks and bank boxes to dungeon treasure chests and lootable corpses.

## Player Containers

| Container | Weight | Max Items | Weight Reduction | How to Obtain |
|-----------|--------|-----------|-----------------|---------------|
| Bag of Holding | 1.0 | 10 | **95%** (items weigh 5% of normal) | Rare loot, special rewards |
| Sack of Holding (Small) | 1.0 | 10 | 100% (items weigh nothing; max weight 100,000) | Rare loot, rewards |
| Sack of Holding (Medium) | 2.0 | 20 | 100% | Rare loot, rewards |
| Sack of Holding (Large) | 3.0 | 30 | 100% | Rare loot, rewards |
| Moving Box | — | Large | None | Purchase |

> **Bag of Holding**: Contents weigh exactly 5% of their normal weight (`totalWeight × 0.05`). Holds 10 items.
> **Sack of Holding**: Max capacity weight is 100,000 stones regardless of contents. Tiered variants by size.

## Storage Containers

| Container | Description | How to Obtain |
|-----------|-------------|---------------|
| Wooden/Metal Chest | Standard storage containers for homes | Crafting (Carpentry/Tinkering) |
| Furniture Container | Dressers, armoires, and other furniture storage | Crafting, purchase |
| Shelves | Display storage for homes | Crafting |
| Strongbox | Secured home storage | Crafting |
| Safe | Locked home storage | Crafting |

## Loot Containers (World)

See [Chest Containers](../systems/loot-tables/chest-containers.md) for how chest levels map to treasure tiers.

| Container | Where Found | Loot Table | Notes |
|-----------|-------------|-----------|-------|
| Dungeon Chest | Dungeons | [Level 1–10](../systems/loot-tables/chest-containers.md) | May be trapped/locked |
| Treasure Chest | Various | [Level 1–10](../systems/loot-tables/chest-containers.md) | Standard loot container |
| Treasure Map Chest | Dug up via treasure maps | [Multi-fill by map level](../systems/loot-tables/chest-containers.md#treasure-map-chests) | Filled 1–4+ times based on map level |
| Land Chest | Overworld | [Level 1–6](../systems/loot-tables/chest-containers.md) | Found in wilderness |
| Pirate Chest | Ships, sea encounters | [Level 1–5](../systems/loot-tables/chest-containers.md) | Nautical-themed |
| Sunken Chest | Underwater/fishing | [Level 1–5](../systems/loot-tables/chest-containers.md) | Retrieved by fishing or diving |
| Sunken Bag | Underwater/fishing | [Level 1–3](../systems/loot-tables/chest-containers.md) | Smaller container |
| Water Chest | Coastal areas | [Level 1–4](../systems/loot-tables/chest-containers.md) | Found near water |
| Grave Chest | Graveyards | [Level 1–4](../systems/loot-tables/chest-containers.md) | Graveyards and crypts |
| Hidden Chest | Various | [Level 1–8](../systems/loot-tables/chest-containers.md) | Requires detection |
| Hidden Box | Various | [Level 1–5](../systems/loot-tables/chest-containers.md) | Small concealed container |
| Paragon Chest | Paragon creatures | [Paragon level](../systems/loot-tables/paragon-drops.md) | Dropped by paragons (10% chance) |
| Inn Chest | Inns | [Level 1–3](../systems/loot-tables/chest-containers.md) | Found in inn rooms |
| Food Chest | Kitchens, dining areas | — | Contains food items |
| Corpse Chest | Dragon/large creature drops | [Level 1–10](../systems/loot-tables/special-drops.md#corpse-chests-dragon-sea-creature) | Fame-based drop from DropRelic |
| Corpse Sailor | Sea creature drops | [Level 1–10](../systems/loot-tables/special-drops.md#corpse-chests-dragon-sea-creature) | Fame-based sea creature drop |
| Bone Container | Dungeons, graveyards | [Level 1–4](../systems/loot-tables/chest-containers.md) | Skeletal-themed |
| Buried Body / Buried Chest | Underground | [Level 1–5](../systems/loot-tables/chest-containers.md) | Discovered via digging |
| Dust Pile | Various | [Level 1–2](../systems/loot-tables/chest-containers.md) | Small loot pile |
| Gypsy Shelf | Gypsy camps | [Level 1–3](../systems/loot-tables/chest-containers.md) | Themed container |
| Loot Bag | Monster drops | — | Standard loot drop container |

## Container Features

- **Lockable**: Many containers can be locked with keys or the Lockpicking skill
- **Trappable**: Dungeon and treasure chests may have traps (poison, explosion, etc.)
- **Weight Reduction**: Special containers like Bag of Holding reduce the weight of their contents
- **Loot System**: World containers use a tiered loot system based on location difficulty

## Bank Box

Every player has a personal bank box accessible at any banker NPC. The bank box is the safest storage in the game — items inside cannot be stolen or lost.
