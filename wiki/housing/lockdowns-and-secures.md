# Lockdowns and Secures

Houses have two storage mechanisms: **lockdowns** (items fixed in place on the floor) and **secure containers** (containers with role-based access and their own item budget).

## Lockdown Mechanics

To lock an item down: stand inside the house, say **"I wish to lock this down"**, then single-click the item. Alternatively, use the house management gump.

To release a locked item: say **"I wish to release this"** and click the item.

Rules:
- Only the **Owner** and **Co-Owners** can lock or release items.
- Each locked item (or item inside a locked-down container) counts as 1 toward the lockdown total.
- Container contents are recursively counted — locking a container locks everything inside it.
- A container must be locked down before you can lock anything inside it.
- The following cannot be locked: `HouseSign`, Static tiles, `AddonComponent`.

Speech keywords (hex):
| Speech | Action |
|---|---|
| `0x0023` | Lock down |
| `0x0024` | Release |
| `0x0025` | Secure |
| `0x0028` | Trash barrel |

## Secure Containers

A secure container is a locked-down container with a **SecureLevel** setting controlling who can open it:

| SecureLevel | Who can access |
|---|---|
| Owner | Owner only |
| CoOwners | Owner and Co-Owners |
| Friends | Owner, Co-Owners, and Friends |
| Anyone | Anyone (including visitors) |
| Guild | Guild members |

To secure a container: say **"I wish to secure this"** then target a container. Only the Owner can secure containers.

### StrongBox

Each Co-Owner gets one **StrongBox** — a personal secure container that counts as 1 lockdown slot but provides private storage just for that co-owner.

## Storage Accounting (AOS Mode)

When `S_HouseStorage = false` (default), the house enforces a storage limit.

**AOS total storage** = `HousePlacementEntry.Storage` (from placement entry)

**AOS current usage** = secure-container item count + vendor backpack item count + lockdown count + moving crate items

If `S_HouseStorage = true`, storage is effectively unlimited (no enforcement).

**Non-AOS mode** (if AOS disabled):
- Each secure container = 125 storage slots.
- Each StrongBox = 1 storage slot.
- Each player vendor = 10 storage slots.

## What Locked-Down Items Can Be Used

Certain locked-down item types are interactable by specific roles without requiring the item to be un-locked. Relevant entries from `BaseHouse.cs:988–1048`:

| Item Type | Who Can Use |
|---|---|
| Runebook | Co-Owners and Friends (read) |
| Container | Co-Owners (open) |
| Light source | Anyone (visual only) |
| Bulletin board | Friends (read) |
| Dye tub | Friends |
| Rental contract | Friends (collect rent) |
| Ballot Box | Anyone (vote) |
| Training dummy | Anyone (practice) |
| Archery butte | Anyone (practice) |

## Related Pages

- [Ownership and Access](ownership-and-access.md) — who has which role
- [House Types](house-types.md) — storage and lockdown limits per house
- [House Components](house-components.md) — Moving Crate details
- [Admin and Settings](admin-and-settings.md) — `S_HouseStorage` flag

---

**Source references:** `World/Source/Scripts/Items/Houses/BaseHouse.cs:988–1048`, `BaseHouse.cs:1917–1950`, `World/Info/Scripts/Settings.cs:673`
