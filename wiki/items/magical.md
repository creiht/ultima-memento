# Magical Items

The Magical category is the largest item category, encompassing reagents, magical consumables, enchanted equipment, and all artifacts. This page covers non-artifact magical items; for artifacts see [artifacts/README.md](artifacts/README.md).

## Reagents

Reagents are consumed when casting spells. They are stackable and weigh 1 stone per unit (standard). Each magic system uses different reagents.

### Standard Magery Reagents (8)

These are the classic 8 reagents used by the Magery spell system. All weigh 1.0 stone per unit, stackable.

| Reagent | Used In |
|---------|---------|
| Black Pearl | Magery (movement and energy spells) |
| Blood Moss | Magery (movement spells) |
| Garlic | Magery (protection spells) |
| Ginseng | Magery (healing spells) |
| Mandrake Root | Magery (summoning and high-power spells) |
| Nightshade | Magery (poison and death spells) |
| Spider's Silk | Magery (web/restraint spells) |
| Sulfurous Ash | Magery (fire/explosion spells) |

### Necromancy Reagents (5)

| Reagent | Notes |
|---------|-------|
| Bat Wing | Standard necromancy ingredient |
| Daemon Blood | Demon essence |
| Grave Dust | Dust from graves |
| Nox Crystal | Poison/necromancy crystal |
| Pig Iron | Heavy iron for necromancy |

### Witch Reagents (7)

| Reagent | Notes |
|---------|-------|
| Bitter Root | Witch magic ingredient |
| Black Sand | Dark sand component |
| Blood Rose | Rare rose |
| Dried Toad | Preserved toad |
| Maggot | Decay reagent |
| Mummy Wrap | Ancient bandage |
| Wolfsbane | Wolf-bane herb |
| Violet Fungus | Purple mushroom |
| Werewolf Claw | Lycanthrope ingredient |

### Unique/Rare Reagents (13)

Rare reagents used in special crafting recipes or high-powered spells:

| Reagent | Notes |
|---------|-------|
| Demigod Blood | Very rare |
| Demon Claw | Demon drop |
| Dragon Blood | Dragon loot |
| Dragon Tooth | Dragon tooth |
| Enchanted Seaweed | Aquatic magic |
| Ghostly Dust | From ghosts |
| Golden Feathers | Rare bird drop |
| Golden Serpent Venom | Rare snake drop |
| Lich Dust | Lich remains |
| Pegasus Feather | Pegasus mount drop |
| Phoenix Feather | Phoenix drop |
| Silver Serpent Venom | Silver snake |
| Unicorn Horn | Unicorn drop |

### Alchemy Reagents (10)

Used in Alchemy crafting for potions and special concoctions:

| Reagent | Notes |
|---------|-------|
| Beetle Shell | Insect component |
| Brimstone | Volcanic mineral |
| Butterfly Wings | Lepidoptera component |
| Eye of Toad | Amphibian component |
| Fairy Egg | Fae creature drop |
| Gargoyle Ear | Gargoyle loot |
| Moon Crystal | Lunar crystal |
| Pixie Skull | Pixie remain |
| Red Lotus | Rare flower |
| Sea Salt | Ocean mineral |
| Silver Widow | Spider silk variant |
| Swamp Berries | Swamp plant |

## Spell Scrolls

Scrolls allow anyone to cast a spell once regardless of skill (though success varies). They are stackable and weigh less than spellbooks. Scrolls exist for every spell in every magic school:

| Magic School | Scroll Count | Notes |
|-------------|-------------|-------|
| Magery | 64 (8 circles × 8 spells) | Found as loot, crafted via Inscription |
| Necromancy | ~17 spells | Necromantic dark magic |
| Chivalry | ~10 spells | Knight/paladin prayers |
| Bushido | ~6 spells | Samurai techniques |
| Ninjitsu | ~7 spells | Ninja techniques |
| Mysticism | ~16 spells | Ancient mystical magic |
| Other Schools | Varies | Druidism, Holy Man, Witch, Jedi, Elementalism, etc. |

Scrolls are crafted via the **Inscription** skill and also found as dungeon loot scaled to difficulty.

## Magical Consumables & Tools

### Moonstone

| Property | Value |
|----------|-------|
| Weight | 1.0 |
| Effect | Opens a moongate lasting **120 seconds** at your feet |
| Restrictions | Cannot be used in no-recall/no-gate regions or Kuldar (requires Vordo Key) |
| Consumed | Yes — single use |

The moongate created by a Moonstone allows free travel similar to the Gate Travel spell.

### Slayer Deed

| Property | Value |
|----------|-------|
| Weight | Varies by type |
| Effect | Applies a Slayer property to a weapon or instrument in your backpack |
| Target | Weapon or instrument; must not already have 2 slayers on it |
| Consumed | Yes — single use |
| Can apply | Up to **2 slayer properties** total on any weapon/instrument |

Double-click the deed, then target a weapon or instrument. The deed applies the appropriate slayer type (e.g., Dragon Slayer, Undead Slayer, Demon Slayer).

### Lucky Horse Shoes

| Property | Value |
|----------|-------|
| Weight | 1.0 |
| Effect | Adds up to **100 Luck** to any eligible item |
| Target | Weapon, armor, clothing, trinket, spellbook, quiver, or instrument |
| Consumed | Yes — single use |

Will not apply if the item already has ≥ 100 Luck. Sets Luck to `min(100, current + 100)`.

### Weapon Renaming Tool

Allows you to rename a weapon in your backpack. Single use.

### Rune of Virtue

| Property | Value |
|----------|-------|
| Weight | 1.0 |
| Slot | Trinket layer |
| Type | Levelable talisman (LevelTalismanHoly base class) |
| Notes | Account-bound to its owner; side (Virtue / Temptation) set by a property |

A special leveling trinket tied to the virtue/temptation alignment system. Cannot be worn by a character on the wrong alignment.

### Soul Orb

A special magical orb related to soul mechanics. See [Special Items](special.md) for soul-related items.

## Enchanted Equipment (Randomly Generated)

### Magic Quiver

`MagicQuiver` is a randomly generated quiver with a random color and a randomly generated name adjective. Properties are random (generated the same as any magical quiver via the random loot system). It is the base random quiver found in loot.

### Gifts System (Random Magical Gear)

The **Gifts/** sub-system provides randomly generated magical equipment distributed as event gifts or special rewards. Categories:

| Category | Examples |
|----------|---------|
| Armor | Magical helms, chest pieces, gloves, gorgets, leggings |
| Clothing | Magical clothing with random skill/stat bonuses |
| Weapons | Magical weapons with random damage bonuses, slayers, hit effects |
| Jewelry | Magical rings, bracelets with random attributes |
| Shields | Magical shields with random defensive bonuses |

These use `BaseRunicTool.ApplyAttributes` to generate random properties at random intensity.

### God-Tier Levelable Items (God/ system)

The **God/** sub-folder contains a levelable item system. Items in this system gain experience and level up over time, gaining enhanced properties. Categories follow the same breakdown as Gifts (armor, clothing, weapons, jewelry, shields). These are high-tier items that advance with use.

Each God-tier item has:
- An **experience** counter that fills with kills
- **Level** that advances when XP thresholds are met
- Enhanced base stats and magical properties that scale with level
- Special level-up effects

## Special Named Magical Items

| Item | Description | Obtain |
|------|-------------|--------|
| Dracula's Sword | Named legendary sword with vampire theme | Special boss/event |
| Hydra Tooth | Special magical tooth item | Hydra monster drop |
| Staff of Five Parts | Named staff requiring 5 components to assemble | Quest / exploration |
| Rune of Virtue | Alignment-based trinket (see above) | Virtue/Temptation system |
| Artifact Manual | A book describing the artifact system | Loot, vendors |
| Manual of Items | A book cataloguing magical items | Loot, vendors |

## Artifacts

Artifacts are unique named items with powerful fixed properties. See [artifacts/README.md](artifacts/README.md) for the complete catalogue (354 items across 12 categories including weapons, armor, jewelry, clothing, instruments, books, shields, offhands, quivers, and sets).

## How to Obtain Magical Items

- **Crafting**: Inscription (scrolls), Alchemy (potions using reagents)
- **Loot**: Monsters drop magical equipment scaled to their difficulty level
- **Treasure Chests**: Dungeon chests contain reagents, scrolls, and magical gear
- **Merchants**: Reagents, basic scrolls, and spellbooks from magic vendors
- **Quests**: Named artifacts from quest chains and boss encounters
- **Sage Artifact Quest**: The primary source of all standard artifacts

## Cross-links

- [Artifacts Overview](artifacts/README.md)
- [Potions](potions.md) — alchemy products using reagents
- [Relics](relics.md) — collectible dungeon treasure
- [Magic Systems](../../magic/) — individual spell school documentation
