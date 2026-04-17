# Draconic (Scaled Armor)

Draconic crafting creates armor from reptile scales at an anvil and forge. This page is the authoritative reference for all scale material tiers.

- **Skill**: Blacksmithing (minimum 46.0)
- **Tool**: Scaling Tools
- **Primary Resource**: Reptile Scales
- **Facility Required**: Anvil and Forge
- **Supports**: Repair, Breakdown, Enhancement

## Scale Tiers

All scales share Arm +5 and Dmg +2 base stats. The Armor and Weapon columns show additional bonuses. Min Craft Skill is the Blacksmithy level needed to work each scale tier.

| Scale | Min Craft Skill | Hue | Phy | Fir | Cld | Psn | Egy | Wep Cold | Wep Fire | Wep Egy | Wep Psn | Durability | Luck |
|---|---|---|---|---|---|---|---|---|---|---|---|---|---|
| Crimson (Red) | 45.0 | 0x807 | +3 | +3 | +3 | +3 | +3 | — | +25 | — | — | +30 | — |
| Golden (Yellow) | 45.0 | 0x809 | +3 | +3 | +3 | +3 | +3 | +10 | +10 | +10 | +10 | +30 | +30 |
| Dark (Black) | 45.0 | 0x803 | +3 | +3 | +3 | +3 | +3 | — | — | — | — | +30 | — |
| Viridian (Green) | 45.0 | 0x806 | +3 | +3 | +3 | +3 | +3 | — | — | — | +25 | +30 | — |
| Ivory (White) | 45.0 | 0x808 | +3 | +3 | +3 | +3 | +3 | +25 | — | — | — | +30 | — |
| Azure (Blue) | 45.0 | 0x804 | +3 | +3 | +3 | +3 | +3 | +15 | — | — | +15 | +30 | — |
| Dinosaur | 45.0 | 0x805 | +3 | +3 | +3 | +3 | +3 | — | — | — | — | +30 | — |
| Metallic | 45.0 | 0xB80 | +3 | +3 | +3 | +3 | +3 | — | — | — | — | +30 | — |
| Brazen | 45.0 | 0x436 | +3 | +3 | +3 | +3 | +3 | — | +15 | +15 | — | +30 | — |
| Umber | 45.0 | 0x435 | +3 | +3 | +3 | +3 | +3 | — | — | +35 | — | +30 | — |
| Violet | 45.0 | 0x424 | +3 | +3 | +3 | +3 | +3 | — | — | +25 | — | +30 | — |
| Platinum | 45.0 | 0x449 | +3 | +3 | +3 | +3 | +3 | +15 | +15 | +15 | +15 | +30 | +50 |
| Cadalyte | 115.0 | 0x99D | +3 | +3 | +3 | +3 | +3 | — | — | +50 | — | +200 | — |

Source: `ResourceInfo.cs:397–411`.

## Creature Sources

Scales are carved from dragon, dinosaur, and sea-creature corpses.

| Scale | Sources |
|---|---|
| Crimson (Red) | Most dragons (default ScaleType) |
| Golden (Yellow) | Baby Dragon, Fire Wyrmling |
| Dark (Black) | Shadow Wyrm, Volcanic Dragon |
| Viridian (Green) | Swamp Dragon |
| Azure (Blue) | Great White Shark, Megalodon, Sea Horses, Sharks, Giant Eels, Slitheran, Sea Serpents, Jormungand, Slasher of Void |
| Dinosaur | Iguanodon, Titanoboa, Ridgeback, Savage Ridgeback |
| Cadalyte | Caddellite Dragon, Ruby Pickaxe special drop |
| Metallic / Brazen / Umber / Violet / Platinum | Source not confirmed in current discovery pass — likely rare encounter drops |

Source: `BaseCreature.cs:4818–4841`, ScaleType enum `BaseCreature.cs:120–136`.

## Sci-Fi Scales

> **Note:** These materials can be obtained as loot drops but cannot currently be used in crafting — the sci-fi scale sub-resources are disabled in the Draconic craft menu.

Sci-fi scales drop from Mutant Lizardmen (`ScaleType.SciFi`). Each carve yields one of four types at random (25% each).

All sci-fi scales share: Arm +7, Dmg +3, all resistances +4, Durability +100, Lower Requirements 10.

| Scale | Hue | Min Craft Skill | Weapon Bonus |
|---|---|---|---|
| Gorn | 0x5D6 | 110.0 | Fire +25 |
| Trandoshan | 0x5D8 | 110.0 | Cold +25 |
| Silurian | 0x5D5 | 110.0 | Energy +25 |
| Krayt | 0x692 | 110.0 | Poison +25 |

Source: `ResourceInfo.cs:412–415`, `MutantLizardman.cs:56`.

## Scaly Armor

| Item | Min Skill | Scales |
|---|---|---|
| Scaly Boots | 46.3 | 14 |
| Scaly Gorget | 56.4 | 10 |
| Scaly Gloves | 58.9 | 12 |
| Scaly Helm | 62.6 | 15 |
| Scaly Sleeves | 66.3 | 18 |
| Scaly Leggings | 68.8 | 20 |
| Scaly Tunic | 75.0 | 25 |

## Drakbone Armor

Drakbone armor requires both Reptile Scales and Draco Bones.

| Item | Min Skill | Scales | Draco Bones |
|---|---|---|---|
| Drakbone Gauntlets | 58.9 | 6 | 6 |
| Drakbone Bracers | 66.3 | 12 | 9 |
| Drakbone Greaves | 68.8 | 14 | 10 |
| Drakbone Tunic | 75.0 | 19 | 12 |
| Drakbone Helm | 81.4 | 24 | 15 |

## Scalemail Armor

| Item | Min Skill | Scales |
|---|---|---|
| Scalemail Gloves | 76.6 | 24 |
| Scalemail Helm | 81.4 | 30 |
| Scalemail Arms | 86.2 | 36 |
| Scalemail Leggings | 89.4 | 40 |
| Scalemail Tunic | 97.5 | 50 |

## Scaled Plate Armor

| Item | Min Skill | Scales |
|---|---|---|
| Scaled Gorget | 79.0 | 30 |
| Scaled Gloves | 82.5 | 36 |
| Scaled Helm | 87.6 | 45 |
| Scaled Arms | 92.8 | 54 |
| Scaled Legs | 96.3 | 60 |
| Scaled Chest | 105.0 | 75 |

## Shields

| Item | Min Skill | Scales |
|---|---|---|
| Scalemail Shield | 64.3 | 14 |
| Scaled Shield | 84.3 | 18 |

## See Also

- [Leatherworking](leatherworking.md) — leather hides
- [Bonecrafting](bonecrafting.md) — skeletal bones (Draco bones used in Drakbone)
