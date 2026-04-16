# The World of Ultima Memento

The game world of Ultima Memento spans multiple lands (facets) connected by moongates, ships, and magical portals. Each land has its own settlements, dungeons, creatures, and resources. Some resources and creatures are unique to specific lands, encouraging exploration and travel.

## Lands Overview

| Land | Map Size (tiles) | Description |
|------|------------------|-------------|
| [Sosaria](sosaria.md) | 7168 × 4096 | The primary homeland and starting area. Contains the largest number of towns, dungeons, and regions. |
| [Lodoria](lodoria.md) | 7168 × 4096 | A vast continent featuring classic UO-style dungeons and many settlements. |
| [Serpent Island](serpent-island.md) | 2560 × 2048 | A dangerous volcanic island chain with themed dungeons of vice and virtue. |
| [Isles of Dread](isles-of-dread.md) | 1448 × 1448 | Remote and perilous islands with icy fortresses and ancient temples. |
| [Savaged Empire](savaged-empire.md) | 1280 × 4096 | A primal jungle land with tribal villages and monster-filled ruins. |
| [Underworld](underworld.md) | 2304 × 1600 | A dark subterranean realm of infernos, abysses, and ancient sky ships. |

### Sub-Regions of Sosaria

The Sosaria map also contains several distinct sub-regions that are geographically separate areas on the same map file:

| Sub-Region | Description |
|------------|-------------|
| **Ambrosia** | A lost continent on the Sosaria map, home to the Cave of the Zuluu, the City of the Dead, and the Dragon's Maw. |
| **Umber Veil** | A dark island chain containing the Mausoleum and the Tower of Brass. |
| **Kuldar** | A bottle world accessible from Sosaria, featuring the City of Kuldara, Vordo's Castle, and unique dungeons. |
| **Luna** | A small area on the Sosaria map. |
| **Skara Brae** | A quest-driven area on the Lodoria map with special entry requirements. |

### Additional Map

| Map | Description |
|-----|-------------|
| **Atlantis** | A special map (index 6) that shares the same map data as Sosaria. |

## Navigation

- Travel between lands via **moongates**, **ships**, and **magical portals**
- Use `[magicgate` to locate the nearest moongate
- Some areas have entry warnings (Skara Brae, Bottle City of Kuldar)
- Dungeon portals with exits can be toggled in server settings

## Difficulty System

Monster difficulty scales by dungeon tier:

| Tier | Difficulty Increase |
|------|-------------------|
| Normal | +0% |
| Difficult | +30% |
| Challenging | +60% |
| Hard | +90% |
| Deadly | +120% |

The difficulty increase affects creature attributes, skills, fame, karma, statistics, taming requirements, and gold drops.

## Region-Locked Premium Materials

Certain premium crafting materials can only be obtained in specific facets or regions. See [crafting/README.md](../crafting/README.md) for complete material tier details.

| Facet / Region | Premium Material | Notes |
|---|---|---|
| Sea exploration + Shipwreck Grotto / Barnacled Cavern | Nepturite ore, Driftwood logs | Mine Agapite/Verite/Valorite veins in sea regions for 50% mutation chance |
| Serpent Island | Obsidian ore | 50% mutation on Agt/Ver/Val veins |
| Savaged Empire | Steel ore | 50% mutation on Agt/Ver/Val veins |
| Umber Veil (Sosaria sub-region) | Brass ore | 50% mutation on Agt/Ver/Val veins |
| Underworld (Sosaria/Lodoria/IslesDread/Serpent maps) | Mithril ore, Petrified wood | All Agt/Ver/Val mutations; all non-Regular wood mutations |
| Underworld (Savaged Empire map) | Xormite ore | 50% mutation on Agt/Ver/Val veins |
| NecromancerRegion dungeons (various maps) | Ebony wood (lower tiers), Ghostwood (higher tiers) | Triggered by region type on wood chop |
| Isles of Dread | Boosted ore & wood yield | ConsumedPerIslesDreadHarvest: base + ceil(base/2) + 2 |
| the Mines of Morinia (Sosaria) | +66% ore yield | 2-in-3 chance of boosted harvest per swing |
| Kuldar + ancient sky ship (Sosaria) | Sci-Fi metals, leathers, scales, bones, woods | Dropped by droids and alien creatures |

## See Also

- [Dungeons](dungeons.md) — Complete dungeon listing by land
- [Crafting Systems](../crafting/README.md) — All crafting professions and material tiers
