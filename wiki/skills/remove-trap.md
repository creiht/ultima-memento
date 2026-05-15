# Remove Trap

Remove Trap allows you to disarm traps on containers and hidden floor traps.

## Overview

| Property | Value |
|---|---|
| **Primary Stat** | Dexterity |
| **Usage** | Active (targeted) |
| **Skill Type** | Utility / Defensive |
| **Skill Check** | 0 - 125 (varies by trap type) |

## Description

Remove Trap lets you disarm both trapped containers and hidden floor traps. Higher skill allows you to disarm harder traps and provides passive protection against certain deadly traps. The skill also scales with offensive trapping effectiveness.

## How It Works

Use the skill and target a trapped object.

### Trapped Containers (TrapableContainer)

For trapped containers, the difficulty is based on the trap level:

| Trap Level | Required Skill | Skill Check Max |
|---|---|---|
| 1 | 10 | 30 |
| 2 | 20 | 40 |
| 3 | 30 | 50 |
| 4 | 40 | 60 |
| 5 | 50 | 70 |

If your Remove Trap skill is below `TrapLevel * 10`, the trap "looks too complicated for you." On success, the trap is completely removed (type, level, and power all reset to zero). On failure, the trap remains but does **not** go off.

### Hidden Floor Traps (HiddenTrap)

Hidden traps found by [Searching](searching.md) can be disarmed with Remove Trap. The skill check is against 0-125. Light traps (weight < 5.0) can be disarmed; heavier ones cannot.

### Restrictions

- Cannot be used on mobiles.
- If the target is not trapped, you receive "That doesn't appear to be trapped."

## How to Train

Find trapped containers in dungeons and disarm them. The skill check scales with trap level, so you need progressively harder traps for gains at higher skill levels. Hidden floor traps provide a 0-125 check that works at any skill level.

## What It Affects

### Defensive & Passive Effects
- `HiddenTrap.cs:1276` — If Remove Trap >= 5.0, the game passively checks `CheckSkill(SkillName.RemoveTrap, 0, 125)` when walking near hidden floor traps. On success, the trap is disabled and a message is displayed.
- `TrapableContainer.cs:89` — When opening a container with Searching >= 5, if a trap is present, the game checks `CheckSkill(SkillName.Searching, 0, 125)` to warn you the container is trapped. If Searching fails, the trap is triggered — but Remove Trap then gets a chance to auto-disarm it via `ExecuteTrap()`.
- `TrapableContainer.cs:120-124` — When opening a trapped container, the game automatically tries `CheckTargetSkill(SkillName.RemoveTrap, this, 0, nTrapLevel2)` before triggering the trap. This means you can walk into dungeons with high Remove Trap and occasionally auto-disarm containers.
- `KillerTile.cs:33` — At 90+ Remove Trap, you get a 25% base chance to survive a killer tile, increasing by 1% per skill point above 90 (max ~35% at 125). On success, you take 1 hit instead of death. Below 90, no chance to avoid.

### Magic Spell — Remove Trap (Magery 2nd Circle)
- `RemoveTrap.cs` (spell) — Cast `Remove Trap` (An Jux) to either disarm a container directly using **Magery skill** (`Spell.ItemSkillValue(Caster, SkillName.Magery)`) against `TrapLevel * 12`, or cast on yourself to summon a `TrapWand` (magical orb) into your backpack.
- `RemoveTrap.cs:104` — The summoned TrapWand power = `Magery / 3 + 25` (caps at 66%). The TrapWand passively helps avoid hidden traps and container traps.
- `RemoveTrap.cs:110` — Casting on yourself grants a 30-minute `BuffIcon.RemoveTrap` buff displaying the TrapWand power.
- `SpellItemInfo.cs:64` — Spell description: "Deactivates a magical trap on a container, or you can cast on yourself to summon an orb of trap detection. Item orb would remain in your pack and help you avoid hidden traps."
- `ResearchFunctions.cs:825` — Research spell reference: Remove Trap, Circle 2, reagents Bloodmoss + SulfurousAsh, mana 16, required skill 40.
- `SpellBarsDisplay.cs:1307` — Available as spellbar slot 13.

### Crafting
- `DefAlchemy.cs:361` — `ElixirRemoveTrap` crafted by Alchemy at 60.0–120.0. Ingredients: Empty Bottle, Bat Wing, Emerald, SilverWidow. Name: "removing trap" elixir. Grants temporary Remove Trap skill boost.
- `Elixirs.cs:3756` — The elixir applies a temporary Remove Trap skill bonus via a Hashtable tracking effects. Uses `SkillName.RemoveTrap` as the skill identifier.
- `ItemSales.cs:3996` — ElixirRemoveTrap sold by Alchemy merchants for 70 gold (1–95 stock).

### Offensive — Trap Placement
- `TrapKit.cs:73-77` — Trapping tools require Remove Trap > 0 to use. Trap power = `RemoveTrap / 2 + 1` + resource bonus from crafting materials (e.g., Valorite tools add more).
- `Landmine.cs:56` — Technology landmine placement power = `RemoveTrap / 2 + 24`. Removes the landmine setup tool from inventory upon placement.
- `Talk.cs:66` — NPC Thief dialogue confirms: "The higher your trap removing skill, the more effective your trap will be. If you have trapping tools made from more precious metals, it would be even more effective."

### Quests & Special Encounters
- `PuzzleChest.cs:161` — When stealing from a Puzzle Chest pedestal and failing the solution check, `CheckSkill(SkillName.RemoveTrap, 0, 125)` is attempted to avoid trap damage. Success displays "You pull back just in time to avoid a trap!"
- `StealBase.cs:274` — Thief quest (stealing from pedestals): When Snooping fails, Remove Trap `CheckSkill(0, 125)` is checked to avoid trap damage before Stealing skill is tried.

### Items & Equipment (Skill Bonuses)
| Item | Slot | Bonus | Location |
|---|---|---|---|
| Torch of Trap Burning | Off-hand | +100 Remove Trap | `Artifact_TorchOfTrapFinding.cs:13` |
| Cloak of the Rogue | Back | +80 Remove Trap | `Artifact_GrayMouserCloak.cs:16` |
| Detective Boots of the Royal Guard | Feet | +10–25 Remove Trap (random) | `Artifact_DetectiveBoots.cs:16` |
| `BaseRunicTool.cs:225` — Remove Trap can receive bonuses via runic tool enchantment (one of ~20 enchantable skills). | | | |

### NPC Merchants
| Merchant | Remove Trap Range | Source |
|---|---|---|
| Tinker | 75.0–98.0 | `Tinker.cs:17` |
| Thief | 65.0–88.0 | `Thief.cs:30` |
| Tinker Guildmaster | 85.0–100.0 | `TinkerGuildmaster.cs:24` |
| Thief Guildmaster | 85.0–100.0 | `ThiefGuildmaster.cs:28` |

### Other Mechanics
- `PowerScroll.cs:57` — Remove Trap is a power-up skill (can be raised above 100.0 via power scrolls).
- `CharacterCreation.cs:1042` — Remove Trap cannot be assigned as a background skill bonus during character creation.
- `Behavior.cs:6265` — Remove Trap is listed in the NPC behavior skill list (NPCs may use it for certain actions).
- `PlayerMobile.cs:1432` — Remove Trap is included in the mobile's skill tracking list.
- `DynamicBook.cs:342` — The book "LearnTraps" contains the most detailed in-game explanation of trap mechanics, including all 27 hidden trap effects, container trap types, and how Remove Trap, Searching, TenFootPole, and TrapWand interact.

## Related Systems & Skills

### Synergies
- [Searching](searching.md): Detects hidden traps, secret doors, and hidden items. Works in tandem with Remove Trap to warn before triggering traps.
- [Stealing](stealing.md): Both skills are used together in the Thief quest line for stealing from pedestals.
- [Snooping](snooping.md): Snooping failure on pedestal steals triggers a Remove Trap check as fallback.
- [Forensics](forensics.md): Identifies lockpickers; complements Remove Trap for dungeon exploration.

### Prerequisites / Co-requisites
- [Magery](../magic/magery.md): Remove Trap is the 2nd circle Magery spell that provides a magical alternative to the skill.
- [Alchemy](../crafting/alchemy.md): Crafting the Elixir of Remove Trap for temporary skill boosts.
- [Tinkering](../crafting/tinkering.md): Tinkers have high Remove Trap; trapping tools can be crafted from various metals.

## Notes
- The magical Remove Trap spell uses **Magery skill** for its check, not Remove Trap skill, making it independent of your skill level.
- The Torch of Trap Burning artifact provides an enormous +100 bonus, essentially maxing the skill.
- At 90+ Remove Trap, you gain meaningful protection against killer tiles — a rare defensive application.
- Failed Remove Trap checks do **not** trigger the trap (safe to attempt even at low skill).
- `[buildworld` — After changing trap-related settings, run this console command to regenerate world content (spawners, merchants, traps).
- Remove Trap spell can be added to custom spell bars (slots 1-4) for quick casting.
