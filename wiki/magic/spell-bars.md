# Spell Bars

Spell Bars are customizable on-screen toolbars that give you quick access to cast spells without opening your spellbook. They support multiple magic schools and can be configured in horizontal or vertical layouts.

## Opening Spell Bars

Spell Bars are managed through player commands. There are multiple bar types for different magic schools:

| Bar Type | Open Command | Close Command | Setup Command |
|----------|-------------|---------------|---------------|
| Archmage Bar 1 | `[archtool1` | `[archclose1` | `[archspell1` |
| Archmage Bar 2 | `[archtool2` | `[archclose2` | `[archspell2` |

### All Spell Bar Systems

Every magic school has its own set of `*tool*` (open), `*close*` (close), and `*spell*` (setup) commands. The complete list (source: `SpellBarsManage.cs`):

| School | Open | Close | Setup |
|---|---|---|---|
| Ancient (Archmage) | `[archtool1`–`[archtool4` | `[archclose1`–`[archclose4` | `[archspell1`–`[archspell4` |
| Magery | `[magetool1`–`[magetool4` | `[mageclose1`–`[mageclose4` | `[magespell1`–`[magespell4` |
| Necromancy | `[necrotool1`–`[necrotool2` | `[necroclose1`–`[necroclose2` | `[necrospell1`–`[necrospell2` |
| Elementalism | `[elementtool1`–`[elementtool2` | `[elementclose1`–`[elementclose2` | `[elementspell1`–`[elementspell2` |
| Knight (Chivalry) | `[knighttool1`–`[knighttool2` | `[knightclose1`–`[knightclose2` | `[knightspell1`–`[knightspell2` |
| Bard | `[bardtool1`–`[bardtool2` | `[bardclose1`–`[bardclose2` | `[bardspell1`–`[bardspell2` |
| Death Knight | `[deathtool1`–`[deathtool2` | `[deathclose1`–`[deathclose2` | `[deathspell1`–`[deathspell2` |
| Holy Man | `[holytool1`–`[holytool2` | `[holyclose1`–`[holyclose2` | `[holyspell1`–`[holyspell2` |
| Monk (Mystic) | `[monktool1`–`[monktool2` | `[monkclose1`–`[monkclose2` | `[monkspell1`–`[monkspell2` |

Use the `*spell*` command to configure which spells appear on the bar, then the `*tool*` command to open it, and `*close*` to dismiss it.

## Configuring a Spell Bar

1. **Open the setup gump** by using the appropriate command or context menu option on your spellbook.
2. **Select spells** to include by checking the checkbox next to each spell icon.
3. **Choose layout:** Horizontal or Vertical bar.
4. **Show Spell Names:** When using vertical layout, you can toggle spell name labels on/off.
5. **Open Toolbar:** Click to open the configured toolbar on screen.
6. **Close Toolbar:** Click to close it.

## Layout Options

- **Horizontal Bar:** Shows spell icons in a single horizontal row. Compact and efficient.
- **Vertical Bar:** Shows spell icons stacked vertically. Can optionally display spell names next to each icon.

## Using Spell Bars

- Click any spell icon on the toolbar to cast that spell.
- Spell bars remain on screen and can be dragged to your preferred position.
- You can have multiple spell bars open simultaneously (e.g., one for Magery, one for Necromancy).

## Casting via Commands

Every spell can also be cast directly via a chat command, without using spell bars or books. See each magic school's page for the specific `[CommandName` syntax. For example:
- `[EBolt` casts Elemental Bolt
- `[ForceGrip` casts the Jedi Force Grip ability  
- `[DKHellfire` casts the Death Knight Hellfire spell

## Ancient Book Toggle

For [Research](research.md) magic specifically, use `[ancient` to toggle between casting from the Research Bag or the Ancient Spellbook.

## Tips

- Arrange your most-used spells on spell bars for faster combat.
- Use vertical bars with names enabled while learning a new magic school.
- Switch to horizontal bars once you recognize spell icons to save screen space.
- You can close spell bars with the close command and reopen them without losing your configuration.
