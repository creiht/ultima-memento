# Marksmanship

Marksmanship is the hit and defence skill for all ranged weapons including bows, crossbows, throwing gloves, harpoons, and sci-fi firearms.

## Overview

| Property | Value |
|---|---|
| **Primary Stat** | Dexterity |
| **Usage** | Passive |
| **Skill Type** | Combat |
| **Skill Check** | None (anti-macro disabled) |

## Description

Marksmanship governs hit chance, defence rating, and damage recovery for every ranged attack. It is declared as both the defence reference skill and accuracy skill on all ranged weapon families. Tactics and Strength contribute to damage separately, while Dexterity affects swing speed and stamina cost.

## How It Works

### Hit Chance

Hit chance is calculated using the attacker's Marksmanship versus the defender's active defence skill using the standard `BaseWeapon` formula.

### Skill Gain

Ranged skill gain fires on every attack with `checkSkills = true`. Marksmanship does NOT use anti-macro code, so it can be trained anywhere without target/position restrictions. Skill gains fire on every ranged attack regardless of target.

### Weapon Ability Tiers

All weapon special ability tier thresholds for ranged weapons check Marksmanship alongside Tactics.

## How to Train

Attack with any ranged weapon. Marksmanship gains passively on every shot.

## What It Affects

### Combat & Weapons

- `BaseRanged.cs:26,30` — `DefSkill` and `AccuracySkill` both return `SkillName.Marksmanship` for all bows and crossbows
- `Harpoon.cs:18,22` — `DefSkill` and `AccuracySkill` = Marksmanship
- `ThrowingGloves.cs:120` — `DefSkill` = Marksmanship
- `MonsterGloves.cs:84` — `DefSkill` = Marksmanship
- `WizardStaff.cs:207,211` — `DefSkill` and `AccuracySkill` = Marksmanship
- `BaseKilrathi.cs:17,23` — `DefSkill` and `AccuracySkill` = Marksmanship (sci-fi firearms)
- `LevelStave.cs:206,210` — `DefSkill` and `AccuracySkill` = Marksmanship (god weapon)
- `LevelHarpoon.cs:18,22` — `DefSkill` and `AccuracySkill` = Marksmanship (god weapon)
- `LevelThrowingGloves.cs:106` — `DefSkill` = Marksmanship (god weapon)
- `GiftHarpoon.cs:18,22` — `DefSkill` and `AccuracySkill` = Marksmanship (gift weapon)
- `GiftThrowingGloves.cs:106` — `DefSkill` = Marksmanship (gift weapon)
- `GiftStave.cs:206,210` — `DefSkill` and `AccuracySkill` = Marksmanship (gift weapon)
- `BaseWeapon.cs:3459` — displays "skill required: marksmanship" on item property tooltips for ranged weapons
- `BaseRanged.cs:112-113` — 40% chance to recover ammo on hit against animal/monster NPCs
- `BaseRanged.cs:158-188` — 40% chance to recover ammo on miss; recoverable ammo tracked via `RecoverableAmmo` dictionary

### Weapon Abilities & Mana

- `WeaponAbility.cs:71` — Marksmanship skill total contributes to special move mana reduction; at combined weapon skill >= 300, special moves cost -10 mana; >= 200, -5 mana
- `WeaponArmorCalls.cs:96` — Marksmanship is included in the top-5 skill detection (FIT) system
- `WeaponArmorCalls.cs:121` — Marksmanship is included in the `ManaRedux` calculation (same thresholds as above)

### Druidism

- `Druidism.cs:143,174` — Marksmanship is one of the five combat skills averaged to produce a creature's combat rating displayed in the Druidism Monster Manual and Player's Handbook gumps

### Items & Equipment

- `Artifact_Windsong.cs:19` — `SkillBonuses.SetValues( 0, SkillName.Marksmanship, 10 )`
- `Artifact_WildfireBow.cs:15` — `+10 Marksmanship`
- `Artifact_RobinHoodsBow.cs:17` — `+20 Marksmanship`
- `Artifact_Frostbringer.cs:18` — `+15 Marksmanship`
- `Artifact_BowofthePhoenix.cs:17` — `+5 Marksmanship`
- `Artifact_AilricsLongbow.cs:17` — `+10 Marksmanship`
- `Artifact_RobinHoodsFeatheredHat.cs:13` — `+10 Marksmanship`
- `Artifact_HuntersHeaddress.cs:15` — `+20 Marksmanship`
- `Artifact_HuntersTunic.cs:19` — `+10 Marksmanship`
- `Artifact_HuntersLeggings.cs:19` — `+10 Marksmanship`
- `Artifact_HuntersGorget.cs:19` — `+5 Marksmanship`
- `GuildRing.cs:91` — Archers Guild Ring grants `+10 Marksmanship`
- `SwordsAndShackles.cs:85` — Book describing harpoon mechanics, rope mechanics, and Seafaring synergy
- `Elixirs.cs:432,480` — "Elixir of Marksmanship" adds a temporary `DefaultSkillMod` to Marksmanship (crafted via Alchemy)
- `PotionKeg.cs:514` — Keg of marksmanship elixir (mass production via Alchemy trade)

### NPC Behavior

- `Behavior.cs:4590` — Certain NPCs copy their Magery skill value into Marksmanship: `SetSkill( SkillName.Marksmanship, from.Skills[SkillName.Magery].Value )`
- `BaseSailor.cs:30` — Sailors get Marksmanship = `(level/3)` based on their level tier

### Quests & Achievements

- `SkillArchive.cs:127-128` — Marksmanship is tracked in the Avatar skill archive system for skill milestone rewards
- `ResourceMods.cs:1857` — Resource modification system maps skill index 5 to Marksmanship

### Training & Skill Gains

- `SkillCheck.cs:47` — Marksmanship does NOT use anti-macro code (`false`), so it can be trained anywhere without target/position restrictions
- `SkillCheck.cs:334` — Marksmanship is included in the list of skills that can gain from location checks (no direct target needed)
- `SkillCheck.cs:334` — Returns `true` for `CanGainFromLocation` when `skillName == SkillName.Marksmanship`, meaning skill gains fire on every ranged attack regardless of target

### Mount Requirements

- `Ethereals.cs:132` — Warhorse mount requires at least one of Tactics, Swords, Bludgeoning, Marksmanship, or Fencing at GM (100.0 base)

## Related Systems & Skills

### Synergies
- [Tactics](tactics.md): amplifies ranged damage and gates weapon ability tiers; combined with Marksmanship for special move mana reduction
- [Seafaring](seafaring.md): provides Harpoon damage bonus on top of Marksmanship hit chance
- [Weapon Abilities](weapon-abilities.md): special moves available on ranged weapons; Marksmanship contributes to mana cost reduction
- [Druidism](druidism.md): used to lore creatures; Marksmanship is factored into the creature's combat rating display
- [Bowcraft](bowcraft.md): crafting of bows; bowyers set to Marksmanship 80-100

### Prerequisites / Co-requisites
- [Archers Guild](../systems/npc-guilds.md#archers-guild): Marksmanship is a guild skill, granting accelerated gains for Archers Guild members

## Notes

- Marksmanship can be trained anywhere since it does not use anti-macro code.
- Ammo recovery mechanics (40% on hit and 40% on miss) make Marksmanship efficient for extended ranged combat.
