# Player Wiki Documentation Plan

## Overview

Implement comprehensive player-facing documentation for the Ultima Memento game server, covering all major game systems as defined in `wiki/AGENTS.md`. The wiki currently contains only `AGENTS.md` — all documentation must be built from scratch by reading source code.

**Approach:** Phased rollout (~10 phases), each delivering a complete, independently useful section. Creatures and items use a hybrid model: category overview pages with tables, plus individual pages for notable/unique entries.

**Source of truth:** All content is derived from reading source code under `World/Source/Scripts/` and `World/Info/Scripts/`. No code changes allowed.

---

## Phase 1: Scaffolding & Getting Started

**Goal:** Create the directory structure, page templates, main index, and new-player basics.

### Tasks

1. **Create directory structure** per `wiki/AGENTS.md`:
   ```
   wiki/
     README.md
     getting-started/
     skills/
     magic/
     crafting/
     quests/
     creatures/
     items/
     commands/
     world/
     systems/
   ```

2. **Create `wiki/README.md`** — main index linking to all major sections. Each section gets a short description and link. This will be updated as each phase completes.

3. **Create page templates** (internal reference, not published):
   - Creature template: name, family, habitat, stats table (Hits, Str, Dex, Int, resistances), notable loot, tameable (yes/no), notes
   - Item template: name, category, properties/stats table, how to obtain, special uses
   - Skill template: what it does, how to train, what affects it, related systems
   - Spell template: name, school, circle/level, mana cost, reagents, effect description, notes
   - Quest template: name, type, giver/location, objectives, rewards, walkthrough notes

4. **Write `wiki/getting-started/README.md`** — new player guide:
   - Character creation basics
   - Link to `World/Source/Scripts/Engines and Systems/Avatar/AvatarStarterTemplates.cs` for starter templates
   - Overview of the attribute system (Str, Dex, Int and what they affect)
   - Source: `World/Source/Scripts/System/Misc/` for core mechanics, `World/Info/Scripts/Settings.cs` for gameplay values

5. **Write `wiki/getting-started/attributes.md`** — detailed attribute breakdown:
   - Read `PlayerContext.cs`, `AvatarEngine.cs`, `Settings.cs` for stat caps, regen rates, derived effects
   - Document each primary attribute and what it influences

6. **Write `wiki/getting-started/death-and-resurrection.md`**:
   - Source: `World/Source/Scripts/System/Misc/` (death-related files)

7. **Write `wiki/getting-started/notoriety.md`**:
   - Source: `World/Source/Scripts/System/Misc/` (notoriety files)

**Deliverable:** 5-6 wiki pages, full directory skeleton, working README index.

---

## Phase 2: Skills

**Goal:** Document all ~26 skills and the weapon abilities system.

### Tasks

1. **Write `wiki/skills/README.md`** — skills overview and index, linking to each skill page.

2. **Create one page per skill** (`wiki/skills/<skill-name>.md`), ~26 pages:
   - Source: `World/Source/Scripts/System/Skills/<Skill>.cs`
   - Each page: description, how to train, what affects it, related systems, stat effects
   - Skills: Anatomy, Arms Lore, Begging, Discordance, Druidism, Forensics, Healing, Hiding, Inscribe, Meditation, Mercantile, Parrying, Peacemaking, Poisoning, Provocation, Psychology, Remove Trap, Searching, Snooping, Spiritualism, Stealing, Stealth, Taming, Tasting, Tracking

3. **Write `wiki/skills/weapon-abilities.md`** — overview of the weapon ability system:
   - Source: `World/Source/Scripts/System/Skills/Weapon Abilities/`
   - Table of all 30+ special moves with: name, weapon types, effect, mana cost
   - Group base abilities vs Extra abilities

4. **Update `wiki/README.md`** with skills section link.

**Deliverable:** ~28 wiki pages.

---

## Phase 3: Magic Systems

**Goal:** Document all 19 spell schools.

### Tasks

1. **Write `wiki/magic/README.md`** — magic systems overview and index.

2. **Create one page per spell school** (`wiki/magic/<school-name>.md`), 19 pages:
   - Source: `World/Source/Scripts/Engines and Systems/Magic/<SchoolName>/`
   - Each page: school description, how to access/train, spell list table (name, circle/level, mana cost, reagents, effect), related skill, notes
   - Schools: Magery, Necromancy, Druidism, Holy Man, Jedi, Knight (Chivalry), Witch, Bushido, Bard, Mystic, Elementalism, Ninjitsu, Shinobi, Death Knight, Research, Jester, Syth, Misc (special attack spells), SpecialMoves

3. **Write `wiki/magic/spell-bars.md`** — how the spell bar system works:
   - Source: look for SpellBar-related files in Scripts

4. **Update `wiki/README.md`** with magic section link.

**Deliverable:** ~21 wiki pages.

---

## Phase 4: Crafting & Trades

**Goal:** Document all 22 crafting professions and related trade systems (harvest, bulk orders, gardening, etc.).

### Tasks

1. **Write `wiki/crafting/README.md`** — crafting overview and index.

2. **Create one page per crafting profession** (`wiki/crafting/<profession>.md`), 22 pages:
   - Source: `World/Source/Scripts/Engines and Systems/Trades/Crafting/Def<Name>.cs`
   - Each page: description, required skill, resource types, craftable items table (name, skill required, resources, properties), notes
   - Professions: Alchemy, Apothecary, Blacksmithy, Bonecrafting, Bowfletching, Carpentry, Cartography, Cooking, Draconic, Druidism, Glassblowing, Inscription, Lapidary, Leatherworking, Masonry, Shelves, Stitching, Tailoring, Tinkering, Wands, Wax Crafting, Witchery

3. **Write harvest system pages** under `wiki/crafting/`:
   - `wiki/crafting/mining.md` — Source: `Trades/Harvest/Mining.cs`, `RichVeins/`
   - `wiki/crafting/lumberjacking.md` — Source: `Trades/Harvest/Lumberjacking.cs`, `RichLumberjacking/`
   - `wiki/crafting/fishing.md` — Source: `Trades/Harvest/Fishing.cs`
   - `wiki/crafting/grave-robbing.md` — Source: `Trades/Harvest/GraveRobbing.cs`

4. **Write trade support system pages**:
   - `wiki/crafting/bulk-orders.md` — Source: `Trades/Bulk Orders/`, `Trades/BulkCraft/`
   - `wiki/crafting/global-shoppes.md` — Source: `Trades/Global Shoppe/`

5. **Update `wiki/README.md`** with crafting section link.

**Deliverable:** ~29 wiki pages.

---

## Phase 5: Creatures

**Goal:** Document all 22 creature families using hybrid approach — category overview pages with summary tables, plus individual pages for unique/notable creatures.

### Tasks

1. **Write `wiki/creatures/README.md`** — creatures overview and index linking to each family.

2. **Create one overview page per creature family** (`wiki/creatures/<family>.md`), 22 pages:
   - Source: `World/Source/Scripts/Mobiles/<Family>/`
   - Each page: family description, table of all creatures in family (name, hits, str, dex, int, resists, tameable, notable loot)
   - Stats read from each mobile's constructor
   - Families: Animals, Civilized, Constructs, Demons, Dragons, Elementals, Gargoyles, Goliaths, Hellish, Humanoids, Insects, Mystical, Plants, Races, Reptilian, Slimes, Summoned, Undead, Unique, Unusual, Base, Omni AI

3. **Create individual pages for notable creatures** (`wiki/creatures/notable/<creature>.md`):
   - Champion spawn bosses (Barracoon, Lord Oaks, Mephitis, Neira, Rikktor, Semidar, Silvani)
   - Unique creatures (all ~20 from the Unique family)
   - Dragon variants (if significantly different)
   - Estimated: ~30 individual pages

4. **Write `wiki/creatures/tameables.md`** — cross-reference page listing all tameable creatures with stats:
   - Search constructors for `Tamable = true` or equivalent

5. **Update `wiki/README.md`** with creatures section link.

**Deliverable:** ~54 wiki pages.

**Discovery approach:** Write a helper script to parse creature constructors and extract stats (HitsMax, Str, Dex, Int, resistances, Tamable flag, loot). Run this to generate raw data tables, then manually clean up for wiki pages.

---

## Phase 6: Items

**Goal:** Document all 25 item categories using hybrid approach.

### Tasks

1. **Write `wiki/items/README.md`** — items overview and index linking to each category.

2. **Create one overview page per item category** (`wiki/items/<category>.md`), 25 pages:
   - Source: `World/Source/Scripts/Items/<Category>/`
   - Each page: category description, table of items (name, stats/properties, how to obtain, special notes)
   - Categories: Abstractions, Armor, Boats, Books, Clothing, Containers, Deeds, Explorers, Food, Games, Gems, Houses, Instruments, Magical, Misc, Potions, Quivers, Relics, Sharpening, Special, Technology, Trades, Traps, Trinkets, Weapons

3. **Create individual pages for notable items** (`wiki/items/notable/<item>.md`):
   - Relics (28 files — likely unique artifacts)
   - Special items (33 files)
   - Magical items of note
   - Estimated: ~30-40 individual pages

4. **Write `wiki/items/armor-guide.md`** — consolidated armor comparison:
   - Source: `Items/Armor/` — 16 files covering armor types
   - Resistance tables, material bonuses

5. **Write `wiki/items/weapons-guide.md`** — consolidated weapon comparison:
   - Source: `Items/Weapons/` — 18 files
   - Damage, speed, special abilities per weapon type

6. **Update `wiki/README.md`** with items section link.

**Deliverable:** ~60 wiki pages.

**Discovery approach:** Similar to creatures — script to extract item properties from constructors.

---

## Phase 7: Quests

**Goal:** Document all 24+ quest types.

### Tasks

1. **Write `wiki/quests/README.md`** — quests overview and index.

2. **Create one page per quest type** (`wiki/quests/<quest-type>.md`), 24 pages:
   - Source: `World/Source/Scripts/Engines and Systems/Quests/<QuestType>/`
   - Each page: quest type description, how to start, objectives, rewards, walkthrough, related NPCs/locations
   - Types: Assassin, Bards Tale, Codex, Epic, Fishing, Frankenstein, Golems, Hoard, Jester, Magic Pools, Major, Museum, Pagan, Prisoners, Robots, Runes, Search, Serpents, Shadowlords, Standard, Summon, Thief, Underworld

3. **Write `wiki/quests/quest-system.md`** — how the quest system works overall:
   - Source: `Quests/Core/` (15 files — quest engine)

4. **Update `wiki/README.md`** with quests section link.

**Deliverable:** ~26 wiki pages.

---

## Phase 8: Systems (Achievements, Pets, Champions, etc.)

**Goal:** Document the miscellaneous game systems that don't fit other categories.

### Tasks

1. **Write `wiki/systems/README.md`** — systems overview and index.

2. **Write `wiki/systems/avatar-leveling.md`** — the Avatar/leveling system:
   - Source: `Engines and Systems/Avatar/` (10 files + Reward subdir)
   - Level progression, rewards shop, starter templates

3. **Write `wiki/systems/achievements.md`** — achievement system:
   - Source: `Engines and Systems/Achievments/` (7 achievement types)
   - List all achievement types with descriptions and requirements

4. **Write `wiki/systems/champion-spawns.md`** — champion spawn system:
   - Source: `Engines and Systems/Champs/`
   - How spawns work, progression, bosses (with links to creature pages), rewards

5. **Write `wiki/systems/pet-leveling.md`** — Jako pet leveling system:
   - Source: `Engines and Systems/Jako Pets/Attributes/`
   - How pets level, which attributes improve, caps

6. **Write `wiki/systems/gardening.md`**:
   - Source: `Trades/Gardening/` (15 files)

7. **Write `wiki/systems/apiculture.md`** — beekeeping:
   - Source: `Trades/Apiculture/` (8 files)

8. **Write `wiki/systems/taxidermy.md`**:
   - Source: `Trades/Taxidermy/` (6 files)

9. **Write `wiki/systems/temptations.md`** — alignment/temptation system:
   - Search for temptation-related files

10. **Write `wiki/systems/puzzle-chests.md`**:
    - Search for puzzle chest implementation

11. **Update `wiki/README.md`** with systems section link.

**Deliverable:** ~11 wiki pages.

---

## Phase 9: World (Facets, Regions, Landmarks)

**Goal:** Document the game world geography.

### Tasks

1. **Write `wiki/world/README.md`** — world overview and index.

2. **Identify all facets** — Search source for facet definitions:
   - Source: `World/Source/Scripts/System/Misc/` and map data references
   - `World/Info/Scripts/Settings.cs` for enabled facets

3. **Create one page per facet** (`wiki/world/<facet-name>.md`):
   - Description, unique features, notable locations, dungeons, related quests
   - Estimated: 5-8 pages depending on facet count

4. **Write `wiki/world/dungeons.md`** — dungeon index if applicable.

5. **Update `wiki/README.md`** with world section link.

**Deliverable:** ~8-12 wiki pages.

---

## Phase 10: Commands

**Goal:** Document all player and admin commands.

### Tasks

1. **Write `wiki/commands/README.md`** — commands overview, split into player vs admin sections.

2. **Write `wiki/commands/player-commands.md`**:
   - Source: `World/Source/Scripts/System/Commands/Player/` (~52 files)
   - Table: command name, syntax, description, notes
   - Commands include: Afk, AutoAttack, BandSelf, CombatBar, CorpseSearch, Emote, Loot, MusicPlayer, Organize, QuickBar, Quests, SkillsGump, WealthBar, etc.

3. **Write `wiki/commands/admin-commands.md`**:
   - Source: `World/Source/Scripts/System/Commands/` (loose files, ~40)
   - Table: command name, access level, syntax, description
   - Commands include: Add, AdminGump, Builders, Dupe, Properties, Skills, SpawnerCatalog, Wipe, etc.

4. **Update `wiki/README.md`** with commands section link.

**Deliverable:** ~3-4 wiki pages.

---

## Phase 11: Books

**Goal:** Document all discoverable in-game books.

### Tasks

1. **Write `wiki/items/books.md`** (or expand the Phase 6 books page):
   - Source: `World/Source/Scripts/Items/Books/` (15 files)
   - List all books: title, where to find, contents summary, lore significance

**Deliverable:** 1 wiki page (may already exist from Phase 6 — expand it).

---

## Execution Notes

### Discovery Scripts

For phases with large numbers of entities (creatures, items), write and run C#-parsing helper scripts to bulk-extract stats from constructors. This avoids manually reading 1000+ files. Script approach:
- Use regex or simple parsing to find `SetStr()`, `SetDex()`, `SetInt()`, `SetHits()`, resistance setters, `Tamable`, loot additions
- Output CSV/markdown tables that can be pasted into wiki pages
- Scripts go in a temporary location, not committed

### Cross-Linking

Each page should include relative links to related pages:
- Skill pages link to related magic schools, crafting professions
- Creature pages link to the facet/region they appear in
- Item pages link to crafting profession that creates them
- Quest pages link to creatures, items, and locations involved

### Quality Checks Per Phase

Before marking a phase complete:
- All links in README.md work
- All pages follow the template format
- Stats are verified against source code
- Cross-links between sections are in place

---

## Phase Summary

| Phase | Section | Est. Pages | Dependencies |
|-------|---------|-----------|--------------|
| 1 | Scaffolding & Getting Started | 5-6 | None |
| 2 | Skills | ~28 | Phase 1 |
| 3 | Magic Systems | ~21 | Phase 1 |
| 4 | Crafting & Trades | ~29 | Phase 1 |
| 5 | Creatures | ~54 | Phase 1 |
| 6 | Items | ~60 | Phase 1 |
| 7 | Quests | ~26 | Phase 1 |
| 8 | Systems | ~11 | Phase 1 |
| 9 | World | ~8-12 | Phase 1 |
| 10 | Commands | ~3-4 | Phase 1 |
| 11 | Books | 1 | Phase 6 |
| **Total** | | **~250-260** | |

Phases 2-10 depend only on Phase 1 (scaffolding) and can be executed in any order. Phase 11 is a minor addition to Phase 6.
