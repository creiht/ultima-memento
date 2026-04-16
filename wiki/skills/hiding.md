# Hiding

Hiding lets you conceal yourself from the sight of other players and creatures.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Dexterity |
| Usage | Active |
| Cooldown | 4 seconds |

## How It Works

Using Hide attempts to make you invisible. Success depends on your skill level and whether you are in combat.

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

## Related Skills

- [Stealth](stealth.md) - Move while hidden.
- [Searching](searching.md) - Detect hidden players and objects.
