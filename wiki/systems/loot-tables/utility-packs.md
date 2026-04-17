# Utility Packs

Utility packs are single-item wrapper packs that always drop exactly one item from their pool. They are used as entries inside monster and treasure packs, or called directly via `AddLoot()`.

**Source:** `World/Source/Scripts/Items/Containers/LootPack.cs` (lines 443–451)

[Back to Loot Tables](README.md)

---

## Scrolls

### LowScrolls
Drops one random low-tier magic scroll (spells 1–16 of Magery circle 1–4).  
**Scroll range:** Circle 1–4 spells (e.g., Clumsy, Create Food, Feeblemind, Fireball…)

### MedScrolls
Drops one random mid-tier magic scroll (circles 5–7).  
**Scroll range:** Arch Cure, Arch Protection, Chain Lightning range

### HighScrolls
Drops one random high-tier magic scroll (circles 7–8, top spells).  
**Scroll range:** Chain Lightning, Energy Field, Meteor Swarm, Resurrection…

> **Note:** The scroll tier tokens (`ClumsyScroll`, `ArchCureScroll`, `ChainLightningScroll`) are just placeholders; `Loot.RandomScroll(tier)` picks the actual scroll at generation time.

See [Magical Items (Scrolls)](../../items/magical.md) for the full scroll list.

---

## Gems

### Gems
Drops one random gem from `Loot.RandomGem()`.  
**Possible gems:** Amber, Amethyst, Citrine, Diamond, Emerald, Ruby, Sapphire, Star Sapphire, Tourmaline (and any stackable variants).

> In sci-fi regions, gems are replaced with themed crystal types (kyber, etaan, trilithium, lava, dilithium, dantari, vexxtal, nova, permafrost crystals).

See [Gems](../../items/gems.md) for details.

---

## Potions

### LowPotions
Drops one random low-tier potion.  
**Examples:** Lesser Heal, Lesser Cure, Lesser Refresh, Lesser Explosion

### MedPotions
Drops one random mid-tier potion.  
**Examples:** Heal, Cure, Refresh, Explosion

### HighPotions
Drops one random high-tier potion.  
**Examples:** Greater Heal, Greater Cure, Greater Refresh, Greater Explosion, Greater Strength, Greater Agility…

> **Tasting skill bonus**: A player with 30+ Tasting has a chance to upgrade potion tier — `LesserHeal` may become `Heal`, `Heal` may become `GreaterHeal`.

See [Potions](../../items/potions.md) for details.

---

## Songs

### Songs
Drops one random Bard song scroll (`FoeRequiemScroll` family via `Loot.RandomSong()`).  
Used by bard-type creatures.

---

## Music

### Music
Drops one random musical instrument (same pool as the `BaseInstrument` entry in regular packs via `Loot.RandomInstrument()`).

See [Instruments](../../items/instruments.md).
