# Special Drops (DropRelic)

`DropRelic.DropSpecialItem()` fires from `BaseCreature.OnDeath()` for every creature death. It applies a series of conditional checks — creature type, fame, region, and killer's magic school — and can add zero or many items to the corpse. Stabled, controlled, and bonded creatures do not trigger it.

**Source:** `World/Source/Scripts/Mobiles/Base/DropRelic.cs`

[Back to Loot Tables](README.md)

---

## Champion Skulls

Any creature with Fame ≥ 20,000 that dies **outside** a `ChampionSpawnRegion` has a chance to drop a `ChampionSkull`:

| Condition | Chance |
|-----------|--------|
| Fame 20,000–22,000 | ~10% |
| Fame 22,000+ | 10% + (Fame − 20,000) / 2,000 (up to ~14%) |

---

## Sci-Fi / Spaceship Drops

Creatures on the Spaceship drop sci-fi items scaled to their fame:

- Fame-based count: `min(10, fame / 2400)` items (random 0 to max)
- Each item is a random sci-fi item from `Loot.RandomSciFiItems()`

---

## Robot Components (Droid Types)

`ServiceDroid`, `BattleDroid`, `SecurityDroid`, `MaintenanceDroid`, `ExcavationDroid`, `CombatDroid` — each component part has a separate fame-scaled chance:

| Component | Chance formula |
|-----------|----------------|
| Robot Sheet Metal (4–10) | fame/100 out of 300 |
| Robot Batteries | fame/100 out of 300 |
| Robot Engine Parts | fame/100 out of 300 |
| Robot Circuit Board | fame/100 out of 300 |
| Robot Transistor | fame/100 out of 300 |
| Robot Bolt (1–4) | fame/100 out of 300 |
| Robot Gears (1–4) | fame/100 out of 300 |
| Robot Oil (1–2) | fame/100 out of 300 |

---

## Creature-Type Relics (Lucky Killer, >95/100 roll)

Requires `LuckyKiller` flag **and** a >95/100 roll:

| Creature Type | Drop | Item Type |
|---------------|------|-----------|
| Cyclops, ShamanicCyclops | Eye of [name] (talisman) | BaseTrinket (MakeFixedDrop enchant) |
| Beholder, Gazer, ElderGazer | Eye of [name] (talisman) | BaseTrinket (MakeFixedDrop enchant) |
| Lich, Vordo, Nazghoul, LichLord, DemiLich, AncientLich, Surtaz, LichKing, UndeadDruid | Skull of [name] (talisman) | BaseTrinket (MakeFixedDrop enchant) |

**Lich also:** Requires Lucky + >95/100 **and** no skull/talisman already in backpack — drops a **Mask of [name]** (ReaperHood hat, random evil hue, MakeFixedDrop enchant).

---

## Syth Mysticron

From a `Syth` creature, requires `LuckyKiller` + 50% chance:
- Drops a `TrinketTalisman` named "Mysticron of [name]", random color, MakeFixedDrop enchanted.

---

## Jedi / Syth Crystals

When a Syth-slayer creature (`SlayerName.Exorcism`) is killed by a Jedi or Syth player:
- Jedi killer → `KaranCrystal` (count: fame/600 to fame/400, min 1–3)
- Syth killer → `HellShard` (same count)

---

## Wizard Wands (Wizard-Slayer Creatures)

Creatures slayable by `WizardSlayer` with Inscribe ≥ 20 and Magery ≥ 20 skills (LuckyKiller + >90/100):
- Drops a `TomeOfWands`

All `WizardSlayer` creatures also:
- 4% chance: `MagicalWand(0)`
- 1% chance: Random rune magic item (`Loot.RandomRuneMagic()`)
- 25% chance (if killer has a wizard staff): `MageEye` (count = creature level)

---

## Region-Specific Drops

### Tower of Brass

`FireGiant` in the Tower of Brass — fame-scaled chance:
- 50%/50% roll: random Brass-resource armor **or** weapon (only iron-base items are kept)

`BloodDemon` in the Tower of Brass — fame-scaled chance:
- 50%/50% roll: random WintrySpec armor/shield or weapon, enchanted at level 500

### Ancient Elven Mine

`ShamanicCyclops` in the Ancient Elven Mine — ~20% chance:
- 50%/50% roll: random SilverBlock armor/shield or weapon, enchanted at level 200

Any creature with Fame > 2,000 — ~2% chance:
- Drops 1–3 Silver Stones **or** 1–3 Silver Blocks (ingots)

### Daemon's Crag

`EvilMage` — lucky or 1-in-20 chance:
- Drops a `PaganArtifact` (variant 0), 80–100 pagan points

`EvilMageLord` — same condition:
- Drops a `PaganArtifact` (variant 0), 100–120 pagan points

### Zealan Tombs

`KhumashGor` — lucky or 1-in-10 chance:
- Drops a `PaganArtifact` (variant 16), 100–150 pagan points

---

## Demon Claw

The following demon types have a **10% chance** to drop a `DemonClaw` on death:

DemonOfTheSea, BloodDemon, Devil, TitanPyros, Balron, Fiend, Archfiend, LesserDemon, Xurtzar, FireDemon, DeepSeaDevil, Daemon, DaemonTemplate, BlackGateDemon

---

## Phoenix Feather
- `Phoenix` — **50% chance** to drop a `PhoenixFeather`

## Pegasus Feather
- `Placeron`, `Pegasus` — **25% chance** to drop a `PegasusFeather`

## Unicorn Horn
- `Unicorn`, `Dreadhorn`, `DarkUnicornRiding` — **10% chance** to drop a `UnicornHorn`

## Obsidian Stone
- `ObsidianElemental` — **0.1% chance** (1 in 1,000) to drop an `ObsidianStone`

---

## Creature Skulls

All creature deaths: **10% chance** (any killer) — `Skulls.MakeSkull()` creates a skull item named after the creature.

---

## Corpse Chests (Dragon / Sea Creature)

**Dragons and wyrms** (large list including Ancient Wyrm, Bottle Dragon, Sea Dragon, Primeval dragons, Hydra, AntLion, Shadow Wyrm, etc.) — fame-scaled chance:

| Check | Formula |
|-------|---------|
| Chance | `fame × 0.002 + 2` % |
| Chest level | min(10, `fame × 0.0006`) |

Drops a `CorpseChest` at the computed level if the chance succeeds.

**Sea creatures** (Deep Sea Serpent, Sea Dragon, Giant Squid, Megalodon, Jormungandr, Shark, Great White, Sea Serpent, Kraken, Leviathan) — same formula drops a `CorpseSailor`.

---

## Dragon Blood / Drakkhen Eggs / Dragon Teeth

On death of most dragon/wyrm types (including all Primeval variants, Sea Dragon, Ash Dragon, Void Dragon, etc.):

| Drop | Chance | Notes |
|------|--------|-------|
| `DragonBlood` (1–3) | **~5%** (>95 out of 100) | All dragon types that match the list |
| `DrakkhenEgg` (Red or Black) | 3% | Color depends on dragon type/hue |
| `DragonTooth` | 25% | Certain types only: Ash, Bottle, Caddellite, Crystal, Elder, Radiation, Void |
| `DragonTooth` (1–2) | 50% | All Primeval variants + some others |
| `DragonTooth` (1–4) | 100% | Dragon King only |

---

## Lich Dust

On death of Lich variants:

| Creature | Chance | Amount |
|----------|--------|--------|
| AncientLich | 100% | 1–3 |
| Lich, LichLord, Nazghoul, AncientLich, UndeadDruid, TitanLich, DemiLich, Surtaz | **~20%** (>80 out of 100) | 1–3 |

---

## High Seas Loot

Sea creatures on the open ocean or in sea dungeons (`neptune.Slays(from)` + `WhisperHue == 999`, or `Jormungandr`, or `Worlds.IsSeaDungeon()`):

| Drop | Chance | Condition |
|------|--------|-----------|
| `HighSeasRelic` | `fame × 0.002 + 2`% | Always on sea creatures |
| `MessageInABottle` (level 1–4) | `fame × 0.002 + 1`% | Fame ≥ 6,000 |
| `LootChest` (Sea Chest, level 1–5) | `fame × 0.001 − 1`% | Not a StormGiant |

High-fame sea creatures (≥ 11,500) also:

| Drop | Chance |
|------|--------|
| `EnchantedSeaweed` (1–3) | `fame × 0.002 + 2`% |
| `Oyster` | `fame × 0.001 + 1`% |
