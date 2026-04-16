# Player Wiki

This is documentation for players around all of the systems in this game.

# Goals

The main goal is to document all of the main game systems that would be useful for a player who is playing the game.

This should include, but is not an all-encompassing list:
* Player attributes and what things they affect
* Player skills and all the things they affect
* Player spell systems
* Combat mechanics
* All discoverable books
* All items in the game and their stats and special uses
* All creatures in the game and their stats and what type of loot they drop
* All tameables and their stats
* All quests
* Special characters in the game and their interactions
* All facets and highlights and things that are unique about those facets
* All commands that can be used (admin and player)

# Structure

* All docs are in markdown format, and should link to relevant other docs
* All docs must be in the wiki folder
* Create folders to group topics logically
* There should be a main index at `wiki/README.md` that links to all major sections

Suggested folder layout:
```
wiki/
  README.md            ← main index, links to all sections
  getting-started/     ← new player basics, attributes, character creation
  skills/              ← one doc per skill
  magic/               ← one doc per spell system
  crafting/            ← one doc per craft profession
  quests/              ← quest types and guides
  creatures/           ← creature families, stats, loot tables
  items/               ← item categories, stats, special uses
  commands/            ← player and admin commands
  world/               ← facets, regions, landmarks
  systems/             ← achievements, pets, champion spawns, etc.
```

# Scope — what exists in the codebase

Use this as a checklist when deciding what to document. All of these systems exist in source.

**19 magic/spell systems:**
Magery, Necromancy, Druidism, Holy Man, Jedi, Knight (Chivalry), Witch, Bushido, Bard, Mystic, Elementalism, Ninjitsu, Shinobi, Death Knight, Research, Jester, Syth, special attack spells (Misc), and SpecialMoves

**22 crafting professions:**
Alchemy, Apothecary, Blacksmithy, Bonecrafting, Bowfletching, Carpentry, Cartography, Cooking, Draconic, Druidism, Glassblowing, Inscription, Lapidary, Leatherworking, Masonry, Shelves, Stitching, Tailoring, Tinkering, Wands, Wax Crafting, Witchery

**~27 skills:**
Anatomy, Arms Lore, Begging, Discordance, Druidism, Forensics, Healing, Hiding, Inscribe, Meditation, Mercantile, Parrying, Peacemaking, Poisoning, Provocation, Psychology, Remove Trap, Searching, Snooping, Spiritualism, Stealing, Stealth, Taming, Tasting, Tracking — plus weapon abilities (30+ special moves)

**Quest types (24+):**
Assassin, Bards Tale, Codex, Epic, Fishing, Frankenstein, Golems, Hoard, Jester, Magic Pools, Major, Museum, Pagan, Prisoners, Robots, Runes, Search, Serpents, Shadowlords, Standard, Summon, Thief, Underworld, and more

**Creature families (22):**
Animals, Civilized, Constructs, Demons, Dragons, Elementals, Gargoyles, Goliaths, Hellish, Humanoids, Insects, Mystical, Plants, Races, Reptilian, Slimes, Summoned, Undead, Unique, Unusual, Base, Omni AI

**Item categories (25):**
Abstractions, Armor, Boats, Books, Clothing, Containers, Deeds, Explorers, Food, Games, Gems, Houses, Instruments, Magical, Misc, Potions, Quivers, Relics, Sharpening, Special, Technology, Trades, Traps, Trinkets, Weapons

**Other notable systems:**
Achievements, Avatar/leveling, Champion spawns, Pet leveling (Jako Pets), Spell Bars, Temptations/alignment, Gardening, Apiculture (beekeeping), Taxidermy, Harvest (Mining, Fishing, Lumberjacking, Grave Robbing), Bulk Orders, Global Shoppes, Puzzle Chests

# Source code navigation

All discovery should be done by reading source — do not change any code.

| What you're documenting | Where to look |
|---|---|
| Spell systems | `World/Source/Scripts/Engines and Systems/Magic/<SystemName>/` |
| Skills | `World/Source/Scripts/System/Skills/` |
| Crafting systems | `World/Source/Scripts/Engines and Systems/Trades/Crafting/Def<Name>.cs` |
| Quests | `World/Source/Scripts/Engines and Systems/Quests/` |
| Creature stats | Constructor of each mobile in `World/Source/Scripts/Mobiles/<Family>/` |
| Item properties | Constructor of each item in `World/Source/Scripts/Items/<Category>/` |
| Player commands | `World/Source/Scripts/System/Commands/` |
| Core mechanics (death, regen, notoriety) | `World/Source/Scripts/System/Misc/` |
| Server settings affecting gameplay | `World/Info/Scripts/Settings.cs` (`MySettings` class) |
| Avatar/level system | `World/Source/Scripts/Engines and Systems/Avatar/` |
| Achievement system | `World/Source/Scripts/Engines and Systems/Achievments/` |
| Champion spawns | `World/Source/Scripts/Engines and Systems/Champs/` |
| Pet leveling | `World/Source/Scripts/Engines and Systems/Jako Pets/` |
| Harvest systems | `World/Source/Scripts/Engines and Systems/Trades/Harvest/` |

# Formatting conventions

* Use markdown tables for stat blocks (creatures, items, skills)
* Use relative links for cross-references, e.g. `[Magery](../magic/magery.md)`
* Prefer a consistent page template per category — lead with a short description, then a stats/properties table, then details/notes
* Creature pages: name, family, habitat, stats (Hits, Str, Dex, Int, resistances), notable loot, tameable (yes/no), notes
* Item pages: name, category, properties/stats, how to obtain, special uses
* Skill pages: what it does, how to train it, what affects it, related systems

# Other useful information

* This code is based off of the RunUO Ultima Online server emulator
* Use the code as the source of truth, but do not change any code
* You can write and run scripts to help in discovery
* Creature stats (HitsMax, Str, Dex, Int, resistances, loot) are typically set in the constructor of each mobile class
* Item properties follow the same pattern — read the constructor and any `OnAdded`/`OnSingleClick` methods
* The `MySettings` class in `World/Info/Scripts/Settings.cs` (~800 lines, 12 categories) documents many server-wide gameplay values useful to mention in docs
