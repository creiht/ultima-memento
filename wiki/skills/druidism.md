# Druidism

Druidism lets you examine creatures to learn detailed information about their stats, resistances, and taming requirements, while also governing druidic herbalism crafting and the casting of 16 nature-themed spells.

## Overview

| Property | Value |
|---|---|
| **Primary Stat** | Intelligence |
| **Usage** | Active (targeted — lore creatures) |
| **Skill Type** | Trainable |
| **Skill Check** | 0 – 125 |

## Description

Druidism provides a "Monster Manual" for examining creatures, modifies taming difficulty, and unlocks a full druidic magic system and herbalism crafting profession. It is one of four animal-related skills that determine follower capacity and stable slots.

## How It Works

### Creature Lore (Monster Manual)

Target any animal-type creature to open a detailed information gump showing Power Level, damage types, combat ratings, resistances, stats, and taming info.

**Skill gate thresholds:**

- **Below 100:** Only lore your own tamed creatures (`Druidism.cs:72`).
- **100+:** Lore tamed or tameable creatures from any owner (`Druidism.cs:76`).
- **110+:** Lore any creature, including untameable ones (`Druidism.cs:80`).

**Skill check:** `CheckTargetSkill(Druidism, creature, 0.0, 125.0)` on successful lore (`Druidism.cs:80`).

**Creature type restrictions:** does not work on slimes (SlimyScourge Slayer), elementals (ElementalBan), Repond (Repond Slayer), silvers (Silver Slayer), giants (GiantKiller), golems (GolemDestruction), humanoids, undead, or dead pets (`Druidism.cs:48-54`).

### Taming

- **Passive Druidism gains:** when taming a creature for the first time (`!alreadyOwned`), `CheckTargetSkill(Druidism, creature, 0.0, 125.0)` is triggered as a gain check (`Taming.cs:309,324`).
- **Taming modifier:** Druidism.Value / 5 is subtracted from the taming difficulty check (`Taming.cs:333`).
- **Taming lore bonus:** when Druidism.Base > Taming.Base, the lore value (Druidism × 10) is used instead of taming value for taming calculations (`BaseCreature.cs:1999-2002`).

### Druidic Herbalism Crafting

Druidism is the primary skill for **Druidic Herbalism** (also called Druid Herbalism), a craft system using a **Druid Cauldron** as the required tool (`DruidCauldron.cs:9`).

**17 recipes** are available, each requiring a Druidism range and a Veterinary sub-skill range (`DefDruidism.cs:94-172`):

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

All potions are brewed in jars (not bottles) and stored in a **Druid Pouch** (`DruidPouch.cs`). The **Book of Druidic Herbalism** (`BookDruidBrewing.cs`) provides a full recipe guide with descriptions.

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
- Runebook gating: Druidism > 0 gates visibility of Nature's Passage and Mushroom Gateway spells in the runebook (`RunebookGump.cs:355,371,382`).
- Lure Stone spell: Druidism.Value determines tamer skill for lured creatures (`LureStoneSpell.cs:141,340`).

### Pet Follower Capacity

Druidism.Base is one of four skills (with Herding, Veterinary, Taming) that determine max follower count:

- All four >= 60: **6 followers** (`PlayerMobile.cs:659`).
- All four >= 90: **7 followers** (`PlayerMobile.cs:656`).
- All four >= 120: **8 followers** (`PlayerMobile.cs:653`).

### Stable Slots

Stable slots (via AnimalTrainer) are determined by the sum of Taming + Druidism + Veterinary + Herding, with each skill individually giving +1 slot per 10 points above 90.0 (`AnimalTrainer.cs:238-276`). See [Veterinary](veterinary.md) for the full slot table.

## How to Train

Target creatures to open the lore gump. The skill check range is 0 – 125, and passive gains also occur when taming creatures for the first time.

## What It Affects

### Creature Lore & Taming

- `Druidism.cs:48-54` — Creature type restrictions: slimes, elementals, Repond, silvers, giants, golems, humanoids, undead, and dead pets cannot be lore'd.
- `Druidism.cs:72` — Below 100: only lore own tamed creatures.
- `Druidism.cs:76` — 100+: lore tamed or tameable creatures from any owner.
- `Druidism.cs:80` — 110+: lore any creature; skill check `CheckTargetSkill(Druidism, creature, 0.0, 125.0)`.
- `Taming.cs:309,324` — Passive Druidism gain on first-time tame (`CheckTargetSkill`).
- `Taming.cs:333` — Taming modifier: Druidism.Value / 5 subtracted from taming difficulty.
- `BaseCreature.cs:1999-2002` — Taming lore bonus: Druidism × 10 replaces taming value when Druidism.Base > Taming.Base.

### Druidic Herbalism Crafting

- `DefDruidism.cs:94-172` — 17 recipes with Druidism ranges (10–120) and Veterinary sub-skills (5–90).
- `DruidCauldron.cs:9` — Druid Cauldron is the required crafting tool.
- `DruidPouch.cs` — Potions stored in Druid Pouch.
- `BookDruidBrewing.cs` — Book of Druidic Herbalism provides full recipe guide.

### Druid Magic System

- `HerbalistSpell.cs:12` — `CastSkill = Druidism` for all 16 spells.
- `HerbalistSpell.cs:13` — Damage skill for herbalist potions is Veterinary.
- `HerbalistSpell.cs:35-43` — Spell resistances based on target's Magic Resist.
- `HerbalistSpell.cs:91-93` — Cast delay varies per spell.

### Pet Follower Capacity & Stable Slots

- `PlayerMobile.cs:641` — Follower count update triggered on Druidism skill changes.
- `PlayerMobile.cs:653` — All four >= 120: 8 followers.
- `PlayerMobile.cs:656` — All four >= 90: 7 followers.
- `PlayerMobile.cs:659` — All four >= 60: 6 followers.
- `AnimalTrainer.cs:238-276` — Stable slots determined by sum of Taming + Druidism + Veterinary + Herding.

### NPCs & Vendor Access

- `BaseVendor.cs:2294` — Herbalist, Druid, DruidTree, DruidGuildmaster vendors grant shop setup to players with Druidism.Value >= 50.
- `AnimalTrainer.cs:241` — AnimalTrainer NPC uses Druidism.Value for trade adjustments.
- `Druid.cs:31` — Druid merchant: Druidism 55–100.
- `DruidTree.cs:38` — DruidTree merchant: Druidism 55–100.
- `DruidGuildmaster.cs:29` — DruidGuildmaster merchant: Druidism 55–100.
- `Veterinarian.cs:27` — Veterinarian: Druidism 85–100.
- `Shepherd.cs:62` — Shepherd: Druidism 64–100.
- `Rancher.cs:25` — Rancher: Druidism 55–78.
- `Ranger.cs:28` — Ranger: Druidism 64–100.
- `RangerGuildmaster.cs` — RangerGuildmaster: Druidism 64–100.
- `AnimalTrainer.cs` — AnimalTrainer: Druidism 64–100.
- `Furtrader.cs` — Furtrader: Druidism 85–100.

### Item Bonuses

- `GuildRing.cs:83-89` — Druids Guild Ring: +10 Druidism (+5 Alchemy, +10 Taming, +10 Herding, +10 Veterinary, +5 Cooking).
- `Artifact_TheDryadBow.cs:21` — The Dryad Bow artifact: +25 Druidism.
- `ShoppeRewardGump.cs:120` — Ancient Herbalist Gloves: +5 Druidism, available from Global Shoppe rewards.

### Quests & Achievement Systems

- `HerbalistShoppe.cs:173` — Global Shoppe (Herbalist): effective skill = (Druidism + Veterinary) / 2 for reward calculations.
- `ResearchDivination.cs:74-83` — Research magic system: Divination spell opens DruidismGump — source 3 (Divination book) or source 4 (People's Handbook).
- `MonsterManual.cs:74-75` — Monster Manual book opens DruidismGump with source 1.
- `PlayersHandbook.cs:96-97` — Players Handbook book opens DruidismGump with source 2.
- `DynamicBook.cs:343` — DynamicBook assigns "Naturalist" as the Druidism skill title.
- `CodexWisdom.cs:78,388` — Codex of Wisdom includes Druidism in skill display and learning checks.

### Character Creation & Display

- `CharacterCreation.cs:960` — Druidism starts at 30 during character creation.
- `Players.cs:227` — Druidism.Base contributes to character title calculation.
- `SkillsGump.cs:69` — Character skill showcase: selectable as skill #36.
- `Elixirs.cs:272` — Druidism is a valid target skill for skill-enhancing elixirs.
- `SkillCheck.cs:18` — Druidism listed in the skill check table.
- `SkillCheck.cs:326` — Blackthorn's Dungeon: Druidism is one of 4 skills used in the dungeon's skill check.

## Related Systems & Skills

### Synergies
- [Veterinary](veterinary.md): required sub-skill for all herbalism recipes; damage skill for herbalist spell casting; paired with Druidism for pet healing and follower capacity.
- [Taming](taming.md): Druidism gains passively during taming; Druidism mod subtracts from taming difficulty; lore value can substitute for taming value in taming calculations.
- [Herding](herding.md): paired with Druidism, Veterinary, and Taming for max follower count and stable slots.

### Prerequisites / Co-requisites
- [Veterinary](veterinary.md): sub-skill for all 17 herbalism recipes; damage skill for herbalist spell casting.
- [Research](../magic/research.md): Divination spell uses DruidismGump for creature info (sources: Monster Manual, Players Handbook, Divination book, People's Handbook).
- [Anatomy](anatomy.md): evaluates humanoid physical stats (parallel lore skill).
- [Global Shoppe](../crafting/global-shoppe.md): Herbalist Shoppe uses (Druidism + Veterinary) / 2 for stock level and rewards.

## Notes
- Druidism is passively trained during Taming and Herding activities.
- The Druidism Animal Form grants additional combat stats and abilities based on the chosen animal.
- Druidism and Veterinary together determine max follower count and stable slots.
