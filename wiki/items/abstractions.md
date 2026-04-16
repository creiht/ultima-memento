# Abstractions

Abstractions are internal programming interfaces used by the item system. They are not items players interact with directly, but define behaviors shared by many item types.

## Interfaces

| Interface | Purpose |
|-----------|---------|
| `ICommodity` | Marks items that can be stored in Commodity Deeds (e.g., crafting resources, reagents). Items implementing this can be wrapped in a commodity deed at a banker. |
| `IHarvestTool` | Marks items that can be used as harvesting tools (e.g., pickaxes for mining, hatchets for lumberjacking). Items implementing this connect to a `HarvestSystem`. |

## Player Relevance

- **ICommodity**: If an item is a commodity, you can use a [Commodity Deed](deeds.md) to wrap stacks of that resource for safe bank storage and trading.
- **IHarvestTool**: Any tool implementing this interface can be used to gather raw materials from the world (ore, wood, etc.).
