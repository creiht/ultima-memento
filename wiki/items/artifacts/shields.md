# Artifact Shields

Artifact shields combine defensive bonuses with unique enchantments.

See [README](README.md) for acquisition details.

| Name | Base Type | Level | Base Resistances (Phys/Fire/Cold/Pois/Enrg) | Attributes & Skills | Slayers | Special | Source |
| --- | --- | --- | --- | --- | --- | --- | --- |
| Achille's Shield | BronzeShield | Standard | — | DurabilityBonus +30, Lower Stat Req +10, Defense Chance +10, Reflect Physical +5, Night Sight, Parry +25 | - | - | Sage Artifact Quest |
| Aegis | HeaterShield | Standard | — | Self Repair +5, Reflect Physical +20, Defense Chance +20, LMC +10, Parry +10 | - | - | Sage Artifact Quest |
| Arcane Shield | WoodenKiteShield | Standard | — | Night Sight, Spell Channeling, Defense Chance +15, FCR +1 | - | - | Sage Artifact Quest |
| Dupre's Shield | OrderShield | Standard | — | HP +5, HP Regen +5, Swords +10, Parry +10, Tactics +10 | - | - | Companion turn-in: Dupre |
| Gargoyle Shield | HeaterShield | Standard | 12 / 17 / 4 / 6 / 13 | DEX +10, HP Regen +3, Hit Chance +10, Defense Chance +10, FCR +1, FC +1, Spell Channeling | - | STR Req 105 | Sage Artifact Quest |
| Shield of Invulnerability | OrderShield | Standard | — | Spell Channeling, Reflect Physical +10, Defense Chance +15, Lower Stat Req +100 | - | - | Sage Artifact Quest |

## Special Notes

- **Gargoyle Shield** (`Artifact_MarbleShield`): The source shows `Luck +0` and `Self Repair +0` existed only in a prior version (version < 1 in the Deserialize). The current version does **not** include those properties — the zeros were placeholders from old data and have been corrected above.
- **Dupre's Shield** is obtained by turning in Dupre's Suit pieces to the Dupre companion NPC, not via the Sage Artifact Quest.
- Shields occupy the **Left Hand** (off-hand) equipment slot.
- Base resistances shown for Gargoyle Shield come directly from the constructor overrides (`BasePhysicalResistance`, `BaseFireResistance`, etc.).

## Cross-links

- [Armor Guide](../armor-guide.md) — resistance system explanation
- [Artifacts Overview](README.md)
