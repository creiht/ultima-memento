# Admin and Settings

This page covers all GM/admin commands related to housing and all housing-relevant settings from `World/Info/Scripts/Settings.cs` (category 009 — HOMES & SHIPS).

## GM Commands (AccessLevel.GameMaster)

| Command | Usage | Description |
|---|---|---|
| `[RefreshHouse` | Target a house sign or house object | Resets the house's decay timer to now (makes it LikeNew). Source: `World/Source/Scripts/System/Commands/Commands/Commands.cs:139–170` |
| `[DesignInsert` | Target a custom foundation | Inserts a stored design template into a `HouseFoundation`. Source: `HouseFoundation.cs:741` |
| `[Link` | Target two doors in sequence | Links a pair of doors so they open/close together. Source: `Doors/BaseDoor.cs:106` |
| `[ChainLink` | Target doors in sequence | Links a chain of doors (all open/close together). Source: `Doors/BaseDoor.cs:107` |

## Admin Commands (AccessLevel.Administrator)

| Command | Usage | Description |
|---|---|---|
| `[Monopoly` | (no args) | Regenerates all Monopoly decoration items from `.cfg` files in `Data/Decoration/Monopoly/` for all six facets. Source: `Monopoly/Decorate.cs:14` |
| `[SHTelGen` | (no args) | Generates house teleporter sets (SH Teleporter system). Source: `Construction/Addons/SHTeleporter.cs:137` |
| `[GenStealArties` | (no args) | Spawns stealable artifact objects throughout the world. Source: `Decorations/Artifacts/StealableArtifactsSpawner.cs:122` |
| `[RemoveStealArties` | (no args) | Removes all stealable artifact spawners. Source: `Decorations/Artifacts/StealableArtifactsSpawner.cs:123` |

## Housing Settings (Settings.cs Category 009)

Override any of these in `World/Info/Scripts/Settings.override.cs` via `SettingOverrides.Initialize()` to avoid modifying the tracked source file.

| Setting | Default | Effect |
|---|---|---|
| `S_HouseOwners` | `false` | If `true`, co-owners have the same permissions as the owner. If `false` (default), co-owners have the standard limited permissions from the base game. |
| `S_LawnsAllowed` | `true` | Enables the Lawn System (exterior items via architect tools). If set to `false` after items were placed, existing lawn items are refunded and tools are removed. |
| `S_ShantysAllowed` | `true` | Enables the Shanty/Remodeling System (interior walls, doors, tiles). Same refund behavior as lawns if disabled. |
| `S_BoatDecay` | `365.0` | Days before a boat or magic carpet decays if unused at sea. Min: 5.0. |
| `S_HomeDecay` | `365.0` | Days before a house decays if its owner never visits (assuming `S_HousesDecay = true`). Min: 30.0. |
| `S_HousesDecay` | `false` | Master switch for house decay. If `false` (default), `S_HomeDecay` is ignored and all houses are Ageless. |
| `S_HousesPerAccount` | `2` | Maximum number of houses an account's characters may own. Set to `-1` for unlimited. |
| `S_AllowHouseDyes` | `false` | If `true`, players can dye construction contracts to color an entire pre-built house uniformly. |
| `S_AllowCustomHomes` | `true` | If `false`, custom (design-your-own) foundations are disabled; players can only place classic houses. |
| `S_Basements` | `true` | Enables the public basement system. Players can buy basement doors; basement doors appear in trade shops. |
| `S_HouseStorage` | `false` | If `true`, item storage in houses is unlimited — the storage accounting system is not enforced. Players can drop items on the floor without locking them. |
| `S_NoMountsInCertainRegions` | `true` | If `true`, certain regions (dungeons, caves) dismount players and stable their mounts. |
| `S_NoMountBuilding` | `true` | If `true`, entering any building (including houses) dismounts the player. |
| `S_NoMountsInHouses` | `true` | If `true`, entering a player house dismounts the player specifically (more targeted than `S_NoMountBuilding`). |

Source: `World/Info/Scripts/Settings.cs:614–719`

## Override Advice

To change a setting without touching the tracked source, add it to `World/Info/Scripts/Settings.override.cs`:

```csharp
public static void Initialize()
{
    MySettings.S_HousesDecay = true;
    MySettings.S_HousesPerAccount = 3;
    // etc.
}
```

The override file is processed after `Settings.cs`, so it takes precedence.

## Notably Absent

- There is **no** `[placehouse` command — staff do not place houses for players; players use Construction Contracts or Deeds.
- There is **no** player `[refresh` command — decay refresh happens naturally through gameplay (door opens, sign views).
- There is **no** undo-demolish — when a house is demolished, the Moving Crate captures items, but the structure is gone.

## Related Pages

- [Decay and Refresh](decay-and-refresh.md) — decay system details
- [Lawn and Remodeling](lawn-and-remodeling.md) — `S_LawnsAllowed`, `S_ShantysAllowed`
- [Town Houses (Monopoly)](town-houses-monopoly.md) — `[Monopoly` command
- [Custom Foundations](custom-foundations.md) — `S_AllowCustomHomes`

---

**Source references:** `World/Info/Scripts/Settings.cs:609–719`, `World/Source/Scripts/System/Commands/Commands/Commands.cs:139–170`, `HouseFoundation.cs:741`, `Doors/BaseDoor.cs:106–107`, `Monopoly/Decorate.cs:14`, `Construction/Addons/SHTeleporter.cs:137`, `Decorations/Artifacts/StealableArtifactsSpawner.cs:122–123`
