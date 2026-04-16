# Arms Lore

Arms Lore lets you identify and appraise weapons, armor, and other equipment. It also passively reduces durability loss on your gear.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Intelligence |
| Usage | Active (targeted) + Passive |
| Range | 2 tiles |

## How It Works

### Active Use - Item Identification

Use the skill and target any item. The item will be identified via the `RelicFunctions.IDItem` system, revealing its properties, quality, and enchantments.

### Passive Use - Durability Protection

Arms Lore provides a passive chance to **avoid durability loss** on your equipped items during combat. This check occurs automatically whenever your gear would take durability damage.

| Arms Lore Skill | Approximate Avoid Chance |
|---|---|
| Below 5 | 0% |
| 50 | ~25% (when triggered) |
| 100 | ~50% (when triggered) |

The check works in two stages: first a 50% coin flip, then a skill-vs-random(100) check. Both must succeed. Below 5 skill, the passive effect does not activate.

## How to Train

Target weapons, armor, and other items to gain skill. Since identification uses the `RelicFunctions.IDItem` system, the difficulty scales with the item being examined.

## Related Skills

- [Mercantile](mercantile.md) - Also identifies items, but from a merchant/trade perspective.
- [Tasting](tasting.md) - Can also identify certain items.
