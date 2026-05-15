# Elementalism

Elementalism is a reagent-free parallel to Magery organized into 8 Spheres, with spells themed to one chosen element (Air, Earth, Fire, or Water). The skill governs cast success and the power of elemental effects.

## Overview

| Property | Value |
|---|---|
| **Primary Stat** | Intelligence |
| **Usage** | Active (cast Elementalism spells) |
| **Skill Type** | Magic |
| **Skill Check** | 0–125 |

## Description

Elementalism uses an Elemental Spellbook trinket with 8 Spheres of spells themed to Air, Earth, Fire, or Water. Spells consume both stamina and mana, and the skill value directly affects cast success, resist checks, spell damage, and effect duration.

## How It Works

### Spell Casting Mechanics

- Success chance when casting from an Elemental Spellbook (`ElementalSpell.cs:11`).
- Minimum-skill gating per Sphere: 0 / 0 / 9 / 23 / 38 / 52 / 66 / 80 for Spheres 1–8 (via `GetCastSkills` in `ElementalSpell.cs:46-59`, based on circle index).
- Stamina cost per spell equals mana cost, modified by LowerRegCost attribute (`ElementalSpell.cs:94-106`).
- Armor fizzle chance: each equipped armor piece adds a percentage penalty, calculated by material type (`ElementalSpell.cs:450-488`). Mage armor and Spell Channeling armor bypass this penalty entirely.
- Mana cost per circle: 5 / 7 / 10 / 14 / 19 / 24 / 40 / 50 (`ElementalSpell.cs:61`).
- Cast delay scales with circle: `(3 + circle) * CastDelaySecondsPerTick` seconds (`ElementalSpell.cs:153-159`).
- Resist percent based on circle: `(skill/5) - (max((casterSkill-20)/5 + (1+circle)*5, 0))` all divided by 2 (`ElementalSpell.cs:140-151`).
- Magic Resist training per spell: each spell circle trains Magic Resist up to `10*(1+circle) + 25*(1+circle/6)` (`ElementalSpell.cs:108-117`).

### Spell Damage & Effects

- **Elemental Pain** — damage scales with proximity to caster, skill affects resist check (`Elemental_Pain.cs`).
- **Elemental Protection** — resistance reduction is `-15 + min(skill/20, 15)` physical and `-35 + min(skill/20, 35)` magic resist (`Elemental_Protection.cs:64-65`).
- **Elemental Field** — wall damage = `skill / 10`, duration = `(15 + skill/5) / 4 + skill/2` seconds (`Elemental_Field.cs:96-100`).
- **Elemental Fiend** — summon duration = `120 + skill/2` seconds (`Elemental_Fiend.cs:65`).
- **Elemental Storm** — damage tick bonus = `skill / 5` (`Elemental_Storm.cs:75`).
- **Elemental Wall** — duration benefit = `skill / 2` (`Elemental_Wall.cs:176`).
- **Elemental Hold** — immobilize duration affected by target's Magic Resist (check resisted calculation).
- **Elemental Barrage / Devastation / Fall / Apocalypse** — area-of-effect damage uses the same bonus formula as other magic skills.

### Weapon Bonus

Staff / Scepter / Wizard Wand / Stave weapons receive a damage bonus of `GetBonus(Elementalism, 0.625, 100.0, 6.25)` (`BaseWeapon.cs:2399`). This is the same bonus curve as Bushido, Necromancy, and Magery.

## How to Train

- Cast Elementalism spells from your Elemental Spellbook — each cast rolls a skill gain check.
- Elementalism spells consume **stamina in addition to mana**, so keep [Focus](focus.md) trained and avoid heavy encumbrance.
- Lower Reagent Cost items reduce the **stamina** cost rather than a reagent cost.
- Cast at the edge of each Sphere's threshold to move into higher-gain territory.

## What It Affects

### Guild & Region Access
- `SkillCheck.cs:248` — Elemental Guild membership — Elementalism is a core guild skill.
- `ElementalShrine.cs:88` — Requires 5.0 base Elementalism to change element focus at the Elemental Shrine.
- `Elemental_Sanctuary.cs:52-73` — At 90+ skill, can be cast in dungeons (otherwise restricted to outdoors/main region only).
- `MoonCore.cs:55`, `LunaRegion.cs:37`, `DawnRegion.cs:36` — Moon / Luna / Dawn regions require 80+ Elementalism (or Magery/Necromancy) to enter.

### Merchant & NPC Interactions
- `Elementalist.cs:57-60` — Elementalist vendor sells Elementalism-specific books, scrolls, and weapons.
- `ElementalGuildmaster.cs:193-214` — Elemental Guildmaster requires 50+ Elementalism (or Magery/Necromancy) for Star Sapphire gift, and 100+ for Henchman rewards.
- `MageGuildmaster.cs:220-221` — Mage Guildmaster uses the same 50/100 tier system for elementalists.
- `NecromancerGuildmaster.cs:267-288` — Necromancer Guildmaster uses the same 50/100 tier system for elementalists.
- `FamiliarItem.cs:84` — Familiar NPC requires 50+ Elementalism (or Magery/Necromancy) to receive a familiar.
- `OmniAI Magery.cs:209` — Enemies with 35+ Elementalism drain +0.2 additional mana.

### Quests & Achievements
- `Mangar.cs:335` — Mangar quest: Elementalism base skill is checked as one of four combat stats (alongside Necromancy, Magery, Musicianship) for determining reward quality.
- `DemonPrison.cs:204-205` — Demon Prison: Elementalism is the determining skill if higher than Magery and Necromancy, affecting gold return and success.
- `CodexWisdom.cs:440` — Codex of Knowledge: Elementalism is one of the 22+ skills tracked in wisdom rewards.
- `MangarsRewards.cs:88` — Bards Tale (Mangar's Rewards): Skill Bonus item grants +10 Elementalism.

### Items & Equipment
- `StaffOfFiveParts.cs:72` — Staff of Five Parts grants +25 Elementalism.
- `GuildRing.cs:111` — Guild Ring grants +10 Elementalism.
- 4-element Artifact sets (16 items total):
  - Robes: +20 Elementalism (`Artifact_RobeofStratos.cs`, `Artifact_RobeofPyros.cs`, `Artifact_RobeofLithos.cs`, `Artifact_RobeofHydros.cs:21`)
  - Mantles: +15 Elementalism (`Artifact_MantleofStratos.cs`, `Artifact_MantleofPyros.cs`, `Artifact_MantleofLithos.cs`, `Artifact_MantleofHydros.cs:21`)
  - Boots: +15 Elementalism (`Artifact_BootsofStratos.cs`, `Artifact_BootsofHydros.cs`, `Artifact_BootsofPyros.cs`, `Artifact_BootsofLithos.cs:23`)
  - Books: +10 to +20 Elementalism (`Artifact_StratosManual.cs:34`, `Artifact_PyrosGrimoire.cs:34`, `Artifact_HydrosLexicon.cs:34`, `Artifact_LithosTome.cs:34`)
- `PowerScroll.cs:63,190,331,427` — Power Scroll gives permanent cap upgrade for Elementalism.
- `BaseRunicTool.cs:199,319` — Tinkering, Carpentry, and Inscription runic tools can apply Elementalism-related mods.
- `ResearchBag.cs:168-233` — Research Bag runes can have Elementalism skill bonuses.

### Crafting
- `DefTinkering.cs:303-307` — Tinkering: crafting Elemental staves/sceptres requires 50.3–80.3 Elementalism.

### Race & Character Creation
- `BaseRace.cs:416,421,425` — Gargoyle race: Elementalism is available as a SkillBonus slot (multiple variants).
- `CharacterCreation.cs:472-477` — Not pickable as a starting skill.
- `CharacterCreation.cs:1042` — Excluded from bonus skill items in starter packs.

### Spell Restrictions
- `Spell.cs:680` — Cannot cast Elementalism spells if you have 1+ Magery and also 1+ Necromancy.
- `Spell.cs:682` — Cannot cast Elementalism spells if you have 1+ Magery and also 1+ Elementalism.
- `Spell.cs:684` — Cannot cast Research spells if you have 1+ Elementalism.
- `BaseWeapon.cs:2296-2313` — Staff weapon usage requires 30+ in your highest magic skill (Elementalism/Magery/Necromancy).
- `RunebookGump.cs:356` — Elementalism appears as a casting option when configured in a runebook.
- `HelpGump.cs:376` — Elementalism appears in spell help for those with 1+ skill.

## Related Systems & Skills

### Synergies
- [Focus](focus.md): Stamina regeneration, critical for Elementalism's dual mana+stamina cost.
- [Meditation](meditation.md): Mana regeneration for sustained casting.
- [Magic Resistance](magic-resistance.md): Defensive counter to hostile elemental magic; all Elementalism spells train Magic Resist.

### Prerequisites / Co-requisites
- [Elemental Shrine](../items/shrines.md): Requires 5.0 base Elementalism to change element focus.
- [Magery](../magic/magery.md): Mutually exclusive — cannot cast both Magery and Elementalism spells simultaneously.
- [Necromancy](../magic/necromancy.md): Mutually exclusive — cannot cast both Necromancy and Elementalism spells simultaneously.
- [Research](../magic/research.md): Cannot cast Research spells if you have any Elementalism.

### Synergies
- [Elementalism magic system](../magic/elementalism.md): Full spell list, 8 Spheres, 4 element types (Air, Earth, Fire, Water).
- [Elemental Guild](../world/guilds.md): Elementalism is the primary skill of the Elemental Guild.
- [Elemental Spellbook](../items/spellbooks.md): Trinket-slot item holding all learned Elementalism spells; 4 element variants.
- [Staves & Scepters](../items/weapons.md): Weapons that benefit from Elementalism damage bonus.
- [Elemental Artifacts](../items/artifacts.md): 4-element sets of Robes (+20), Mantles (+15), Boots (+15), Books (+10-20).
- [Staff of Five Parts](../items/artifacts.md): Artifact weapon granting +25 Elementalism.
- [Runic Tools](../items/runic-tools.md): Tinkering, Carpentry, and Inscription tools can apply Elementalism mods.
- [Guild Ring](../items/gear.md): Accessory granting +10 Elementalism.
- [Power Scrolls](../items/power-scrolls.md): Permanent skill cap increase for Elementalism.
- [Armor](../items/armor.md): Spell fizzle penalty scales with armor weight and material; Mage Armor and Spell Channeling bypass fizzle.
- [Elementalist vendor](../world/npcs.md): Sells Elementalism spellbooks, scrolls, and related supplies.
- [Elemental Guildmaster](../world/npcs.md): 90–100 Elementalism, offers guild rewards and familiar services.
- [Mangar Quest](../quests/epic.md): Unique boss fight; Elementalism skill level affects reward quality.
- [Demon Prison](../items/special.md): Shatter a demon prison shard; Elementalism is the determining magic skill if highest.
- [Codex of Knowledge](../quests/codex.md): Skill progress tracked for wisdom rewards.
- [Moon / Luna / Dawn facets](../world/facets.md): Require 80+ Elementalism (or Magery/Necromancy) to enter.
- [Bards Tale / Mangar's Rewards](../quests/bards-tale.md): Skill Bonus item grants +10 Elementalism.
- [Bushido](bushido.md): Same weapon damage bonus curve on staves/scepters.
- [Ninjitsu](ninjitsu.md): Same weapon damage bonus curve on staves/scepters.

## Notes

- Elementalism spells consume **both stamina and mana** simultaneously, making stamina management critical.
- The skill is mutually exclusive with both Magery and Necromancy — having 1 point in any of these locks out the others' spellcasting.
- At 90+ skill, the Elemental Sanctuary spell can be cast in dungeons instead of only outdoors/main region.
- Gargoyle race characters can use Elementalism as a SkillBonus slot.
- The skill check range (0–125) is higher than the standard 0–120, allowing power-skilled elementalists to cast at maximum efficiency.
