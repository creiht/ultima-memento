# Fountain of Life

The Fountain of Life is a special house addon container that converts regular bandages into enhanced bandages, providing a persistent healing bonus for the owner.

## Properties

| Property | Value |
|----------|-------|
| Type | House addon / Container |
| Max Items | 125 bandage stacks |
| Charges | Up to 10 (shown in item tooltip) |
| Recharge Rate | Fully recharges to 10 charges every **24 hours** |
| Loot Type | Blessed (deed) |

## How It Works

1. **Drag bandages** into the Fountain of Life (either directly onto the addon or into its container).
2. Each charge converts one bandage (or batch of bandages up to the charge count) into an **Enhanced Bandage**.
3. **Enhanced Bandages** heal for `+10` hit points more than normal bandages (`EnhancedBandage.HealingBonus = 10`).
4. The fountain processes bandages using its current charge count: if it has 3 charges and you drop in 10 bandages, 3 become enhanced and 7 remain regular.
5. Charges replenish automatically every 24 hours (`RechargeTime = TimeSpan.FromDays(1)`). When it recharges, it immediately converts any bandages still inside.

## Placement

- Must be placed inside a **player-owned house** — it is a house addon, not a portable item.
- The deed is blessed and survives player death.
- Placed via deed (double-click the `FountainOfLifeDeed` to place).
- Cannot be moved once placed (returns to deed only through normal house addon mechanics).

## How to Obtain

The Fountain of Life is obtained as a special veteran reward or rare event prize.

## Cross-links

- [Healing / Veterinary](../../skills/) — skills that use bandages
- [Special Items](../special.md) — other special items
