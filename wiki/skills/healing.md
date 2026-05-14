# Healing

Healing allows you to mend your own wounds, cure poison, and stop bleeding without bandages or reagents.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Intelligence |
| Usage | Active (self-only) |
| Cooldown | 15 seconds (when healing), 1 second (when full health) |

## How It Works

Using the Healing skill on yourself has different effects depending on your current condition:

### Priority Order

1. **Cure Poison & Stop Bleeding** - If you are poisoned or bleeding, healing will cure the poison and/or stop the bleeding. Both conditions can be cured in a single use.
2. **Heal Hit Points** - If you are injured but not poisoned/bleeding, you heal a calculated amount of HP.
3. **Already Healthy** - If you are at full health, you receive the message "You already feel healthy."

### Heal Amount Formula

```
Base Amount = 2 + (Healing Skill / 5)
If skill > 100: Amount += 3 * (Skill - 100) / 5
```

| Healing Skill | Base Heal Amount |
|---|---|
| 50 | 12 |
| 100 | 22 |
| 125 | 42 |

On a **failed** skill check (checked against -50 to 99.9), the heal amount is reduced to **75%** of normal.

### Restrictions

- **Cannot heal while starving** (Hunger < 6).
- **Cannot heal under Mortal Strike** (the wound prevents healing).

## How to Train

Use the skill whenever you are injured. The skill check range is -50 to 99.9, meaning you can gain at any skill level as long as you have damage to heal.

## Related Skills

- [Anatomy](anatomy.md) - Evaluate targets' physical condition. Combined with Healing for henchman heal amounts and NPC healing formulas.
- [Spiritualism](spiritualism.md) - Alternative self-healing using spiritual energy. Combined with Healing in Holy Man spell formulas.
- [Begging](begging.md) - Reduces gold cost of henchman resurrection by BaseHealer vendors.

## What It Affects

### Self-Healing (Core Mechanic)

| File | Line | What it does |
|---|---|---|
| `System/Skills/Healing.cs` | 13-62 | Main skill handler. Heals self, cures poison, stops bleeding. Check range: -50 to 99.9. Failing reduces heal to 75%. |
| `System/Misc/ResourceMods.cs` | 1875 | Maps skill index 23 to Healing skill. |
| `System/Misc/CharacterCreation.cs` | 919, 929 | Healing (30) is an optional starting skill for certain character archetypes. |
| `System/Skills/SkillCheck.cs` | 275 | Healing is always a valid training skill (unlimited gain). |

### Combat & Weapons

| File | Line | What it does |
|---|---|---|
| `System/Commands/Player/CombatBar.cs` | 85 | Requires **5.0 Healing** to unlock the CombatBar feature. |
| `Items/Trades/Misc/Bandage.cs` | 294 | Bandage crafting uses Healing skill for quality determination. |
| `Items/Trades/Misc/Bandage.cs` | 156-212 | Bandages can resurrect dead henchmen; requires **80 Anatomy + 80 Healing**. |

### Items & Equipment

| File | Line | What it does |
|---|---|---|
| `Items/Magical/Artifacts/Jewelry/Artifact_RingOfHealth.cs` | 16 | Ring of Health grants **+25 Healing**. |
| `Items/Magical/Artifacts/Armor/Artifact_StitchersMittens.cs` | 17 | Stitcher's Mittens grant **+25 Healing**. |
| `Items/Trinkets/GuildRing.cs` | 57 | Healer's Guild Ring grants **+15 Healing**. |
| `Items/Trades/Magical/Tools/BaseRunicTool.cs` | 206, 247 | Runic tool crafting has Healing-skill-based options. |
| `Items/Books/PowerScrolls/PowerScroll.cs` | 239, 294, 396 | Power Scrolls for Healing cap at **125**. |

### Henchmen & Comrades

| File | Line | What it does |
|---|---|---|
| `Mobiles/Civilized/Comrades/HenchmanFunctions.cs` | 221-248 | Henchmen auto-heal using Healing + Anatomy. Heal range: `(Anatomy/4 + Healing/4 + 6)` to `(Anatomy/4 + Healing/2 + 20)`. Poison cure thresholds: 60, 70, 80, 90. |
| `Mobiles/Civilized/Comrades/HenchmanFighter.cs` | 75 | Fighter henchmen trained in Healing. |
| `Mobiles/Civilized/Comrades/HenchmanArcher.cs` | 75 | Archer henchmen trained in Healing. |
| `Mobiles/Civilized/Comrades/HenchmanWizard.cs` | 80 | Wizard henchmen trained in Healing. |
| `Mobiles/Civilized/Comrades/HenchmanMonster.cs` | 63, 84, 96 | Creature henchmen trained in Healing. |

### NPCs & Vendors

| File | Line | What it does |
|---|---|---|
| `Mobiles/Base/BaseHealer.cs` | 56 | All healer NPCs (Healer, WanderingHealer, EvilHealer) have **75.0-97.5 Healing**. Also trained in Anatomy (75-97.5), Psychology (82-100), Magery (82-100). |
| `Mobiles/Civilized/Healers/Healer.cs` | 28 | Healer NPC has Healing in its skill list. |
| `Mobiles/Civilized/Healers/WanderingHealer.cs` | 30 | Wandering Healer NPC has Healing in its skill list. |
| `Mobiles/Civilized/Healers/EvilHealer.cs` | 29, 40 | Evil Healer NPC has **80.0-100.0 Healing**. |
| `Mobiles/Civilized/Guilds/HealerGuildmaster.cs` | 22 | Healer Guildmaster has **90.0-100.0 Healing**. |
| `Mobiles/Civilized/Merchants/Priest.cs` | 27, 118 | Priest discounts based on Healing (and Spiritualism) skill. Requires Healing > 0 for certain rewards at karma 2500+. |
| `Mobiles/Omni AI/OmniAI Shared.cs` | 88 | Omni AI NPCs use bandages on self when Healing > 10.0. |
| `Mobiles/Base/BaseCreature.cs` | 9298, 9330 | BaseCreature healing AI checks Healing skill. Poison cure: skill checked 0-90 + poisonLevel*10. Normal heal: skill checked 0-90. |

### Magic Systems

#### Holy Man (19 magic systems)

| File | Line | What it does |
|---|---|---|
| `Magic/Holy Man/HolyManSpell.cs` | 19 | Holy Man spells use Healing as the `DamageSkill` (skill to check for spell power). |
| `Magic/Holy Man/Spells/TouchOfLifeSpell.cs` | 42 | Heal amount: `1 + (Healing/10) + (Spiritualism/10)`. |
| `Magic/Holy Man/Spells/SmiteSpell.cs` | 50 | Benefit value: `(Healing/10) + (Spiritualism/10)`. |
| `Magic/Holy Man/Spells/SeanceSpell.cs` | 146 | Seance value: `Healing + (Spiritualism/2)`. |
| `Magic/Holy Man/Spells/SanctifySpell.cs` | 69, 92 | Duration/modify: `(Healing/2) + (Spiritualism/2)`. Duration span: `Healing + (Spiritualism/2)`. |
| `Magic/Holy Man/Spells/SacredBoonSpell.cs` | 130 | Boon heal: `1 + (Healing/25) + (Spiritualism/25)`. |
| `Magic/Holy Man/Spells/NourishSpell.cs` | 45 | Nourish value: `Healing/5`. |
| `Magic/Holy Man/Spells/EnchantSpell.cs` | 85 | Enchant value: `Healing` (direct). |
| `Magic/Holy Man/Spells/HammerOfFaithSpell.cs` | 74 | Duration: `Healing/5.0`. |
| `Magic/Holy Man/Spells/HeavenlyLightSpell.cs` | 51 | Dungeon level scaling: `Healing/100`. |
| `Magic/Holy Man/Spells/TrialByFireSpell.cs` | 56 | Trial value: `(Healing + Spiritualism)/4`. |

#### Research (Theurgy)

| File | Line | What it does |
|---|---|---|
| `Magic/Research/Spells/Theurgy/ResearchHealingTouch.cs` | 66 | Heals `(DamagingSkill/2)`, capped at 12-125. |

#### Druidism (Herbalism)

| File | Line | What it does |
|---|---|---|
| `Magic/Druidism/Effects/HerbalHealingSpell.cs` | 52 | Heals `Herbalism + DamagingSkill + PotionEnhance`, also cures poison and removes curses. Requires 45.0 Herbalism. |

### Character Title & Display

| File | Line | What it does |
|---|---|---|
| `System/Misc/Players.cs` | 43 | Healing skill base is factored into character titles. |
| `System/Misc/Players.cs` | 247 | Skill index 23 maps to Healing in display gumps. |
| `System/Gumps/SkillsGump.cs` | 501 | Healing listed in the SkillsGump. |
| `System/Commands/Player/SkillListing.cs` | 85, 172 | Healing appears in skill listing commands. |
| `Avatar/SkillArchive.cs` | 88 | Healing archive property for avatar system. |
| `Mobiles/Races/BaseRace.cs` | 1317 | Race skill index 17 maps to Healing. |
| `Items/Misc/Scrolls/SpecialScroll.cs` | 75 | Skill index 18 maps to Healing on special scrolls. |

### Quests & Codex

| File | Line | What it does |
|---|---|---|
| `Quests/Codex/CodexWisdom.cs` | 408 | Codex wisdom rewards can grant Healing skill points. |
