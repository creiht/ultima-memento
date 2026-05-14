# Psychology

Psychology (Evaluate Intelligence) lets you assess a target's mental capabilities, revealing their intelligence and current mana percentage. It is also the primary skill used to enhance spell damage and duration across nearly all magic systems.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Intelligence |
| Usage | Active (targeted) |
| Range | 8 tiles |
| Skill Check | 0 - 125 |
| Guild Affiliation | Mages Guild |
| Starting Value (Mage) | 30 |

## How It Works

Use the skill and target a creature or player. On success, you receive a message describing their **intelligence level** (e.g. "That being looks very smart" or "Slightly less intelligent than a rock"). At **76.0+ base skill**, you also see their current **mana percentage**.

### Accuracy

Your reading has a margin of error that decreases with skill:

| Psychology Skill | Margin of Error |
|---|---|
| 0 | +/- 20 |
| 50 | +/- 10 |
| 76+ | +/- 4 |
| 100 | 0 |

### Targeting Yourself

Targeting yourself gives: "Hmm, that person looks really silly."

### Targeting Vendors

Invulnerable vendors: "That person could probably calculate the cost of what you buy from them."

### Targeting Items

"It looks smarter than a rock, but dumber than a piece of wood."

## How to Train

Target creatures and players. The skill check ranges from 0 to 125, so any target can provide gains.

## What It Affects

### Magic Systems

Psychology is the default `DamageSkill` for all base spells (`Spell.cs`). It affects:

- **Spell Duration** — All spells' duration scales with Psychology: `((6 * Spell.ItemSkillValue(caster, Psychology, true)) / 50) + 1` seconds. Higher Psychology = longer spell effects.
- **Stat Drain Spells** — Strength/Dexterity/Intelligence drain effectiveness uses Psychology: `percent = 1 + (Psychology / 100)` for normal drains, and `percent = 8 + (Psychology / 100) - (target.MagicResist / 100)` for curses.
- **Magic Reflect** — The magic damage absorption value combines Magery and Psychology: `(Magery + Psychology) / 4`.

| File | Line | Effect |
|---|---|---|
| `Magic/Base/Spell.cs` | 51 | Default `DamageSkill` for all base spells |
| `Magic/Base/SpellHelper.cs` | 308 | Spell duration formula using Psychology |
| `Magic/Base/SpellHelper.cs` | 319-326 | Stat drain offset percentage |
| `Magic/Magery/Spells/Magery 5th/MagicReflect.cs` | 65 | Magic reflect absorb value = (Magery + Psychology) / 4 |
| `Items/Traps/SpellTrap.cs` | 83 | Spell traps can be avoided via Psychology check |
| `Engines and Systems/Magic/Research/ResearchFunctions.cs` | 368 | Research spell checks use Psychology alongside Magery, Necromancy, Spiritualism |

### Jedi Magic

Psychology is the `CastSkill` for all Jedi spells.

| File | Line | Effect |
|---|---|---|
| `Magic/Jedi/JediSpell.cs` | 21 | Default `CastSkill` for Jedi spells |
| `Magic/Jedi/JediSpell.cs` | 285 | Jedi power value: `sqrt(karma + 20000 + (Psychology.Fixed * 10)) / div` |
| `Magic/Jedi/Spells/StasisField.cs` | 53 | Stasis duration: `(JediDamage/25) - (resist/10) + (Psychology.Value / 2)` seconds |
| `Magic/Jedi/Spells/SoothingTouch.cs` | 67 | Poison cure chance uses Psychology value |
| `Magic/Jedi/Spells/SoothingTouch.cs` | 99 | Healing amount: `Psychology.Value * 0.2 + JediDamage * 0.1` |
| `Magic/Jedi/Spells/MindsEye.cs` | 52 | Detection range: `1 + (Psychology.Value / 20)` tiles |
| `Magic/Jedi/Spells/MindsEye.cs` | 184 | Reveal chance: uses Psychology as "searching" skill vs Hiding/Stealth |

### Syth Magic

Psychology is the `CastSkill` for all Syth spells, used alongside negative karma.

| File | Line | Effect |
|---|---|---|
| `Magic/Syth/SythSpell.cs` | 21 | Default `CastSkill` for Syth spells |
| `Magic/Syth/SythSpell.cs` | 292 | Syth power value: `sqrt((karma * -1) + 20000 + (Psychology.Fixed * 10)) / div` |

### Jester Class

Jesters must have at least **10 Psychology** (or 10 Begging) to qualify as a Jester.

| File | Line | Effect |
|---|---|---|
| `System/Misc/Players.cs` | 130 | Jester qualification check: Begging < 10 AND Psychology < 10 = not a Jester |
| `Magic/Jester/Spells/CanOfSnakes.cs` | 59-60 | Can of Snakes summons extra jokers for each successful Psychology check (rolled twice, each checked vs `Psychology.Value >= random(1-200)`) |
| `Magic/Jester/BagOfTricks.cs` | 129 | Jester lore: "Jesters beg for laughs and can use psychology on their audience to be more effective" |

### Character Progression Requirements

| System | Requirement | File | Line |
|---|---|---|---|
| **Jedi Path** | Psychology ≥ 25 + positive karma | `System/Misc/Talk.cs` | 177 |
| **Syth Class** | Psychology ≥ 50 + Swords ≥ 50 + Karma ≤ -5000 + isSyth flag | `System/Misc/Players.cs` | 571, 608 |
| **Syth NPC Hostility** | Psychology ≥ 50 + Syth flag = treated as enemy in settlements | `Mobiles/Base/Behavior.cs` | 1127 |

### Druidism AI

When a Druidism creature evaluates a target, Psychology is shown as one of the three "Lore & Knowledge" stats (alongside Magery and Meditation).

| File | Line | Effect |
|---|---|---|
| `System/Skills/Druidism.cs` | 513 | Druidism talent assessment shows target's Psychology value |

### NPC Skill Assignments

Many magical NPCs and bosses are assigned Psychology skill:

| Mobile | Range | Location |
|---|---|---|
| Mage Guildmaster | 85.0 - 100.0 | `Mobiles/Civilized/Guilds/MageGuildmaster.cs:21` |
| Titan Stratos | 80.1 - 100.0 | `Mobiles/Unique/TitanStratos.cs:53` |
| Titan Hydros | 90.1 - 100.0 | `Mobiles/Unique/TitanHydros.cs:54` |
| Titan Pyros | 90.1 - 100.0 | `Mobiles/Unique/TitanPyros.cs:54` |
| Lord Oaks (Champion Boss) | 120.1 - 130.0 | `Champs/Mobiles/Bosses/LordOaks.cs:52` |
| Neira (Champion Boss) | 120.0 | `Champs/Mobiles/Bosses/Neira.cs:37` |
| Semidar (Champion Boss) | 95.1 - 100.0 | `Champs/Mobiles/Bosses/Semidar.cs:38` |
| Silvani (Champion Boss) | 100.0 | `Champs/Mobiles/Bosses/Silvani.cs:29` |
| Serpentine Dragon (Champion) | 100.1 - 110.0 | `Champs/Mobiles/SerpentineDragon.cs:30` |
| Titan Lich | 120.1 - 130.0 | `Mobiles/Undead/TitanLich.cs:58` |
| Exodus | 110.0 | `Mobiles/Unique/Exodus.cs:59` |
| Ghostly | 100.0 | `Mobiles/Undead/Ghostly.cs:49` |
| Spectres | 100.0 | `Mobiles/Unique/Spectres.cs:46` |
| Leviathan | 97.6 - 107.5 | `Mobiles/Reptilian/Sea/Leviathan.cs:63` |
| Rune Guardian | 90.1 - 120.0 | `Mobiles/Unique/RuneGuardian.cs:272` |
| Shadowlord | 90.1 - 100.0 | `Mobiles/Unique/Shadowlord.cs:51` |
| Various undead, eyes, goliaths | 30 - 100 | Multiple files |

### Runic Tools

Psychology is one of the skills recognized by runic tools for crafting bonuses.

| File | Line | Effect |
|---|---|---|
| `Items/Trades/Magical/Tools/BaseRunicTool.cs` | 200 | Psychology recognized as runic tool skill |
| `Items/Trades/Magical/Tools/BaseRunicTool.cs` | 297 | Psychology recognized as runic tool skill |
| `Items/Trades/Magical/Tools/BaseRunicTool.cs` | 361 | Psychology recognized as runic tool skill |

## Related Skills

- [Anatomy](anatomy.md) - Evaluates strength, dexterity, and stamina instead of intelligence.
- [Meditation](meditation.md) - Mana-focused skill, used alongside Psychology for spellcasting.
- [Magery](../magic/magery.md) - Primary magic skill; Psychology enhances all Magery spells' duration and damage.
- [Spiritualism](spiritualism.md) - Necromancy counterpart; used alongside Psychology in research checks.
- [Magic Resist](magic-resistance.md) - Defensively countered by Psychology-enhanced spell effectiveness.
- [Jedi](../magic/jedi.md) - Jedi spells require Psychology as cast skill; 25+ needed to begin the path.
- [Syth](../magic/syth.md) - Syth spells require Psychology as cast skill; 50+ needed for Syth class.
- [Jester](../magic/jester.md) - Jester class requires 10+ Psychology.
- [Elementalism](../magic/elementalism.md) - Elementalists are noted as NOT having supplement skills like mages with Psychology.
