# Decay and Refresh

> **Important:** On this server, house decay is **disabled by default** (`S_HousesDecay = false`). All houses are **Ageless** — they will never collapse on their own. The rest of this page describes how decay works if an administrator re-enables it via `S_HousesDecay = true`.

## Decay Types

| DecayType | Meaning |
|---|---|
| Ageless | House never decays. Assigned when `S_HousesDecay = false`, when `RestrictDecay` is set, or when the house has Ageless status. |
| AutoRefresh | House refreshes automatically (e.g., rented vendors active). |
| ManualRefresh | House decays unless refreshed by a friend visiting. |
| Condemned | House is condemned and will collapse; cannot be refreshed. |

## Decay Levels

When decay is active, a house progresses through levels based on the percentage of `S_HomeDecay` (default **365 days**) that has elapsed since the last refresh:

| Level | Elapsed % | Default Days Elapsed (at 365-day period) |
|---|---|---|
| LikeNew | 0.0% – 0.4% | 0 – 1.5 days |
| Slightly | 0.5% – 24.9% | 1.5 – 90 days |
| Somewhat | 25.0% – 49.9% | 91 – 182 days |
| Fairly | 50.0% – 74.9% | 183 – 273 days |
| Greatly | 75.0% – 94.9% | 274 – 346 days |
| IDOC | 95.0% – 99.9% | 347 – 364 days |
| DemolitionPending | 100%+ AND vendors/inventory present | — |
| Collapsed | 100%+ AND no vendors or inventory | House is deleted |

Source: `BaseHouse.cs:143–156`

## Refresh Triggers

- A **Friend** (or higher) opening a house door refreshes the decay timer.
- In ML mode, only the **Owner** viewing the house sign refreshes it; friend door-opens do not.
- There is no player `[refresh` command — interaction is the only natural refresh.

## DemolitionPending

If a house reaches 100% decay and there are active rented vendors or vendor inventories, it enters **DemolitionPending** instead of collapsing immediately. The house waits until those vendors are cleared before completing demolition.

## Decay Settings

| Setting | Default | Effect |
|---|---|---|
| `S_HousesDecay` | `false` | Master on/off switch for all house decay |
| `S_HomeDecay` | `365.0` | Decay period in days |

Both are in `World/Info/Scripts/Settings.cs` category 009.

## GM Commands

- `[RefreshHouse` — Staff can manually reset a house's decay timer. Target the house sign. Requires GameMaster access level.

See [Admin and Settings](admin-and-settings.md) for the full command reference.

## Related Pages

- [Admin and Settings](admin-and-settings.md) — `S_HousesDecay`, `S_HomeDecay`, `[RefreshHouse`
- [Vendors](vendors.md) — DemolitionPending and vendor cleanup
- [House Components](house-components.md) — house sign decay text display

---

**Source references:** `World/Source/Scripts/Items/Houses/BaseHouse.cs:25–196`, `World/Info/Scripts/Settings.cs:639–643`
