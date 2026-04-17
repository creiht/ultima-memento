# Vendors

Houses support player vendors, barkeepers, rental contracts, and the world-wide Advertiser Vendor directory.

## Player Vendors

Placing a player vendor in your house:

1. Stand inside your house.
2. Say **"I wish to place a vendor"** (or use the context menu on the house sign).
3. The vendor is placed and you can stock it with items, set prices, and configure it.

Vendors count against the house's vendor slot limit (`Vendors` in [House Types](house-types.md)).

**New vendor system** (AOS mode — active on this server): The vendor count is tracked by `CanPlaceNewVendor()`:

```
(PlayerVendors.Count + VendorRentalContracts.Count) < GetNewVendorSystemMaxVendors()
```

Each vendor's backpack items are counted in the [storage accounting](lockdowns-and-secures.md) total.

## Barkeepers

Player Barkeepers are special NPCs that serve as scripted flavor characters behind a bar. They can be configured with dialogue lines.

- Limit: **2 barkeepers per house** (`MaximumBarkeepCount = 2`, `BaseHouse.cs:367`).
- Placed similarly to vendors.

## Rental Contracts

An owner can rent out a portion of their house to another player using rental contracts.

**To create a rental contract:**
1. Stand inside your own house.
2. Say **"create rental contract"**.
3. A `VendorRentalContract` item is created; configure the rent amount, lockdown/secure allocation, and duration.
4. Give the contract to the renter. They sign it to gain access to their sub-portion.

Rental contracts count toward the vendor slot total.

## Advertiser Vendor

The **Advertiser Vendor** (`AdvertiserVendor.cs`, graphics 0x577C / 0x577B) is a world-wide player-vendor directory. Double-click one to browse all active player vendors across the server.

- Results are displayed **12 vendors per page**.
- Filtered by avatar mode and permadeath mode — you only see vendors in your current play mode.
- These vendors are placed as decorative NPCs (not normal player vendor mobiles) and simply point to the vendor directory.

## Related Pages

- [Lockdowns and Secures](lockdowns-and-secures.md) — vendor storage accounting
- [Town Houses (Monopoly)](town-houses-monopoly.md) — staff-designated rental buildings
- [House Types](house-types.md) — vendor slot limits per house type
- [Decay and Refresh](decay-and-refresh.md) — DemolitionPending when vendors present at collapse

---

**Source references:** `World/Source/Scripts/Items/Houses/BaseHouse.cs:307–371`, `World/Source/Scripts/Items/Houses/AdvertiserVendor.cs`
