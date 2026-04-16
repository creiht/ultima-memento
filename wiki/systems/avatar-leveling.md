# Avatar Leveling System

The **Avatar** system is Ultima Memento's permadeath progression layer. When you play as an Avatar character, you earn **coins** by killing creatures and completing combat quests. Coins are banked on death, and you spend them in the **Avatar Shop** on permanent account-wide upgrades that carry across every new life.

## How Coins Work

- **Earning coins**: Every creature you kill drops loot whose value is converted to coins (copper = 1, silver = 2, gold = 10, xormite = 30, crystals = 50, gemstones/jewels = 20, gold nuggets = 10). You must deal at least 10 % of the creature's max HP to receive credit.
- **Group penalty**: If more than one player damaged the creature, coins earned are halved.
- **Combat quests**: Completing combat quests awards `quest_reward × 5` coins.
- **Banking**: While alive, coins accumulate as "Farmed" coins. When you die, farmed coins move into your **Saved** pool and can be spent in the shop. Lifetime totals are tracked.
- **Bonus coin rate**: You can purchase upgrades that increase your coin gain rate by 1 % per level (up to 100 levels / +100 %).

## Rival Faction

On character creation each Avatar is assigned a random **Rival Faction** — a slayer group that murdered your family. Killing creatures that belong to your rival faction grants a **50 % bonus** to coins earned. Once you accumulate 50,000 bonus coins from rival kills, the rivalry is "avenged."

| Slayer | Faction Name |
|--------|-------------|
| Silver | The Returned |
| Repond | The Oathbreakers |
| Reptilian Death | The Scaled Ones |
| Exorcism | The Dreadwings |
| Arachnid Doom | The Doom Weavers |
| Elemental Ban | The Riftborn |
| Wizard Slayer | The Spellreavers |
| Avian Hunter | The Skycleave Talons |
| Slimy Scourge | The Oozen Swarm |
| Animal Hunter | The Pack |
| Giant Killer | The Colossal |
| Golem Destruction | The Construct |
| Weed Ruin | The Briarblight |
| Neptune's Bane | The Tidebreakers |
| Fey | The Faeborn Circle |

## Avatar Shop

Open the Avatar Shop through your **Avatar Book** (given at character creation and kept in your backpack). The shop is divided into several categories:

### Ascensions (permanent unlocks)

| Upgrade | Description | Max |
|---------|-------------|-----|
| Persistent Storage Container | Safety deposit box in your bank that survives death | 1 (then upgradeable to 10 capacity) |
| Erudian Teachings | Permanently record your skill caps across lives | 1 |
| Jack of No Trades | Unlock the ability to restore **Primary** skills from your Skill Archive | 1 |
| Artisan's Mastery | Unlock the ability to restore **Secondary** skills from your Skill Archive | 1 |
| Crafter Lineage | Permanently record learned recipes | 1 |
| World Class Cartographer | Permanently record facet discoveries | 1 |
| Fast Seaman | Increase sailing speed | multiple levels |
| Power Overwhelming | Unlock the Temptations system | 1 |
| Primal Awakening | Unlock the Savage race tarot card (requires Cartographer) | 1 |
| Bestial Transformation | Unlock non-human monster races | 1 |
| Outlaw's Mark | Unlock Fugitive mode tarot card | 1 |
| Blessed Beginnings | Chance for templates to spawn as (Improved), giving +10 to each starting skill | up to 5 |

### Stat & Skill Upgrades

| Upgrade | Per Level | Max Levels |
|---------|-----------|------------|
| Skill Cap | +10 skill cap | 70 |
| Stat Cap | +1 stat cap | 150 |
| Erudian Knowledge | +5 to Skill Archive cap (starts at 30, max 125) | 19 |
| Coins Gain Rate | +1 % coin income | 100 |
| Skill Gain Rate | +5 % skill gain speed | 10 |

### Templates (free, reusable)

Templates reset your stats and skills to a predefined build. **Improved** templates (unlocked via Blessed Beginnings) add +10 to each starting skill.

| Template | Starting Stats |
|----------|---------------|
| The Brute | 60 STR / 10 DEX / 10 INT |
| The Acrobat | 10 STR / 60 DEX / 10 INT |
| The Scholar | 10 STR / 10 DEX / 60 INT |
| The Archer | Class preset |
| The Bard | Class preset |
| The Druid | Class preset |
| The Knight | Class preset |
| The Mage | Class preset |
| The Ninja | Class preset |
| The Warrior | Class preset |

### Skill Archive

Once you unlock **Jack of No Trades** or **Artisan's Mastery**, your highest-ever skill values are recorded. After death, you can instantly restore skills up to your recorded cap (limited by your Erudian Knowledge level).

### Items

The shop also sells basic supplies with coins: gold, ingots, fabric, bottles, tools, spellbooks, potions, reagents, boats, mounts, and more.

## Lifetime Statistics

Your Avatar Book tracks lifetime stats including:
- Total coins earned
- Total deaths
- Creature kills
- Enemy faction kills
- Combat quest completions
- Total game time played
