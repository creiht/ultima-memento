# Bludgeoning

Bludgeoning is the hit skill for all blunt weapons — clubs, maces, war hammers, and other bashing weapons. It also receives a unique Mining damage bonus.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Strength |
| Usage | Passive (every bashing swing) |
| Cooldown | None |

## How It Works

### Weapons That Use Bludgeoning

All weapons of `WeaponType.Bashing` declare `DefSkill = Bludgeoning`. This includes clubs, maces, war hammers, mauls, and similar blunt weapons.

### Hit Chance

Hit chance is resolved identically to Swordsmanship — the attacker's Bludgeoning versus the defender's active defence skill. Tactics and Strength contribute damage separately.

### Mining Damage Bonus

Bludgeoning weapons receive a unique bonus that other weapon skills do not:

```
miningBonus = GetBonus(Mining, 0.20, 100.0, 10.0)
```

This bonus is added during `ScaleDamageAOS`. Characters who also train [Mining](../crafting/mining.md) deal extra damage with bludgeoning weapons.

### Player Title

At Grandmaster level the player title is **"Bludgeoner"**. In some NPC social contexts this may display as "Man-at-arms" depending on alignment.

## How to Train

Attack with any bashing weapon. Bludgeoning gains passively on every swing.

## Related Skills

- [Tactics](tactics.md) — damage amplifier and weapon ability tier gate.
- Mining ([crafting](../crafting/mining.md)) — contributes a passive damage bonus to all bashing weapons.
- [Weapon Abilities](weapon-abilities.md) — special moves available on bashing weapons.

## What It Affects

### Combat & Weapons

| Reference | Detail |
|---|---|
| `BaseWeapon.cs:872-907` | `GetUsedSkill()` — when a weapon has `UseBestSkill > 0`, Bludgeoning is compared against Swords, Fencing, and Fist-Fighting; the highest skill is used for the swing |
| `BaseWeapon.cs:909-917` | `GetAttackSkillValue()` / `GetDefendSkillValue()` — delegates to `GetUsedSkill()`, so Bludgeoning affects both offense and defense when it is your best skill |
| `BaseWeapon.cs:3457` | Weapon tooltip displays "skill required: bludgeoning" for bashing weapons |

### Weapon Abilities

| Reference | Detail |
|---|---|
| `WeaponAbility.cs:70` | `CalculateMana()` — Bludgeoning contributes to the total weapon skill pool (Swords + Bludgeoning + Fencing + Marksmanship + Parrying + Lumberjacking + Stealth + Fist-Fighting + Poisoning + Bushido + Ninjitsu); ≥300 total reduces special move mana cost by 10 |
| `WeaponAbility.cs:118` | `CheckWeaponSkill()` — with UseBestSkill, any of Swords/Bludgeoning/Fencing/Fist-Fighting ≥ required skill lets you use the ability |
| `WeaponAbility.cs:144` | `GetWeaponSkill()` — Bludgeoning is considered as a fallback skill when UseBestSkill is enabled |
| `WeaponArmorCalls.cs:98` | Bludgeoning is included in the top-5 skills ranking used by armor systems |
| `WeaponArmorCalls.cs:120` | `ManaRedux.CalculateSpecialMana()` — same skill pool as WeaponAbility mana calc; ≥300 reduces mana by 10, ≥200 by 5 |
| `AbilityBook.cs:59` | Ability Book text lists Bludgeoning as one of the skills that reduces special move mana cost |
| `AbilityBook.cs:182` | `CalculateMana()` — duplicate mana reduction calc including Bludgeoning |

### Magic Systems

| Reference | Detail |
|---|---|
| `Druidism.cs:147` | `FormatCombat()` — Bludgeoning is averaged with Marksmanship, Fencing, Swords, and Fist-Fighting to compute a druidism combat display value |
| `Druidism.cs:178` | `FormatFight()` — same averaging logic for druidism fight display |

### Runic Tools

| Reference | Detail |
|---|---|
| `BaseRunicTool.cs:213` | Included in `m_PossibleSkills` — list of all skills that can appear on runic tools |
| `BaseRunicTool.cs:248` | Included in `m_PossibleFightSkills` — skills that can roll on fight-oriented runic tools |
| `BaseRunicTool.cs:258` | Included in `m_PossibleShieldSkills` — skills that can roll on shield-oriented runic tools |
| `BaseRunicTool.cs:270-273` | `m_PossibleWepBludgeoningSkills` — the exclusive skill-bonus pool for bludgeoning weapons: `[Bludgeoning, Tactics]` |

### Items

| Reference | Detail |
|---|---|
| `StaffOfFiveParts.cs:69` | Staff of Five Parts gives +20 Bludgeoning skill via `SkillBonuses` |
| `ItemProperties.cs:624` | Skill requirement property displays "Skill: Bludgeoning" when affixed to bashing weapons |

### NPCs & AI

| Reference | Detail |
|---|---|
| `Behavior.cs:3191` | Armor gear assignment — NPCs wearing armor receive `50 + myBonus` Bludgeoning |
| `Behavior.cs:3398` | Same logic at different armor tier — Bludgeoning set to `50 + myBonus` |
| `Behavior.cs:4029` | Vampire gear drop — a staff is packed with `+2*Mgear` Bludgeoning skill bonus |
| `Behavior.cs:6281` | NPC speech response skill list — Bludgeoning included in skill checks for town NPC responses |
| `Mobiles/Civilized/TownGuards.cs:31` | Town Guards start with 200.0 Bludgeoning |
| `Mobiles/Civilized/Merchants/Weaponsmith.cs:22` | Weaponsmith merchants have 45-68 Bludgeoning |
| `Mobiles/Unique/BlackKnight.cs:49` | Black Knight has 110.0 Bludgeoning |
| `Mobiles/Unique/BaneOfWantoness.cs:49` | Bane of Wantoness has 110.0 Bludgeoning |
| `Mobiles/Humanoids/Aliens/SavageAlien.cs:49` | Savage Alien has 125.1-140 Bludgeoning (highest base) |

### Guilds

| Reference | Detail |
|---|---|
| `SkillCheck.cs:254` | Warriors Guild skill — Warriors Guild members receive increased skill gain for Bludgeoning |
| `Mobiles/Civilized/Guilds/MageGuildmaster.cs:27` | Mage Guildmaster has 36-68 Bludgeoning |
| `Mobiles/Civilized/Guilds/ElementalGuildmaster.cs:28` | Elemental Guildmaster has 36-68 Bludgeoning |

### Character Creation

| Reference | Detail |
|---|---|
| `CharacterCreation.cs:399` | Knight character template starts with Bludgeoning instead of Swordsmanship |
| `CharacterCreation.cs:930` | Knight template starting skill: 30 Bludgeoning |

### Avatar System

| Reference | Detail |
|---|---|
| `SkillArchive.cs:31-32` | `SkillArchive.Bludgeoning` property accessor for avatar skill tracking |

### Related Skills

- [Swords](swords.md) — alternative weapon skill; used together for `UseBestSkill` selection
- [Fencing](fencing.md) — same UseBestSkill pool as Bludgeoning
- [Fist-Fighting](fist-fighting.md) — same UseBestSkill pool
- [Tactics](tactics.md) — second skill in the Bludgeoning runic tool bonus pool; also part of weapon ability mana reduction
- [Mining](../crafting/mining.md) — passive damage bonus on bashing weapons
- [Weapon Abilities](weapon-abilities.md) — mana cost reduction uses Bludgeoning in combined skill pool
- [Druidism](../magic/druidism.md) — averaged for combat display
- [Warriors Guild](../world/guilds.md#warriors-guild) — Bludgeoning is a designated Warriors Guild skill for bonus gain rate
