# Magic Resistance

Magic Resistance is a passive skill that gives you a chance to reduce or completely ignore the debuff component of hostile spells.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Intelligence |
| Usage | Passive (automatic on spell receipt) |
| Cooldown | None |

## How It Works

### Spell Resist Formula

Every hostile spell from Magery, Elementalism, Jedi, or Syth calls `CheckResisted()` using two competing percentages:

```
firstPercent  = MagicResist / 5.0
secondPercent = MagicResist - ((CasterSkill - 20) / 5) - (1 + circle) * 5
resistChance  = max(firstPercent, secondPercent) / 2.0
```

A successful resist **cancels the debuff or effect** but does not reduce direct damage. The second formula is suppressed at high spell circles, ensuring higher-level spells remain threatening even against skilled resisters.

### Bard Skill Resist

Resist also protects against bard skills:

- **Discordance** on players: `MagicResist > RandomMinMax(0, 125)` cancels the debuff.
- **Peacemaking** on NPCs: same formula.

### Passive Training Threshold

A gain check fires when an incoming spell circle satisfies:

```
MagicResist < (1 + circle) * 10
```

This means higher-circle spells keep triggering gains at higher skill levels.

## How to Train

Stand in low-risk situations where hostile spellcasters target you with mid-to-high circle spells. Each incoming spell whose circle threshold exceeds your current skill fires a gain check automatically — no action required on your part.

## What It Affects

### Magic Systems

Magic Resistance is checked by every hostile spell system via `CheckResisted()`. A successful resist cancels the spell's debuff/effect or reduces damage.

| Spell System | File:Line | Effect |
|---|---|---|
| **Magery** | `MagerySpell.cs:59` | `CheckResisted()` uses resist formula; gain check against `maxSkill = (1+circle)*10 + (1+circle/6)*25` |
| **Magery — Poison (3rd circle)** | `Magery/Spells/Magery 3rd/Poison.cs:47` | Resist cancels poison application entirely |
| **Magery — Mana Drain (4th circle)** | `Magery/Spells/Magery 4th/ManaDrain.cs:93` | Resist cancels mana loss (hardcoded 99% resist chance, always succeeds) |
| **Magery — Fire Field (4th circle)** | `Magery/Spells/Magery 4th/FireField.cs:199` | `m.CheckSkill(MagicResist, 0, 30)` — resist reduces damage to 1 |
| **Elementalism** | `ElementalSpell.cs:119` | Same resist formula as Magery; gain check scales with circle |
| **Elementalism — Elemental Protection** | `Elementalism/Sphere 2/Elemental_Protection.cs:65` | Reduces target's Magic Resistance by `-35 + (Elementalism/20)` when active |
| **Elementalism — Immobilization spells** | `ElementalSpell.cs:375-378` | Magic Resist skill affects immobilization duration for flame strands, stars, vines, and tentacles |
| **Jedi** | `JediSpell.cs:290` | Resist formula with fixed 7-circle max; gain check capped at 120.0 |
| **Syth** | `SythSpell.cs:297` | Same as Jedi — fixed 7-circle, capped at 120.0 gain |
| **Necromancy — Poison Strike** | `Necromancy/PoisonStrike.cs:46` | `CheckResisted()` is called but return value is ignored (per OSI: "Necro spells don't give Resist gain") |
| **Necromancy — Necro Poison (Witch)** | `Witch/Effects/NecroPoison.cs:41` | Resist cancels poison; level based on Necromancy + Poisoning + EnhancePotions |
| **Witch — Mana Leech** | `Witch/Effects/ManaLeech.cs:78` | Resist formula with fixed 7-circle; gain capped at 120.0 |
| **Druidism** | `Druidism/HerbalistSpell.cs:46` | Resist formula; gain check scales with circle, capped at 120.0 |
| **Druidism — Volcanic Eruption** | `Druidism/Effects/VolcanicEruption.cs:63` | Resist reduces damage by 30% (toDeal *= 0.7) |
| **Druidism — Swarm of Insects** | `Druidism/Effects/SwarmofInsectsSpell.cs:35` | CheckResisted called only for gain; does not block damage |
| **Druidism — Firefly** | `Druidism/Effects/FireflySpell.cs:56` | Resist prevents pacify/paralyze effect on NPCs and monsters |
| **Mystic** | `Mystic/MysticSpell.cs:190` | Resist formula with MysticSpellCircle; gain capped at 120.0 |
| **Shinobi** | `Shinobi/ShinobiSpell.cs:106` | Always returns `false` — Shinobi spells cannot be resisted |
| **Jester** | `Jester/JesterSpell.cs:97` | Always returns `false` — Jester spells cannot be resisted |
| **Misc — Attack Spells (Wizardry)** | `Misc/AttackSpells.cs:91` | `m.CheckSkill(MagicResist, 0, 125)` — resist halves damage |
| **Misc — Thor Lightning** | `Misc/ThorLightningSpell.cs:53` | Resist reduces damage to 75% |

### Bardic Skills

| Skill | File:Line | Effect |
|---|---|---|
| **Discordance** | `Discordance.cs:211` | `MagicResist > RandomMinMax(0, 125)` cancels the strength debuff |
| **Peacemaking** | `BaseCreature.cs:7921-7922` | `RandomMinMax(bard-20, bard) < RandomMinMax(resist-20, resist)` — NPC bard AI checks resist to pacify |
| **BaseCreature Suppress** | `BaseCreature.cs:7959-7961` | Same resist vs musicianship check; blocks skill reduction debuff |

### Items & Equipment

| Item | File:Line | Effect |
|---|---|---|
| **Dispel weapon ability** | `BaseWeapon.cs:2007` | Weapon's OnHit triggers Dispel spell; resist determines if dispel succeeds |
| **Fire Horn** | `FireHorn.cs:158` | `m.CheckSkill(MagicResist, 0, 120)` — resist halves fire damage from horn blast |
| **Hidden Trap — magic save** | `HiddenTrap.cs:1100` | Magic trap save uses `(Int + MagicResist + EnergyRes) / 4` as the save value |
| **Elixir of Magic Resistance** | `Elixirs.cs:2929` | Potions — consumeable that boosts Magic Resist skill |
| **Alchemy crafting** | `DefAlchemy.cs:317` | Elixir of Magic Resist requires 60–120 Alchemy, uses Beetle Shell |

### AI & NPCs

| NPC | File:Line | Effect |
|---|---|---|
| **Revenant** | `Revenant.cs:45` | Sets Magic Resist to `100.0 * scalar` — noted as "absolute value of spiritspeak" |

### Damage Mitigation

| Location | File:Line | Effect |
|---|---|---|
| **Blood Oath (reflected damage)** | `PlayerMobile.cs:2812` | Reflected damage reduced by `((MagicResist * 0.5) + 10) / 100` — magic resist lowers the damage taken from Blood Oath reflection |

### Training

| Mechanism | File:Line | Condition |
|---|---|---|
| **Magery/Elementalism gain check** | `MagerySpell.cs:74`, `ElementalSpell.cs:134` | `MagicResist < (1 + circle) * 10 + (1 + circle/6) * 25` |
| **Jedi/Syth/Mystic/Druidism gain check** | Various | `MagicResist < (1 + circle) * 10 + (1 + circle/6) * 25`, capped at 120.0 |
| **Attack Spells gain check** | `AttackSpells.cs:91` | `m.CheckSkill(MagicResist, 0, 125)` |

## Related Skills

- [Meditation](meditation.md) — mana regeneration; pairs well for magic-focused characters.
- [Psychology](psychology.md) — evaluating caster skill levels to predict resist chance.
- [Elementalism](../magic/elementalism.md) — Elemental Protection spell actively reduces target's Magic Resistance.
- [Discordance](discordance.md) — directly contested against Magic Resist for skill check.
- [Peacemaking](peacemaking.md) — contested against Magic Resist by NPC bard AI for pacify effects.
