# Town Houses (Monopoly System)

The Monopoly system provides a set of staff-designated town buildings that players can rent or purchase. Unlike regular player-placed houses, town houses are fixed in place by server administrators and made available for occupancy through a rental/purchase system.

## Overview

- Staff place `TownHouse` objects in towns across the world's facets.
- Each town house has a `TownHouseSign` that shows its availability, price, and rental/purchase terms.
- Players browse available properties and claim one through a gump.

## Components

| Component | Class | Purpose |
|---|---|---|
| Town House | `TownHouse` | The house structure; maintains the owner and rental state |
| Town House Sign | `TownHouseSign` | Per-house management gump; shows price, status, owner |
| Rental Contract | `RentalContract` | Agreement between owner and sub-renter for a portion of the house |
| Rental Contract Copy | `RentalContractCopy` | Renter's copy of the signed contract |
| Rental License | `RentalLicense` | Required for renting (only if `RequireRenterLicense = true`; default false) |
| Sign Hammer | `SignHammer` | Staff tool for managing town house signs |

## Player Flow — Acquiring a Town House

1. Open the **`[AllTownHouses`** gump to browse all available town houses on the server.
2. Find one that is available (unowned or expired lease) and within your price range.
3. Click to view details: location, price, size, lockdown/secure allocation.
4. Buy (permanently) or rent (pay recurring rent) through the gump.
5. Once claimed, the town house functions like a regular house for access, lockdowns, and secures.

## House-Owner Rental Flow

A player who owns a regular house can sub-rent portions of it to other players:

1. Stand inside your own house.
2. Say **"create rental contract"**.
3. A `VendorRentalContract` item is created in your pack.
4. Configure: rent amount per period, lockdown and secure allocation to the renter, and duration.
5. Give the contract to the prospective renter.
6. The renter double-clicks it and signs it (pays the first rental period).
7. A `RentalContractCopy` is given to the renter as proof.
8. The renter gains access to their allocated sub-portion.

When the rental contract expires, the bank automatically repossesses the space and the owner is notified: *"Your town house rental contract has expired, and the bank has once again taken possession."*

Source: `TownHouseSign.cs:986`

## Pricing

Suggested pricing is calculated as:

```
Suggested Price = CalcVolume() × SuggestionFactor
SuggestionFactor = 600 gp per tile²
```

This is a suggestion only — the owner can set any price.

Source: `Misc/General.cs:16`

## Settings

| Setting | Value | Notes |
|---|---|---|
| `SuggestionFactor` | 600 gp / tile² | Suggested price per volume unit |
| `RequireRenterLicense` | `false` | If true, renter must hold a `RentalLicense` |

Source: `World/Source/Scripts/Items/Houses/Monopoly/Misc/General.cs`

## Facet Coverage

Monopoly decorative items (town house markers and related decor) are generated across all six major facets:

- Sosaria
- Lodor
- Serpent Island
- Isles of Dread
- Savaged Empire
- Underworld

Source: `Decorate.cs:39–44`

## Admin Command

- `[Monopoly` — Staff command to regenerate all Monopoly decoration items from `.cfg` files in `Data/Decoration/Monopoly/`. See [Admin and Settings](admin-and-settings.md).

## Related Pages

- [Vendors](vendors.md) — rental contracts and vendor system
- [Admin and Settings](admin-and-settings.md) — `[Monopoly` command
- [Ownership and Access](ownership-and-access.md) — access rules in rented spaces

---

**Source references:** `World/Source/Scripts/Items/Houses/Monopoly/Items/TownHouse.cs`, `TownHouseSign.cs`, `RentalContract.cs`, `Misc/General.cs`, `Decorate.cs`
