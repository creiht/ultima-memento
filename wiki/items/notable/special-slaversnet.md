# Slaver's Net (Throwing Net)

The Slaver's Net (displayed in-game as "throwing net") is a special single-use tool that allows you to instantly capture a tamable creature and bond it as a follower — no taming skill required.

## Properties

| Property | Value |
|----------|-------|
| In-game name | throwing net |
| Weight | 10.0 stones |
| Uses | 1 (consumed on any outcome except "net fails to capture") |
| Range | 6 tiles |

## How It Works

1. The net must be **in your backpack** to use.
2. Double-click the net, then target a creature within 6 tiles.
3. The net checks the following conditions in order:

| Condition | Result |
|-----------|--------|
| Target is a Paragon (cursed) creature | Fails — cannot capture |
| Target is not tamable | Fails — cannot capture |
| Target is already controlled | Fails — cannot capture |
| Your follower slots + (creature's ControlSlots + 2) would exceed your max | Fails — not enough slots |
| `creature.MinTameSkill < Random(50–200)` | 50% chance: net torn to shreds (consumed). 50% chance: net fails to capture (NOT consumed). |
| All checks pass | Success: creature captured and bonded to you |

4. On **success**: the creature is immediately set as your controlled, bonded follower with `OrderType.Follow`. Its `MinTameSkill` is set to 29.1 (accessible to all) and its slot cost is increased by 2.
5. On **torn to shreds** failure: net is deleted.
6. On **failed capture**: net is NOT consumed — you can try again.

## Key Notes

- The net effectively gives a **`MinTameSkill / 200` chance of success** for any creature. Weaker creatures (lower MinTameSkill) are much easier to capture.
- Capturing a creature costs **creature's normal ControlSlots + 2** follower slots (the extra 2 represent the cost of not taming properly).
- The captured pet is bonded immediately — no bonding period needed.
- Any tamable creature can be targeted, including powerful ones, as long as the slot math works out.

## How to Obtain

Found as rare loot in special encounters. The item property tooltip reads "Used to capture tamable creatures."

## Cross-links

- [Taming](../../skills/) — normal taming mechanics and follower slots
- [Special Items](../special.md) — other special items
