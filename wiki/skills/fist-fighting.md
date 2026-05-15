# Fist Fighting

Fist Fighting governs unarmed combat and is the core skill of the Mystic (Monk) magic system. Reaching 100 base Fist Fighting is required before any Mystic spell can be cast.

## Overview

| Property | Value |
|---|---|
| **Primary Stat** | Strength |
| **Usage** | Passive |
| **Skill Type** | Weapon / Magic |
| **Skill Check** | None |

## Description

Fist Fighting is the combat skill used when unarmed or wearing pugilist gloves. It also serves as both the CastSkill and DamageSkill for the Mystic (Monk) magic system, scaling all Mystic spell effects. At Grandmaster level the player title is "Fighter".

## How It Works

### Unarmed Combat

When no weapon is equipped (or pugilist gloves are worn), Fist Fighting is used as the active combat skill for hit chance and ability resolution. With non-weapon skills (Disarm, Paralyzing Blow), using fists removes the Tactics requirement [Disarm.cs:43], [ParalyzingBlow.cs:48].

### Mystic (Monk) Magic Prerequisite

To qualify as a Monk and use any Mystic spell you must simultaneously meet **all** of the following:

- **100 base Fist Fighting**
- **100 base Meditation**
- **100 base Focus**
- Wearing a **MysticMonkRobe** with **no other armor**

Fist Fighting is both the **CastSkill** and **DamageSkill** for every Mystic spell [MysticSpellBook.cs:129].

### Mystic Spell Scaling

| Spell | Formula |
|---|---|
| Psionic Blast | Damage = `(FistFighting + Int) / 4` (capped at 60) — `[PsionicBlast.cs:65]` |
| Gentle Touch | Heal = `(FistFighting / 10) + random(1-10)`, modified by player level — `[GentleTouch.cs:58]` |
| Quivering Palm | Paralyze duration = `FistFighting` seconds — `[QuiveringPalm.cs:46]` |
| Purity of Body | Poison cure chance = `10000 + (FistFighting × 75) − (poison level penalty)` — `[PurityOfBody.cs:38]` |

See [Mystic magic](../magic/mystic.md) for the full spell list.

### Best Weapon Skill (UBWS)

Weapons with the Use Best Weapon Skill (UBWS) attribute will consider Fist Fighting when the player is unarmed or wearing pugilist gloves. If Fist Fighting value exceeds the weapon's native skill, it becomes the active combat skill [BaseWeapon.cs:881-903]. Non-human NPCs default to Fist Fighting if it exceeds their native weapon skill. Fist Fighting is a valid skill for using weapon abilities with any weapon [WeaponAbility.cs:118-146]. The item property display text reads "skill required: fist fighting" [BaseWeapon.cs:3460], [ItemProperties.cs:627].

### Spiritualism Synergy

Fist Fighting contributes `(FistFighting × 0.15)` to the minimum HP of Spiritualism summons and channeled heals [Spiritualism.cs:166, 173].

### NPC AI Gates

Several NPC abilities require reaching certain Fist Fighting thresholds alongside other skills:

- **80+ Fist Fighting + 80+ Anatomy** → NPC AI unlocks **Stun** [Behavior.cs:9769]
- **80+ Fist Fighting + 80+ Arms Lore** → NPC AI unlocks **Disarm** [Behavior.cs:10489]

### Weapon Abilities

- `[FistsOfFury.cs:35]` — Number of strikes = `(FistFighting / 75) + 1`: 1 strike at 0-74, 2 strikes at 75-99, 3 strikes at 100+

## How to Train

Attack while unarmed. Fist Fighting also gains on every Mystic spell cast. The skill is marked as non-check-trainable [SkillCheck.cs:59], meaning it only trains through direct attack use rather than skill-check-based methods. Monks in training should alternate between sparring unarmed and casting spells.

## Character Creation

Choosing Fist Fighting as a starter skill grants Pugilist Gloves [CharacterCreation.cs:421]. The Mage starter profession also receives 30 base Fist Fighting [CharacterCreation.cs:897].

## What It Affects

### Combat & Weapons
- `[BaseWeapon.cs:881-903]` — UBWS (Use Best Weapon Skill): Fist Fighting is checked as the highest skill when no weapon is equipped; non-human NPCs default to Fist Fighting if it exceeds their native weapon skill
- `[BaseWeapon.cs:3460]` — Item property display text: "skill required: fist fighting"
- `[ItemProperties.cs:627]` — "skill required: fist fighting" tooltip text for weapon attributes
- `[WeaponAbility.cs:72]` — Fist Fighting counts toward total skill pool for mana cost reduction (300+ total skills = -10 mana, 200+ = -5 mana)
- `[WeaponAbility.cs:118-146]` — UBWS check: Fist Fighting is a valid skill for using weapon abilities with any weapon
- `[Disarm.cs:43]` — When using fists, Disarm does not require Tactics skill (only when using non-fist weapons)
- `[ParalyzingBlow.cs:48]` — When using fists, Paralyzing Blow does not require Tactics skill

### Mystic Magic System
- `[MysticSpellBook.cs:129]` — Requires 100 base Fist Fighting to pack Mystic spells from the shrine
- `[QuiveringPalm.cs:46]` — Paralyze duration = Fist Fighting value in seconds (e.g., 100 skill = 100 seconds)
- `[PurityOfBody.cs:38]` — Poison cure chance = 10000 + (FistFighting × 75) − (poison level penalty); higher Fist Fighting dramatically improves cure rate
- `[PsionicBlast.cs:65]` — Damage = (FistFighting + Intelligence) / 4, capped at 60 damage
- `[GentleTouch.cs:58]` — Heal = (FistFighting / 10) + random(1-10), modified by player level system

### NPC Defaults
- `[Behavior.cs:3193, 3400]` — Base NPC generation sets Fist Fighting to 50.0 + difficulty bonus
- `[Behavior.cs:6283]` — Fist Fighting included in the standard skill list for NPC generation
- `[TownGuards.cs:33]` — Town Guards have 200.0 Fist Fighting
- `[ConfirmBreakCrystalGump.cs:39]` — Summoned imprisoned creatures receive 100 base Fist Fighting

### Crafting & Enchanting — Runic Tools
- `[BaseRunicTool.cs:237, 252]` — Fist Fighting is a valid enchantment skill for runic tools
- `[BaseRunicTool.cs:287-291]` — Fist Fighting + Tactics is the bonus skill pair for enchanting Fist Fighting weapons
- `[BaseRunicTool.cs:386]` — Runic tool skill assignment: Fist Fighting weapons can enchant Tactics as the bonus skill

### Druidism Integration
- `[Druidism.cs:151, 182]` — Fist Fighting is included in the average fight skill calculation for talent evaluation (alongside Swords, Fencing, Bludgeoning)
- `[Druidism.cs:498-504]` — Fist Fighting is displayed as the "Combat Skill" in the Druidism talent screen when viewing creature stats

### Character & Progression
- `[Players.cs:153]` — Fist Fighting is the initial candidate for finding a player's highest skill (fallback before iterating all skills)
- `[SkillArchive.cs:75]` — Fist Fighting is tracked in the Avatar/level system's skill archive
- `[ResourceMods.cs:1906]` — Fist Fighting registered as skill ID 54 in resource/modification system
- `[SkillCheck.cs:59]` — Fist Fighting marked as non-check-trainable (only trains via direct attack use)

### Champion Spawns
- `[Silvani.cs:34]` — Champion Silvani: 97.6 to 100.0
- `[Neira.cs:42]` — Champion Neira: 97.6 to 100.0, uses Fist Fighting as weapon skill
- `[Mephitis.cs:40]` — Champion Mephitis: 97.6 to 100.0
- `[Barracoon.cs:42]` — Champion Barracoon: 97.6 to 100.0
- `[LordOaks.cs:57]` — Champion Lord Oaks: 100.0
- `[Semidar.cs:43]` — Champion Semidar: 90.1 to 105.0
- `[Rikktor.cs:52]` — Champion Rikktor: 80.0
- `[SerpentineDragon.cs:35]` — Champion Serpentine Dragon: 30.1 to 100.0
- `[GreaterMongbat.cs:29]` — Champion Greater Mongbat: 20.1 to 35.0

### Unique & Notable NPCs
- `[TitanStratos.cs:58]` — Titan Stratos: 97.6 to 100.0
- `[TitanLithos.cs:55]` — Titan Lithos: 97.6 to 100.0
- `[SlasherOfVoid.cs:47]` — Slasher of Void: 97.6 to 100.0
- `[KhumashGor.cs:39]` — Khumash Gor: 97.6 to 100.0
- `[BaneOfInsanity.cs:51]` — Bane of Insanity: 110.0
- `[BaneOfWantoness.cs:51]` — Bane of Wantoness: 110.0
- `[BaneOfAnarchy.cs:51]` — Bane of Anarchy: 110.0
- `[Exodus.cs:62]` — Exodus: 110.0
- `[RuneGuardian.cs:277]` — Rune Guardian: 90.1 to 120.0
- `[Leviathan.cs:68]` — Leviathan: 97.6 to 107.5
- `[Shadowlord.cs:56]` — Shadowlord: 90.1 to 100.0
- `[TitanPyros.cs:59]` — Titan Pyros: 90.1 to 100.0
- `[TitanHydros.cs:59]` — Titan Hydros: 90.1 to 100.0
- `[EpicCharacter.cs:80]` — Epic Characters: 100.0
- `[MageGuildmaster.cs:25]` — Mage Guildmaster: 60.0 to 83.0
- `[ElementalGuildmaster.cs:26]` — Elemental Guildmaster: 60.0 to 83.0
- `[Sherry.cs:65]` — Sherry: 100.0

## Related Systems & Skills

### Synergies
- [Meditation](meditation.md): co-requisite for Monk status; affects mana regeneration
- [Focus](focus.md): co-requisite for Monk status; affects stamina and mana regen
- [Spiritualism](spiritualism.md): gains summon quality boost from Fist Fighting
- [Tactics](tactics.md): paired with Fist Fighting on runic tools and UBWS checks
- [Anatomy](anatomy.md): NPC stun synergy (requires 80+ Fist Fighting + 80+ Anatomy)
- [Arms Lore](arms-lore.md): NPC disarm synergy (requires 80+ Fist Fighting + 80+ Arms Lore)
- [Weapon Abilities](weapon-abilities.md): mana cost reduction uses Fist Fighting in combined skill pool
- [Druidism](../magic/druidism.md): averaged for combat display in Druidism talent screen
- [Pugilist Gloves](../items/equipment.md): required equipment for Mystic spell casting; boosts unarmed combat

### Prerequisites / Co-requisites
- [Meditation](meditation.md): must have 100 base Meditation to qualify as a Monk
- [Focus](focus.md): must have 100 base Focus to qualify as a Monk
- [MysticMonkRobe](../items/equipment.md): must wear Monk robe with no other armor to cast Mystic spells
- [Mystic magic](../magic/mystic.md): Fist Fighting is both the CastSkill and DamageSkill for all Mystic spells
- [Warriors Guild](../world/guilds.md#warriors-guild): Fist Fighting is a Warriors Guild skill

## Notes

- Fist Fighting is marked as non-check-trainable, meaning it only trains through direct attack use.
- The Mystic spell prerequisite requires ALL three skills (Fist Fighting, Meditation, Focus) at 100 base simultaneously.
- Fists are the only weapons that don't require Tactics for Disarm and Paralyzing Blow.
