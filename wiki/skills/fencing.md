# Fencing

Fencing is the hit skill for piercing weapons — spears, forks, kryss, sai, lajatang, tek-agi, kama, war cleaver, daggers, assassin spikes, and lances.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Dexterity |
| Usage | Passive (every fencing-weapon swing) |
| Cooldown | None |
| Anti-Macro | No |

## How It Works

### Weapons That Use Fencing

Weapons that explicitly declare `DefSkill = Fencing` include:

- Daggers (`Dagger`)
- Assassin Spikes (`AssassinSpike`)
- Kryss, Sai
- Tek-agi, Kama, Lajatang
- War Cleaver
- Spears and forks (`BaseSpear` family — Lance, etc.)

### Hit Chance

Hit chance is calculated identically to Swordsmanship — attacker's Fencing versus the defender's active defence skill. Tactics and Strength contribute damage; Dexterity affects swing speed.

### Best-Skill Pool

When a weapon has `UseBestSkill > 0`, the engine compares Swords, Bludgeoning, Fencing, and Fist-Fighting values at `BaseWeapon.GetUsedSkill` and selects whichever is highest. This means a player with 120 Fencing and 80 Swords will use Fencing even on a sword-type weapon.

- `BaseWeapon.cs:872-907` — `GetUsedSkill()` picks Fencing when it's the highest in the pool

### Weapon Ability Tier Gate

Fencing is one of the four skills checked when a player attempts to use a weapon ability on a `UseBestSkill` weapon. If any of Swords, Bludgeoning, Fencing, or Fist-Fighting meets the required tier, the ability is available.

- `WeaponAbility.cs:118` — ability check allows UseBestSkill fallback
- `WeaponAbility.cs:140-148` — `GetWeaponSkill()` selects highest qualifying skill

## Combat & Weapons

- `BaseWeapon.cs:879` — Fencing value read into `GetUsedSkill()` best-skill comparison
- `BaseWeapon.cs:887` — Fencing selected as active skill if highest
- `BaseWeapon.cs:3458` — Weapon label displays "skill required: fencing"

### Fencing Weapons

| Weapon | File | Ability 1 | Ability 2 |
|---|---|---|---|
| Dagger | `Knives/Dagger.cs:30` | — | — |
| Assassin Spike | `Knives/AssassinSpike.cs:27` | — | — |
| Kryss | `Swords/Kryss.cs:33` | — | — |
| Sai | `Oriental/Sai.cs:33` | — | — |
| Tek-agi | `Oriental/Tekagi.cs:33` | — | — |
| Kama | `Oriental/Kama.cs:33` | — | — |
| Lajatang | `Oriental/Lajatang.cs:33` | — | — |
| War Cleaver | `Knives/WarCleaver.cs:33` | — | — |
| Lance | `Swords/Lance.cs:33` | Dismount | Concussion Blow |

## Weapon Abilities

Fencing is included in the mana reduction calculation for weapon abilities. The total of Swords, Bludgeoning, Fencing, Marksmanship, Parrying, Lumberjacking, Stealth, Poisoning, Bushido, Fist-Fighting, and Ninjitsu determines mana cost:

- `WeaponAbility.cs:70-76` — If total >= 300, subtract 10 mana; if >= 200, subtract 5 mana
- `AbilityBook.cs:182-188` — Same mana calculation in legacy ability system
- `WeaponAbility.cs:71` — Fencing counted in skill total for mana reduction
- `WeaponArmorCalls.cs:99` — Fencing value collected for armor call display
- `AbilityBook.cs:59` — Ability Book gump lists Fencing as one of the contributing skills

## Crafting & Harvest

### Alchemy

The `ElixirFencing` potion temporarily boosts Fencing skill. Craftable via Alchemy:

- `DefAlchemy.cs:277` — Recipe: Elixir of Fencing, skill check 60.0–120.0
- Reagents: Bottle + Bloodmoss + Citrine
- `BasePotion.cs:64` — Listed in `PotionEffect` enum as `ElixirFencing`
- `Elixirs.cs:1571-1666` — `ElixirFencing` class: applies temporary skill bonus, tracked in a `Hashtable` keyed by mobile

### Merchant Sales

- `ItemSales.cs:3975` — Elixir of Fencing sold by alchemists for 70–95 gold

## Items

### Runic Tools / Runic Imbuing

Fencing appears as a possible bonus skill on runic-imbued items:

- `BaseRunicTool.cs:201` — Listed in `m_AllSkills` pool for general runic tool rolls
- `BaseRunicTool.cs:245` — Listed in `m_PossibleFightSkills` pool for runic armor (any armor type)
- `BaseRunicTool.cs:257` — Listed in `m_PossibleShieldSkills` pool for runic shields
- `BaseRunicTool.cs:264-268` — Listed in `m_PossibleWepFencingSkills` pool: `{ Fencing, Tactics }` for runic fencing weapons
- `BaseRunicTool.cs:384` — Skill bonus selection: if weapon skill is Fencing, possible bonuses are Fencing or Tactics

### Item Properties Display

- `ItemProperties.cs:625` — Skill requirement property displays "Skill: Fencing" when item checks this skill

## NPCs

Fencing is one of the most commonly assigned NPC skills across humanoid factions. Typical ranges:

| NPC Type | Fencing Range | File |
|---|---|---|
| Town Guards | 200.0 (fixed) | `TownGuards.cs:32` |
| Black Knights | 110.0 (fixed) | `BlackKnight.cs:50` |
| Bane mobs (Wantonness/Insanity/Anarchy) | 110.0 (fixed) | `BaneOf*.cs:50` |
| Gargoyles (Ancient/Cosmic) | 90.1–100.0 | `AncientGargoyle.cs:36`, `CosmicGargoyle.cs:49` |
| Alien Sentries | 90.1–100.0 | `Psionicist.cs:78`, `BombWorshipper.cs:79` |
| Galleon Guards | 90.1–100.0 | `SailorGuards.cs:74`, `SailorElfGuards.cs:68`, `SailorOrkGuards.cs:75` |
| Orc Uruks | 85.1–95.0 | `Urk.cs:162` |
| Galleon crew/merchants | 80.1–90.0 | Various `Galleons/*.cs` |
| Aliens (Savage) | 125.1–140.0 | `SavageAlien.cs:48` |
| Ghost Warriors/Pirates | 66.0–97.5 | `GhostWarrior.cs:96`, `GhostPirate.cs:82` |
| Savages / Natives | 60.0–102.5 | Various `Savages/*.cs` |
| Bandits / Brigands | 66.0–97.5 | `Bandit.cs:46`, `Brigand.cs:44` |
| Blood Assassins | 66.0–97.5 | `BloodAssassin.cs:40` |
| Monks (Human/Elf) | 50.0 (fixed) | `Monks.cs:51`, `ElfMonks.cs:50` |
| Berserkers | 50.0 (fixed) | `Berserker.cs:57` |
| Citizens | 60.0–82.5 | `Citizens.cs:125` |
| Rogues | 50.0 + bonus | `Rogue.cs:84`, `ElfRogue.cs:79` |
| Adventurers (citizens) | 28 + 7 * CitizenLevel | `Adventurers.cs:90` |
| Dead Knights | 50.0 (fixed) | `DeadKnight.cs:56` |
| Ork Warriors/Monks | 50.0 (fixed) | `OrkWarrior.cs:55`, `OrkMonks.cs:55` |
| Ork Rogues | 50.0 + bonus | `OrkRogue.cs:83` |

### Behavior System

Fencing is assigned to all Behavior-controlled creatures alongside Swords, Bludgeoning, and Fist-Fighting as a baseline combat skill:

- `Behavior.cs:3192` — Default Behavior: `50.0 + myBonus`
- `Behavior.cs:3399` — Advanced Behavior: `50.0 + myBonus`

### Merchant NPCs

| Merchant | Fencing Range | File |
|---|---|---|
| Weaponsmith | 45.0–68.0 | `Weaponsmith.cs:21` |
| Blacksmith | 60.0–83.0 | `Blacksmith.cs:21` |
| Thief | 55.0–78.0 | `Thief.cs:27` |
| Kung Fu Master | 64.0–80.0 | `KungFu.cs:27` |
| Keeper of Chivalry | 75.0–85.0 | `KeeperOfChivalry.cs:26` |
| Fighter | 45.0–68.0 | `Fighter.cs:19` |
| Iron Worker | 60.0–83.0 | `IronWorker.cs:22` |
| Warrior Guildmaster | 60.0–83.0 | `WarriorGuildmaster.cs:27` |
| Assassin Guildmaster | 75.0–98.0 | `AssassinGuildmaster.cs:26` |
| Thief Guildmaster | 75.0–98.0 | `ThiefGuildmaster.cs:26` |
| Ranger Guildmaster | 36.0–68.0 | `RangerGuildmaster.cs:29` |
| Garth (unique NPC) | 60.0–83.0 | `Garth.cs:27` |
| Trituns | 60.0–85.0 | `Tritun.cs:29`, `TritunMage.cs:36` |
| Reptaur | 66.0–97.5 | `Reptaur.cs:28` |
| Pirate crew variants | 66.0–97.5 | `PirateLand.cs:45`, `PirateCrew.cs:63`, `ElfPirateCrew.cs:60` |

## Mounts

The Warhorse mount requires a grandmaster-level combat skill to ride:

- `Ethereals.cs:128-138` — Warhorse check: any one of Tactics, Swords, Bludgeoning, Marksmanship, or Fencing must be >= 100

## Quests & Achievements

### Codex of Legendary Creatures

The Codex wisdom system awards Fencing skill knowledge as a quest reward:

- `CodexWisdom.cs:80` — Fencing maps to skill index 18 in the wisdom lookup
- `CodexWisdom.cs:403` — Reward: `SkillName.Fencing` assigned when player selects reward 18

## Avatar System

The Avatar/leveling system tracks Fencing separately:

- `SkillArchive.cs:71-72` — `Fencing` property reads/writes `SkillName.Fencing`

## Related Systems

### Guild Skill Bonuses

Fencing is a guild skill for two NpcGuilds, meaning players in those guilds receive accelerated skill gains:

- `SkillCheck.cs:253` — Warriors Guild: Fencing is a guild skill
- `SkillCheck.cs:359` — Assassins Guild: Fencing is a guild skill
- `SkillCheck.cs:129-141` — Guild skill gain factor: 1.0x–1.5x multiplier applied during `CheckSkill()`

### Stat Gain

Fencing is a Dexterity-associated skill. When a player gains Fencing and their Dex lock is up, there is a chance to also gain +1 RawDex (governed by `StatGain` setting):

- `SkillCheck.cs:442-443` — Dex gain triggered during skill gain for Fencing

### Poison Synergy

Many fencing weapons (kryss, lance, spears) are commonly used with [Poisoning](poisoning.md) because they deal piercing damage that applies poison coatings effectively.

## Starter Characters

### Fencing Starter Pack

Players choosing Fencing as their combat specialization receive:

- `CharacterCreation.cs:410-418` — Random selection of: Dagger, Kryss, Assassin Spike, or Sai

### Assassin Starter Profession

The Assassin starter profession begins with 30 skill in:

- `CharacterCreation.cs:936-942` — Ninjitsu (30), Hiding (30), Stealth (30), Fencing (30)

## How to Train

Attack with any fencing weapon. Fencing gains passively on every swing. Fencing does **not** use anti-macro code (no location/target verification), so it can be trained anywhere by attacking any target.
