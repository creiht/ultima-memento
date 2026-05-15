# Veterinary

Veterinary is the healing and resurrection skill for animals and monsters, mirroring the Healing–Anatomy relationship but for creatures.

## Overview

| Property | Value |
|---|---|
| **Primary Stat** | Intelligence |
| **Usage** | Active (bandage on animal/monster) |
| **Skill Type** | Trainable |
| **Skill Check** | 0 – 125 |

## Description

Veterinary lets you bandage, cure poison on, and resurrect injured or dead non-player creatures. It is the primary skill for monster healing, paired with Druidism as the secondary skill, and scales multiple game systems including druidic spell potency, pet management, and egg-hatching refunds.

## How It Works

### Bandaging Creatures

Apply bandages to any non-player creature classified as a monster or animal. The server uses **Veterinary as the primary skill** and **Druidism as the secondary skill** for the heal check — exactly mirroring how Healing uses Anatomy for players (`Bandage.cs:289`, `Bandage.cs:297`).

**Heal amount formula:**

```
min = (Druidism / 2) + (Veterinary / 2) + 50
max = (Druidism / 2) + (Veterinary / 2) + 100
monster bonus = HitsMax / 100
total = random(min, max) + monster bonus
```

**Heal speed:** Veterinary heals complete in a flat **2.0 seconds**, regardless of Dexterity — significantly faster than Healing which scales with Dex (`Bandage.cs:648-671`).

**Normal heal check:** chance = `(Vet + 10) / 100 - slips*0.02` (`Bandage.cs:485-487`).

**Poison cure:** Requires Veterinary ≥ 60 AND Druidism ≥ 60. Cure chance formula:

```
chance = ((Veterinary - 30) / 50) - (PoisonLevel * 0.1) - (slips * 0.02)
```

(`Bandage.cs:427-454`)

**Resurrection:** Dead pets can be brought back to life with bandages when **both** of the following conditions are met:

- **Veterinary ≥ 80**
- **Druidism ≥ 80**

Resurrection chance formula:

```
chance = ((Veterinary - 68) / 50) - (slips * 0.02)
```

(`Bandage.cs:340-344`)

Resurrecting pets costs -0.1 base to all of the pet's skills on revival. Resurrection is not possible in Khaldun or at invalid locations. If the pet's master is not nearby, any friend within 3 tiles can resurrect it.

### Druidism Spell Scaling

Several Druidism spells scale their power from Veterinary:

- **Lurestone Spell** — effect radius or potency × `Vet / 100` (`LureStoneSpell.cs:141,340`).
- **Treefellow Spell** — summoned companion quality × `Vet / 100`.

### Herbalist Shoppe

The range of stock available from the Herbalist Shoppe scales with:

```
Stock level = (Druidism + Veterinary) / 2
```

(`HerbalistShoppe.cs:171-176`). See [Druidism](druidism.md) for more on shoppe mechanics.

### Egg Hatch Quality

Bringing a **Dragon Egg** or **Alien Egg** to the appropriate animal expert yields a refund based on Veterinary skill:

- **Dragon Egg:** refunds gold = `NeedGold × (Veterinary / 200)` (capped at 50% refund) (`DragonEgg.cs:126-181`).
- **Alien Egg:** refunds xormite = `NeedXormite × (Veterinary / 200)` (capped at 50% refund) (`AlienEgg.cs:127-175`).

The hatched creature becomes a **bonded pet** that can be resurrected if it dies (within the bonding period). See [Dragon Egg](../items/dragon-egg.md) and [Alien Egg](../items/alien-egg.md) for full egg quest details.

### Beastmaster Title

Hitting combined thresholds of 60/90/120 across **Herding, Veterinary, Druidism, and Taming** simultaneously unlocks three tiers of the **Beastmaster** player title. See [Herding](herding.md) for the full table.

### Stable Slots & Follower Cap

**Stable slots** (via AnimalTrainer) are determined by the sum of Taming + Druidism + Veterinary + Herding, with each skill individually giving +1 slot per 10 points above 90.0:

| Sum of 4 Skills | Base Slots |
|---|---|
| < 160 | 2 |
| 160–199 | 3 |
| 200–239 | 4 |
| 240–299 | 5 |
| 300–399 | 6 |
| 400+ | 7 |

Each of the four skills above 100 adds additional slots on top of this base (`AnimalTrainer.cs:238-276`).

**Follower cap** is similarly gated by all four skills at 60/90/120 thresholds (minimum 5, max 8 followers), triggered on skill changes (`PlayerMobile.cs:641-642`, `PlayerMobile.cs:651-663`).

## How to Train

Apply bandages to injured animals and monsters. Gain fires passively on each application. Veterinary is a **trainable skill** (`SkillCheck.cs:55`).

Power Scrolls for Veterinary are available at the **Shrine of Wisdom** to cap the skill above 120.0.

## What It Affects

### Creature Healing & Resurrection

- `Bandage.cs:289` — `GetPrimarySkill()` returns Veterinary for monsters/animals (Healing for players).
- `Bandage.cs:297` — `GetSecondarySkill()` returns Druidism for monsters/animals (Anatomy for players).
- `Bandage.cs:340-344` — Resurrection check: `Veterinary >= 80 && Druidism >= 80`, chance = `(Vet - 68) / 50 - slips*0.02`.
- `Bandage.cs:427-454` — Poison cure check: `Veterinary >= 60 && Druidism >= 60`, chance = `(Vet - 30) / 50 - poisonLevel*0.1 - slips*0.02`.
- `Bandage.cs:485-487` — Normal heal check: chance = `(Vet + 10) / 100 - slips*0.02`.
- `Bandage.cs:627-646` — `CalculateHealAmount()`: formula uses average of Veterinary and Druidism, plus HitsMax/100 for monsters.
- `Bandage.cs:648-671` — `HealTimer()`: Veterinary heals take flat 2.0 seconds (Healing scales with Dex).
- `SkillCheck.cs:55` — Veterinary is marked as trainable (true).
- `SkillCheck.cs:276` — `CanGain()` allows passive gain fires for Veterinary.

### Druidic Herbalism Crafting

- `DefDruidism.cs:95-150` — **14 recipes** have Veterinary skill checks ranging from 5.0–15.0 to 75.0–95.0:
  - LureStonePotion: Vet 5–15
  - NaturesPassagePotion: Vet 10–20
  - ShieldOfEarthPotion: Vet 15–25
  - WoodlandProtectionPotion: Vet 20–30
  - StoneCirclePotion: Vet 25–35
  - GraspingRootsPotion: Vet 30–40
  - DruidicRunePotion: Vet 35–45
  - HerbalHealingPotion: Vet 40–50
  - BlendWithForestPotion: Vet 45–55
  - FireflyPotion: Vet 50–60
  - MushroomGatewayPotion: Vet 55–65
  - SwarmOfInsectsPotion: Vet 60–70
  - ProtectiveFairyPotion: Vet 65–75
  - TreefellowPotion: Vet 70–80
  - VolcanicEruptionPotion: Vet 80–95

### Elixirs

- `Elixirs.cs:4900-4999` — **Elixir of Veterinary** is an alchemical potion that adds a temporary skill mod to Veterinary. Duration and strength scale with Cooking + Tasting + Alchemy.
- `ItemSales.cs:4007` — Craftable via Alchemy market, requires Mortar and Pestle.
- `BaseElixir.cs:122` — Players can only have 2 elixirs active simultaneously; cannot stack two Veterinary elixirs.

### Pet Management

- `AnimalTrainer.cs:238-276` — `GetMaxStabled()`: Veterinary is one of four skills (with Taming, Druidism, Herding) that determine stable slots.
- `PlayerMobile.cs:641-642` — `OnSkillInvalidated()`: Veterinary changes trigger `UpdateFollowers()`.
- `PlayerMobile.cs:651-663` — `UpdateFollowers()`: Veterinary ≥ 60/90/120 (with the other three) raises follower cap from 5 → 6 → 7 → 8.

### Egg Hatching Quests

- `DragonEgg.cs:126-181` — `ProcessDragonEgg()`: Veterinary skill refund = `NeedGold × (Vet / 200)`, capped at 50%.
- `AlienEgg.cs:127-175` — `ProcessAlienEgg()`: Veterinary skill refund = `NeedXormite × (Vet / 200)`, capped at 50%.

### NPCs & Vendor Types

- `Veterinarian.cs:27` — Veterinarian NPC vendor has 90.0–100.0 Veterinary; sells bandages, animals, and stable items.
- `Shepherd.cs:62` — Shepherd NPC has 65.0–88.0 Veterinary.
- `Ranger.cs:28` — Ranger NPC has 65.0–88.0 Veterinary.
- `Rancher.cs:25` — Rancher NPC has 60.0–83.0 Veterinary.
- `Druid.cs:33` — Druid NPC has 90.0–100.0 Veterinary.
- `DruidTree.cs:40` — DruidTree NPC has 90.0–100.0 Veterinary.
- `PorterItem.cs:73` — Porters accept items from Veterinarian vendors.
- `BaseVendor.cs:1230-1234` — Veterinarian and AnimalTrainer vendors accept AlienEgg and DragonEgg drops.
- `Cargo.cs:855` — Cargo "Stable Worker" vendors match Veterinarian, Rancher, and AnimalTrainer types.

### Item Bonuses

- `GuildRing.cs:58` — Healers Guild Ring: +15 Veterinary.
- `GuildRing.cs:88` — Druids Guild Ring: +10 Veterinary.
- `Artifact_TheDryadBow.cs:23` — The Dryad Bow artifact: +25 Veterinary.
- `Artifact_RingOfHealth.cs:17` — Ring of Health artifact: +25 Veterinary.
- `Artifact_StitchersMittens.cs:18` — Stitcher's Mittens artifact: +25 Veterinary.
- `BaseRunicTool.cs:236` — Veterinary is a possible random enchant skill on runic tools.

### Character Creation & Display

- `CharacterCreation.cs:962` — Veterinary 30.0 is a starting skill option for certain character builds.
- `SkillName.cs:77` — `/skill veterinary` command sets character skill view to index 53.
- `SkillDisplay.cs:115,207` — Veterinary appears in skill listing gumps.
- `DynamicBook.cs:343` — Veterinary profession title: "Mortician".
- `Skills.cs:96` — In-game skill description: "If one decides to become a Tamer, this skill will allow you to use bandages to heal your pets and even resurrect them. This skill is also required if one intends to explore druidic herbalism."

### Other Systems

- `Avatar/SkillArchive.cs:239-240` — Veterinary is tracked as `Veterinary` property in the Avatar system's SkillArchive.

## Related Systems & Skills

### Synergies
- [Druidism](druidism.md): co-requisite for pet resurrection, Druidism crafting, and Beastmaster title; secondary skill for healing monsters.
- [Taming](taming.md): bond with pets; required for the Beastmaster title and stable slots alongside Veterinary.
- [Herding](herding.md): move and assist pets; shares the Beastmaster gate and follower cap with Veterinary.
- [Druidism](../magic/druidism.md): 16 nature-themed spells scale power from Veterinary skill.

### Prerequisites / Co-requisites
- [Druidism](druidism.md): Veterinary ≥ 80 AND Druidism ≥ 80 required for pet resurrection.
- [Druidism](druidism.md): Veterinary ≥ 60 AND Druidism ≥ 60 required for poison cure on creatures.
- [Alchemy](../crafting/alchemy.md): Craft Elixir of Veterinary; duration and strength scale with Tasting + Cooking + Alchemy.
- [Anatomy](anatomy.md): Secondary skill for Healing (the player-equivalent skill); Druidism fills this role for Veterinary.

## Notes
- Veterinary ≥ 80 AND Druidism ≥ 80 are both required for pet resurrection via bandages.
- The Beastmaster title requires Veterinary, Taming, and Herding to be at specific thresholds.
- Veterinary is the monster-equivalent of Healing, with Druidism filling the role of Anatomy.
