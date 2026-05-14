# Elementalism

Elementalism is the casting skill for the Elementalism magic system — a reagent-free parallel to Magery organized into 8 Spheres, with spells themed to one chosen element (Air, Earth, Fire, or Water). The skill governs cast success and the power of elemental effects.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Intelligence |
| Usage | Active (cast Elementalism spells) |
| Type | Magic |

## What It Affects

### Spell Casting
- Success chance when casting spells from an Elemental Spellbook (`ElementalSpell.cs:11`).
- Minimum-skill gating per Sphere: 0 / 0 / 9 / 23 / 38 / 52 / 66 / 80 for Spheres 1–8 (via `GetCastSkills` in `ElementalSpell.cs:46-59`, based on circle index).
- Stamina cost per spell equals mana cost, modified by LowerRegCost attribute (`ElementalSpell.cs:94-106`).
- Armor fizzle chance: each equipped armor piece adds a percentage penalty, calculated by material type (`ElementalSpell.cs:450-488`). Mage armor and Spell Channeling armor bypass this penalty entirely.
- Mana cost per circle: 5 / 7 / 10 / 14 / 19 / 24 / 40 / 50 (`ElementalSpell.cs:61`).
- Cast delay scales with circle: `(3 + circle) * CastDelaySecondsPerTick` seconds (`ElementalSpell.cs:153-159`).

### Spell Damage & Effects
- Elemental Pain — damage scales with proximity to caster, skill affects resist check (`Elemental_Pain.cs`).
- Elemental Protection — resistance reduction is `-15 + min(skill/20, 15)` physical and `-35 + min(skill/20, 35)` magic resist (`Elemental_Protection.cs:64-65`).
- Elemental Field — wall damage = `skill / 10`, duration = `(15 + skill/5) / 4 + skill/2` seconds (`Elemental_Field.cs:96-100`).
- Elemental Fiend — summon duration = `120 + skill/2` seconds (`Elemental_Fiend.cs:65`).
- Elemental Storm — damage tick bonus = `skill / 5` (`Elemental_Storm.cs:75`).
- Elemental Wall — duration benefit = `skill / 2` (`Elemental_Wall.cs:176`).
- Elemental Hold — immobilize duration affected by target's Magic Resist (check resisted calculation).
- Elemental Barrage / Devastation / Fall / Apocalypse — area-of-effect damage uses the same bonus formula as other magic skills.

### Weapon Bonuses
- Staff / Scepter / Wizard Wand / Stave weapons receive a damage bonus of `GetBonus(Elementalism, 0.625, 100.0, 6.25)` (`BaseWeapon.cs:2399`). This is the same bonus curve as Bushido, Necromancy, and Magery.

### Guild & Region Access
- Elemental Guild membership — Elementalism is a core guild skill (`SkillCheck.cs:248`).
- Elemental Shrine — requires 5.0 base Elementalism to change element focus (`ElementalShrine.cs:88`).
- Elemental Sanctuary — at 90+ skill, can be cast in dungeons (otherwise restricted to outdoors/main region only) (`Elemental_Sanctuary.cs:52-73`).
- Moon / Luna / Dawn regions — requires 80+ Elementalism, Magery, or Necromancy to enter (`MoonCore.cs:55`, `LunaRegion.cs:37`, `DawnRegion.cs:36`).

### Merchant & NPC Interactions
- Elementalist vendor — sells Elementalism-specific books and scrolls, plus weapons (`Elementalist.cs:57-60`).
- Elemental Guildmaster — requires 50+ Elementalism (or Magery/Necromancy) for Star Sapphire gift, and 100+ for Henchman rewards (`ElementalGuildmaster.cs:193-214`).
- Mage Guildmaster — same 50/100 tier system for elementalists (`MageGuildmaster.cs:220-221`).
- Necromancer Guildmaster — same 50/100 tier system for elementalists (`NecromancerGuildmaster.cs:267-288`).
- Familiar NPC — requires 50+ Elementalism (or Magery/Necromancy) to receive a familiar (`FamiliarItem.cs:84`).
- OmniAI — enemies with 35+ Elementalism drain +0.2 additional mana (`OmniAI Magery.cs:209`).

### Quests & Achievements
- Mangar quest — Elementalism base skill is checked as one of four combat stats (alongside Necromancy, Magery, Musicianship) for determining reward quality (`Mangar.cs:335`).
- Demon Prison — Elementalism is the determining skill if higher than Magery and Necromancy, affecting gold return and success (`DemonPrison.cs:204-205`).
- Codex of Knowledge — Elementalism is one of the 22+ skills tracked in wisdom rewards (`CodexWisdom.cs:440`).
- Bards Tale (Mangar's Rewards) — Skill Bonus item grants +10 Elementalism (`MangarsRewards.cs:88`).

### Items & Equipment
- Staff of Five Parts — grants +25 Elementalism (`StaffOfFiveParts.cs:72`).
- Guild Ring — grants +10 Elementalism (`GuildRing.cs:111`).
- Artifacts (4 elements × 4 pieces = 16 items):
  - Robes: +20 Elementalism (`Artifact_RobeofStratos.cs`, `Artifact_RobeofPyros.cs`, `Artifact_RobeofLithos.cs`, `Artifact_RobeofHydros.cs:21`)
  - Mantles: +15 Elementalism (`Artifact_MantleofStratos.cs`, `Artifact_MantleofPyros.cs`, `Artifact_MantleofLithos.cs`, `Artifact_MantleofHydros.cs:21`)
  - Boots: +15 Elementalism (`Artifact_BootsofStratos.cs`, `Artifact_BootsofHydros.cs`, `Artifact_BootsofPyros.cs`, `Artifact_BootsofLithos.cs:23`)
  - Manual/Grimoire/Lexicon/Tome books: +10 to +20 Elementalism (`Artifact_StratosManual.cs:34`, `Artifact_PyrosGrimoire.cs:34`, `Artifact_HydrosLexicon.cs:34`, `Artifact_LithosTome.cs:34`)
- Power Scroll — Elementalism has its own power scroll (cap upgrade) (`PowerScroll.cs:63,190,331,427`).
- Runic Tools — Tinkering, Carpentry, and Inscription runic tools can apply Elementalism-related mods (`BaseRunicTool.cs:199,319`).
- Research Bag — runes can have Elementalism skill bonuses (`ResearchBag.cs:168-233`).

### Crafting
- Tinkering — crafting Elemental staves/sceptres requires 50.3–80.3 Elementalism (`DefTinkering.cs:303-307`).

### Race & Character Creation
- Gargoyle race — Elementalism is available as a SkillBonus slot (multiple variants at `BaseRace.cs:416,421,425`).
- Character Creation — Elementalism is not pickable as a starting skill (`CharacterCreation.cs:472-477`).
- Starter pack exclusion — Elementalism is excluded from bonus skill items in starter packs (`CharacterCreation.cs:1042`).

### Spell Restrictions
- Cannot cast Elementalism spells if you have 1+ Magery and also 1+ Necromancy (`Spell.cs:680`).
- Cannot cast Elementalism spells if you have 1+ Magery and also 1+ Elementalism (`Spell.cs:682`).
- Cannot cast Research spells if you have 1+ Elementalism (`Spell.cs:684`).
- Staff weapon usage requires 30+ in your highest magic skill (Elementalism/Magery/Necromancy) (`BaseWeapon.cs:2296-2313`).
- Runebook — Elementalism appears as a casting option when configured (`RunebookGump.cs:356`).
- Help system — Elementalism appears in spell help for those with 1+ skill (`HelpGump.cs:376`).

### Resist Calculations
- All Elementalism spells use the Magic Resist skill for defense, with resist percent based on circle: `(skill/5) - (max((casterSkill-20)/5 + (1+circle)*5, 0))` all divided by 2 (`ElementalSpell.cs:140-151`).
- Magic Resist training: each spell circle trains Magic Resist up to `10*(1+circle) + 25*(1+circle/6)` (`ElementalSpell.cs:108-117`).

## How to Train

- Cast Elementalism spells from your Elemental Spellbook — each cast rolls a skill gain check.
- Elementalism spells consume **stamina in addition to mana**, so keep [Focus](focus.md) trained and avoid heavy encumbrance.
- Lower Reagent Cost items reduce the **stamina** cost rather than a reagent cost.
- Cast at the edge of each Sphere's threshold to move into higher-gain territory.

## Related Systems

### Core Mechanics
- [Elementalism magic system](../magic/elementalism.md) — full spell list, 8 Spheres, 4 element types (Air, Earth, Fire, Water), and element-specific spell effects.
- [Meditation](meditation.md) — mana regeneration for sustained casting.
- [Focus](focus.md) — stamina regeneration, important for Elementalism's stamina cost.
- [Magic Resistance](magic-resistance.md) — defensive counter to hostile elemental magic; all Elementalism spells train Magic Resist.
- [Armor](../items/armor.md) — spell fizzle penalty scales with armor weight and material; Mage Armor and Spell Channeling bypass fizzle.

### Guild & NPCs
- [Elemental Guild](../world/guilds.md) — Elementalism is the primary skill of the Elemental Guild.
- [Elementalist vendor](../world/npcs.md) — sells Elementalism spellbooks, scrolls, and related supplies.
- [Elemental Guildmaster](../world/npcs.md) — 90–100 Elementalism, offers guild rewards and familiar services.

### Items & Equipment
- [Elemental Spellbook](../items/spellbooks.md) — trinket-slot item holding all learned Elementalism spells; comes in 4 element variants (Air/Earth/Fire/Water).
- [Elemental Shrine](../items/shrines.md) — world objects that let you switch your element focus (requires 5.0 base).
- [Power Scrolls](../items/power-scrolls.md) — permanent skill cap increase for Elementalism.
- [Staves & Scepters](../items/weapons.md) — weapons that benefit from Elementalism damage bonus.
- [Elemental Artifacts](../items/artifacts.md) — 4-element sets of Robes (+20), Mantles (+15), Boots (+15), and Books (+10-20) that boost Elementalism.
- [Staff of Five Parts](../items/artifacts.md) — artifact weapon granting +25 Elementalism.
- [Runic Tools](../items/runic-tools.md) — Tinkering, Carpentry, and Inscription tools can apply Elementalism mods.
- [Guild Ring](../items/gear.md) — accessory granting +10 Elementalism.

### Quests & Special Locations
- [Mangar Quest](../quests/epic.md) — Unique boss fight; Elementalism skill level affects reward quality.
- [Demon Prison](../items/special.md) — shatter a demon prison shard; Elementalism is the determining magic skill if highest.
- [Codex of Knowledge](../quests/codex.md) — skill progress tracked for wisdom rewards.
- [Moon / Luna / Dawn facets](../world/facets.md) — require 80+ Elementalism (or Magery/Necromancy) to enter.
- [Bards Tale / Mangar's Rewards](../quests/bards-tale.md) — Skill Bonus item grants +10 Elementalism.

### Cross-Skill Interactions
- [Magery](magery.md) — mutually exclusive with Elementalism; cannot cast both types of spells simultaneously.
- [Necromancy](necromancy.md) — mutually exclusive with Elementalism; cannot cast both types of spells simultaneously.
- [Research](../magic/research.md) — cannot cast Research spells if you have any Elementalism.
- [Bushido](bushido.md) — same weapon damage bonus curve on staves/scepters.
- [Ninjitsu](ninjitsu.md) — same weapon damage bonus curve on staves/scepters.

### Related Skills
- Synergy: Elementalism pairs with [Focus](focus.md) for stamina sustain and [Meditation](meditation.md) for mana sustain.
- Synergy: [Magic Resistance](magic-resistance.md) is trained by all Elementalism spells and protects against enemy Elementalism.
- Prerequisite: None formally, but [Elemental Shrine](../items/shrines.md) access requires 5.0 base.
