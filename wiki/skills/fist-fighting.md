# Fist Fighting

Fist Fighting governs unarmed combat and is the core skill of the Mystic (Monk) magic system. Reaching 100 base Fist Fighting is required before any Mystic spell can be cast.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Strength |
| Usage | Passive (unarmed swing / Mystic cast) |
| Cooldown | None |

## How It Works

### Unarmed Combat

When no weapon is equipped (or pugilist gloves are worn), Fist Fighting is used as the active combat skill for hit chance and ability resolution.

### Mystic (Monk) Magic Prerequisite

To qualify as a Monk and use any Mystic spell you must simultaneously meet **all** of the following:

- **100 base Fist Fighting**
- **100 base Meditation**
- **100 base Focus**
- Wearing a **MysticMonkRobe** with **no other armor**

Fist Fighting is both the **CastSkill** and **DamageSkill** for every Mystic spell.

### Mystic Spell Scaling

| Spell | Formula |
|---|---|
| Psionic Blast | Damage = `(FistFighting + Int) / 4` |
| Gentle Touch | Heal = `FistFighting / 10 + rand(1, 10)` |
| Quivering Palm | Paralyze duration = `FistFighting` seconds |

See [Mystic magic](../magic/mystic.md) for the full spell list.

### Spiritualism Synergy

Fist Fighting contributes `FistFighting * 0.15` to the quality of Spiritualism summons.

### NPC AI Gates

Several NPC abilities require reaching certain Fist Fighting thresholds alongside other skills:

- **80+ Fist Fighting + 80+ Anatomy** → NPC AI unlocks **Stun**.
- **80+ Fist Fighting + 80+ Arms Lore** → NPC AI unlocks **Disarm**.

## How to Train

Attack while unarmed. Fist Fighting also gains on every Mystic spell cast. Monks in training should alternate between sparring unarmed and casting spells.

## Related Skills

- [Meditation](meditation.md) — co-requisite for Monk status; affects mana regeneration.
- [Focus](focus.md) — co-requisite for Monk status; affects stamina and mana regen.
- [Anatomy](anatomy.md) — NPC stun synergy; evaluates physical condition.
- [Arms Lore](arms-lore.md) — NPC disarm synergy.
- [Spiritualism](spiritualism.md) — gains summon quality boost from Fist Fighting.
- Mystic magic: [wiki/magic/mystic.md](../magic/mystic.md).
