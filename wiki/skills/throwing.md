# Throwing

> **Disabled — Legacy Skill**
> Throwing appears in the skills gump and the `SkillName` enum but is **not active** in Ultima Memento. It cannot be trained, modified by powerscrolls, or targeted by avatar rewards.

## Status

Throwing was introduced in the official Ultima Online: Stygian Abyss expansion as a Gargoyle-race combat skill for cyclone, boomerang, and soul glaive throwing weapons. **None of this functionality is implemented in Ultima Memento.**

The following systems explicitly skip this skill:

- Character creation (`CharacterCreation.cs:475`)
- Avatar reward shop (`AvatarShopGumpRewards.cs:457, 500`)
- Powerscroll buy menu (`PowerScrollBuy.cs:54`)

No source file under `World/Source/Scripts/System/Skills/` implements Throwing. No weapon in the game declares `DefSkill = Throwing`. Throwing-style weapons that exist in Ultima Memento — Harpoon, Throwing Gloves, Monster Gloves — all use **Marksmanship** instead.

## What to Do Instead

For ranged and thrown combat, train [Marksmanship](marksmanship.md). It covers all thrown, ranged, and projectile weapons in the game.

## Related Skills

- [Marksmanship](marksmanship.md) — the active substitute for all ranged/thrown combat.
