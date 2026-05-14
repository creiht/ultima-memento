# Tactics

Tactics amplifies the damage of every melee and ranged attack, and is the gating skill for all weapon special ability tiers.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Strength |
| Usage | Passive (every swing) |
| Cooldown | None |

## How It Works

### Damage Multiplier

Tactics adds a flat damage scalar on top of Strength and weapon-skill contributions:

```
tacticsBonus = GetBonus(Tactics, 0.625, 100.0, 6.25)
```

| Tactics Skill | Bonus Damage |
|---|---|
| 50 | ~3.1 |
| 100 | 6.25 |
| 125 | ~7.8 |

### Weapon Ability Tier Gating

All five weapon ability tiers require the attacker to meet a **minimum Tactics value** alongside the relevant weapon skill. Both must equal or exceed the tier threshold before that ability slot unlocks. Several abilities also scale their effectiveness directly from Tactics:

- **Nerve Strike** — paralysis duration scales with Tactics.
- **Talon Strike** — bleed damage scales with Tactics.
- **Block** — parry bonus scales with Tactics.
- **Frenzied Whirlwind** — AoE radius/damage scales with Tactics.

See [Weapon Abilities](weapon-abilities.md) for the full tier threshold table.

## How to Train

Tactics gains passively on every swing with `checkSkills = true`. Fight regularly and it will rise alongside your weapon skill.

## What It Affects

### Combat & Damage

- `BaseWeapon.cs:2390` — Tactics adds a flat damage scalar via `GetBonus(Tactics, 0.625, 100.0, 6.25)`, capping at **6.25 bonus damage** at 100 skill.
- `BaseWeapon.cs:2379` — Every successful weapon swing passively checks Tactics for training gain alongside Anatomy.
- `BaseWeapon.cs:273` — `AccuracySkill` property defaults to `SkillName.Tactics` for all weapons.

### Weapon Abilities

- `WeaponAbility.cs:108` — **Tier gating**: Tactics must meet or exceed the same threshold as the weapon skill (default tiers: 70 / 80 / 90 / 100 / 110 per tier via `S_SpecialWeaponAbilSkill = 70.0`). Both must equal or exceed the threshold for that ability slot to unlock.
- `WeaponAbility.cs:41` — `RequiresTactics()` returns `true` for all abilities — every weapon special has a Tactics requirement.
- `NerveStrike.cs:56-57` — Damage = `15 * ((Tactics - 50) / 70) + random(10)` (0-25) and paralysis chance = `(150/7 + 4*Tactics/7) / 100` (~71% at 50, ~100% at 100).
- `TalonStrike.cs:40` — Bleed damage = `10 * ((Tactics - 50) / 70) + 5` (5-15 damage).
- `FrenziedWhirlwind.cs:78` — AoE damage = `10 * ((max(Tactics, Anatomy) - 50) / 70 + 5)` (5-15 damage), dealing to all nearby targets.
- `Block.cs:35` — Armor bonus = `10 * ((max(Tactics, Anatomy) - 50) / 70 + 5)` (5-15 armor). Tactics competes with Anatomy.
- `DefenseMastery.cs:34` — Physical resistance bonus = `30 * ((max(Tactics, Anatomy) - 50) / 70)` (0-30 resist). Tactics competes with Anatomy.
- `DualWield.cs:45` — Attack speed increase = `20 + 3 * (Tactics - 50) / 7` percent (20-50% increase) for 6 seconds.
- `RidingSwipe.cs:49,58` — Damage to mounted target or their mount = `10 + 10 * ((Tactics - 50) / 70 + 5)`, plus paralyze on mounted attacker.

### Magic Systems

- `JediSpell.cs:137` — Jedi spell casting requires Tactics >= 10 base (alongside Psychology >= 10 and Swords >= 10).
- `SythSpell.cs:137` — Syth spell casting requires Tactics >= 10 base (alongside Psychology >= 10 and Swords >= 10).
- `JediSpell.cs:375` / `SythSpell.cs:382` — Jedi/Syth "hate" formula: `karma/120 + Tactics + Swords` (capped at 375). Higher Tactics means more aggression from NPCs.
- `SythSpellBookGump.cs:188` — Laser sword construction requires Tactics >= 100 (alongside Psychology >= 100, Swords >= 100, Fame >= 15000, Karma <= -15000).
- `JediSpellBookGump.cs:189` — Lightsaber construction requires Tactics >= 100 (alongside Psychology >= 100, Swords >= 100, Fame >= 15000, Karma >= 15000).
- `AnimateDeadSpell.cs:318,325` — Summoned undead inherit Tactics skill scaled by the summoner's modifier (mages also get Meditation and Psychology).

### AI & NPCs

- `BaseCreature.cs:6776` — FightMode.Strongest ranking uses `Tactics + Str` to determine which player an NPC targets first.
- `OmniAI Bushido.cs:88` — AI NPC attempts primary weapon ability when Tactics >= 90 and Bushido >= 25.
- `OmniAI Bushido.cs:90` — AI NPC attempts secondary weapon ability when Tactics >= 60.
- `BladeSpirits.cs:49` — Blade Spirit summoned pet has Tactics set to 90.0.
- `ElementalFiendFire.cs:19` / `ElementalFiendWater.cs:19` / `ElementalFiendEarth.cs:19` / `ElementalFiendAir.cs:19` — Elemental fiends use `(Str + Tactics) / distance` for fight mode ranking.
- `Druidism.cs:492` — Druidism Animal Form info panel displays Tactics as one of the creature's combat ratings.

### Items & Mounts

- `HorseArmor.cs:119` — Applying Horse Armor to a mount adds the armor's modification to the horse's Tactics skill.
- `Ethereals.cs:129` — Warhorse mount requires Tactics >= 100 (alongside grandmaster in any one combat weapon skill).
- `SilverSteed.cs:20` — Silver Steed mount has Tactics 30.0-45.0.
- `SeaHorse.cs:20` — Sea Horse mount has Tactics 30.0-45.0.

### Quest NPCs

- `GolemFighter.cs:107` — Golem Fighter NPC has Tactics set to `50 * scalar`.
- `FrankenFighter.cs:107` — Frankenstein Fighter NPC has Tactics set to `50 * scalar`.
- `Robot.cs:57` — Robot NPC has Tactics in range 80.2-98.0.
- `CodexWisdom.cs:113,433` — Tactics is skill #48 in the Codex skill list.

### Champion Spawns

- `Silvani.cs:33` — Silvan boss has Tactics 97.6-100.0.
- `Semidar.cs:42` — Semidar boss has Tactics 90.1-105.0.
- `Rikktor.cs:51` — Rikktor boss has Tactics 80.0.
- `Neira.cs:41` — Neira boss has Tactics 97.6-100.0.
- `Mephitis.cs:39` — Mephitis boss has Tactics 97.6-100.0.
- `LordOaks.cs:56` — Lord Oaks boss has Tactics 100.0.
- `Barracoon.cs:41` — Barracoon boss has Tactics 97.6-100.0.
- `SerpentineDragon.cs:34` — Serpentine Dragon champion has Tactics 50.1-60.0.
- `GreaterMongbat.cs:28` — Greater Mongbat champion has Tactics 35.1-50.0.

### Avatar System

- `SkillArchive.cs:211-212` — Tactics skill tracked in avatar progression system as `Tactics` property.

## Related Skills

- [Anatomy](anatomy.md) — also contributes to damage calculations; competes equally with Tactics for Block, Defense Mastery, and Frenzied Whirlwind bonuses (whichever is higher).
- [Psychology](psychology.md) — Jedi and Syth spell prerequisites pair Tactics with Psychology and Swords at 10 base each.
- [Swordsmanship](swordsmanship.md), [Bludgeoning](bludgeoning.md), [Fencing](fencing.md), [Fist Fighting](fist-fighting.md), [Marksmanship](marksmanship.md) — each weapon skill pairs with Tactics; Tactics tier thresholds gate all ability slots.
- [Bushido](bushido.md) — Omni AI NPCs use Tactics >= 90 as an alternative gating condition for primary weapon abilities.
- [Weapon Abilities](weapon-abilities.md) — full list of specials gated by Tactics tiers; all abilities have Tactics requirements.
