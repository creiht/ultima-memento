# Knight (Chivalry)

The Knight school represents the holy combat abilities of paladins. These abilities use [Knightship](../skills/knightship.md) and require positive Karma and Tithing Points earned through virtuous deeds.

## Requirements

- **Skill:** [Knightship](../skills/knightship.md)
- **Karma:** Must be **non-negative** (≥ 0) — Karma of exactly 0 is allowed (source: `PaladinSpell.cs:40`)
- **Tithing Points:** Consumed when casting abilities
- **Stamina:** Most abilities also require stamina
- **Spellbook:** Book of Chivalry

## How to Learn

Acquire a Book of Chivalry and learn paladin abilities. Tithing Points are earned by tithing gold at shrines of Virtue.

## Spell List

| Spell | Mana | Min Skill | Tithing | Effect |
|-------|------|-----------|---------|--------|
| Cleanse By Fire | - | 5.0 | 10 | Burns away poison from the target |
| Close Wounds | - | 0.0 | 10 | Heals the target's wounds |
| Consecrate Weapon | - | 15.0 | 10 | Imbues weapon to deal the target's weakest resistance type |
| Dispel Evil | - | 35.0 | 10 | Dispels summoned creatures and damages undead nearby |
| Divine Fury | - | 25.0 | 10 | Increases attack speed and damage but lowers defense |
| Enemy of One | - | 45.0 | 10 | Greatly increases damage against one creature type |
| Holy Light | - | 55.0 | 10 | Deals energy damage to all enemies nearby |
| Noble Sacrifice | - | 65.0 | 30 | Heals, cures, and resurrects nearby allies at great personal cost |
| Remove Curse | - | 5.0 | 10 | Removes curses from the target |
| Sacred Journey | - | 15.0 | 10 | Teleports to a marked rune (like Recall) |

## Notes

- Power scales with both **Knightship skill** and **Karma**.
- Tithing Points can be reduced by Lower Reagent Cost properties.
- Knight abilities use stamina in addition to mana.
