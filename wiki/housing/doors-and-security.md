# Doors and Security

## House Door Classes

Classic house doors are defined in `World/Source/Scripts/Items/Houses/Doors/HouseDoors.cs`. The primary types used on player houses are:

| Class | Description |
|---|---|
| `DarkWoodHouseDoor` | Dark wood panel door |
| `MetalHouseDoor` | Iron/metal door |
| `GenericHouseDoor` | Generic house door (parameterized graphic) |

Custom foundation houses use their own door component types placed during design mode.

## DoorFacing Directions

Doors use a `DoorFacing` enum indicating open/close direction:

| Value | Direction |
|---|---|
| WestCW | West, clockwise |
| EastCCW | East, counter-clockwise |
| WestCCW | West, counter-clockwise |
| EastCW | East, clockwise |
| SouthCW | South, clockwise |
| NorthCCW | North, counter-clockwise |
| SouthCCW | South, counter-clockwise |
| NorthCW | North, clockwise |
| NorthCCW | (alias) |
| SouthCW | (alias) |

Source: `World/Source/Scripts/Items/Houses/Doors/BaseDoor.cs`

## SecureLevel

The `SecureLevel` enum determines who can open a secured container or a lockdown. Default for secured items is **Anyone**.

| Value | Access |
|---|---|
| Owner | Owner only |
| CoOwners | Owner and Co-Owners |
| Friends | Owner, Co-Owners, Friends |
| Anyone | All (including public visitors) |
| Guild | Guild members |

Source: `BaseHouse.cs:2036–2038`

## AOS vs Non-AOS Access Checking

This server runs in **AOS mode**. In AOS mode:
- Access checks use the AOS friend/ban limits (140 friends, 140 bans).
- Door-opening by a Friend does NOT refresh decay in ML mode; on this server decay is disabled anyway (`S_HousesDecay = false`).

In non-AOS mode, a friend opening a door refreshes the decay timer.

## Key System (Non-AOS)

In non-AOS mode, house keys are physical items:
- Keys are placed in the owner's pack and bank at placement.
- Keys are **newbied** (never dropped on death).
- Keys use a gold key graphic.
- `ChangeLocks()` is called on house transfer, generating new keys and invalidating old ones.

In AOS mode (this server), the key system is not used — access is role-based.

## Door-Opening Effects

- A **Friend** (or higher) opening a door refreshes the house decay timer (non-AOS / non-ML mode).
- A non-friend **public visitor** opening a door increments a visit counter (tracked for informational purposes only).

## Special Doors

The following door types in `World/Source/Scripts/Items/Houses/Doors/` are not typical house doors but are relevant to housing:

| File | Type | Notes |
|---|---|---|
| `BasementDoor.cs` | Basement hatch | Leads to basement level when `S_Basements = true` |
| `BasementDoorway.cs` | Basement doorway arch | Visual frame for basement entrance |
| `Portcullis.cs` | Portcullis gate | Heavy castle-style gate |
| `KeywordDoor.cs` | Keyword-triggered door | Opens when correct word is spoken |
| `PickableDoor.cs` | Lockpickable door | Can be opened with Remove Trap / Lockpicking |
| `SecretDoors.cs` | Secret/hidden door | Visually hidden in wall |
| `DoorSwitch.cs` | Pressure switch | Triggers linked door |
| `ThruDoor.cs` | Pass-through door | Teleport-style door to another location |

## Basements

When `S_Basements = true` (default), houses can have a basement level accessible through a `BasementDoor`. The basement is a separate Z-plane below the ground floor.

## Related Pages

- [Ownership and Access](ownership-and-access.md) — who can open doors
- [Decay and Refresh](decay-and-refresh.md) — decay refresh via door opens
- [Lockdowns and Secures](lockdowns-and-secures.md) — SecureLevel on containers
- [Admin and Settings](admin-and-settings.md) — `S_Basements` flag

---

**Source references:** `World/Source/Scripts/Items/Houses/Doors/`, `World/Source/Scripts/Items/Houses/BaseHouse.cs:2036–2038`, `World/Info/Scripts/Settings.cs:663`
