# Fencing

Fencing is the hit skill for piercing weapons — spears, forks, daggers, kryss, sai, and other thrusting/bladed weapons.

## Overview

| Property | Value |
|---|---|
| **Primary Stat** | Dexterity |
| **Usage** | Passive |
| **Skill Type** | Weapon |
| **Skill Check** | None |

## Description

Fencing governs hit chance and defense for weapons that declare `DefSkill = Fencing`, including daggers, kryss, sai, tek-agi, kama, lajatang, war cleavers, and spears/lances. Dexterity affects swing speed while Tactics and Strength contribute damage. At Grandmaster level the player title is "Fencer".

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

When a weapon has `UseBestSkill > 0`, the engine compares Swords, Bludgeoning, Fencing, and Fist-Fighting values at `BaseWeapon.GetUsedSkill` and selects whichever is highest. This means a player with 120 Fencing and 80 Swords will use Fencing even on a sword-type weapon [BaseWeapon.cs:872-907]. Fencing value is read into `GetUsedSkill()` best-skill comparison [BaseWeapon.cs:879] and selected as active skill if highest [BaseWeapon.cs:887]. The weapon label displays "skill required: fencing" [BaseWeapon.cs:3458].

### Weapon Ability Tier Gate

Fencing is one of the four skills checked when a player attempts to use a weapon ability on a `UseBestSkill` weapon. If any of Swords, Bludgeoning, Fencing, or Fist-Fighting meets the required tier, the ability is available [WeaponAbility.cs:118], [WeaponAbility.cs:140-148].

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

## How to Train

Attack with any fencing weapon. Fencing gains passively on every swing. Fencing does **not** use anti-macro code (no location/target verification), so it can be trained anywhere by attacking any target.

## What It Affects

### Combat & Weapons
- `[BaseWeapon.cs:879]` — Fencing value read into `GetUsedSkill()` best-skill comparison
- `[BaseWeapon.cs:887]` — Fencing selected as active skill if highest
- `[BaseWeapon.cs:3458]` — Weapon label displays "skill required: fencing"

### Weapon Abilities
- `[WeaponAbility.cs:70-76]` — If total skill >= 300, subtract 10 mana; if >= 200, subtract 5 mana
- `[AbilityBook.cs:182-188]` — Same mana calculation in legacy ability system
- `[WeaponAbility.cs:71]` — Fencing counted in skill total for mana reduction
- `[WeaponAbility.cs:118]` — ability check allows UseBestSkill fallback
- `[WeaponAbility.cs:140-148]` — `GetWeaponSkill()` selects highest qualifying skill
- `[WeaponArmorCalls.cs:99]` — Fencing value collected for armor call display
- `[AbilityBook.cs:59]` — Ability Book gump lists Fencing as one of the contributing skills

### Crafting & Harvest — Alchemy
- `[DefAlchemy.cs:277]` — Elixir of Fencing recipe: skill check 60.0–120.0, reagents: Bottle + Bloodmoss + Citrine
- `[BasePotion.cs:64]` — Listed in `PotionEffect` enum as `ElixirFencing`
- `[Elixirs.cs:1571-1666]` — `ElixirFencing` class: applies temporary skill bonus, tracked in a `Hashtable` keyed by mobile
- `[ItemSales.cs:3975]` — Elixir of Fencing sold by alchemists for 70–95 gold

### Runic Tools / Runic Imbuing
- `[BaseRunicTool.cs:201]` — Listed in `m_AllSkills` pool for general runic tool rolls
- `[BaseRunicTool.cs:245]` — Listed in `m_PossibleFightSkills` pool for runic armor (any armor type)
- `[BaseRunicTool.cs:257]` — Listed in `m_PossibleShieldSkills` pool for runic shields
- `[BaseRunicTool.cs:264-268]` — Listed in `m_PossibleWepFencingSkills` pool: `{ Fencing, Tactics }` for runic fencing weapons
- `[BaseRunicTool.cs:384]` — Skill bonus selection: if weapon skill is Fencing, possible bonuses are Fencing or Tactics

### Item Properties Display
- `[ItemProperties.cs:625]` — Skill requirement property displays "Skill: Fencing" when item checks this skill

### NPCs
Fencing is one of the most commonly assigned NPC skills across humanoid factions.

| NPC Type | Fencing Range | File |
|---|---|---|
| Town Guards | 200.0 (fixed) | `[TownGuards.cs:32]` |
| Black Knights | 110.0 (fixed) | `[BlackKnight.cs:50]` |
| Bane mobs (Wantonness/Insanity/Anarchy) | 110.0 (fixed) | `[BaneOf*.cs:50]` |
| Gargoyles (Ancient/Cosmic) | 90.1–100.0 | `[AncientGargoyle.cs:36]`, `[CosmicGargoyle.cs:49]` |
| Alien Sentries | 90.1–100.0 | `[Psionicist.cs:78]`, `[BombWorshipper.cs:79]` |
| Galleon Guards | 90.1–100.0 | `[SailorGuards.cs:74]`, `[SailorElfGuards.cs:68]`, `[SailorOrkGuards.cs:75]` |
| Orc Uruks | 85.1–95.0 | `[Urk.cs:162]` |
| Galleon crew/merchants | 80.1–90.0 | Various `Galleons/*.cs` |
| Aliens (Savage) | 125.1–140.0 | `[SavageAlien.cs:48]` |
| Ghost Warriors/Pirates | 66.0–97.5 | `[GhostWarrior.cs:96]`, `[GhostPirate.cs:82]` |
| Savages / Natives | 60.0–102.5 | Various `Savages/*.cs` |
| Bandits / Brigands | 66.0–97.5 | `[Bandit.cs:46]`, `[Brigand.cs:44]` |
| Blood Assassins | 66.0–97.5 | `[BloodAssassin.cs:40]` |
| Monks (Human/Elf) | 50.0 (fixed) | `[Monks.cs:51]`, `[ElfMonks.cs:50]` |
| Berserkers | 50.0 (fixed) | `[Berserker.cs:57]` |
| Citizens | 60.0–82.5 | `[Citizens.cs:125]` |
| Rogues | 50.0 + bonus | `[Rogue.cs:84]`, `[ElfRogue.cs:79]` |
| Adventurers (citizens) | 28 + 7 * CitizenLevel | `[Adventurers.cs:90]` |
| Dead Knights | 50.0 (fixed) | `[DeadKnight.cs:56]` |
| Ork Warriors/Monks | 50.0 (fixed) | `[OrkWarrior.cs:55]`, `[OrkMonks.cs:55]` |
| Ork Rogues | 50.0 + bonus | `[OrkRogue.cs:83]` |

#### Behavior System
- `[Behavior.cs:3192]` — Default Behavior: `50.0 + myBonus`
- `[Behavior.cs:3399]` — Advanced Behavior: `50.0 + myBonus`

#### Merchant NPCs
- `[Weaponsmith.cs:21]` — 45.0–68.0
- `[Blacksmith.cs:21]` — 60.0–83.0
- `[Thief.cs:27]` — 55.0–78.0
- `[KungFu.cs:27]` — 64.0–80.0
- `[KeeperOfChivalry.cs:26]` — 75.0–85.0
- `[Fighter.cs:19]` — 45.0–68.0
- `[IronWorker.cs:22]` — 60.0–83.0
- `[WarriorGuildmaster.cs:27]` — 60.0–83.0
- `[AssassinGuildmaster.cs:26]` — 75.0–98.0
- `[ThiefGuildmaster.cs:26]` — 75.0–98.0
- `[RangerGuildmaster.cs:29]` — 36.0–68.0
- `[Garth.cs:27]` — 60.0–83.0 (unique NPC)
- `[Tritun.cs:29]`, `[TritunMage.cs:36]` — Trituns: 60.0–85.0
- `[Reptaur.cs:28]` — Reptaur: 66.0–97.5
- `[PirateLand.cs:45]`, `[PirateCrew.cs:63]`, `[ElfPirateCrew.cs:60]` — Pirate crew variants: 66.0–97.5

### Mounts
- `[Ethereals.cs:128-138]` — Warhorse check: any one of Tactics, Swords, Bludgeoning, Marksmanship, or Fencing must be >= 100

### Quests & Achievements — Codex
- `[CodexWisdom.cs:80]` — Fencing maps to skill index 18 in the wisdom lookup
- `[CodexWisdom.cs:403]` — Reward: `SkillName.Fencing` assigned when player selects reward 18

### Avatar System
- `[SkillArchive.cs:71-72]` — `Fencing` property reads/writes `SkillName.Fencing`

### Character Creation — Starter Packs
- `[CharacterCreation.cs:410-418]` — Fencing starter pack: random selection of Dagger, Kryss, Assassin Spike, or Sai
- `[CharacterCreation.cs:936-942]` — Assassin starter profession: Ninjitsu (30), Hiding (30), Stealth (30), Fencing (30)

## Related Systems & Skills

### Synergies
- [Swords](swords.md): alternative weapon skill; used together for `UseBestSkill` selection
- [Bludgeoning](bludgeoning.md): same UseBestSkill pool as Fencing
- [Fist-Fighting](fist-fighting.md): same UseBestSkill pool
- [Tactics](tactics.md): paired with Fencing on runic tools and UBWS checks
- [Poisoning](poisoning.md): many fencing weapons (kryss, lance, spears) deal piercing damage that applies poison coatings effectively
- [Weapon Abilities](weapon-abilities.md): mana cost reduction uses Fencing in combined skill pool

### Prerequisites / Co-requisites
- [Warriors Guild](../world/guilds.md#warriors-guild): Fencing is a Warriors Guild skill
- [Assassins Guild](../world/guilds.md#assassins-guild): Fencing is an Assassins Guild skill
- [Dexterity](../getting-started/attributes.md#dexterity): Fencing is a Dex-associated skill; gaining Fencing can trigger +1 RawDex [SkillCheck.cs:442-443]
- [Guild skill gain factor](../world/guilds.md): 1.0x–1.5x multiplier applied during `CheckSkill()` [SkillCheck.cs:129-141]

## Notes

- Fencing does **not** use anti-macro code (no location/target verification), so it can be trained anywhere by attacking any target.
- Fencing is one of the most commonly assigned NPC skills across humanoid factions, with ranges from 28+ (adventurers) to 200 (town guards).
