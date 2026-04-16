# Base Spell System & Special Moves

The Base directory contains the core spell system infrastructure that all magic schools build upon. It also includes the Special Move system used by weapon abilities.

## Core Components

| File | Purpose |
|------|---------|
| Spell.cs | Base class for all spells; handles casting, fizzling, mana consumption |
| SpellInfo.cs | Defines spell metadata (name, mantra, reagents) |
| SpellRegistry.cs | Global registry mapping spell IDs to spell types |
| Initializer.cs | Registers all spells from all schools at server startup |
| SpellHelper.cs | Utility methods: damage calculations, targeting, line of sight |
| SpellCircle.cs | Defines the 8 circles (First through Eighth) |
| Reagent.cs | Reagent type definitions |
| Runebook.cs | Runebook item for storing marked recall runes |
| SpecialMove.cs | Base class for weapon special moves |

## Spell Registration

All spells across every school are registered in `Initializer.cs` with unique numeric IDs:

| ID Range | School |
|----------|--------|
| 0-63 | [Magery](magery.md) (8 circles x 8 spells) |
| 100-116 | [Necromancy](necromancy.md) |
| 131-162 | [Witch](witch.md) and [Druidism](druidism.md) |
| 200-209 | [Knight (Chivalry)](knight.md) |
| 250-259 | [Mystic](mystic.md) |
| 260-269 | [Jester](jester.md) |
| 270-279 | [Syth](syth.md) |
| 280-289 | [Jedi](jedi.md) |
| 290-297 | [Shinobi](shinobi.md) |
| 300-331 | [Elementalism](elementalism.md) |
| 351-366 | [Bard Songs](bard.md) |
| 400-405 | [Bushido](bushido.md) |
| 500-507 | [Ninjitsu](ninjitsu.md) |
| 600-663 | [Research](research.md) |
| 700-706 | [Misc Spells](misc-spells.md) |
| 750-763 | [Death Knight](death-knight.md) |
| 770-783 | [Holy Man](holy-man.md) |

## Special Moves

Weapon special moves are combat abilities tied to specific weapon types. They are not cast like spells but activated through the combat system. See your weapon's properties to discover which special moves it supports.

## Forgetful Gem

The Forgetful Gem item allows a player to forget/unlearn spells from their spellbooks, freeing up capacity for new spells.
