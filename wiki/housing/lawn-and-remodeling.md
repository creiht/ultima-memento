# Lawn and Remodeling

Two systems allow players to customize the appearance of their houses beyond the standard interior: the **Lawn System** (exterior items) and the **Shanty System** (interior/exterior walls, doors, and tiles).

Both are enabled by default and toggled via `Settings.cs`.

## Lawn System

**Setting:** `S_LawnsAllowed = true`  
**Source:** `World/Source/Scripts/Items/Houses/Remodeling/LawnSystem.cs`

The Lawn System lets house owners place exterior decorative objects — trees, shrubs, fences, ground textures, pits, pentagrams, and more — **up to 15 tiles** from the house border.

**How to use:**
1. Obtain **Architect Tools** (Lawn variant) from an Architect NPC.
2. Double-click the tools inside or near your house to open the Lawn Gump.
3. Browse categories, select an item, and click its name to enter targeting mode.
4. Target the desired location within 15 tiles of the house border.
5. The gold cost is withdrawn from your bank.

**Placement rules:**
- Items must be placed **outside** the house, not inside.
- Maximum placement distance: **15 tiles** from the house border.
- If you want to place as far as possible (e.g., northwest corner), stand at the house's closest northwest position.
- Items near the east or south boundary may be tricky — try placing 1 tile over and nudging with homeowner tools.

Source: `LawnGump.cs:58`

### Ground Texture Variants

Ground textures replace the visual tile under the placed spot.

| Texture Name | Notes |
|---|---|
| magma rock ground | |
| lava rock ground | |
| grassy ground | |
| forest ground | |
| cavern ground | |
| desert ground | |
| jungle ground | |
| lunar rock ground | |
| blood rock ground | |
| stone ground | |
| light stone ground | |
| dark stone ground | |
| muddy ground | |
| dirt ground | |
| light dirt ground | |
| dark dirt ground | |

Source: `Remodeling.cs:37–56`

### Orphan Cleanup

On each world save, the Lawn System scans all lawn items for ones whose house has been demolished. Orphaned items are automatically deleted.

Source: `LawnSystem.cs:53–66`

## Shanty (Remodeling) System

**Setting:** `S_ShantysAllowed = true`  
**Source:** `World/Source/Scripts/Items/Houses/Remodeling/ShantySystem.cs`

The Shanty System lets owners place custom walls, doors, and tile patterns inside (and around) the house to create a more hand-built "shanty" aesthetic. This is an interior remodeling system as opposed to the Lawn System's exterior focus.

**How to use:**
1. Obtain **Architect Tools** (Shanty variant) from an Architect NPC.
2. Double-click the tools to open the Shanty Gump.
3. Select wall segments, door types, or floor tiles and target locations in your house.
4. Shanty items placed inside count against house resources.

Shanty items are also subject to orphan cleanup on world save.

## Setting Toggles

| Setting | Default | Effect |
|---|---|---|
| `S_LawnsAllowed` | `true` | Enables/disables the Lawn System globally |
| `S_ShantysAllowed` | `true` | Enables/disables the Shanty System globally |

Both are in `World/Info/Scripts/Settings.cs` category 009.

## Related Pages

- [Addons](addons.md) — interior addon system
- [Admin and Settings](admin-and-settings.md) — `S_LawnsAllowed`, `S_ShantysAllowed`

---

**Source references:** `World/Source/Scripts/Items/Houses/Remodeling/LawnSystem.cs`, `LawnGump.cs`, `Remodeling.cs`, `ShantySystem.cs`, `World/Info/Scripts/Settings.cs:622–630`
