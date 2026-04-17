# Frankenstein Quest

The Frankenstein quest lets you build a reanimated flesh golem companion by collecting body parts from giant creatures.

## How to Start

Find **Frankenstein's Journal** in the world. It is bound to you upon pickup.

## Requirements

- You must be at least a **neophyte undertaker** (some Forensics skill).
- Carry the journal and use a **bladed item** to skin giant corpses (ogres, ettins, cyclops, etc.).

## Collecting Body Parts

You need **7 components**, each obtained by skinning giant creatures:

| Part | Notes |
|------|-------|
| Head | From giant corpses |
| Torso | From giant corpses |
| Left Arm | From giant corpses |
| Right Arm | From giant corpses |
| Left Leg | From giant corpses |
| Right Leg | From giant corpses |
| Brain | From giants -- more powerful giants give better brains (brain level affects golem power) |

- Double-click a severed body part and target the journal to add it.
- You can only have **one of each** body part (except brain, which can be swapped).
- Unwanted body parts can be sold to the undertaker at the Black Magic Guild.

## Completing the Quest

1. Collect all 7 parts and add them to the journal.
2. Find a **Power Coil** (the undertaker has one; you can also buy one for your home via tinkering).
3. Stand near the Power Coil and open the journal.
4. Choose to reanimate a **Slave** (worker/porter) or a **Protector** (fighter).

## Golem Types

| Type | Description | Follower Slots |
|------|-------------|----------------|
| Slave (Porter) | Carries items, cannot fight, immune to damage | 5 |
| Protector (Fighter) | Fights alongside you | 5 |

> **Note:** The in-game Frankenstein Journal gump text states the Protector uses 3 follower slots, but the summoning code (`FrankenPorterItem.cs:126`) unconditionally sets `ControlSlots = 5` for all Frankenstein creations. The runtime value is 5.

## Tips

- A storm giant brain gives more power than an ogre brain -- hunt the strongest giants for the best results.
- Embalming fluid may be needed for some parts of the process.
- The journal tracks all progress visually -- double-click it at any time to check.
