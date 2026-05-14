# Poisoning

Poisoning lets you apply poison from poison potions onto weapons, food, and beverages.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Dexterity |
| Usage | Active (targeted) |
| Cooldown | 5 seconds |
| NpcGuild | Assassins Guild |
| Skill Page | 40 (in `/skills` command) |

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

### Poison Potion Skill Ranges

| Poison Potion | Min Skill | Max Skill | Resulting Poison |
|---|---|---|---|
| Lesser | 0 | 40 | Lesser |
| Regular | 20 | 60 | Regular |
| Greater | 40 | 80 | Greater |
| Deadly | 60 | 100 | Deadly |
| Lethal | 80 | 125 | Lethal |

## Related Systems

### Combat & Weapons
- `BaseWeapon.cs:1861` - Regular attacks use `CheckSkill(Poisoning, 0, 125)` in Classic Poisoning mode to determine if poison is applied on hit.
- `BaseWeapon.cs:1834` - Poison level on a weapon is capped by `Poisoning.Fixed / 200` (e.g., 200 → max level 1/Regular, 400 → max level 2/Greater, 600 → max level 3/Deadly, 800 → max level 4/Lethal).
- `InfectiousStrike.cs:57` - If `Poisoning.Value > random(150)`, the strike is "perfect" and does **not** consume a poison charge.
- `InfectiousStrike.cs:63` - Maximum poison level delivered is capped at `Poisoning.Fixed / 200`.
- `InfectiousStrike.cs:67` - If `Poisoning.Value / 100 > random`, the poison level is **upgraded by +1** on hit (e.g., Regular → Greater).
- `ShadowInfectiousStrike.cs:47` - Same perfect-strike check as Infectious Strike (no charge consumed).
- `ShadowInfectiousStrike.cs:52` - Same poison level cap as Infectious Strike.
- `ShadowInfectiousStrike.cs:55` - Same poison upgrade mechanic. Requires **Stealth >= 80** to function without poison on weapon.

### Magic Systems
- `Magery Poison.cs:57` - 3rd circle Poison spell: poison level is determined by `Magery + Poisoning` combined total. Level 0 (Lesser) for <100, Level 1 (Regular) for 100-150, Level 2 (Greater) for 150-200, Level 3 (Deadly) for 200-250, Level 4 (Lethal) for 250+. Only works within 2 tiles of target.
- `Magery PoisonField.cs:165` - 5th circle Poison Field: same formula as Poison spell (`Magery + Poisoning` total determines poison level). Targets walking through the field.
- `Necromancy PoisonStrike.cs:55` - Poison Strike spell damage receives a bonus of `Poisoning.Value / 4` added to the base damage calculation.
- `Bard PoisonCarolSong.cs` - Beneficial song (50 Musicianship required) that **increases poison resistance** for nearby allies. Duration = `0.24 * Musicianship + 30` seconds.
- `Bard PoisonThrenodySong.cs` - Harmful song (70 Musicianship required) that **decreases poison resistance** on a target. Amount = `Musicianship / 16`. Doubled duration and amount if instrument's Slayer matches the target.
- `Jedi SoothingTouch.cs:65` - Can **cure poison** from a target. Chance = `((Psychology - 30) / 50) - (Poison.Level * 0.1)`. Requires Psychology >= 60 and Anatomy (Jedi Damage/2) >= 60.
- `Mystic GentleTouch.cs:50` - **Cannot** target poisoned or mortally wounded creatures.
- `Mystic PurityOfBody.cs:34` - Can **cure poison** from the caster.
- `OmniAI Magery.cs:87` - AI mages have a **25% chance** to cast Poison spell on combatants who are not already poisoned.
- `ReactiveArmor.cs (Magery)` - Grants -5 poison resistance as a side effect.
- `PsychicAura.cs (Jedi)` - Grants -5 poison resistance as a side effect.

### Items
- `PoisonedGlasses.cs` - Elven Glasses variant with **+30 poison resistance**, +10 all other resistances, +3 Stam, +4 Stam Regen.
- `ItemSales.cs:137,285,440,502,558` - Poison resistance bonus on armor, spellbooks, instruments, trinkets, and clothing adds to sale price (`PoisonBonus * 2` or `Resistances.Poison * 2`).

### NPC Systems
- `Behavior.cs:6267` - Poisoning is listed in NPC skill assignment tables (general skill pool).
- `SkillCheck.cs:361` - Poisoning is a valid gain skill for **Assassins Guild** NPCs (alongside Fencing, Hiding, Stealth).
- `CharacterCreation.cs:334` - Poisoning is available as a selectable starting skill during character creation.
- `Players.cs:264` - Poisoning is displayed as skill page 40 in the `/skills` character sheet view.

### Related Skills
- [Tasting](tasting.md) - Detects poison in food and drink.
- [Weapon Abilities](weapon-abilities.md) - Infectious Strike and Shadow Infectious Strike apply weapon poison on hit.
- [Stealth](stealth.md) - Shadow Infectious Strike requires Stealth >= 80 to use without poison on weapon.
- [Magery](../magic/magery.md) - Poison and Poison Field spells scale with Poisoning skill.
- [Necromancy](../magic/necromancy.md) - Poison Strike spell damage benefits from Poisoning.
- [Bardic Music](../magic/bard.md) - Poison Carol and Poison Threnody songs manipulate poison resistance.
- [Jedi](../magic/jedi.md) - Soothing Touch can cure poison.
- [Assassins Guild](../systems/npc-guilds.md) - Poisoning is a core Assassins Guild skill.
