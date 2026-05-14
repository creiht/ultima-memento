# Swordsmanship

Swordsmanship is the hit skill for bladed melee weapons and the default fallback weapon skill. It also serves as the damage and aggro skill for the Jedi and Syth magic systems.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Strength |
| Usage | Passive (every swing / every Jedi or Syth cast) |
| Cooldown | None |

## How It Works

### Weapons That Use Swordsmanship

Any weapon that does not explicitly declare a different `DefSkill` falls back to Swordsmanship. This covers long swords, katanas, Viking swords, broadswords, scimitars, and many other bladed weapons.

### Hit Chance

Hit chance for both the attacker and the defender is resolved using `GetUsedSkill()` on each side. Tactics and Strength contribute damage; Dexterity affects swing speed.

### Jedi and Syth Magic

Swordsmanship is the **damage skill** for both the Jedi and Syth magic systems:

- Spell damage scales from Swordsmanship value.
- Aggro generation = `Tactics + Swordsmanship`.
- **Minimum requirements to use any Jedi or Syth spell:** 10 Swordsmanship + 10 Tactics + 10 Psychology.

See [Jedi](../magic/jedi.md) and [Syth](../magic/syth.md) for full spell lists.

## How to Train

Swordsmanship gains passively on every swing with a sword-type weapon. Casting Jedi/Syth spells also triggers gain checks.

## What It Affects

### Combat & Weapons

- `BaseWeapon.cs:215` — `DefSkill` defaults to `SkillName.Swords` for every weapon that doesn't override it (long swords, katanas, broadswords, scimitars, cleavers, cutlasses, viking swords, etc.).
- `BaseWeapon.cs:872-899` — `GetUsedSkill()` compares Swordsmanship against Fencing, Bludgeoning, and FistFighting when the weapon has `UseBestSkill > 0`, selecting whichever is highest.
- `BaseWeapon.cs:3456` — Weapons display "skill required: swordsmanship" in their item info text.
- `WeaponAbility.cs:70` — Swordsmanship contributes to the total skill pool used to calculate mana cost reduction for weapon abilities (10% reduction at 300 total, 5% at 200 total).
- `WeaponAbility.cs:118` — With `UseBestSkill`, if Swordsmanship meets the requirement, weapon abilities are available even if the weapon's declared skill differs.
- `WeaponAbility.cs:143` — `GetWeaponSkill()` uses Swordsmanship as the first candidate when selecting best skill for abilities.
- `CustomWeaponAbilities.cs:60` — Weapon ability availability check: if `UseBestSkill > 0`, Swordsmanship value is checked against tier requirements (primary: config base, secondary: +10, third: +20, fourth: +30, fifth: +40).
- `AbilityBook.cs:182` — Swordsmanship is factored into mana redux calculation for weapon abilities.
- `WeaponArmorCalls.cs:16,97,120` — Swordsmanship is the default skill in `GetTrueBestSkill` and contributes to `ManaRedux.CalculateSpecialMana`.

### Magic Systems

- `JediSpell.cs:22` — Jedi spells use Swordsmanship as the `DamageSkill`, meaning spell damage scales from your Swordsmanship value.
- `JediSpell.cs:137` — Minimum casting requirement: 10 Swordsmanship + 10 Tactics + 10 Psychology.
- `JediSpell.cs:375` — Aggro generation = `Tactics + Swordsmanship` (capped at 375).
- `JediSpell.cs:382,390` — Spell casting checks Swordsmanship value against required skill threshold.
- `SythSpell.cs:22` — Syth spells also use Swordsmanship as the `DamageSkill`.
- `SythSpell.cs:137` — Same minimum casting requirement as Jedi: 10 Swords + 10 Tactics + 10 Psychology.
- `SythSpell.cs:382,389,397` — Aggro and spell checks use Swordsmanship identically to Jedi.

### Crafting & Harvest

- `BaseRunicTool.cs:230,277,340,382` — Runic tools can apply +15-30% Swordsmanship bonus to weapons whose skill is Swords (along with Tactics).
- `BaseRunicTool.cs:250,260` — Armor and shields can receive Swordsmanship bonuses when rolled by runic tools.
- `BaseRunicTool.cs:348,356` — Book of Bushido and Book of Chivalry can receive Swordsmanship bonuses.

### Items

- `ItemProperties.cs:623` — When inspecting weapons via tool menus, "Skill: Swordsmanship" is displayed for Swords-type weapons.
- `DynamicBook.cs:343` — `LearnTitles` book documents the trade title for Swordsmanship as "Man-at-arms".
- `PaganArtifact.cs:275` — Pagan weapon artifacts can roll 15-30% bonus to Swordsmanship.

### AI & NPCs

- `TownGuards.cs:34` — Town Guards have 200.0 Swordsmanship (alongside all other combat skills at 200.0).
- `Behavior.cs:3194,3401` — Mangar's Tower and similar NPC behaviors set Swordsmanship to `50.0 + myBonus` on generated creatures.
- `Behavior.cs:6280` — Swordsmanship is included in the NPC skill gain list (index 40).
- `SkillCheck.cs:256` — Warriors Guild NPCs can gain skillup on Swordsmanship.
- **Notable NPC Swordsmanship values:**
  - Pirate Captains / Elf Pirate Captains: 125.0
  - Executioners: 125.0
  - Lost Knights, Murks, Kulls, Grundul Vargs, Soul Reapers: 125.0
  - Revenants: 100.0 * scalar
  - Banes (Insanity, Anarchy, Wantonness): 110.0
  - Orc Captain, Orks: 70-95.0
  - Pirates / Crew: 65-87.5
  - Savages, Natives, Lizardmen: 60-87.5
  - Lizardmen / Reptaur: 65-87.5
  - Ghost Warriors / Ghost Pirates: 65-87.5
  - Ophidian Warriors: 60-85.0
  - Monks / Rogues / Brigands: 50-87.5 (with bonus)

### Quests

- `SummonPrison.cs:749,808` — Summoned boss NPCs (e.g., knight-themed summons) are given 125.0 Swordsmanship.
- `PaganArtifact.cs:275` — Pagan artifact weapon rewards can include Swordsmanship skill bonuses.
- `CodexWisdom.cs:432` — Codex of Wisdom can teach Swordsmanship to players.

### Related Systems

- `SkillCheck.cs:56` — Swordsmanship is skill index 40 in the anti-macro gain array. Anti-macro is **disabled** (`false`) for Swordsmanship — meaning it can be trained anywhere by swinging weapons without location restrictions.
- `SkillCheck.cs:256` — Warriors Guild affiliation grants skillup on Swordsmanship.
- `CharacterCreation.cs:389` — Swordsmanship class choice during character creation grants a random starting weapon (Bokuto, Cleaver, or Cutlass).
- `Players.cs:571` — Syth alignment detection: players with 50+ Swordsmanship, 50+ Psychology, and karma <= -5000 are flagged as "evil" (Syth alignment).
- `BaseRace.cs:1340` — Race skill mapping: skill index 40 maps to `SkillName.Swords`.
- `ResourceMods.cs:1899` — Resource modification system: variable index 47 maps to Swordsmanship.
- `SkillArchive.cs:208` — Avatar system SkillArchive has a dedicated `Swords` property.
- `SkillsGump.cs:103,515` — Skill listing gumps render Swordsmanship at display index 47/48.

### Related Skills

- [Tactics](tactics.md) — damage amplifier; required for weapon ability tiers and Jedi/Syth threshold.
- [Parrying](parrying.md) — defensive complement to any weapon skill.
- [Psychology](psychology.md) — third prerequisite for Jedi/Syth casting.
- [Fencing](fencing.md) — alternative weapon skill; compared via UseBestSkill on weapons.
- [Bludgeoning](bludgeoning.md) — alternative weapon skill; compared via UseBestSkill on weapons.
- [Fist-Fighting](fist-fighting.md) — alternative weapon skill; compared via UseBestSkill on weapons.
- [Arms Lore](arms-lore.md) — identifies weapon stats for swords; synergizes with weapon selection.
- Jedi magic: [wiki/magic/jedi.md](../magic/jedi.md).
- Syth magic: [wiki/magic/syth.md](../magic/syth.md).
- Weapon Abilities: [wiki/systems/weapon-abilities.md](../systems/weapon-abilities.md) (if it exists).
