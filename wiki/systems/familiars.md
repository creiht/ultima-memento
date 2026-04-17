# Familiars

There are **three distinct systems** in Ultima Memento that use the word "familiar." They are mechanically unrelated — this page documents all three.

---

## Comparison at a Glance

| Property | Necromancy Summon | Crystal Ball of Summoning | Hoard Minion Item |
|---|---|---|---|
| **Source** | Necromancy spell | Guildmaster quest | Champion boss drop / quest reward |
| **How triggered** | Cast *Summon Familiar* | Double-click crystal ball | Double-click consumable item |
| **Duration** | Up to 24 h (wiped on restart) | Persistent (survives saves) | 10 minutes |
| **Control slots** | 1 | 5 | 1 |
| **Blessed** | No | Yes | Yes |
| **Combat** | Yes | No (AI_Animal, Aggressor only) | Limited (melee, carries pack) |
| **Pack storage** | No | Yes (StrongBackpack) | Yes (StrongBackpack) |
| **Cap** | 1 per player | 1 + no other followers | 1 follower slot needed |
| **Dispellable** | Difficulty 80 | No | No |

---

## System 1 — Necromancy Summon Familiar

A dark-magic spell that binds a creature to serve the necromancer until dismissed or the world restarts.

### Spell Details

| Property | Value |
|---|---|
| Spell name | Summon Familiar |
| Words | *Kal Xen Bal* |
| Minimum Necromancy | 30.0 |
| Mana cost | 17 |
| Cast time | 2 seconds |
| Reagents | Bat Wing, Grave Dust, Daemon Blood |
| Limit | 1 active familiar per player |

### Familiar Selection

After casting, a gump appears. Familiars are unlocked by meeting **both** the Necromancy and Spiritualism skill minimums.

| Familiar | Min Necromancy | Min Spiritualism |
|---|---|---|
| Horde Minion | 30 | 30 |
| Shadow Wisp | 50 | 50 |
| Dark Wolf | 60 | 60 |
| Death Adder | 80 | 80 |
| Vampire Bat | 100 | 100 |

### Stat Scaling

At summon time, stats are boosted from the caster's skills:

```
DamageMin += (Necromancy + Spiritualism) / 25
DamageMax += (Necromancy + Spiritualism) / 25
HitsMax   += (Necromancy + Spiritualism) / 2
MagicResist = caster's MagicResist skill
```

### Familiar Stats Table

Base stats before scaling (from constructors):

| Familiar | Hits | STR | DEX | INT | Phys | Fire | Cold | Poison | Energy | Skills |
|---|---|---|---|---|---|---|---|---|---|---|
| Horde Minion | 70 | 100 | 110 | 100 | 50–60 | 50–55 | — | 25–30 | 25–30 | FistFighting 70–75, Tactics 50 |
| Shadow Wisp | 50 | 50 | 60 | 100 | 10–15 | 10–15 | 10–15 | 10–15 | 99 | FistFighting 40, Tactics 40 |
| Dark Wolf | 60 | 100 | 90 | 90 | 40–50 | 25–40 | 25–40 | 25–40 | 25–40 | FistFighting 85–90, Tactics 50 |
| Death Adder | 50 | 70 | 150 | 100 | 10 | — | — | 100 | — | FistFighting 90, Tactics 50, MagicResist 100, Poisoning 150 |
| Vampire Bat | 90 | 120 | 120 | 100 | 10–15 | 10–15 | 10–15 | 10–15 | 10–15 | FistFighting 95–100, Tactics 50 |

### Special Abilities

**Horde Minion** — Carries a backpack. Every 1–3 seconds, automatically picks up any **stackable** items on the ground within 3 tiles and stores them in its pack. Items drop to the ground on death.

**Shadow Wisp** — Every 5–30 seconds: emits a mana flare in a 5-tile radius; all **negative-karma** players (not in combat with the master) within range gain mana equal to `1 - (karma / 1000)`.

**Dark Wolf** — Every 2 seconds: grants the master `+1 stamina` (directly increments `Stam`). Useful for sustained stamina regeneration. See also [Taming — Dark Wolf interaction](../skills/taming.md#dark-wolf-familiar).

**Death Adder** — Any melee hit applies poison. 80% chance to apply **Greater Poison**; 20% chance to apply **Deadly Poison**.

**Vampire Bat** — No special passive. Has the highest base combat stats of all five familiars.

### Shared BaseFamiliar Mechanics

All five Necromancy familiars inherit from `BaseFamiliar`:

| Mechanic | Value |
|---|---|
| Bard-immune | Yes |
| Poison immune | Deadly level |
| Player-commandable | No (`Commandable = false`) |
| Dispel difficulty | 80 (focus 20) |
| Follows hidden state | Yes (mirrors master's hidden flag) |
| On master deletion | Drops pack contents and deletes |
| On server restart / world save | Deleted (via `IValidate.Validate()`) |

Because `BaseFamiliar.Validate()` destroys the familiar during world validation, they *never* survive a server restart regardless of their 24-hour summon duration.

### Duration

Nominally **24 hours**, but in practice the familiar is removed whenever the world saves or the server restarts. Plan for it to last only for the current play session.

---

## System 2 — Crystal Ball of Summoning (HenchmanFamiliar)

A persistent pack-animal companion obtained from Guildmasters. Unlike tamed pets, this familiar is bound to a specific player and stored in the crystal ball between uses.

### How to Obtain

Visit a **Mage Guildmaster**, **Necromancer Guildmaster**, or **Elemental Guildmaster** and donate **20 or more rubies or star sapphires** (specific gem varies by guildmaster). You must have **at least 50 in Magery, Necromancy, or Elementalism**.

The guildmaster presents you with a `crystal ball of summoning` deed item bound to your character.

### Charges

| Property | Value |
|---|---|
| Starting charges | 5 |
| Maximum charges | 50 |
| Recharge cost | 500 gp per 5 charges |
| Begging discount | Yes — Begging reduces recharge cost |

Drag the crystal ball onto the Guildmaster to recharge it.

### Summoning Requirements

To summon the familiar from the crystal ball (double-click the ball):

- Ball must be in your backpack
- You must have **no other followers** (Followers must be 0)
- You must have ≥ 50 in Magery, Elementalism, **or** Necromancy
- At least 1 charge remaining
- The ball must belong to you (ownership bound by `FamiliarOwner`)

### HenchmanFamiliar Stats

The familiar spawned is always the same creature regardless of body form:

| Property | Value |
|---|---|
| STR | 65,000 |
| AI | AI_Animal, FightMode.Aggressor |
| Blessed | Yes (cannot be killed) |
| Control slots | 5 |
| Pack type | StrongBackpack |
| Bondable | No |
| Dispellable | No |
| Can be renamed | Yes |

Because it is **blessed**, it has an effectively unlimited health pool and cannot be killed by anything.

### Body Form Cycling

Drag the crystal ball onto the Guildmaster to change the familiar's body form — it advances through a chain of 22 forms. The chain has two branching points based on whether you have ≥ 50 in a "high" cast skill (Magery/Elementalism/Necromancy):

**Chain (in order):**
gazer → dog → rat → cat → huge rat → large toad → huge frog → large cat → wolf → large lizard →

- ***Branch A* (≥ 50 skill):** small dragon → large scorpion → ...
- ***Branch B* (< 50 skill):** dragon → large scorpion → ...

...→ large scorpion → huge beetle → imp →

- ***Branch A* (≥ 50 skill):** spider → bat → ...
- ***Branch B* (< 50 skill):** giant spider → bat → ...

...→ bat → giant insect → serpent →

- ***Branch A* (≥ 50 skill):** demon → gazer → (cycle restarts)
- ***Branch B* (< 50 skill):** daemon → gazer → (cycle restarts)

### Pack Animal Behavior

Double-clicking the familiar opens its pack. Both the familiar's master and any **co-owner** (controlled ally with Pack Animal access) can deposit and withdraw items. Works identically to a pack horse.

### Persistence

The crystal ball and its familiar **persist across world saves and server restarts**:

- When the server reloads, the `HenchmanFamiliar` triggers a `LeaveNowTimer` (10 seconds) and then auto-releases back into the crystal ball.
- The ball's `FamiliarSerial`, `FamiliarName`, `FamiliarType`, and `Hue` are all saved, so the familiar re-spawns with the same appearance and name next time the ball is used.

---

## System 3 — Hoard Minion Familiar Item (Consumable)

A single-use item that summons a powerful, blessed pack-mule Hoard Minion for 10 minutes.

### Item Properties

| Property | Value |
|---|---|
| Item name | A hoard minion |
| Use | Double-click from backpack |
| Duration | 10 minutes, then auto-deletes |
| Follower slots required | 1 |

### Summoned Hoard Minion Stats

| Property | Value |
|---|---|
| STR | 65,000 |
| Blessed | Yes |
| Control slots | 1 |
| Pack type | StrongBackpack |
| Auto-loots | Yes (inherits HordeMinionFamiliar behavior — picks up stackables within 3 tiles) |

### Drop Sources

| Source | Chance |
|---|---|
| Champion boss death | 100% guaranteed |
| Major Quest completion | Possible reward |
| Summon Quest chest | Possible reward |

See [Champion Spawns](champion-spawns.md) and [Champion Rewards](loot-tables/champion-rewards.md) for more on champion boss loot.

---

## Cross-links

- [Necromancy](../magic/necromancy.md) — Summon Familiar spell (System 1)
- [Spiritualism](../skills/spiritualism.md) — required alongside Necromancy for System 1 familiar selection
- [Taming](../skills/taming.md) — Dark Wolf grants wolf mastery (System 1 interaction)
- [Inscription](../crafting/inscription.md) — Summon Familiar scroll can be scribed
- [Champion Spawns](champion-spawns.md) — source of Hoard Minion Familiar items
- [Champion Rewards](loot-tables/champion-rewards.md) — full champion drop tables
- [Henchmen](henchmen.md) — the fourth companion system; not a familiar

---

## Source Files

| File | Purpose |
|---|---|
| `World/Source/Scripts/Engines and Systems/Magic/Necromancy/SummonFamiliar.cs` | System 1: spell, gump, summon logic, scaling |
| `World/Source/Scripts/Mobiles/Base/BaseFamiliar.cs` | System 1: shared base class |
| `World/Source/Scripts/Mobiles/Civilized/Familiars/HordeMinion.cs` | System 1: Horde Minion (auto-loot) |
| `World/Source/Scripts/Mobiles/Civilized/Familiars/ShadowWisp.cs` | System 1: Shadow Wisp (mana flare) |
| `World/Source/Scripts/Mobiles/Civilized/Familiars/DarkWolf.cs` | System 1: Dark Wolf (stamina regen) |
| `World/Source/Scripts/Mobiles/Civilized/Familiars/DeathAdder.cs` | System 1: Death Adder (poison on hit) |
| `World/Source/Scripts/Mobiles/Civilized/Familiars/VampireBat.cs` | System 1: Vampire Bat (combat) |
| `World/Source/Scripts/Mobiles/Civilized/Familiars/Familiar.cs` | System 2: HenchmanFamiliar mobile |
| `World/Source/Scripts/Mobiles/Civilized/Familiars/FamiliarItem.cs` | System 2: Crystal Ball of Summoning item |
| `World/Source/Scripts/Mobiles/Civilized/Familiars/HoardMinionFamiliar.cs` | System 3: blessed pack Hoard Minion mobile |
| `World/Source/Scripts/Mobiles/Civilized/Familiars/HoardMinionFamiliarItem.cs` | System 3: consumable item |
| `World/Source/Scripts/Mobiles/Civilized/Guilds/MageGuildmaster.cs` | System 2: crystal ball acquisition and recharge |
| `World/Source/Scripts/Engines and Systems/Champs/Mobiles/Bosses/BaseChampion.cs` | System 3: champion drops |
