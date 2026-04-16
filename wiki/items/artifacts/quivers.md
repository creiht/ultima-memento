# Artifact Quivers

Artifact quivers are worn in the cloak slot and provide bonuses to archers along with fixed elemental ammunition effects. Each quiver also has 4 randomly generated magical properties applied at 40–100% intensity (via `BaseRunicTool.ApplyAttributes`), so the exact bonus values vary per item.

See [README](README.md) for acquisition details.

| Name | Level | Fixed Attributes & Skills | Element Damages | Weight Reduction | Source |
| --- | --- | --- | --- | --- | --- |
| Pestilence | Artifact | Defense Chance +5, Hit Chance +5, Lower Ammo Cost 5%, + 4 random properties | None (100% physical) | 100% | Sage Artifact Quest |
| Quiver of Blight | Artifact | 4 random properties | Cold 50%, Poison 50% | — | Sage Artifact Quest |
| Quiver of Fire | Artifact | 4 random properties | Physical 50%, Fire 50% | — | Sage Artifact Quest |
| Quiver of Ice | Artifact | 4 random properties | Physical 50%, Cold 50% | — | Sage Artifact Quest |
| Quiver of Infinity | Artifact | Defense Chance +5, Lower Ammo Cost 20%, + 4 random properties | None (100% physical) | 80% | Sage Artifact Quest |
| Quiver of Lightning | Artifact | 4 random properties | Physical 50%, Energy 50% | — | Sage Artifact Quest |
| Quiver of Rage | Artifact | Weight Reduction 100%, + 4 random properties | Physical 20%, Fire 20%, Cold 20%, Poison 20%, Energy 20% | 100% | Sage Artifact Quest |
| Quiver of the Elements | Artifact | Weight Reduction 100%, + 4 random properties | Fire 25%, Cold 25%, Poison 25%, Energy 25% | 100% | Sage Artifact Quest |

## Special Notes

- **Element Damages** are applied via `AlterBowDamage` and affect all arrows/bolts fired while the quiver is equipped.
- **Weight Reduction** reduces the total weight of ammunition stored in the quiver.
- **Lower Ammo Cost** gives a chance per shot that no ammo is consumed.
- The 4 random properties from `BaseRunicTool.ApplyAttributes` can include any standard magical attribute (Damage Increase, Luck, Skill bonuses, etc.) at 40–100% intensity. Fixed explicitly-set attributes (like DefendChance and LowerAmmoCost on Pestilence/Infinity) are applied after the random roll, so they are guaranteed.
- All quivers are worn in the **Cloak** equipment slot.

## Cross-links

- [Quivers](../quivers.md) — non-artifact quivers with DI and property ranges
- [Marksmanship / Archery](../../skills/) — skill governing ranged combat
