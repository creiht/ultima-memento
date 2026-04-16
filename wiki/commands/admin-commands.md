# Admin Commands

These commands are restricted to staff members based on their access level. Access levels from lowest to highest: Counselor, GameMaster, Administrator, Developer, Owner.

## Command Reference

| Command | Access Level | Syntax | Description |
|---------|-------------|--------|-------------|
| `Go` | Counselor | `[Go <location>` | Teleports the invoker to a specified location. |
| `Where` | Counselor | `[Where` | Shows your current coordinates, region, and facet. |
| `Stuck` | Counselor | `[Stuck` | Helps a stuck player. |
| `Client` | Counselor | `[Client` | Shows client information for a target. |
| `Light` | Counselor | `[Light` | Shows light level information. |
| `Stats` | Counselor | `[Stats` | Shows stats for the target. |
| `Echo` | Counselor | `[Echo <text>` | Echoes text back to the invoker. |
| `Cast` | Counselor | `[Cast <spell>` | Casts a spell by name. |
| `Vis` | Counselor | `[Vis` | Toggles visibility of a target. |
| `VisList` | Counselor | `[VisList` | Lists the visibility list. |
| `VisClear` | Counselor | `[VisClear` | Clears the visibility list. |
| `TargetLog` | Counselor | `[TargetLog` | Logs target information. |
| `SpawnerCatalog` | Counselor | `[SpawnerCatalog` | Opens the spawner catalog interface. |
| `Skills` | Counselor | `[Skills` | Opens the skills menu for a target. |
| `Scan` | Counselor | `[Scan` | Scans area and shows information gump. |
| `RecordItems` | Counselor | `[RecordItems` | Records item data for logging. |
| `Props` | Counselor | `[Props` | Opens the properties gump for a target. |
| `PointLog` | Counselor | `[PointLog` | Logs point/location data. |
| `FaceLog` | Counselor | `[FaceLog` | Logs facing direction data. |
| `Builders` | Counselor | `[Builders` | Runs large-scale building commands. |
| `DropHolding` | Counselor | `[DropHolding` | Drops any item the target is holding. |
| `AutoPageNotify` / `APN` | Counselor | `[APN` | Toggles auto page notification. |
| `SpeedBoost` | Counselor | `[SpeedBoost [true\|false]` | Toggles speed boost for the invoker. |
| `SMsg` / `SM` / `S` | Counselor | `[S <message>` | Sends a staff-only message. |
| `HelpInfo` | Player | `[HelpInfo` | Shows available command help. |
| `GetFollowers` | GameMaster | `[GetFollowers` | Teleports all your followers to you. |
| `Animate` | GameMaster | `[Animate` | Plays an animation on a target. |
| `Move` | GameMaster | `[Move` | Moves a target to a location. |
| `BCast` / `BC` / `B` | GameMaster | `[B <message>` | Broadcasts a message to all players. |
| `Bank` | GameMaster | `[Bank` | Opens a target's bank box. |
| `Inn` | GameMaster | `[Inn` | Opens an inn interface. |
| `Sound` | GameMaster | `[Sound <id>` | Plays a sound effect. |
| `ViewEquip` | GameMaster | `[ViewEquip` | Views equipment of a target. |
| `Tile` | GameMaster | `[Tile <type>` | Tiles items in a defined area. |
| `TileRXYZ` | GameMaster | `[TileRXYZ` | Tiles items with relative XYZ offsets. |
| `TileXYZ` | GameMaster | `[TileXYZ` | Tiles items at specific XYZ coordinates. |
| `TileZ` | GameMaster | `[TileZ` | Tiles items at a specific Z level. |
| `Dupe` | GameMaster | `[Dupe [amount]` | Duplicates a targeted item. |
| `DupeInBag` | GameMaster | `[DupeInBag <count>` | Duplicates an item in its current location. |
| `Wipe` | GameMaster | `[Wipe` | Wipes all items and NPCs in an area. |
| `WipeItems` | GameMaster | `[WipeItems` | Wipes only items in an area. |
| `WipeNPCs` | GameMaster | `[WipeNPCs` | Wipes only NPCs in an area. |
| `WipeMultis` | GameMaster | `[WipeMultis` | Wipes only multi-objects (houses, boats) in an area. |
| `SetSkill` | GameMaster | `[SetSkill <name> <value>` | Sets a skill value for a target. |
| `GetSkill` | GameMaster | `[GetSkill <name>` | Gets a skill value for a target. |
| `SetSkillCap` | GameMaster | `[SetSkillCap <value>` | Sets the skill cap for a target. |
| `GetSkillCap` | GameMaster | `[GetSkillCap` | Gets the skill cap for a target. |
| `SetAllSkills` | GameMaster | `[SetAllSkills <value>` | Sets all skills to the specified value. |
| `UseSkill` | Player | `[UseSkill <name>` | Uses a skill by name. |
| `Save` | Administrator | `[Save` | Forces an immediate world save. |
| `BGSave` / `SaveBG` | Administrator | `[BGSave` | Forces a background world save. |
| `ClearFacet` | Administrator | `[ClearFacet` | Clears all items/NPCs on a facet. |
| `ReplaceBankers` | Administrator | `[ReplaceBankers` | Replaces all banker NPCs. |
| `Freeze` | Administrator | `[Freeze` | Converts items into static tiles in an area. |
| `FreezeMap` | Administrator | `[FreezeMap` | Freezes all items on the current map. |
| `FreezeWorld` | Administrator | `[FreezeWorld` | Freezes items across all maps. |
| `Unfreeze` | Administrator | `[Unfreeze` | Converts static tiles back to items. |
| `UnfreezeMap` | Administrator | `[UnfreezeMap` | Unfreezes all statics on the current map. |
| `UnfreezeWorld` | Administrator | `[UnfreezeWorld` | Unfreezes across all maps. |
| `StaticExport` / `StaEx` | Administrator | `[StaticExport` | Exports static tile data. |
| `SpecialExport` / `SpcEx` | Administrator | `[SpecialExport` | Exports special item data. |
| `SignGen` | Administrator | `[SignGen` | Generates signs from definition data. |
| `DocGen` | Administrator | `[DocGen` | Generates RunUO documentation files. |
| `DumpTimers` | Administrator | `[DumpTimers` | Dumps timer information for debugging. |
| `CountObjects` | Administrator | `[CountObjects` | Counts all objects in the world. |
| `ProfileWorld` | Administrator | `[ProfileWorld` | Profiles the world for performance data. |
| `TraceInternal` | Administrator | `[TraceInternal` | Traces internal map usage. |
| `TraceExpanded` | Administrator | `[TraceExpanded` | Traces expanded map data. |
| `WriteProfiles` | Administrator | `[WriteProfiles` | Writes profiling data to disk. |
| `SetProfiles` | Administrator | `[SetProfiles` | Configures profiling settings. |
| `RebuildCategorization` | Administrator | `[RebuildCategorization` | Rebuilds the item categorization data. |
| `MultiGen` | Administrator | `[MultiGen` | Generates multi-object (building) data. |
| `logchests` | Administrator | `[logchests` | Logs all treasure chest locations. |
| `ItemPrices-ExportCraft` | Administrator | `[ItemPrices-ExportCraft` | Exports crafted item pricing data. |
| `ItemPrices-RecreateCraft` | Administrator | `[ItemPrices-RecreateCraft` | Recreates crafted item pricing. |

## World Building

The most important admin command for world setup is `[buildworld`, which regenerates all spawners, decorations, merchants, and world content. It is implemented in `Build.cs` and should be run after certain configuration changes.

See the [AGENTS.md](../../AGENTS.md) for details on when `[buildworld` must be run.
