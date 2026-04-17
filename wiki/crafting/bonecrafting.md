# Bonecrafting

Bonecrafting creates armor from skeletal remains of various creatures. This page is the authoritative source for all skeletal bone tiers, sci-fi bones, and special "spec" bones.

- **Skill**: Forensics
- **Tool**: Bonecrafting tool
- **Primary Resource**: Skeletal bones (Brittle tier from graves; higher tiers from creature carving)
- **Supports**: Repair, Breakdown, Enhancement

## Skeletal Bone Tiers

The Arm column is the armor mod. Bonus columns show additional resistances and weapon bonuses. Higher tiers also carry slayer-class bonuses.

| Bone | Min Craft Skill | Hue | Arm | Phy | Fir | Cld | Psn | Egy | Wep | Durability | Luck |
|---|---|---|---|---|---|---|---|---|---|---|---|
| Brittle | 0.0 | default | 0 | 0 | 0 | 0 | 0 | 0 | — | — | — |
| Drow | 55.0 | 0x424 | +1 | +2 | +2 | +2 | +2 | +2 | Energy +25 | +5 | +5 |
| Orc | 60.0 | 0x44C | +2 | +3 | +2 | +2 | +2 | +2 | — | +10 | — |
| Reptile | 65.0 | 0x806 | +3 | +3 | +3 | +2 | +2 | +2 | Poison +25 | +10 | — |
| Ogre | 70.0 | 0x5B2 | +4 | +3 | +3 | +3 | +2 | +2 | — | +20 | — |
| Troll | 70.0 | 0x961 | +4 | +3 | +3 | +3 | +3 | +2 | — | +20 | — |
| Gargoyle | 75.0 | 0x807 | +5 | +3 | +3 | +3 | +3 | +3 | Fire +50 | +30 | — |
| Minotaur | 80.0 | 0x83F | +6 | +4 | +3 | +3 | +3 | +3 | — | +30 | — |
| Lycan | 85.0 | 0x436 | +7 | +4 | +4 | +3 | +3 | +3 | — | +40 | — |
| Shark | 90.0 | 0x43F | +8 | +4 | +4 | +4 | +3 | +3 | Cold +25 | +40 | — |
| Colossal | 91.0 | 0x69A | +9 | +4 | +4 | +4 | +4 | +3 | — | +40 | — |
| Mystical | 93.0 | 0x809 | +10 | +4 | +4 | +4 | +4 | +4 | Energy +50 | +50 | +10 |
| Vampire | 95.0 | 0x803 | +11 | +5 | +4 | +4 | +4 | +4 | Egy+25/Psn+25 | +60 | — |
| Lich | 97.0 | 0x808 | +12 | +5 | +5 | +4 | +4 | +4 | Cold+25/Psn+25 | +60 | — |
| Sphinx | 99.0 | 0x804 | +13 | +5 | +5 | +5 | +4 | +4 | All +15 | +70 | +30 |
| Devil | 102.0 | 0x648 | +15 | +5 | +5 | +5 | +5 | +4 | Fire+35/Egy+15 | +70 | +50 |
| Draco | 105.0 | 0x437 | +17 | +5 | +5 | +5 | +5 | +5 | All +20 | +100 | — |
| Xeno | 110.0 | 0x44D | +18 | +6 | +5 | +5 | +5 | +5 | Cold+10/Egy+30/Psn+10 | +80 | — |

Source: `ResourceInfo.cs:533–552`.

## Creature Sources

Bones are carved from creature corpses. Brittle bones can also come from [Grave Robbing](grave-robbing.md).

| Bone | Sources |
|---|---|
| Brittle | Default skeletons; also found via Grave Robbing |
| Drow | Drow (dark elves) |
| Orc | Orcs and orc variants |
| Reptile | Large reptilian creatures |
| Ogre | Ogres and ogre lords |
| Troll | Trollbear |
| Gargoyle | Gargoyles (all types) |
| Minotaur | Minotaurs |
| Lycan | Werewolves |
| Shark | Sharks and giant shark variants |
| Colossal | Colossal creatures |
| Mystical | Mystical creatures |
| Vampire | Vampiric Dragon (50%) |
| Lich | Liches |
| Sphinx | Sphinxes |
| Devil | All demons |
| Draco | All dragons |
| Xeno | Alien xenomorphs |

**Special**: Bone Golems use `SkeletalType.All`, yielding one random bone from Brittle–Draco per carve.

Source: `BaseCreature.cs:4853–4919`, SkeletalType enum `BaseCreature.cs:138–160`.

## Sci-Fi Bones

> **Note:** The Andorian through Zabrak sci-fi bone tiers can be obtained as loot drops but cannot currently be used in crafting — they are disabled as selectable sub-resources in the Bonecrafting craft menu. (Xeno is the exception — it is enabled as the 18th standard tier in the menu.)

Sci-fi bones drop from sci-fi humanoid creatures: Jedi, Syth, Psionicist, BombWorshipper, SavageAlien, Mutant. Any creature with `SkeletalType.SciFi` yields one of 9 types at random.

All sci-fi bones share: Arm +14, Dmg +4, all resistances +4, Durability +80, Lower Requirements 30–45 (varies). Note that Xeno can also be obtained from SciFi carving.

| Bone | Hue | Min Craft Skill | Weapon Bonus | Lower Req |
|---|---|---|---|---|
| Xeno | 0x44D | 100.1 | Cold+10/Egy+30/Psn+10 | — |
| Andorian | 0xB3D | 100.1 | Fire +50 | 35 |
| Cardassian | 0x986 | 100.1 | All +10 | 30 |
| Martian | 0x6F6 | 100.1 | Poison +50 | 40 |
| Rodian | 0x77F | 100.1 | Egy+25/Psn+25 | 45 |
| Tusken | 0x775 | 100.1 | Fire+25/Egy+25 | 30 |
| Twi'lek | 0xAF8 | 100.1 | Cold+15/Fire+15/Egy+15 | 35 |
| Xindi | 0x877 | 100.1 | All +10 | 30 |
| Zabrak | 0xB01 | 100.1 | Fire+30/Egy+30 | 40 |

Source: `ResourceInfo.cs:553–560`, `BaseCreature.cs:4903–4918`.

## Special "Spec" Bone Materials

Spec bones are rare drops from boss encounters, quest rewards, and special events. They use the `CraftResourceType.Special` family and have their own stat profiles. Min Craft Skill is 110.0 for most; Fire/Cold/Venom/Energy are lower-tier at 80.0.

| Spec | Hue | Min Craft Skill | Phy | Fir | Cld | Psn | Egy | Weapon | Durability | Luck |
|---|---|---|---|---|---|---|---|---|---|---|
| Spectral | 2859 | 110.0 | +4 | +4 | +4 | +4 | +4 | Cold +50 | +20 | — |
| Dread | 2860 | 110.0 | +4 | +4 | +4 | +4 | +4 | — | +90 | +20 |
| Ghoulish | 2937 | 110.0 | +4 | +4 | +4 | +4 | +4 | All+10 | +200 | +50 |
| Wyrm | 2817 | 110.0 | +4 | +4 | +4 | +4 | +4 | All+10 | +200 | +50 |
| Holy | 2882 | 110.0 | +4 | +4 | +4 | +4 | +4 | Cold+35/Egy+35 | +100 | — |
| Bloodless | 1194 | 110.0 | +4 | +4 | +4 | +4 | +4 | — | +70 | — |
| Gilded | 2815 | 110.0 | +2 | +2 | +2 | +2 | +2 | — | — | +100 |
| Demilich | 2858 | 110.0 | +4 | +4 | +4 | +4 | +4 | Poison +30 | +200 | — |
| Wintry | 2867 | 110.0 | +4 | +4 | +4 | +4 | +4 | Cold +50 | +70 | — |
| Fire | 0xB54 | 80.0 | 0 | +17 | 0 | 0 | 0 | Fire +100 | +25 | — |
| Cold | 0xB57 | 80.0 | 0 | 0 | +17 | 0 | 0 | Cold +100 | +25 | — |
| Venom | 0xB51 | 80.0 | 0 | 0 | 0 | +17 | 0 | Poison +100 | +25 | — |
| Energy | 0xAFE | 80.0 | 0 | 0 | 0 | 0 | +17 | Energy +100 | +25 | — |
| Exodus | 1072 | 120.0 | +4 | +4 | +4 | +4 | +4 | — | — | — |
| Turtle Shell | 0x9ED | 110.0 | +4 | +4 | +4 | +4 | +4 | — | +120 | — |

> Source drop info: Spec bones come from boss and event loot. Exact creature sources for most spec bones are not fully confirmed — update as discovered.

Source: `ResourceInfo.cs:417–433`.

## Bone Armor

| Item | Min Skill | Bones |
|---|---|---|
| Bone Bracers | 42.0 | 12 |
| Bone Greaves | 45.0 | 16 |
| Bone Gauntlets | 39.0 | 8 |
| Bone Helm | 35.0 | 6 |
| Bone Skirt | 45.0 | 16 |
| Bone Tunic | 46.0 | 22 |

## Skeletal Armor

| Item | Min Skill | Bones |
|---|---|---|
| Skeletal Bracers | 92.0 | 16 |
| Skeletal Greaves | 95.0 | 20 |
| Skeletal Gauntlets | 89.0 | 12 |
| Skeletal Helm | 85.0 | 10 |
| Skeletal Tunic | 96.0 | 26 |

## See Also

- [Grave Robbing](grave-robbing.md) — source of Brittle bones
- [Draconic](draconic.md) — Draco bones used in Drakbone armor
- [Leatherworking](leatherworking.md) — leather hides
