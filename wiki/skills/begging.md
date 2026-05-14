# Begging

Begging allows you to grovel before NPCs for gold, or desperately plead with hostile creatures and players to leave you alone. It also provides merchant discounts when you toggle your begging demeanor.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Dexterity |
| Usage | Active (targeted) |
| Range | 12 tiles (combat), 2 tiles (NPC gold) |
| Cooldown | 10 seconds |
| Power Scroll Cap | Yes (PowerScroll.cs:15,208,283,389) |

## How It Works

### Begging Gold from NPCs

Target a human NPC while within 2 tiles. Your character bows, and after a short delay the NPC may give you gold. The amount depends on how much the NPC is carrying (up to 1/10 of their gold, capped at 10-14 based on your fame). Negative karma reduces your chance of success.

**Karma Warning:** Successfully begging from NPCs costs **-40 Karma**.

### Begging Enemies to Stop Attacking

Target a hostile creature or player who is attacking you. Your character cries out pleas like "Have mercy!" or "Leave me alone!" On success, the target is **pacified** and stops fighting.

- Against creatures: They are pacified for a duration based on difficulty (10-120 seconds). On a very strong result the creature may additionally be paralyzed briefly (this branch only applies to `BaseCreature`). Difficulty is calculated from the target's HitsMax, StamMax, ManaMax, SkillsTotal, and bonuses for magery, fire breath, poison immunity, and paragon status.
- Against players: a successful beg simply ends the target player's combat mode. **Players are never paralyzed by begging** — the paralysis branch only fires against creatures. (Source: `Begging.cs:262-288`.)
- Uncalmable creatures cannot be begged.
- Bard-pacified creatures cannot be begged again.

**Karma/Fame Warning:** Using begging in combat costs **-40 Karma** and **-40 Fame**.

### Toggle Begging Demeanor

Target yourself to toggle "begging demeanor" mode on or off. While active, this enables merchant discounts (see below) and is checked by various systems. The pose is detected via `BaseVendor.BeggingPose()` which returns your Begging skill value if the demeanor is active (`BaseVendor.cs:355-366`).

## What It Affects

### Merchant Discounts

When your begging demeanor is toggled on, the following vendor services receive a **0.5% per skill value discount** (formula: `cost - (skill * 0.005 * cost)`, minimum 1 gold):

| Service | File:Line | Details |
|---|---|---|
| Vendor buy price | `BaseVendor.cs:1148-1152` | Replaces Mercantile barter value with Begging value; costs -40 Karma |
| Vendor sell price | `BaseVendor.cs:2041-2048` | Replaces Mercantile barter value with Begging value |
| Recharge service | `BaseVendor.cs:2388-2392` | Discount on item recharge costs |
| Identify service | `BaseVendor.cs:2407-2412` | Discount on item identification (200g base) |
| Repair service | `BaseVendor.cs:2428-2433` | Discount on durability/repair costs |
| Black Market prices | `BlackMarket.cs:138-139` | Uses Begging instead of Mercantile for price calculation |

The following individual vendors also apply the begging discount to their services:

| Vendor | File:Lines |
|---|---|
| Healer | `BaseHealer.cs:213,246,279,312` |
| Mage Guildmaster | `MageGuildmaster.cs:129,161` |
| Necromancer Guildmaster | `NecromancerGuildmaster.cs:196,228` |
| Druid Guildmaster | `DruidGuildmaster.cs:131,163` |
| Elemental Guildmaster | `ElementalGuildmaster.cs:122,154` |
| Librarian Guildmaster | `LibrarianGuildmaster.cs:173,200` |
| Cartographers Guildmaster | `CartographersGuildmaster.cs:104,136` |
| Tailor | `Tailor.cs:116,117,149,189,229` |
| Weaver | `Weaver.cs:101,102,134` |
| Thief | `Thief.cs:129,156` |
| Painter | `Painter.cs:78` |
| Mapmaker | `Mapmaker.cs:107,139` |
| Jester | `Jester.cs:137,189` |
| Gypsy Lady | `GypsyLady.cs:171,217,259,301,341` |

Note: Player Barkeepers do **not** offer begging discounts.

### Quests

| Quest | File:Line | Effect |
|---|---|---|
| Museum (Antiques) | `Museum.cs:102` | Extra museum gold when selling antiques: `(cost * Begging * 0.01 / 4)` if begging pose active |
| Prisoners | `Prisoner.cs:320-326` | Reduces prisoner join cost by `(Begging * 25)`, max 3000 gold reduction |
| Cargo/Boats | `Cargo.cs:867` | Extra port cargo gold: `(cargoValue * Begging * 0.01 / 3)` if begging pose active |

### Jester Magic System

Begging is deeply integrated into the Jester spell system:

| Spell | File:Line | Effect |
|---|---|---|
| Base Jester Spell | `JesterSpell.cs:15` | CastSkill returns `SkillName.Begging` |
| Base Jester Spell | `JesterSpell.cs:137` | Duration: `Begging / 2` (max 60) |
| Base Jester Spell | `JesterSpell.cs:142` | Buff strength: `Begging / 4` (max 25) |
| Base Jester Spell | `JesterSpell.cs:147` | Skill check: `Begging / 2` (max 60) |
| Base Jester Spell | `JesterSpell.cs:152` | Damage: `Begging / 25` (max 4) |
| Hilarity | `Hilarity.cs:103` | Duration: `Psychology + (Psychology + Begging) / 8` seconds |
| Seltzer Bottle | `SeltzerBottle.cs:49` | Damage: `1 + (Begging / 5) + (Psychology / 3)` |
| Seltzer Bottle | `SeltzerBottle.cs:54` | Chance to leave MonsterSplatter based on Begging check vs random(50,300) |
| Flower Power | `FlowerPower.cs:49` | Damage: `1 + (Begging / 5) + (Psychology / 3)` |
| Flower Power | `FlowerPower.cs:54` | Chance to leave MonsterSplatter based on Begging check vs random(50,300) |
| Can of Snakes | `CanOfSnakes.cs:58` | Each Begging check vs random(1,200) that succeeds adds +1 snake |
| Clowns | `Clowns.cs:70` | Each Begging check vs random(1,200) that succeeds adds +1 clown |
| Rabbit in a Hat | `RabbitInAHat.cs:63-64` | Two independent Begging checks vs random(1,200), each succeeds adds +1 rabbit |

### Items

| Item | File:Line | Effect |
|---|---|---|
| Beggar's Robe (Artifact) | `Artifact_BeggarsRobe.cs:15` | +30 to Begging skill, +100 Luck |
| Bag of Tricks | `Players.cs:130` | Requires Begging >= 10 **OR** Psychology >= 10 to use |

### Training & Behavior

| System | File:Line | Details |
|---|---|---|
| NPC AI Training | `Behavior.cs:6247` | AI NPCs auto-train Begging as one of their practiced skills |
| Character Creation | `CharacterCreation.cs:202` | Selectable skill during character creation |
| Runic Tools | `BaseRunicTool.cs:189` | Can affect Begging skill |
| Elixirs | `Elixirs.cs:688` | Can be a skill type for certain elixirs |
| Special Scrolls | `SpecialScroll.cs:64` | Skill index 7 maps to Begging |
| Race Skills | `BaseRace.cs:1306` | Skill index 6 maps to Begging |

## How to Train

Use the skill on hostile creatures. The difficulty is based on the target's stats, skills, and special abilities (magery, fire breath, poison immunity, etc.). Stronger enemies are harder to beg.

**Difficulty formula** (`Begging.cs:82-121`):
- Base = `(HitsMax * 1.6 + StamMax + ManaMax + SkillsTotal / 10) / 10`
- Capped at `700 + (excess * 3/11)` before division
- +100 for creatures with Magery > 5
- +100 for creatures with fire breath
- +100 for poison-immune creatures
- +100 for VampireBats/VampireBatFamiliars
- +20 per poison level
- +40 for Paragon creatures
- SE era capped at 160

## Related Skills

- [Psychology](psychology.md) - Used together in Jester spell calculations; also checked as alternative for Bag of Tricks
- [Peacemaking](peacemaking.md) - Also pacifies creatures but uses music
- [Mercantile](mercantile.md) - Competing barter skill for vendor discounts; Begging replaces Mercantile when begging pose is active
- [Hiding](hiding.md) - An alternative way to disengage from combat
