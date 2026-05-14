# Mercantile

Mercantile lets you appraise and identify items, sell goods at better prices, and earn more from cargo shipping. It is the primary "merchant" skill, affecting NPC trade, item identification, and shipping economies.

## Overview

| Property | Value |
|---|---|
| Primary Stat | Intelligence |
| Usage | Active (targeted) |
| Range | 8 tiles |
| Gain Method | Identifying items, buying from and selling to vendors |

## How It Works

Use the skill to target items for identification via `RelicFunctions.IDItem`. Identification reveals the item's true name, properties, and estimated gold value. Items marked as unidentified must be identified before their contents can be accessed.

Mercantile also passively appraises visible items in your vicinity — if your Mercantile is high enough and your Base is below 50, you receive a random gold estimate for unidentified non-Relic items with value.

## Related Systems

### Vendor Trading

Mercantile directly affects how much gold you receive when selling items to NPCs and how much gold NPCs have available when you buy from them.

- `BaseVendor.cs:274` — When **buying** from a vendor, your Mercantile skill (divided by 2, capped at 50%) increases the gold the vendor has available for purchases. Guild members of the Merchants Guild get the full 50% bonus automatically.
- `BaseVendor.cs:1142` — When **selling** to a vendor, the `barter` value used in sell price calculation is set to `(int)from.Skills[SkillName.Mercantile].Value`. Higher Mercantile = better sell prices.
- `BaseVendor.cs:2044` — Per-sale barter value: `SoldBarter = (int)seller.Skills[SkillName.Mercantile].Value`, capped at 100 for guild members.
- `BaseVendor.cs:2156` — Per-item barter calculation uses Mercantile value, which can be replaced by Begging skill if the player is performing the begging pose.
- `BaseVendor.cs:1949` — **Buy skill gain**: one CheckSkill attempt per 200 gold spent on purchases.
- `BaseVendor.cs:2187` — **Sell skill gain**: one CheckSkill attempt per 500 gold received (plus 1 for the first 200), but **only when not begging and not a guild member**.

### Item Identification & Unidentified Loot

Mercantile is the primary identification skill for decorative items, artifacts, relics, and general unidentified loot.

- `Mercantile.cs:41` — The skill's `OnUse` callback targets items and calls `RelicFunctions.IDItem` with `SkillName.Mercantile`.
- `RelicFunctions.cs:38-44` — **Passive appraisal**: when you examine an unidentified item that isn't a Relic, if your Mercantile value exceeds a random roll (0-99) and your Base is below 50, you receive a random gold estimate and may gain the skill.
- `RelicFunctions.cs:105` — **Active identification check**: `CheckTargetSkill(skill, examine, -5, 125)` with a range of -5 to 125. Successful identification reveals the item name.
- `RelicFunctions.cs:137-148` — **Failed identification on relics**: the item is partially identified with a random CoinPrice of 5-25 gold and messages about its unusable nature.
- `RelicFunctions.cs:159-244` — **Vendor identification**: specific vendor types can only identify certain item categories (see `VendorCanID`). Merchants, Provisioners, Variety Dealers, and Merchant Guildmasters identify items with `Identity.Merchant` — the default Mercantile category.
- `NotIdentified.cs:55` — Double-click identification command routes to `RelicFunctions.IDItem` with Mercantile (unless Arms Lore or Tasting is specified).
- `NotIdentified.cs:68` — Default identification skill for unidentified items: `NotIDSkill = IDSkill.Mercantile`.
- `NotIdentified.cs:297-368` — **Auto-delete saving throw**: when unidentified items are auto-deleted from containers, each item rolls against your Mercantile skill. Higher skill = more items saved.

### Unidentified Item Auto-Delete

When unidentified items are cleared from containers (e.g., corpse decay, container purge), Mercantile skill determines which items are preserved.

- `Settings.cs:271-284` — `S_UnidentifiedItem_GuaranteedItemChecks` setting: an array of skill breakpoints. Default `[0, 30, 60]` means Mercantile 0 saves 1 item, 30 saves 2 items, 60 saves 3 items. At 125 Mercantile, all unidentified items are guaranteed to survive.
- `NotIdentified.cs:268` — `DoAutoDelete` reads Mercantile (along with Arms Lore and Tasting) to determine item preservation.
- `NotIdentified.cs:303-352` — Items with `NotIDSkill == IDSkill.Mercantile` (the default for most unidentified items) are saved based on Mercantile skill thresholds.

### Cargo & Shipping

Mercantile increases gold earned from shipping cargo on boats.

- `Cargo.cs:866` — `CargoMerchantGold` formula: `(int)(cargo.CargoValue * (Mercantile.Value * 0.01) / 3)`. At 100 Mercantile, this yields ~33% of cargo value as bonus gold.

### NpcGuild Synergy

Members of certain NpcGuilds face no penalty when training Mercantile.

- `SkillCheck.cs:284` — **Merchants Guild** members can train Mercantile without gain penalty.
- `SkillCheck.cs:349` — **Librarians Guild** members can train Mercantile without gain penalty.

### Runic Tools

Mercantile is one of the skills checked when using runic tools.

- `BaseRunicTool.cs:210` — Mercantile is included in the list of skills that can be affected by runic tool crafting.

### Relic Items

Most relic-type items use Mercantile as their identification skill.

- `Clocks.cs:248,336,424` — `DDRelicClock1/2/3` items all set `NotIDSkill = IDSkill.Mercantile`.
- `DDRelicArts.cs:27`, `DDRelicBanner.cs:36`, `DDRelicBook.cs:27`, `DDRelicCloth.cs:28`, `DDRelicCoins.cs:35`, `DDRelicDrink.cs:147`, `DDRelicFur.cs:28`, `DDRelicGem.cs:45`, `DDRelicGrave.cs:40`, `DDRelicInstrument.cs:35`, `DDRelicJewels.cs:26`, `DDRelicLeather.cs:26`, `DDRelicLight.cs:28,194,296`, `DDRelicOrbs.cs:29`, `DDRelicPainting.cs:29`, `DDRelicReagent.cs:64`, `DDRelicRug.cs:472`, `DDRelicScrolls.cs:27`, `DDRelicStatue.cs:40`, `DDRelicTablet.cs:53`, `DDRelicVase.cs:26`, `DDRelicArmor.cs:112`, `DDRelicAlchemy.cs:28`, `DDRelicBearRugs.cs:291`, `DDRelicWeapon.cs:105` — All DDRelic item types use `NotIDSkill = IDSkill.Mercantile`.
- `HighSeasRelic.cs:118` — Fishing-related relic items use Mercantile for identification.

### Avatar System

- `SkillArchive.cs:135-136` — Mercantile is tracked as a property in the Avatar/SkillArchive system.

### Behavior Skills

- `Behavior.cs:6245` — Mercantile is listed among the skills used in NPC/creature behavior decision-making.

### Character Creation & Quests

- `CharacterCreation.cs:190` — Mercantile is referenced as a named skill during character creation.
- `CharacterCreation.cs:896` — Mercantile 30 is a requirement for certain character creation options (likely a quest or achievement unlock).

### Player Commands

- `Skills.cs:72` — The `/skills` player command includes Mercantile help text explaining its identification and trading functions.
- `SkillsGump.cs:86` — Mercantile maps to index 27 in the skill selection gump.
- `Players.cs:251` — Mercantile is skill index 27 when displaying skills to other players.

### Resource Mods

- `ResourceMods.cs:1879` — Mercantile is skill index 27 in resource modification calculations.

## Training Tips

- **Best method**: Buy and sell items at vendors. Each 200 gold purchased and each 500 gold received in sales triggers a skill check.
- **Identification**: Identify unidentified items dropped by monsters. Each successful `CheckTargetSkill` can gain the skill, especially when rolling near your current skill level.
- **Passive appraisal**: Walking around with unidentified items in your backpack can trigger passive gold estimates and skill gains (Base < 50).
- **Merchants Guild membership** provides a flat 50% bonus to vendor gold availability (same as having 100 Mercantile) and removes the penalty on skill gains from trading.
- At **125 Mercantile**, all unidentified items are guaranteed to be preserved during auto-delete checks.

## Related Skills

- [Arms Lore](arms-lore.md) — Identifies weapons, armor, and crafted equipment. Shares the same identification system but with different item categories and a passive durability bonus.
- [Tasting](tasting.md) — Identifies potions, reagents, and food/drink items. Also shares the auto-delete and identification systems.
- [Begging](begging.md) — Can temporarily replace Mercantile when selling to vendors (if performing the begging pose), using Begging skill value for barter calculations instead.
- [Global Shoppes](../systems/global-shoppes.md) — NPC transactions at Global Shoppes also trigger Mercantile skill gains.
