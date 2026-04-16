# Quest System Overview

This page describes how the quest engine works from a player's perspective. Ultima Memento has two parallel quest systems: a **modern ML-style quest system** (used by NPC quest givers) and a **classic quest system** (used by bulletin boards, special items, and exploration).

## Checking Your Quests

- Type **`[quests`** in the chat to open the Quest Log gump.
- The Quest Log lists all active quests with their titles.
- Click the arrow next to a quest to see detailed objectives and progress.
- For collection/crafting quests, a crosshair button lets you toggle quest items.

## ML Quest System (NPC Quests)

### Accepting Quests

1. **Double-click an NPC** who offers quests. The NPC will turn to face you.
2. A **Quest Offer** gump appears with the quest title, description, objectives, and rewards.
3. Click **Accept** to take the quest, or **Refuse** to decline.
4. You hear a confirmation sound and see "You have accepted the Quest."

### Quest Limits

- You can have up to **10 active quests** at once.
- Some quests are **one-time only** -- once completed, the NPC will not offer them again.
- Some quests have a **cooldown timer** -- after completing them, you must wait before the same quest is available again. The NPC will tell you approximately how long to wait.

### Quest Objectives

Quests can have several types of objectives:

| Objective Type | Description |
|----------------|-------------|
| **Kill** | Slay a specific number of creatures. Progress is tracked automatically. |
| **Collect** | Gather items and mark them as Quest Items in your backpack. |
| **Deliver** | Carry an item to a destination NPC. The delivery item is placed in your backpack. |
| **Craft** | Craft specific items and mark them as Quest Items. |
| **Gain Skill** | Increase a specific skill. |

- For **Kill** objectives, you receive messages as you progress: "You have killed a quest creature. X more left."
- For **Collect** objectives, items must be in your backpack and toggled as Quest Items (use the crosshair button in the Quest Log, or click yourself to toggle).
- Some quests require **all** objectives to be completed; others require only **one**.

### Quest Items

- Certain items can be marked as **Quest Items** for collection objectives.
- Quest Items must remain in the **top level of your backpack**.
- When a quest is completed or cancelled, collected quest items are consumed or unmarked.

### Completing Quests

1. When all objectives are met, you hear a completion sound and see a notice.
2. **Return to the quest giver NPC** and double-click them.
3. A **Report Back** gump appears confirming completion.
4. A **Reward** gump shows what you will receive.
5. Click to claim your reward. Items are placed in your backpack.
6. If your backpack is full, you cannot claim the reward until you make space.

### Quest Chains

Some quests are part of a **chain**. Completing one quest in the chain unlocks the next quest from the same NPC. If you quit a chain quest, you lose progress in that chain.

### Timed Quests

Some objectives have a time limit. If you fail to complete the objective before time runs out, the objective expires and the quest may fail. A timer is displayed in the quest details.

### Cancelling Quests

- Open the Quest Log, select a quest, and choose to cancel it.
- Cancelled quests may have a cooldown before the NPC offers them again.

## Classic Quest System (Bulletin Boards & Items)

Many quests in Ultima Memento use a separate, item-driven system:

- **Bulletin Boards** in taverns and docks offer bounty/hunting quests.
- **Special items** found in dungeons (journals, cubes, schematics, etc.) start exploration quests.
- Progress is tracked through the item itself (double-click it to check status).
- Rewards are typically gold paid by the quest giver NPC or board, plus fame/karma.
- There is usually a **cooldown** between quests of the same type.

## Rewards

Quest rewards vary by type:

| Reward Type | Examples |
|-------------|---------|
| **Gold** | Paid directly into your backpack |
| **Items** | Weapons, armor, artifacts, unique quest rewards |
| **Fame & Karma** | Earned or lost depending on quest and alignment |
| **Skill Bonuses** | Some quest reward items grant skill bonuses |
| **Companions** | Henchmen, golems, flesh golems, robots |
| **Stat Bonuses** | The Codex grants +25 Intelligence and +100 in two skills |

## Tips

- Always bring a **sextant** on courier/epic quests -- you can view a map gump showing quest locations.
- Talk to **citizens** (NPCs with orange names) for rumors about Major quest items.
- Keep quest journals/items in your backpack at all times -- many quest triggers check your pack.
- Higher **Luck** improves rewards from treasure hoards and thief pedestals.
- **Mercantile** skill and **Merchant Guild** membership increase gold from antique sales.
