# Taming

Taming lets you domesticate wild creatures so they serve you as loyal pets and combat companions.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Strength |
| Usage | Active (targeted) |
| Range | 3 tiles (targeting), 6 tiles (during taming) |
| Taming Duration | 3-4 ticks, 3 seconds each (9-12 seconds total) |

## How It Works

1. Use the skill and target a tameable creature.
2. Your character speaks soothing phrases for several rounds.
3. After the taming attempts complete, a final skill check determines success.

### Skill Requirements

Each creature has a **Minimum Tame Skill** (`MinTameSkill`). You must meet or exceed this value. Creatures already owned by you are much easier to re-tame.

### Taming Difficulty

```
Required Skill = MinTameSkill + (Previous Owners * 6) + 24.9
Druidism Bonus: reduces min check by (Druidism Skill / 5)
```

### Taming Effects on Stats

When a creature is tamed for the **first time**, it suffers stat penalties:
- **Skills reduced to 90%** of original (86% if the creature was paralyzed during taming)
- Creatures with `StatLossAfterTame` also lose **25% of their stats**

### Follower Slots

Each tamed creature requires follower slots. You cannot tame a creature if it would exceed your maximum followers.

### Dark Wolf Familiar

Having a Dark Wolf Familiar active grants automatic mastery over wolf-type creatures (Worg, Dire Wolf, Grey Wolf, Timber Wolf, White Wolf, Mystical Fox). The Dark Wolf Familiar is obtained via the [Necromancy Summon Familiar spell](../magic/necromancy.md) — see [Familiars — Dark Wolf](../systems/familiars.md#dark-wolf) for its full stats and passive stamina-regen ability.

### Conditions That Interrupt Taming

- Moving more than 6 tiles away
- Losing line of sight or path access
- The creature taking damage
- The creature dying or becoming untameable
- Someone else already taming the creature

### Subduing

Some creatures must be **subdued** (reduced below 10% health) before they can be tamed.

### Max Owners

Creatures have a maximum number of previous owners. If the limit is reached, the creature is "too upset" to be tamed by a new owner.

### Angering the Creature

There is a 95% chance that an untamed creature with `CanAngerOnTame` will become hostile when you attempt to tame it, attacking you and potentially breaking pacification.

### Successful Tame

On success:
- The creature becomes your controlled pet
- It loses all fame and karma
- Its fight mode changes to Aggressor
- It starts at Level 1 and is unbonded

## How to Train

Tame progressively harder creatures. Re-taming already-owned creatures gives no skill gain ("That wasn't even challenging"). [Druidism](druidism.md) gains passively during the taming process — **but only on the first tame of a creature** (`!alreadyOwned`). Re-taming a pet you already own does **not** grant Druidism gain. (Source: `Taming.cs:308`.)

## What It Affects

### Pet Control Chance

Your Taming skill is the primary input for **control chance** — the probability that your pet obeys commands during combat. The formula (`BaseCreature.cs:1987-2031`):

```
tamingValue = Taming.Base or Taming.Value (configurable)
druidismValue = Druidism if higher, otherwise Taming
SkillMod = 28 if Taming < MinTameSkill, else 6
LoreMod = 14 if Druidism < MinTameSkill, else 6
bonus = ((taming - MinTameSkill) * SkillMod + (druidism - MinTameSkill) * LoreMod) / 2
chance = max(200, min(990, 700 + bonus)) - (MaxLoyalty - Loyalty) * 10
ControlChance = chance / 1000
```

Loyalty reduces control chance as it drops — a pet at 0 loyalty has significantly worse obedience. Control checks occur when you issue commands during combat (`BaseCreature.cs:1951-1975`).

### Pet Loyalty Decay

Loyalty naturally decays when your pet is out and idle (`BaseCreature.cs:10263-10279`):

| Pet State | Loyalty Decay Rate |
|---|---|
| Normal pet | 10% of MaxLoyalty per 5-minute check |
| Bonded pet (that can't anger on tame) | 5% of MaxLoyalty per 5-minute check |

When loyalty hits 0, the pet runs away and is released (`BaseCreature.cs:10279`). You can restore loyalty by feeding your pet or using gold (`BaseCreature.cs:5730-5748`). Feeding has a 50% chance to increase loyalty by 10 per tick when below MaxLoyalty.

### Pet Leveling (Jako Pets)

When your pet gains a level, a Taming check is made per level against `MinTameSkill ± 25` (`BaseCreature.cs:10154-10159`). Pets that reach **Level 3 auto-bond** regardless of bonding progress (`BaseCreature.cs:10182-10189`). At the **maximum level**, pets lose 1 ControlSlot (minimum 2), making them easier to control (`BaseCreature.cs:10163-10172`).

### Bonding System

Bonding lets your pet survive death and return to you. It requires your **Taming >= MinTameSkill** of the pet (using Base skill, or Value if Mondain's Legacy expansions apply) (`BaseCreature.cs:5766`). The bonding process begins when you feed your pet and takes a configurable number of days. Bonded pets:

- Return after death (if owner is within range and on the same map)
- Have slower loyalty decay (1/20 MaxLoyalty vs 1/10)
- Auto-bond at pet Level 3 (Jako Pets system)

After bonding, the pet cannot anger on tame (if it didn't already) (`BaseCreature.cs:10269`).

### Stable Slots

The Animal Trainer charges 30 gold per pet per real-world week for stabling. Your maximum stabled pets is calculated from the sum of **Taming + Druidism + Veterinary + Herding** (`AnimalTrainer.cs:238-276`):

| Skill Sum | Base Slots |
|---|---|
| < 160 | 2 |
| 160-199 | 3 |
| 200-239 | 4 |
| 240-299 | 5 |
| 300-399 | 6 |
| 400+ | 7 |

Bonus slots are added for each of the four skills above 90: **+1 slot per 10 points** beyond 90 (`AnimalTrainer.cs:261-271`).

### Follower Slots (Beastmaster Tiers)

Your maximum follower count (how many pets you can control simultaneously) depends on the combined skill levels of Taming, Druidism, Veterinary, and Herding (`PlayerMobile.cs:651-663`):

| All Four Skills ≥ | FollowersMax |
|---|---|
| 60 | 6 |
| 90 | 7 |
| 120 | 8 |

Base FollowersMax is 5. These four skills are the **only** skills that affect FollowersMax.

### NPC Merchants

| NPC | Location | Taming Interaction |
|---|---|---|
| [Animal Trainer](../civilized/animal-trainer.md) | Druids Guild | Sells/purchases tamable creatures; provides stabling service (30g/pet/week); has Riding Gump and Claim Gump |
| [Veterinarian](../civilized/veterinarian.md) | Druids Guild | Sells/purchases tamable creatures; provides Riding Gump |
| [Druid Guildmaster](../civilized/druid-guildmaster.md) | Druids Guild | Can change [Crystal Ball of Summoning](../systems/familiars.md#crystal-ball) familiar form; sells Shepherd's Crook |

### Items

| Item | Category | Taming Interaction |
|---|---|---|
| [Shepherd's Crook](../items/weapons.md#shepherds-crook) | Weapon / Bludgeoning | Crafted via Carpentry (78.9-103.9 SKIL); also used by [Herding](herding.md) for leading creatures |
| Level / Gift Shepherd's Crook | Artifact Staff | Scaled variants of Shepherd's Crook (`LevelShepherdsCrook`, `GiftShepherdsCrook`) |

### Codex of Wisdom

Reaching **51 in Taming** triggers a Codex of Wisdom entry (`CodexWisdom.cs:115,389`).

### Related Systems

| System | Source | Taming Interaction |
|---|---|---|
| Pet Stat Gain Delay | `Settings.cs:684` | `S_PetStatGainDelay = 5.0` minutes between pet stat gains |
| Damage to Pets | `Settings.cs:688` | `S_DamageToPets = 1.4` (1.4x normal damage) |
| Critical to Pets | `Settings.cs:692` | `S_CriticalToPets = 5` (5% crit chance against pets) |
| Pet Notoriety | `Settings.cs:695` | `S_PetsMatchMasterNotoriety = true` by default |
| No Mounts in Regions | `Settings.cs:709` | `S_NoMountsInCertainRegions = true` — mounts dismount in dungeons/caves |

## Related Skills

- [Druidism](druidism.md) - Examine and improve tamed pets; gains passively during taming (first-time tames only). Also contributes to control chance and stable slots.
- [Herding](herding.md) - Leads tamed creatures to new locations; gains passively on pet control checks; contributes to stable slots and follower tiers.
- [Veterinary](veterinary.md) - Heals and treats tamed pets; contributes to stable slots and follower tiers.
- [Healing](healing.md) - Keep your pets alive with bandages and spells.
- [Necromancy](../magic/necromancy.md) - Summon Familiar spell provides Dark Wolf Familiar for taming mastery over wolf-type creatures.
- [Spiritualism](spiritualism.md) - Required alongside Necromancy for Summon Familiar selection.
