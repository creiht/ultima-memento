# Searching

Searching (Detect Hidden) lets you reveal hidden players, uncover traps, find secret doors, and discover hidden treasure chests.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Intelligence |
| Usage | Active (targeted location) |
| Range | 12 tiles (targeting), variable detection range |
| Cooldown | 6 seconds |
| Skill Check | 0 - 125 |

## How It Works

Use the skill and target a location. Everything hidden within your detection range centered on that point is checked.

### Detection Range

```
Range = Searching Skill / 10
```

On a failed skill check, the range is **halved**. Inside a house where you are a Friend, the range is always **22 tiles**.

| Searching Skill | Range (Success) | Range (Failure) |
|---|---|---|
| 50 | 5 tiles | 2 tiles |
| 100 | 10 tiles | 5 tiles |
| 125 | 12 tiles | 6 tiles |

### What You Can Find

#### Hidden Players
Your Searching skill (+/- random 10) is compared against the target's [Hiding](hiding.md) skill (+/- random 10). If yours is higher, they are revealed. Party members are ignored.

#### Traps
Detects various trap types within range:
- Fire Column Traps, Flame Spurt Traps
- Poison Gas Traps, Giant Spike Traps
- Saw Blade Traps, Spike Traps
- Stone Face Traps, Odd Mushrooms
- Hidden Floor Traps (also marks them as discovered)
- Killer Tiles ("It's a trap! Death awaits.")

#### Hidden Doors
Secret doors within range are automatically opened when detected.

#### Hidden Chests
Hidden treasure chests can be uncovered. The quality of discovered chests depends on:
- `Searching Skill / 20` (max 6 levels)
- Plus area difficulty bonus (max 4 levels)
- Total level capped at 1-10

### Night Sight Bonus

Even if a normal skill check fails, the **Night Sight** equipment attribute provides an additional chance to spot traps and hidden objects in the dark.

Multiple items in range are checked, with the first `Searching Skill / 10` items getting a full skill check and the rest relying on passive detection only.

## How to Train

Use the skill in areas with hidden creatures, traps, or objects. Dungeons with traps are ideal. The skill check is 0-125, allowing gains at any level.

## What It Affects

### Hidden Chests
The quality of discovered treasure chests scales with Searching skill. Chest level = `floor(Searching / 20)` (max 6), plus up to 4 bonus levels from area difficulty, capped at 10 total. Higher levels yield more gold and better loot.

- `World/Source/Scripts/System/Skills/Searching.cs:228` - Level calculation
- `World/Source/Scripts/Items/Containers/HiddenChest.cs:40` - `FoundBox()` uses level for loot generation

### Passive Trap Detection
Walking over a hidden floor trap with **5+ Searching** triggers a passive check (`CheckSkill 0-125`). If successful, the trap becomes visible with a warning message and disappears after 5 minutes.

- `World/Source/Scripts/Items/Traps/HiddenTrap.cs:1202` - `PassiveSearching()` requires `Skills.Searching.Value >= 5`

### Anti-Macro Protection
Searching has anti-macro protection enabled, meaning skill gains require actual movement and legitimate use rather than rapid repeated clicks.

- `World/Source/Scripts/System/Skills/SkillCheck.cs:30` - `true` (anti-macro enabled)

### Items Affected by Searching
- **Detective Boots of the Royal Guard** - Provides +10 to +25 bonus to Searching as a skill bonus slot
  - `World/Source/Scripts/Items/Magical/Artifacts/Clothing/Foot/Artifact_DetectiveBoots.cs:14`
- **Elixir of Detect Hidden** - Temporarily buffs Searching with a skill mod
  - `World/Source/Scripts/Items/Potions/Elixirs/Elixirs.cs:1312`
- **Runic Tools** - Searching is among the skills that can appear on runic tools
  - `World/Source/Scripts/Items/Trades/Magical/Tools/BaseRunicTool.cs:197`

## Related Systems

### Spells with Similar Functionality
Several spells across magic systems replicate Searching's detection behavior (traps + hidden chests):

| Spell | Magic System | Stat Used | Chest Level Formula |
|---|---|---|---|
| [Reveal](../magic/magery.md) | Magery | `Magery / 16` (max 6) | `World/Source/Scripts/Engines and Systems/Magic/Magery/Spells/Magery 6th/Reveal.cs:112` |
| [Mind's Eye](../magic/jedi.md) | Jedi | `GetJediDamage() / 50` (max 6) | `World/Source/Scripts/Engines and Systems/Magic/Jedi/Spells/MindsEye.cs:118` |
| [Eagle Eye](../magic/shinobi.md) | Shinobi | `Ninjitsu / 16` (max 6) | `World/Source/Scripts/Engines and Systems/Magic/Shinobi/Spells/EagleEye.cs:118` |
| [Gem of Seeing](../items/magical.md) | Artifact | No skill check (always uses Night Sight) | `World/Source/Scripts/Items/Magical/Artifacts/Minor/GemOfSeeing.cs:131` |

### NPCs that Use Searching

| Mobile | Searching Value | Notes |
|---|---|---|
| Revenant | 75.0 × difficulty scalar | Actively uses Searching skill in combat to reveal hidden targets (`World/Source/Scripts/Mobiles/Undead/Revenant.cs:137`) |
| Assassin/Thief Guildmasters | 75.0 - 98.0 | `World/Source/Scripts/Mobiles/Civilized/Guilds/` |
| Black Knights, Bone Demons, Ice Golems, WereWolves | 80.0 | `World/Source/Scripts/Mobiles/Humanoids/Humans/BlackKnight.cs:46`, etc. |
| Recluse/Phase Spiders, Soul Reaper | 125.0 | `World/Source/Scripts/Mobiles/Insects/Spiders/ShadowRecluse.cs:52`, `World/Source/Scripts/Mobiles/Undead/SoulReaper.cs:73` |
| Pirate/Elf Pirate Captains | 80.0 | `World/Source/Scripts/Mobiles/Humanoids/Sailors/Pirates/PirateCaptain.cs:73` |
| Rogues, Elf Rogues, Orc Rogues | 20.0 + difficulty bonus | `World/Source/Scripts/Mobiles/Humanoids/Humans/Rogue.cs:80` |
| Citizens, Thieves, Rangers | 20.0 - 98.0 range | `World/Source/Scripts/Mobiles/Civilized/Merchants/Thief.cs:28` |
| Xenomorphs, Xenomutants | 80.1 - 100.0 | `World/Source/Scripts/Mobiles/Unusual/Xenomorph.cs:40` |
| Most other humanoid NPCs | 20.0 | Monks, Berserkers, Orc Warriors |

### Creature AI Searching
When `S_CreaturesSearching` is enabled (default), NPCs in the Omni AI system can detect hidden player characters. The detection chance formula:

```
chance = Searching / 1.2 - min(Hiding / 2.9, Stealth / 1.8)
```

Minimum chance is `Searching / 10`. This runs periodically on AI-controlled creatures with 10+ Searching.

- `World/Info/Scripts/Settings.cs:429` - `S_CreaturesSearching = true` (default)
- `World/Source/Scripts/Mobiles/Base/Behavior.cs:8797` - `Searching()` AI method
- `World/Source/Scripts/Mobiles/Base/Behavior.cs:8977` - Cooldown trigger for AI searching

### Tracking Synergy
When tracking a hidden player, both Tracking and Searching are combined against the target's Hiding and Stealth:

```
divisor = Hiding + Stealth
```

Necromancy transformations modify this divisor (Horrific Beast reduces it by 200, Vampiric Embrace caps it at 500, Wraith Form adds 200).

- `World/Source/Scripts/System/Skills/Tracking.cs:345` - `from.Skills[SkillName.Searching].Fixed`
- `World/Source/Scripts/System/Skills/Tracking.cs:341` - Comment: "Tracking players uses tracking and searching vs. hiding and stealth"

### Related Skills
- [Hiding](hiding.md) - The skill Searching contests against to reveal hidden players.
- [Remove Trap](remove-trap.md) - Disarms traps after Finding them; does not share the passive detection mechanic.
- [Tracking](tracking.md) - Combined with Searching for tracking hidden players.
- [Stealth](stealth.md) - Combined with Hiding to resist Searching detection.
- [Night Sight](../magic/magery.md) - The Night Sight equipment attribute (`AosAttribute.NightSight`) provides a 2% chance per point to detect hidden items even on failed skill checks. Spell/potion Night Sight adds a further 2%.
- [Snooping](snooping.md) - Similar rogue skill for container inspection.
- [Stealing](stealing.md) - Another rogue skill with comparable AI behavior patterns.
