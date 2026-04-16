# Seafaring

Seafaring governs fishing, sailing, and maritime combat. It is the primary skill for all ocean-based activities in Ultima Memento.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Dexterity |
| Usage | Passive (fishing / sailing actions) |
| Cooldown | None |

## How It Works

### Fishing

Seafaring is the sole skill checked on every fishing attempt. Below 50 skill you may fish from land; at **50 or higher** you must be aboard a boat to fish in open water.

### Boat Speed

Higher Seafaring unlocks faster sailing speeds:

| Seafaring Skill | Speed Tier |
|---|---|
| 0–49 | Base speed |
| 50–74 | −25 ms per movement tick |
| 75–99 | −50 ms per movement tick |
| 100–124 | −75 ms per movement tick |
| 125 | −100 ms per movement tick |

### Sunken Ship Loot

Killing a sea creature or pirate adds `Seafaring / 25` bonus loot levels to any sunken ship treasures in the area.

### Harpoon Damage Bonus

The Harpoon weapon gains a damage bonus based on Seafaring:

```
Harpoon bonus = GetBonus(Seafaring, 0.20, 100.0, 10.0)
```

This stacks with the standard Marksmanship hit chance.

### Boat Access

- At **90+ Seafaring**, the boat door becomes visible to you from outside.
- At **Grandmaster (100+)**, you may dock your boat anywhere rather than at official docks only.

## How to Train

Seafaring gains passively on each fishing action and each sailing movement. Fish regularly and sail frequently to raise it.

## Related Skills

- [Marksmanship](marksmanship.md) — the Harpoon uses both Seafaring (damage) and Marksmanship (hit chance).
- [Tracking](tracking.md) — can detect hidden sea creatures that Seafaring alone cannot reveal.
