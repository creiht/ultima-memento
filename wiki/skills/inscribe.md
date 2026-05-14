# Inscribe

Inscribe allows you to copy the contents of one book to another, duplicating text including title, author, and all pages.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Intelligence |
| Usage | Active (targeted) |
| Range | 3 tiles |
| Skill Check | 0 - 50 |

## How It Works

1. Use the skill and target the **source book** you wish to copy.
2. Then target the **destination book** to copy the contents into.

On success, the destination book receives the title, author, and all page contents of the source book.

### Requirements

- The source book must not be empty.
- The destination book must be **writable**.
- You cannot copy a book onto itself.
- No one else can be inscribing either book at the same time.
- Each targeting step has a 1-minute timeout.

## How to Train

Copy books repeatedly. The skill check ranges from 0 to 50, so gaining slows significantly after 50 skill. At higher skill levels, you will need other means of training (such as scribe-crafting if available).

## What It Affects

### Book Copying
- `Inscribe.cs:136` — `CheckTargetSkill(SkillName.Inscribe, bookDst, 0, 50)` — The skill check range for copying books is 0–50. Above 50, copying always succeeds but does not train.

### Combat & Weapons
- `BaseWeapon.cs:1892` — `GetAosDamage()` adds a damage bonus of `inscribe/200` (rounded down). At 1000+ inscribe, an additional +5 flat bonus is applied to weapon damage.

### Magic Systems

#### Magery — Reactive Armor
- `ReactiveArmor.cs:62` — Physical resist bonus = `15 + (inscribe / 20)`. Higher inscribe increases the physical protection of the spell.

#### Magery — Protection
- `Protection.cs:70` — Physical resist penalty = `-15 + min(inscribe/20, 15)`. At 60+ inscribe, the penalty is fully negated (returns 0).
- `Protection.cs:71` — Magic Resist penalty = `-35 + min(inscribe/20, 35)`. At 175+ inscribe, the penalty is fully negated.

#### Jedi — Psychic Aura
- `PsychicAura.cs:44` — Physical resist = `inscribe/15 + jediDamage/50`.
- `PsychicAura.cs:45` — Energy resist = `inscribe/25 + jediDamage/75`.

#### Runebook Crafting
- `Runebook.cs:504` — Max charges on crafted runebooks = `12 + (quality * inscribeValue / 20)`. At 125+ inscribe, +6 bonus charges are added.

### Research System
- `ResearchBag.cs:41` — Requires 30+ inscribe to open and read a Research Bag.
- `ResearchFunctions.cs:1117,1464,1538` — Minimum inscribe skill required to attempt scribing each specific spell/scroll.
- `ResearchFunctions.cs:1139,1486,1498,1560,1573` — `CheckSkill(Inscribe, 0, 125)` on every scribing attempt (range 0–125).
- `ResearchFunctions.cs:1137,1484,1558` — Failure check against `RandomMinMax(skill-25, skill+25)`. Lower inscribe means higher failure rate.
- On failure, mana, ink, scrolls, quills, and reagents may be consumed (`ResearchFunctions.cs:1141-1145`).
- `Scribe.cs:96` — Buy Research Bag for 500 gold; requires 30+ inscribe.
- `Sage.cs:76` — Buy Research Bag for 500 gold; requires 30+ inscribe.
- `LibrarianGuildmaster.cs:76` — Buy Research Bag for 500 gold; requires 30+ inscribe.

### Crafting & Harvest

#### Librarian Harvest
- `Librarian.cs:50` — The Librarian harvest defines its skill as `Inscribe`.
- `Librarian.cs:218` — Bonus discovery check: `inscribe > Random(5000)` as a prerequisite.
- `Librarian.cs:221` — `CheckSkill(Inscribe, 0, 125)` to discover rare bonus items (spellbooks, deeds, power scrolls, treasure maps, artifacts, stone tablets).
- `Librarian.cs:239` — Stone tablet coin price scales with inscribe: `+RandomMinMax(1, inscribe*2)`.

#### General Harvest
- `HarvestSystem.cs:248` — Blank scroll yield bonus: `amount + (inscribe / 10)` additional scrolls per harvest.
- `HarvestSystem.cs:412` — DDRelicBook coin price scales with inscribe: `+RandomMinMax(1, inscribe*2)`.
- `HarvestSystem.cs:426` — DDRelicScrolls coin price scales with inscribe: `+RandomMinMax(1, inscribe*2)`.

### Vendors & Trading
- `BaseVendor.cs:2301` — At 50+ inscribe, a "Setup Shoppe" entry becomes available at Scribe, Sage, and Librarian Guildmaster vendors.
- `Scribe.cs:96` — Research Bag purchase requires 30+ inscribe.
- `Sage.cs:76` — Research Bag purchase requires 30+ inscribe.
- `LibrarianGuildmaster.cs:76` — Research Bag purchase requires 30+ inscribe.

### Quests & Loot

#### Scroll Clue Quests
- `ScrollClue.cs:507` — Deciphering coded scrolls requires either sufficient Intelligence OR inscribe between 30–120.

#### Lucky Drops
- `DropRelic.cs:150` — 10% chance (on lucky kill vs wizard slayers) to drop a TomeOfWands when inscribe ≥ 20 AND magery ≥ 20.

### Related Skills
- [Mercantile](mercantile.md) — Identifying items.
- [Magery](../magic/magery.md) — Reactive Armor and Protection spells benefit from high inscribe.
- [Jedi](../magic/jedi.md) — Psychic Aura resistances scale with inscribe.
- [Research](../magic/research.md) — Core skill for the research system; scribing scrolls and spells.
