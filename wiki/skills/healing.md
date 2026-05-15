# Healing

Healing allows you to mend your own wounds, cure poison, and stop bleeding without bandages or reagents.

## Overview

| Property | Value |
|---|---|
| **Primary Stat** | Intelligence |
| **Usage** | Active (self-only) |
| **Skill Type** | Trainable |
| **Skill Check** | -50 – 99.9 |

## Description

Healing is a self-only skill that heals hit points, cures poison, and stops bleeding in a single use. It is the primary stat for Holy Man spells, contributes to henchman healing formulas, and unlocks bandage-related features.

## How It Works

### Priority Order

Using the Healing skill on yourself follows this priority:

1. **Cure Poison & Stop Bleeding** — If you are poisoned or bleeding, healing cures both conditions in a single use.
2. **Heal Hit Points** — If you are injured but not poisoned/bleeding, you heal a calculated amount of HP.
3. **Already Healthy** — If at full health, you receive "You already feel healthy."

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

On a **failed** skill check (checked against -50 to 99.9), the heal amount is reduced to **75%** of normal (`Healing.cs:13-62`).

### Restrictions

- **Cannot heal while starving** (Hunger < 6).
- **Cannot heal under Mortal Strike** (the wound prevents healing).

## How to Train

Use the skill whenever you are injured. The skill check range is -50 to 99.9, meaning you can gain at any skill level as long as you have damage to heal. Healing is a **trainable skill** (`SkillCheck.cs:275`).

Power Scrolls for Healing cap the skill at **125** (`PowerScroll.cs:239,294,396`).

## What It Affects

### Self-Healing (Core Mechanic)

- `Healing.cs:13-62` — Main skill handler. Heals self, cures poison, stops bleeding. Check range: -50 to 99.9. Failing reduces heal to 75%.
- `ResourceMods.cs:1875` — Maps skill index 23 to Healing skill.
- `CharacterCreation.cs:919,929` — Healing (30) is an optional starting skill for certain character archetypes.
- `SkillCheck.cs:275` — Healing is always a valid training skill (unlimited gain).

### Combat & Weapons

- `CombatBar.cs:85` — Requires **5.0 Healing** to unlock the CombatBar feature.
- `Bandage.cs:294` — Bandage crafting uses Healing skill for quality determination.
- `Bandage.cs:156-212` — Bandages can resurrect dead henchmen; requires **80 Anatomy + 80 Healing**.

### Henchmen & Comrades

- `HenchmanFunctions.cs:221-248` — Henchmen auto-heal using Healing + Anatomy. Heal range: `(Anatomy/4 + Healing/4 + 6)` to `(Anatomy/4 + Healing/2 + 20)`. Poison cure thresholds: 60, 70, 80, 90.
- `HenchmanFighter.cs:75` — Fighter henchmen trained in Healing.
- `HenchmanArcher.cs:75` — Archer henchmen trained in Healing.
- `HenchmanWizard.cs:80` — Wizard henchmen trained in Healing.
- `HenchmanMonster.cs:63,84,96` — Creature henchmen trained in Healing.

### NPCs & Vendors

- `BaseHealer.cs:56` — All healer NPCs (Healer, WanderingHealer, EvilHealer) have **75.0–97.5 Healing**. Also trained in Anatomy (75–97.5), Psychology (82–100), Magery (82–100).
- `Healer.cs:28` — Healer NPC has Healing in its skill list.
- `WanderingHealer.cs:30` — Wandering Healer NPC has Healing in its skill list.
- `EvilHealer.cs:29,40` — Evil Healer NPC has **80.0–100.0 Healing**.
- `HealerGuildmaster.cs:22` — Healer Guildmaster has **90.0–100.0 Healing**.
- `Priest.cs:27,118` — Priest discounts based on Healing (and Spiritualism) skill. Requires Healing > 0 for certain rewards at karma 2500+.
- `OmniAI Shared.cs:88` — Omni AI NPCs use bandages on self when Healing > 10.0.
- `BaseCreature.cs:9298,9330` — BaseCreature healing AI checks Healing skill. Poison cure: skill checked 0–90 + poisonLevel*10. Normal heal: skill checked 0–90.

### Magic Systems

#### Holy Man

- `HolyManSpell.cs:19` — Holy Man spells use Healing as the `DamageSkill` (skill to check for spell power).
- `TouchOfLifeSpell.cs:42` — Heal amount: `1 + (Healing/10) + (Spiritualism/10)`.
- `SmiteSpell.cs:50` — Benefit value: `(Healing/10) + (Spiritualism/10)`.
- `SeanceSpell.cs:146` — Seance value: `Healing + (Spiritualism/2)`.
- `SanctifySpell.cs:69,92` — Duration/modify: `(Healing/2) + (Spiritualism/2)`. Duration span: `Healing + (Spiritualism/2)`.
- `SacredBoonSpell.cs:130` — Boon heal: `1 + (Healing/25) + (Spiritualism/25)`.
- `NourishSpell.cs:45` — Nourish value: `Healing/5`.
- `EnchantSpell.cs:85` — Enchant value: `Healing` (direct).
- `HammerOfFaithSpell.cs:74` — Duration: `Healing/5.0`.
- `HeavenlyLightSpell.cs:51` — Dungeon level scaling: `Healing/100`.
- `TrialByFireSpell.cs:56` — Trial value: `(Healing + Spiritualism)/4`.

#### Research (Theurgy)

- `ResearchHealingTouch.cs:66` — Heals `(DamagingSkill/2)`, capped at 12–125.

#### Druidism (Herbalism)

- `HerbalHealingSpell.cs:52` — Heals `Herbalism + DamagingSkill + PotionEnhance`, also cures poison and removes curses. Requires 45.0 Herbalism.

### Items & Equipment

- `Artifact_RingOfHealth.cs:16` — Ring of Health grants **+25 Healing**.
- `Artifact_StitchersMittens.cs:17` — Stitcher's Mittens grant **+25 Healing**.
- `GuildRing.cs:57` — Healer's Guild Ring grants **+15 Healing**.
- `BaseRunicTool.cs:206,247` — Runic tool crafting has Healing-skill-based options.
- `PowerScroll.cs:239,294,396` — Power Scrolls for Healing cap at **125**.

### Character Title & Display

- `Players.cs:43` — Healing skill base is factored into character titles.
- `Players.cs:247` — Skill index 23 maps to Healing in display gumps.
- `SkillsGump.cs:501` — Healing listed in the SkillsGump.
- `SkillListing.cs:85,172` — Healing appears in skill listing commands.
- `SkillArchive.cs:88` — Healing archive property for avatar system.
- `BaseRace.cs:1317` — Race skill index 17 maps to Healing.
- `SpecialScroll.cs:75` — Skill index 18 maps to Healing on special scrolls.

### Quests & Codex

- `CodexWisdom.cs:408` — Codex wisdom rewards can grant Healing skill points.

## Related Systems & Skills

### Synergies
- [Anatomy](anatomy.md): evaluates targets' physical condition; combined with Healing for henchman heal amounts and NPC healing formulas.
- [Spiritualism](spiritualism.md): alternative self-healing using spiritual energy; combined with Healing in Holy Man spell formulas.
- [Begging](begging.md): reduces gold cost of henchman resurrection by BaseHealer vendors.

### Prerequisites / Co-requisites
- [Anatomy](anatomy.md): required alongside Healing (80 Anatomy + 80 Healing) to resurrect dead henchmen via bandages.
- [Spiritualism](spiritualism.md): paired in all Holy Man spell formulas for heal amounts, durations, and benefits.

## Notes
- Healing is one of the most frequently used skills in the game, with applications from daily wound treatment to high-level resurrection.
- Poison curing requires both Healing >= 60 AND Anatomy >= 60.
- Henchman resurrection via bandages requires 80 Anatomy + 80 Healing.
