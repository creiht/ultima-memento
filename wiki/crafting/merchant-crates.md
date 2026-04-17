# Merchant Crates

A Merchant Crate is a container that craftsmen can place in their home as a passive income source. Once locked down, it acts as a storefront — you fill it with crafted goods, and a representative from the Merchants Guild stops by once a day to purchase whatever you have left inside, leaving gold in return.

---

## Obtaining a Merchant Crate

Merchant Crates are available from provisioners and general-goods vendors. They can also be crafted by tinkers in some server configurations. The crate appears as a wooden chest and can be dyed or flipped before placement.

---

## Setting Up

1. **Find a house** — the crate must be locked down inside a player house to function. It will not accept purchases while movable.
2. **Lock it down** — use your house menu to secure the crate to the floor.
3. **Stock it** — open the crate and place your crafted goods inside. The crate will display the total gold value of its current contents in its item label.

---

## What Sells and for How Much

When you place an item into the crate you will see a message indicating its gold value to the guild. The following guidelines apply:

- **Crafted armor, weapons, and clothing** — valued based on the resource used, quality (exceptional = higher), and durability. Higher-tier materials (e.g. valorite, dwarven) are worth more.
- **Non-crafted armor, weapons, and clothing** — valued at **0 gold**. Only player-crafted gear has value.
- **Potions, scrolls, tools, food, and furniture** — valued at their standard guild price.
- **Tools** must have at least **50 uses remaining** to have any value.
- **Ingots and logs** — always accepted and well-valued regardless of how they were obtained. Different ore/wood types command higher prices based on tier.
- **Items that cannot be crafted** — generally have no value unless they are ingots or logs.

---

## Daily Pickup

Once per day a Merchants Guild representative visits the crate and purchases everything inside. The gold accumulated from the sale is stored in the crate and visible in the item label (e.g. "Contains: 1,500 Gold").

---

## Cashing Out

1. Single-click the crate → select **"Transfer"** from the context menu.
   - The Transfer option only appears when the crate is locked down and contains gold.
2. A bank check for the full amount is added to your backpack and a confirmation message is shown.

### Mercantile and Guild Bonus

Your **Mercantile skill** and **Merchants Guild membership** both improve the payout you receive:

- Base bonus: `Mercantile skill ÷ 2` percent added to the base gold value.
- Guild bonus: an additional **+25 %** if you are a member of the Merchants Guild.

The crate's label shows the base accumulated gold. The actual check you receive will be higher if you have Mercantile skill or guild membership.

---

## Comparison with Global Shoppes

| Feature | Merchant Crate | Global Shoppes |
|---|---|---|
| Skill requirement | None | ≥ 50 in matching skill |
| Setup | Lock down in house | Unlock physical shoppe item (10,000 gold) |
| Income style | Passive — daily guild pickup | Active — serve customers and fulfil orders |
| Customer interaction | None | Up to 12 walk-in customers (4 h refresh) |
| Craft orders | None | Up to 3 orders (1 h refresh) |
| Points / reward shop | No | Yes |
| Reputation system | No | Yes |
| Mercantile bonus | Yes (on cashout) | Yes (on cashout) |
| Guild bonus | Yes (+25 % Merchants Guild) | Yes (matching NPC guild) |

Use Merchant Crates for **steady passive income** from surplus production. Use [Global Shoppes](global-shoppes.md) when you want to **actively work your craft** for Points, unique rewards, and Reputation.

---

## Operator Note

Merchant Crates can be disabled server-wide by operators via the `S_MerchantCrates` setting (`false` disables the selling functionality; the crate becomes a plain container). When disabled the crate description changes to reflect its decorative-only status.

---

## Related Systems

- [Global Shoppes](global-shoppes.md) — active craft business with customers, orders, and a reward shop
- [Bulk Orders](bulk-orders.md) — NPC-issued mass-crafting contracts for additional income
