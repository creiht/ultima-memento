# Lumberjacking

Lumberjacking harvests logs from trees, which are then processed into boards for use in [Carpentry](carpentry.md), [Bow Fletching](bowfletching.md), and [Shelves](shelves.md).

- **Skill**: Lumberjacking
- **Tool**: Hatchet (must be equipped)
- **Range**: Must be within 2 tiles of a tree

## How It Works

- Equip a hatchet and target a tree
- Resource banks are per-tree (1×1 tiles), holding 4–6 logs each
- Trees respawn every 20–30 minutes
- Higher skill unlocks rarer wood types
- In certain regions, standard wood tiers mutate into region-specific premium wood (see below)

## Standard Wood Tiers

| Wood | Min Skill | Vein % | Hue | Arm | Phy | Fir | Cld | Psn | Egy | Wep Cold | Wep Fire | Wep Egy | Wep Psn | Durability | Luck | Lower Req |
|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|
| Regular | 0.0 | 30% | default | 0 | 0 | 0 | 0 | 0 | 0 | — | — | — | — | — | — | — |
| Ash | 55.0 | 16% | 0x509 | +1 | +2 | +2 | +2 | +1 | +1 | +5 | +5 | +5 | +5 | +10 | — | 35 |
| Cherry | 60.0 | 10% | 0x50A | +2 | +3 | +3 | +3 | +3 | +2 | — | — | +20 | +10 | +25 | — | — |
| Ebony | 65.0 | 9% | 0x50B | +3 | +3 | +3 | +3 | +3 | +3 | +20 | — | — | — | +40 | — | — |
| Golden Oak | 70.0 | 8% | 0x50E | +4 | +4 | +3 | +3 | +3 | +3 | — | — | — | — | +20 | +40 | — |
| Hickory | 75.0 | 7% | 0x508 | +5 | +4 | +4 | +3 | +3 | +3 | — | — | — | — | +50 | — | — |
| Mahogany | 80.0 | 6% | 0x50F | +6 | +4 | +4 | +4 | +3 | +3 | — | — | +20 | +10 | +55 | — | — |
| Oak | 85.0 | 5% | 0x510 | +7 | +4 | +4 | +4 | +4 | +3 | — | +40 | — | — | +55 | — | — |
| Pine | 90.0 | 4% | 0x512 | +8 | +4 | +4 | +4 | +4 | +4 | +30 | — | +20 | — | +60 | — | — |
| Rosewood | 95.0 | 3% | 0x513 | +10 | +5 | +5 | +4 | +4 | +4 | — | — | +20 | +40 | +60 | — | — |
| Walnut | 100.0 | 2% | 0x514 | +11 | +5 | +5 | +5 | +4 | +4 | +20 | +10 | +20 | +10 | +65 | — | — |

Source: `ResourceInfo.cs:463–474`, `Lumberjacking.cs:78–106`.

## Location-Specific Log Mutations

When you chop a non-Regular wood vein, certain regions can mutate the result. The mutation only applies if the base wood is one of the tiers listed.

| Region / Condition | Replaces | Premium Wood |
|---|---|---|
| Sea areas, Shipwreck Grotto, Barnacled Cavern (50% chance) | Any non-Regular | Driftwood |
| NecromancerRegion (lower tiers: Ash/Cherry/Golden Oak/Hickory/Mahogany) | Those five tiers | Ebony |
| NecromancerRegion (higher tiers: Oak/Pine/Rosewood/Walnut) | Those four tiers | Ghostwood |
| Underworld (any map) | Any non-Regular | Petrified |

Source: `HarvestSystem.cs:347–379`.

### Premium Wood Properties

| Wood | Min Skill | Hue | Arm | Phy | Fir | Cld | Psn | Egy | Wep | Durability | Luck | Lower Req |
|---|---|---|---|---|---|---|---|---|---|---|---|---|
| Ghostwood | 105.0 | 0x50D | +9 | +5 | +4 | +4 | +4 | +4 | Cold+25 / Egy+25 | +60 | — | — |
| Petrified | 115.0 | 0x511 | +12 | +5 | +5 | +5 | +5 | +4 | Fire +25 | +70 | — | — |
| Driftwood | 115.0 | 0x507 | +13 | +5 | +5 | +5 | +5 | +5 | Cold+10/Fire+10/Egy+10/Psn+20 | +80 | — | — |
| Elven | 125.0 | 0x50C | +14 | +6 | +5 | +5 | +5 | +5 | — | +100 | +100 | — |

## Rich Lumberjacking Sparkle Nodes

Admin-placed glowing (sparkle) nodes are the **only** source of **Elven** wood. Requires 100.1+ Lumberjacking skill; Elven vein is ~2.5% chance per swing at these nodes. All standard Regular–Walnut tiers are also available at sparkle nodes.

Source: `RichLumberjacking.cs:28–109`.

## Bonus Resources

While lumberjacking, you may also find:
- **Bark Fragments** (90+ skill, ~10% chance) — used in [Cartography](cartography.md) and crafting blank scrolls
- **Mushrooms** (100+ skill, ~1% chance)

## Processing Logs

Logs must be converted to boards (using a saw mill or by using an axe on them) before they can be used in crafting.

## Sci-Fi Woods

Sci-fi woods are **not** harvested from trees. They drop from sci-fi creatures and may also come from ship cargo crates. Any creature with the appropriate `WoodType` (SciFi) yields one of these boards when carved.

All 8 sci-fi woods share the same base stats: Arm +15, all resistances +4, Durability +80. Cosian also grants Luck +50; Kyshyyyk grants Durability +100 (higher than the others).

| Wood | Hue | Min Craft Skill | Notable Bonus |
|---|---|---|---|
| Borl | 0x775 | 115.0 | — |
| Cosian | 0x77F | 115.0 | Luck +50 |
| Greel | 0x870 | 115.0 | — |
| Japor | 0x948 | 115.0 | — |
| Kyshyyyk | 0x705 | 115.0 | Durability +100 |
| Laroon | 0x877 | 115.0 | — |
| Teej | 0x6F6 | 115.0 | — |
| Veshok | 0x6F8 | 115.0 | — |

Source: `ResourceInfo.cs:478–485`.
