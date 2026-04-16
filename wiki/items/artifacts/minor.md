# Minor Artifacts

Minor artifacts are utility and flavor items tagged as `ArtifactLevel.Artifact` or `ArtifactLevel.DecorativeArtefact`. They are **not** obtained through the Sage Artifact Quest — each comes from specific encounters, loot tables, or fixed spawns. Sources noted below reflect the class definition; precise drop locations are tied to spawn scripts rather than the item class files.

See [README](README.md) for general artifact information.

| Name | Base Type | Level | Weight | Effect / Notes | Source |
| --- | --- | --- | --- | --- | --- |
| Admiral's Hearty Rum | BeverageBottle (Ale) | Decorative | — | Functional ale bottle; decorative collectible | Rare loot |
| Book of Prismatic Magic | Item | Artifact | 1.0 | Double-click opens a color-selector gump with 577 colors (Blue, Green, Orange, Pink, Red, Yellow, Neutral, Gargoyle, Serpent, Avian, Slime, Animal, Metal, Silver variants). Select a color, then target any item in your backpack to instantly recolor it. The book retains the last selected color. | Rare loot |
| Candelabra of Souls | CandelabraStand | Decorative | — | Functional candelabra; decorative collectible | Rare loot |
| Everlasting Bottle | Item | Artifact | 1.0 | Double-click to instantly set your **Thirst to 20** (fully quenched). The bottle magically refills. No charges — unlimited uses. | Rare loot |
| Everlasting Loaf | Item | Artifact | 1.0 | Double-click to instantly set your **Hunger to 20** (fully fed). The loaf magically reforms. No charges — unlimited uses. | Rare loot |
| Gem of Seeing | Item | Artifact | 1.0 | Double-click, then target an area (range 10 tiles; 22 if inside a friendly house). Reveals hidden players and detects/disarms hidden traps and chests within range. Starts with **50 charges**; when all charges are consumed the gem is destroyed. | Rare loot |
| Ghost Ship Anchor | Item | Decorative | 80.0 | Decorative large anchor with ghostly hue; no functional effect | Rare loot |
| Gold Bricks | Item | Decorative | — | Decorative stacked gold ingots; no functional effect | Rare loot |
| Pandora's Box | Item | Artifact | 5.0 | Double-click to open your **bank box** from anywhere (no need to be near a banker). Starts with **200 charges**. When charges run out the box transforms into a plain metal box and is destroyed. | Rare loot |
| Phillip's Wooden Steed | MonsterStatuette | Decorative | — | Collectible animated horse statuette; double-click to toggle animation | Rare loot |
| Seahorse Statuette | MonsterStatuette | Decorative | — | Collectible animated seahorse statuette in a random color; double-click to toggle animation | Rare loot |
| Ship Model of the HMS Cape | Item | Decorative | — | Decorative ship model; no functional effect | Rare loot |

## Special Effect Details

- **Book of Prismatic Magic**: Opens the Prismatic Magic gump with 577 named color swatches across 13 color families. Select a swatch to charge the book with that color, then target an item in your backpack to recolor it. The book can be used indefinitely (no charges).
- **Everlasting Bottle**: No charges; sets thirst to maximum (20 / 20) each use. Cannot be used in Sci-Fi regions where the item is replaced by a Canteen.
- **Everlasting Loaf**: No charges; sets hunger to maximum (20 / 20) each use. Triggers the eating animation.
- **Gem of Seeing**: 50 charges total. Range 10 normally, 22 tiles inside a friendly house. Reveals hidden players and flags/deletes hidden treasure chests (`HiddenChest`). Source: `Items/Magical/Artifacts/Minor/GemOfSeeing.cs`.
- **Pandora's Box**: 200 charges. When the last charge is used, the box is replaced by a plain metal box (hue 0x492).

## Cross-links

- [Special Items](../special.md) — Fountain of Life, Slaver's Net, Dragon Eggs, and other special items
- [Artifacts Overview](README.md)
