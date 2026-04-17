# Global Shoppes

Global Shoppes are player-operated craft businesses placed as physical objects in the world. You pay a one-time fee to unlock a shoppe, then serve walk-in customers and fulfil bulk craft orders to earn Gold, Reputation, and Points. Points are redeemable at the shoppe's built-in reward shop for unique tools and artifacts.

---

## How to Find a Shoppe

Shoppes are physical items placed in towns and villages throughout the world. To be directed to the nearest one:

1. Find an NPC tradesperson whose profession matches the shoppe type you want (e.g. a Blacksmith NPC for the Blacksmith Shoppe).
2. **Right-click** (single-click → context menu) the NPC while having **at least 50** in the matching skill.
3. The **"Setup Shoppe"** option will appear. Selecting it opens a tutorial gump that points you to the nearest available shoppe item.

---

## Unlocking a Shoppe

- **Cost:** 10,000 gold — drag the gold (or a check) directly onto the shoppe item.
- **Skill requirement:** ≥ 50 in the matching primary skill.
- **Progress is per-account** and is isolated between game modes — Avatar (`account-$AV`) and Hardcore (`account-$HC`) maintain separate shoppe histories and Points totals.

Once unlocked, the shoppe opens its main gump when double-clicked.

---

## The 11 Shoppe Types

| Shoppe | Primary Skill | NPC Guild | Tool | Resource | Orders? |
|---|---|---|---|---|---|
| Alchemist | Alchemy | Alchemists Guild | Mortar & Pestle | Reagents | Yes |
| Baker | Cooking | Culinarians Guild | Culinary Set | Dough / Sweet Dough | Yes |
| Blacksmith | Blacksmithing | Blacksmiths Guild | Smith Hammer | Metal Ingots | Yes |
| Bowyer | Bowcraft | Archers Guild | Fletcher Tools | Wood Boards | Yes |
| Carpentry | Carpentry | Carpenters Guild | Carpenter Tools | Wood Boards | Yes |
| Cartography | Cartography | Cartographers Guild | Mapmaker's Pen | Blank Scrolls | **No** ¹ |
| Herbalist | Druidism | Druids Guild | Druid Cauldron | Druidic Reagents | Yes |
| Librarian | Inscription | Librarians Guild | Scribe's Pen | Blank Scrolls | Yes |
| Mortician | Necromancy | Necromancers Guild | Witch Cauldron | Witchery Reagents | Yes |
| Tailor | Tailoring | Tailors Guild | Sewing Kit | Fabric | Yes |
| Tinker | Tinkering | Tinkers Guild | Tinker Tools | Metal Ingots | Yes |

¹ The **Cartography** shoppe is walk-in customers only. It has no craft-order system and earns no Points.

---

## Stocking the Shoppe

Drag items directly onto the shoppe item to restock it:

- **Tools** (cap: 1,000 uses) — each dragged tool adds its remaining uses to the shoppe's pool. See the table above for which tool each shoppe accepts.
- **Resources** (cap: 5,000 units) — raw materials consumed when serving customers. See the table above for the resource type each shoppe accepts.

The shoppe gump displays current tool and resource levels. Customers cannot be served when either drops to zero.

---

## Walk-in Customers

- Up to **12 customers** wait at a time; the list regenerates every **4 hours**.
- Customer lists are not saved across server restarts — the list regenerates on your next gump open after a restart.
- Each customer has a task description and a **difficulty** rating.
- **Success chance** = `(your skill − difficulty) + 25`, clamped to 0–100 %.
- **Accept** the job → your character attempts the task, consuming tools and resources.
  - **Success** → earn Gold + Reputation + craft skill gain + Mercantile gain.
  - **Failure** → small Reputation loss.
- **Reject** a customer → Reputation penalty. Use sparingly.

Higher Reputation makes future customers offer better-paying contracts.

---

## Craft Orders

- Up to **3 orders** are available at a time; the order list refreshes every **1 hour**.
- Orders are drawn from items you can currently craft with the shoppe's skill.
- An order may require:
  - A specific quantity of a particular item.
  - **Exceptional quality** (Blacksmith, Bowyer, Carpentry, Tailor orders).
  - A **specific resource type** (e.g. Valorite ingots for a Blacksmith order).
  - A **gem type** (Tinker jewellery orders).
- **To submit:** open the shoppe gump → "Add Items" → target the completed items from your pack.
- On completion choose your reward: **Gold**, **Points**, or **Reputation**.

Orders are saved to disk and survive server restarts.

### Order Reward Scaling

Reward amounts scale with Base Value × a per-shoppe ratio:

| Shoppe | Gold ratio | Points ratio | Reputation ratio |
|---|---|---|---|
| Alchemist | 0.33× | 0.40× | 0.025× |
| Baker | 1.00× | 1.50× | 0.08× |
| Blacksmith | 0.40× | 0.30× | 0.02× |
| Bowyer | 1.00× | 0.40× | 0.02× |
| Carpentry | 0.75× | 0.60× | 0.02× |
| Herbalist | 0.75× | 0.50× | 0.02× |
| Librarian | 0.75× | 0.75× | 0.02× |
| Mortician | 0.50× | 0.60× | 0.02× |
| Tailor | 1.00× | 0.60× | 0.02× |
| Tinker | 0.50× | 0.60× | 0.02× |

Baker and Tailor orders pay the most gold per order; Baker orders also award the most Points.

---

## Reputation

- Reputation increases when you succeed at customer jobs or complete craft orders.
- **Maximum:** 10,000 Reputation.
- Higher Reputation attracts higher-value customer contracts.
- Reputation is **lost** when you fail a customer job or reject customers/orders. Reject sparingly.

---

## Cashing Out Gold

Gold earned from customers accumulates inside the shoppe (cap: **500,000 gold**).

To withdraw:

1. Single-click the shoppe → **"Transfer"** context menu option.
2. A bank check is added to your backpack.

Your Mercantile skill and guild membership improve your cashout payout. Join the matching NPC guild for the best bonus.

---

## Points and the Reward Shop

Points are earned by completing craft orders (not from walk-in customers). Open the shoppe gump and select **"Rewards"** to browse and purchase items. Points are tracked per shoppe type and per account-mode.

The Cartography shoppe cannot earn Points.

### Reward Tiers

| Points Cost | Available Rewards |
|---|---|
| 1,000 | 1,000-use crafting tool (matching shoppe type); Repair Potion (Alchemist / Herbalist) |
| 2,000 | Monocle — 250 uses (Librarian only) |
| 2,500 | Durability Potion (Alchemist / Herbalist / Mortician); Magical Dyes — single-item rare hue (Alchemist / Herbalist) |
| 5,000 | Runic tool Tier I — 15 uses, crafted items gain 1 magical property (most shoppes); Arborist Tool — 50 uses (Bowyer / Carpentry); Advanced Skinning Knife — increases carving yields by 20%, 100 uses (Tailor); Metal Dye Tub — 20 uses (Blacksmith / Tinker); Wood Dye Tub — 20 uses (Bowyer / Carpentry); Leather Dye Tub — 20 uses (Tailor) |
| 10,000 | **Ancient Crafting Gloves** — +5 to the shoppe's primary skill, 10 uses (one variant per shoppe type) |
| 20,000 | Runic tool Tier II — 10 uses, crafted items gain 2 magical properties (most shoppes); Soulstone Fragment — extract a single skill, binds to account (Alchemist / Herbalist) |
| 50,000 | Runic tool Tier III — 5 uses, crafted items gain 3 magical properties (most shoppes); Everlasting Bottle — refills itself when drunk (Baker); Everlasting Loaf — reforms itself when eaten (Baker); Hue Vacuum Tube (Tinker) |
| 100,000 | **Artifact Boots of Hermes** — run at mounted speed while on foot (all shoppe types) |

---

## Skill Training

Every served customer and every completed craft order trains both the shoppe's **primary craft skill** and **Mercantile**. The shoppe is an efficient way to raise Mercantile passively alongside your crafting skill.

---

## Limits & Constants Reference

| Stat | Value |
|---|---|
| Unlock fee | 10,000 gold |
| Minimum skill to unlock | 50 |
| Max customers at once | 12 |
| Customer list refresh | every 4 hours |
| Max orders at once | 3 |
| Order list refresh | every 1 hour |
| Max shoppe gold | 500,000 |
| Max tool uses stored | 1,000 |
| Max resources stored | 5,000 |
| Max Reputation | 10,000 |

---

## Related Systems

- [Merchant Crates](merchant-crates.md) — passive home-based selling; no skill floor, no customers
- [Bulk Orders](bulk-orders.md) — automated mass-crafting contracts from NPCs
- Each crafting profession: [Alchemy](alchemy.md), [Cooking / Baking](cooking.md), [Blacksmithy](blacksmithy.md), [Bow Fletching](bowfletching.md), [Carpentry](carpentry.md), [Cartography](cartography.md), [Druidism (Herbalism)](druidism-crafting.md), [Inscription](inscription.md), [Tailoring](tailoring.md), [Tinkering](tinkering.md)

---

## Tips

- **Join the matching NPC guild** before cashing out — guild membership provides a significant bonus on top of your Mercantile skill.
- **Keep tools and resources topped up.** You cannot serve customers when either runs out, and incomplete service wastes the refresh timer.
- **Prioritise orders for materials you over-harvest.** If you mine in bulk, Blacksmith or Tinker orders let you convert surplus ingots directly into Points.
- **Manage Reputation carefully.** Rejecting customers is sometimes necessary, but the Reputation loss compounds — keep a few easy customers available as a buffer.
- **Baker and Tailor shoppes offer the best Points-per-order ratios.** If you do both crafts, prioritise their orders.
- **Cartography shoppe note:** it has customers but no orders and earns no Points. Run it for the customer income and Reputation only.
