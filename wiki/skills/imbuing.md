# Imbuing

> **Disabled — Legacy Skill**
> Imbuing appears in the skills gump and the `SkillName` enum but is **not active** in Ultima Memento. It cannot be trained, modified by powerscrolls, or targeted by avatar rewards.

## Status

Imbuing was introduced in the official Ultima Online: Stygian Abyss expansion as a skill for enhancing magical properties on weapons and armor using special ingredients. **None of this functionality is implemented in Ultima Memento.**

The skill value in your character sheet is permanently read-only — the setter is a no-op in the engine (`Skills.cs:1057`). The following systems explicitly skip this skill:

- Character creation (`CharacterCreation.cs:474`)
- Avatar reward shop (`AvatarShopGumpRewards.cs:456, 499`)
- Powerscroll buy menu (`PowerScrollBuy.cs:53`)

No source file under `World/Source/Scripts/System/Skills/` implements Imbuing. No items reference it for gain. No NPC trains it. The title "Artificer" that would be awarded at Grandmaster is present in the skill definition but effectively orphaned.

## What to Do Instead

Ignore this skill entirely. For active magical-item crafting in Ultima Memento, see:

- [Inscription](../crafting/inscription.md) — scribing scrolls and magical books.
- Tinkering ([crafting](../crafting/tinkering.md)) — mechanical and magical devices.

## Related Skills

- [Inscription](../crafting/inscription.md)
- Tinkering ([crafting](../crafting/tinkering.md))
