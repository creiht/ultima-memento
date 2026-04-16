# Fishing Loot

Fishing produces various special items beyond ordinary fish — treasure maps, messages in bottles, sea relics, and shipwreck items — depending on skill level, the player's location, and the type of net used.

**Source:** `World/Source/Scripts/Engines and Systems/Trades/Harvest/Fishing/`

[Back to Loot Tables](README.md) | [Fishing skill](../../../skills/fishing.md)

---

## Standard Fishing Loot

| Item | Notes |
|------|-------|
| Various fish types | Raw fish, colored fish, special fish |
| `TreasureMap` | Level 1–7, chance scales with skill |
| `MessageInABottle` | Level 1–4, found in open water |
| `HighSeasRelic` | Sea-encounter special item |
| `SOS` / `SpecialFishingNet` | High-skill rolls |

---

## Fabled Fishing Nets

Special nets cast into the sea can summon high-seas encounters — sea serpents, krakens, and other sea creatures. When those creatures are killed, they drop sea-specific loot via [DropRelic](special-drops.md#high-seas-loot), including:
- `EnchantedSeaweed` (1–3)
- `Oyster`
- `HighSeasRelic`
- `MessageInABottle` (level 1–4)
- `LootChest` named "sea chest" (level 1–5)

---

## Sea Creature Drops

Creatures killed in sea areas or by sea-creature encounters (see [Special Drops — High Seas](special-drops.md#high-seas-loot)) can also drop `CorpseSailor`, a leveled chest styled as sailor remains.

---

## Sea Relics

`HighSeasRelic` items come from sea creature drops and fishing. Their `CoinPrice` is augmented by `creature.RawStatTotal / 3` when dropped from creatures.

---

## Messages in Bottles

`MessageInABottle` levels map to treasure map / quest content:
- Level 0: Random level
- Level 1–2: Low-tier content  
- Level 3: Medium content
- Level 4: High content

Creature fame determines bottle level when dropped from sea creatures:

| Creature Fame | Bottle Level |
|-------------|-------------|
| < 8,000 | 1 |
| 8,000–9,999 | 1–2 |
| 10,000–11,999 | 2–3 |
| ≥ 12,000 | 3–4 |
| Any (20% chance) | Level 0 (random) |
