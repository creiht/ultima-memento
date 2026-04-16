# Treasure Packs

Treasure packs fill lockable containers — dungeon chests, treasure map chests, paragon chests, sea chests, and buried finds. Unlike monster packs, treasure packs never include a Gold entry; gold is added separately by `LootPackChange.AddGoldToContainer()` before the pack fires.

**Source:** `World/Source/Scripts/Items/Containers/LootPack.cs`, `ContainerFunctions.cs`

[Back to Loot Tables](README.md)

---

## How They Work

`ContainerFunctions.FillTheContainer(level, box, opener)` is the entry point:

1. Adds a gold bag via `AddGoldToContainer()` (amount scales with chest level).
2. Calls `GenerateTreasure(level, box, opener)`.
3. `GenerateTreasure` loops `FillCycle(level)` times (roughly `level/2` to `level/2 + 2` iterations), each time picking one treasure pack based on a random roll bounded by the chest level.

**Level → tier mapping** (simplified):

| Level roll | Pack selected |
|------------|--------------|
| 1 | TPoor |
| 2 | TPoor or TMeager |
| 3 | TMeager or TAverage |
| 4 | TRich or TAverage |
| 5 | TRich |
| 6 | TRich or TFilthyRich |
| 7 | TFilthyRich |
| 8 | TFilthyRich or TUltraRich |
| 9 | TUltraRich |
| 10 | TUltraRich or TMegaRich |
| 11–12 | TMegaRich |

Additionally, each call to `AddTreasure` may add bonus `RandomItem` or `RandomTreasure` drops scaled by level (non-special-chest types only).

**`TreasureMapChest` multi-fill**: A treasure map chest calls `FillTheContainer` multiple times based on map level:
- Always: once
- Map level > 3: a second fill
- Map level > 7: a third fill
- Luck bonus: possible additional fill

See [Chest Containers](chest-containers.md) for more on chest types.

---

## TPoor

**Accessor:** `LootPack.TPoor`  
**Typical level:** Chest level 1–2

| Chance | Entry | Count | Props | Intensity |
|--------|-------|-------|-------|-----------|
| 10% | [Magic item (Poor pool)](magic-item-pools.md#poor) | 1 | 1 | 10–25% |
| 0.04% | [Instrument](../../../items/instruments.md) | 1 | 1 | 10–25% |
| 0.04% | Spellbook | 1 | 1 | 10–25% |
| 0.02% | [Quiver](../../../items/quivers.md) | 1 | 1 | 10–25% |
| 20.4% | [Magic item (Meager1 pool)](magic-item-pools.md#meager) | 1 | 1 | 10–25% |
| 5% | [Low Scroll](utility-packs.md#scrolls) | 1 | — | — |
| 20% | [Gem](utility-packs.md#gems) | 1 | — | — |
| 5% | Reagent | 1 | — | — |
| 5% | [Low Potion](utility-packs.md#lowpotions) | 1 | — | — |

---

## TMeager

**Accessor:** `LootPack.TMeager`  
**Typical level:** Chest level 2–3

| Chance | Entry | Count | Props | Intensity |
|--------|-------|-------|-------|-----------|
| 20.4% | [Magic item (Meager1 pool)](magic-item-pools.md#meager) | 1–2 | 2 | 10–30% |
| 0.2% | [Instrument](../../../items/instruments.md) | 1–2 | 2 | 10–30% |
| 0.2% | Spellbook | 1–2 | 2 | 10–30% |
| 0.1% | [Quiver](../../../items/quivers.md) | 1–2 | 2 | 10–30% |
| 10% | [Low Scroll](utility-packs.md#scrolls) | 1 | — | — |
| 40% | [Gem](utility-packs.md#gems) | 1 | — | — |
| 10% | Reagent | 1 | — | — |
| 10% | [Low Potion](utility-packs.md#lowpotions) | 1 | — | — |

---

## TAverage

**Accessor:** `LootPack.TAverage`  
**Typical level:** Chest level 3–4

| Chance | Entry | Count | Props | Intensity |
|--------|-------|-------|-------|-----------|
| 32.8% | [Magic item (Average1 pool)](magic-item-pools.md#average) | 1–3 | 3 | 10–40% |
| 0.8% | [Instrument](../../../items/instruments.md) | 1–3 | 3 | 10–40% |
| 0.8% | Spellbook | 1–3 | 3 | 10–40% |
| 0.4% | [Quiver](../../../items/quivers.md) | 1–3 | 3 | 10–40% |
| 20% | [Med Scroll](utility-packs.md#scrolls) | 1 | — | — |
| 60% | [Gem](utility-packs.md#gems) | 1 | — | — |
| 20% | Reagent | 1 | — | — |
| 20% | [Med Potion](utility-packs.md#medpotions) | 1 | — | — |

---

## TRich

**Accessor:** `LootPack.TRich`  
**Typical level:** Chest level 5–6

| Chance | Entry | Count | Props | Intensity |
|--------|-------|-------|-------|-----------|
| 76.3% | [Magic item (Rich1 pool)](magic-item-pools.md#rich) | 2–3 | 3 | 20–40% |
| 4% | [Instrument](../../../items/instruments.md) | 2–3 | 3 | 20–40% |
| 4% | Spellbook | 2–3 | 3 | 20–40% |
| 2% | [Quiver](../../../items/quivers.md) | 2–3 | 3 | 20–40% |
| 0.5% | [Semi-Artifact](artifact-pools.md#semi-artifacts) | 2–3 | 3 | 20–40% |
| 30% | [High Scroll](utility-packs.md#scrolls) | 1 | — | — |
| 70% | [Gem](utility-packs.md#gems) | 1 | — | — |
| 30% | Reagent | 1 | — | — |
| 30% | [High Potion](utility-packs.md#highpotions) | 1 | — | — |

---

## TFilthyRich

**Accessor:** `LootPack.TFilthyRich`  
**Typical level:** Chest level 7–8

| Chance | Entry | Count | Props | Intensity |
|--------|-------|-------|-------|-----------|
| 79.5% | [Magic item (FilthyRich1 pool)](magic-item-pools.md#filthyrich) | 2–4 | 4 | 35–50% |
| 4% | [Instrument](../../../items/instruments.md) | 2–4 | 4 | 35–50% |
| 4% | Spellbook | 2–4 | 4 | 35–50% |
| 2% | [Quiver](../../../items/quivers.md) | 2–4 | 4 | 35–50% |
| 0.5% | [Semi-Artifact](artifact-pools.md#semi-artifacts) | 1 | — | — |
| 0.25% | [Artifact](artifact-pools.md#artifacts) | 1 | — | — |
| 40% | [High Scroll](utility-packs.md#scrolls) | 1 | — | — |
| 80% | [Gem](utility-packs.md#gems) | 1 | — | — |
| 40% | Reagent | 1 | — | — |
| 40% | [High Potion](utility-packs.md#highpotions) | 1 | — | — |

---

## TUltraRich

**Accessor:** `LootPack.TUltraRich`  
**Typical level:** Chest level 9–10

| Chance | Entry | Count | Props | Intensity |
|--------|-------|-------|-------|-----------|
| 100% | [Magic item (UltraRich pool)](magic-item-pools.md#ultrarich) | 2–5 | 5 | 50–70% |
| 8% | [Instrument](../../../items/instruments.md) | 2–5 | 5 | 50–70% |
| 8% | Spellbook | 2–5 | 5 | 50–70% |
| 4% | [Quiver](../../../items/quivers.md) | 2–5 | 5 | 50–70% |
| 1% | [Semi-Artifact](artifact-pools.md#semi-artifacts) | 1 | — | — |
| 0.5% | [Artifact](artifact-pools.md#artifacts) | 1 | — | — |
| 50% | [High Scroll](utility-packs.md#scrolls) | 1 | — | — |
| 90% | [Gem](utility-packs.md#gems) | 1 | — | — |
| 50% | Reagent | 1 | — | — |
| 50% | [High Potion](utility-packs.md#highpotions) | 1 | — | — |

---

## TMegaRich

**Accessor:** `LootPack.TMegaRich`  
**Typical level:** Chest level 11–12

| Chance | Entry | Count | Props | Intensity |
|--------|-------|-------|-------|-----------|
| 100% ×2 | [Magic item (UltraRich pool)](magic-item-pools.md#ultrarich) | 3–5 | 5 | 50–70% |
| 8% | [Instrument](../../../items/instruments.md) | 3–5 | 5 | 50–70% |
| 8% | Spellbook | 3–5 | 5 | 50–70% |
| 6% | [Quiver](../../../items/quivers.md) | 3–5 | 5 | 50–70% |
| 2% | [Semi-Artifact](artifact-pools.md#semi-artifacts) | 1 | — | — |
| 0.75% | [Artifact](artifact-pools.md#artifacts) | 1 | — | — |
| 60% | [High Scroll](utility-packs.md#scrolls) | 1 | — | — |
| 100% | [Gem](utility-packs.md#gems) | 1 | — | — |
| 60% | Reagent | 1 | — | — |
| 60% | [High Potion](utility-packs.md#highpotions) | 1 | — | — |
