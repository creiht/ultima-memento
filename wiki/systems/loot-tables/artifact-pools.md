# Artifact Pools

Two distinct artifact pools exist in the game. Both are selected randomly with no weighting — every entry has equal probability.

**Source:** `World/Source/Scripts/Items/Containers/Loot.cs` (lines 511–650)

[Back to Loot Tables](README.md)

---

## Artifacts (`m_ArtyTypes`)

**Accessor:** `Loot.RandomArty()` — selects one item at random from the full pool.  
**Pool size:** ~384 entries (32 rows × 12 columns in source)  
**Quality:** Full named artifacts — unique items with powerful pre-set magical properties.

These items have `ArtifactLevel > None` and are **not** further mutated by `BaseRunicTool` — they drop with their fixed stats.

### Where They Drop

| Source | Chance |
|--------|--------|
| [Monster FilthyRich](monster-packs.md#filthyrich) | 0.5% per pack generation |
| [Monster UltraRich](monster-packs.md#ultrarich) | 1% per pack generation |
| [Monster SuperBoss](monster-packs.md#superboss-megarich) | 2% per pack generation |
| [Treasure FilthyRich](treasure-packs.md#tfilthyrich) | 0.25% per fill |
| [Treasure UltraRich](treasure-packs.md#tultrarich) | 0.5% per fill |
| [Treasure MegaRich](treasure-packs.md#tmegarich) | 0.75% per fill |
| [Paragon](paragon-drops.md) | Fame-based probability via `CheckArtifactChance()` |
| [Champion OnDeath](champion-rewards.md) | `ArtifactRewardChance`% (set per spawn) |
| [BaseChampion boss item](champion-rewards.md) | `GetArtifact()` — 30% chance for a `DecorativeList` item |

### Artifact Categories

The pool spans all item categories. See the sub-pages under [Artifacts](../../../items/artifacts/) for full listings by type:

- [Artifact Weapons](../../../items/artifacts/weapons.md)
- [Artifact Armor](../../../items/artifacts/armor.md)
- [Artifact Shields & Offhands](../../../items/artifacts/offhands.md)
- [Artifact Trinkets](../../../items/artifacts/trinkets.md)
- [Artifact Clothing](../../../items/artifacts/clothing.md)
- [Artifact Quivers](../../../items/artifacts/quivers.md)
- [Artifact Instruments](../../../items/artifacts/instruments.md)
- [Artifact Books](../../../items/artifacts/books.md)
- [Artifact Armor Sets](../../../items/artifacts/armor-sets.md)
- [Minor Artifacts](../../../items/artifacts/minor.md)

---

## Semi-Artifacts (`m_SArtyTypes`)

**Accessor:** `Loot.RandomSArty(playOrient, mobile)` — selects from the standard or oriental variant.  
**Pool size:** ~168 entries  
**Quality:** Decorative items, utility items, bags of holding, soul stones, deeds, special crafting components, dice, manuals, and themed furniture deeds.

Semi-artifacts are not combat upgrades — they are collectibles, furniture deeds, and useful miscellaneous items. They have `NotModAble` set or `ArtifactLevel = None` but are considered a special drop tier above normal magic items.

### Examples from the Pool
Gold Bricks, Bed of Nails deed, Soul Stone, Red/Blue Soul Stone, Haunter Mirror deed, Creepy Portrait deed, Guillotine deed, Wind Spirit, Suit of Gold Armor deed, Suit of Silver Armor deed, Everlasting Bottle, Everlasting Loaf, Gem of Seeing, Slayer Deed, Lucky Horseshoes, Fire Horn, Bags of Holding (all sizes), Pandora's Box, Monster Manual, Player's Handbook, Dungeon Master's Guide, Dragon Orb Statue, and many more.

### Where They Drop

| Source | Chance |
|--------|--------|
| [Monster Rich](monster-packs.md#rich) | 1% per pack generation |
| [Monster FilthyRich](monster-packs.md#filthyrich) | 1% per pack generation |
| [Monster UltraRich](monster-packs.md#ultrarich) | 2% per pack generation |
| [Monster SuperBoss](monster-packs.md#superboss-megarich) | 4% per pack generation |
| [Treasure Rich](treasure-packs.md#trich) | 0.5% per fill |
| [Treasure FilthyRich](treasure-packs.md#tfilthyrich) | 0.5% per fill |
| [Treasure UltraRich](treasure-packs.md#tultrarich) | 1% per fill |
| [Treasure MegaRich](treasure-packs.md#tmegarich) | 2% per fill |

### Oriental Variant (`m_SArtyOrientTypes`)

When the killer has the oriental play flag set, `RandomSArty` uses a smaller oriental-themed pool:  
White Hanging Lantern, Shoji Lantern, Round Paper Lantern, Red Hanging Lantern, Paper Lantern, Tower Lantern, Origami Paper, Wind Chimes, Fancy Wind Chimes, Bamboo Screen, Shoji Screen, and 5 Oriental Basket variants, plus `OrientalItems`.
