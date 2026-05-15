# Throwing

> **Disabled — Legacy Skill**
> Throwing appears in the skills gump and the `SkillName` enum but is **not active** in Ultima Memento. It cannot be trained, modified by powerscrolls, or targeted by avatar rewards.

## Overview

| Property | Value |
|---|---|
| **Primary Stat** | N/A |
| **Usage** | N/A |
| **Skill Type** | Disabled |
| **Skill Check** | N/A |

## Status

Throwing was introduced in the official Ultima Online: Stygian Abyss expansion as a Gargoyle-race combat skill for cyclone, boomerang, and soul glaive throwing weapons. **None of this functionality is implemented in Ultima Memento.**

The following systems explicitly skip this skill:

- Character creation (`CharacterCreation.cs:475`)
- Avatar reward shop (`AvatarShopGumpRewards.cs:457, 500`)
- Powerscroll buy menu (`PowerScrollBuy.cs:54`)

No source file under `World/Source/Scripts/System/Skills/` implements Throwing. No weapon in the game declares `DefSkill = Throwing`. Throwing-style weapons that exist in Ultima Memento — Harpoon, Throwing Gloves, Monster Gloves — all use **Marksmanship** instead.

## How It Works

This skill is **not implemented**. No mechanics, checks, or effects exist.

## How to Train

Cannot be trained. The skill cannot be increased under any circumstances.

## What It Affects

None. This skill has no impact on gameplay.

## Related Systems & Skills

### Alternatives
- `[Marksmanship](marksmanship.md)`: The active substitute for all ranged/thrown combat. Covers all thrown, ranged, and projectile weapons in the game.

## Notes

- For ranged and thrown combat, train Marksmanship instead.
- Throwing-style weapons (Harpoon, Throwing Gloves, Monster Gloves) all use Marksmanship.
- The skill exists only as a placeholder from the original UO codebase.
