# Hiding

Hiding lets you conceal yourself from the sight of other players and creatures, enabling sneak attacks and evasion.

## Overview

| Property | Value |
|---|---|
| **Primary Stat** | Dexterity |
| **Usage** | Active |
| **Skill Type** | Rogue |
| **Skill Check** | 0 – 100 (out of combat), 100 – 125 (combat) |

## Description

Hiding lets you conceal yourself from the sight of other players and creatures, enabling sneak attacks and evasion. It is a foundational rogue skill that pairs with Stealth for advanced mobility and with Searching for detection contests.

## How It Works

### Out of Combat

At **100 skill**, hiding out of combat is **guaranteed** to succeed. Below 100, a skill check against 0-100 determines success.

You can always successfully hide inside a house where you are a Friend or higher.

### In Combat

When a hostile combatant is nearby and has line of sight to you, hiding becomes much harder. The detection range scales with skill:

| Hiding Skill | Detection Range |
|---|---|
| 0 | 14 tiles |
| 50 | 9 tiles |
| 100 | 4 tiles |

If someone within range is fighting you (or you are fighting them), the standard hide will fail. However, at **100+ skill**, a secondary check provides a chance to hide even in combat:

| Hiding Skill | Combat Hide Chance |
|---|---|
| 100 | 0% |
| 110 | 15% |
| 120 | 30% |
| 125 | 40% |

The formula is: `(Skill - 100) * 1.5%`, with a bonus +2.5% at exactly 125 skill.

### Auto-Stealth at GM

At **100+ Hiding**, successfully hiding will automatically attempt to activate [Stealth](stealth.md). If Stealth succeeds, you begin moving silently immediately.

### Pet Hiding

When you hide, all your controlled pets also become hidden.

### Restrictions

- Cannot hide while casting a spell.
- Active targets are cancelled when you hide.
- Hiding sets you out of war mode.

## How to Train

Simply use the skill repeatedly. The out-of-combat check ranges from 0-100, so you can gain on any attempt until reaching GM.

## What It Affects

### Combat & Weapons
- `BaseWeapon.cs:1114` — Sneak attack detection: if the attacker is hidden and their Hiding skill exceeds a random value between 1-125, the `SneakDamage` flag is set.
- `BaseWeapon.cs:1539-1560` — Sneak attack damage bonus: `Hiding + Stealth` combined skill determines the bonus, up to 125% for melee weapons (halved for ranged). Formula: `(0.015 * (Hiding + Stealth)) / 1.50` * random modifier.
- `DeathStrike.cs:125` — Ninjitsu Death Strike damage is multiplied by a scalar of `(Hiding + Stealth) / 220`, capping at 1.0x. Higher Hiding directly increases Death Strike damage.

### Magic Systems
- `Reveal.cs:181` — Magery Reveal spell uses the formula `50 * (Magery + Searching) / (Hiding + Stealth)` to determine success against hidden targets.
- `MindsEye.cs:186` — Jedi Mind's Eye spell uses the same detection formula: `50 * (JediPower + Psychology) / (Hiding + Stealth)`.
- `EagleEye.cs:189` — Shinobi Eagle Eye spell: `50 * (Ninjitsu + Searching) / (Hiding + Stealth)`.
- `ResearchSneak.cs:83` — Research Sneak spell applies a skill mod debuff to targets, reducing their Hiding by `100 - Hiding.Base` (capped at 0 minimum).
- `InvisibilityPotion.cs:76` — Lesser Invisibility Potion reduces target's Hiding by `100 - Hiding.Base` for the duration.
- `LesserInvisibilityPotion.cs:77` — Lesser Invisibility Potion reduces target's Hiding by `100 - Hiding.Base` for the duration.
- `GreaterInvisibilityPotion.cs:77` — Greater Invisibility Potion reduces target's Hiding by `100 - Hiding.Base` for the duration.

### Items
- `Corpse.cs:1154` — Looting a corpse while hidden: if your Hiding is below a random value of 1-125, you reveal yourself.
- `DungeonChest.cs:228` — Opening a dungeon chest while hidden: same reveal check at Hiding < random(1,125).
- `BaseDoor.cs:557` — Operating a hidden door while hidden: same reveal check at Hiding < random(1,125).
- `GemOfSeeing.cs:114` — The Gem of Seeing artifact detects hidden mobile players using `Hiding + random(-10, 10)` in the same comparison formula as Searching.
- `DisguiseKit.cs:57` — Disguise Kit requires at least 50 base in Hiding (along with 50 in Ninjitsu, Stealth, Psychology, or Snooping) to use.

### AI & NPCs
- `Behavior.cs:3735` — NPCs can autonomously hide when their HP drops to 20% (HitsMax/5). Requires Hiding >= random(1,120) and a 1 in `maxChance` roll. Successfully hides and relocates.
- `Behavior.cs:8815` — NPC searching detection: target's Hiding is divided by 2.9 and Stealth by 1.8, then subtracted from the NPC's Searching skill to determine reveal chance.
- `BaseCreature.cs:6879` — NPCs can only teach Stealth if the student has at least 50 Hiding (SE era) or 80 Hiding (ML era).

### Quests & Harvest
- `GraveRobbing.cs:217` — When a grave robber is spotted (2% chance per dig), having Hiding >= 30 avoids detection. If still caught, Stealth determines if they escape unnoticed.
- `Thief/Coffer.cs:190` — Thief quest coffer: if you have >= 10 Snooping but fail the check, your hiding is tested at `Hiding/2 < random(0,100)` to determine if you reveal yourself.

## Related Systems & Skills

### Synergies
- [Stealth](stealth.md) — Auto-invoked at 100+ Hiding when successfully hidden. Combined with Hiding for sneak attacks, Death Strike scaling, and all reveal spell checks.
- [Night Sight](../magic/magery.md) — The Night Sight equipment attribute (`AosAttribute.NightSight`) can help detect hidden items; also useful for spotting enemies that might detect your hiding.

### Prerequisites / Co-requisites
- [Stealth](stealth.md) — Required prerequisite for Stealth (50/80 threshold). Combined with Hiding for sneak attacks, Death Strike scaling, and all reveal spell checks. Auto-invoked at 100+ Hiding.
- [Ninjitsu](ninjitsu.md) — Death Strike damage scales with combined Hiding+Stealth. Disguise Kit requires 50 Ninjitsu alongside 50 Hiding.
- [Snooping](snooping.md) — When snoop fails, Hiding/2 is checked to determine if the snoop is revealed to others.

## Notes
- At 100+ Hiding, successfully hiding will automatically attempt to activate Stealth for silent movement.
- In combat hiding is extremely difficult below 100 skill; the secondary check only begins at 100 and maxes at 40% at 125 skill.
- Your pets become hidden when you hide, providing a team-wide stealth benefit.
- Hiding cancels active targets and sets you out of war mode.
