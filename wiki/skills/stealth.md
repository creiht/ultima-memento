# Stealth

Stealth lets you move silently while hidden, taking a limited number of steps before being revealed.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Dexterity |
| Usage | Active (while hidden) |
| Cooldown | 2 seconds |
| Minimum Hiding Skill | 30 |

## How It Works

You must be [hidden](hiding.md) before you can activate Stealth. Using the skill performs an armor check and a skill check. On success, you can move a number of steps while remaining invisible.

### Steps Allowed

```
Steps = Stealth Skill / 5
```

| Stealth Skill | Steps |
|---|---|
| 25 | 5 |
| 50 | 10 |
| 75 | 15 |
| 100 | 20 |
| 125 | 25 |

### Armor Restriction

Your total armor rating is compared against your Stealth skill:

```
Armor Check: (ArmorRating - Stealth/5) must be <= 50
```

If your armor is too heavy, "You could not hope to move quietly wearing this much armor." The Stealth skill check difficulty also scales with your armor rating.

### Minimum Hiding Requirements

| Era | Minimum Hiding Skill |
|---|---|
| ML | 30 |
| SE | 50 |
| Pre-SE | 80 |

Below the minimum, you get: "You are not hidden well enough. Become better at hiding."

### Auto-Stealth from Hiding

At **100+ Hiding skill**, successfully hiding will automatically attempt Stealth without requiring a separate skill use.

### Failure

On failure, you are revealed and "You fail in your attempt to move unnoticed." Player-activated stealth attempts reveal you on failure; auto-stealth from hiding does not.

## How to Train

Hide first, then use Stealth. The difficulty scales with your armor rating, so wearing lighter armor makes training easier. Gain skill by making successful and failed attempts.

## What It Affects

### Weapon Abilities

- `System/Skills/Weapon Abilities/ShadowStrike.cs:24-37` - ShadowStrike requires **Stealth >= 80.0** to use. On hit, attacker becomes Hidden and deals 1.25x damage.
- `System/Skills/Weapon Abilities/Extra/ShadowInfectiousStrike.cs:18,28,33` - ShadowInfectiousStrike requires **Stealth >= 80.0** to hide after strike (when weapon has no poison charges).
- `System/Skills/Weapon Abilities/WeaponAbility.cs:72` - Stealth is included in total skill count for weapon ability mana reduction.

Weapons that have ShadowStrike or ShadowInfectiousStrike assigned as abilities include: Daggers, Cutlasses, Two-Handed Axes, Short Spears, Pitchforks, Clubs, Harpoons, Throwing Gloves, Assassin Spikes, Prospectors Tools, Pickaxes, Short Swords, Scimitars, Broad Swords, Spears, Ornate Axes, and Elven Machetes (plus all God/Gift versions).

### Sneak Attack Damage

- `Items/Weapons/BaseWeapon.cs:1117` - When attacking from hidden, `SneakDamage` is determined by checking if `Stealth > Random(1-250)`.
- `Items/Weapons/BaseWeapon.cs:1539-1560` - Sneak damage bonus formula: `(Hiding + Stealth) * 0.01 * bonusRange`, capped at 125%. Ranged weapons get half.

### Ninjitsu Abilities

- `Engines and Systems/Magic/Ninjitsu/Backstab.cs:29-38` - Requires **Hidden && AllowedStealthSteps > 0**. Ignores armor if defender is behind attacker. On hit, triggers ParalyzingBlow effect.
- `Engines and Systems/Magic/Ninjitsu/SurpriseAttack.cs:22-31` - Requires **Hidden && AllowedStealthSteps > 0**. Applies a 30-second defense malus to defender based on attacker's Ninjitsu + Tracking stalking bonus.
- `Engines and Systems/Magic/Ninjitsu/DeathStrike.cs:17` - Requires **85.0 Ninjitsu**. Damage scalar: `(Hiding + Stealth) / 220`.
- `Engines and Systems/Magic/Ninjitsu/ShadowJump.cs:19,28-33,56-60` - Requires **50.0 Ninjitsu** and **active stealth state** (`IsStealting`). After teleport, re-rolls Stealth steps.
- `Engines and Systems/Magic/Ninjitsu/KiAttack.cs:32-38` - Explicitly **fails** if already in stealth mode ("You cannot use this ability while in stealth mode.").
- `Engines and Systems/Magic/Ninjitsu/AnimalForm.cs:182-186` - Some animal forms grant StealthBonus of +20.

### Items & Equipment

| Item | Stealth Bonus | Source |
|---|---|---|
| Hooded Shroud of Shadows | +50 | `Items/Magical/Artifacts/Clothing/Outer/Artifact_HoodedShroudOfShadows.cs:12` |
| Embroidered Oak Leaf Cloak | +50 | `Items/Magical/Artifacts/Clothing/Back/Artifact_EmbroideredOakLeafCloak.cs:19` |
| ShadowDancer Leggings | +20 | `Items/Magical/Artifacts/Armor/ShadowDancer/Artifact_ShadowDancerLeggings.cs:21` |
| Burglar's Bandana | +10 | `Items/Magical/Artifacts/Clothing/Head/Artifact_BurglarsBandana.cs:20` |
| ShadowDancer (Cap/Gorget/Arms/Tunic/Gloves) | +10 each | `Items/Magical/Artifacts/Armor/ShadowDancer/` |
| LeatherSoftBoots | +10 | `Items/Armor/Leather/LeatherBoots.cs:227` |
| Oniwaban Boots (God/Gift) | +10 | `Items/Magical/God/Armor/Leather/LevelOniwabanBoots.cs:33` |
| Thieves Guild Ring | +10 | `Items/Trinkets/GuildRing.cs:51` |
| Assassins Guild Ring | +10 | `Items/Trinkets/GuildRing.cs:109` |

### Detection & Reveal Spells

Stealth (combined with Hiding) is used as a **divisor** to resist detection:

- `Engines and Systems/Magic/Magery/Spells/Magery 6th/Reveal.cs:182-183` - `divisor = Hiding + Stealth`
- `Engines and Systems/Magic/Jedi/Spells/MindsEye.cs:187-188` - `divisor = Hiding + Stealth`
- `Engines and Systems/Magic/Shinobi/Spells/EagleEye.cs:190-191` - `divisor = Hiding + Stealth`
- `System/Skills/Tracking.cs:341-349` - `CheckDifficulty()` uses `divisor = Hiding + Stealth` to reduce tracking difficulty.

### NPC Detection

- `Mobiles/Base/Behavior.cs:8816-8818` - NPCs detect hidden stealthy players using: `trgStealth = Stealth.Value / 1.8; chance = srcSkill / 1.2 - Min(trgHiding, trgStealth)`.

### NPC AI Behavior

- `Mobiles/Omni AI/OmniAI Core.cs:386,401,462,473` - OmniAI calls `Stealth.OnUse()` on smoke bomb use, movement, and random walking while hidden.
- `Mobiles/Omni AI/OmniAI Ninjitsu.cs:90,92,103` - Ninjitsu OmniAI uses SurpriseAttack, Backstab, and DeathStrike abilities.
- `Mobiles/Base/BaseCreature.cs:6879` - NPCs require **Hiding >= 50 (SE) or 80 (ML)** before teaching Stealth.

### Harvest Systems

- `Engines and Systems/Trades/Harvest/GraveRobbing.cs:217-220` - When caught grave robbing: if **Hiding >= 30**, Stealth skill is checked to avoid being seen by guards.

### Potions & Elixirs

- `Items/Potions/Elixirs/Elixirs.cs:4218-4246` - **Elixir of Stealth** applies a temporary Stealth skill mod.
- `Items/Potions/Unique/LesserInvisibilityPotion.cs:79-85`, `InvisibilityPotion.cs:78-84`, `GreaterInvisibilityPotion.cs:79-85` - Invisibility potions **reduce** Stealth skill by `100 - Stealth.Base`.
- `Engines and Systems/Magic/Research/Spells/Enchanting/ResearchSneak.cs:85-91` - Research Sneak spell reduces Stealth + Hiding skill and makes target Hidden.

### Character Creation

- `System/Misc/CharacterCreation.cs:940` - **Ninja** starter class begins with **30.0 Stealth**.
- `System/Misc/CharacterCreation.cs:468-469` - Ninja class receives a +5 to +10 Stealth bonus item.

### Crafting

- `Items/Trades/Magical/Tools/BaseRunicTool.cs:229,330` - Stealth is listed as a required skill for runic tool crafting.

### Skill Gains

- `System/Skills/SkillCheck.cs:63` - Stealth gains on use (direct skill check).
- `System/Skills/SkillCheck.cs:265,362` - Thieves Guild and Assassins Guild members gain Stealth while performing actions.
- `ChangeLog.cs:608` - Stealting is 2x more likely to gain.

### Other

- `System/Misc/WeightOverloading.cs:67,105` - DeathStrike step counter is triggered by weight overload, used by ShadowJump and DeathStrike Ninjitsu abilities.
- `System/Misc/BuffIcons.cs:258` - HidingAndOrStealth buff icon (`0x7565`) displays when hidden/stealthing.

## Related Skills

- [Hiding](hiding.md) - Must be hidden first before using Stealth.
- [Searching](searching.md) - Used to detect stealthed players.
- [Tracking](tracking.md) - Tracking difficulty factors in a target's Stealth skill.
