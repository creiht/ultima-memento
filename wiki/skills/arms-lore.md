# Arms Lore

Arms Lore lets you identify and appraise weapons, armor, and other equipment, while also passively reducing durability loss on your gear.

## Overview

| Property | Value |
|---|---|
| **Primary Stat** | Intelligence |
| **Usage** | Active (targeted) + Passive |
| **Skill Type** | Knowledge |
| **Skill Check** | 0 - 125 |

## Description

Arms Lore is an Intelligence-based knowledge skill used to identify unidentified weapons, armor, and equipment. It also passively protects your equipped gear from durability loss during combat and enhances the quality of exceptional crafted items.

## How It Works

### Active Use - Item Identification

Target any unidentified item to reveal its properties, quality, and enchantments. Identification routes through the `RelicFunctions.IDItem()` system, which assigns item categories to their identifying skill:

- `NotIdentified.cs:170` - Metal/scales/skeletal/block armor sets `NotIDSkill = ArmsLore`
- `NotIdentified.cs:176` - Metal/scales/skeletal/block weapons set `NotIDSkill = ArmsLore`
- `NotIdentified.cs:182` - Leather/skin armor/weapons set `NotIDSkill = ArmsLore`
- `NotIdentified.cs:188` - Wooden ranged weapons set `NotIDSkill = ArmsLore`
- `NotIdentified.cs:194` - Wooden armor/weapons set `NotIDSkill = ArmsLore`
- `RelicFunctions.cs:31-32` - `IDItem()` routes to ArmsLore for weapon/armor relics

### Passive Use - Durability Protection

Arms Lore provides a passive chance to **avoid durability loss** on equipped items during combat. The check occurs in two stages when gear would take durability damage:

1. A 50/50 coin flip
2. A skill-vs-random(100) check

Both must succeed for durability loss to be avoided. At 5 skill or below, no protection is applied.

| Arms Lore Skill | Approximate Avoid Chance |
|---|---|
| Below 5 | 0% |
| 50 | ~25% (when triggered) |
| 100 | ~50% (when triggered) |

### Unidentified Item Preservation

Higher Arms Lore increases the number of **guaranteed unidentified items** that survive automatic container deletion:

- `NotIdentified.cs:268,302-307,324` - `DoAutoDelete()` checks skill against breakpoints in `MySettings.S_UnidentifiedItem_GuaranteedItemChecks` to determine how many ArmsLore-gated items survive deletion

## How to Train

Target weapons, armor, and other unidentified items to gain skill. Since identification uses the `RelicFunctions.IDItem` system, the difficulty scales with the item being examined.

## What It Affects

### Crafting & Exceptional Items

When crafting **exceptional** weapons or armor, Arms Lore increases the bonus stats granted:

- `BaseWeapon.cs:3565` - Exceptional weapons gain **+1% Damage Increase per 10 skill** in Arms Lore
- `BaseWeapon.cs:3566` - At **125 skill**, exceptional weapons receive an additional **+3% DI** (capped at 50 total bonus DI, ~15% total at max skill)
- `BaseArmor.cs:1588` - Exceptional armor gains **3 + ArmsLore/20 bonus resistance points** distributed across resistances
- `BaseWeapon.cs:3571`, `BaseArmor.cs:1590` - Both checks `CheckSkill(SkillName.ArmsLore, 0, 100)` during crafting

### Durability Protection

Arms Lore passively reduces equipment durability loss during combat:

- `ArmsLore.cs:47-59` - `AvoidDurabilityHit()` performs a 2-stage check: first a 50/50 coin flip, then `skill vs Random(100)`. Both must pass.
- `BaseWeapon.cs:1698,1710` - Called when a weapon would take durability damage from combat

### Disarm

- `Behavior.cs:10489` - NPCs can attempt disarm when **both FistFighting >= 80 AND ArmsLore >= 80**

### Runic Tools

- `BaseRunicTool.cs:188` - Arms Lore is a possible bonus skill rolled on runic tools

### Elixirs

- `DefAlchemy.cs:237` - **Elixir of Arms Lore** is a craftable potion (Alchemy 60-120, requires Butterfly Wings)
- `ItemSales.cs:3965` - Elixir of Arms Lore sells for 70 gold base price

### NPC Behavior

- `Behavior.cs:6246` - ArmsLore is included in the NPC skill selection pool for general behavior decisions

## Related Systems & Skills

### Synergies
- [Mercantile](mercantile.md): Identifies a different set of items (containers, misc. goods, decorative items); shares the same `RelicFunctions.IDItem()` system.
- [Tasting](tasting.md): Identifies another category of items (food/drink); also shares `RelicFunctions.IDItem()`.

### Prerequisites / Co-requisites
- [Fist-Fighting](fist-fighting.md): Both FistFighting and Arms Lore must be >= 80 for NPC disarm attempts.

## Notes
- Arms Lore is the only skill that provides a passive durability reduction bonus, extending equipment longevity.
- Failed identification attempts do not reveal any information about the item.
- Arms Lore and Mercantile share the same identification system but cover different item categories.
