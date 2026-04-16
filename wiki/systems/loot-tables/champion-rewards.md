# Champion Rewards

Champion bosses deliver several simultaneous reward streams. Rewards scale with the spawn's **size** (number of participants who dealt damage) and **difficulty** setting.

**Source:** `World/Source/Scripts/Engines and Systems/Champs/Mobiles/Bosses/BaseChampion.cs`, `ChampionRewards.cs`

[Back to Loot Tables](README.md) | [Champion Spawns system page](../champion-spawns.md)

---

## Reward Scaling Formulas

From `ChampionRewards.cs`:

| Reward | Formula | Cap |
|--------|---------|-----|
| Gold scatter chance | `25 + 10×difficulty + 5×size` % | 100% |
| Artifact drop chance | `10×difficulty + 5×size` % | 100% |
| Power scroll count | `1 + difficulty + size÷3` | — |
| Treasure chest chance | `20×difficulty + 10×size` % | 100% |
| Boss item drop | Always **100%** | — |

`difficulty` is the spawn's `Difficulty` enum value (0–6); `size` is the number of participants.

---

## Gold Scatter (`GoodiesTimer`)

On boss death, gold coins rain down in a 12-tile radius over ~10 seconds. Each tile within radius 12 has a gold drop of `300–800 × GoldPercent/100` (after the server gold cut rate). `GoldPercent` defaults to 100 and scales with `GetGoldPercent()`.

---

## Hoard Minion Familiar

Every champion boss drops a `HoardMinionFamiliarItem` — a 100% guaranteed drop placed into the corpse.

---

## Treasure Chest

If `TreasureChestRewardChance > 0` and the roll succeeds, a `LootChest(10)` is placed in the corpse (level 10, decorated as a demon box). This yields [TMegaRich](treasure-packs.md#tmegarich)-tier loot.

---

## Boss Item

`BossItemRewardChance` defaults to 100 (always). The boss item is a random magical item (`Loot.RandomMagicalItem`) enchanted at level 500 — the maximum enchantment tier. It is labeled with `[Belonged to: BossName]` in its tooltip.

---

## Artifacts (DecorativeList)

Each boss has a 30% chance (`GetArtifact()`) to drop one random item from its personal `DecorativeList`. These are thematically flavored items unique to that boss:

| Boss | DecorativeList items |
|------|-------------------|
| Barracoon | SwampTile, MonsterStatuette (Slime type) |
| Mephitis | See `Mephitis.cs` |
| Rikktor | See `Rikktor.cs` |
| Lord Oaks | See `LordOaks.cs` |
| Neira | See `Neira.cs` |
| Semidar | See `Semidar.cs` |
| Silvani | See `Silvani.cs` |

If `ArtifactRewardChance > 0`, the boss also has a `X%` chance to drop a [full artifact](artifact-pools.md#artifacts) from `Loot.RandomArty()`.

---

## Power Scrolls

`GetPowerscrollDropCount(size, difficulty)` scrolls are distributed randomly among all eligible participants (anyone who dealt damage). Scroll levels:

| Level | Probability |
|-------|-------------|
| 5 | 35% |
| 10 | 30% |
| 15 | 20% |
| 20 | 10% |
| 25 | 5% |

Power scrolls cannot be crafted — they permanently raise a skill's cap.

---

## Regular Body Loot

Champion bosses also have a standard `GenerateLoot()` override (e.g., Barracoon calls `AddLoot(LootPack.UltraRich, 3)` — three independent UltraRich generations). See [Monster Packs — UltraRich](monster-packs.md#ultrarich).
