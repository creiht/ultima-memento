# Spiritualism

Spiritualism (Spirit Speak) lets you channel spiritual energy to heal yourself, restore stamina, and communicate with the dead.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Intelligence |
| Usage | Active |
| Cooldown | 5 seconds |
| Mana Cost | 10 (without corpse), 0 (with nearby corpse) |

## How It Works

Spiritualism has two modes depending on whether a nearby corpse is available.

### With a Nearby Corpse (within 3 tiles)

If an unchanneled, non-animated corpse is nearby, you draw energy from it:
- The corpse turns grey (hue 0x835) and is marked as channeled.
- You **heal HP** and **restore Stamina** by a random amount.
- You also **gain 25% of the roll as Mana**.
- **No mana cost.**

### Without a Corpse

You channel your own spiritual energy:
- Costs **10 mana**.
- You **heal HP** and **restore Stamina** by a random amount.

### Heal Formula

```
Min = 1 + (Spiritualism Skill * 0.25) + (Fist Fighting Skill * 0.15)
Max = Min + 4
```

Both min and max are further modified by the player level system (`PlayerLevelMod`).

### Success Chance

```
Success Rate = Spiritualism Skill / 100
```

At 100 skill you always succeed; at 50 skill you succeed 50% of the time.

### Mantras and Effects

Your character speaks a mantra when channeling:
- **Positive karma:** "Anh Mi Sah Ko" (with a gentle sound and golden particles)
- **Negative karma:** "Xtee Mee Glau" (with a harsh sound and dark particles)

### Hear Ghosts (Legacy Mode)

In non-AOS mode, successful use grants the ability to **hear ghosts** (dead players' speech) for a duration based on skill: `(Skill / 50) * 90` seconds (minimum 15 seconds, maximum ~3 minutes).

### Restrictions

- Cannot use while poisoned.
- Cannot use while starving (Hunger < 1) or dying of thirst (Thirst < 1).
- Must have enough mana (10) when no corpse is available.

## What It Affects

### Combat & Weapons
- `World/Source/Scripts/System/Skills/Weapon Abilities/ForceofNature.cs:73` — Force of Nature weapon ability deals damage scaled by `Spiritualism / 15` (min 4 hits)
- `World/Source/Scripts/Engines and Systems/Magic/Necromancy/WraithForm.cs:40` — Wraith Form mana leech % = `5 + (15 × Spiritualism) / 100`, ranging from 5% to 20%

### Crafting & Harvest
- `World/Source/Scripts/Engines and Systems/Trades/Harvest/GraveRobbing.cs:269,285,287` — Grave robbing: `Spiritualism / 10` reduces the chance of raising undead from graves (used in the roll `Utility.Random(100) > (nSpiritualism + 85)`, i.e. 10% base chance reduced by skill); also calls `CheckSkill(Spiritualism, 0, 100)` for skill gains

### Items
- `World/Source/Scripts/Items/Misc/Bodies/Corpses/Corpse.cs:45` — Corpses track a `Channeled` flag set when Spiritualism is used on them, turning them grey (hue 0x835) to prevent re-use
- `World/Source/Scripts/Items/Containers/DungeonChest.cs:276` — Coffin openings: higher Spiritualism reduces 10% chance of raising undead from tombstones and sarcophagi (`Utility.RandomMinMax(1,100) > seance`)
- `World/Source/Scripts/Items/Trades/Magical/Tools/BaseRunicTool.cs:227,314,366` — Spiritualism is a valid skill for runic tool enchantments (crafting tools, weapon tool, armor tool)

### Artifacts (Skill Bonuses)
| Item | Skill Bonus Slot | Value |
|---|---|---|
| `Artifact_BloodwoodSpirit.cs` — Bloodwood Spirit Staff | 0 | +30 |
| `Artifact_ANecromancerShroud.cs` — Shroud of the Necromancer | 0 | +25 |
| `Artifact_VampiresRobe.cs` — Nosferatu's Robe | 0 | +20 |
| `Artifact_GrimReapersRobe.cs` — Grim Reaper's Robe | 1 | +15 |
| `Artifact_GrimReapersLantern.cs` — Grim Reaper's Lantern | 1 | +15 |
| `Artifact_RobeOfTheEclipse.cs` — Robe of the Eclipse | 1 | +10 |
| `Artifact_GrimReapersMask.cs` — Grim Reaper's Mask | 1 | +10 |
| `Artifact_Candles.cs` — Candles of the Dead | 2 | +10 |
| `Artifact_OssianGrimoire.cs` — Ossian's Grimoire | 1 | +10 to +30 (random, rolls × 5) |

### Guild Rewards
- `World/Source/Scripts/Items/Trinkets/GuildRing.cs:78` — Necromancers Guild Ring gives +10 to Spiritualism on slot 2

### Quests
- `World/Source/Scripts/Mobiles/Civilized/Merchants/Priest.cs:118` — Priest quest reward: requires `Spiritualism > 0` and `Healing > 0` (in addition to reward >= 1000 and Karma >= 2500) to receive the Holy Symbol and Holy Man Spellbook

### Spell Systems
- `World/Source/Scripts/Engines and Systems/Magic/Research/ResearchFunctions.cs:367` — Research system: Spiritualism is checked alongside Magery, Necromancy, and Psychology when consuming research scrolls (`CheckSkill(Spiritualism, min, max)`)

### NPC Behavior
- `World/Source/Scripts/Mobiles/Base/Behavior.cs:9522` — `mySpiritualism` property exposed on BaseCreature for AI decision-making; also used as a valid taught skill (`Behavior.cs:6269`)
- `World/Source/Scripts/Mobiles/Base/PlayerMobile.cs:2710,2719` — Dead players can be heard by any living player with ≥100 Spiritualism (core ML and AOS speech mutation)

## How to Train

Use the skill regularly, ideally near corpses to avoid the mana cost. The skill check is 0-120 for gains.

## Related Skills

- [Fist Fighting](fist-fighting.md) — Contributes +15% of Fist Fighting base to the Spiritualism heal formula
- [Healing](healing.md) — Alternative self-healing that cures poison/bleeding; Healers and Priests teach Spiritualism
- [Meditation](meditation.md) — Mana regeneration; synergizes with Spiritualism's mana restoration
- [Necromancy](necromancy.md) — Both deal with death and spiritual energy; Research system checks both together; many undead NPCs have both skills
