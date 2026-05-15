# Attributes

Every character has three primary attributes (stats) that determine your capabilities, plus derived secondary stats.

## Primary Attributes

| Attribute | Abbreviation | Effects |
|---|---|---|
| **Strength** | Str | Hit points, carry weight, melee damage |
| **Dexterity** | Dex | Stamina, attack speed, movement |
| **Intelligence** | Int | Mana pool, mana regen, magic effectiveness |

### Strength (Str)

Strength is the primary stat for melee fighters and anyone carrying heavy equipment.

- **Hit Points** — your max HP scales from Strength (approximately Str x 2.0). A character with 100 Str has roughly 200 HP.
- **Carry Weight** — determines how much you can carry before becoming overloaded. Exceeding your limit by more than 4 stones drains stamina while moving.
- **Melee Damage** — higher Strength increases damage with melee weapons.

### Dexterity (Dex)

Dexterity governs speed and agility.

- **Stamina** — your max stamina scales from Dexterity (approximately Dex x 2.0).
- **Attack Speed** — higher Dexterity increases weapon swing speed.
- **Movement** — stamina is consumed by movement, combat, and carrying heavy loads.

### Intelligence (Int)

Intelligence is the primary stat for spellcasters.

- **Mana** — your max mana scales from Intelligence (approximately Int x 2.0).
- **Mana Regeneration** — Int works with the Meditation skill to boost mana recovery.
- **Magic Effectiveness** — factors into spell damage and magical abilities.

## Stat Caps

- **Starting stat cap:** 250 (max sum of Str + Dex + Int)
- **Minimum per stat:** 10
- **Maximum per stat at creation:** 60
- **Starting stat points:** 90
- **Max stat cap (with Avatar upgrades):** 400

Stats increase passively through normal gameplay. The server checks for stat gains approximately every **7.5 minutes**:
- **Strength** gains from physical combat
- **Dexterity** gains from speed-based activities
- **Intelligence** gains from magic and crafting

## Secondary Stats

These are derived from your primary attributes and cannot be set directly.

| Stat | Derived From | Regen Rate |
|---|---|---|
| Hit Points | Strength x 2.0 | 1 per ~11 seconds |
| Stamina | Dexterity x 2.0 | 1 per ~7 seconds |
| Mana | Intelligence x 2.0 | 1 per ~7 seconds |

### Hit Points (HP)

When HP reaches zero, you die. HP can be restored through:
- Bandages and the Healing skill
- Healing spells from various magic schools
- Heal potions
- Equipment with HP regeneration bonuses (capped at +18)

### Stamina

Consumed by movement, combat actions, and heavy loads. Low stamina slows your actions. Boosted by:
- The Focus skill
- Equipment bonuses (capped at +24)

### Mana

Fuels all spellcasting. Boosted by:
- The Meditation skill
- Intelligence
- Equipment bonuses (capped at +18)

## Resistances

Every character has five resistance types that reduce incoming damage. The max resistance cap is **70%** per category.

- **Physical** — reduces damage from attacks and environmental hazards
- **Fire** — reduces damage from fire-based spells and effects
- **Cold** — reduces damage from ice-based spells and effects
- **Poison** — reduces damage from poison-based attacks
- **Energy** — reduces damage from energy-based spells and effects

Resistances are gained through equipment, spells, and potions.

## Related Pages

- [Attributes](attributes.md) — this page
- [Combat](../combat/index.md) — combat overview
- [Death](death.md) — stat loss on death
