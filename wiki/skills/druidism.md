# Druidism

Druidism (Animal Lore) lets you examine creatures to learn detailed information about their stats, skills, resistances, damage types, and taming requirements. It also governs druidic herbalism crafting and the casting of 16 nature-themed spells.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Intelligence |
| Usage | Active (targeted — lore creatures) |
| Range | 8 tiles |
| Skill Check | 0 - 125 |
| Power Scroll | Yes |

## What It Affects

### Creature Lore (Monster Manual)

- Target any animal-type creature to open a detailed information gump showing Power Level, damage types, combat ratings, resistances, stats, and taming info.
- Skill gate thresholds:
  - **Below 100:** Only lore your own tamed creatures (`Druidism.cs:72`).
  - **100+:** Lore tamed or tameable creatures from any owner (`Druidism.cs:76`).
  - **110+:** Lore any creature, including untameable ones (`Druidism.cs:80`).
- Skill check: `CheckTargetSkill(Druidism, creature, 0.0, 125.0)` on successful lore (`Druidism.cs:80`).
- Creature type restrictions: does not work on slimes (SlimyScourge Slayer), elementals (ElementalBan), Repond (Repond Slayer), silvers (Silver Slayer), giants (GiantKiller), golems (GolemDestruction), humanoids, undead, or dead pets (`Druidism.cs:48-54`).

### Taming

- Passive Druidism gains: when taming a creature for the first time (`!alreadyOwned`), `CheckTargetSkill(Druidism, creature, 0.0, 125.0)` is triggered as a gain check (`Taming.cs:309,324`).
- Taming modifier: Druidism.Value / 5 is subtracted from the taming difficulty check (`Taming.cs:333`).
- Taming lore bonus: when Druidism.Base > Taming.Base, the lore value (Druidism × 10) is used instead of taming value for taming calculations (`BaseCreature.cs:1999-2002`).

### Druidic Herbalism Crafting

- Druidism is the primary skill for **Druidic Herbalism** (also called Druid Herbalism), a craft system using a **Druid Cauldron** as the required tool (`DruidCauldron.cs:9`).
- 17 recipes are available, each requiring a Druidism range and a Veterinary sub-skill range (`DefDruidism.cs:94-172`):

| Potion | Druidism | Veterinary | Ingredients |
|---|---|---|---|
| Stone in a Jar | 10 - 30 | 5 - 15 | Moon Crystal, Silver Widow |
| Nature Passage Mixture | 15 - 35 | 10 - 20 | Sea Salt, Fairy Egg |
| Shield of Earth Liquid | 20 - 40 | 15 - 25 | Ginseng, Black Pearl |
| Woodland Protection Oil | 25 - 45 | 20 - 30 | Garlic, Swamp Berries |
| Stone Rising Concoction | 30 - 50 | 25 - 35 | Beetle Shell, Sea Salt |
| Grasping Roots Mixture | 35 - 55 | 30 - 40 | Mandrake Root, Ginseng |
| Druidic Marking Oil | 40 - 60 | 35 - 45 | Black Pearl, Eye of Toad |
| Herbal Healing Elixir | 45 - 65 | 40 - 50 | Red Lotus, Garlic |
| Forest Blending Oil | 50 - 70 | 45 - 55 | Silver Widow, Nightshade |
| Jar of Fireflies | 55 - 75 | 50 - 60 | Spider Silk, Butterfly Wings |
| Mushroom Gateway Growth | 60 - 80 | 55 - 65 | Bloodmoss, Eye of Toad |
| Jar of Insects | 65 - 85 | 60 - 70 | Butterfly Wings, Beetle Shell |
| Fairy in a Jar | 70 - 90 | 65 - 75 | Fairy Egg, Moon Crystal |
| Treant Fertilizer | 75 - 95 | 70 - 80 | Swamp Berries, Mandrake Root |
| Volcanic Fluid | 80 - 110 | 75 - 85 | Brimstone, Sulfurous Ash |
| Jar of Magical Mud | 85 - 120 | 80 - 90 | Nightshade, Red Lotus |

- All potions are brewed in jars (not bottles) and stored in a **Druid Pouch** (`DruidPouch.cs`).
- The **Book of Druidic Herbalism** (`BookDruidBrewing.cs`) provides a full recipe guide with descriptions.

### Druid Spell System

Druidism governs the casting of **16 druidic spells**, each requiring a spell scroll (potions) and a minimum Druidism level (`HerbalistSpell.cs:12` sets `CastSkill = Druidism`):

| Spell | Circle | Druidism Required | Effect |
|---|---|---|---|
| Stone in a Jar (Lure Stone) | 4 | 10 | Dumps a magical stone that draws nearby animals |
| Nature Passage Mixture | 3 | 15 | Turns caster to petals, transports to a rune |
| Shield of Earth Liquid | 2 | 20 | Grows foliage wall blocking passage |
| Woodland Protection Oil | 2 | 25 | Bark-like skin, increases protection |
| Stone Rising Concoction | 3 | 30 | Stones push up from ground to trap foes |
| Grasping Roots Mixture | 3 | 35 | Roots from ground entangle foe |
| Druidic Marking Oil | 3 | 40 | Marks a rune with caster's location for recall |
| Herbal Healing Elixir | 3 | 45 | Heals target of all ailments |
| Forest Blending Oil | 3 | 50 | Blends with forest, foes lose sight |
| Jar of Fireflies | 4 | 55 | Fireflies distract foe in battle |
| Mushroom Gateway Growth | 4 | 60 | Magical mushrooms form portal to rune |
| Jar of Insects | 4 | 65 | Swarm of insects bites stings nearby foes |
| Fairy in a Jar | 4 | 70 | Releases fairy to help adventurer |
| Treant Fertilizer | 4 | 75 | Living tree grows and wanders with caster |
| Volcanic Fluid | 4 | 80 | Molten lava bursts from ground at all foes |
| Jar of Magical Mud | 4 | 85 | Resurrects caster/others after death |

- Spell resistances are based on target's Magic Resist (`HerbalistSpell.cs:35-43`).
- Cast delay varies per spell (`HerbalistSpell.cs:91-93`).
- Damage skill for herbalist potions is Veterinary (`HerbalistSpell.cs:13`).

### Pet Follower Capacity

- Druidism.Base is one of four skills (with Herding, Veterinary, Taming) that determine max follower count:
  - All four >= 60: **6 followers** (`PlayerMobile.cs:659`)
  - All four >= 90: **7 followers** (`PlayerMobile.cs:656`)
  - All four >= 120: **8 followers** (`PlayerMobile.cs:653`)

### NPCs & Vendor Discounts

- Herbalist, Druid, DruidTree, and DruidGuildmaster vendors grant shop setup access to players with Druidism.Value >= 50 (`BaseVendor.cs:2294`).
- Druid merchants have Druidism in range 55-100 (`Druid.cs:31, DruidTree.cs:38, DruidGuildmaster.cs:29`).
- Other animal-related NPCs with Druidism: Veterinarian (85-100), Shepherd (64-100), Rancher (55-78), Furtrader (85-100), AnimalTrainer (64-100), RangerGuildmaster (64-100).
- AnimalTrainer NPC uses Druidism.Value for trade adjustments (`AnimalTrainer.cs:241`).

### Items

- **Guild Ring (Druids Guild):** +10 Druidism (+5 Alchemy, +10 Taming, +10 Herding, +10 Veterinary, +5 Cooking) (`GuildRing.cs:83-89`).
- **The Dryad Bow (Artifact):** +25 Druidism (`Artifact_TheDryadBow.cs:21`).
- **Ancient Herbalist Gloves:** +5 Druidism, available from Global Shoppe rewards (`ShoppeRewardGump.cs:120`).

### Quests & Achievement Systems

- **Global Shoppe (Herbalist):** effective skill = (Druidism + Veterinary) / 2 for reward calculations (`HerbalistShoppe.cs:173`).
- **Research magic system:** Divination spell opens the DruidismGump — source 3 (Divination book) or source 4 (People's Handbook) (`ResearchDivination.cs:74-83`).
- **Monster Manual book:** opens DruidismGump with source 1 (Monster Manual view) (`MonsterManual.cs:74-75`).
- **Players Handbook book:** opens DruidismGump with source 2 (Player's Handbook view) (`PlayersHandbook.cs:96-97`).
- **DynamicBook:** assigns "Naturalist" as the Druidism skill title (`DynamicBook.cs:343`).
- **Codex of Wisdom:** includes Druidism in skill display and learning checks (`CodexWisdom.cs:78,388`).

### Character & Alignment

- Starting skill: Druidism starts at **30** during character creation (`CharacterCreation.cs:960`).
- Skill title: Druidism.Base contributes to character title calculation (`Players.cs:227`).
- Character skill showcase: selectable as skill #36 in character display (`SkillsGump.cs:69`).
- Follower count update: triggered on Druidism skill changes (`PlayerMobile.cs:641`).
- Lure Stone spell: Druidism.Value determines tamer skill for lured creatures (`LureStoneSpell.cs:141,340`).
- Runebook gating: Druidism > 0 gates visibility of Nature's Passage and Mushroom Gateway spells in the runebook (`RunebookGump.cs:355,371,382`).
- Alchemical Elixirs: Druidism is a valid target skill for skill-enhancing elixirs (`Elixirs.cs:272`).
- SkillCheck: Druidism is listed in the skill check table (`SkillCheck.cs:18`).
- Blackthorn's Dungeon: Druidism is one of 4 skills used in the dungeon's skill check (`SkillCheck.cs:326`).

### Related Systems

- **Veterinary:** required sub-skill for all 17 herbalism recipes; damage skill for herbalist spell casting; paired with Druidism for pet healing and follower capacity.
- **Taming:** Druidism gains passively during taming; Druidism mod subtracts from taming difficulty; lore value can substitute for taming value in taming calculations.
- **Herding:** paired with Druidism, Veterinary, and Taming for max follower count.
- **Druidism magic system:** 16 spells requiring scrolls, cast at minimum Druidism levels.
- **Druidic Herbalism crafting:** 17 recipes using Druid Cauldron + jars.
- **[Taming](taming.md):** tame creatures; Druidism gains passively during taming.
- **[Anatomy](anatomy.md):** evaluates humanoid physical stats (parallel lore skill).
- **[Research](../magic/research.md):** Divination spell uses DruidismGump for creature info.
- **[Global Shoppe](../crafting/global-shoppe.md):** Herbalist Shoppe uses (Druidism + Veterinary) / 2.
