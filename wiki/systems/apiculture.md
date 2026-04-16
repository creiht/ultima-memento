# Apiculture (Beekeeping)

Apiculture is the art of raising honey bees. Tend beehives to produce **honey** and **beeswax**, then use wax crafting to create candles, sculptures, paintings, and polish.

## Getting Started

1. Obtain a **beehive deed** (from a beekeeper vendor or crafting).
2. Place the hive in an area with **flowers** and **water** nearby (water troughs, barrels, or natural water sources).
3. The hive will begin developing automatically.

## Hive Development Stages

| Stage | Description |
|-------|-------------|
| **Colonizing** | Scouts survey the area for flowers and water |
| **Brooding** | Egg laying begins as the hive prepares for production |
| **Producing** | The mature hive produces honey and wax |

The hive progresses through 5 internal stages. Once it reaches Stage 5 (Producing), it begins generating resources.

## Hive Health

| Status | Meaning |
|--------|---------|
| **Thriving** | Extremely healthy — increased honey and wax output |
| **Healthy** | Normal production |
| **Sickly** | No longer producing resources |
| **Dying** | Bee population will begin to drop |

If health reaches zero during the producing stage, the population drops. If population hits zero, the hive becomes **empty** and must be redeeded with an axe.

## Resources: Flowers and Water

Bees need **flowers** and **water** within range to thrive. The search range is `population + 2 + agility potion bonus`.

- Too few flowers or water = sickly hive, no growth
- Too much water = higher disease chance
- Too many flowers = higher parasite chance

Resource levels are scaled relative to population: None, Very Low, Low, Normal, High, Very High.

## Bee Population

- Starts at 10,000 bees (displayed as "10k").
- Maximum: 100,000 bees (10 population units).
- Population grows when flowers and water are at Normal or higher and the hive is healthy.
- Larger populations produce more honey and wax but require proportionally more flowers and water.

## Products

| Product | Max Storage | Notes |
|---------|-------------|-------|
| **Honey** | 255 units | Primary product, harvested via the production gump |
| **Beeswax** | 255 units | Produced more slowly than honey; harvested with a hive tool |

### Wax Crafting

Raw beeswax must be **rendered** (purified) before use:
1. Scrape raw wax from the hive using a **hive tool**.
2. Place raw wax in a **small wax pot** near a heat source to melt it.
3. Remove impurities (slumgum) to get pure beeswax.
4. Use a **wax crafting pot** to make items.

Wax crafting products include:
- **Candles** (some can be dyed with dye tubs)
- **Wax sculptures** (can be dyed, some can depict a targeted character)
- **Encaustic paintings** (wax mixed with dyes on canvases from weavers)
- **Wax polish** (improves durability of armor, weapons, and musical instruments)

Some crafted items can be sold to beekeepers or art collectors for gold.

## Treating Your Hive

Apply **greater** potions to combat problems (lesser/normal potions are too weak):

| Potion | Effect |
|--------|--------|
| **Greater Poison** | Kills parasites and insects — careful, excess harms bees |
| **Greater Cure** | Cures disease; can neutralize excess poison |
| **Greater Heal** | Heals bee health |
| **Greater Strength** | Builds immunity to infestation and disease |
| **Greater Agility** | Bees work harder — increased honey/wax output and search range |

Each potion type can hold up to **2 doses** at a time. Potions can be applied from individual bottles or kegs.

## Growth Checks

Hive updates occur **once per day** during world save. The growth indicator in the upper right of the Apiculture gump shows:

| Symbol | Meaning |
|--------|---------|
| Red **!** | Not healthy |
| Yellow **!** | Low resources |
| Red **-** | Population decrease |
| Green **+** | Population growth |
| Blue **+** | Stage increase or resource production |

## Tips

- Older hives are more susceptible to infestation and disease.
- Place flowers (bought from herbalists or grown via gardening) near your hive if the area lacks natural ones.
- Use an axe on an empty hive to redeed it for relocation.
- A single hive can live indefinitely if well maintained.
