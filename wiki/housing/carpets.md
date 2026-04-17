# Magic Carpets

> **Clarification:** The "Carpets" system in the source (`World/Source/Scripts/Items/Houses/Carpets/`) refers to **flying / sailing Magic Carpets** — vehicles that behave like boats but travel through the air. They are **not** decorative floor carpets. Decorative floor covering tiles are standard addon items found in the Floors category under [Addons](addons.md).

## Overview

Magic Carpets A through I are vehicle multis derived from `BaseBoat`. They function like boats (commands, docking, decay) but use carpet graphics and fly rather than sail on water. Each carpet type has a deed and a docked form.

## Carpet Types

| Carpet | Deed Class | Docked Class |
|---|---|---|
| Magic Carpet A | `MagicCarpetADeed` | `MagicDockedCarpetA` |
| Magic Carpet B | `MagicCarpetBDeed` | `MagicDockedCarpetB` |
| Magic Carpet C | `MagicCarpetCDeed` | `MagicDockedCarpetC` |
| Magic Carpet D | `MagicCarpetDDeed` | `MagicDockedCarpetD` |
| Magic Carpet E | `MagicCarpetEDeed` | `MagicDockedCarpetE` |
| Magic Carpet F | `MagicCarpetFDeed` | `MagicDockedCarpetF` |
| Magic Carpet G | `MagicCarpetGDeed` | `MagicDockedCarpetG` |
| Magic Carpet H | `MagicCarpetHDeed` | `MagicDockedCarpetH` |
| Magic Carpet I | `MagicCarpetIDeed` | `MagicDockedCarpetI` |

Source: `World/Source/Scripts/Items/Houses/Carpets/MagicCarpet[A–I].cs`

## Deck and Area

Each carpet variant has its own interior `Rectangle2D` area (the "deck" players stand on). These vary by carpet size — smaller carpets have an 8×8 area, larger ones have up to 31×32.

## Decay

Magic Carpets decay as boats. Boat decay: `S_BoatDecay = 365.0` days (default).

When a carpet decays or is demolished, it generates a `BaseDockedBoat` deed form that the owner can use to re-deploy it.

## Related Pages

- [Items — Boats](../items/boats.md) — base boat mechanics (carpets share the boat system)
- [Admin and Settings](admin-and-settings.md) — `S_BoatDecay` setting

---

**Source references:** `World/Source/Scripts/Items/Houses/Carpets/`, `World/Info/Scripts/Settings.cs:635`
