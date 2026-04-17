# Notoriety

The notoriety system determines how other players and NPCs perceive your character. Your notoriety affects who you can attack, who can attack you, how town guards treat you, and your resurrection options.

## Notoriety Levels

Each mobile (player or creature) has a notoriety that is displayed via their name color:

| Notoriety | Name Color | Description |
|---|---|---|
| **Innocent** | Blue | Law-abiding citizens; attacking them flags you as criminal |
| **Ally** | Green | Members of your guild or allied guilds |
| **Can Be Attacked** | Grey | Aggressors, house trespassers, or flagged targets — attacking them carries no penalty |
| **Criminal** | Grey | Temporarily flagged for committing a crime (theft, assault on innocents, etc.) |
| **Enemy** | Orange | Members of an enemy guild |
| **Murderer** | Red | Characters with 1 or more murder counts |
| **Invulnerable** | Yellow | Blessed NPCs, vendors, and barkeepers — cannot be harmed |

## How Notoriety Works

### Innocent (Blue)

All player characters start as Innocent. You remain Innocent as long as you:
- Do not attack other Innocent players
- Do not steal from other players
- Have zero murder counts

NPCs such as townsfolk (BasePerson, BaseNPC) and racial vendors are always considered Innocent.

### Criminal (Grey)

You become Criminal temporarily when you:
- Attack or steal from an Innocent player
- Perform a hostile action against an Innocent player or their pet
- Are caught stealing

Criminal status is temporary and fades after a period of time. While Criminal, town guards may pursue you.

### Murderer (Red)

A character becomes a Murderer when their **kill count** (`Kills`) reaches 1 or more. Killing an Innocent player adds to your murder count.

Murderer status has serious consequences:
- Town guards will attack you on sight
- Most healers and shrines will refuse to resurrect you (you must seek evil-aligned altars, such as those in Xardok's Castle or crypts)
- Other players can attack you freely with no penalty

### Reducing Murder Counts

Murder counts can be reduced through **bribery**:
- Visit an **Assassin Guildmaster** and pay **50,000 gold** per murder count to have it removed
- Assassin guild members pay half price (25,000 gold)
- Bribery never applies to characters with Fugitive status

## Fame and Karma

In addition to notoriety, characters have **Fame** and **Karma** values that represent their reputation.

### Fame

Fame ranges from **0 to 15,000** and represents how well-known your character is.

- Gained by defeating strong enemies, completing quests, and performing notable deeds
- Lost on death (10% if resurrection penalty applies)
- Fame is always positive — it measures notoriety of any kind

### Karma

Karma ranges from **-15,000 to +15,000** and represents your moral alignment.

- **Positive karma** — gained by killing evil creatures, helping others, and performing good deeds
- **Negative karma** — gained by killing innocent creatures, stealing, and committing crimes
- Lost on death (10% if resurrection penalty applies, only if currently positive)

Characters with negative karma may find that some healers and shrine services are restricted.

**Karma Lock:** If your karma drops below zero, it becomes locked. You must speak a mantra at a shrine to unlock it again. Characters who intentionally lock karma (evil path) receive doubled negative karma gains and halved positive karma offsets.

## Player-vs-Player Rules

Ultima Memento has strict PvP rules:

- **Two different players** (not in the same guild or allied guilds) **cannot harm each other** — harmful actions between unrelated players are denied
- **Guild warfare** — members of warring (enemy) guilds appear orange to each other, but per `Mobile_AllowHarmful` they still cannot actually deal damage. Only members of the **same guild** or **allied guilds** can freely harm each other
- **Same player** — a player can harm themselves; whether pets can harm their owner is controlled by server settings (currently disabled)
- **Pets** — pets from the same owner can harm each other

This means open-world PvP between strangers is not possible — only structured guild warfare allows player-vs-player combat.

## Guard Behavior

Town guards respond to criminal and murderer activity:

- Guards **chase** criminals and murderers in town (they do not instantly kill)
- Criminals/murderers caught by guards are **sent to prison**
- Guards can **sprint** to catch fleeing criminals
- When jailed, **only gold** is deleted from your inventory (server setting `S_JailOnlyDeletesMoney = true`). Other items — potions, bandages, arrows, equipment — are preserved

## Effects on Gameplay

| Status | Town Access | Healer Access | Can Be Attacked Freely | Guard Response |
|---|---|---|---|---|
| Innocent | Full | Full | No | None |
| Criminal | Limited | Limited | Yes | Chased/Jailed |
| Murderer | Dangerous | Evil altars only | Yes | Chased/Jailed |
| Fugitive | Dangerous | Evil altars only, 2× cost | Yes | Chased/Jailed |

## Pets and Notoriety

When the server setting `PetsMatchMasterNotoriety` is enabled (which it is by default), controlled pets inherit their master's notoriety. This means a murderer's pet will also appear red.

## See Also

- [Death & Resurrection](death-and-resurrection.md) — how notoriety affects your resurrection options
- [Attributes](attributes.md) — Fame and Karma interact with character level
- [Getting Started](README.md) — back to the new player guide
