# Elementalism

Elementalism is a complete magic system parallel to Magery, built around four elements: **Air**, **Earth**, **Fire**, and **Water**. Each elementalist chooses one element to focus on, which changes spell visuals and damage types. Spells are organized into 8 Spheres (like Magery circles) and do not require reagents -- they consume **stamina** in addition to mana.

## Requirements

- **Skill:** [Elementalism](../skills/elementalism.md)
- **Spellbook:** Elemental Spellbook (appearance changes based on chosen element)
- **No Reagents:** Spells consume stamina instead
- **Armor Penalty:** Heavy armor increases fizzle chance; fabric/leather is best

## How to Learn

Obtain an Elemental Spellbook and elemental spell scrolls. Choose your element (Air, Earth, Fire, Water) -- this changes the appearance and effects of all spells. You can change your element, which updates all spellbooks you own.

## Element Damage Types

| Element | Primary Damage | Resistance Boosted by Armor Spell |
|---------|---------------|-----------------------------------|
| Air | Energy | Energy |
| Earth | Physical / Poison | Physical |
| Fire | Fire | Fire |
| Water | Cold | Cold |

## Mana & Stamina Cost by Sphere

| Sphere | Mana | Stamina | Min Skill |
|--------|------|---------|-----------|
| First | 5 | 5 | 0 |
| Second | 7 | 7 | 0 |
| Third | 10 | 10 | 9 |
| Fourth | 14 | 14 | 23 |
| Fifth | 19 | 19 | 38 |
| Sixth | 24 | 24 | 52 |
| Seventh | 40 | 40 | 66 |
| Eighth | 50 | 50 | 80 |

## Spell List

| Spell | Sphere | Command | Effect |
|-------|--------|---------|--------|
| Elemental Armor | 1st | `[EArmor` | Increases elemental resistance, reduces others |
| Elemental Bolt | 1st | `[EBolt` | Shoots an elemental bolt at a target |
| Elemental Mend | 1st | `[EMend` | Heals a small amount of hit points |
| Elemental Sanctuary | 1st | `[ESanctuary` | Teleports to the Lyceum for safety |
| Elemental Pain | 2nd | `[EPain` | Deals elemental damage at close range |
| Elemental Protection | 2nd | `[EProtection` | Prevents spell disruption; lowers resistances |
| Elemental Purge | 2nd | `[EPurge` | Attempts to cure poison |
| Elemental Steed | 2nd | `[ESteed` | Summons a ridable elemental mount |
| Elemental Call | 3rd | `[ECall` | Summons a lesser elemental servant |
| Elemental Force | 3rd | `[EForce` | Fires a powerful elemental projectile |
| Elemental Wall | 3rd | `[EWall` | Creates a temporary elemental wall |
| Elemental Warp | 3rd | `[EWarp` | Teleports the caster to a target location |
| Elemental Field | 4th | `[EField` | Creates a damaging elemental field |
| Elemental Restoration | 4th | `[ERestoration` | Heals a medium amount of hit points |
| Elemental Strike | 4th | `[EStrike` | Strikes the target with falling elemental damage |
| Elemental Void | 4th | `[EVoid` | Teleports to a marked rune with followers |
| Elemental Blast | 5th | `[EBlast` | Delayed elemental blast based on skill and intelligence |
| Elemental Echo | 5th | `[EEcho` | Reflects harmful wizard spells (requires gem) |
| Elemental Fiend | 5th | `[EFiend` | Summons an elemental creature (2 control slots) |
| Elemental Hold | 5th | `[EHold` | Immobilizes the target |
| Elemental Barrage | 6th | `[EBarrage` | Launches significant elemental damage at a target |
| Elemental Rune | 6th | `[ERune` | Marks a rune to the caster's current location |
| Elemental Storm | 6th | `[EStorm` | Area-effect elemental storm |
| Elemental Summon | 6th | `[ESummon` | Summons a powerful elemental servant |
| Elemental Devastation | 7th | `[EDevastation` | Area-effect damage to nearby enemies |
| Elemental Fall | 7th | `[EFall` | Area attack splitting damage among targets |
| Elemental Gate | 7th | `[EGate` | Opens a portal to a marked rune location |
| Elemental Havoc | 7th | `[EHavoc` | Massive single-target elemental damage |
| Elemental Apocalypse | 8th | `[EApocalypse` | Devastating area-effect attack |
| Elemental Lord | 8th | `[ELord` | Summons an Elemental Lord servant |
| Elemental Soul | 8th | `[ESoul` | Resurrects another or creates a resurrection item |
| Elemental Spirit | 8th | `[ESpirit` | Summons an elemental spirit (2 control slots) |

## Notes

- Lower Reagent Cost reduces **stamina** cost instead of reagent cost.
- The Elemental Echo spell requires a gem matching your element (amethyst for Air, emerald for Earth, ruby for Fire, sapphire for Water).
- You must focus on a single element; your spellbook appearance changes accordingly.
