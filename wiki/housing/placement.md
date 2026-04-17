# House Placement

Houses are placed via one of two paths: a **Construction Contract** (previewed placement with bank withdrawal) or a **House Deed** (direct, deed-consumed placement).

## Construction Contract Path

The Construction Contract is an item (graphic 0x14F0) that opens the placement category gump. Use flow:

1. Double-click the Construction Contract.
2. Choose a category: **Classic Houses**, **2-Story Foundations**, or **3-Story Foundations**.
3. Browse the list. Each entry shows name, storage, lockdowns, vendor slots, and cost.
4. Click a house entry to enter targeting mode. A blue-tinted preview multi appears at your cursor.
5. Target a valid spot. A 20-second preview timer starts.
6. Click **Okay** to commit (cost is withdrawn from bank) or **Cancel** to abort. Clicking the condemn checkbox warns you the house will be demolished then rebuilt.

## House Deed Path

House deeds are specific items (subclasses of `HouseDeed`) for each house type. Double-click the deed and target the desired placement location. The deed is consumed on success. No preview timer or gump.

## Placement Validation Rules

Source: `World/Source/Scripts/Items/Houses/HousePlacement.cs`

The following checks are applied in order:

| # | Rule |
|---|---|
| 1 | All tiles around the **outside** of the foundation must be passable. |
| 2 | No impassable object or land tile may touch any part of the house directly. |
| 3 | A 1-tile buffer zone around the house perimeter must be clear of any other house tiles (`YardSize = 1`). |
| 4 | The foundation must rest flat. Height variation around the foundation is not allowed. |
| 5 | No foundation tile may overlap tiles considered roads. |

These rules are enforced regardless of placement method.

## Region Restrictions

| Result Code | Cause |
|---|---|
| `BadRegion` | Location is inside a `NoHousingRegion` (towns, dungeons, special areas). |
| `BadRegionTemp` | Location is inside a `TempNoHousingRegion` (temporary restriction). |
| `BadRegionHidden` | Hidden region restriction (same effect as BadRegion). |
| `InvalidCastleKeep` | Castles and Keeps have additional footprint restrictions. |

### Dirt-Terrain Exceptions

Certain exterior dirt/desert areas skip the normal land-type check and allow placement:

- `NecromancerRegion`
- `LunaRegion`
- `UnderHouseRegion`
- Underworld facet (`Land.Underworld`)
- Lodor map: X 1105–1950, Y 2685–3201 (Lodor desert)
- Sosaria map: X 1114–1265, Y 387–597 (Sosaria desert)

Source: `HousePlacement.cs:205–208`

## Account Limit

Players may own at most **2 houses per account** (default; configurable via `S_HousesPerAccount`). This limit is enforced per account, with avatar mode and permadeath mode maintaining separate pools.

## Error Messages

| Message | Meaning |
|---|---|
| "That location is not available for placing a house." | General placement failure (bad land, static, or item in the way). |
| "You cannot place a house in this area." | BadRegion. |
| "The house could not be placed, as somebody is standing where it would be built." | Mobile in the footprint. |
| "You are not allowed to own a house at this time." | Account limit reached or other account restriction. |

## Related Pages

- [Getting Started](getting-started.md) — quick-start overview
- [House Types](house-types.md) — classic house stats
- [Custom Foundations](custom-foundations.md) — 2-story and 3-story designs

---

**Source references:** `World/Source/Scripts/Items/Houses/HousePlacement.cs`, `World/Source/Scripts/Items/Houses/HousePlacementTool.cs`, `World/Info/Scripts/Settings.cs:647`
