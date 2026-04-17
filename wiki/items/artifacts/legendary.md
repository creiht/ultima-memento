# Legendary Artefacts

Legendary Artefacts are player-forged, permanently blessed, leveling equipment items created by **Arez, the God of Legends** at the Hall of Legends. They are an entirely separate system from the [Sage artifact quest line](README.md) — they are not found on Search stones, have no fixed stats, and belong to a single owner by name.

Every Legendary Artefact:
- Is **named after you** (e.g. *"the Ancient Longsword of Gabriel"* or *"Gabriel's Ancient Longsword"*).
- Shows a yellow **Legendary Artefact** tooltip tag.
- Is permanently **blessed** — kept on death, never lost to PvP.
- **Never wears out** — durability is automatically restored.
- Is **immune to item-destroying traps**.
- Gains experience as you fight while wearing it, earning attribute points you can spend however you like.

---

## Obtaining a Legendary Artefact

### Hall of Legends — Arez

Travel to the **Hall of Legends** and speak with **Arez, the God of Legends**. Inside the hall you will find a *Legendary Artefacts* book on a pedestal. Double-click it to browse all 290 available items grouped across 19 pages.

**Requirements to claim an artefact:**

| Requirement | Amount |
|---|---|
| Fame | 15,000 minimum |
| Karma | 15,000 minimum (absolute value — evil characters qualify) |
| Gold tribute | 10,000 gold (consumed from your backpack) |

When you select an item and confirm:

1. 10,000 gold is deducted.
2. Both your **Fame and Karma are reset to 0** — a player with 50,000 fame loses all of it.
3. The server creates the item, assigns it a randomly-chosen magic adjective and your name (see [Naming](#naming)), and places it in your backpack.

### Naming

The item's name always includes a magic adjective and your character's name in one of two formats chosen randomly:

- `the <Adjective> <Item> of <Your Name>` — e.g. *the Ancient Longsword of Gabriel*
- `<Your Name>'s <Adjective> <Item>` — e.g. *Gabriel's Ancient Longsword*

The item cannot be renamed except with a [Legendary Branding Iron](#legendary-branding-iron).

---

## Permanent Properties

All Legendary Artefacts share these properties regardless of slot:

| Property | Details |
|---|---|
| Blessed | Kept on death; cannot be looted in PvP |
| Auto-repair | Durability is automatically restored by the server — the item never degrades |
| Trap immune | Destroyed-by-trap effects do not apply |
| Mundane appearance | The item looks like an ordinary base item (e.g. a plain longsword), not a special graphic |
| Artifact tooltip | Yellow *"Legendary Artefact"* label in the item properties |
| Weapon abilities | **5 weapon abilities** (Primary through Fifth) instead of the usual 2 — this is a server extension beyond the standard two-ability limit |

---

## Leveling

### Experience Formula

The total XP required to **reach** level *n* is:

```
exp_to_level(n) = ((n + 1) × 10)² − 100
```

| Level | XP to reach this level | XP per-kill cap |
|-------|------------------------|-----------------|
| 1 | 300 | 40 |
| 2 | 800 | 72 |
| 3 | 1,500 | 120 |
| 4 | 2,400 | 184 |
| 5 | 3,500 | 264 |
| 10 | 12,000 | 715 |
| 15 | 25,500 | 1,440 |
| 20 | 44,000 | 2,475 |
| 25 | 67,500 | 3,820 |
| 30 | 96,000 | 5,475 |
| 35 | 129,500 | 7,440 |
| 39 | 159,900 | 8,960 |
| 40 | 168,000 | — (max level) |

The per-kill XP cap = `exp_to_level(level + 1) / 20`. This keeps early leveling slow against trivial monsters; you must hunt creatures tough enough to give meaningful XP.

### How XP is Earned

XP is awarded to the **equipped item that scored the kill**. Only one item gains XP per kill (the weapon or slot item that dealt the finishing blow).

Base XP from a kill:

```
xp = (target.Hits + target.Stam + target.Mana + sum_of_all_skills) / 10
```

Bonuses added **before** the division by 10 (and before diminishing returns):

| Condition | Bonus |
|---|---|
| Target uses Mage AI (has Magery > 5) | +100 |
| Target has a breath weapon | +100 |
| Target is poison immune | +100 |
| Target is a Vampire Bat | +100 |
| Target has a hit-poison attack (per poison level) | ×20 per level |

**Diminishing returns:** if the raw total exceeds 700, the excess is divided by 3.67 before adding it back. Weak, low-stat creatures yield very little XP even without the cap.

### Points Per Level

Each level-up awards **5 attribute points**. The **final level-up to level 40** awards **10 points** instead of 5.

**Total attribute points at level 40: 205** (5 × 39 + 10).

---

## Spending Points

Use `[itemexp` (or `[ixp`) to open the attribute-spending interface. Points are spent one attribute at a time; each point purchase costs the listed amount and increments that attribute by 1 up to its cap.

### Universal Attributes (all slot types)

| Attribute | Category | Cost per +1 | Cap |
|---|---|---|---|
| Regen Hits | Stats | 5 | 5 |
| Regen Stamina | Stats | 5 | 5 |
| Regen Mana | Stats | 5 | 5 |
| Defence Chance Increase | Melee | 8 | 15 |
| Hit Chance Increase | Melee | 10 | 15 |
| Bonus Strength | Stats | 10 | 10 |
| Bonus Dex | Stats | 10 | 10 |
| Bonus Int | Stats | 10 | 10 |
| Bonus Hits | Stats | 5 | 20 |
| Bonus Stamina | Stats | 5 | 20 |
| Bonus Mana | Stats | 5 | 20 |
| Damage Increase | Melee | 5 | 50 |
| Swing Speed Increase | Melee | 6 | 40 |
| Spell Damage | Magic | 4 | 25 |
| Faster Cast Recovery | Magic | 20 | 4 |
| Faster Casting | Magic | 20 | 4 |
| Lower Mana Cost | Magic | 5 | server cap |
| Lower Reagent Cost | Magic | 5 | server cap |
| Reflect Physical Damage | Melee | 2 | 50 |
| Enhance Potions | Magic | 2 | 25 |
| Luck | Misc | 2 | 500 |
| Spell Channeling | Magic | 15 | 1 (flag) |
| Nightsight | Misc | 6 | 1 (flag) |

### Weapon-Only Attributes

| Attribute | Category | Cost per +1 | Cap |
|---|---|---|---|
| Lower Stat Requirement | Stats | 2 | 100 |
| Hit Life Leech | Hit Effects | 3 | 50 |
| Hit Stamina Leech | Hit Effects | 3 | 50 |
| Hit Mana Leech | Hit Effects | 3 | 50 |
| Hit Lower Attack | Hit Effects | 3 | 50 |
| Hit Lower Defence | Hit Effects | 3 | 50 |
| Hit Magic Arrow | Hit Effects | 3 | 50 |
| Hit Harm | Hit Effects | 3 | 50 |
| Hit Fireball | Hit Effects | 3 | 50 |
| Hit Lightning | Hit Effects | 3 | 50 |
| Hit Dispel | Hit Effects | 3 | 50 |
| Hit Cold Area | Hit Effects | 3 | 50 |
| Hit Fire Area | Hit Effects | 3 | 50 |
| Hit Poison Area | Hit Effects | 3 | 50 |
| Hit Energy Area | Hit Effects | 3 | 50 |
| Hit Physical Area | Hit Effects | 3 | 50 |
| Resist Physical Bonus | Resists | 5 | 20 |
| Resist Fire Bonus | Resists | 5 | 20 |
| Resist Cold Bonus | Resists | 5 | 20 |
| Resist Poison Bonus | Resists | 5 | 20 |
| Resist Energy Bonus | Resists | 5 | 20 |
| Use Best Weapon Skill | Misc | 10 | 1 (flag) |
| Mage Weapon | Magic | 5 | 1 (flag) |

### Armor-Only Attributes

| Attribute | Category | Cost per +1 | Cap |
|---|---|---|---|
| Lower Stat Requirement | Stats | 2 | 100 |
| Mage Armor | Magic | 5 | 1 (flag) |

### Armor Resistances (armor pieces only)

| Resistance | Cost per +1 | Cap |
|---|---|---|
| Physical Resistance | 5 | 20 |
| Fire Resistance | 5 | 20 |
| Cold Resistance | 5 | 20 |
| Poison Resistance | 5 | 20 |
| Energy Resistance | 5 | 20 |

### Jewel & Clothing Resistances

Jewelry and clothing use a different property path (`AosElementAttribute`) but are functionally identical to players:

| Resistance | Cost per +1 | Cap |
|---|---|---|
| Physical Resistance | 5 | 20 |
| Fire Resistance | 5 | 20 |
| Cold Resistance | 5 | 20 |
| Poison Resistance | 5 | 20 |
| Energy Resistance | 5 | 20 |

---

## Related Items

### Enhancement Rune

An Enhancement Rune raises the item's **maximum level cap** beyond 40, allowing it to continue gaining experience and attribute points.

| Rune Tier | Max Level Increase |
|---|---|
| Wondrous rune of enhancing | +5 |
| Exalted rune of enhancing | +10 |
| Mythical rune of enhancing | +15 |
| Legendary rune of enhancing | +20 |

Double-click the rune and target the Legendary Artefact. A blacksmith-validation workflow exists in the code but is currently disabled on this server.

### Experience Token

An Experience Token stores raw XP. Double-click it and target a Legendary Artefact in your pack or equipped to transfer the XP — it will fill only up to the amount needed to complete the next level, so excess XP on the token is preserved for later.

Tokens can be **merged together** by using one token on another to combine their stored XP into a single token.

Experience Tokens are produced automatically during certain server-side data migrations (one-time conversion of older item versions).

### Legendary Branding Iron

Dropped by **Arez** when you drag any Legendary Artefact onto him. Each use renames the targeted artefact to a custom string of your choice.

| Property | Details |
|---|---|
| Charges | 3 per iron |
| Owner-locked | Only the owner can use it |
| Stacking | Drag one branding iron onto another to combine charges |
| One iron per player | When Arez creates a new iron for you, any existing iron you own is **deleted** — you always have at most one (you cannot stack charges via Arez, only by combining two irons together) |

---

## Commands

| Command | Description |
|---|---|
| `[itemexp` or `[ixp` | Open the **Item Experience** interface on a targeted Legendary Artefact in your pack or equipped. Shows current level, total XP, available points, and a category-grouped attribute-spending UI (Misc, Melee, Magic, Stats, Resists, Hit Effects). |

---

## Full Item Catalog

All 290 items available from the Legendary Artefacts book. Items appear visually as their mundane base form; the legendary properties come entirely from the leveling system.

### Weapons

**Axes:** Axe, Barbarian Axe, Battle Axe, Double Axe, Great Axe, Halberd, Harpoon, Hatchet, Large Battle Axe, Pickaxe, Two Handed Axe, War Axe

**Swords:** Assassin Sword, Barbarian Sword, Bokuto, Broadsword, Claymore, Cutlass, Dagger, Daisho, Falchion, Katana, Longsword, Machete, NoDachi, Rapier, Royal Sword, Rune Blade (War Blades), Scimitar, Short Sword, Sword, Wakizashi, War Cleaver

**Maces & Bludgeons:** Battle Mace, Club, Hammer, Hammer Pick, Mace, Maul, Nunchaku, Scepter, Sceptre, Spiked Club, Tetsubo, War Hammer, War Mace

**Polearms:** Bardiche, Bladed Staff, Crescent Blade, Scythe

**Spears & Forks:** Lance, Pike, Spear, Tribal Spear, Trident, War Fork

**Staves:** Double Bladed Staff, Druid Staff, Gnarled Staff, Quarter Staff, Shepherds Crook, Stave, Wizard Staff

**Bows & Crossbows:** Bow, Composite Bow, Crossbow, Heavy Crossbow, Repeating Crossbow, Woodland Longbow, Woodland Shortbow, Yumi

**Knives:** Assassin Dagger, Butcher Knife, Cleaver, Kama, Kryss, Large Knife, Sai, Sickle, Tekagi, Tessen, War Dagger (Leafblade)

**Unarmed:** Pugilist Gloves, Throwing Gloves

**Whips:** Whip

**Lajatang / Unique:** Lajatang, Wakizashi (also listed above)

### Armor

**Bone:** Bone Arms, Bone Chest, Bone Gloves, Bone Helm, Bone Legs

**Chain:** Chain Chest, Chain Coif, Chain Hatsuburi, Chain Legs

**Leather:** Leather Arms, Leather Bustier Arms, Leather Cap, Leather Chest, Leather Cloak, Leather Gloves, Leather Gorget, Leather Legs, Leather Robe, Leather Shorts, Leather Skirt

**Plate:** Female Plate Chest, Plate Arms, Plate Chest, Plate Gloves, Plate Gorget, Plate Helm, Plate Legs

**Ringmail:** Ringmail Arms, Ringmail Chest, Ringmail Gloves, Ringmail Legs

**Studded:** Female Studded Chest, Studded Arms, Studded Bustier Arms, Studded Chest, Studded Gloves, Studded Gorget, Studded Legs

**Royal Set:** Royal Arms, Royal Boots, Royal Chest, Royal Gloves, Royal Gorget, Royal Helm, Royal Legs

**Scalemail / Dragon:** Scalemail Arms, Scalemail Gloves, Scalemail Helm, Scalemail Leggings, Scalemail Tunic

**Wooden Plate:** Wooden Plate Arms, Wooden Plate Chest, Wooden Plate Gloves, Wooden Plate Gorget, Wooden Plate Helm, Wooden Plate Legs

**Samurai / Japanese:** Decorative Plate Kabuto, Heavy Plate Jingasa, Leather Do, Leather Haidate, Leather HiroSode, Leather Jingasa, Leather Mempo, Leather Suneate, Light Plate Jingasa, Plate Battle Kabuto, Plate Do, Plate Haidate, Plate Hatsuburi, Plate Hiro Sode, Plate Mempo, Plate Suneate, Small Plate Jingasa, Standard Plate Kabuto, Studded Do, Studded Haidate, Studded Hiro Sode, Studded Mempo, Studded Suneate

**Oniwaban:** Oniwaban Boots, Oniwaban Gloves, Oniwaban Hood, Oniwaban Leggings, Oniwaban Tunic

**Shinobi:** Leather Ninja Hood, Leather Ninja Jacket, Leather Ninja Mitts, Leather Ninja Pants, Leather Shinobi Cowl, Leather Shinobi Hood, Leather Shinobi Mask, Leather Shinobi Robe

**Loose Helms:** Bascinet, Circlet, Close Helm, Dread Helm, Female Leather Chest, Helmet, Horned Helm, Norse Helm

### Shields

Buckler, Champion Shield, Chaos Shield, Crested Shield, Dark Shield, Elven Shield, Guardsman Shield, Heater Shield, Jeweled Shield, Large Shield (Bronze), Metal Kite Shield, Metal Shield, Order Shield, Royal Shield, Scalemail Shield, Sun Shield, Virtue Shield, Wooden Kite Shield, Wooden Shield

### Clothing

**Hats:** Bandana, Bonnet, Cap, Feathered Hat, Floppy Hat, Jester Hat, Kasa, Pirate Hat, Skull Cap, Straw Hat, Tall Straw Hat, Tricorne Hat, Wide Brim Hat, Witch Hat, Wizards Hat

**Cloaks & Capes:** Cloak, Fur Cape, Royal Cape

**Robes & Dresses:** Fancy Dress, Gilded Dress, Jester Suit, Plain Dress, Robe

**Shirts & Doublets:** Doublet, Fancy Shirt, Formal Shirt, Surcoat, Tunic

**Kimonos & Hakama:** Female Kimono, Hakama, Hakama Shita, Jin Baori, Kamishimo, Male Kimono, Tattsuke Hakama

**Sashes & Belts:** Belt, Body Sash, Obi, Sash

**Aprons:** Full Apron, Half Apron

**Ninja Cloth:** Cloth Ninja Hood, Cloth Ninja Jacket

**Pants & Skirts:** Kilt, Loin Cloth, Long Pants, Short Pants, Skirt

**Boots & Shoes:** Boots, Fancy Boots, Fur Boots, Ninja Tabi, Samurai Tabi, Sandals, Shoes, Thigh Boots, Waraji

**Misc Clothing:** Cowl, Fur Sarong, Hood

**Masks:** Bear Mask, Deer Mask, Horned Tribal Mask, Tribal Mask, Wolf Mask

### Jewelry

Amulet, Bead Necklace, Gold Amulet, Gold Bracelet, Gold Earrings, Gold Ring, Silver Amulet, Silver Bead Necklace, Silver Bracelet, Silver Earrings, Silver Ring

### Trinkets

| Display Name | Notes |
|---|---|
| Trinket, Talisman | Leather talisman |
| Trinket, Symbol | Holy symbol |
| Trinket, Idol | Snake idol |
| Trinket, Totem | Totem |

### Offhand Light Sources

Candle, Lantern, Torch

---

## Tips

- **Focus on one item** until it is high-level before spreading XP across multiple artefacts — XP only goes to the item that finishes the kill.
- **Hunt hard monsters**: weak mobs give very little XP due to diminishing returns and the per-kill cap. You need enemies with high stats and skills to make meaningful progress, especially at low levels.
- **Enhancement Runes** are most valuable once your item already sits at level 40 and you want to push further; there is no benefit to using them early.
- **Karma zeroes on claim**: if you rely on high Karma for other systems, plan your Legendary Artefact pickup accordingly — you will need to rebuild from zero.
- **One branding iron at a time**: visiting Arez deletes your old iron. To stockpile charges, combine two irons by dragging one onto the other before going back to Arez.
- Use `[ixp` in the field to check your item's current level and how close you are to the next level-up without needing to open your pack.
