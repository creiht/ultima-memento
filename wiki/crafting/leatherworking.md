# Leatherworking

Leatherworking creates leather armor, footwear, bags, and accessories from leather hides. It is the authoritative source for all leather material tiers.

- **Skill**: Tailoring
- **Tool**: Tanning Tools
- **Primary Resource**: Leather
- **Supports**: Repair, Breakdown, Enhancement

## Leather Tiers

The Arm column is the armor mod bonus. Bonus columns show additional resistances and weapon bonuses on crafted items. The carve skill (Tailoring) required to **use** each hide tier is listed in the Min Craft Skill column.

| Leather | Min Craft Skill | Hue | Arm | Phy | Fir | Cld | Psn | Egy | Wep Fire | Wep Psn | Durability |
|---|---|---|---|---|---|---|---|---|---|---|---|
| Normal (Regular) | 0.0 | default | 0 | 0 | 0 | 0 | 0 | 0 | — | — | — |
| Lizard (Horned) | 55.0 | 0x69C | +1 | +3 | +2 | 0 | 0 | 0 | — | — | +10 |
| Serpent (Barbed) | 60.0 | 0x69E | +2 | +2 | 0 | 0 | +4 | 0 | — | +70 | +20 |
| Necrotic | 65.0 | 0x69D | +3 | 0 | 0 | +3 | +2 | +2 | — | +50 | +30 |
| Volcanic | 70.0 | 0x69F | +4 | +3 | +5 | 0 | 0 | 0 | +50 | — | +40 |
| Frozen | 75.0 | 0x699 | +5 | 0 | +2 | +5 | 0 | +2 | — | — | +50 |
| Deep Sea (Spined) | 80.0 | 0x696 | +6 | 0 | +4 | +4 | +2 | 0 | — | +20 | +50 |
| Goliath | 85.0 | 0x69A | +7 | +5 | 0 | 0 | +3 | +3 | +25 (Egy) | — | +60 |
| Draconic | 90.0 | 0x698 | +8 | 0 | +5 | +3 | +2 | +2 | +25 (Fire) | — | +70 |
| Hellish | 100.0 | 0x69B | +9 | +4 | +5 | 0 | 0 | +4 | +50 (Fire) | — | +80 |
| Dinosaur | 105.0 | 0x697 | +10 | +5 | 0 | +5 | +4 | 0 | — | — | +100 |
| Alien | 125.0 | 0x695 | +11 | +3 | +3 | +3 | +3 | +3 | +50 (Egy) | — | +100 |

Source: `ResourceInfo.cs:435–448`.

## Creature Sources

Hides are carved from creature corpses using a skinning knife (or any bladed weapon with the carve command).

| Leather | Sources |
|---|---|
| Normal | Most animals and humanoids (default HideType) |
| Lizard (Horned) | Lizardmen, horned lizards, raptor variants |
| Serpent (Barbed) | Giant serpents, ophidians, barbed creatures |
| Necrotic | Flesh Golems, Skin Golems |
| Volcanic | Hell Cats, Fire Demons, Fire Mephits |
| Frozen | Polar Bears, White/Winter Wolves, Snow Lions, Mammoths, Ramadon, Ice Devil |
| Deep Sea (Spined) | Deep Sea Devil, Sea Serpents, Sea Dragons (50%), Dragon Turtle (50%) |
| Goliath | Goliath family creatures |
| Draconic | All Dragons |
| Hellish | All Demons |
| Dinosaur | Iguanodon, Axe Beak, Bullradon |
| Alien | Mutants |

Source: `BaseCreature.cs:4557–4574`, HideType enum `BaseCreature.cs:162–176`.

## Sci-Fi Leathers

> **Note:** These materials can be obtained as loot drops but cannot currently be used in Leatherworking crafting — the sci-fi leather sub-resources are disabled in the Leatherworking craft menu. (They *can* be used as book cover material in [Inscription](inscription.md).)

Sci-fi leathers drop from alien humanoid creatures in [Kuldar](../world/sosaria.md#kuldar-bottle-world), sci-fi dungeons, and related zones. Any creature with `HideType.SciFi` (alien/robot skinnable) yields one random sci-fi leather piece.

All 11 sci-fi leathers share: Arm +12, all resistances +4, Durability +80. Each has a unique weapon/armor specialty and Lower Requirements bonus as shown.

| Leather | Hue | Min Craft Skill | Armor Bonus | Weapon Bonus | Lower Req |
|---|---|---|---|---|---|
| Adesote | 0xAF8 | 110.0 | All +4 | Energy +25 | 50 |
| Biomesh | 0x829 | 110.0 | All +4 | — | 40 |
| Cerlin | 0xB57 | 110.0 | All +4 | Cold +25 | 60 |
| Durafiber | 0x8C1 | 110.0 | All +4 | — | 40 |
| Flexicris | 0x705 | 110.0 | All +4 | Fire+25/Fire+25 | 50 |
| Hypercloth | 0x77F | 110.0 | All +4 | Poison +25 | 60 |
| Nylar | 0x701 | 110.0 | All +4 | Fire +50 | 60 |
| Nylonite | 0x6F8 | 110.0 | All +4 | Energy +50 | 50 |
| Polyfiber | 0x6F6 | 110.0 | All +4 | Poison +50 | 50 |
| Syncloth | 0x7A9 | 110.0 | All +4 | — | 40 |
| Thermoweave | 0x775 | 110.0 | All +4 | Fire+20/Fire+20 | 50 |

Source: `ResourceInfo.cs:449–459`.

## Footwear

| Item | Min Skill | Leather |
|---|---|---|
| Sandals | 12.4 | 4 |
| Shoes | 16.5 | 6 |
| Boots | 33.1 | 8 |
| Thigh Boots | 41.4 | 10 |
| Leather Sandals | 42.4 | 4 |
| Leather Shoes | 56.5 | 6 |
| Leather Boots | 63.1 | 8 |
| Leather Thigh Boots | 71.4 | 10 |
| Soft Leather Boots | 81.4 | 8 |
| Hiking Boots | 83.1 | 8 |
| Oniwaban Boots | 81.4 | 8 |

## Leather Armor

| Item | Min Skill | Leather |
|---|---|---|
| Leather Cap | 6.2 | 2 |
| Leather Gloves | 51.8 | 3 |
| Leather Gorget | 53.9 | 4 |
| Leather Arms | 53.9 | 4 |
| Leather Leggings | 66.3 | 10 |
| Leather Chest | 70.5 | 12 |
| Ninja Hood/Jacket/Pants | 80–90 | 13–14 |

## Studded Armor

| Item | Min Skill | Leather |
|---|---|---|
| Studded Gorget | 78.8 | 6 |
| Studded Gloves | 82.9 | 8 |
| Studded Arms | 87.1 | 10 |
| Studded Leggings | 91.2 | 12 |
| Studded Chest | 94.0 | 14 |

## Miscellaneous

Pugilist Gloves, Throwing Gloves, Whips, Backpacks, Pouches, Bags (various sizes), and animal-skin caps (Bear, Deer, Stag, Wolf).

## See Also

- [Draconic](draconic.md) — scales-based armor
- [Stitching](stitching.md) — exotic creature skins armor
- [Bonecrafting](bonecrafting.md) — skeletal bones armor
