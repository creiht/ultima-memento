# Begging

Begging lets you grovel before NPCs for gold, plead with hostile creatures and players to leave you alone, and gain merchant discounts when toggling your begging demeanor.

## Overview

| Property | Value |
|---|---|
| **Primary Stat** | Dexterity |
| **Usage** | Active (targeted) |
| **Skill Type** | Social / Utility |
| **Skill Check** | Target difficulty based on creature stats |

## Description

Begging has three uses: requesting gold from NPCs, pacifying hostile targets in combat, and toggling a begging demeanor that grants vendor discounts. Combat begging is especially useful against dangerous creatures, though it costs karma and fame.

## How It Works

### Begging Gold from NPCs

Target a human NPC while within 2 tiles. Your character bows, and after a short delay the NPC may give you gold. The amount depends on how much the NPC is carrying (up to 1/10 of their gold, capped at 10-14 based on your fame). Negative karma reduces your chance of success.

**Karma Warning:** Successfully begging from NPCs costs **-40 Karma**.

### Begging Enemies to Stop Attacking

Target a hostile creature or player who is attacking you. Your character cries out pleas like "Have mercy!" or "Leave me alone!" On success, the target is **pacified** and stops fighting.

- **Against creatures:** Pacified for 10-120 seconds based on difficulty. On a very strong result the creature may additionally be paralyzed briefly (only applies to `BaseCreature`). Difficulty is calculated from HitsMax, StamMax, ManaMax, SkillsTotal, and bonuses for magery, fire breath, poison immunity, and paragon status (`Begging.cs:82-121`).
- **Against players:** A successful beg simply ends the target player's combat mode. **Players are never paralyzed by begging** — the paralysis branch only fires against creatures (`Begging.cs:262-288`).
- Uncalmable creatures cannot be begged.
- Bard-pacified creatures cannot be begged again.

**Karma/Fame Warning:** Using begging in combat costs **-40 Karma** and **-40 Fame**.

### Toggle Begging Demeanor

Target yourself to toggle "begging demeanor" mode on or off. While active, this enables merchant discounts (see What It Affects) and is checked by various systems. The pose is detected via `BaseVendor.BeggingPose()` which returns your Begging skill value if the demeanor is active (`BaseVendor.cs:355-366`).

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

## What It Affects

### Merchant Discounts

When begging demeanor is toggled on, vendor services receive a **0.5% per skill value discount** (formula: `cost - (skill * 0.005 * cost)`, minimum 1 gold).

**Core vendor services:**
- `BaseVendor.cs:1148-1152` — Buy price: replaces Mercantile barter value with Begging value; costs -40 Karma
- `BaseVendor.cs:2041-2048` — Sell price: replaces Mercantile barter value with Begging value
- `BaseVendor.cs:2388-2392` — Recharge service discount
- `BaseVendor.cs:2407-2412` — Identify service discount (200g base)
- `BaseVendor.cs:2428-2433` — Repair service discount
- `BlackMarket.cs:138-139` — Black Market uses Begging instead of Mercantile

**Individual vendors with begging discount:**
- `BaseHealer.cs:213,246,279,312` — Healer
- `MageGuildmaster.cs:129,161` — Mage Guildmaster
- `NecromancerGuildmaster.cs:196,228` — Necromancer Guildmaster
- `DruidGuildmaster.cs:131,163` — Druid Guildmaster
- `ElementalGuildmaster.cs:122,154` — Elemental Guildmaster
- `LibrarianGuildmaster.cs:173,200` — Librarian Guildmaster
- `CartographersGuildmaster.cs:104,136` — Cartographers Guildmaster
- `Tailor.cs:116,117,149,189,229` — Tailor
- `Weaver.cs:101,102,134` — Weaver
- `Thief.cs:129,156` — Thief
- `Painter.cs:78` — Painter
- `Mapmaker.cs:107,139` — Mapmaker
- `Jester.cs:137,189` — Jester
- `GypsyLady.cs:171,217,259,301,341` — Gypsy Lady

Note: Player Barkeepers do **not** offer begging discounts.

### Quests
- `Museum.cs:102` — Museum (Antiques): extra gold when selling antiques = `(cost * Begging * 0.01 / 4)` if begging pose active
- `Prisoner.cs:320-326` — Prisoners quest: reduces prisoner join cost by `(Begging * 25)`, max 3000 gold reduction
- `Cargo.cs:867` — Cargo/Boats: extra port cargo gold = `(cargoValue * Begging * 0.01 / 3)` if begging pose active

### Jester Magic System
- `JesterSpell.cs:15` — CastSkill returns `SkillName.Begging`
- `JesterSpell.cs:137` — Duration: `Begging / 2` (max 60)
- `JesterSpell.cs:142` — Buff strength: `Begging / 4` (max 25)
- `JesterSpell.cs:147` — Skill check: `Begging / 2` (max 60)
- `JesterSpell.cs:152` — Damage: `Begging / 25` (max 4)
- `Hilarity.cs:103` — Duration: `Psychology + (Psychology + Begging) / 8` seconds
- `SeltzerBottle.cs:49` — Damage: `1 + (Begging / 5) + (Psychology / 3)`
- `SeltzerBottle.cs:54` — Chance to leave MonsterSplatter based on Begging check vs random(50,300)
- `FlowerPower.cs:49` — Damage: `1 + (Begging / 5) + (Psychology / 3)`
- `FlowerPower.cs:54` — Chance to leave MonsterSplatter based on Begging check vs random(50,300)
- `CanOfSnakes.cs:58` — Each Begging check vs random(1,200) that succeeds adds +1 snake
- `Clowns.cs:70` — Each Begging check vs random(1,200) that succeeds adds +1 clown
- `RabbitInAHat.cs:63-64` — Two independent Begging checks vs random(1,200), each succeeds adds +1 rabbit

### Items
- `Artifact_BeggarsRobe.cs:15` — **Beggar's Robe** (Artifact): +30 to Begging skill, +100 Luck
- `Players.cs:130` — **Bag of Tricks**: requires Begging >= 10 **OR** Psychology >= 10 to use

### Training & Behavior
- `Behavior.cs:6247` — AI NPCs auto-train Begging as a practiced skill
- `CharacterCreation.cs:202` — Selectable skill during character creation
- `BaseRunicTool.cs:189` — Can affect Begging skill
- `Elixirs.cs:688` — Can be a skill type for certain elixirs
- `SpecialScroll.cs:64` — Skill index 7 maps to Begging
- `BaseRace.cs:1306` — Skill index 6 maps to Begging
- `PowerScroll.cs:15,208,283,389` — Begging can gain a power scroll

## Related Systems & Skills

### Synergies
- [Psychology](psychology.md): Used together in Jester spell calculations (Hilarity, Seltzer Bottle, Flower Power). Also checked as alternative for Bag of Tricks.
- [Mercantile](mercantile.md): Competing barter skill for vendor discounts. Begging replaces Mercantile when begging pose is active.
- [Jester](../magic/jester.md): Begging is the primary stat for the Jester magic system.

### Prerequisites / Co-requisites
- [Peacemaking](peacemaking.md): Alternative pacification method using music. Consider which is more efficient for your target.
- [Hiding](hiding.md): An alternative way to disengage from combat without the karma/fame cost of begging in combat.

## Notes
- Combat begging costs **-40 Karma** and **-40 Fame** — use sparingly.
- NPC gold begging also costs **-40 Karma** on success.
- Players cannot be paralyzed by begging — only creatures.
- Bard-pacified creatures cannot be begged again.
