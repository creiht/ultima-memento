# Housing

Player housing in Ultima Memento is one of the server's most expansive systems. Houses serve as personal storage, crafting workshops, vendor shops, and a canvas for decoration and exterior landscaping. The system spans classic pre-built structures, fully customizable foundations, tent-style dwellings, giant keeps and castles, exterior lawn and shanty remodeling, a Monopoly-style town-house rental system, and a rich set of admin controls.

## Quick Facts

| Setting | Default | Notes |
|---|---|---|
| Houses per account | 2 | `S_HousesPerAccount = 2` |
| Decay enabled | No | `S_HousesDecay = false` — all houses are Ageless |
| Custom foundations | Yes | `S_AllowCustomHomes = true` |
| Lawn system | Yes | `S_LawnsAllowed = true` |
| Shanty remodeling | Yes | `S_ShantysAllowed = true` |
| Basements | Yes | `S_Basements = true` |
| House dyes | No | `S_AllowHouseDyes = false` |
| Storage unlimited | No | `S_HouseStorage = false` |
| Mounts inside houses | No | `S_NoMountsInHouses = true` |

## Table of Contents

| Page | What it covers |
|---|---|
| [Getting Started](getting-started.md) | Quick-start guide: buy a deed, place a house, first steps |
| [Placement](placement.md) | Placement rules, construction contracts vs deeds, restrictions |
| [House Types](house-types.md) | Full table of every classic house — storage, lockdowns, vendors, cost |
| [Custom Foundations](custom-foundations.md) | 2-story and 3-story sizes, foundation materials, design mode |
| [Ownership and Access](ownership-and-access.md) | Owner, Co-Owner, Friend, Access, Ban lists; transfers; public/private |
| [Lockdowns and Secures](lockdowns-and-secures.md) | Lockdown rules, secure containers, StrongBox, storage accounting |
| [Decay and Refresh](decay-and-refresh.md) | Decay levels, IDOC, refresh triggers, Ageless setting |
| [Vendors](vendors.md) | Player vendors, barkeepers, rental contracts, Advertiser Vendor |
| [Addons](addons.md) | Functional and decorative addons, Interior Decorator, key addon list |
| [Lawn and Remodeling](lawn-and-remodeling.md) | Lawn System and Shanty System, architect tools |
| [Doors and Security](doors-and-security.md) | House doors, security levels, key system, special doors |
| [House Components](house-components.md) | Sign, Teleporter, Moving Crate, Mailbox, Magical Rope, Tavern Table |
| [Tents](tents.md) | Blue/Green Tent, Large Tent, tent addons, Gypsy Camp Addon |
| [Carpets](carpets.md) | Magic Carpet A–I flying vehicles |
| [Town Houses (Monopoly)](town-houses-monopoly.md) | Staff-designated rental properties, rental contracts, AllTownHouses gump |
| [Admin and Settings](admin-and-settings.md) | GM commands and all `Settings.cs` housing flags |

## Related Wiki Sections

- [Crafting — Carpentry](../crafting/carpentry.md) — crafts many addon deeds
- [Crafting — Masonry](../crafting/masonry.md) — crafts stone addon deeds
- [Items — Deeds](../items/deeds.md) — deed item category overview
- [Commands](../commands/README.md) — player and admin commands reference

---

**Source references:** `World/Info/Scripts/Settings.cs` (category 009)
