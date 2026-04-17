# Addons

An **addon** is a multi-tile object placed inside (or just outside) a house via a deed. On demo­lition or customization, the addon reverts to its deed form and is placed in the Moving Crate. Most addons are crafted via [Carpentry](../crafting/carpentry.md), [Masonry](../crafting/masonry.md), or other crafting professions, or purchased from vendors.

## Functional Addons

Functional addons provide an in-game utility beyond decoration.

| Addon | Function |
|---|---|
| Forge | Blacksmithing smelting station |
| Anvil (East / South) | Blacksmithing crafting station |
| Spinning Wheel (East / South) | Produces thread and yarn |
| Loom (East / South) | Produces cloth |
| Flour Mill (East / South) | Converts grain to flour |
| Water Trough (East / South) | Water source for crafting |
| Training Dummy (East / South) | Weapon skill training at home |
| Archery Butte (East / South) | Archery skill training at home |
| Alchemist Table | Alchemy crafting surface |
| Arcane Bookshelf | Focuses arcane energy; used in certain magic systems |
| Arcane Circle | Spellcasting focus for certain magic systems |
| Pentagram (BloodPentagram) | Necromancy focus |
| Abattoir | Necromancy focus/altar |
| Ballot Box | Players can vote on house matters |

## Decorative Addons

Decorative addons are organized under `World/Source/Scripts/Items/Houses/Construction/Decorations/`:

| Category | Examples |
|---|---|
| Chairs | Various chair styles |
| Floors | Tile floor patterns |
| Lights | Candelabras, fireplaces, lanterns |
| Misc | Display cases, statues, fountains, chests |
| Signs | Hanging signs and plaques |
| Tables | Various table styles |
| Walls | Wall panels and separators |
| Wells | Stone and wooden wells |
| Trees | Decorative trees and plants |
| Treasure Piles | Coin and gem piles |
| Ruined | Cracked walls, rubble, damaged furniture |
| Oriental Items | Eastern-styled furniture |
| Pillows | Cushioned seating |
| Monster Statues | Large creature statue addons |
| Bear Rugs | Mounted bear-skin rugs |

## Interior Decorator / Homeowner Tools

The **Interior Decorator** (item graphic 0x1EBA) lets the owner and co-owners manipulate unlocked items and addon deeds inside the house.

| Button | Action |
|---|---|
| Turn | Rotate the targeted item 45° |
| Up | Raise the item 1 Z-level |
| Down | Lower the item 1 Z-level |
| North | Move item north 1 tile |
| East | Move item east 1 tile |
| South | Move item south 1 tile |
| West | Move item west 1 tile |
| Lock | Lock down the targeted item |
| Secure | Secure the targeted container |
| Release | Release a locked-down item |
| Flip Deed | Flip a deed to the opposite facing (e.g., East ↔ South); works on most deed-like items including tents and bear rugs |
| Trash | Delete the targeted item |
| Close | Close the gump |

Source: `InteriorDecorator.cs:117–185`

## Placing and Removing Addons

- **Place:** Double-click the addon deed inside your house. The addon appears at your targeted location.
- **Remove / Flip:** Use the Interior Decorator "Flip Deed" option to change facing before placing, or target the addon with a deed demolition tool.
- Addons placed with a hue retain that hue if `RetainDeedHue` is set on the addon class.

## Related Pages

- [Crafting — Carpentry](../crafting/carpentry.md)
- [Crafting — Masonry](../crafting/masonry.md)
- [House Components](house-components.md) — Moving Crate (receives addons on demolish)
- [Lawn and Remodeling](lawn-and-remodeling.md) — exterior items placed outside the house

---

**Source references:** `World/Source/Scripts/Items/Houses/Construction/`, `World/Source/Scripts/Items/Houses/InteriorDecorator.cs`
