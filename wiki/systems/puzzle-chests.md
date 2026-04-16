# Puzzle Chests

Puzzle chests are locked containers found on pedestals throughout the world. To claim the treasure inside, you must solve a color-coded cylinder puzzle — similar to the classic Mastermind game.

## How It Works

1. Approach a pedestal with a puzzle chest and double-click it to open the puzzle gump.
2. The puzzle consists of **5 cylinder slots**, each of which must be set to the correct color.
3. There are **8 possible colors**: Light Blue, Blue, Dark Blue, Green, Orange, Purple, Red, and Yellow.
4. You are given **3 hints** — these are correct colors from the solution (but not their positions).
5. Submit your guess. The game tells you:
   - How many cylinders are the **correct color in the correct position**
   - How many are the **correct color but in the wrong position**
6. Adjust your guess and try again.

## Solving the Puzzle

- Use the 3 hints to narrow down which colors are in the solution.
- After each guess, use the feedback (correct position vs. correct color) to deduce the arrangement.
- A wrong guess triggers a **trap** — if your Remove Trap skill check (0–125) fails, you take damage.
- There is a **1-hour cooldown** between guess attempts per player.

## Rewards

Successfully solving the puzzle releases the chest, and you take it and its contents. The treasure inside varies based on the chest's level and location — see [Chest Containers](loot-tables/chest-containers.md) for full details on how levels map to treasure tiers.

## Requirements

- **Puzzle Master temptation**: You must have the "Puzzle Master" temptation active to interact with puzzle chests (see [Temptations](temptations.md)).
- **Remove Trap skill**: Higher Remove Trap skill helps avoid trap damage on wrong guesses.

## Tips

- Write down your guesses and the feedback to work through the logic systematically.
- The hints give you 3 of the 5 solution colors (but from positions 2–5 only, not the first position) — start by placing these and testing positions.
- If you're struggling, focus on placing one color at a time and using process of elimination.
- Be prepared for trap damage — bring healing supplies.
