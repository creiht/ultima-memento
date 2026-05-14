# Forensics

Forensic Evaluation lets you investigate crime scenes, examining corpses, locks, coffers, and other objects for evidence of criminal activity.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Intelligence |
| Usage | Active (targeted) |
| Range | 10 tiles |
| Skill Check | 0 - 125 (corpses), 40 - 125 (mobiles) |
| Trainable | Yes (0.0 - 125.0, rate 0.2) |
| Display Position | 22 (SkillsGump) |

## How It Works

### Examining Mobiles

Target a player or NPC to check if they are a member of the Thieves' Guild. Requires a skill check against difficulty 40-125.

### Examining Corpses

Target a corpse to learn:
- **Who killed them** (if human)
- **Who looted the corpse**
- Your name is recorded as the forensicist on the corpse

Once examined by a forensicist, subsequent examinations reveal the original findings without requiring a new skill check.

### Examining Coffers

Target a coffer to learn if it has been robbed and by whom.

### Examining Locks

Target a lockpickable container to learn who picked the lock.

### Examining Other Objects

- **Land Chests (bodies):** "This adventurer looks to have been slain by some wild animal."
- **Land Chests (wagons):** "For some reason, this wagon was left behind."
- **Water Chests:** "Maybe the owner of this boat fell into the sea and drowned."
- **Sunken Ships:** "This ship looks as though it seen better days."

## How to Train

Examine corpses, locked containers, and NPCs. Corpse examination has a skill check from 0-125, making it the easiest way to gain.

## What It Affects

### Corpse Carving (Skinning)

`BaseCreature.cs:4472` — When skinning a corpse with a bladed item, a successful Forensics check (0-100) with at least 5.0 base Forensics increases the quantity of harvested resources. The bonus is `(ForensicsValue / 25) + (AnatomyValue / 25)` per resource type (feathers, wool, hides, meat, scales, cloth, rocks, skeletal, skins, granite, metal, wood). This synergizes directly with Anatomy.

`BaseCreature.cs:4403` — Players carrying the Frankenstein Journal can sever body parts from giant slayers (ogres, ettins, cyclops) when Forensics value is >= a random threshold between 30-250 and the Slayer matches. Body parts include FrankenLegLeft, FrankenLegRight, FrankenArmLeft, FrankenArmRight, FrankenHead, FrankenTorso, and FrankenBrain.

### Harvest System

`GraveRobbing.cs:48` — Grave Robbing uses Forensics as its skill definition. The harvest resource yields bones, rotted limbs, grave dust, fertile dirt, potions, reagents, and scrolls.

`GraveRobbing.cs:236-241` — The probability of encountering a "grave raiser" (awakened undead monster) is scaled by Forensics level: below 80 yields a random range of 0-17, between 80-100 yields 6-18, and 100+ yields 6-19 possible undead spawns.

`GraveRobbing.cs:335-338` — Higher Forensics increases the chance to dig up a treasure chest from a grave (`(2 + ForensicsValue/10)%` chance), with better chests available at higher skill levels.

### Crafting

`DefWitchery.cs:11` — Witchery (Witch Brewing) uses Forensics as its primary crafting skill. This crafting system produces various undead-themed brews and elixirs requiring reagents and a cauldron, with secondary Necromancy skill checks ranging from 10-120.

`DefMasonry.cs:105` — Masonry requires 75.0-80.0 Forensics for certain recipes.

`DefShelves.cs:145-147` — Shelves requires 75.0-80.0 Forensics for certain recipes.

### Items & Tools

`GuildRing.cs:76` — The Necromancers Guild Ring provides a +10 bonus to Forensics as its first skill bonus.

`PolishBoneBrush.cs:149` — The Polish Bone Brush tool converts regular bones into special skeletal types (Drow, Orc, Troll, Gargoyle, Minotaur, Lycan, Vampire, Lich, Sphinx, Devil, Draco, etc.). The chance of getting rare skeletals is determined by `(ForensicsBase / 10) + 7`.

`Elixirs.cs:1987-2059` — The Elixir of Forensics temporarily boosts Forensics skill. Duration and strength are affected by Cooking, Tasting, and Alchemy skills. While active, the player cannot drink another elixir of the same type or have more than 2 elixirs active simultaneously.

`ResourceMods.cs:193` — Grave Robbing harvest tools (pickaxes, scythes) and Skinning Knife Tools receive Forensics skill bonuses when crafted/enhanced.

`ResourceMods.cs:299,310` — Both BaseAxe and BasePoleArm harvest tools with Grave Robbing systems grant Forensics skill bonuses based on tool usage.

`BaseRunicTool.cs:205` — Runic tools can be enchanted with Forensics as one of their skill bonuses.

### NPC Interactions

`BaseVendor.cs:2293` — Players with 50.0+ Forensics gain access to the Setup Shoppe option at Undertaker, Witches, Necromancer, and NecromancerGuildmaster vendors.

`Players.cs:569` — Players with 80.0+ Forensics and negative karma are classified as "Undertakers" for the EvilPlayer check, affecting NPC reactions and certain gameplay flags.

`Behavior.cs:6275` — Forensics is included in the list of skills that trigger NPC speech responses in town.

### Global Shoppes

`MorticianShoppe.cs:214` — The Mortician Global Shoppe uses the average of Forensics and Necromancy values as its skill check: `(Forensics + Necromancy) / 2`.

`ShoppeRewardGump.cs:145` — The Mortician Global Shoppe rewards include "Ancient Mortician Gloves" which provide +5 to +10 Forensics.

### Slayer Drops

`BaseCreature.cs:8342` — Undead creatures (Mummy, Ghoul, Flesh Golem, Zombie variants, etc.) have a chance to drop Embalming Fluid. The drop threshold is a random value between 30-150, checked against the player's Forensics value.

### Avatar System

`SkillArchive.cs:83-84` — Forensics is tracked in the Avatar system's SkillArchive, meaning it is counted toward avatar level calculations.

### How to Train

The game auto-tracks Forensics during certain activities.

`SkillCheck.cs:314` — Forensics is listed as an auto-trainable skill when performing certain actions.

`BaseCreature.cs:4472` — Corpse skinning performs a Forensics skill check (0-100) whenever you carve resources, contributing to training.

## Related Skills

- [Anatomy](anatomy.md) — Both skills contribute equally to corpse carving bonuses (`ForensicsValue/25 + AnatomyValue/25`)
- [Necromancy](../magic/necromancy.md) — Averaged with Forensics for Mortician Shoppe skill; Necromancers Guild Ring gives bonus to both; Witchery crafting requires Necromancy as secondary skill
- [Spiritualism](spiritualism.md) — Co-bonus on Necromancers Guild Ring; used to resist grave raiser spawns during Grave Robbing
- [Searching](searching.md) — Detects hidden traps, doors, and creatures
- [Snooping](snooping.md) — Peeks into containers
- [Stealth](stealth.md) — Used during Grave Robbing to avoid being caught while digging
