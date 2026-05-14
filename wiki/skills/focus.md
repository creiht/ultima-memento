# Focus

Focus is a passive regeneration skill that accelerates both stamina and mana recovery. It is also one of the three prerequisites for the Mystic (Monk) magic specialization. The character title for this skill is **"Driven"**.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Intelligence |
| Usage | Passive (regen ticks) |
| Cooldown | None |

## How It Works

### Stamina Regeneration

Each regen tick adds a bonus based on Focus:

```
Stam regen bonus = Focus * 0.1
```

At 100 Focus this is **+10 stamina per regen tick**.

### Mana Regeneration

Focus also contributes a smaller mana regen bonus:

```
Mana regen bonus = Focus * 0.05
```

Unlike [Meditation](meditation.md), this bonus is **not blocked by wearing armor**. It applies at all times regardless of equipment.

| Focus Skill | Stam Regen Bonus | Mana Regen Bonus |
|---|---|---|
| 50 | +5.0 | +2.5 |
| 100 | +10.0 | +5.0 |
| 125 | +12.5 | +6.25 |

### Mystic (Monk) Prerequisite

**100 base Focus** is required (alongside 100 base Meditation, 100 base Fist Fighting, and a MysticMonkRobe) to qualify as a Monk and equip a Mystic Spellbook. See [Fist Fighting](fist-fighting.md) for the full prerequisite list.

### Magical Items

Focus is also used as both cast and damage skill by the minor `MagicalSpell` class, which some magic items invoke.

## How to Train

Focus gains passively — each stamina and mana regen tick calls `CheckBonusSkill` automatically. Simply existing and regenerating resources will raise Focus over time. Wearing armor does not interrupt this.

## What It Affects

### Passive Regen

- `RegenRates.cs:88` — Stamina regen bonus: `(int)(Focus * 0.1)` points added per tick (before armor blocking).
- `RegenRates.cs:131` — Mana regen bonus: `(Focus * 0.05)` points added per tick (not blocked by armor).
- `RegenRates.cs:86, 129` — Both regen rate functions call `CheckBonusSkill()` on Focus, enabling passive skill gain during resource recovery.

### Mystic (Monk) Magic

- `MysticSpell.cs:120` — `Focus >= 100` (base) is required to cast any Mystic spell (in addition to Meditation >= 100 and wearing a MysticMonkRobe).
- `Spellbook.cs:788` — `Focus >= 100` (base) is required to equip a MysticSpellbook, otherwise the message "Your need at least a natural grandmaster skill in focus and meditation to equip that!" is shown.

### Magical Spell Items

- `MagicalSpell.cs:11-12` — The abstract `MagicalSpell` class (base for minor magical items) uses Focus as both `CastSkill` and `DamageSkill`. Subclasses include:
  - `AttackSpells.cs` — minor attack spell invoked by items
  - `IdentifySpell.cs` — item-based identification
  - `TravelSpell.cs` — item-based teleportation
  - `ThorLightningSpell.cs` — item-based lightning attack
  - `SummonDragonSpell.cs`, `SummonSkeleton.cs`, `SummonSnakesSpell.cs` — item-based summoning

### Crafting (Alchemy)

- `DefAlchemy.cs:285` — Elixir of Focus is craftable with Alchemy 60–120 using Swamp Berries, Empty Bottle, Garlic, and Tourmaline. Adds a temporary +10 to +60 Focus bonus (duration scales with Cooking, Tasting, and Alchemy).

### Elixirs

- `Elixirs.cs:1936` — Drinking an Elixir of Focus applies a `DefaultSkillMod` to Focus, stacking with the base skill value. Max 2 active elixirs at once; cannot drink another Elixir of Focus while one is active.
- `PotionKeg.cs:390` — Kegs can produce Elixir of Focus via `PotionEffect.ElixirFocus`.
- `ItemSales.cs:3978` — Elixir of Focus is sold by Alchemy vendors (70–95 gold).

### AI & NPCs

- `SkillCheck.cs:386` — `BaseCreature` (NPCs/creatures) cannot passively gain Focus skill; it is disabled for non-player mobiles.
- `HenchmanArcher.cs:74`, `HenchmanWizard.cs:76`, `HenchmanFighter.cs:69`, `HenchmanMonster.cs:54/79/91` — All henchman types are pre-set with Focus at their base skill level (`nSkills`) during creation.

### Guild Access

- `SkillCheck.cs:247` — Focus is a guild-allowed skill for the **Elemental Guild** (alongside Elementalism and Meditation). NPCs in this guild can train Focus without macro restrictions.

### Avatar System

- `SkillArchive.cs:80` — Focus is tracked in the Avatar SkillArchive for stat/skill templates.
- `AvatarShopGumpRewards.cs:307` — When a player selects a template from the Avatar Shop, Focus (and Meditation) are auto-locked to prevent natural skill gain.

### Quests & Learn Books

- `CodexWisdom.cs:406` — Learning option 21 in the Codex of Wisdom quest grants Focus skill.
- `DynamicBook.cs:343` — The "Learn Titles" book assigns the title **"Driven"** to characters with Focus skill.

### Skill Scrolls & Race Skills

- `SpecialScroll.cs:108` — Focus appears on special skill scrolls at index 51.
- `BaseRace.cs:1350` — Focus maps to skill index 50 for racial skill assignments.
- `ResourceMods.cs:1873` — Focus maps to index 21 in resource modification tables.

### UI Display

- `Players.cs:245` — Focus (skill index 21) is displayed in the `!skills` command output when `NskillShow == 21`.
- `SkillListing.cs:83, 170` — Focus appears in the skill listing gump with display of base and value.
- `SkillCheck.cs:429` — When Focus gains, there is a 1 in 10 chance that the skill listing gump is refreshed for the player.

## Related Skills

- [Meditation](meditation.md) — the other co-requisite for Monk status; provides larger active mana regen.
- [Fist Fighting](fist-fighting.md) — the primary Monk combat and spell skill.
- [Elementalism](elementalism.md) — co-taught by Elemental Guild; Focus is one of its allowed skills.
- Mystic magic: [wiki/magic/mystic.md](../magic/mystic.md).
