# Meditation

Meditation allows you to enter a trance to regenerate mana at an increased rate.

## Overview

| Property | Value |
|---|---|
| **Primary Stat** | Intelligence |
| **Usage** | Active |
| **Skill Type** | Secondary (skill check) |
| **Skill Check** | 0 - 100 |

## Description

Meditation boosts your mana regeneration rate when you enter a meditative trance. It is the primary skill governing mana regeneration for all mobile types, with different formulas applying in AOS and non-AOS eras.

## How It Works

Using Meditation attempts to enter a meditative trance, which boosts your mana regeneration rate.

### Success Chance

```
Chance = (50 + (Skill - (Current Mana / Max Mana)) * 2) / 100
```

In practice, because the formula uses integer division of `(Mana / ManaMax)`, that term evaluates to `0` whenever mana is below maximum and `1` only at exactly full mana. Meditation **cannot be attempted when your mana is already full**; whenever it is below maximum, the success chance is driven purely by your Meditation skill — intermediate mana levels do not change the chance.

### Requirements

- You must not already be at full mana.
- **Armor interferes with meditation.** If you have too much armor, you receive the message "Regenerative forces cannot penetrate your armor!" Heavy armor prevents meditation entirely.
- You cannot meditate while targeting something.
- Items not compatible with meditation are automatically unequipped (moved to backpack).

### Compatible Held Items

The following items can be held while meditating:
- Spellbooks, Magic Rune Bags
- Tools and Harvest Tools
- Trinkets, Equippable Lights
- Weapons/Armor with the **Spell Channeling** property

### Using the Skill

On success, you enter a meditative trance (shown as a buff icon). A sound plays and your mana regeneration increases. On failure, "You cannot focus your concentration."

## How to Train

Use the skill whenever your mana is not full. The skill check is against 0-100. Because success chance depends on skill (not on how low your mana is), simply repeat Meditation after casting spells whenever mana is below max.

## What It Affects

### Mana Regeneration

Meditation is the primary skill governing mana regeneration for all mobile types. The formula differs between AOS and non-AOS eras:

**AOS Era (default):**
```
medPoints = Intelligence + (Meditation × 3)
medPoints *= (Meditation < 100) ? 0.025 : 0.0275
```

- `RegenRates.cs:125-127`
- At 100+ Meditation, you gain a 10% multiplier bonus (0.0275 vs 0.025).
- When meditating (buff active), mana points are capped at 13.0: `RegenRates.cs:136`

**Non-AOS Era:**
```
medPoints = (Intelligence + Meditation) × 0.5
```
- `RegenRates.cs:163`

### Armor Interference

Armor reduces meditation effectiveness. Each armor slot contributes to an armor penalty score:

- `RegenRates.cs:188-206` — `GetArmorOffset()` sums penalty from all 9 armor slots (neck, hand, head, arms, legs, chest, shoes, cloak, outer torso).
- `RegenRates.cs:209-221` — `GetArmorMeditationValue()`:
  - `MageArmor != 0` or `SpellChanneling != 0` → no penalty
  - `MeditationAllowance.None` → full base armor rating penalty
  - `MeditationAllowance.Half` → half base armor rating penalty
  - `MeditationAllowance.All` → no penalty

In AOS, any armor with a positive meditation offset **completely nullifies** the Meditation bonus to mana regen (`RegenRates.cs:133-134`).

Wear `MeditationAllowance.All` armor to meditate in armor without penalty.

### Skills That Affect or Are Affected by Meditation

- **Focus** — adds bonus mana regen points on top of Meditation (`RegenRates.cs:129-131`): `focusPoints = Focus × 0.05`
- **Druidism** — displays Meditation skill level on creature assessment panels (`System/Skills/Druidism.cs:512`)

### Crafting & Items

- **Elixir of Meditating** — Alchemy recipe: 60–120 skill, requires Beetle Shell, Ginseng, Amber, Bottle (`Engines and Systems/Trades/Crafting/DefAlchemy.cs:325`)
- **Elixir of Meditating** — sold by alchemy market vendors: price 70, market 1–95 (`System/Misc/ItemSales.cs:3989`)
- **Runic Tools** — can enchant items granting Meditation skill bonuses (`Items/Trades/Magical/Tools/BaseRunicTool.cs:216,296,312,322,365`)
  - Common skills pool: includes Meditation (`BaseRunicTool.cs:216`)
  - Spellbook skills pool: includes Meditation (`BaseRunicTool.cs:296`)
  - Necromancy tools pool: includes Meditation (`BaseRunicTool.cs:312`)
  - Ancient skills pool: includes Meditation (`BaseRunicTool.cs:365`)
- **Spellbooks** — require Meditation ≥ 100 base to open Mystic Spellbooks (`Engines and Systems/Magic/Magery/Spellbook.cs:788`)
- **Mystic Spells** — require Meditation ≥ 100 base to cast (`Engines and Systems/Magic/Mystic/MysticSpell.cs:120`)

### NPC Behavior & AI

- **Behavior AI** — NPCs use Meditation when mana is below maximum (`Mobiles/Base/Behavior.cs:9218`)
- **OmniAI** — uses Meditation when mana is low and skill exceeds 60.0 (`Mobiles/Omni AI/OmniAI Core.cs:149-154`)
- **BaseCreature** — Paragons set Meditation to 100.1–101.0 (`Mobiles/Base/BaseCreature.cs:2646`)

### Magic Systems

- **Necromancy — Animate Dead** — copies caster's Meditation value scaled by a multiplier to summoned undead (`Engines and Systems/Magic/Necromancy/AnimateDeadSpell.cs:314`)
- **Magery — Magic Lock** — can modify a target's Meditation skill (`Engines and Systems/Magic/Magery/Spells/Magery 3rd/MagicLock.cs:707`)
- **Elementalism** — Elemental summons inherit Meditation (45.0 for called elementals, 100.0 for elemental lords) (`Engines and Systems/Magic/Elementalism/Mobiles/` — ElementalCalledWater.cs:55, ElementalCalledFire.cs:40, ElementalCalledEarth.cs:50, ElementalCalledAir.cs:50, ElementalLordWater.cs:52, ElementalLordAir.cs:54)
- **Druidism — Protective Fairy** — sets Meditation to 90.0 on summoned fairy (`Engines and Systems/Magic/Druidism/Effects/ProtectiveFairySpell.cs:92`)

### Guilds

Meditation is a registered guild skill for both magical guilds:
- **Mage's Guild** (`System/Skills/SkillCheck.cs:243`)
- **Elemental Guild** (`System/Skills/SkillCheck.cs:249`)

### Races

Racial skill bonuses can assign Meditation as Skill_2_Name for certain race/magic school combinations (`Mobiles/Races/BaseRace.cs:417`)

### Quests & Rewards

- **Codex of Wisdom** — Meditation is one of the skills that can be learned from the Codex (`Engines and Systems/Quests/Codex/CodexWisdom.cs:94, 418`)
- **Bard's Tale — Mangar's Robes** — all three variants grant +10 Meditation:
  - `MangarRobe` (Mage) — `Engines and Systems/Quests/Bards Tale/MangarsRewards.cs:19`
  - `MangarNecroRobe` (Necromancer) — `MangarsRewards.cs:55`
  - `MangarElementalistRobe` (Elementalist) — `MangarsRewards.cs:91`

### Champion Spawns

Champion spawn NPCs carry very high Meditation values:
- **Serpentine Dragon** — 100.0 (`Engines and Systems/Champs/Mobiles/SerpentineDragon.cs:32`)
- **Silvani** — 100.0 (`Engines and Systems/Champs/Mobiles/Bosses/Silvani.cs:31`)
- **Semidar** — 95.1–100.0 (`Engines and Systems/Champs/Mobiles/Bosses/Semidar.cs:40`)
- **Neira** — 120.0 (`Engines and Systems/Champs/Mobiles/Bosses/Neira.cs:39`)
- **Lord Oaks** — 120.1–130.0 (`Engines and Systems/Champs/Mobiles/Bosses/LordOaks.cs:54`)

### Other Notes

- **Skill cap exemption** — Meditation is a secondary skill, meaning it ignores the total skill cap (`System/Skills/SkillCheck.cs:62`)
- **Skill listing UI refresh** — gains to Meditation trigger a UI refresh in the skill listing gump (`System/Skills/SkillCheck.cs:429`)
- **Avatar system** — Meditation is tracked in the avatar SkillArchive (`Engines and Systems/Avatar/SkillArchive.cs:131-132`), and is auto-locked when selecting an avatar template to prevent skill reduction (`Engines and Systems/Avatar/Reward/AvatarShopGumpRewards.cs:306-337`)
- **Gump categorization** — displayed under the "Magical" tab in SkillsGump (`System/Gumps/SkillsGump.cs:489`)

## Related Systems & Skills

### Synergies
- [Mystic Spells](../magic/mystic.md): require Meditation ≥ 100 base to cast
- [Mystic Spellbooks](../magic/magery.md): require Meditation ≥ 100 base to open
- [Elixir of Meditating](../crafting/alchemy.md): Alchemy recipe that grants Meditation skill bonuses
- [Runic Tools](../crafting/inscription.md): can enchant items granting Meditation skill bonuses
- [Focus](focus.md): adds bonus mana regen points on top of Meditation
- [Druidism](druidism.md): displays Meditation skill level on creature assessment panels

### Prerequisites / Co-requisites
- [Intelligence](../attributes/intelligence.md): Primary stat for mana regeneration calculations

## Notes
- Meditation is a secondary skill, meaning it ignores the total skill cap.
- You cannot meditate while your mana is full.
- Heavy armor prevents meditation entirely; wear `MeditationAllowance.All` armor to meditate without penalty.
- In AOS era, any armor with a positive meditation offset completely nullifies the Meditation bonus to mana regen.
