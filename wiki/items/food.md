# Food

Food items restore Hunger and Thirst, which are tracked separately on a 0–20 scale. Both must be above 4 to benefit from campfire rest and bedroll healing. Each item of food restores Hunger by its **FillFactor** value; each beverage restores **+5 Thirst**.

Eating any food also has a secondary benefit: it heals HP equal to your **Tasting** skill value (capped at your missing HP), and gives a chance equal to your Tasting skill to **cure poison** (`Tasting >= Random(1–100)`). Drinking beverages similarly restores Stamina by your Tasting skill.

## Hunger & Thirst System

| Property | Details |
|----------|---------|
| Hunger scale | 0 (starving) to 20 (stuffed) |
| Thirst scale | 0 (parched) to 20 (quenched) |
| Rest healing requirement | Both Hunger and Thirst must be > 4 |
| Eating effect | `Hunger += FillFactor` (capped at 20) |
| Drinking effect | `Thirst += 5` (capped at 20) |
| Bonus (Tasting skill) | Eating heals HP; drinking restores Stamina — both equal to your Tasting skill value |

## Beverages

All beverages restore **+5 Thirst** per drink. Beverage bottles hold up to 5 servings.

| Beverage Type | Container Types | Notes |
|--------------|-----------------|-------|
| Ale | Bottle (2.0 wt), Pitcher, Barrel keg | Ale also raises Blood Alcohol Content (BAC) |
| Cider | Bottle, Pitcher | |
| Liquor | Bottle, Pitcher | Raises BAC |
| Milk | Bottle, Pitcher | |
| Wine | Bottle, Glass, Pitcher | Raises BAC slightly |
| Water | Bottle, Pitcher, Barrel, Jug | Can also fill from water tiles |

> **Note**: Ale, wine, and liquor raise BAC (Blood Alcohol Content). High BAC causes wobbly movement and eventually vomiting.

## Fruits & Vegetables

All single fruits/vegetables weigh **1.0 stone** unless noted.

| Item | FillFactor | Notes |
|------|-----------|-------|
| Apple | 1 | Common, found on trees |
| Banana / Bananas | 1 | |
| Cantaloupe | 1 | |
| Coconut | 1 | |
| Open Coconut | 1 | |
| Split Coconut | 1 | |
| Dates | 1 | |
| Grapes | 1 | |
| HoneydewMelon | 1 | |
| GreenGourd | 1 | |
| YellowGourd | 1 | |
| Lemon / Lemons | 1 | |
| Lime / Limes | 1 | |
| Peach | 1 | |
| Pear | 1 | |
| Squash | 1 | |
| Watermelon | 5 | Weight: 5.0 |
| Small Watermelon | 5 | Weight: 5.0 |
| Fruit Basket | 5 | Weight: 2.0; returns a Basket container on eat |
| Cabbage | 1 | |
| Carrot | 1 | |
| Ear of Corn | 1 | |
| Lettuce | 1 | |
| Onion | 1 | |
| Pumpkin (small) | 8 | Standard pumpkin |
| Small Pumpkin | 8 | |
| Large Pumpkin | 10 | Weight: 10.0 |
| Tall Pumpkin | 10 | Weight: 10.0 |
| Green Pumpkin | 10 | Weight: 10.0 |
| Giant Pumpkin | 20 | Weight: 100.0; fills hunger completely |
| Turnip | 1 | |

## Baked Goods & Cooked Foods

| Item | FillFactor | Weight | Cookable? |
|------|-----------|--------|-----------|
| Bacon | 1 | 1.0 | No (raw already) |
| Slab of Bacon | 3 | 1.0 | No |
| Beef Jerky | 3 | 1.0 | No |
| Bread Loaf | 3 | 1.0 | Cooked |
| French Bread | 3 | 2.0 | Cooked |
| Muffins | 4 | 1.0 | Cooked |
| Cookies | 4 | 1.0 | Cooked |
| Cake | 10 | 1.0 | Cooked; not stackable |
| Cheese Slice | 1 | 0.1 | No |
| Cheese Wedge | 3 | 0.1 | No |
| Cheese Wheel | 3 | 0.1 | No |
| Cheese Pizza | 6 | 1.0 | Cooked; not stackable |
| Sausage Pizza | 6 | 1.0 | Cooked; not stackable |
| Fried Eggs | 4 | 1.0 | Cooked |
| Sausage | 4 | 1.0 | Cooked |
| Chicken Leg | 4 | 1.0 | Cooked |
| Cooked Bird | 5 | 1.0 | Cooked |
| Fish Steak | 3 | 0.1 | Cooked |
| Ham | 5 | 1.0 | Cooked |
| Lamb Leg | 5 | 2.0 | Cooked |
| Ribs | 5 | 1.0 | Cooked |
| Roast Pig | 20 | 45.0 | Cooked; fills hunger completely |
| Apple Pie | 5 | 1.0 | Cooked; not stackable |
| Fruit Pie | 5 | 1.0 | Cooked; not stackable |
| Meat Pie | 5 | 1.0 | Cooked; not stackable |
| Peach Cobbler | 5 | 1.0 | Cooked; not stackable |
| Pumpkin Pie | 5 | 1.0 | Cooked; not stackable |
| Quiche | 5 | 1.0 | Cooked |

## Special / Exotic Foods

| Item | FillFactor | Weight | Notes |
|------|-----------|--------|-------|
| Toad Stool | 1 | 1.0 | Found in forests |
| Potato | 2 | 1.0 | |
| Acorn | 1 | 1.0 | Found in forests |
| Imp Berry | 1 | 1.0 | |
| Cubed Fruit | 1 | 1.0 | Sci-Fi region substitution for fruits |
| Cubed Grain | 3 | 1.0 | Sci-Fi region substitution for grains |
| Cubed Meat | 3 | 1.0 | Sci-Fi region substitution for meats |
| Fresh Brain | — | — | For undead/brain-eating races only |
| Tasty Heart | — | — | Special effect food |
| Blood Drink | — | — | For blood-drinking races only |

## Farming

Players can grow crops using farmable plants in player housing garden plots.

| Crop Plant | Produces |
|-----------|----------|
| Farmable Cabbage | Cabbage |
| Farmable Carrot | Carrot |
| Farmable Corn | Ear of Corn |
| Farmable Lettuce | Lettuce |
| Farmable Onion | Onion |
| Farmable Pumpkin | Pumpkin |
| Farmable Tomato | Tomato |
| Farmable Turnip | Turnip |
| Farmable Watermelon | Watermelon |
| Farmable Wheat | Wheat (for Cooking) |
| Farmable Cotton | Cotton (for Tailoring) |
| Farmable Flax | Flax (for Tailoring) |

## Cooking

The **Cooking** skill lets you prepare raw ingredients at a heat source (campfire, oven, firepit, fire field, heating stand). Cooking produces the cooked versions in the tables above. Higher Cooking skill unlocks more complex recipes.

Heat sources recognized by the cooking system:
- Campfire (tile IDs 0xDE3–0xDE9)
- Sandstone oven/fireplace (0x461–0x48E)
- Stone oven/fireplace (0x92B–0x96C)
- Firepit variants (0xFAC, 0x576A–0x5775)

## Cross-links

- [Cooking](../../crafting/) — cooking skill and recipes
- [Tasting](../../skills/) — skill that provides healing/stamina/cure bonus when eating
- [Camping](../../skills/) — rest-based healing that requires hunger > 4
