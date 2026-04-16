# Pet Leveling (Jako System)

The Jako pet leveling system allows you to permanently improve your tamed creatures by spending **trait points** on various attributes.

## How It Works

Tamed creatures earn **trait points** through combat. You can then spend these points to increase your pet's stats and resistances. Each attribute costs a certain number of trait points per upgrade and gives a fixed amount of increase.

## Leveling Attributes

| Attribute | Points per Upgrade | Increase per Upgrade | Cap | Scale |
|-----------|-------------------|---------------------|-----|-------|
| Hit Points | 1 | +10 | 550 | 1.5x base |
| Stamina | 1 | +10 | 250 | 1.5x base |
| Mana | 1 | +10 | 250 | 1.5x base |
| Physical Resist | 2 | +1 | 70 | 1.25x base |
| Fire Resist | 2 | +1 | 70 | 1.25x base |
| Cold Resist | 2 | +1 | 70 | 1.25x base |
| Poison Resist | 2 | +1 | 70 | 1.25x base |
| Energy Resist | 2 | +1 | 70 | 1.25x base |

## Caps and Scaling

Each attribute has both an **absolute cap** and a **scaling cap** based on the pet's base stats:

- The **absolute cap** is the hard maximum for that attribute (e.g., 550 for hit points).
- The **scale factor** multiplied by the pet's original base value determines the effective cap. For example, a pet with 200 base hit points can be upgraded to a maximum of `200 × 1.5 = 300` hit points (still under the 550 absolute cap).
- If a pet's base stat already exceeds the cap, no further upgrades can be applied to that attribute.

## Tips

- Spend trait points wisely — stronger base creatures benefit more from the scaling system.
- Resistance upgrades cost 2 trait points each but only add +1, making them more expensive than stat upgrades.
- Hit points are generally the most efficient investment (1 point for +10 HP).
- The system is designed so that pets grow proportionally to their natural abilities rather than uniformly.
