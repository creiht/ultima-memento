# Clothing

Clothing items provide no base combat resistance but can have **magical properties** (resistances, stat bonuses, skill bonuses) added via crafting or loot generation. All clothing is dyeable, blessable, and craftable via **Tailoring**. Exceptional quality clothing provides bonus magical properties.

## Clothing Properties

All clothing items share these properties:

| Property | Notes |
|----------|-------|
| Base resistances | 0 physical/fire/cold/poison/energy (no base combat protection) |
| Dyeable | Yes — all clothing implements the dye tub system |
| Blessable | Yes — use a [Clothing Bless Deed](deeds.md) to prevent loss on death |
| Quality | Low / Regular / Exceptional (exceptional adds bonus properties) |
| Durability | Hit points degrade with use/damage |
| STR requirement | 0 for all standard clothing |
| Magical properties | Can have AosAttributes (stat bonuses, regen), AosSkillBonuses (up to 5), AosResistances (physical/fire/cold/poison/energy) |
| Crafting | Tailoring skill with cloth or leather material |

## Clothing Slots & Common Items

### Shirt Slot (Layer.Shirt)

| Item | Weight | Notes |
|------|--------|-------|
| Fancy Shirt | 2.0 | Decorative, common |
| Plain Shirt | 1.0 | |
| Tunic | 1.0 | |
| Studdable Shirt | 2.0 | |
| Royal Coat | 2.0 | Named NPC clothing |
| Squire Shirt | 2.0 | |

### Middle Torso (Layer.MiddleTorso)

| Item | Weight | Notes |
|------|--------|-------|
| Doublet | 2.0 | |
| Vest | 1.0 | |
| Jerkin | 2.0 | |
| Tunic (mid) | 2.0 | |

### Outer Torso (Layer.OuterTorso)

| Item | Weight | Notes |
|------|--------|-------|
| Surcoat | 3.0 | |
| Plate Mail (Cloth) | 3.0 | |
| Dress | 3.0 | |
| Formal Dress | 3.0 | |

### Robe (Layer.OuterTorso)

| Item | Weight | Notes |
|------|--------|-------|
| Robe | 3.0 | Full covering robe |
| Female Kimono | 3.0 | Asian style |
| Kimono | 3.0 | Asian style |
| King Robe | 3.0 | |
| Jester Suit | 3.0 | |

### Cloak (Layer.Cloak)

| Item | Weight | Notes |
|------|--------|-------|
| Cloak | 5.0 | Standard cloak |
| Samuari Cloak | 3.0 | |
| Royal Cloak | 5.0 | Special appearance |

### Hat / Helm (Layer.Helm) — Hats

| Item | Weight | Notes |
|------|--------|-------|
| Wide Brim Hat | 1.0 | |
| Tall Straw Hat | 1.0 | |
| Wizard's Hat | 1.0 | |
| Witch's Hat | 1.0 | |
| Skull Cap | 1.0 | |
| Bandana | 1.0 | |
| Cap | 1.0 | |
| Tricorne Hat | 1.0 | |
| Flower Garland | 1.0 | Decoration |
| Bonnet | 1.0 | |
| Fancy Pointy Hat | 1.0 | |
| Summer Hat | 1.0 | |
| Reaper Hood | 2.0 | Dark-themed hood (see Reaper Hoods section) |
| Jester's Hat | 1.0 | |

### Pants (Layer.Pants)

| Item | Weight | Notes |
|------|--------|-------|
| Long Pants | 2.0 | |
| Short Pants | 1.0 | |
| Full Pants | 2.0 | |
| Kilt | 2.0 | |
| Skirt | 2.0 | |

### Outer Legs (Layer.Pants / outer)

| Item | Weight | Notes |
|------|--------|-------|
| Leather Skirt | 3.0 | crafted |
| Thigh Boots (separate from shoe) | — | see Shoes |

### Waist (Layer.Waist)

| Item | Weight | Notes |
|------|--------|-------|
| Half Apron | 1.0 | |
| Full Apron | 2.0 | |
| Obi Sash | 1.0 | |
| Sash | 1.0 | |

### Shoes / Feet (Layer.Shoes)

| Item | Weight | Notes |
|------|--------|-------|
| Shoes | 2.0 | |
| Boots | 3.0 | |
| Thigh Boots | 4.0 | |
| Sandals | 1.0 | |
| Ninja Tabi | 2.0 | Asian footwear |
| Desert Boots | 3.0 | |

### Loin Cloth (Layer.Pants / inner)

| Item | Weight | Notes |
|------|--------|-------|
| Loin Cloth | 1.0 | Minimal coverage |

## Special Clothing

### Reaper Hoods

Dark/sinister hooded items worn in the Helm slot. Various aesthetic variants (skull, shadow, grim reaper, etc.).

### Suits (Full-Body Costume Items)

Suits use `BaseSuit` and occupy the **Shirt layer** in a single piece. They require **GameMaster access level** to equip (cosmetic/display items for NPCs or special occasions).

| Suit | Notes |
|------|-------|
| Death Shroud | Worn by ghost NPCs |
| Dupre Suit | Costume of the legendary paladin Dupre |
| Lord Blackthorne Suit | Costume of Lord Blackthorne |
| Lord British Suit | Costume of Lord British |

## Crafting Materials & Bonuses

The material used to craft clothing affects its appearance and may provide bonus resistances when exceptional quality:

- **Regular Cloth** — standard white/beige appearance
- **Colored Cloth** — dyed variants; no stat difference
- **Leather** — higher durability
- **Spined / Horned / Barbed Leather** — exceptional leatherwork provides elemental resistance bonuses (see [Armor Guide](armor-guide.md) for material resistance details)

## Blessing

Use a [Clothing Bless Deed](deeds.md) to bless a single clothing item. Blessed clothing stays with you on death (not dropped to your corpse).

## Cross-links

- [Tailoring](../../crafting/) — how to craft clothing
- [Armor Guide](armor-guide.md) — material bonus resistance values
- [Deeds](deeds.md) — Clothing Bless Deed and other property deeds
- [Artifacts — Clothing](artifacts/clothing.md) — named artifacts worn in clothing slots
