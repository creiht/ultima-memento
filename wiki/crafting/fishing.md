# Fishing

Fishing (Seafaring) catches fish and other items from water, and is also the means to reach shipwrecks, underwater ruins, and crashed alien vessels.

- **Skill**: Seafaring
- **Tool**: Fishing Pole
- **Range**: Must be within 4 tiles of water

## How It Works

- Use a fishing pole and target a water tile
- Resource banks are 8×8 tiles, holding 5–15 fish
- Banks respawn every 10–20 minutes
- Fishing from land caps skill gains at 50.0 — you must fish from a boat to advance beyond that

## Skill Advancement

- **Land fishing**: Skill gains up to 50.0
- **Boat fishing**: Required for skill gains above 50.0

## Standard Yields

| Catch | Requirement | Notes |
|---|---|---|
| Raw Fish | Any skill | Standard catch |
| Oyster | 80+ skill | 0.6% chance; may contain a pearl |
| Prized / Wondrous / Truly Rare / Peculiar Fish | Any (deep water) | Skill-weighted chance |
| Wet Clothes / Rusty Junk / Special Seaweed | Any | Skill-weighted chance |
| Fishing Net / Special Net / Fabled Net / Neptune's Net | 50+ skill | Skill-weighted; must be on boat |
| Corpse Sailor / Sunken Bag | 50+ skill | Skill-weighted; must be on boat |
| Exotic New Fish | 50+ skill | Skill-weighted |
| Treasure Map | 90+ skill (deep water) | Skill-weighted |
| Message in a Bottle | 90+ skill (deep water) | Used to locate SOS chests |

Deep-water catches require being on a boat and not too close to a town.

Source: `Fishing.cs:85–173`.

## Shipwreck & Ruin Locations

When fishing near a major shipwreck and your Seafaring skill beats a random 1–250 roll, you fish up items from the wreck instead of a standard catch. Fishing the Waters of Ktulu counts as always near a wreck.

### Huge Shipwrecks (within 36 tiles)

| Map | Coordinates | Notes |
|---|---|---|
| Underworld | 578, 1370 | — |
| Underworld | Waters of Ktulu region | Always active |
| Savaged Empire | 946, 821 | — |
| Savaged Empire | 969, 217 | — |
| Savaged Empire | 322, 661 | — |
| Isles of Dread | 760, 587 | — |
| Isles of Dread | 200, 1056 | — |
| Isles of Dread | 1232, 387 | — |
| Isles of Dread | 528, 233 | — |
| Serpent Island | 504, 1931 | — |
| Serpent Island | 1472, 1776 | — |
| Serpent Island | 1560, 579 | — |
| Serpent Island | 1328, 144 | — |
| Lodoria | 2312, 2299 | — |
| Lodoria | 2497, 3217 | — |
| Lodoria | 576, 3523 | — |
| Lodoria | 4352, 3768 | — |
| Lodoria | 4824, 1627 | — |
| Lodoria | 3208, 216 | — |
| Lodoria | 1112, 619 | — |
| Lodoria | 521, 2153 | — |
| Lodoria | 2920, 1643 | — |
| Sosaria | 320, 2288 | — |
| Sosaria | 3343, 1842 | — |
| Sosaria | 3214, 938 | — |
| Sosaria | 4520, 1128 | — |
| Sosaria | 4760, 2307 | — |
| Sosaria | 3551, 2952 | — |
| Sosaria | 1271, 2651 | — |
| Sosaria | 744, 1304 | — |
| Sosaria | 735, 555 | — |
| Sosaria | 1824, 440 | — |
| Sosaria | 883, 3749 | — |
| Sosaria | 2078, 3987 | — |
| Sosaria | 6973, 1016 | Kuldar area |
| Sosaria | 6388, 2512 | Kuldar area |

Wrecks yield: body parts, sea relics, unique hats and boots, weapons, armor, jewelry, instruments, books, scrolls, orbs, and relic items (via Loot.RandomRelic).

### Crashed Alien Vessels (Sci-Fi Salvage)

Fishing near a space crash site yields sci-fi items (via `Loot.RandomSciFiItems()`). Two crash sites exist on Sosaria:

| Map | X Range | Y Range |
|---|---|---|
| Sosaria | 457–494 | 1785–1821 |
| Sosaria | 4430–4501 | 589–661 |

### Underwater Ruins

Fishing over underwater ruins yields relics via `Loot.RandomRelic`. Five ruin zones exist:

| Map | X Range | Y Range |
|---|---|---|
| Sosaria | 4342–4420 | 2766–2845 |
| Sosaria | 175–243 | 2316–2344 |
| Sosaria | 3664–3737 | 2522–2594 |
| Lodoria | 1668–1734 | 1309–1376 |
| Lodoria | 1573–1634 | 3261–3326 |

Source: `Fishing.cs:213–319`.

## Ship Cargo

While crewing or looting ship cargo holds during seafaring encounters, ore crates containing premium metals may be found: Dwarven, Xormite, Mithril, Obsidian, and Nepturite ore crates. See [Mining](mining.md) for properties of these metals.

Source: `Items/Boats/Cargo.cs:497–501`.

## SOS Chests

A **Message in a Bottle** (MiB) obtained from fishing encodes the coordinates of a sunken treasure chest. Sail near the encoded coordinates and use the MiB to spawn a sea creature guardian and a sunken chest with varied loot.

## Tips

- Craft a fishing pole via Carpentry (68.4 skill, 5 boards + 5 fabric)
- Cook raw fish steaks at a fire for food
- Fish steaks are also used as a cooking ingredient (sushi, miso soup)
- Join the Fishermen's Guild for stat bonuses to shipwreck fishing
