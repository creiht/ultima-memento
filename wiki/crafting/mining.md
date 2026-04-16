# Mining

Mining extracts ore, granite, sand, and gemstones from the earth. It is the supply chain for [Blacksmithy](blacksmithy.md), [Tinkering](tinkering.md), [Masonry](masonry.md), [Lapidary](lapidary.md), [Wands](wands.md), and [Glassblowing](glassblowing.md).

- **Skill**: Mining
- **Tool**: Pickaxe or Spade
- **Range**: Must be within 2 tiles of a mountain, cave wall, or sand tile

## How It Works

- Target a mountain or cave wall to mine ore and stone
- Target sand tiles (beaches) to mine sand for Glassblowing
- Resource banks are 8×8 tiles and respawn every 10–20 minutes
- Each bank holds 5–17 ore units
- Higher Mining skill unlocks rarer ore types
- At 100+ Mining with the Stone Mining toggle enabled, you have a 10% chance per swing to get granite instead of ore

## Standard Ore Tiers

All ore veins are available on any mining tile. The mutation system (see below) can replace Agapite/Verite/Valorite ore with a region-specific premium ore in certain areas.

The armor/weapon bonus columns show the bonus resistances each material grants to crafted items.

| Ore | Min Mine Skill | Vein % | Hue | Arm | Phy | Fir | Cld | Psn | Egy | Wep Cold | Wep Fire | Wep Egy | Wep Psn | Durability | Luck | Lower Req |
|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|
| Iron | 0.0 | 45% | default | 0 | 0 | 0 | 0 | 0 | 0 | — | — | — | — | — | — | — |
| Dull Copper | 65.0 | 16% | 0x436 | +1 | +2 | +1 | +1 | +1 | +1 | — | — | — | — | +75 | — | 35 |
| Shadow Iron | 70.0 | 11% | 0x445 | +2 | +3 | +3 | +3 | +2 | +2 | — | — | — | — | +75 | — | — |
| Copper | 75.0 | 8% | 0x435 | +3 | +3 | +3 | +3 | +3 | +2 | — | — | +20 | +10 | +25 | — | — |
| Bronze | 80.0 | 6% | 0x433 | +4 | +3 | +3 | +3 | +3 | +3 | — | +40 | — | — | +30 | — | — |
| Gold | 85.0 | 5% | 0x43A | +5 | +4 | +3 | +3 | +3 | +3 | — | — | — | — | +30 | +40 | — |
| Agapite | 90.0 | 4% | 0x424 | +6 | +4 | +4 | +3 | +3 | +3 | +30 | — | +20 | — | +25 | — | — |
| Verite | 95.0 | 3% | 0x44C | +7 | +4 | +4 | +4 | +3 | +3 | — | — | +20 | +40 | +25 | — | — |
| Valorite | 99.0 | 2% | 0x44B | +8 | +4 | +4 | +4 | +4 | +3 | +20 | +10 | +20 | +10 | +40 | — | — |

> **Craft skill** required to use each ore in Blacksmithy is approximately the same as the mining skill (Iron = 0, Dull Copper = 65, … Valorite = 99). Source: `ResourceInfo.cs:364–379`, `Mining.cs:80–103`.

## Facet-Specific Ore Mutations

When you mine an Agapite, Verite, or Valorite vein, there is a **50% chance** the ore mutates into the premium ore of your current region. The mutation only applies to those three tiers.

| Region / Condition | Premium Ore |
|---|---|
| Sea areas, Shipwreck Grotto, Barnacled Cavern, sea towns | Nepturite |
| Serpent Island (Land.Serpent) | Obsidian |
| Savaged Empire (Land.Savaged) | Steel |
| Umber Veil (Land.UmberVeil) | Brass |
| Underworld on Savaged Empire map | Xormite |
| Underworld on other maps | Mithril |

The same mutation applies to **granite** when Stone Mining is active.

### Premium Ore Properties

| Ore | Min Mine Skill | Hue | Arm | Phy | Fir | Cld | Psn | Egy | Wep | Durability | Luck | Lower Req |
|---|---|---|---|---|---|---|---|---|---|---|---|---|
| Nepturite | 99.0 | 0x43F | +9 | +4 | +4 | +4 | +4 | +4 | Cold +25 / Psn +25 | +40 | — | — |
| Obsidian | 99.0 | 0x440 | +9 | +5 | +4 | +4 | +4 | +4 | Fire +20 / Egy +10 | +40 | — | — |
| Steel | 105.0 | 0x449 | +10 | +5 | +5 | +4 | +4 | +4 | — | +50 | — | — |
| Brass | 105.0 | 0x432 | +11 | +5 | +5 | +5 | +4 | +4 | Fire +20 / Egy +20 | +55 | — | — |
| Mithril | 115.0 | 0x43E | +12 | +5 | +5 | +5 | +5 | +4 | Egy +30 | +100 | +100 | 50 |
| Xormite | 115.0 | 0x44D | +12 | +5 | +5 | +5 | +5 | +5 | Egy +30 | — | — | 25 |
| Dwarven | 125.0 | 0x437 | +14 | +6 | +5 | +5 | +5 | +5 | — | +100 | — | 10 |

Source: `HarvestSystem.cs:257–298`, `ResourceInfo.cs:373–379`.

## Rich Vein Nodes

Admin-placed Rich Vein nodes produce the same tier distribution as standard mining PLUS the **Dwarven** ore tier (items 0x176C / 0x178A), which cannot be obtained any other way in the field. All standard Iron–Valorite types are also available from rich veins.

Source: `RichVeinMining.cs:57–85`, `RichVeinConfig.cs`.

## Special Region Bonuses

- **The Mines of Morinia** (Sosaria): 2-in-3 chance (+66%) that your ore yield uses the `ConsumedPerIslesDreadHarvest` formula instead of the base amount.
- **Isles of Dread**: All harvesting (ore, wood, sand) uses the boosted `ConsumedPerIslesDreadHarvest` formula: base + ceil(base/2) + 2.

Source: `HarvestSystem.cs:252`, `Mining.cs:63`.

## Granite (Stone Mining)

With the **Stone Mining** toggle enabled and 100.0+ Mining skill, each swing has a **10% chance** to yield granite of the same tier as the ore vein you hit. Granite types mirror ore tiers (Iron Granite, Dull Copper Granite, … Dwarven Granite). Granite is used in [Masonry](masonry.md).

## Raw Gemstones (Lapidary)

With 90.0+ Mining, each swing has a **0.1% chance each** (independent rolls) to yield one of the following raw gemstones:

Amber, Amethyst, Citrine, Diamond, Emerald, Ruby, Sapphire, Star Sapphire, Tourmaline

Raw gemstones are used in [Lapidary](lapidary.md) jewelry recipes. See that page for details.

Source: `Mining.cs:111–123`.

## Sand Mining

- **Requires**: 100.0 Mining skill, Pickaxe or Spade, **Sand Mining toggle** enabled
- **Tiles**: Beach/sand tiles only
- **Bank size**: 6–12 sand per bank
- **Respawn**: 10–20 minutes
- Sand is used in [Glassblowing](glassblowing.md) to craft bottles, vials, and glass items

Source: `Mining.cs:132–188`.

## Sci-Fi Metals

Sci-fi metals are **not** mined from the ground. They are harvested by carving droids and alien constructs in [Kuldar](../world/sosaria.md#kuldar-bottle-world), the ancient sky ship, and sci-fi themed dungeons. Any creature with `MetalType.SciFi` drops one random sci-fi ingot per carve.

**Eligible creature types**: Battle Droids, Combat Droids, Excavation Droids, Maintenance Droids, Security Droids, Service Droids.

All 16 sci-fi metals share the same base stats: Arm +13, all resistances +4, Durability +80, Lower Requirements 25. Each has a unique weapon element specialty as noted below.

| Metal | Hue | Min Craft Skill | Weapon Bonus |
|---|---|---|---|
| Agrinium | 0x8C1 | 117.0 | — |
| Beskar | 0x6F8 | 117.0 | Fire +10 |
| Carbonite | 0x829 | 117.0 | — |
| Cortosis | 0x82C | 117.0 | Energy +25 |
| Durasteel | 0x7A9 | 117.0 | — |
| Durite | 0x877 | 117.0 | — |
| Farium | 0x775 | 117.0 | Fire +35 |
| Laminasteel | 0x77F | 117.0 | Poison +25 |
| Neuranium | 0x870 | 117.0 | Fire +25 |
| Phrik | 0xAF8 | 117.0 | Energy +35 |
| Promethium | 0x6F6 | 117.0 | Poison +35 |
| Quadranium | 0x705 | 117.0 | Cold+10/Fire+10/Egy+10/Psn+10 |
| Songsteel | 0xB42 | 117.0 | — |
| Titanium | 0xB70 | 117.0 | — |
| Trimantium | 0x8C3 | 117.0 | Cold +50 |
| Xonolite | 0x701 | 117.0 | Fire +50 |

Source: `ResourceInfo.cs:380–395`, `BaseCreature.cs:4784–4806`.

## Ship Cargo — Alternate Ore Sources

Certain ore crates can also be obtained from ship cargo holds while seafaring. See [Fishing](fishing.md) for details on ship cargo looting.

Source: `Items/Boats/Cargo.cs:497–501`.
