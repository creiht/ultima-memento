# Henchmen

Henchmen are gold-paid adventuring companions that fight alongside you in dungeons. Unlike tamed pets, they are not controlled through the Animal Taming skill — they are hired through deed items. Unlike magical summons, they persist across sessions in deed form and remember their remaining travel time and bandage supply.

## Overview

| Property | Value |
|---|---|
| Max active henchmen | 2 |
| Follower slots per henchman | 1 |
| How to dismiss | Release them anywhere; deed returns to backpack |
| Transferable? | Deed can be given to another player; active henchmen cannot be transferred |
| Bondable? | No |
| Stableable? | No |
| Dispellable? | No |

---

## How to Acquire

### Inn / Tavern Purchase

Fighter, Archer, and Wizard henchmen are sold as deed items at inns and taverns throughout the world.

| Type | Buy Price |
|------|-----------|
| Fighter henchman | 5,000 gp |
| Archer henchman | 6,000 gp |
| Wizard henchman | 7,000 gp |

### Prisoner Quest

When freeing a prisoner from a dungeon cage, you may instead recruit them as a henchman. See [Prisoner Quests](../quests/prisoners.md) for the full system.

| Prisoner Type | Cost Range | Notes |
|---|---|---|
| Human Fighter (type 97) | 4,100–5,000 gp | Random within range |
| Human Archer (type 98) | 5,100–6,000 gp | Random within range |
| Human Wizard (type 99) | 6,100–7,000 gp | Random within range |
| Monster Fighter | same range | Variable creature body |
| Monster Archer | same range | Variable creature body |
| Monster Mage | same range | Variable creature body |

[Begging](../skills/begging.md) reduces cost up to 3,000 gp at grandmaster skill (Begging × 25 = discount in gold).

Monster henchmen are **only available through Prisoner quests** — they cannot be purchased at inns.

### Tavernkeeper "Swap"

Drag an existing henchman deed onto a TavernKeeper or Barkeeper to receive a freshly-dressed replacement of the same type. The timer (`HenchTimer`) and bandage count (`HenchBandages`) carry over from the original deed.

---

## The Four Types

| Type | AI | Range | Primary Role |
|------|----|-------|-------------|
| Fighter | AI_Melee | Melee | Front-line tank and damage |
| Archer | AI_Archer | 7 tiles | Ranged physical damage |
| Wizard | AI_Mage | 7 tiles | Spellcasting / mixed damage |
| Monster | Variable† | Variable | Prisoner-only; body/AI depends on creature |

†Monster henchmen have the body of their prisoner creature but use the same stat-derivation and AI pattern (melee, archer, or mage) as the equivalent class.

---

## Stat Derivation

All henchman stats are calculated **from the summoner** at the moment the deed is used. There are no fixed stats.

### Input Values

```
nStats  = player.RawStr + player.RawDex + player.RawInt   (raw, no item bonuses)
nSkills = player.SkillsTotal / (player.Skills.Cap / 100)  (as %, capped at 100)
```

`SkillsTotal / SkillsCap` gives a skill "percentage" (0–100) representing how full the player's skill pool is.

### Per-Type Stat Split

| Stat | Fighter | Archer | Wizard |
|------|---------|--------|--------|
| STR | nStats/6 × 3 | nStats/6 × 2 | nStats/6 × 1 |
| DEX | nStats/6 × 2 | nStats/6 × 3 | nStats/6 × 2 |
| INT | nStats/6 × 1 | nStats/6 × 1 | nStats/6 × 3 |

### Derived Combat Values

| Value | Formula |
|---|---|
| Hits | STR × 2 |
| Stamina | DEX × 2 |
| Mana | INT × 2 |
| Damage (min–max) | nStats/20 – nStats/10 |
| Virtual Armor | nStats / 5 |
| Physical Resist | Fighter: nStats/2 · Archer: nStats/3 · Wizard: nStats/4 (all cap at 70) |
| Fire/Cold/Poison/Energy Resist | Fighter: nStats/4 · Archer: nStats/6 · Wizard: nStats/7 (all cap at 70) |

All resistances are hard-capped at **70%**.

### Worked Example

A player with **RawStr 100, RawDex 80, RawInt 90** and skills at 100% cap:

- `nStats = 270`, `nSkills = 100`

**Fighter henchman:**

| Stat | Calculation | Result |
|---|---|---|
| STR | 270/6 × 3 | 135 |
| DEX | 270/6 × 2 | 90 |
| INT | 270/6 × 1 | 45 |
| Hits | 135 × 2 | 270 |
| Stamina | 90 × 2 | 180 |
| Mana | 45 × 2 | 90 |
| Damage | 13–27 | |
| Phys Resist | 270/2 = 135 → capped | 70% |
| Elem Resists | 270/4 = 67 | 67% |

---

## Skills Assigned Per Type

Every skill is set to `nSkills` (0–100), scaled from the player's total skill fill.

| Skill | Fighter | Archer | Wizard |
|-------|:-------:|:------:|:------:|
| Swords | ✓ | | |
| Bludgeoning | ✓ | | |
| Marksmanship | | ✓ | ✓ |
| Magery | | | ✓ |
| Psychology | | | ✓ |
| Poisoning | | | ✓ |
| Meditation | | | ✓ |
| Tactics | ✓ | ✓ | ✓ |
| Parry | ✓ | ✓ | |
| Anatomy | ✓ | ✓ | ✓ |
| Healing | ✓ | ✓ | ✓ |
| MagicResist | ✓ | ✓ | ✓ |
| Focus | ✓ | ✓ | ✓ |

Monster henchmen use the same table for their AI type (melee, archer, or mage variant).

---

## Payment / Morale / Timer System

The henchman's **Fame** field stores the remaining "morale" in payment units (not the usual fame stat). Every **5 gold-equivalent units** = **1 minute** of adventuring time.

| Property | Value |
|---|---|
| Starting timer | 300 units = 1 hour |
| Maximum timer | 1,800 units = 6 hours |
| Cost per minute | 5 gp (equivalent) |
| Morale tick interval | 60 seconds, on movement |
| Rest regions (timer paused) | Inns, taverns, player homes, camping areas |
| Warning threshold | Below 26 units (~5 minutes) |

When the timer reaches 0 the henchman says a leaving phrase and departs — the deed reappears in your backpack.

### Payment Table

Drag treasure directly onto the henchman to pay them. The gold-equivalent value is added to their timer.

| Item | Gold-Equivalent |
|---|---|
| Gold coin | 1 gp each |
| Gold Nuggets | 1 gp each |
| Silver coin (DDSilver) | 1 gp per 5 |
| Copper coin (DDCopper) | 1 gp per 10 |
| Jewels (DDJewels) | 2 gp each |
| Xormite (DDXormite) | 3 gp each |
| Crystals | 5 gp each |
| Gemstones (DDGemstones) | 2 gp each |
| Ring / Necklace / Earrings / Bracelet / Circlet | 50–300 gp (random) |
| Amber | 12 gp each |
| Amethyst | 25 gp each |
| Citrine | 12 gp each |
| Diamond | 50 gp each |
| Emerald | 25 gp each |
| Ruby | 19 gp each |
| Sapphire | 25 gp each |
| Star Sapphire | 31 gp each |
| Tourmaline | 23 gp each |

### Potions (Consumed Immediately)

Drop any of the following potions on the henchman; they consume it, return an empty bottle, and the effect is applied:

| Potion Type | Effect |
|---|---|
| Lesser/Regular/Greater Heal | Full heal (Hits → HitsMax) |
| Lesser/Regular/Greater Cure | Cures poison |
| Refresh / Total Refresh | Full stamina restore |
| Lesser/Regular/Greater Mana | Full mana restore |
| Lesser/Regular/Greater Rejuvenate | Full heal + stamina + mana |

---

## Self-Healing

Henchmen use bandages from their **Hunger** field (treat Hunger as bandage count). Bandages are consumed at a rate of one per healing application.

- Interval: 4–8 seconds (random) between healing applications
- Condition: must have > 0 bandages AND be injured
- **Heal formula:** random between `Anatomy/4 + Healing/4 + 6` and `Anatomy/4 + Healing/2 + 20`
- **Poison cure chances by Healing skill:**

| Healing Skill | Cure Chance |
|---|---|
| 90+ | 100% (always cures) |
| 80–89 | 75% (3 in 4) |
| 70–79 | 50% (1 in 2) |
| 60–69 | 25% (1 in 4) |
| Below 60 | No cure |

Drop [Bandage](../items/consumables.md) stacks directly onto the henchman to resupply them.

---

## Commands / Speech

| Command | Response |
|---|---|
| Say `report` within range | Henchman announces current bandage count and remaining minutes |

The default control order is **Guard**. Loyalty resets to 100 whenever the henchman attacks, is attacked, or receives a payment item.

---

## Summoning Rules

- You must be in a **rest region** (inn, tavern, player-owned home, or equivalent) to summon a henchman.
- Each henchman uses **1 follower slot**. You need at least 1 free slot.
- Maximum of **2 active henchmen** at any time.

---

## Mounting

When a henchman is active and you **mount a creature or gain speed**, the henchman automatically mounts a `HenchHorse`:

- Fighter, Archer, and Wizard henchmen mount a HenchHorse when the player is mounted.
- Mounted speed: ActiveSpeed 0.1, PassiveSpeed 0.2 (unmounted: 0.2 / 0.4).
- Monster henchmen do not mount independently.
- Controlled via `S_FastFriends` server setting.

---

## Death

When a henchman is killed:

1. The deed reappears in your backpack renamed to **"dead [type] henchman"**.
2. The deed's `HenchDead` value is set to `(Str + Dex + Int) × 2` — this is the gold cost to resurrect.
3. The henchman's corpse and equipment are removed (`DeleteCorpseOnDeath = true`).
4. If a **player** (not the henchman's master) killed the henchman, that player becomes **Criminal** and gains +1 kill count.

---

## Resurrection

To revive a dead henchman, target the dead deed item using any of:

| Method | Notes |
|---|---|
| **Healer NPC** (hire to resurrect) | Costs the gold shown on the deed; Begging discount applies |
| **Resurrection spell** (Magery 8th) | Target the dead deed |
| **Restorative Soil** (Druidism) | Target the dead deed |
| **Elemental Soul** (Elementalism 8) | Target the dead deed |
| **Rebirth spell** (Holy Man) | Target the dead deed |
| **Vampire Gift** (Witch) | Target the dead deed |

After resurrection, the name reverts to normal and the henchman can be summoned again from a rest region.

---

## Alignment Dressing

Henchman gear and titles vary based on the player's alignment:

- **Evil-aligned players** (`EvilPlay = true`): henchmen receive dark-hued gear and an evil-themed title.
- **Oriental-aligned players** (`OrientalPlay = true`): henchmen receive samurai / eastern-themed equipment variants.

---

## Limitations

| Property | Value |
|---|---|
| Bondable | No |
| Stableable | No |
| Dispellable | No |
| Transferable (active) | No — release first, then give deed |
| Deed transferable | Yes — give deed to another player who then owns that henchman |
| Max followers at once | 2 |

---

## Related Systems & Cross-links

- [Prisoner Quests](../quests/prisoners.md) — primary source of Monster henchmen and lower-cost human henchmen
- [Begging](../skills/begging.md) — reduces recruitment cost and healer resurrection fee
- [Healing](../skills/healing.md) — determines henchman self-heal and poison-cure effectiveness
- [Familiars](familiars.md) — the three distinct "familiar" systems; different from henchmen
- Settings: `S_FastFriends`, `S_FriendsAvoidHeels`, `S_FriendsGuardFriends` in `Settings.cs`

---

## Source Files

| File | Purpose |
|---|---|
| `World/Source/Scripts/Mobiles/Civilized/Comrades/HenchmanFunctions.cs` | Core morale, payment, combat, healing, death logic |
| `World/Source/Scripts/Mobiles/Civilized/Comrades/HenchmanFighter.cs` | Fighter mobile |
| `World/Source/Scripts/Mobiles/Civilized/Comrades/HenchmanArcher.cs` | Archer mobile |
| `World/Source/Scripts/Mobiles/Civilized/Comrades/HenchmanWizard.cs` | Wizard mobile |
| `World/Source/Scripts/Mobiles/Civilized/Comrades/HenchmanMonster.cs` | Monster mobile |
| `World/Source/Scripts/Mobiles/Civilized/Comrades/HenchmanItem.cs` | Deed base class / summoning logic |
| `World/Source/Scripts/Mobiles/Civilized/Comrades/HenchHorse.cs` | Mount spawned when player is mounted |
| `World/Source/Scripts/Engines and Systems/Quests/Prisoners/Prisoner.cs` | Prisoner quest recruitment |
| `World/Source/Scripts/Mobiles/Base/BaseVendor.cs` | TavernKeeper swap logic |
| `World/Source/Scripts/Mobiles/Base/BaseHealer.cs` | Healer resurrection |
