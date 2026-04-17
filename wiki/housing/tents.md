# Tents

Tents are lightweight house types and addon structures. They range from small personal shelters to a massive Large Tent house.

## Blue Tent and Green Tent (Houses)

Small tent-style houses. Despite the "tent" appearance they function as full houses with lockdowns, secures, and vendor slots.

| Property | Value |
|---|---|
| Lockdowns | 500 |
| Secures | 4 |
| Vendors (placement entry) | 1 |
| Cost (placement entry) | 15,000 gp |
| Interior area | Rectangle2D 8×8 |
| Deed | `BlueTentDeed` / `GreenTentDeed` |
| Multi ID | 0x70 (Blue) / 0x72 (Green) |

- Blue Tent deed label: "deed to a blue tent"
- Green Tent deed label: "deed to a green tent"
- `IsInside()` uses the 8×8 `Rectangle2D` — no doors, the whole area is the "inside."

Source: `SmallTents.cs:56, 151`

## Tent House Addons (Decorative)

Single-color decorative tent structures placed as addons inside or outside a house. These are not house structures — they are decorative multi-tile items.

- **TentAddon (East)** — `TentsEast.cs`
- **TentAddon (South)** — `TentsSouth.cs`
- Parameterized hue on placement (choose the color when using the deed).

## Circus Tent Addons (Decorative)

Two-color decorative circus-style tents.

- **CircusTentAddon (East)** — `CircusTentsEast.cs`
- **CircusTentAddon (South)** — `CircusTentsSouth.cs`
- Two configurable hues (primary and secondary color).

## Large Tent (House)

A very large tent-style house at the keep/castle tier.

| Property | Value |
|---|---|
| Lockdowns | 1,576 |
| Secures | 788 |
| Vendors (placement entry) | 28 |
| Cost (placement entry) | 610,000 gp |
| Interior area | Rectangle2D 25×26 |
| Deed | `LargeTentDeed` |
| Multi ID | 0x49 |

Source: `Houses.cs:66`, `HousePlacementTool.cs:714`

## Gypsy Camp Addon

A large, elaborate multi-component decorative addon that creates a full gypsy camp scene.

- Placed via `GypsyCampAddonDeed`.
- Composed of many components (~100+) including wagons, campfire, tents, crates, barrels, and other scenery.
- Suited for large house interiors or exterior placements on keep-sized or larger houses.

Source: `GypsyCampAddon.cs`

## Related Pages

- [House Types](house-types.md) — full table of all classic houses including tents
- [Placement](placement.md) — placement rules apply to tent houses
- [Addons](addons.md) — decorative addon overview

---

**Source references:** `World/Source/Scripts/Items/Houses/SmallTents.cs`, `Houses.cs:57–80`, `TentsEast.cs`, `TentsSouth.cs`, `CircusTentsEast.cs`, `CircusTentsSouth.cs`, `GypsyCampAddon.cs`, `HousePlacementTool.cs:714`
