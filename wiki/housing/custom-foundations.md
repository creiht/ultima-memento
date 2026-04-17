# Custom Foundations

Custom (player-designed) houses use the `HouseFoundation` class and are available when `S_AllowCustomHomes = true` (default). They come in **2-Story** and **3-Story** sizes selected from the Construction Contract gump.

## Foundation Materials

Nine foundation material types are available via the `FoundationType` enum:

| Type | Description |
|---|---|
| Stone | Grey stone blocks |
| DarkWood | Dark brown wood |
| LightWood | Light tan wood |
| Dungeon | Dark dungeon stone |
| Brick | Red brick |
| ElvenGrey | Elven grey organic stone |
| ElvenNatural | Elven natural organic stone |
| Crystal | Crystal lattice |
| Shadow | Shadow / black stone |

Source: `World/Source/Scripts/Items/Houses/HouseFoundation.cs:16–26`

## 2-Story Foundations

Sizes range from 7×7 to 13×13. The table below lists every entry. Storage and Lockdowns are the AOS values from the placement entry; NewStorage / NewLockdowns are the AOS-ML values (×1.15 scalar, shown in parentheses where different).

| Size | Storage | Lockdowns | Vendors | Cost (gp) |
|---|---|---|---|---|
| 7×7 | 425 | 212 | 10 | 30,500 |
| 7×8 | 580 | 290 | 14 | 34,500 |
| 7×9 | 650 | 325 | 16 | 38,500 |
| 7×10 | 700 | 350 | 16 | 42,500 |
| 7×11 | 750 | 375 | 16 | 46,500 |
| 7×12 | 800 | 400 | 18 | 50,500 |
| 8×7 | 580 | 290 | 14 | 34,500 |
| 8×8 | 650 | 325 | 16 | 39,000 |
| 8×9 | 700 | 350 | 16 | 43,500 |
| 8×10 | 750 | 375 | 16 | 48,000 |
| 8×11 | 800 | 400 | 18 | 52,500 |
| 8×12 | 850 | 425 | 24 | 57,000 |
| 8×13 | 1,100 | 550 | 24 | 61,500 |
| 9×7 | 650 | 325 | 16 | 38,500 |
| 9×8 | 700 | 350 | 16 | 43,500 |
| 9×9 | 750 | 375 | 16 | 48,500 |
| 9×10 | 800 | 400 | 18 | 53,500 |
| 9×11 | 850 | 425 | 24 | 58,500 |
| 9×12 | 1,100 | 550 | 24 | 63,500 |
| 9×13 | 1,100 | 550 | 24 | 68,500 |
| 10×7 | 700 | 350 | 16 | 42,500 |
| 10×8 | 750 | 375 | 16 | 48,000 |
| 10×9 | 800 | 400 | 18 | 53,500 |
| 10×10 | 850 | 425 | 24 | 59,000 |
| 10×11 | 1,100 | 550 | 24 | 64,500 |
| 10×12 | 1,100 | 550 | 24 | 70,000 |
| 10×13 | 1,150 | 575 | 24 | 75,500 |
| 11×7 | 750 | 375 | 16 | 46,500 |
| 11×8 | 800 | 400 | 18 | 52,500 |
| 11×9 | 850 | 425 | 24 | 58,500 |
| 11×10 | 1,100 | 550 | 24 | 64,500 |
| 11×11 | 1,100 | 550 | 24 | 70,500 |
| 11×12 | 1,150 | 575 | 24 | 76,500 |
| 11×13 | 1,200 | 600 | 26 | 82,500 |
| 12×7 | 800 | 400 | 18 | 50,500 |
| 12×8 | 850 | 425 | 24 | 57,000 |
| 12×9 | 1,100 | 550 | 24 | 63,500 |
| 12×10 | 1,100 | 550 | 24 | 70,000 |
| 12×11 | 1,150 | 575 | 24 | 76,500 |
| 12×12 | 1,200 | 600 | 26 | 83,000 |
| 12×13 | 1,250 | 625 | 26 | 89,500 |
| 13×8 | 1,100 | 550 | 24 | 61,500 |
| 13×9 | 1,100 | 550 | 24 | 68,500 |
| 13×10 | 1,150 | 575 | 24 | 75,500 |
| 13×11 | 1,200 | 600 | 26 | 82,500 |
| 13×12 | 1,250 | 625 | 26 | 89,500 |
| 13×13 | 1,300 | 650 | 28 | 96,500 |

Source: `HousePlacementTool.cs:725–782`

## 3-Story Foundations

3-story foundations start at 9×14 and go up to 18×18.

| Size | Storage | Lockdowns | Vendors | Cost (gp) |
|---|---|---|---|---|
| 9×14 | 1,150 | 575 | 24 | 73,500 |
| 10×14 | 1,200 | 600 | 26 | 81,000 |
| 10×15 | 1,250 | 625 | 26 | 86,500 |
| 11×14 | 1,250 | 625 | 26 | 88,500 |
| 11×15 | 1,300 | 650 | 28 | 94,500 |
| 11×16 | 1,350 | 675 | 28 | 100,500 |
| 12×14 | 1,300 | 650 | 28 | 96,000 |
| 12×15 | 1,350 | 675 | 28 | 102,500 |
| 12×16 | 1,370 | 685 | 28 | 109,000 |
| 12×17 | 1,370 | 685 | 28 | 115,500 |
| 13×14 | 1,350 | 675 | 28 | 103,500 |
| 13×15 | 1,370 | 685 | 28 | 110,500 |
| 13×16 | 1,370 | 685 | 28 | 117,500 |
| 13×17 | 2,119 | 1,059 | 42 | 124,500 |
| 13×18 | 2,119 | 1,059 | 42 | 131,500 |
| 14×9 | 1,150 | 575 | 24 | 73,500 |
| 14×10 | 1,200 | 600 | 26 | 81,000 |
| 14×11 | 1,250 | 625 | 26 | 88,500 |
| 14×12 | 1,300 | 650 | 28 | 96,000 |
| 14×13 | 1,350 | 675 | 28 | 103,500 |

Source: `HousePlacementTool.cs:784–840` (partial; full list continues to 18×18)

## Design Mode

When customizing a foundation:

1. The house enters an **inactive** state — no lockdowns, vendors, or access while editing.
2. Three design states exist: **Current** (live), **Design** (your in-progress work), **Backup** (previous state).
3. Component categories you can place: Walls, Stairs, Floors, Roofs, Doors, Teleporters, Misc.
4. Customization tool cost is 0 gp in AOS mode (this server's mode).
5. Commit your design to make it live; revert to restore the backup.

## Related Pages

- [House Types](house-types.md) — pre-built classic houses
- [Placement](placement.md) — placement rules apply equally to foundations

---

**Source references:** `World/Source/Scripts/Items/Houses/HouseFoundation.cs`, `World/Source/Scripts/Items/Houses/HousePlacementTool.cs:725–840`, `World/Info/Scripts/Settings.cs:657`
