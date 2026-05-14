# Stealing

Stealing lets you pilfer items from containers, coffers, dungeon chests, and the backpacks of other creatures and players.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Dexterity |
| Usage | Active (targeted) |
| Range | 1 tile |
| Max Item Weight | 10 stones |

## How It Works

Use the skill and target an item, container, or creature. You must be **empty-handed** (no weapon wielded, though pugilist gloves are allowed).

### Stealing from Creatures/Players

Target a creature to attempt to steal a random item from their backpack. Target a specific item to steal that item directly. Items that are equipped, blessed, or newbied cannot be stolen. Containers cannot be stolen.

The difficulty is based on **item weight**:

```
Difficulty = (Item Weight * 10) +/- ~25
```

For stackable items, you steal a portion based on skill: `Max Amount = (Skill / 10) / Item Weight`.

### Stolen Item Timer

Stolen items are tracked for **2 minutes**. If you die while carrying a stolen item, it is returned to the victim.

### Stealing from Coffers

Target a coffer to steal gold from it. Success gives you all the gold in the coffer. Failure may reveal you, and nearby vendors may shout "Stop! Thief!" (with a [Snooping](snooping.md) check to avoid being spotted).

### Stealing Dungeon Chests

Target a dungeon chest to steal the entire container. On success, you receive a copy of the chest with its contents value. The original chest is replaced with a new spawn. On failure, the chest may be destroyed.

### Stealable Artifacts

Certain rare artifacts in the world can be stolen. Requires **100 Stealing skill** and membership in the **Thieves' Guild**. Each artifact can only be stolen once per character.

### Getting Caught

```
Caught Chance = Skill < Random(150)
```

At 100 skill you have roughly a 33% chance of being noticed. If caught stealing from a player, witnesses within 8 tiles are notified, your disguise is removed, and you may be flagged criminal. You are only **revealed from hiding on failure or when caught**, not on every attempt.

### Restrictions

- Must be empty-handed (no weapons).
- Must be within 1 tile of the target.
- Need Thieves' Guild membership to steal from innocent players.
- Cannot steal from shopkeepers or player vendors.
- Cannot steal while in a blessed state.
- Causes karma loss (-60 for item theft, variable for coffers).

## How to Train

Steal from dungeon chests and coffers. The difficulty scales with item weight, so lighter items are easier. Stealing from coffers uses a 0-100 check.

## What It Affects

### Core Mechanics
- `Stealing.cs:113` — **Dungeon chest theft**: `CheckSkill(Stealing, 0, 125)` to steal the container. On success, you receive a copy of the chest with contents valued at `(containerLevel + 1) * 50 * goldCutRate`. Original chest is replaced by a new spawner.
- `Stealing.cs:221` — **Coffer pilfering**: `CheckSkill(Stealing, 0, 100)` to steal all gold from a merchant coffer. On success, gold is taken, karma is awarded negatively, and the coffer is marked as robbed with the thief's name and skill title recorded.
- `Stealing.cs:343, 351, 365` — **Item theft**: `CheckTargetSkill(Stealing, target, weight*10 - 22.5, weight*10 + 27.5)` for single items and stacks. Stackable items use max amount = `(skill / 10) / itemWeight`.
- `Stealing.cs:387` — **Caught chance**: `skill.Value < Random(150)`. At 100 skill, ~33% chance of being noticed. On caught, you are criminalized (if stealing from innocent non-guild players), disguise is removed, and witnesses within 8 tiles receive a message.
- `Stealing.cs:287` — **100 skill requirement**: Stealing artifacts from pedestals requires **100+ Stealing**. Each artifact can only be stolen once per character unless `S_DecoArtySteal` setting is enabled.
- `Stealing.cs:373` — Successful item theft awards **-60 Karma**.
- `Stealing.cs:528` — Stolen items are tracked for **2 minutes** (`StolenItem.StealTime`). If you die while carrying stolen goods, they are returned to the victim.
- `Stealing.cs:54-57` — **Stealable artifacts**: 24 unique artifacts tracked (Rock, SkullCandle, Bottle, DamagedBooks, StretchedHide, Brazier, LampPost, BooksNorth, BooksWest, BooksFaceDown, StuddedLeggings, EggCase, SkinnedGoat, GruesomeStandard, BloodyWater, TarotCards, Backpack, StuddedTunic, Cocoon, SkinnedDeer, Saddle, LeatherTunic, RuinedPainting).

### Combat & Creatures
- `BaseCreature.cs:6532-6579` — **Coin steal on attack**: When melee attacking a creature, if you are within 1 tile and `Stealing >= 20` and your creature level < your Stealing AND `Snooping > Random(20, 126)`, you steal a portion of their coins. Amount = `coins * (1 - creatureLevel / yourStealing)`. Uses `CheckSkill(Stealing, 0, 125)` on success. Loot types include Gold, DDXormite, Crystals, and DDJewels.
- `Behavior.cs:3704` — **NPC stealing from players**: When you hide within 2 tiles of a creature, if their Stealing >= random 1-125 AND their Snooping >= random 1-100, there's a 1-in-5 chance they steal an item from your backpack (blessed and multi-item containers excluded).
- `Behavior.cs:10495-10588` — **Thief NPC AI**: Rogue-type creatures in combat can `UseSkill(Stealing)` to pilfer items from combatants. They steal from 10+ item types including weapons, bandages, reagents, spellbooks, runes, potions, scrolls, wands, and gold.
- `Utility.cs:2621` — Stealing appears in the `SkillGroup.Rogue` classification.

### Thieves Guild & NPCs
- `ThiefGuildmaster.cs:25` — Thief Guildmaster has **90 - 100** Stealing. Gives steal quests via `ThiefNote`.
- `Thief.cs:33` — Thief vendor NPC has **65 - 88** Stealing.
- `GypsyLady.cs:99` — Gypsy Lady has **65 - 88** Stealing.
- `Rogue.cs:89` (Humans), `ElfRogue.cs:84` (Elves), `OrkRogue.cs:88` (Orcs) — Rogue NPCs have **50+** Stealing (varies by bonus).
- `Stealing.cs:22-25` — `IsInGuild()` checks if player is a Thieves Guild member (`NpcGuild.ThievesGuild`). Required to steal from innocent players and access coffer quests.
- `Stealing.cs:188-190` — Without Thieves Guild membership, stealing from innocent players is blocked with message "You must be in the thieves guild to steal from other players."
- `GuildRing.cs:50` — **Thieves Guild Ring** grants **+10 Stealing** (Skill Bonus slot 3).

### Items & Equipment (Skill Bonuses)
| Item | Location | Bonus | Source |
|---|---|---|---|
| Burglar's Bandana | `Artifact_BurglarsBandana.cs:19` | +10 Stealing (Slot 0) | Artifact |
| Cloak of the Rogue | `Artifact_GrayMouserCloak.cs:14` | +25 Stealing (Slot 0) | Artifact — largest flat bonus |
| Shadow Dancer Cap | `Artifact_ShadowDancerCap.cs:21` | +10 Stealing (Slot 1) | Shadow Dancer set |
| Shadow Dancer Gorget | `Artifact_ShadowDancerGorget.cs:22` | +10 Stealing (Slot 1) | Shadow Dancer set |
| Shadow Dancer Tunic | `Artifact_ShadowDancerTunic.cs:22` | +10 Stealing (Slot 1) | Shadow Dancer set |
| Shadow Dancer Arms | `Artifact_ShadowDancerArms.cs:22` | +10 Stealing (Slot 1) | Shadow Dancer set |
| Shadow Dancer Leggings | `Artifact_ShadowDancerLeggings.cs:22` | +20 Stealing (Slot 1) | Shadow Dancer set — best piece |
| Shadow Dancer Gloves | `Artifact_ShadowDancerGloves.cs:22` | +10 Stealing (Slot 1) | Shadow Dancer set |

### Consumables
- `Elixirs.cs:4121` — **Elixir of Stealing** adds a temporary `DefaultSkillMod` to Stealing. Brewable at Alchemy (`DefAlchemy.cs:381`): recipe requires skill 60-120, uses MoonCrystal. Keg conversion at `PotionKeg.cs:411` (`PotionEffect.ElixirStealing`).

### Magic Systems
- `AnimalForm.cs:189-201` (Ninjitsu) — Certain animal forms grant **+10 Stealing** via `DefaultSkillMod` when `entry.StealingBonus` is true. Mod is applied on transform and removed when exiting animal form (`AnimalForm.cs:239`). Stealing is listed as a restricted skill for animal forms (`PlayerMobile.cs:1432`).

### Quests
- `StealBase.cs:283` (Thief quest) — `CheckSkill(Stealing, 0, 125)` to steal artifacts from trapped pedestals after successful Snooping check.
- `ThiefNote.cs:214, 249` — Thief quest notes direct players to use Stealing on coffers and dungeon pedestals. Randomly assigns "steal from town" or "steal from dungeon" objectives.
- `ThiefGuildmaster.cs:103-128` — Guildmaster gives Thief quests via `ThiefNote.GetMyCurrentJob()`, creating randomized item/target/reward objectives.
- `Coffer.cs:168` (Thief quest) — Post-snoop message instructs: "Use your stealing skill on the coffer."
- `BulletinBoards/StealingBoard.cs:1-119` — Thieves Guild bulletin board with artifact quest locations for 24 stealable artifacts.
- `CodexWisdom.cs:110, 430` — Skill index 45 = Stealing in Codex of Wisdom display and learn logic.

### Crafting
- `DefAlchemy.cs:381` — **Elixir of Stealing** (`ElixirStealing`): Alchemy recipe requiring 60.0 - 120.0 skill, uses MoonCrystal as reagent.
- `BaseRunicTool.cs:228, 329` — Runic tools can enchant items with Stealing as a possible skill bonus.

### Containers & Training
- `PickpocketDips.cs:83, 99` — **Pickpocket training dummies**: `CheckSkill(Stealing, m_MinSkill, m_MaxSkill)` for practice. Requires both Stealing and Snooping. Max skill gain from dips controlled by `S_PickDips` setting (default 30.0).
- `PickpocketDips.cs:97, 125` — Dips disabled when `Stealing.Base >= m_MaxSkill` or both Stealing and Snooping at max.
- `StolenChest` — Custom stolen chest item created on successful dungeon chest theft, copies original chest ID/gump/resource/hue.
- `DungeonChest` — Special chest type with item ID restrictions (graves, golems, etc. cannot be stolen).

### Scroll System
- `SpecialScroll.cs:91` — Stealing is skill index **34** on special scrolls.

### Race System
- `BaseRace.cs:1333` — Stealing is skill index **33** for racial skill assignments.

### Settings
- `Settings.cs:307-309` — `S_QuestRewardModifier` (default 150) modifies thief quest rewards and deco artifact values.
- `Settings.cs:314` — `S_DecoArtySteal = true` — Allow unlimited artifact pedestal steals (false = one-time only per character).
- `Settings.cs:319` — `S_PedStealThrottle = false` — Throttle lucrative pedestal loot to once every few days.
- `Settings.cs:358` — `S_PickDips = 30.0` — Maximum Stealing skill gain from pickpocket training dummies.
- `Settings.cs:305` — `S_CannotStealWhileBlessed = true` — Blessed players cannot steal (enforced at `Stealing.cs:49`).

### Other Systems
- `PowerScroll.cs:42, 215, 310, 410` — Stealing is in the power scroll skill list with max value and base value lookups.
- `DynamicBook.cs:343` — Stealing maps to the "Spy" title in dynamic book system.
- `LearnStealing.cs:11-94` — "The Art of Thievery" book item providing a gump-based tutorial for stealing.
- `ResourceMods.cs:1897` — Stealing is skill index **45** for resource modification systems.
- `CharacterCreation.cs:349` — Stealing is available as a skill during character creation.
- `SkillCheck.cs:264` — Stealing has a classic mode check in `SkillInfo.Check`.

## Related Skills

- [Snooping](snooping.md) — Directly paired; Snooping enables stealing from containers and creatures. Thieves Guild auto-restricts both. Failed coffer snoop uses Snooping check (0-150) to avoid being spotted by vendors.
- [Hiding](hiding.md) — Stay hidden while stealing. Failed stealing calls `RevealingAction()` exposing you from hiding.
- [Stealth](stealth.md) — Move silently to approach targets. Thieves Guild auto-restricts both.
- [Lockpicking](lockpicking.md) — Both used on containers; Thieves Guild auto-restricts both.
- [Searching](searching.md) — Complementary skill for finding hidden items and containers.
- [Remove Trap](remove-trap.md) — Trapped pedestal artifacts require Remove Trap after Stealing in thief quests.
- [Ninjitsu](../magic/ninjitsu.md) — Animal forms can grant +10 Stealing; Stealing is a restricted skill for animal transformation.
- [Disguise](disguise.md) — Disguise is removed when caught stealing; Thieves Guild members can steal from innocent players while disguised.
