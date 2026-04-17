# Jedi

Jedi powers are psionic/psychic abilities fueled by positive Karma, [Psychology](../skills/psychology.md) skill, and [Swords](../skills/swordsmanship.md) skill. A Jedi must wear Jedi-themed clothing and wield a sword to use their abilities. Karan Crystals are consumed as a resource, stored in the Jedi Spellbook (datacron).

## Requirements

- **Skills:** [Psychology](../skills/psychology.md) 10+, [Swords](../skills/swordsmanship.md) 10+, and [Tactics](../skills/tactics.md) 10+ (source: `JediSpell.cs:137`)
- **Karma:** Must be **positive** (>= 0)
- **Equipment:** Jedi-themed robe/cloak/helm/talisman + sword equipped
- **Resource:** Karan Crystals (stored in datacron)
- **Spellbook:** Jedi Spellbook (datacron)

## How to Learn

Find Jedi Datacrons in dungeons throughout the world. Each datacron teaches one ability and can be found at specific locations. Learn abilities by using datacrons.

## Spell List

| Ability | Command | Mana | Min Skill | Crystals | Effect |
|---------|---------|------|-----------|----------|--------|
| Force Grip | `[ForceGrip` | 5 | 10 | 6 | Use or move objects at a distance; can trigger traps safely |
| Mind's Eye | `[MindsEye` | 8 | 20 | 16 | Detect hidden creatures and traps |
| Mirage | `[Mirage` | 12 | 30 | 24 | Creates a physical projection to distract foes (~3 min) |
| Throw Sabre | `[ThrowSabre` | 16 | 40 | 12 | Throws equipped sword for bonus 17-53 damage |
| Celerity | `[Celerity` | 20 | 50 | 80 | Run as fast as a horse for 10-25 minutes |
| Psychic Aura | `[PsychicAura` | 24 | 20 | 32 | Boosts physical/energy resistance; lowers cold/fire/poison |
| Deflection | `[Deflection` | 28 | 70 | 500 | Deflects damaging magery spells back at the caster |
| Soothing Touch | `[SoothingTouch` | 32 | 10 | 48 | Heals self or others; can cure poison and mortal wounds at high skill |
| Stasis Field | `[StasisField` | 36 | 50 | 52 | Puts target into stasis, unable to act |
| Replicate | `[Replicate` | 40 | 100 | 250 | Creates a replication crystal for self-resurrection |

## Notes

- Must wear at least one piece of Jedi-identified equipment (robe, cloak, helm, or talisman).
- Power scales with **Karma**, **Psychology**, and **Swords** skill.
- Celerity does not work in some restricted areas (dungeons, caves, indoor areas).
- Jedi is the light-side counterpart to [Syth](syth.md).
