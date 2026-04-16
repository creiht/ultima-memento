# Discordance

Discordance (also known as Discord) lets you play jarring music to weaken a target, reducing their resistances and skills.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Intelligence |
| Usage | Active (targeted, requires instrument) |
| Cooldown | 3 seconds (on use), 6 seconds (minimum skill message) |
| Skill Check | Variable, based on target difficulty |

## How It Works

1. Use the skill to select an instrument from your pack.
2. Target a creature or player (cannot target another player directly from player-to-player in some cases).
3. A Musicianship check is performed first. If that fails, you play poorly with no effect.
4. A Discordance skill check determines the outcome:
   - **Success:** Full effect applied for **10 seconds** per successful use (stacking duration).
   - **Failure:** Reduced "daze" effect applied for **4 seconds**.

### Effect Calculation

The debuff strength is based on your Discordance skill:

| Discordance Skill | Resistance Reduction | Skill Reduction |
|---|---|---|
| 50 | -10% all resistances | -10% all skills |
| 100 | -20% all resistances | -20% all skills |

Against difficult creatures (bard difficulty 160+), the effect is **halved**.

The effect reduces:
- All five resistances (Physical, Fire, Cold, Poison, Energy)
- All of the target's skills by a percentage scalar

Discordance no longer reduces the target's stats (Str/Dex/Int).

### Duration & Stacking

Repeated successful uses extend the duration by 10 seconds (or 4 seconds on failure). The effect ends if:
- The target dies or is deleted
- The bard dies or hides
- The bard moves out of range
- The duration expires

### Musicianship Bonus

Musicianship above 100 reduces the difficulty by `(Musicianship - 100) * 0.5`.

### Player Resistance

Players can resist discordance if their Magic Resist skill check succeeds against a random 0-125 roll.

## How to Train

Target progressively harder creatures. The difficulty is based on the instrument's `GetDifficultyFor` method minus 10. You need at least `(difficulty - 25)` skill to attempt a target.

## Related Skills

- [Peacemaking](peacemaking.md) - Calms targets instead of weakening them.
- [Provocation](provocation.md) - Turns creatures against each other.
