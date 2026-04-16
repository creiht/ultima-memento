# Trinkets

Trinkets include jewelry (rings, necklaces, bracelets, earrings, circlets), wands, talismans, and light-source trinkets. They provide stat bonuses, resistances, skill bonuses, and special effects.

## Jewelry

Jewelry is crafted via Tinkering using metal and gem resources. All jewelry weighs 0.1 stones.

| Item | Equip Slot | How to Obtain |
|------|-----------|---------------|
| Ring | Ring finger | Crafting, loot, merchants |
| Bracelet | Wrist | Crafting, loot, merchants |
| Necklace | Neck | Crafting, loot, merchants |
| Earrings | Ears | Crafting, loot, merchants |
| Circlet | Head (Helm) | Crafting, loot |

### Jewelry Properties

- **Base resistances**: 0 physical / 0 fire / 0 cold / 0 poison / 0 energy (jewelry has no inherent base resistance — all resistance values come from magical properties or material bonuses)
- **Quality**: Low, Regular, Exceptional
- **Gem Type**: Star Sapphire, Emerald, Sapphire, Ruby, Citrine, Amethyst, Tourmaline, Amber, Diamond, Pearl — affects appearance and value
- **Metal Resource**: Metal tier affects resistance bonus values when exceptional quality
- **Attributes**: Can have AoS attributes (Strength, Dexterity, Intelligence bonuses, HP, Stamina, Mana, all regen types, etc.)
- **Resistances**: Physical, Fire, Cold, Poison, Energy
- **Skill Bonuses**: Up to 5 skill bonuses
- **Durability**: Has hit points; repaired with tinkering tools or Tinker's Deeds

## Guild Rings

Special rings given when joining a guild. Each provides significant skill bonuses for that guild's disciplines. **Only wearable by the ring's owner.**

| Guild | Skill Bonuses |
|-------|--------------|
| Wizards Guild | +10 Psychology, +10 Magery, +10 Meditation |
| Warriors Guild | +10 Fencing, +10 Bludgeoning, +10 Parry, +10 Swords, +10 Tactics |
| Thieves Guild | +10 Hiding, +10 Lockpicking, +10 Snooping, +10 Stealing, +10 Stealth |
| Rangers Guild | +25 Camping, +25 Tracking |
| Healers Guild | +15 Anatomy, +15 Healing, +15 Veterinary |
| Miners Guild | +30 Mining |
| Merchants Guild | +15 Mercantile, +15 Arms Lore, +15 Tasting |
| Tinkers Guild | +30 Tinkering |
| Tailors Guild | +30 Tailoring |
| Mariners Guild | +30 Seafaring |
| Bards Guild | +10 Discordance, +10 Musicianship, +10 Peacemaking, +10 Provocation |
| Blacksmiths Guild | +20 Blacksmithing, +20 Arms Lore |
| Black Magic Guild | +10 Forensics, +10 Necromancy, +10 Spiritualism |
| Alchemists Guild | +15 Alchemy, +15 Cooking, +15 Tasting |
| Druids Guild | +10 Druidism, +10 Taming, +10 Herding, +10 Veterinary, +5 Cooking |
| Archers Guild | +10 Marksmanship, +20 Bowcraft, +10 Tactics |
| Carpenters Guild | +20 Carpentry, +20 Lumberjacking |
| Cartographers Guild | +30 Cartography |
| Librarians Guild | +20 Mercantile, +20 Inscription |
| Culinary Guild | +20 Cooking, +20 Tasting |
| Assassins Guild | +10 Fencing, +10 Hiding, +15 Poisoning, +10 Stealth |
| Elemental Guild | +10 Elementalism, +10 Focus, +10 Meditation |

## Magic Wands

Wands are trinket-slot items that cast a magery spell when double-clicked. They require mana to cast (based on the spell level). The wand must be **equipped** to cast from it.

| Property | Details |
|----------|---------|
| Weight | 1.0 |
| Equip Slot | Trinket (hip) |
| Identified By | Mercantile skill |
| Charges | Limited; depleted with each cast |
| Recharging | Visit a wizard NPC — they can recharge a wand if they have the right spell |
| Spell Type | Each wand is enchanted with a specific spell from the full Magery spell list (any of the 64 spells across 8 circles) |
| Mana Cost | Normal mana cost for the spell applies; some spells also consume reagents |

## Talismans

Talismans come in **51 random forms** and provide random magical bonuses. Equipped in the Trinket slot. Forms (source: `TrinketTalisman.cs`):

talisman, idol, totem, symbol, bag/pouch/sack, ankh, censer, cube, lamp, box/chest/casket/coffer, ball/orb/sphere, dice, eye, gem/crystal/jewel, unicorn horn, rose/flower, medal/badge/medallion, skull, scroll/parchment/manuscript, vial/flask/bottle, key, hand/claw, heart, jaw, spine, feather, shell, coin, rune, ring, knife/blade/dagger, tooth, horn, scale, wing, bead, lens, shard, flask/decanter, bone/femur/skull, candle, pendant/medallion, statuette, cog/gear, spring, sextant, compass, bracelet, thread spool

> The talisman randomly picks one of these form names and a random magical attribute combination (resistances, skill bonuses, stat bonuses, etc.).

## Light Sources

| Item | Weight | Light | Slot | Effect |
|------|--------|-------|------|--------|
| Candle | 1.0 | Circle150 | Two-Handed | Night Sight when equipped |
| Lantern | 2.0 | Circle300 | Two-Handed | Night Sight when equipped |
| Torch | 1.0 | Circle300 | Two-Handed | Night Sight when equipped |

Light sources play a sound effect when equipped/unequipped and allow spell casting while held.

## Special Trinkets

| Item | Weight | Properties | How to Obtain |
|------|--------|------------|---------------|
| Old Sword Talisman | 1.0 | +25 Alchemy, +5 Regen Hits, +5 Regen Stam, +20 Bonus Hits, -50 Mana | Special quest/reward, owner-bound |
| Barbaric Talisman | 1.0 | +80 Camping, +50 Cooking | Savage encounters, owner-bound |
