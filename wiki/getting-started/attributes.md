# Attributes

Every character in Ultima Memento has three primary attributes (stats) and three secondary stats derived from them.

## Primary Attributes

| Attribute | Abbreviation | Effects |
|---|---|---|
| **Strength** | Str | Determines carry weight, hit points, and melee damage |
| **Dexterity** | Dex | Determines stamina, attack speed, and defensive ability |
| **Intelligence** | Int | Determines mana pool and magic effectiveness (mana regeneration, spell power) |

### Strength (Str)

Strength is the primary attribute for melee fighters and anyone who needs to carry heavy equipment.

- **Hit Points** — your maximum HP is derived from Strength, scaled by the server's level modifier (2.0×). A character with 100 Str has approximately 200 HP.
- **Carry Weight** — determines how much you can carry before becoming overloaded. If you exceed your weight limit by more than 4 stones, you begin losing stamina while moving. If stamina reaches zero, you cannot move.
- **Melee Damage** — higher Strength increases the damage dealt by melee weapons.

### Dexterity (Dex)

Dexterity governs speed and agility in combat.

- **Stamina** — your maximum stamina is derived from Dexterity, scaled by the level modifier (2.0×). A character with 100 Dex has approximately 200 stamina.
- **Attack Speed** — higher Dexterity increases your weapon swing speed.
- **Movement** — stamina is consumed while moving, especially when running or carrying heavy loads. Mounted characters consume stamina more slowly.

### Intelligence (Int)

Intelligence is the primary attribute for spellcasters.

- **Mana** — your maximum mana is derived from Intelligence, scaled by the level modifier (2.0×). A character with 100 Int has approximately 200 mana.
- **Mana Regeneration** — Int contributes to how fast your mana regenerates, together with the Meditation skill.
- **Magic Effectiveness** — Intelligence factors into spell damage and magical abilities.

## Stat Caps

| Setting | Value |
|---|---|
| Starting stat cap | 250 |
| Minimum per stat | 10 |
| Maximum per stat at creation | 60 |
| Starting stat points at creation | 90 |

The **stat cap** is the maximum sum of your Str + Dex + Int. New characters start with a stat cap of 250. Through the Avatar system, you can increase your stat cap by 1 per level (up to 150 levels of stat cap upgrades).

### Raising Stats

Stats increase passively through normal gameplay as you use abilities tied to each stat. The server checks for stat gains approximately every **7.5 minutes**, with a gain rate setting of 33.3 (on a scale of 10–50 where lower is faster).

- **Strength** gains from activities involving physical combat
- **Dexterity** gains from activities involving speed and agility
- **Intelligence** gains from activities involving magic and crafting

Stats cannot drop below 10 in any category.

## Secondary Stats

Secondary stats are derived from primary attributes and are not set directly.

| Secondary Stat | Derived From | Base Regen Rate |
|---|---|---|
| **Hit Points** | Strength × 2.0 | 1 point per ~11 seconds |
| **Stamina** | Dexterity × 2.0 | 1 point per ~7 seconds |
| **Mana** | Intelligence × 2.0 | 1 point per ~7 seconds |

### Hit Points (HP)

Hit points represent your health. When they reach zero, you die. HP regenerates slowly over time, and can be restored faster through:
- Healing skill (bandages)
- Healing spells (Magery, Chivalry, etc.)
- Potions (heal potions)
- Equipment with HP regeneration bonuses (capped at +18 for players)

### Stamina

Stamina is consumed by movement, combat actions, and carrying heavy loads. Low stamina slows your actions. Stamina regeneration is boosted by the **Focus** skill and equipment bonuses (capped at +24 for players).

### Mana

Mana fuels all spellcasting. Mana regeneration is boosted by the **Meditation** skill and **Intelligence**. Wearing non-mage armor slows or blocks mana regeneration from Meditation. Equipment mana regeneration bonuses are capped at +9 for players (after level scaling).

## Resistances

Characters have five resistance types that reduce incoming damage:

- Physical
- Fire
- Cold
- Poison
- Energy

The maximum resistance cap for players is **70%** in each category. Resistances are gained through equipment, spells, and other effects.

## See Also

- [Getting Started](README.md) — character creation and first steps
- [Death & Resurrection](death-and-resurrection.md) — what happens when stats are lost on death
- [Skills](../skills/README.md) — skill overview
