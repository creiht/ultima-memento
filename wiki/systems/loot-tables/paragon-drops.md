# Paragon Drops

Paragons are elite versions of normal creatures that spawn only on **Serpent Island**. They are visually distinguished by their distinctive blue-purple hue (`0x845`) and have dramatically increased stats, skills, and fame.

**Source:** `World/Source/Scripts/Mobiles/Base/Paragon.cs`

[Back to Loot Tables](README.md)

---

## Paragon Stats

When a creature is converted to a paragon via `Paragon.Convert()`:

| Stat | Multiplier |
|------|-----------|
| Hits (max seed) | ×5.0 |
| Strength | ×1.05 |
| Intelligence | ×1.20 |
| Dexterity | ×1.20 |
| Skills | ×1.20 |
| Movement speed | ÷1.20 (faster) |
| Damage | +5 (flat) |
| Fame | ×1.40 (cap 32,000) |
| Karma | ×1.40 |

---

## Paragon Chest

Paragons have a **10% chance** to carry a `ParagonChest`. This is a locked, trapped chest filled using the standard chest-filling system scaled to the paragon's effective level.

---

## Loot Bonus

Paragon loot is generated in `BaseCreature.GenerateLoot(bool dying)`. After the creature's own `GenerateLoot()` override runs, the paragon augment appends an extra pack based on the (boosted) fame level. The specific pack tier is determined by the paragon's modified fame value.

---

## Artifact Roll (`CheckArtifactChance`)

On death, if the paragon rolls a successful `CheckArtifactChance()`, a random artifact from [Loot.RandomArty()](artifact-pools.md#artifacts) is placed directly into the **killer's backpack** (or at their feet if full), with the message:

> *"As a reward for slaying the cursed creature, an artifact has been placed in your backpack."*

The probability formula:

```
chance = 1 / (max(10, 100 × (0.83 − log10(round(fame/6000 + 0.001, 3)))) × (100 − sqrt(luck)) / 100)
```

Where `fame` is the paragon's (boosted) fame value (cap 32,000) and `luck` is the killer's luck stat. Higher fame and higher luck both increase the chance.

**Approximate thresholds:**

| Paragon Fame | Approx. Artifact Chance (luck 0) |
|-------------|----------------------------------|
| 3,000 | ~0.8% |
| 6,000 | ~1.1% |
| 12,000 | ~1.5% |
| 24,000 | ~2.5% |
| 32,000 | ~4%+ |

> Paragons only spawn on Serpent Island. The `CheckConvert()` function rejects conversion for BlackGateDemon, BasePerson, Citizens, BaseVendor, Clone, creatures in the Castle of the Black Knight region, and creatures with Fame < 1,000.
