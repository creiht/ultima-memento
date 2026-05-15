# Bushido

Bushido is the samurai's martial discipline. It governs the activation and power of Bushido combat techniques cast from a Book of Bushido — offensive strikes, defensive stances, and evasive parries.

## Overview

| Property | Value |
|---|---|
| **Primary Stat** | Strength |
| **Usage** | Active (activate Bushido abilities) |
| **Skill Type** | Combat / Magic (weapon ability) |
| **Skill Check** | 0 - 100 (varies by ability) |

## Description

Bushido is a samurai martial discipline that governs offensive strikes, defensive stances, and evasive parries activated from a Book of Bushido. Each ability scales with Bushido skill, and the skill also provides passive combat bonuses to weapons and parry calculations.

## How It Works

### Bushido Abilities

Each Bushido ability's effectiveness scales with Bushido skill:

| Ability | Min Skill | Mana | Effect |
|---------|-----------|------|--------|
| Confidence | 25 | 10 | 15s stance; regenerates hits each tick: `15 + (Bushido² / 57600)` hits/tick. While active, blocks hit-interrupting spell casts. |
| Evasion | 60 | 10 | 20s stance (scales: `3 + (Bushido - 60) / 20` seconds with scaling). Lets you parry with a weapon. Requires weapon skill base >= 50 (ML). |
| Counter Attack | 40 | 5 | 30s stance. On successful block, immediately counter-attacks with your weapon. |
| Honorable Execution | 25 | 0 | Next hit deals `1.0 + (Bushido × 20) / 10000` × damage. If target dies: heal `20 + (Bushido² / 480)` hits + swing bonus for 20s. If target lives: apply -40 to all resistances and -MagicResist skill for 7s. |
| Lightning Strike | 50 | 5 | Next attack gains accuracy bonus: `25 + max(0, (Bushido - 50) / 2)`, capped at 50. Has armor-piercing chance: `Bushido² / 72000`. |
| Momentum Strike | 70 | 10 | After killing a target, strikes a second nearby enemy within weapon range. Damage bonus: `Bushido / 100` (doubled if primary target was dead). |

### Passive Combat Bonuses

- **Damage bonus** on Axe, Slashing, and Polearm weapons: `GetBonus(Bushido, 0.625, 100.0, 6.25)` — up to +6.25 damage.
- **Parry calculations** — Bushido reduces shield parry chance and multiplies weapon parry chance (`parry × bushido / divisor`). Parry or Bushido >= 100 grants +5% parry.
- **Evasion parry scalar** — while Evading, parry chance is multiplied: `1.0 + ((Bushido - 60) × 0.004 + 0.16)`, up to 1.56x (or 1.66x with GM Tactics + GM Anatomy + Bushido > 100).

### Stance Rules

Only one Bushido stance (Evasion, Confidence, Counter Attack) can be active at a time. Activating a new stance cancels the current one.

Honorable Execution and Lightning Strike are special moves triggered on weapon swings. Momentum Strike triggers only when your primary target dies.

## How to Train

- Acquire a Book of Bushido (purchased from the Monk merchant, costs 140 gold) and activate abilities in combat — each use rolls a skill gain check.
- Use abilities at or near their minimum skill thresholds for fastest gains. For example, start with Confidence/Honorable Execution at 25, then progress to Counter Attack at 40, Lightning Strike at 50, and Momentum Strike at 70.
- Lightning Strike gain check only rolls if Bushido >= RequiredSkill + 37.5 (87.5 for Lightning Strike).

## What It Affects

### Combat & Weapons

- `BaseWeapon.cs:2395` — Bushido provides +6.25 damage bonus on Axe, Slashing, and Polearm weapons via `GetBonus(attacker.Skills.Bushido.Value, 0.625, 100.0, 6.25)`.
- `BaseWeapon.cs:1212-1268` — `CheckParry()` uses Bushido in parry formulas: shield parry is reduced by Bushido; weapon parry is `parry × bushido / divisor`; both Parry >= 100 or Bushido >= 100 add +5% parry chance.
- `BaseWeapon.cs:1307` — On block while Confidence is active, heal `bushido / 12` hits and `bushido / 5` stamina.
- `BaseWeapon.cs:1288` — Blocking an Honorable Execution removes the penalty (resistance/skill debuff).

### Bushido Abilities (Magic System)

- `Confidence.cs:146` — Hit regen per tick: `15 + (Bushido² / 57600)`.
- `Evasion.cs:150-154` — Evasion duration scales: `3 + (Bushido - 60) / 20` seconds; +1s bonus with GM Tactics + GM Anatomy + Bushido > 100.
- `Evasion.cs:178-182` — Evasion parry scalar: `1.0 + ((Bushido - 60) × 0.004 + 0.16)`, +0.10 bonus with GM Tactics + GM Anatomy + Bushido > 100.
- `HonorableExecution.cs:26` — Damage scalar: `1.0 + (Bushido × 20) / 10000`.
- `HonorableExecution.cs:52` — On kill: heal `20 + (Bushido² / 480)` hits.
- `HonorableExecution.cs:54` — On kill: swing bonus = `Bushido² / 720` for 20 seconds.
- `LightningStrike.cs:36-39` — Accuracy bonus: `25 + max(0, (Bushido - 50) / 2)`, capped at 50.
- `LightningStrike.cs:58` — Armor ignore chance: `Bushido² / 72000`.
- `MomentumStrike.cs:50` — Secondary hit damage bonus: `Bushido / 100` (×1.5 if primary target dead).

### Mana Reduction & Weapon Abilities

- `WeaponArmorCalls.cs:123` — Bushido contributes to `ManaRedux` calculation. Total of (Swords + Bludgeoning + Fencing + Marksmanship + Parry + Lumberjacking + Stealth + Poisoning + Bushido + Ninjitsu) >= 300 reduces weapon ability mana by 10; >= 200 reduces by 5.
- `WeaponAbility.cs:73` — Bushido is factored into weapon ability mana cost reduction.
- `WeaponAbility.cs:211` — Honorable Execution penalty is checked before executing weapon abilities.

### Feint & Double Whirlwind

- `Feint.cs:41` — Feint damage reduction uses `max(Ninjitsu, Bushido)`. Bonus formula: `20 + 3 × (skill - 50) / 7`.
- `DoubleWhirlwindAttack.cs:50-51` — Area attack damage bonus: `1.0 + ((targetCount × Bushido) / 60)² / 100`, capped at 2.0.

### Items & Gear

- `BaseRunicTool.cs:191` — Bushido is a possible bonus skill on runic tools.
- `BaseRunicTool.cs:243` — Bushido is a possible fight skill on runic tools.
- `BaseRunicTool.cs:335-393` — `BookOfBushido` has its own special skill table for runic tool applications.
- `ItemSales.cs:2072` — Book of Bushido sold by Monk merchant for 140 gold (Orient world).
- `Loot.cs:239,247` — Book of Bushido spawns in loot containers alongside Book of Ninjitsu.
- `ResourceMods.cs:441` — Book of Bushido can receive bonus skills from resource mods.
- `ItemProperties.cs:1335-1345` — Books of Bushido can have descriptive prefixes (e.g., "of Bushido", "of the Bushido Arts").
- `Spellbook.cs:769` — Book of Bushido requires 30.0 base Bushido to read (for skill checks on content).

### Mounts

- `YoungRoc.cs:94` — Young Roc can be bonded if Bushido base >= 90.
- `YoungRoc.cs:123` — Special Roc effect triggers at Bushido base >= 120.

### NPC AI (OmniAI)

- `OmniAI Core.cs:43-45` — NPCs can use Bushido if skill > 10.
- `OmniAI Bushido.cs:54-59` — NPC stance selection: Evasion at >= 60, Counter Attack at >= 40, Confidence at >= 25.
- `OmniAI Bushido.cs:82-87` — NPC move selection: Momentum Strike at >= 70, Lightning Strike at >= 50, Honorable Execution at >= 25 (when opponent hits <= DamageMin).
- `OmniAI Magery.cs:201` — NPCs avoid casting spells against foes with Bushido > 35 (Evasion detection).
- `OmniAI Core.cs:70` — Bushido + Ninjitsu together determine NPC spell-casting capability.

### Avatar System

- `SkillArchive.cs:39-40` — Bushido is tracked as the 9th skill in the Avatar/leveling system.

### Character Creation

- `CharacterCreation.cs:460-461` — Samurai faction starts with a Book of Bushido in their starting bag.

### Achievement & Display

- `Titles.cs:249` — Bushido determines combat tier (tier 1).
- `Players.cs:192` — Bushido maps to combat tier 1 in player display.
- `SkillListing.cs:70` — Bushido is the 9th skill listed in skill displays.

### Special Scrolls & Tools

- `SpecialScroll.cs:110` — Bushido can appear as a skill on special scrolls.
- `PowerScroll.cs:61` — Bushido power scrolls are available at level 171.

## How to Obtain a Book of Bushido

- Purchase from a **Monk** merchant for 140 gold (Orient world only).
- Find as loot in containers (spawns alongside Book of Ninjitsu and Mystic Spellbook).
- Acquire via runic tool application (Bushido-specific skill table).

## Related Systems & Skills

### Synergies
- [Ninjitsu](ninjitsu.md): Feint uses whichever is higher: Bushido or Ninjitsu. Both skills feed into mana reduction. OmniAI NPCs use both for ability selection.
- [Parrying](parrying.md): synergizes directly with Evasion's weapon-parry chance. Bushido also factors into shield and weapon parry calculations.
- [Tactics](tactics.md): GM Tactics (+ GM Anatomy) extends Evasion duration and parry scalar.
- [Anatomy](anatomy.md): GM Anatomy (+ GM Tactics) extends Evasion duration by 1 second.
- [Confidence](../magic/bushido.md#confidence): Buff icon `BuffIcon.Confidence` tracks active stance.
- [Evasion](../magic/bushido.md#evasion): Buff icon `BuffIcon.Evasion` and `BuffIcon.Counter` track active stances.
- [Honorable Execution](../magic/bushido.md#honorable-execution): Buff icon tracks penalty state.
- [Weapon Abilities](../systems/weapon-abilities.md): Bushido contributes to mana cost reduction for all weapon abilities.

### Prerequisites / Co-requisites
- [Book of Bushido](../items/books.md): Required spellbook. Held in trinket slot. Requires 30.0 base Bushido to read.
- [Samurai faction](../races/factions.md): Starts with a Book of Bushido in their starting bag.
- [Young Roc](../creatures/mounts.md): Can be bonded if Bushido base >= 90; special effect at Bushido >= 120.

## Notes
- Only one Bushido stance (Evasion, Confidence, Counter Attack) can be active at a time.
- Lightning Strike gain check only rolls if Bushido >= RequiredSkill + 37.5.
- Honorable Execution on kill heals and applies a swing bonus; on failure, applies -40 to all resistances and -MagicResist skill.
- Bushido is a combat tier 1 skill in the achievement system.
