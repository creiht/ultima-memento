# Holy Man (Priest)

The Holy Man is a divine caster who channels spiritual blessings and prayers. These abilities use [Spiritualism](../skills/spiritualism.md) and [Healing](../skills/healing.md), requiring high positive Karma and piety points earned through banishing evil.

## Requirements

- **Skill:** [Spiritualism](../skills/spiritualism.md)
- **Damage Skill:** [Healing](../skills/healing.md)
- **Karma:** Must be at least **2,500** (positive)
- **Resource:** Piety (stored in a Holy Symbol, earned by banishing evil)
- **Spellbook:** Holy Man Spell Book

## How to Learn

Acquire Holy Symbols containing spell knowledge and inscribe them into a Holy Man Spell Book. Earn piety by using your Holy Symbol to banish undead and evil creatures.

## Spell List

| Spell | Command | Min Skill | Effect |
|-------|---------|-----------|--------|
| Heavenly Light | `[HMHeavenlyLight` | 10 | Destroys darkness, enhancing vision |
| Nourish | `[HMNourish` | 10 | Feeds those who are starving or thirsty |
| Sacred Boon | `[HMSacredBoon` | 20 | Surrounds target with a healing aura |
| Touch of Life | `[HMTouchLife` | 20 | Restores health and stamina |
| Sanctify | `[HMSanctify` | 30 | Grants increased Strength, speed, and Intelligence |
| Trial by Fire | `[HMTrialFire` | 30 | Engulfs the priest in holy flames, reflecting magic |
| Purge | `[HMPurge` | 40 | Removes curses and ailing effects |
| Smite | `[HMSmite` | 40 | Calls down a holy bolt; double damage to undead/demons |
| Hammer of Faith | `[HMHammerFaith` | 50 | Temporarily summons a divine hammer weapon |
| Banish Evil | `[HMBanish` | 60 | Sends demons and undead back to the hells |
| Seance | `[HMSeance` | 60 | Enter the realm of the dead, becoming immune to harm |
| Dampen Spirit | `[HMDampenSpirit` | 70 | Absorbs mana from others |
| Rebirth | `[HMRebirth` | 80 | Resurrects another or summons an orb for self-resurrection |
| Enchant | `[HMEnchant` | 90 | Temporarily imbues a weapon with holy powers |

## Notes

- Power nominally scales with Karma and **Spiritualism skill**. **Note:** Due to how the power formula is implemented (`from.Karma * -1`, apparently copy-pasted from the Syth / Death Knight formulas), higher positive Karma actually *reduces* elemental power. This appears to be unintended behavior in the source code. In practice, the power floor ensures usable abilities at high Karma. (Source: `HolyManSpell.cs:174`.)
- Piety is consumed on cast (reducible by Lower Reagent Cost).
- The Holy Man school is the polar opposite of the [Death Knight](death-knight.md).
