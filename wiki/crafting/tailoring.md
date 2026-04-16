# Tailoring

Tailoring creates cloth clothing, hats, robes, and accessories from fabric. This page is the authoritative reference for all fabric material tiers.

- **Skill**: Tailoring
- **Tool**: Sewing Kit
- **Primary Resource**: Fabric
- **Supports**: Repair, Breakdown, Enhancement

## Fabric Tiers

Fabric is harvested by carving creatures with a skinning knife (ClothType system). Min Craft Skill is the Tailoring level needed to sew with each fabric.

| Fabric | Min Craft Skill | Hue | Phy | Fir | Cld | Psn | Egy | Wep | Durability | Luck | Lower Req |
|---|---|---|---|---|---|---|---|---|---|---|---|
| Normal | 0.0 | default | 0 | 0 | 0 | 0 | 0 | — | — | — | — |
| Furry | 45.0 | 0x8BC | +1 | +1 | +1 | +1 | +1 | — | — | — | 25 |
| Wooly | 50.0 | 0x911 | +2 | +1 | +1 | +1 | +1 | Cold +25 | — | — | 25 |
| Silk | 60.0 | 0xAFE | +2 | +2 | +1 | +1 | +1 | Poison +25 | — | +10 | 25 |
| Haunted | 65.0 | 0xB3B | +2 | +2 | +2 | +1 | +1 | Energy +25 | — | — | 25 |
| Arctic | 70.0 | 0x9A3 | +2 | +2 | +2 | +2 | +1 | Cold +50 | — | — | 25 |
| Pyre | 75.0 | 0x981 | +2 | +2 | +2 | +2 | +2 | Fire +50 | — | — | 25 |
| Venomous | 75.0 | 0xB0C | +3 | +2 | +2 | +2 | +2 | Poison +50 | — | — | 25 |
| Mysterious | 80.0 | 0x8E4 | +3 | +3 | +2 | +2 | +2 | Energy +50 | — | +20 | 25 |
| Vile | 90.0 | 0x7B1 | +3 | +3 | +3 | +2 | +2 | Egy+25/Psn+25 | — | — | 25 |
| Divine | 99.0 | 0x8D7 | +3 | +3 | +3 | +3 | +2 | Cold+10/Fire+10/Egy+25 | +50 | +50 | 25 |
| Fiendish | 105.0 | 0x870 | +4 | +3 | +3 | +3 | +3 | Cold+10/Fire+25/Psn+10 | +50 | — | 25 |

Source: `ResourceInfo.cs:487–500`.

## Creature Sources

Fabric is carved from mammal, undead, and certain special creature corpses.

| Fabric | Sources |
|---|---|
| Furry | Bears, wolves, wild cats, apes/gorillas/monkeys, werewolves, ferret/rabbit/squirrel/weasel, zebra, giraffe, hyena, jackal, mastodon, mad dog, grum, gorakong, infected creatures, dire wolf |
| Wooly | Polar bears, white wolves, snow leopards/lions, white tigers, mammoths, ramadon, goats (dire/mountain/regular), white rabbit |
| Haunted | All ghosts/undead: Phantom, Wraith, Shade, Spectre, Mummy/MummyLord/MummyGiant, GhostDragyn, GhostGargoyle, GhostPirate, GhostWarrior, GhostWizard, Spirit, SpectralGargoyle, RestlessSoul, SeaGhost, Shroud, WailingBanshee, DragonGhost |
| Venomous | Diseased Mummy |
| Vile | Nazghoul, Soul Reaper |
| Silk | *Source not confirmed — likely Global Shoppe or quest reward; update when discovered* |
| Arctic | *Source not confirmed — likely Global Shoppe or quest reward; update when discovered* |
| Pyre | *Source not confirmed — likely Global Shoppe or quest reward; update when discovered* |
| Mysterious | *Source not confirmed — likely Global Shoppe or quest reward; update when discovered* |
| Divine | *Source not confirmed — likely Global Shoppe or quest reward; update when discovered* |
| Fiendish | *Source not confirmed — likely Global Shoppe or quest reward; update when discovered* |

Source: `BaseCreature.cs:4539–4549`, ClothType enum `BaseCreature.cs:104–118`.

## Hats (24 items)

| Item | Min Skill | Fabric |
|---|---|---|
| Skull Cap | 0.0 | 2 |
| Bandana | 0.0 | 2 |
| Floppy Hat | 6.2 | 11 |
| Wizard's Hat | 7.2 | 15 |
| Witch Hat | 7.2 | 15 |
| Cloth Hood/Cowl | 7.2 | 12 |
| Mask of the Dead | 7.2 | 12 + 1 Human Bone |
| Cloth Ninja Hood | 80.0 | 13 |

## Shirts & Robes (50+ items)

Includes doublets, shirts, tunics, dresses, cloaks, and over 30 robe styles (archmage, assassin, chaos, cultist, dragon, elegant, fancy, gilded, jester, necromancer, pirate, priest, royal, sage, sorcerer, vampire, and more). Most robes require 70.0 skill and 16 fabric.

## Pants & Skirts

Short pants, long pants, sailor pants, pirate pants, kilts, skirts, royal skirts, hakama (24.8–50.0 skill, 6–16 fabric).

## Miscellaneous

Body sashes, belts, loin cloths, aprons, obi, harpoon rope, ninja belt, oil cloth, and goza mats.

## Footwear

Ninja Tabi (70.0 skill, 10 fabric), Samurai Tabi (20.0 skill, 6 fabric).

## See Also

- [Leatherworking](leatherworking.md) — leather hides and sci-fi leathers
- [Stitching](stitching.md) — exotic creature skins (demon, dragon, etc.)
- [Mining](mining.md) — sand used in some accessory recipes via Glassblowing
