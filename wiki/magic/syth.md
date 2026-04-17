# Syth

Syth powers are dark-side psionic abilities fueled by negative Karma, hatred, and rage. Like Jedi, they use [Psychology](../skills/psychology.md) and [Swords](../skills/swordsmanship.md) skills, but require Syth-themed equipment and negative Karma. Hell Shard crystals are consumed as a resource.

## Requirements

- **Skills:** [Psychology](../skills/psychology.md) 10+, [Swords](../skills/swordsmanship.md) 10+, and [Tactics](../skills/tactics.md) 10+ (source: `SythSpell.cs:137`)
- **Karma:** Must be **non-positive** (≤ 0) — Karma of exactly 0 is allowed (source: `SythSpell.cs:154`)
- **Equipment:** Syth-themed robe/cloak/helm/talisman + sword equipped
- **Resource:** Hell Shard Crystals (stored in datacron)
- **Spellbook:** Syth Spellbook (datacron)

## How to Learn

Find Syth Datacrons in dark dungeons throughout the world. Each datacron teaches one power.

## Spell List

| Ability | Command | Mana | Min Skill | Crystals | Effect |
|---------|---------|------|-----------|----------|--------|
| Psychokinesis | `[Psychokinesis` | 5 | 10 | 6 | Use or move objects at a distance; can trigger traps safely |
| Death Grip | `[DeathGrip` | 8 | 20 | 16 | Psychically grips a foe, dealing 5-20 damage every few seconds for 2-75 seconds |
| Projection | `[Projection` | 12 | 30 | 24 | Creates a physical projection to distract foes (~3 min) |
| Throw Sword | `[ThrowSword` | 16 | 40 | 12 | Throws equipped sword for bonus 17-53 damage |
| Speed | `[SythSpeed` | 20 | 50 | 80 | Run as fast as a horse for 10-25 minutes |
| Syth Lightning | `[SythLightning` | 24 | 60 | 32 | Strikes multiple enemies with lightning for 12-75 energy damage each |
| Absorption | `[Absorption` | 28 | 70 | 500 | Absorbs and redirects damaging magery spells |
| Psychic Blast | `[PsychicBlast` | 32 | 80 | 48 | Massive energy damage (80-125 points) based on Syth power |
| Drain Life | `[DrainLife` | 36 | 90 | 52 | Drains 10-15 HP every few seconds for 10-60 seconds; heals the Syth |
| Clone | `[CloneBody` | 40 | 100 | 250 | Creates a cloning crystal for self-resurrection |

## Notes

- Must wear at least one piece of Syth-identified equipment.
- Power scales with **negative Karma**, **Psychology**, and **Swords** skill.
- Speed does not work in some restricted areas.
- Casting Syth abilities awards negative Karma.
- Syth is the dark-side counterpart to [Jedi](jedi.md).
