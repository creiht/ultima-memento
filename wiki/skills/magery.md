# Magery

Magery is the traditional arcane casting skill. It governs your ability to successfully cast spells from a standard Spellbook and determines the power and reliability of most Magery effects. It is also the skill checked when casting directly from scrolls.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Intelligence |
| Usage | Active (cast spells or use scrolls) |
| Type | Magic |

## What It Affects

- Success chance when casting any spell from a standard Spellbook.
- Scroll casting (scrolls use a reduced skill requirement of circle − 2).
- Damage and potency of most Magery spells that scale with the caster's skill.
- Resistance checks for many Magery debuffs (Clumsy, Curse, Paralyze, Mind Blast, etc.).
- Success of summoning and dispelling creatures.

## How to Train

- Cast spells from a Spellbook — every cast rolls a skill gain check.
- Cast from scrolls at low skill to learn higher-circle spells before you can cast them from memory.
- Fizzle-rate drops rapidly as skill approaches the spell's circle requirement, so moving up in circles keeps gain rates high.
- Meditation and high Intelligence help sustain casting long enough to gain.

## Related Systems

- [Magery magic system](../magic/magery.md) — full spell list, circles, and reagent costs.
- [Meditation](meditation.md) — regenerates the mana Magery consumes.
- [Inscription](../crafting/inscription.md) — craft Magery scrolls and spellbooks.
- [Magic Resistance](magic-resistance.md) — defensive counter to hostile Magery.

### Spellcasting

- `Spell.cs:50` — `MagerySpell.CastSkill` defaults to `SkillName.Magery`; all Magery spells use this skill for cast chance and damage scaling.
- `MagerySpell.cs:28-38` — `GetCastSkills()` defines the success range per spell circle: range is `circle*100/7 ± 20` for spellbook casts (reduced by 2 circles when casting from scrolls).
- `MagerySpell.cs:41` — Mana cost per circle: `[4, 6, 9, 11, 14, 20, 40, 50]` for circles 1–8.
- `MagerySpell.cs:48-57` — `GetResistSkill()` sets the target's Magic Resist cap based on spell circle.
- `MagerySpell.cs:80-91` — `GetResistPercentForCircle()` computes dispel resistance: `(magicResist/2) - (magery-20)/10 - (circle+1)*5 / 2`.
- `MagerySpell.cs:93-99` — Cast delay scales with circle: `(3 + circle) * CastDelaySecondsPerTick`.
- `Spell.cs:776` — Spell casting speed cap is reduced to 2 (from 4) for Magery/Elementalism/Necromancy casts; Knightship casters with Magery ≥70 also get the tighter cap.
- `SpellHelper.cs:359` — Stat gain from `GainStat()` uses `ItemSkillValue(Magery) * 0.1 + 1` as baseline when no stat is specified.

### Spell-Specific Mechanics

| Spell | Effect of Magery |
|---|---|
| Heal (`Heal.cs`) | Heals `skill/5 + 5` hits |
| Magic Arrow (`MagicArrow.cs`) | Damage = `(Magery + Int)/5` |
| Energy Bolt (`EnergyBolt.cs`) | Damage = `(Magery + Int)/5` |
| Fireball (`Fireball.cs`) | Damage = `(Magery + Int)/5` |
| Lightning (`Lightning.cs`) | Damage = `(Magery + Int)/5` |
| Explosion (`Explosion.cs:84`) | Delayed damage bonus = `Magery / 5` |
| Mind Blast (`MindBlast.cs:56`) | Delayed damage bonus = `Magery / 5` |
| BladeSpirits (`BladeSpirits.cs:62`) | Summon duration bonus = `Magery / 2` seconds |
| MagicReflect (`MagicReflect.cs:65`) | Damage absorb = `(Magery + Psychology) / 4` |
| Curse (`Curse.cs`) | Debuff amount scales with caster Magery |
| Dispel (`Dispel.cs`) | Dispel effectiveness scales with caster Magery |

### Weapon Damage

- `BaseWeapon.cs:795-801` — Weapons with the `MageWeapon` attribute (0–30) apply a skill modifier to Magery: `mod = MageWeapon - 30`. A +30 MageWeapon weapon gives +0 bonus; +20 gives -10.
- `BaseWeapon.cs:2397` — `GetDamageScale()` gives a damage bonus for staff/wand users: `GetBonus(Magery, 0.625, 100.0, 6.25)` — each point of Magery adds 0.625 damage at low skill, capping at 6.25 bonus at 100 Magery.
- `BaseWeapon.cs:893-894` — When using a staff/wand, if Magery > the equipped weapon skill, the weapon skill is replaced by Magery for attack rolls.
- `BaseWeapon.cs:2299-2307` — `WizardCheck()` classifies the player as "mage" if Magery is highest among Magery/Necromancy/Elementalism; determines job title and access to arcane items.

### Armor & Item Requirements

- `AOS.cs:953` — Polymorph spell is forcibly ended if Magery drops below 66.1.
- `AOS.cs:962` — Incognito spell is forcibly ended if Magery drops below 38.1.
- `Spellbook.cs:805,811` — Ancient Spellbook and regular Spellbooks require at least 30.0 base Magery (or base Necromancy ≥30 for Ancient) to equip.
- `FamiliarItem.cs:84` — Familiars require at least 50 base Magery, Elementalism, or Necromancy to summon.

### NPC & AI Behavior

- `OmniAI Core.cs:55` — NPCs with Magery base > 10.0 can use Magery spells (`m_CanUseMagery`).
- `OmniAI Magery.cs:101-103` — AI with Magery > 80 casts `ManaVampire`; between 40–80 casts `ManaDrain`.
- `OmniAI Magery.cs:139,165` — AI with Magery ≥ 40 can use summoning and self-buff spells.
- `OmniAI Magery.cs:205` — AI checks foe Magery > 35 to decide on defensive tactics.
- `OmniAI Magery.cs:229` — AI with Magery > 95 and sufficient mana casts `ManaVampire` in combat.
- `OmniAI Magery.cs:246` — AI with Magery > 55 can cast 5th-circle spells in combat.
- `OmniAI Magery.cs:265` — AI picks spell tier based on `Magery / 14.2` to determine max circle available.
- `Behavior.cs:9195-9201` — NPC healing chance = 10% at GM magery; teleport chance = 5% at GM magery, scaled by `ScaleByMagery() = Magery * factor * 0.01`.
- `Behavior.cs:6261` — Magery is listed as a valid skill for NPC skill targeting.
- `BaseCreature.cs:6496` — Dispel prevention: NPCs with Magery < 53 and Necromancy < 80 cannot be dispelled.
- `BaseCreature.cs:6584` — `DispelChecks()`: 75% base dispel chance at GM magery, scaled by `Magery * 0.75 / 100`.
- `BaseCreature.cs:2645` — Certain creature types (e.g., summons) are set with Magery 120.1–130.0.
- `BaseCreature.cs:2681` — Mage-type creatures are set with Magery 90.1–100.0.

### Regions & Gate Access

- `MoonCore.cs:55,76` — Moon facet requires Magery ≥ 80 (or Elementalism/Necromancy ≥ 80) to remain; otherwise teleports out.
- `DawnRegion.cs:36,57` — Dawn facet requires Magery ≥ 80 to enter/stay.
- `LunaRegion.cs:37,56` — Luna facet requires Magery ≥ 80 to enter/stay.

### Character Creation & Titles

- `CharacterCreation.cs:293-294` — Mage starter class receives a Spellbook and random Magery scrolls (1st + one 2nd circle).
- `CharacterCreation.cs:894` — Mage starter begins with Magery at 30.0.
- `Players.cs:43,255` — Magery can be the displayed skill title (option 31 in character screen).
- `Skills.cs:169` — Characters with base GM Magery ≥ 100 AND base GM Necromancy ≥ 100 earn the "Archmage" title (if not Barbaric or Oriental).
- `Skills.cs:157,192` — Barbaric characters with Magery title become "Shaman"; Oriental characters become "Wu Jen".
- `SkillCheck.cs:242` — Magery is a MagesGuild NPC guild skill (alongside Psychology and Meditation).

### Crafting & Tools

- `BaseRunicTool.cs:214,295,362` — Magery is one of the skills checked during runic tool crafting (alongside Inscription).
- `BaseRunicTool.cs:419-420` — Magery and Elementalism are treated as equivalent/synergistic for runic tool checks.

### Research System

- `ResearchFunctions.cs:365` — Consuming scrolls for research checks Magery (alongside Necromancy, Spiritualism, Psychology) in the range `[spellSkill-20, spellSkill+20]`.
- `ResearchBag.cs:163-187` — Research runes with Elementalism skill bonuses can be rerolled to Magery or Necromancy if those aren't already present on the rune.

### Begging

- `Begging.cs:51-54` — `IsMageryCreature()` identifies AI_Mage creatures with Magery base > 5.0 as valid begging targets.

### Druidism

- `Druidism.cs:511` — Druidism gump displays Magery as a "Lore & Knowledge" talent alongside Meditation and Psychology.

### Character Titles Reference

| Magery Level | Title (standard) | Title (Barbaric) | Title (Oriental) |
|---|---|---|---|
| 0 | Village Idiot | Village Idiot | Village Idiot |
| 0.1–39.9 | Aspiring | Aspiring | Aspiring |
| 40–49.9 | Novice | Novice | Novice |
| 50–59.9 | Apprentice | Apprentice | Apprentice |
| 60–69.9 | Journeyman | Journeyman | Journeyman |
| 70–79.9 | Expert | Expert | Expert |
| 80–89.9 | Adept | Adept | Adept |
| 90–99.9 | Master | Master | Master |
| 100+ | Grandmaster → Archmage* | Shaman | Wu Jen |

*Archmage requires Magery ≥ 100 AND Necromancy ≥ 100 simultaneously.
