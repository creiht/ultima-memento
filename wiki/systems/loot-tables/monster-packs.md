# Monster Packs

Monster packs are the loot tables assigned to creature body drops. Every creature that overrides `GenerateLoot()` calls `AddLoot(LootPack.X)` one or more times, each call being an independent full generation of that pack.

**Source:** `World/Source/Scripts/Items/Containers/LootPack.cs`

[Back to Loot Tables](README.md)

---

## How They Work

1. `AddLoot(pack)` calls `pack.Generate(...)` once per call.
2. `AddLoot(pack, count)` loops `count` times — each is an independent generation, including a separate gold roll.
3. Each entry in the pack has a **chance in 10,000** (displayed below as a percentage). A luck roll can give a second chance at failed entries.
4. Gold output is immediately converted by `LootPackChange.MakeCoins()` — see [Currency Conversion](README.md#currency-conversion).
5. Magic items pass through intensity scaling — see [Magic Item Pools](magic-item-pools.md).

---

## Poor

**Accessor:** `LootPack.Poor`  
**Typical users:** Weak animals, minor humanoids, very low-threat creatures

| Chance | Entry | Count | Props | Intensity |
|--------|-------|-------|-------|-----------|
| 100% | Gold (2d10+20 ≈ avg 31) | 1 stack | — | — |
| 1% | [Magic item (Poor pool)](magic-item-pools.md#poor) | 1 | 1 | 0–25% |
| 0.04% | [Instrument](../../../items/instruments.md) | 1 | 1 | 0–25% |
| 0.04% | Spellbook | 1 | 1 | 0–25% |
| 0.02% | [Quiver](../../../items/quivers.md) | 1 | 1 | 0–25% |
| 20.4% | [Magic item (Meager1 pool)](magic-item-pools.md#meager) | 1–2 | 2 | 0–25% |
| 20% | [Low Potion](utility-packs.md#lowpotions) | 1 | — | — |

---

## Meager

**Accessor:** `LootPack.Meager`  
**Typical users:** Standard low-level dungeon creatures, weaker humanoids

| Chance | Entry | Count | Props | Intensity |
|--------|-------|-------|-------|-----------|
| 100% | Gold (4d10+40 ≈ avg 62) | 1 stack | — | — |
| 20.4% | [Magic item (Meager1 pool)](magic-item-pools.md#meager) | 1–2 | 2 | 0–30% |
| 10.2% | [Magic item (Meager2 pool)](magic-item-pools.md#meager) | 1–2 | 2 | 0–30% |
| 0.2% | [Instrument](../../../items/instruments.md) | 1–2 | 2 | 0–30% |
| 0.2% | Spellbook | 1–2 | 2 | 0–30% |
| 0.1% | [Quiver](../../../items/quivers.md) | 1–2 | 2 | 0–30% |
| 50% | [Low Potion](utility-packs.md#lowpotions) | 1 | — | — |

---

## Average

**Accessor:** `LootPack.Average`  
**Typical users:** Mid-tier creatures — trolls, harpies, lizardmen, typical dungeon fodder

| Chance | Entry | Count | Props | Intensity |
|--------|-------|-------|-------|-----------|
| 100% | Gold (8d10+100 ≈ avg 144) | 1 stack | — | — |
| 32.8% | [Magic item (Average1 pool)](magic-item-pools.md#average) | 1–3 | 3 | 0–40% |
| 32.8% | [Magic item (Average1 pool)](magic-item-pools.md#average) | 1–3 | 3 | 0–40% |
| 19.5% | [Magic item (Average2 pool)](magic-item-pools.md#average) | 1–3 | 3 | 0–40% |
| 0.8% | [Instrument](../../../items/instruments.md) | 1–3 | 3 | 0–40% |
| 0.8% | Spellbook | 1–3 | 3 | 0–40% |
| 0.4% | [Quiver](../../../items/quivers.md) | 1–3 | 3 | 0–40% |
| 20% | [Med Potion](utility-packs.md#medpotions) | 1 | — | — |

---

## Rich

**Accessor:** `LootPack.Rich`  
**Typical users:** Dangerous creatures — ogre lords, earth elementals, lesser demons, drakes

| Chance | Entry | Count | Props | Intensity |
|--------|-------|-------|-------|-----------|
| 100% | Gold (15d10+225 ≈ avg 300) | 1 stack | — | — |
| 76.3% | [Magic item (Rich1 pool)](magic-item-pools.md#rich) | 2–3 | 3 | 20–40% |
| 76.3% | [Magic item (Rich1 pool)](magic-item-pools.md#rich) | 2–3 | 3 | 20–40% |
| 61.7% | [Magic item (Rich2 pool)](magic-item-pools.md#rich) | 2–4 | 4 | 20–40% |
| 4% | [Instrument](../../../items/instruments.md) | 2–3 | 3 | 20–40% |
| 4% | Spellbook | 2–3 | 3 | 20–40% |
| 2% | [Quiver](../../../items/quivers.md) | 2–3 | 3 | 20–40% |
| 1% | [Semi-Artifact](artifact-pools.md#semi-artifacts) | 2–3 | 3 | 20–40% |
| 50% | [Med Potion](utility-packs.md#medpotions) | 1 | — | — |

---

## FilthyRich

**Accessor:** `LootPack.FilthyRich`  
**Typical users:** Powerful creatures — dragons, liches, vampires, high-end humanoid bosses

| Chance | Entry | Count | Props | Intensity |
|--------|-------|-------|-------|-----------|
| 100% | Gold (3d100+400 ≈ avg 550) | 1 stack | — | — |
| 79.5% | [Magic item (FilthyRich1 pool)](magic-item-pools.md#filthyrich) | 2–4 | 4 | 25–50% |
| 79.5% | [Magic item (FilthyRich1 pool)](magic-item-pools.md#filthyrich) | 2–4 | 4 | 25–50% |
| 77.6% | [Magic item (FilthyRich2 pool)](magic-item-pools.md#filthyrich) | 3–4 | 4 | 25–50% |
| 4% | [Instrument](../../../items/instruments.md) | 2–4 | 4 | 25–50% |
| 4% | Spellbook | 2–4 | 4 | 25–50% |
| 2% | [Quiver](../../../items/quivers.md) | 2–4 | 4 | 25–50% |
| 1% | [Semi-Artifact](artifact-pools.md#semi-artifacts) | 1 | — | — |
| 0.5% | [Artifact](artifact-pools.md#artifacts) | 1 | — | — |
| 25% | [High Potion](utility-packs.md#highpotions) | 1 | — | — |

---

## UltraRich

**Accessor:** `LootPack.UltraRich`  
**Typical users:** Champion bosses (×3), elder dragons, ancient wyrms, powerful uniques

| Chance | Entry | Count | Props | Intensity |
|--------|-------|-------|-------|-----------|
| 100% | Gold (6d100+600 ≈ avg 900) | 1 stack | — | — |
| 100% ×6 | [Magic item (UltraRich pool)](magic-item-pools.md#ultrarich) | 2–5 | 5 | 40–70% |
| 8% | [Instrument](../../../items/instruments.md) | 2–5 | 5 | 40–70% |
| 8% | Spellbook | 2–5 | 5 | 40–70% |
| 4% | [Quiver](../../../items/quivers.md) | 2–5 | 5 | 40–70% |
| 2% | [Semi-Artifact](artifact-pools.md#semi-artifacts) | 1 | — | — |
| 1% | [Artifact](artifact-pools.md#artifacts) | 1 | — | — |
| 50% | [High Potion](utility-packs.md#highpotions) | 1 | — | — |

---

## SuperBoss (MegaRich)

**Accessor:** `LootPack.SuperBoss` (also referenced as `LootPack.MegaRich` in some creature files — both return `MonsterMegaRich`)  
**Typical users:** The most powerful creatures in the game — Slasher of Void, Dragon King, ancient champions

| Chance | Entry | Count | Props | Intensity |
|--------|-------|-------|-------|-----------|
| 100% | Gold (10d100+800 ≈ avg 1300) | 1 stack | — | — |
| 100% ×10 | [Magic item (UltraRich pool)](magic-item-pools.md#ultrarich) | 3–5 | 5 | 40–70% |
| 8% | [Instrument](../../../items/instruments.md) | 3–5 | 5 | 40–70% |
| 8% | Spellbook | 3–5 | 5 | 40–70% |
| 6% | [Quiver](../../../items/quivers.md) | 3–5 | 5 | 40–70% |
| 4% | [Semi-Artifact](artifact-pools.md#semi-artifacts) | 1 | — | — |
| 2% | [Artifact](artifact-pools.md#artifacts) | 1 | — | — |
| 75% | [High Potion](utility-packs.md#highpotions) | 1 | — | — |

---

## Notes

- **Multiple calls**: `AddLoot(LootPack.FilthyRich, 2)` generates the pack twice independently — two gold rolls, two sets of magic item rolls.
- **Intensity scaling**: Each pack entry specifies a `minIntensity`–`maxIntensity` range. High-fame creatures in deep dungeons can push effective intensity well above the listed maximum. See [Magic Item Pools](magic-item-pools.md#intensity-scaling).
- **Currency**: All Gold output is converted to a tiered coin mix or zone-specific currency. See [Currency Conversion](README.md#currency-conversion).
