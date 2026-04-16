# Poisoning

Poisoning lets you apply poison from poison potions onto weapons, food, and beverages.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Dexterity |
| Usage | Active (targeted) |
| Cooldown | 5 seconds |

## How It Works

1. Use the skill and target a **poison potion** in your inventory.
2. Then target the item you wish to poison.

### Valid Targets

- **Weapons:** Depends on your "Classic Poisoning" preference setting:
  - *Classic Mode:* Only **one-handed slashing or piercing** weapons can be poisoned.
  - *Standard Mode:* Only weapons with the **Infectious Strike** or **Shadow Infectious Strike** ability can be poisoned.
- **Food:** Any food item.
- **Beverages:** Any drink.
- **Fukiya Darts & Shuriken:** Special ninja weapons.

### Poison Charges on Weapons

When successfully applied, weapons receive charges based on poison level:

| Poison Level | Charges |
|---|---|
| Lesser (0) | 18 |
| Regular (1) | 16 |
| Greater (2) | 14 |
| Deadly (3) | 12 |
| Lethal (4) | 10 |

Formula: `Charges = 18 - (Poison Level * 2)`

### Failure Consequences

On a failed poisoning attempt:
- If your Poisoning skill is below **80**, there is a **5% chance** you poison yourself with the poison you were trying to apply.
- Otherwise you simply fail with no additional penalty.

### Other Effects

- The empty bottle is returned to your pack after using a poison potion.
- Successfully poisoning costs **-20 Karma**.

## How to Train

Apply poison potions to weapons, food, or drink. The skill check range is determined by the specific poison potion's min/max skill values. Use progressively stronger poisons as your skill increases.

## Related Skills

- [Tasting](tasting.md) - Detects poison in food and drink.
- [Weapon Abilities](weapon-abilities.md) - Infectious Strike applies weapon poison on hit.
