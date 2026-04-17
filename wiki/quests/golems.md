# Golem Quest

The Golem quest lets you construct a metal golem companion from gathered materials, then have a tinker assemble it.

## How to Start

Find a **Manual of Golems** as loot. The manual specifies the type of metal golem and what materials are needed.

## Golem Types

Golem type is determined randomly when the manual is generated:

| Metal | Level | Rarity |
|-------|-------|--------|
| Iron | 1 | Common |
| Dull Copper | 2 | Common |
| Shadow Iron | 3 | Uncommon |
| Copper | 4 | Uncommon |
| Bronze | 5 | Moderate |
| Golden | 6 | Moderate |
| Agapite | 7 | Rare |
| Verite | 8 | Rare |
| Valorite | 9 | Very Rare |

Higher-tier golems are stronger but require more materials.

## Required Materials

Drag and drop materials onto the manual to add them. Requirements scale with golem level:

| Material | Amount | Notes |
|----------|--------|-------|
| Metal Ingots | 1,000 | Must match golem type (e.g., valorite ingots for a Valorite Golem) |
| Clockwork Assemblies | 1-9 | Scales with level |
| Power Crystals | 1-9 | Scales with level |
| Arcane Gems | 1-9 | Scales with level |
| Gears | 5-45 | Scales with level |
| Technomancer Oil | 3-27 | Scales with level |
| Gold | 10,000-18,000 | Tinker's fee, scales with level |
| Springs | 5-45 | **Only needed for combat golems** |
| Dark Core of Exodus | Optional | Massive power boost, turns golem dark |

## Completing the Quest

1. Collect all required materials and add them to the manual.
2. The manual tells you which **specific tinker** (by town/village) can build your golem.
3. Give the completed manual to that tinker.
4. If you have **Tinkering skill**, the tinker refunds some gold (up to 50% at GM).

## Golem Variants

| Type | Follower Slots | Notes |
|------|----------------|-------|
| Worker (no springs) | 5 | Carries items, cannot fight, immune to damage |
| Fighter (with springs) | 5 | Fights alongside you |

> **Note:** The in-game Golem Manual gump text states the Fighter uses 3 follower slots, but the summoning code (`GolemPorterItem.cs:136`) unconditionally sets `ControlSlots = 5` for both golem types. The runtime value is 5.

## Charges

- Golems have limited **charges** (each summon uses one).
- Add **Power Crystals** to recharge: +5 charges for workers, +1 for fighters.
- Maximum 100 charges.
- Golems are controlled like tamed creatures (follow, stay, stop, dismiss).
- Golems are **not transferable** once built.
