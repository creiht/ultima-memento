# Champion Spawns

Champion spawns are large-scale PvE encounters where players fight through escalating waves of increasingly powerful creatures, culminating in a boss fight against a **Champion**.

## How They Work

1. **Activation**: A champion spawn is activated at its altar location. The platform glows when active.
2. **Wave progression**: The spawn has **16 levels** (tracked by red skulls around the altar). Each level requires killing a set number of creatures to advance. White skulls show progress within the current level (at 20 % increments).
3. **Four tiers of creatures**: Creatures spawn in four tiers of increasing difficulty:
   - **Level 1–4**: Tier 1 (weakest creatures)
   - **Level 5–8**: Tier 2
   - **Level 9–12**: Tier 3
   - **Level 13–16**: Tier 4 (strongest creatures before the boss)
4. **Atmospheric messages** appear as waves progress:
   - Level 4: *"The air grows heavy with an unnatural stillness..."*
   - Level 8: *"Thick clouds gather in the sky..."*
   - Level 12: *"The very ground trembles beneath your feet..."*
   - Level 15: *"The boundaries between worlds grow thin..."*
5. **Champion boss**: After level 16, the champion itself spawns with the message *"Reality fractures as [name] awakens!"*
6. **Timer**: Each level has a 10-minute expiration timer. If players don't make enough progress, the spawn can lose a level.

## Champion Types

| Type | Champion Boss | Tier 1 | Tier 2 | Tier 3 | Tier 4 |
|------|--------------|--------|--------|--------|--------|
| **Abyss** | Semidar | Greater Mongbat, Imp | Gargoyle, Harpy | Fire Gargoyle, Stone Gargoyle | Daemon, Succubus |
| **Arachnid** | Mephitis | Scorpion, Giant Spider | Terathan Drone, Terathan Warrior | Dread Spider, Terathan Matriarch | Poison Elemental, Terathan Avenger |
| **Cold Blood** | Rikktor | Lizardman, Snake | Lava Lizard, Ophidian Warrior | Drake, Ophidian Archmage | Dragon, Ophidian Knight |
| **Forest Lord** | Lord Oaks | Pixie, Shadow Wisp | Kirin, Wisp | Centaur, Unicorn | Ethereal Warrior, Serpentine Dragon |
| **Vermin Horde** | Barracoon | Giant Rat, Slime | Dire Wolf, Ratman | Hell Hound, Ratman Mage | Ratman Archer, Silver Serpent |
| **Unholy Terror** | Neira | Ghoul, Shade, Spectre, Wraith | Bone Magi, Mummy, Skeletal Mage | Bone Knight, Lich, Skeletal Knight | Lich Lord, Rotting Corpse |

## Rewards

Rewards scale with the spawn's **size** and **difficulty** settings. See [Champion Rewards](loot-tables/champion-rewards.md) for full formulas.

- **Gold**: `25 + 10×difficulty + 5×size` % chance, cap 100%. Scatters in a 12-tile radius around the boss.
- **Boss item**: 100% drop chance. A random magic item enchanted at maximum level (500), labeled *Belonged to: [BossName]*.
- **Artifact**: `10×difficulty + 5×size` % chance; from [Artifact pool](loot-tables/artifact-pools.md#artifacts).
- **Power Scrolls**: `1 + difficulty + size÷3` scrolls distributed to participants (levels 5/10/15/20/25 at 35/30/20/10/5%).
- **Treasure Chest**: `20×difficulty + 10×size` % chance; a level-10 chest ([TMegaRich tier](loot-tables/chest-containers.md)).
- **Boss body loot**: [UltraRich](loot-tables/monster-packs.md#ultrarich) ×3 (varies by boss — check individual boss pages).
- **Hoard Minion Familiar**: 100% guaranteed drop.

## Useful Slayer Weapons

Each champion type is vulnerable to specific slayer properties:

| Type | Effective Slayers |
|------|-------------------|
| Abyss | Exorcism, Gargoyle's Foe, Daemon Dismissal, Avian Hunter, Flame Dousing, Blood Drinking |
| Arachnid | Arachnid Doom, Spider's Death, Terathan, Scorpion's Bane, Elemental Ban/Health |
| Cold Blood | Dragon Slaying, Reptilian Death, Ophidian, Lizardman Slaughter, Snake's Bane |
| Forest Lord | Fey, Animal Hunter, Dragon Slaying, Reptilian Death |
| Vermin Horde | Animal Hunter, Repond, Slimy Scourge, Reptilian Death, Snake's Bane, Wizard Slayer |
| Unholy Terror | Silver, Wizard Slayer |

## Tips

- The spawn area darkens as levels increase — bring a light source.
- Creatures spawned by a champion are **untameable** and temporary.
- You must be in the champion spawn region at the time the boss dies to be eligible for artifact rewards.
- Double-click the **Idol of the Champion** at the spawn altar to view spawn status.
