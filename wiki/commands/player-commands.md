# Player Commands

All commands below are available to every player. Type `[commandname` in-game to use them.

## Command Reference

| Command | Syntax | Description | Notes |
|---------|--------|-------------|-------|
| `afk` | `[afk <message>` | Toggles AFK mode. Your character says "zZz" and emotes the message periodically. | Deactivates on movement, speech, death, or logout. |
| `autoattack` | `[autoattack` | Toggles automatic counter-attacking when you are attacked. | Toggle on/off. |
| `bandself` | `[bandself` | Automatically applies a bandage from your backpack to yourself. | Warns when bandage count is 5 or below. |
| `bandother` | `[bandother` | Applies a bandage to a targeted mobile. | Opens a targeting cursor. |
| `barbaric` | `[barbaric` | Toggles the barbaric play style. | Cycles through: off → barbaric → amazon fighter (female only). Disables oriental/evil styles. Gives a barbaric satchel. |
| `combatbar` | `[combatbar` | Opens the Combat Bar gump showing combat stats. | Draggable, auto-refreshes. |
| `corpse` | `[corpse` | Directs you toward your nearest corpse within 1000 tiles. | Shows distance and direction. |
| `corpseclear` | `[corpseclear` | Clears corpse tracking. | |
| `e` | `[e <emote>` | Short alias for emote commands. | Same emotes as `[emote`. |
| `emote` | `[emote <action>` | Performs an emote with sound, words, and animation. | Actions: ah, ahha, applaud, blownose, bow, burp, clap, cough, cry, fart, groan, hail, kiss, laugh, no, oh, oooh, puke, punch, salute, shush, sigh, slap, sneeze, sorry, spit, whistle, yawn, yell, yes, and many more. |
| `evil` | `[evil` | Toggles the evil play style. | Disables oriental/barbaric styles. |
| `loot` | `[loot` | Opens the automatic looting configuration gump. | Configure which item types to auto-loot from corpses. Also registers `[AutoLoot` target command. |
| `magicgate` | `[magicgate` | Directs you to the nearest magical moongate within 1000 tiles. | Shows distance and direction. |
| `music` | `[music` | Opens the music playlist and player gump. | Browse and play from 70+ music tracks. |
| `musical` | `[musical` | Toggles dungeon music style between normal and casual (forest). | Toggle on/off. |
| `oriental` | `[oriental` | Toggles the oriental play style. | Disables evil/barbaric styles. |
| `poisons` | `[poisons` | Toggles between classic poisoning and precision (infectious strikes). | Classic: poison on any hit with one-handed slashing/piercing. Precision: uses special weapon ability. |
| `private` | `[private` | Toggles privacy for the town crier announcements. | Public or private news. |
| `quickbar` | `[quickbar` | Opens the Quick Bar gump for fast access to common actions. | Draggable, customizable. |
| `regbar` | `[regbar` | Opens the Reagent Bar showing your reagent counts. | |
| `regclose` | `[regclose` | Closes the Reagent Bar. | |
| `ReleaseSummons` | `[ReleaseSummons` | Releases all summoned creatures you control. | Immediate release, no confirmation. |
| `Rename` | `[Rename <name>` | Renames a targeted container. | Max 64 characters. Must own the container. |
| `sheathe` | `[sheathe` | Toggles automatic weapon sheathing when leaving war mode. | Weapon is stored in backpack when leaving war mode; re-equipped when entering war mode. |
| `skill` | `[skill` | Opens the Skill Descriptions gump with info on all skills. | Reference guide for all 55+ skills. |
| `skilllist` | `[skilllist` | Opens the skill watch list gump. | Track specific skills and their progress. |
| `SkillName` | `[SkillName <skillname>` | Sets your character's displayed skill title. | Use `[SkillName clear` to reset to auto-title. Valid skills: alchemy, anatomy, magery, etc. |
| `spellhue` | `[spellhue <hue>` | Changes the default color for magery spell effects. | Pass a hue number (integer). |
| `SuppressTooltips` | `[SuppressTooltips` | Toggles vendor tooltip display. | Useful for performance on clients that lag with tooltips. |
| `VendorGold` | `[VendorGold` | Toggles the vendor gold safeguard during sales. | Only available when merchants are not rich and don't use remaining gold. When disabled, vendors won't stop sales they can't afford. |
| `wealth` | `[wealth` | Opens the Wealth Tracking Bar gump. | Shows gold and financial information. |

## Sorting Commands (Container Organization)

These commands target a container and sort its contents:

| Command | Syntax | Description |
|---------|--------|-------------|
| `Organize` | `[Organize` | Opens item organization targeting. Sorts items into labeled bags by category (Crafting, Equipment, Scrolls, Potions, etc.). |
| `OrderBy-Graphic` | `[OrderBy-Graphic` | Sorts items by their graphic ID (ascending). |
| `OrderBy-Hue` | `[OrderBy-Hue` | Sorts items by their color hue (ascending). |
| `OrderBy-Name` | `[OrderBy-Name` | Sorts items by name (ascending). |
| `OrderBy-Size` | `[OrderBy-Size` | Sorts items by size (ascending). |
| `OrderBy-Slayer` | `[OrderBy-Slayer` | Sorts weapons by their slayer property (ascending). |
| `OrderBy-Weight` | `[OrderBy-Weight` | Sorts items by weight (descending). |

## Utility Commands

These are not typed as commands but are gumps opened from the Help system or other interfaces:

| Feature | Description |
|---------|-------------|
| Quests & Discoveries | Shows current quest progress (accessed via Help menu) |
| Fame & Karma | Shows the fame/karma title grid (accessed via Help menu) |
| Creature Help | Shows creature race information (accessed via Help menu) |
| Item Properties | Shows detailed item property descriptions (accessed via Help menu) |
| Basics | Shows basic game help information (accessed via Help menu) |
| Library | Shows discovered lore and knowledge (accessed via Help menu) |
| Skill Title Chooser | Choose which skill determines your character's title (accessed via Help menu) |
| Wanted Status | Shows your criminal/wanted status (accessed via Help menu) |
