# Lapidary

Lapidary is gemstone crafting — creating weapons and armor from gemstone blocks. Requires 65+ Blacksmithing and must be done at a specific location in the Savaged Empire near an anvil and forge.

- **Skill**: Blacksmithing (minimum 65.0)
- **Tool**: Lapidary tools
- **Primary Resource**: Gemstone Blocks (Amethyst and higher tiers)
- **Facility Required**: Anvil and Forge in Savaged Empire workshop
- **Supports**: Repair, Breakdown, Enhancement

## Gemstone Block Tiers

All 15 blocks share Arm +12, Dmg +3 base. The Armor columns show bonus resistances and the Weapon columns show bonus elemental damage on crafted items. Durability bonus is +100 for all standard blocks; Caddellite is +200.

| Block | Min Craft Skill | Hue | Phy | Fir | Cld | Psn | Egy | Wep Cold | Wep Fire | Wep Egy | Wep Psn | Durability | Luck |
|---|---|---|---|---|---|---|---|---|---|---|---|---|---|
| Amethyst | 85.0 | 0x8D5 | +3 | +3 | +2 | +2 | +2 | — | — | +25 | — | +100 | +10 |
| Emerald | 85.0 | 0x950 | +3 | +3 | +3 | +2 | +2 | — | — | — | +25 | +100 | — |
| Garnet | 85.0 | 0x4A2 | +3 | +3 | +3 | +3 | +2 | — | — | +10 | +10 | +100 | +5 |
| Ice | 85.0 | 0x8E2 | +3 | +3 | +3 | +3 | +3 | +50 | — | — | — | +100 | — |
| Jade | 85.0 | 0xB0C | +4 | +3 | +3 | +3 | +3 | — | +10 | — | +20 | +100 | +40 |
| Marble | 85.0 | 0xB3B | +4 | +4 | +3 | +3 | +3 | — | — | — | — | +150 | — |
| Onyx | 85.0 | 0xB5E | +4 | +4 | +4 | +3 | +3 | +20 | +20 | +20 | +20 | +100 | +30 |
| Quartz | 85.0 | 0x869 | +4 | +4 | +4 | +4 | +3 | — | +25 | +25 | — | +100 | — |
| Ruby | 85.0 | 0x982 | +4 | +4 | +4 | +4 | +4 | — | +60 | — | — | +100 | +10 |
| Sapphire | 85.0 | 0x5CE | +5 | +4 | +4 | +4 | +4 | — | +30 | — | — | +100 | — |
| Silver | 85.0 | 0xB2A | +5 | +5 | +4 | +4 | +4 | +20 | +20 | +20 | +20 | +100 | +20 |
| Spinel | 85.0 | 0x7CB | +5 | +5 | +5 | +4 | +4 | — | — | +30 | — | +100 | — |
| Star Ruby | 85.0 | 0x7CA | +5 | +5 | +5 | +5 | +4 | — | +15 | +15 | — | +100 | +10 |
| Topaz | 85.0 | 0x856 | +5 | +5 | +5 | +5 | +5 | — | — | +20 | +20 | +100 | — |
| Caddellite | 115.0 | 0x99D | +6 | +5 | +5 | +5 | +5 | — | — | +50 | — | +200 | — |

Source: `ResourceInfo.cs:502–519`.

## Sources

Gemstone blocks (raw stone form) are carved from elemental and golem creature types.

| Block Source | Creatures |
|---|---|
| Earth/gem elementals | Earth Elementals, Gem Elementals, various golem variants, rock creatures (use `RockType` matching the block type) |
| Any mixed stone drop | `RockType.Stones` carve yields a random ore ore from Iron–Xormite (mixed) |
| Any crystal drop | `RockType.Crystals` carve yields a random gem stone from the 15 types |
| Ruby Pickaxe use | Yields Caddellite drop (Caddellite Dragon) |
| Silver Stone | Also obtainable via DropRelic (`DropRelic.cs:247`) |

Source: `BaseCreature.cs:4682–4696`, `RubyPickaxe.cs:128`, `DropRelic.cs:247`.

## Raw Gems (Lapidary Jewelry)

Raw gems (Amber, Amethyst, Citrine, Diamond, Emerald, Ruby, Sapphire, Star Sapphire, Tourmaline) are distinct from gemstone blocks and come from [Mining](mining.md) at 90+ skill (0.1% each per swing). They are used in jewelry crafting recipes within Lapidary.

## Items

Lapidary produces the same armor, weapons, shields, and helmets as Blacksmithy, but using Gemstone Blocks instead of Metal Ingots. This includes:

- **Chain/Ringmail** (9 pieces, 10–20 blocks)
- **Platemail** (12 pieces, 10–28 blocks)
- **Royal Armor** (7 pieces, 10–25 blocks)
- **Helmets** (14 types, 15–25 blocks)
- **Shields** (17 types, 8–25 blocks)
- **Bladed Weapons** (30 types, 3–25 blocks)
- **Axes** (8 types, 12–16 blocks)
- **Polearms** (12 types, 12–20 blocks)
- **Bashing Weapons** (10 types, 6–16 blocks)

See [Blacksmithy](blacksmithy.md) for the full item list — items and skill requirements are identical but use gemstone blocks instead of ingots.

## See Also

- [Mining](mining.md) — raw gemstones (bonus drops at 90+ skill)
- [Blacksmithy](blacksmithy.md) — metal ingot equivalent recipes
