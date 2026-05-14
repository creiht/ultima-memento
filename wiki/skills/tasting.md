# Tasting

Tasting (Taste Identification) lets you detect poison in food and beverages, appraise unidentified items and relics, and enhance the effectiveness of consumed foods, elixirs, and mixtures.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Intelligence |
| Usage | Active (targeted) |
| Range | 2 tiles |
| Skill Check | 0 - 125 (poison detection), -5 to 125 (item ID) |
| Power Scroll | Yes ([PowerScroll.cs](file:///home/cthier/projects/ultima-memento/World/Source/Scripts/Items/Books/PowerScrolls/PowerScroll.cs#L45)) |

## How It Works

### Food and Beverages — Poison Detection

Target a piece of food or a drink to check for poison. On success, you learn the **poison level**:

| Poison Level | Message |
|---|---|
| Lesser | "It appears to have a slight taste of poison" |
| Regular | "It appears to have a somewhat bitter taste of poison" |
| Greater | "It appears to have a bitter taste of poison" |
| Deadly | "It appears to have a strong taste of poison" |
| Lethal | "It appears to have a very strong taste of poison" |
| None | "This food/liquid looks safe to eat/drink" |

**Warning:** On a **failed** check against poisoned food, you accidentally **eat or drink it**, consuming the poison!

> Source: `Tasting.cs:49` (Food), `Tasting.cs:82` (BaseBeverage)

### Item Identification

When targeting any other item, the Tasting skill functions as an item identification ability via the `RelicFunctions.IDItem` system. Items marked with `NotIDSkill == IDSkill.Tasting` require Tasting to identify, just like Arms Lore and Mercantile identify other item types.

- Player attempts: `CheckTargetSkill(Tasting, item, -5, 125)` — `RelicFunctions.cs:105`
- Vendor attempts: guaranteed identification if item is vendible — `RelicFunctions.cs:98-102`
- Correct skill check: targeting a Tasting-marked item with Arms Lore or Mercantile fails — `RelicFunctions.cs:67-71`

### Mobiles

Targeting a creature or player: "You feel that such an action would be inappropriate."

## What Tasting Affects

### Food & Consumption

| Effect | File:Line | Details |
|---|---|---|
| HP healing from food | `Food.cs:193` | Eating food heals `(int)Tasting.Value` HP (capped at missing hits) |
| Poison cure from food | `Food.cs:207` | Eating food cures poison if `Tasting >= Random(1,100)` |
| HP healing from special food | `TastyHeart.cs:89` | Same healing formula as regular food |
| HP healing from baked bread | `BakedBread.cs:66` | Same healing formula as regular food |
| HP healing from magic fish | `MagicFish.cs:62` | Eating magic fish heals `(int)Tasting.Value` HP + poison cure chance `MagicFish.cs:76` |
| Liquid bonus | `BaseLiquid.cs:36` | Liquid effects boosted by `Tasting/20` (capped at +6 at 125 skill) |

### Elixirs & Mixtures

| Effect | File:Line | Formula |
|---|---|---|
| Elixir duration | `BaseElixir.cs:45` | `TotalTime = (time + enhancePotions/2 + Cooking/2 + Tasting) / 120` — Tasting contributes up to **+1 minute** at 125 skill |
| Elixir buff value | `BaseElixir.cs:52` | `TotalBuff = default + enhancePotions/8 + Cooking/5 + Tasting/5` — Tasting contributes up to **+20** buff at 125 skill |
| Mixture duration | `BaseMixture.cs:165` | `time + enhancePotions/2 + Cooking/2 + Tasting/2` — Tasting contributes up to **+62** seconds at 125 skill |
| Mixture strength | `BaseMixture.cs:175` | `default + enhancePotions/5 + Cooking/4 + Tasting/3` — Tasting contributes up to **+41** strength at 125 skill |
| Mixture skill bonus | `BaseMixture.cs:185` | `40 + enhancePotions/2 + Cooking/2 + Tasting/2` — Tasting contributes up to **+62** skill bonus at 125 skill |
| Mixture damage | `BaseMixture.cs:195` | `1 + enhancePotions/40 + Cooking/25 + Tasting/15` — Tasting contributes up to **+8** damage at 125 skill |
| Bonus alchemic slime | `BaseMixture.cs:136` | Extra slime summon if `Cooking >= Random(1,200)` **or** `Tasting >= Random(1,200)` — yields 2 slimes instead of 1 |
| Monster splatter poison potency | `MonsterSplatter.cs:259` | Poison tier bonus includes `Tasting/33` (up to +3) alongside Poisoning/50 and Alchemy/33 |

### Loot & Drops

| Effect | File:Line | Details |
|---|---|---|
| Potion tier upgrade from slimes | `LootPack.cs:796-804` | At 30+ Tasting, chance to upgrade `LesserHealPotion → HealPotion → GreaterHealPotion` based on skill value vs random roll |
| Guaranteed unidentified item drops | `NotIdentified.cs:297-342` | Auto-delete system uses Tasting skill breakpoints alongside Arms Lore and Mercantile to guarantee items drop unidentified rather than being deleted |

### Research System

| Effect | File:Line | Details |
|---|---|---|
| Octopus ink bonus | `ResearchFunctions.cs:582` | Chance to gain extra octopus ink: `Tasting >= Random(25,150)` — alongside Alchemy and Cooking checks |

### Guild Benefits

| Guild | Bonus | File:Line |
|---|---|---|
| Merchants Guild Ring | +15 Tasting | `GuildRing.cs:63` |
| Alchemists Guild Ring | +15 Tasting | `GuildRing.cs:82` |
| Culinary Guild Ring | +20 Tasting | `GuildRing.cs:104` |

### NPC Merchants

These vendors have Tasting skill set and may offer related services:

| Merchant | Tasting Range | File:Line |
|---|---|---|
| Alchemist | 65.0 - 88.0 | `Alchemist.cs:28` |
| Alchemist Guildmaster | 65.0 - 88.0 | `AlchemistGuildmaster.cs:25` |
| Baker | 36.0 - 68.0 | `Baker.cs:29` |
| Cook | 75.0 - 98.0 | `Cook.cs:29` |
| Culinary Guildmaster | 75.0 - 98.0 | `CulinaryGuildmaster.cs:15` |
| Farmer | 36.0 - 68.0 | `Farmer.cs:28` |
| Glassblower | 85.0 - 100.0 | `Glassblower.cs:18` |
| Hair Stylist | 85.0 - 100.0 | `HairStylist.cs:17` |
| Custom Hair Stylist | 85.0 - 100.0 | `CustomHairstylist.cs:77` |
| Herbalist | 80.0 - 100.0 | `Herbalist.cs:29` |

### Relic System

Tasting is one of three identification skills (alongside Arms Lore and Mercantile) used to identify unidentified relics and items throughout the game. Dozens of relic item types use `NotIDSkill = IDSkill.Tasting`:

- `DDRelicAlchemy.cs:26` — Alchemy relics
- `DDRelicArmor.cs:107` — Armor relics
- `DDRelicBook.cs:43` — Book relics
- `DDRelicCloth.cs:78` — Cloth relics
- `DDRelicCoins.cs:121` — Coin relics
- `DDRelicDrink.cs:31` — Drink relics
- `DDRelicFur.cs:111` — Fur relics
- `DDRelicGem.cs:154` — Gem relics
- `DDRelicGrave.cs:167` — Grave relics
- `DDRelicInstrument.cs:93` — Instrument relics
- `DDRelicJewels.cs:79` — Jewels relics
- `DDRelicLeather.cs:95` — Leather relics
- `DDRelicLight.cs:83` — Light relics
- `DDRelicOrbs.cs:120` — Orb relics
- `DDRelicPainting.cs:365` — Painting relics
- `DDRelicReagent.cs:59` — Reagent relics
- `DDRelicRug.cs:515` — Rug relics
- `DDRelicScrolls.cs:57` — Scroll relics
- `DDRelicStatue.cs:174` — Statue relics
- `DDRelicTablet.cs:255` — Tablet relics
- `DDRelicVase.cs:78` — Vase relics
- `DDRelicWeapon.cs:100` — Weapon relics
- And more: `HighSeasRelic.cs:113`, `Clocks.cs:288`, `BaseRunicTool.cs:233`, `ObsidianElemental.cs:132`

### NPC Guild Checks

Tasting provides discount/identification benefits at:

- **Merchants Guild** — `SkillCheck.cs:286`
- **Alchemists Guild** — `SkillCheck.cs:322`
- **Culinarians Guild** — `SkillCheck.cs:355`

### Other Systems

| System | File:Line | Details |
|---|---|---|
| Skill fragment | `PlayerMobile.cs:791` | Moving Tasting to skill fragment costs 10 skill points |
| Behavior skill list | `Behavior.cs:6272` | Tasting is in the global list of skills checked by NPC behavior system |
| Character creation | `CharacterCreation.cs:370` | Tasting available during character skill allocation |
| Skill archive (avatar system) | `SkillArchive.cs:224` | Tasting tracked in avatar skill archive |
| Codex wisdom | `CodexWisdom.cs:435` | Tasting referenced in Codex of Wisdom learnable knowledge |
| Skill listing/display | `SkillListing.cs:204`, `SkillsGump.cs:538`, `Skills.cs:54` | Displayed in skill gumps and help text |

## How to Train

Test poisoned and unpoisoned food/beverages. The skill check is 0-125. You can also identify Tasting-marked items/relics to gain skill. Be careful with very strong poisons at low skill — failure means consuming them.

## Related Skills

- [Poisoning](poisoning.md) — Apply poison to items that Tasting detects.
- [Arms Lore](arms-lore.md) — Another item identification skill (for different item types).
- [Mercantile](mercantile.md) — Another item identification skill; also appraises item value.
- [Cooking](cooking.md) — Works alongside Tasting for elixir/mixture duration, buff values, and bonus alchemic slime chances.
- [Alchemy](alchemy.md) — Works alongside Tasting for monster splatter poison potency and research octopus ink.
- [Healing](healing.md) — Higher Tasting means more HP recovered from food consumption.
- [Seafaring](seafaring.md) — Magic fish consumption benefits from Tasting healing.
