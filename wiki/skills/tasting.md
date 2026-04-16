# Tasting

Tasting (Taste Identification) lets you detect poison in food and beverages, and also appraise and identify items.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Intelligence |
| Usage | Active (targeted) |
| Range | 2 tiles |
| Skill Check | 0 - 125 |

## How It Works

### Food and Beverages

Target a piece of food or a drink to check for poison. On success, you learn the **poison level**:

| Poison Level | Message |
|---|---|
| Lesser | "It appears to have a slight taste of poison" |
| Regular | "It appears to have a somewhat bitter taste of poison" |
| Greater | "It appears to have a bitter taste of poison" |
| Deadly | "It appears to have a strong taste of poison" |
| Lethal | "It appears to have a very strong taste of poison" |
| None | "This food/liquid looks safe to eat/drink" |

**Warning:** On a **failed** check against poisoned food, you accidentally **eat or drink it**, consuming the poison! "You bit off a bit too much!" / "You swallowed a bit too much!"

### Item Identification

When targeting any other item, the Tasting skill functions as an item identification ability via the `RelicFunctions.IDItem` system, similar to [Arms Lore](arms-lore.md) and [Mercantile](mercantile.md).

### Mobiles

Targeting a creature or player: "You feel that such an action would be inappropriate."

## How to Train

Test poisoned and unpoisoned food/beverages. The skill check is 0-125. You can also identify items to gain skill. Be careful with very strong poisons at low skill - failure means consuming them.

## Related Skills

- [Poisoning](poisoning.md) - Apply poison to items that Tasting detects.
- [Arms Lore](arms-lore.md) - Another item identification skill.
- [Mercantile](mercantile.md) - Another item identification skill.
