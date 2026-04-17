# Potions

Potions are consumable items crafted via the **Alchemy** skill. They provide healing, stat boosts, offensive effects, and utility. Potions come in standard bottles; in sci-fi areas they appear as pill bottles.

> **Scaling note**: All HP/Mana/Stamina values shown are the **base** values from source. The actual amount restored may be multiplied by the server's `S_PlayerLevelMod` setting and further increased by the **Enhance Potions** attribute on equipped items.

## Healing Potions

10-second lockout between uses of the same type.

| Potion | HP Restored | Weight | Alchemy Skill |
|--------|-------------|--------|---------------|
| Lesser Heal Potion | 6–8 HP | 1.0 | Low |
| Heal Potion | 13–16 HP | 1.0 | Mid |
| Greater Heal Potion | 20–25 HP | 1.0 | High |

## Cure Potions

Remove poison from the user. Higher tiers cure more powerful poisons.

| Potion | Cures Poison Level | Weight |
|--------|-------------------|--------|
| Lesser Cure Potion | Lesser poison | 1.0 |
| Cure Potion | Regular–Greater | 1.0 |
| Greater Cure Potion | Deadly–Lethal | 1.0 |

## Mana Potions

10-second lockout (Lesser: 3 sec, Regular: 8 sec, Greater: 10 sec).

| Potion | Mana Restored | Lockout |
|--------|--------------|---------|
| Lesser Mana Potion | 6–8 Mana | 3 seconds |
| Mana Potion | 13–16 Mana | 8 seconds |
| Greater Mana Potion | 20–25 Mana | 10 seconds |

## Rejuvenate Potions

Restore HP, Mana, **and** Stamina simultaneously. Same lockout structure as Mana Potions.

| Potion | HP + Mana + Stamina Restored | Lockout |
|--------|------------------------------|---------|
| Lesser Rejuvenate Potion | 6–8 each | 3 seconds |
| Rejuvenate Potion | 13–16 each | 8 seconds |
| Greater Rejuvenate Potion | 20–25 each | 10 seconds |

## Refresh (Stamina) Potions

Restore a percentage of maximum Stamina.

| Potion | Stamina Restored | Notes |
|--------|-----------------|-------|
| Refresh Potion | 25% of max Stamina | |
| Total Refresh Potion | 100% of max Stamina | Fully restores Stamina |

## Stat Boost Potions

Duration: **2 minutes** for all stat boost potions.

| Potion | Stat Bonus | Duration | Notes |
|--------|-----------|----------|-------|
| Strength Potion | +8 STR | 2 min | |
| Greater Strength Potion | +15 STR | 2 min | |
| Agility Potion | +10 DEX | 2 min | |
| Greater Agility Potion | +20 DEX | 2 min | |
| Night Sight Potion | Night vision | Variable | Removes darkness penalty |

## Invisibility Potions

| Potion | Duration |
|--------|---------|
| Lesser Invisibility Potion | 1 minute |
| Invisibility Potion | 2 minutes |
| Greater Invisibility Potion | 3 minutes |

Invisibility breaks if you perform an action (attacking, casting, etc.).

## Poison Potions (Applied to Weapons)

These are used with the **Poisoning** skill to coat weapons.

| Potion | Poison Level |
|--------|-------------|
| Lesser Poison Potion | Level 1 (Lesser) |
| Poison Potion | Level 2 (Regular) |
| Greater Poison Potion | Level 3 (Greater) |
| Deadly Poison Potion | Level 4 (Deadly) |
| Lethal Poison Potion | Level 5 (Lethal) |

## Offensive Throwable Potions

Thrown at targets for area-of-effect damage. Equip a potion and double-click to arm, then throw at a location.

| Potion | Element | Notes |
|--------|---------|-------|
| Lesser Explosion Potion | Fire | Small AoE |
| Explosion Potion | Fire | Medium AoE |
| Greater Explosion Potion | Fire | Large AoE |
| Conflagration Potion | Fire | Fire AoE variant |
| Greater Conflagration Potion | Fire | Stronger fire AoE |
| Frostbite Potion | Cold | Cold AoE |
| Greater Frostbite Potion | Cold | Stronger cold AoE |
| Confusion Blast Potion | Special | Confusion field |
| Greater Confusion Blast Potion | Special | Stronger confusion |

## Special / Rare Potions

| Potion | Effect | How to Obtain |
|--------|--------|---------------|
| Auto-Res Potion | Automatically resurrects on death (one use) | Rare loot, special crafting |
| Bottle of Acid | Thrown acid damage | Alchemy crafting |
| Durability Potion | Restores item durability | Alchemy crafting |
| Gender Potion | Changes character gender | Rare loot |
| Holy Water | Damages undead; consecrates | Alchemy, temples |
| Invulnerability Potion | Temporary invulnerability | Very rare |
| Potion of Dexterity | Permanent +1 DEX (limited) | Very rare |
| Potion of Might | Permanent +1 STR (limited) | Very rare |
| Potion of Wisdom | Permanent +1 INT (limited) | Very rare |
| Repair Potion | Repairs equipment | Alchemy crafting |
| Resurrect Potion | Resurrects a dead player | Alchemy crafting |
| Super Potion | Powerful combined heal/restore | Very rare |
| Transmutation Potion | Transforms materials | Alchemy crafting |
| Monster Splatter | Made from monster parts | Advanced Alchemy |
| Necro Skin Potion | Undead skin transformation | Necromancy-related |

## Elixirs

Enhanced potions with longer-lasting or more powerful effects than standard potions.

## Mixtures & Alchemic Concoctions

Throwable items that create lasting effects on contact:

| Mixture | Effect |
|---------|--------|
| Alchemic Slime | Spawns a slime creature |
| Liquid Fire | Creates a fire damage pool |
| Liquid Goo | Leaves sticky slowing area |
| Liquid Ice | Cold damage pool |
| Liquid Pain | Direct damage on contact |
| Liquid Rot | Poison damage pool |
| Mixture Slime variants | Elemental slime variants (fire, ice, diseased, radiated) |

## Canopic Jars

Special containers used in advanced alchemy recipes:
- **Empty Canopic Jar** — collect special ingredients
- **Canopic Jar (filled)** — completed component for advanced recipes

## Crafting

Potions are crafted using the **Alchemy** skill at a heat source with the appropriate reagents. Higher skill unlocks more potent recipes. The **Venom Sack** (from venomous creatures) is used for poison potion crafting.

## Cross-links

- [Alchemy](../crafting/README.md) — crafting skill for potions
- [Poisoning](../skills/poisoning.md) — applying poisons to weapons
- [Healing](../skills/healing.md) — uses bandages rather than potions

## Sources — Loot Tables

Potions drop from [Low](../systems/loot-tables/utility-packs.md#lowpotions), [Med](../systems/loot-tables/utility-packs.md#medpotions), and [High](../systems/loot-tables/utility-packs.md#highpotions) Potion utility packs, included in every monster and treasure pack tier. See [Utility Packs](../systems/loot-tables/utility-packs.md#potions).
