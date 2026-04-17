# Magic Item Pools

When a loot pack entry generates a "magic item", it picks one type from a weighted pool and then applies random magic attributes via `BaseRunicTool.ApplyAttributes()`. This page documents the pools, the item-type weights, and the intensity scaling system.

**Source:** `World/Source/Scripts/Items/Containers/LootPack.cs` (lines 122–222, 537–600)

[Back to Loot Tables](README.md)

---

## Item Type Pools

Each magic-item pool entry is a weighted list of `BaseWeapon`, `BaseRanged`, `BaseArmor`, `BaseShield`, `BaseTrinket`, and `BaseClothing`. The actual item is selected by `Loot.RandomWeapon()`, `Loot.RandomArmor()`, etc.

**Relative weights by pool:**

| Pool | Weapon | Ranged | Armor | Shield | Trinket | Clothing |
|------|--------|--------|-------|--------|---------|----------|
| Poor | 3 | 1 | 3 | 1 | 2 | 1 |
| Meager1 | 56 | 14 | 61 | 11 | 42 | 20 |
| Meager2 | 28 | 7 | 30 | 5 | 21 | 10 |
| Average1 | 90 | 23 | 98 | 17 | 68 | 32 |
| Average2 | 54 | 13 | 57 | 10 | 40 | 20 |
| Rich1 | 211 | 53 | 227 | 39 | 158 | 76 |
| Rich2 | 170 | 43 | 184 | 32 | 128 | 61 |
| FilthyRich1 | 219 | 55 | 236 | 41 | 164 | 86 |
| FilthyRich2 | 239 | 60 | 257 | 90 | 45 | 86 |
| UltraRich | 276 | 69 | 397 | 52 | 207 | 207 |

> Armor is most common in almost every pool. Trinkets and weapons are next. Ranged weapons and shields are least common.

**Item sub-types:** The specific item within each category is selected randomly from the large type arrays in `Loot.cs`:
- Weapons: `m_WeaponTypes` — swords, axes, maces, polearms, staves, fencing
- Ranged: `m_RangedTypes` — bows, crossbows, throwing
- Armor: `m_ArmorTypes` — head, chest, arms, legs, gorget pieces
- Shields: `m_ShieldTypes`
- Trinkets: `m_TrinketTypes` — rings, bracelets, earrings, necklaces
- Clothing: `m_ClothingTypes` (25% chance for hats instead)

See [Weapons](../../items/weapons.md), [Armor](../../items/armor.md), [Trinkets](../../items/trinkets.md).

---

## <a id="poor"></a>Poor Pool
Used by: [Monster Poor](monster-packs.md#poor), [Treasure Poor](treasure-packs.md#tpoor)  
**Intensity:** 0–25%, up to 1 property

---

## <a id="meager"></a>Meager Pool
Used by: [Monster Meager](monster-packs.md#meager), [Treasure Meager](treasure-packs.md#tmeager)  
**Intensity:** 0–30%, up to 2 properties

---

## <a id="average"></a>Average Pool
Used by: [Monster Average](monster-packs.md#average), [Treasure Average](treasure-packs.md#taverage)  
**Intensity:** 0–40%, up to 3 properties

---

## <a id="rich"></a>Rich Pool
Used by: [Monster Rich](monster-packs.md#rich), [Treasure Rich](treasure-packs.md#trich)  
**Intensity:** 20–40%, up to 3–4 properties

---

## <a id="filthyrich"></a>FilthyRich Pool
Used by: [Monster FilthyRich](monster-packs.md#filthyrich), [Treasure FilthyRich](treasure-packs.md#tfilthyrich)  
**Intensity:** 25–50%, up to 4 properties

---

## <a id="ultrarich"></a>UltraRich Pool
Used by: [Monster UltraRich](monster-packs.md#ultrarich), [Monster SuperBoss](monster-packs.md#superboss-megarich), [Treasure UltraRich](treasure-packs.md#tultrarich), [Treasure MegaRich](treasure-packs.md#tmegarich)  
**Intensity:** 40–70%, up to 5 properties

---

## Intensity Scaling

Base intensity is defined per pack entry as `minIntensity`–`maxIntensity`. Two bonus layers can push effective intensity higher:

### Layer 1 — Dungeon Heat (dungeonLevelBonus)
Each dungeon has a "heat" level from 0 to 4 (tracked via `Server.Difficult.GetDifficultyBounded()`). This maps onto a `NormalizeLevel` calculation:

| NormalizedLevel | Effect |
|-----------------|--------|
| 0–1 | No bonus |
| 2 | `maxIntensity + 5` |
| 3 | `maxIntensity + 15` |
| 4 | `minIntensity + 10` |
| 5 | `minIntensity + 15` |
| 6 | `minIntensity + 20` |
| 7–8 | +1 bonus property |
| 9 | `minIntensity = 70` |
| 10 | `min = 70, max = 100` |

`NormalizedLevel = dungeonLevelBonus + (creatureLevel / 2)`  
`dungeonLevelBonus` ranges 0–4; `creatureLevel` ranges 1–12.  
**Maximum combined:** `4 + (12/2) = 10` → forces 70–100% intensity.

### Layer 2 — Luck
If the killer has Luck > 0, there is an additional chance to gain +1 bonus property:
- `LootPack.GetRegularLuckChance(from)` = `Luck^(1/1.8) × 100` / 10000 → probability

### Net Effect
High-fame creatures (creatureLevel 10–12) in high-heat dungeons (heat 3–4) can produce items with 70–100% intensity regardless of the base pack tier.

---

## Special Item Mutations

After generation, `LootPackChange.ChangeItem()` may further mutate the item:
- **Sci-fi regions**: Trinkets, quivers, scrolls → random sci-fi item; ranged weapons may become sci-fi guns
- **Random resource upgrade**: Based on creature level, item material may be upgraded (iron → valorite, leather → barbed, etc.)
- **Spell item** (1% chance): Weapon/armor/clothing/trinket gains a castable spell
- **Magic Wand**: If the item is `MagicalWand`, it is reconstructed with the creature's level as the wand level
- **Trinket gem**: Non-sci-fi trinkets gain a random gem type
