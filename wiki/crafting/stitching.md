# Stitching

Stitching creates leather armor and accessories from exotic creature skins. Requires 65+ Tailoring and must be done at a specific workshop in the Savaged Empire.

- **Skill**: Tailoring (minimum 65.0)
- **Tool**: Sewing Kit
- **Primary Resource**: Demon Skins (and other exotic skins)
- **Location Requirement**: Savaged Empire stitching workshop
- **Supports**: Repair, Breakdown, Enhancement

## Skin Tiers

All skins share Arm base stats. The table shows armor resistance bonuses, weapon bonuses, and luck on crafted items. Min Craft Skill is the Tailoring level needed to work each skin.

| Skin | Min Craft Skill | Hue | Phy | Fir | Cld | Psn | Egy | Wep | Durability | Luck |
|---|---|---|---|---|---|---|---|---|---|---|
| Demon | 65.0 | 0xB1E | +2 | 0 | +3 | +2 | +2 | Fire +50 | +50 | +20 |
| Dragon | 65.0 | 0x960 | +2 | +2 | +2 | +2 | +2 | Cold+20/Fire+20/Egy+20/Psn+20 | +50 | — |
| Nightmare | 65.0 | 0xB80 | +2 | 0 | +3 | 0 | +3 | Fire +30 | +40 | — |
| Snake | 65.0 | 0xB79 | +4 | 0 | 0 | +4 | 0 | Poison +50 | +60 | — |
| Troll | 65.0 | 0xB4C | +4 | +1 | 0 | +3 | 0 | — | +60 | — |
| Unicorn | 65.0 | 0xBB4 | +2 | 0 | 0 | +2 | +4 | Energy +50 | +30 | +50 |
| Icy | 75.0 | 0xB7A | +4 | +5 | 0 | +2 | +2 | Cold +50 | +30 | — |
| Lava | 75.0 | 0xB17 | +4 | 0 | +5 | +2 | +2 | Fire +80 | +40 | — |
| Seaweed | 75.0 | 0x98D | +4 | +2 | +1 | +4 | +2 | Poison +25 | +20 | — |
| Dead | 75.0 | 0xB4A | +2 | +4 | +1 | +4 | +2 | Poison +60 | +40 | — |

Source: `ResourceInfo.cs:520–531`.

## Creature Sources

Skins are carved from creature corpses.

| Skin | Sources |
|---|---|
| Demon | All demons: Daemon, Balron, Devil, Archfiend, Xurtzar, Satan, MutantDaemon, BlackGateDemon, BloodDemon, ClassicBalron/Daemon, DeepSeaDevil, DemonOfTheSea, IceDevil |
| Dragon | All dragons: Dragons, AsianDragon, RidingDragon, Drakkhen, Dragonogre, BottleDragon, DragonKing, ElderDragon, RadiationDragon, VoidDragon, Primeval dragons, SeaDragon (50%) |
| Nightmare | Nightmare horses |
| Snake | Large/giant snakes |
| Troll | Trollbear |
| Unicorn | Unicorn |
| Icy | Ice Devil |
| Lava | Lava creatures |
| Seaweed | Sea Dragon (50%) |
| Dead | Flesh Golems, Skin Golems |

Source: `BaseCreature.cs:4642–4651`, SkinType enum `BaseCreature.cs:178–190`.

## Footwear

Same items as Leatherworking but crafted from Demon Skins: Leather Sandals (42.4), Leather Shoes (56.5), Leather Boots (63.1), Leather Thigh Boots (71.4), Soft Leather Boots (81.4), Hiking Boots (83.1), Oniwaban Boots (81.4).

## Leather Armor

Same leather armor as Leatherworking but using Demon Skins as the base material, including all standard leather pieces and ninja/shinobi/oniwaban sets.

## Studded Armor

Same studded armor set as Leatherworking using Demon Skins (78.8–94.0 skill).

## Miscellaneous

Pugilist Gloves, Throwing Gloves, Whip, and animal-skin caps (Bear, Deer, Stag, Wolf).

## See Also

- [Leatherworking](leatherworking.md) — standard leather hides and sci-fi leathers
- [Draconic](draconic.md) — reptile scales
