# Silvani 

Silvani is a Champion Boss associated with nature. A magical forest spirit, she attacks evil creatures and summons pixies when attacked. Her melee strikes deal additional damage and drain both stamina and mana from her targets.

[Back to Creature Index](../README.md) | [Champion Bosses](base-champion.md)

## Stats

| Stat | Value |
|------|-------|
| Hits | 600 |
| Strength | 253-400 |
| Dexterity | 157-850 |
| Intelligence | 503-800 |
| Damage | 27-38 |
| Virtual Armor | 50 |
| Fame | 20000 |
| Karma | 20000 |

## Resistances

| Physical | Fire | Cold | Poison | Energy |
|----------|------|------|--------|--------|
| 45-55 | 30-40 | 30-40 | 40-50 | 40-50 |

## Damage Types

| Type | Percentage |
|------|-----------|
| Physical | 75% |
| Cold | 25% |

## Skills

| Skill | Value |
|-------|-------|
| FistFighting | 97.6-100.0 |
| Magery | 97.6-107.5 |
| MagicResist | 100.5-150.0 |
| Meditation | 100.0 |
| Psychology | 100.0 |
| Tactics | 97.6-100.0 |

## Special Abilities

- Immune to Regular Poison
- Unprovokable
- Spawns Pixies

## Loot

Body loot (`GenerateLoot`): [UltraRich](../../systems/loot-tables/monster-packs.md#ultrarich) ×2 (two independent rolls)

Silvani is a `BaseCreature` spawned by the Lord Oaks champion engine, not a `BaseChampion`, and therefore does not grant champion reward drops.

*Special drops:* `ChampionSkull` ~10% (Fame ≥ 20,000)
