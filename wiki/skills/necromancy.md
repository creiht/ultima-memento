# Necromancy

Necromancy is the casting skill for the dark arts of death magic. It governs success when casting spells from a Necromancer Spellbook. Damage for Necromancy spells is calculated from [Spiritualism](spiritualism.md), making Necromancy primarily a cast-reliability and access skill.

## Overview

| Property | Value |
|---|---|
| **Primary Stat** | Intelligence |
| **Usage** | Active (cast Necromancy spells) |
| **Skill Type** | Magic |
| **Skill Check** | 0 - 100 (varies by spell) |

## Description

Necromancy governs success when casting spells from a Necromancer Spellbook, including duration and strength of several debuffs and transformations. Spell damage is driven by [Spiritualism](spiritualism.md), making Necromancy primarily a cast-reliability and access skill. Casting these spells awards negative karma, affecting your alignment.

## How It Works

### Spell Casting

- Success chance when casting any Necromancer Spellbook spell.
- Minimum-skill gating for each spell (see [Necromancy magic system](../magic/necromancy.md) for per-spell thresholds).
- Duration and strength of several debuffs and transformations (Strangle, Corpse Skin, Blood Oath, Lich/Wraith/Vampiric/Horrific form effects).
- Does **not** directly scale spell damage — that is driven by [Spiritualism](spiritualism.md).

### Transformation & Buff Formulas

- Corpse Skin spell: duration = `((Spiritualism - Resist Magic) / 2.5) + 40` seconds. Applies -15 Fire/Poison resistance and +10 (level-modified) Cold/Physical resistance (`CorpseSkin.cs:68`).
- Wither spell: drain amount = `Necromancy.Value / 5` (`Wither.cs:76`).
- Vengeful Spirit spell: damage = `Necromancy.Value / 2` (`VengefulSpirit.cs:61`).
- Pain Spike spell: damage = `Necromancy.Value / 5` (`PainSpike.cs:61`).
- Poison Strike spell: damage = `Necromancy.Value / 10` (`PoisonStrike.cs:53`).
- Strangle spell: damage = `Necromancy.Value / 25` (`Strangle.cs:149`).
- Curse Weapon spell: bonus = `Necromancy.Value` (`CurseWeapon.cs:55`).

## How to Train

- Cast Necromancy spells from a Necromancer Spellbook; each cast rolls a skill gain check.
- Cast at or near the minimum skill of each spell for best gain rates.
- Casting Necromancy spells awards **negative Karma**, so training affects your alignment.

## What It Affects

### Combat & Weapons

- Staff damage bonus: Necromancy.Value contributes up to +6.25% damage when wielding a staff, wizard wand, wizard stave, scepter, or gift scepter (`BaseWeapon.cs:2396`). Bonus is zeroed for non-staff weapons (`BaseWeapon.cs:2415`).
- Weapon wizard check: `BaseWeapon.WizardCheck()` compares Necromancy.Base against Magery.Base and Elementalism.Base to gate use of special weapons. If Necromancy is the highest of the three, the player is classified as "necromancer" (`BaseWeapon.cs:2296-2313`).

### Summoning & Undead

- Animate Dead spell: the average of Necromancy and Spiritualism determines the power multiplier applied to the animated corpse's stats (damage, HP, resistances). At 125 in both skills the animated creature has full stats (`AnimateDeadSpell.cs:110`). Duration = `((Necromancy + Spiritualism) / 2) * 9` seconds (`AnimateDeadSpell.cs:85`).
- Book of the Dead: requires 80 Necromancy to resurrect a dead creature. Skill level 80-100 sets a scalar from 0.6 to 1.0 applied to the SummonCorpse's stats (`BookofDead.cs:35-59`).
- Summon Familiar: Necromancy.Value determines which familiar an NPC necromancer summons (Horde Minion at 30+, Shadow Wisp at 50+, Dark Wolf at 60+, Death Adder at 80+, Vampire Bat at 100+) (`OmniAI Necromancy.cs:211-220`).

### NPCs & Vendor Discounts

- Vendor discount: Necromancer vendors and the Necromancer Guildmaster give discounts to players with Necromancy.Value > 0 (`BaseCreature.cs:620` defines `IsNecromancer` at >50).
- Guildmaster trades: Mage Guildmaster, Necromancer Guildmaster, and Elemental Guildmaster all accept trades and check for Necromancy >= 50/100 to determine HighSpellCaster tier and star sapphire requirements (`MageGuildmaster.cs:200,220-221`, `NecromancerGuildmaster.cs:267,287-288`, `ElementalGuildmaster.cs:193,213-214`).
- NPC AI: OmniAI necromancer NPCs select spells based on Necromancy thresholds — Blood Oath at 30+, Corpse Skin/Evil Omen/Mind Rot at 30-40+, Strangle at 40+/75+, Wraith Form at 30+, Horrific Beast at 50+, Lich Form at 80+, Vampiric Embrace at 110+ (`OmniAI Necromancy.cs:52-177`).
- Evil player detection: Necromancy >= 50 AND negative Karma flags a player as "evil" for NPC reactions (`Players.cs:568`).

### Crafting & Trade

- Mortician Shoppe: primary skill for the Mortician Work Shoppe (Necromancers Guild). Uses average of Forensics and Necromancy as effective skill value for reward calculations (`MorticianShoppe.cs:214`). Uses the Witchery craft system (`MorticianShoppe.cs:24`).
- Necromancy reagents: Bat Wings, Daemon Blood, Grave Dust, Nox Crystal, and Pig Iron are the five dedicated reagents used by necromancy spells (`Items/Trades/Reagents/Necromancy/`).

### Regions & Exploration

- Moon travel: Necromancy >= 80 gates access to the Moon facet alongside Magery and Elementalism (`MoonCore.cs:55,76`, `DawnRegion.cs:36,57`, `LunaRegion.cs:37,56`).
- Necromancer Region: killing undead/demons in this region grants bonus necromancy reagents (Bat Wings, Nox Crystals, Grave Dust, Daemon Blood) to evil players with Necromancy >= 25 (`BaseCreature.cs:8317`).
- House teleporter: Necromancy >= 80 (alongside Magery/Elementalism) prevents accidental teleport to the Moon when using certain teleporters (`PlayersHouseTeleporter.cs:276`).

### Character & Alignment

- Skill title: Necromancy.Base contributes to character title calculation alongside Magery, Healing, and Spiritualism (`Players.cs:43`).
- Character skill showcase: selectable as skill #36 in the character display (`Players.cs:260`).
- Appearance reset: players with Necromancy < 100 who have the necromancer hue (0x47E) will have their hue and hair reset on skill change (`PlayerMobile.cs:644`).
- Karma penalty: casting necromancy spells awards negative karma (`NecromancerSpell.cs:31`).
- Familiar gating: players without 50+ in Magery, Elementalism, or Necromancy cannot summon certain familiars (`FamiliarItem.cs:84`).
- Spell compatibility: the spell system checks that a player has at least 1 in Necromancy (or Elementalism) to cast both elemental and necromancy spells (`Spell.cs:680`).

### Other Systems

- Research magic system: Necromancy.Value is one of the two skills used for casting (with Magery) and is included in the average for damaging skill alongside Spiritualism and Psychology (`ResearchSpell.cs:60,68`).
- Witch magic system: NecroUnlock effect uses Necromancy.Value to enhance lockpicking; Undead Eyes effect scales dungeon level by `Necromancy.Base / 100` (`NecroUnlock.cs:79`, `UndeadEyes.cs:67`).
- Forgotten Gem: Necromancy.Base > 0 allows the ForgetfulGem to remove necromancy spells (`ForgetfulGem.cs:25-128`).
- Mage/Undead drops: killing Skeletal Dragons and Dracoliches has a 5% chance to drop special items if the killer has Necromancy >= 50 (`SkeletalDragon.cs:80`, `Dracolich.cs:81`, `VampiricDragon.cs:79`).
- Demon Prison: Necromancy.Value is compared against Magery and Elementalism to determine the wizard skill level for puzzle difficulty (`DemonPrison.cs:203,205`).
- Magic Forge: Necromancy.Base >= 80 gates access (alongside Magery/Elementalism); Necromancy > Magery determines magic type at the forge (`MagicForges.cs:790,838-840`).
- Summoned creature AI: summons' threat evaluation includes Necromancy.Value alongside Magery.Value (`DeathVortex.cs:17`, `GasCloud.cs:17`, `Swarm.cs:17`).
- Blood Snake: gains bonus damage in Necromancer Region if killer has Necromancy >= 50 (`BloodSnake.cs:82`).
- Ethereal mounts: NecroHorse requires 100 Necromancy to remount; Daemon Mount requires 100 Necromancy or 100 Magery (`Ethereals.cs:144,149`).
- Special potion: NecroSkinPotion has different effects at 100+ Necromancy (`NecroSkinPotion.cs:46`).
- AttackSpells (Eighth Circle): uses the higher of Magery or Necromancy to determine spell circle and damage (`AttackSpells.cs:55-56`).

## Related Systems & Skills

### Synergies
- [Spiritualism](spiritualism.md): damage skill for all Necromancy spells; averaged with Necromancy for Animate Dead power multiplier.
- [Meditation](meditation.md): mana regeneration for sustained casting.
- [Inscription](../crafting/inscription.md): relevant to scroll handling.
- [Forensics](forensics.md): averaged with Necromancy for Mortician Shoppe crafting.
- [Witchery](../crafting/witchery.md): crafting system used by Mortician Shoppe.
- [Research](../magic/research.md): includes Necromancy in casting and damaging skill calculations.
- [Transformation Spells](../magic/necromancy.md#transformations): Horrific Beast, Lich Form, Wraith Form, Vampiric Embrace.
- [Summoning](../systems/summoning.md): Animate Dead and Summon Familiar mechanics.

### Prerequisites / Co-requisites
- [Necromancer Spellbook](../magic/necromancy.md): required to cast all Necromancy spells.
- [Necromancers Guild](../world/guilds.md): the guild associated with this skill; provides vendor discounts.
- [Magery](magery.md): alternative magic skill; gates access to the same weapons and regions.
- [Elementalism](elementalism.md): alternative magic skill; gates access to the same weapons and regions.
- [Moon travel](../world/facets.md): requires Necromancy >= 80 (alongside Magery and Elementalism) for access.

## Notes
- Casting Necromancy spells awards **negative Karma**, affecting your alignment and NPC reactions.
- Necromancy >= 50 with negative karma flags you as "evil" for NPC reactions.
- Players with Necromancy < 100 and necromancer hue (0x47E) will have their hue and hair reset on skill change.
- Necromancy >= 80 is required to prevent accidental Moon teleport via house teleporters.
