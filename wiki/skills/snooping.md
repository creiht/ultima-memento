# Snooping

Snooping lets you peek into the backpacks of other creatures and players to see what they are carrying.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Dexterity |
| Usage | Passive (triggered by opening a container on a mobile) |
| Range | 1 tile |
| Skill Check | 0 - 125 |

## How It Works

Snooping is triggered automatically when you attempt to open a container that belongs to another mobile (their backpack or a container within it). It is **not** an active skill you use from the skill list.

### Success

On a successful skill check (0-125), you see the contents of the container. If the container is trapped, the trap may go off when you open it.

### Failure

On failure, "You failed to peek into the container." Additionally, if your [Hiding](hiding.md) skill / 2 is less than a random 0-100 roll, you are **revealed** from hiding.

### Getting Noticed

Even on success, if your Snooping skill is below a random 0-100 roll, **everyone within 8 tiles** sees a message: "You notice [Name] attempting to peek into [Target]'s belongings."

### Restrictions

- Cannot snoop while in a blessed/invulnerable state.
- Cannot snoop player vendors.
- Cannot snoop staff members.
- In guarded areas, cannot snoop blue (innocent) human NPCs.
- Snooping costs **-4 Karma** if you have positive karma.
- Citizens can always be snooped freely.

## How to Train

Snooping gains come from attempting to open containers on creatures and NPCs. The skill check is 0-125.

## What It Affects

### Core Mechanics
- `Snooping.cs:11-116` — Main skill handler; registers `Container_Snoop` as the container snoop callback via `Container.SnoopHandler`.
- `Snooping.cs:18-43` — `CheckSnoopAllowed()` enforces restrictions: cannot snoop while blessed, cannot snoop innocent human NPCs in guarded areas, citizens are always snooped freely.
- `Snooping.cs:72` — **Detection roll**: If your Snooping skill value is below a random 0-100, all players within 8 tiles see "You notice [Name] attempting to peek into [Target]'s belongings."
- `Snooping.cs:92` — Snooping costs **-4 Karma** when successful and your karma is positive.
- `Snooping.cs:95` — Skill check range is **0 - 125** via `CheckTargetSkill`.
- `Snooping.cs:107` — On failure, if your [Hiding](hiding.md) skill / 2 is less than a random 0-100, `RevealingAction()` is called, exposing you from hiding.
- `Snooping.cs:97` — Trapped containers (`TrapableContainer`) trigger their trap when snooped/opened.

### Stealing & Combat
- `Stealing.cs:241` — When a thief NPC fails to snoop a coffer, they check `CheckSkill(Snooping, 0, 150)` to determine whether nearby vendors notice ("Stop! Thief!"). Higher snooping = less likely to be reported.
- `Behavior.cs:3704` — **Hidden NPC stealing**: When you hide within 2 tiles of a creature, if their Stealing >= random 1-125 AND their Snooping >= random 1-100, there's a 1-in-5 chance they steal an item from your backpack (blessed items and multi-item containers are excluded).
- `BaseCreature.cs:6532-6539` — **Coin steal on attack**: When attacking a creature that carries coins, if you are within 1 tile and your Stealing >= 20 and your creature level < your Stealing AND your Snooping > random 20-126, you steal a portion of their coins. The amount stolen = `coins = coins * (1 - creatureLevel / yourStealing)`. Loot types include Gold, DDXormite, Crystals, and DDJewels.

### Thieves Guild & NPCs
- `SkillCheck.cs:263` — Thieves Guild members have Snooping auto-restricted (unlocked) as a core guild skill.
- `Thief.cs:32` — Thief vendor NPC has **65 - 88** Snooping.
- `ThiefGuildmaster.cs:24` — Thief Guildmaster has **90 - 100** Snooping.
- `GypsyLady.cs:98` — Gypsy Lady has **65 - 88** Snooping.
- `Rogue.cs:88` (Humans), `ElfRogue.cs:83` (Elves), `OrkRogue.cs:87` (Orcs) — Rogue NPCs have **50+** Snooping (varies by bonus).

### Required Skills & Prerequisites
- `DisguiseKit.cs:59` — Disguise Kit requires at least **50 base** in Snooping (along with 50 base in Ninjitsu, Stealth, Hiding, or Psychology) to use.

### Items & Equipment (Skill Bonuses)
| Item | Location | Bonus | Source |
|---|---|---|---|
| Burglar's Bandana | `Artifact_BurglarsBandana.cs:21` | +10 Snooping (Skill Bonus slot 2) | Artifact |
| Detective Boots | `Artifact_DetectiveBoots.cs:18` | +10-25 Snooping (Skill Bonus slot 4) | Artifact |
| Cloak of the Rogue | `Artifact_GrayMouserCloak.cs:15` | +25 Snooping (Skill Bonus slot 1) | Artifact — largest flat bonus |
| Thieves Guild Ring | `GuildRing.cs:49` | +10 Snooping (Skill Bonus slot 2) | Thieves Guild membership |

### Consumables
- `Elixirs.cs:3860-3955` — **Elixir of Snooping** (`ElixirSnooping`) adds a temporary `DefaultSkillMod` to Snooping for a duration. Brewable at Alchemy from a Potion Keg (`PotionKeg.cs:409`). Market price: 70-95g at Alchemy market (`ItemSales.cs:3997`).

### Magic Systems
- `ForceGrip.cs:62` (Jedi/ForceGrip) — When using Force Grip to interact with a container on another mobile, calls `item.OnSnoop(caster)` instead of opening normally.
- `Psychokinesis.cs:62` (Syth/Psychokinesis) — Same behavior: calls `item.OnSnoop(caster)` to snoop containers via telekinesis.

### Containers & Lockable Items
- `LockableContainer.cs:324-330` — Locked containers block snooping just like opening. If `CheckLocked(from)` returns true, snooping is prevented entirely.
- `BaseRunicTool.cs:226` — Runic tools can enchant items with Snooping as a possible skill bonus.

### Scroll System
- `SpecialScroll.cs:86` — Snooping is skill index 29 on special scrolls.

### Race System
- `BaseRace.cs:1328` — Race skill slot 28 maps to Snooping for racial skill assignments.

## Related Skills

- [Stealing](stealing.md) — Directly paired; Snooping enables stealing from containers and creatures. Thieves Guild auto-restricts both.
- [Hiding](hiding.md) — Failed Snooping may reveal you based on Hiding / 2 vs random 0-100. Hiding also protects against NPC theft (Behavior.cs:3700).
- [Lockpicking](lockpicking.md) — Both used on containers; LockableContainer blocks both. Thieves Guild auto-restricts both.
- [Stealth](stealth.md) — Thieves Guild auto-restricts both; both synergize with covert operations.
- [Searching](searching.md) — Complementary skill for finding hidden items and containers.
- [Remove Trap](remove-trap.md) — Trapped containers trigger on Snooping; both appear on Thieves Guild Ring and artifact equipment.
- [Disguise Kit](stealing.md) — Requires 50 base Snooping to use the Disguise Kit item.
