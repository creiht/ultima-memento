# Dragon Egg

Dragon Eggs are rare special items that can be hatched into bonded dragon or wyrm pets through a multi-step quest process.

## Properties

| Property | Value |
|----------|-------|
| Weight | 3.0 stones |
| Stackable | No |
| Light | Circle225 (glows) |

## Drakkhen Crystals

Related items are **Drakkhen Crystals** (red and black variants). These are simpler: pay 50,000 gold, give the crystal to a local druid NPC, and receive a bonded DrakkhenRed or DrakkhenBlack. Drakkhen are rideable but weaker than full dragons. Weight: 4.0 stones.

## How Dragon Egg Hatching Works

The Dragon Egg requires the following materials before it can be taken to an animal trainer:

| Required Material | Description |
|-------------------|-------------|
| Elixir of the Flame (Potion A) | Alchemical fire potion |
| Potion of the Earth (Potion B) | Alchemical earth potion |
| Mixture of the Sea (Potion C) | Alchemical water potion |
| Oil of the Winds (Potion D) | Alchemical air potion |
| Gold | Amount set when egg spawns (shown in egg GUMP as "X/Y gold") |

### Steps

1. **Initialize the egg**: Double-click it while standing in the **Savaged Empire facet** at coordinates roughly X 5296–5318, Y 664–686 (Lodor map). This sets the weight from >2.0 to 1.0, enabling the GUMP.
2. **Read the GUMP**: Double-clicking an initialized egg (Weight < 1.5) shows the required gold amount, the name of the animal trainer city, and a rumor hinting where to find the next missing potion.
3. **Collect the four potions**: The rumor updates as each potion is found. Potions are dropped onto the egg to register them.
4. **Drop gold**: Drop gold coins directly onto the egg until the required amount is met. Excess gold is returned.
5. **Take to animal trainer**: Bring the fully loaded egg (all 4 potions + gold) to the specific animal expert indicated in the egg GUMP.
6. **Hatch**: The animal expert hatches the egg. If you have Veterinary skill, up to 50% of the gold is refunded (`GoldReturn = NeedGold × (VetSkill × 0.005)`).

### Resulting Pet

- The egg hatches into a bonded **RidingDragon** named "a dragon" or "a wyrm" depending on the dragon body type (`DragonBody` field).
  - If the dragon body is 59, the pet is a "wyrm" and costs **3 follower slots**.
  - Other body types are standard "dragon" and cost **2 follower slots**.
- The dragon is given to you pre-bonded with `MinTameSkill = 29.1` (accessible to all players).
- You can use the Druidism skill on the pet to learn about its food preferences.

## How to Obtain

Dragon Eggs are found as rare loot in dragon lairs and as drops from powerful dragon creatures. They spawn pre-initialized with a random animal trainer location and a random dungeon piece location.

## Related Items

- **Drakkhen Crystal (Red / Black)** — simpler variant requiring only 50,000 gold and a druid NPC; produces a DrakkhenRed or DrakkhenBlack pet (2 follower slots)
- **Dragon Orb Statue** — decorative dragon-themed orb
- **Dragon Pedestal Statue** — decorative dragon statue on a pedestal
- **Dracolich Skull** — decorative undead dragon skull

## Cross-links

- [Special Items](../special.md) — broader special items list
- [Taming](../../skills/) — controlling pets and follower slots
