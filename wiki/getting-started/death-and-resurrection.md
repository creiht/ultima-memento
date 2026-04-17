# Death & Resurrection

Death in Ultima Memento is a setback, but not the end. This page explains what happens when you die, how to come back to life, and what penalties you may face.

## What Happens When You Die

When your hit points reach zero, your character dies:

1. **You become a ghost** — you enter spirit form and can move but cannot interact with the living world.
2. **A corpse is left behind** — your body remains where you died, containing your equipment and items.
3. **Instant resurrection gump** — after 5 seconds, a `ResurrectNowGump` dialog opens offering to resurrect you immediately by pleading to the gods. The directional arrow pointing toward the nearest healer or shrine fires separately, when your ghost walks.
4. **Corpse timer begins** — your corpse lasts **10 minutes** before turning into bones. Bones remain for an additional **1,430 minutes** (~24 hours). Combined, you have roughly 24 hours to recover your belongings.

## How to Resurrect

There are several ways to return to life:

### 1. Instant Resurrection (Plea to the Gods)

When you die, a dialog appears offering to resurrect you immediately by pleading to the gods. This option always has a **stat and skill penalty** if your character is above a certain threshold (more than 200 total skill points and more than 90 combined raw stats).

### 2. Healer NPCs

Seek out healers in towns and settlements. Wandering healers can also be found in the wilderness. When resurrected by a healer:
- If you can **pay the tribute** (gold from bank or tithing points), you are resurrected with **no stat/skill penalty**
- If you **cannot afford the tribute**, you are resurrected with a penalty (same as instant resurrection)

### 3. Shrines and Altars

Resurrection shrines and altars are scattered throughout the world (Ankhs, Dryad Altars, Daemon Altars, Sea Altars, etc.). They work the same way as healers — pay tribute to avoid penalties.

### 4. Player Resurrection

Other players with the Spiritualism skill or resurrection spells can bring you back to life.

### 5. Soul Orbs

The Avatar system provides Soul Orbs that can interact with the death system.

## Resurrection Cost

The resurrection tribute cost is based on your character's power level, calculated from:
- **Fame** (up to 15,000)
- **Karma** (absolute value, up to 15,000)
- **Total skills** (up to 15,000 converted)
- **Total stats** (up to 15,000 converted)

These are combined and scaled into a character level (1–100), then multiplied by the tribute rate (20 gold per level by default). Characters below level 5 pay nothing. New characters with very low skills and stats pay nothing.

| Modifier | Cost Multiplier |
|---|---|
| Normal character | 1× |
| Fugitive | 2× |
| Alien origin | 3× |

## Death Penalties

Penalties depend on how you resurrect and your character's origin:

### Standard Characters

| Resurrection Method | Fame/Karma Loss | Stat Loss | Skill Loss |
|---|---|---|---|
| With tribute (paid) | None | None | None |
| Without tribute (plea) | 10% of Fame and Karma | 5% of each stat | 5% of each skill (above 35) |

### Alien Origin Characters

Alien origin characters suffer harsher penalties:

| Resurrection Method | Fame/Karma Loss | Stat Loss | Skill Loss |
|---|---|---|---|
| With tribute (paid) | 10% of Fame and Karma | 5% of each stat | 5% of each skill (above 35) |
| Without tribute (plea) | 20% of Fame and Karma | 10% of each stat | 10% of each skill (above 35) |

**Important:** Stats can never drop below 10, and skills are never reduced below 35 through death penalties.

## Ghost Mechanics

While in ghost form:

- **Movement** — you can walk freely through the world, including through walls and doors.
- **Directional arrow** — the game provides an arrow pointing to the nearest healer or shrine. The arrow updates as you move and recalculates if you change areas.
- **Invisibility** — living players cannot see ghosts normally (requires the Spiritualism skill).
- **Communication** — ghosts cannot speak to the living (speech appears as "OoOoO").
- **Healer restrictions** — some healers and shrines will refuse to resurrect criminals and murderers. Evil-aligned altars (like those found in Xardok's Castle or crypts) will resurrect characters with negative karma or criminal/murderer status.

## Avatar System and Death

When using the Avatar system, death has additional effects:

- Your **lifetime deaths** counter increments
- Your **coins farmed** in the current life are added to your saved total
- Coins farmed resets to zero for the next life
- Rival bonus points reset to zero

## Tips

- Keep gold in your bank box or tithe at shrines to afford resurrection tribute
- The tribute system means skilled/famous characters pay more — this is by design
- If you cannot afford tribute and have high skills, consider carefully whether to accept the plea penalty or try to find a shrine
- Your corpse contains all your items — make recovering it a priority

## See Also

- [Attributes](attributes.md) — understand Str, Dex, Int and how stat loss affects you
- [Notoriety](notoriety.md) — how criminal/murderer status affects resurrection options
- [Getting Started](README.md) — back to the new player guide
