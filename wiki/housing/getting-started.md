# Getting Started with Housing

This page gives a new player everything they need to place their first house and get it running.

> **Before you place:** You may own at most **2 houses per account** (`S_HousesPerAccount = 2`). Houses do not decay on this server by default — your house is yours indefinitely once placed.

## Step 1 — Choose Your House

Two placement methods exist:

**Construction Contract (recommended for classic houses)**
- Obtained from Architect NPCs or the Housing placement tool (item graphic 0x14F0).
- Lets you preview the house footprint, see storage/lockdown/vendor stats, and withdraw the cost from your bank before committing.
- Opens a category gump: Classic Houses | 2-Story Foundations | 3-Story Foundations.

**House Deed**
- A deed item in your pack; double-click it, target the location.
- Deed is consumed on placement.
- Faster, but no preview gump.

See [Placement](placement.md) for a full breakdown of restrictions.

## Step 2 — Find a Valid Spot

- Stand where you want the northwest corner to land.
- The land must be flat near the foundation.
- At least 1 yard tile around the house must be clear of impassable objects.
- Houses cannot overlap existing structures, roads, towns, dungeons, or NoHousing regions.

## Step 3 — Place

- Use the Construction Contract: double-click it → pick a house from the gump → select a category → click the house name → target a location. A preview appears for 20 seconds; click Okay to confirm or Cancel to abort.
- Use a deed: double-click the deed → target the ground.
- The build cost (for contracts) is withdrawn from your bank automatically.

## Step 4 — The House Sign

Once placed, a **House Sign** hangs near the front door. Double-click it to open the house management gump, where you can:
- Set the house name.
- Add/remove Co-Owners, Friends, and Access/Ban lists.
- Toggle Public/Private.
- Access vendor management.

See [Ownership and Access](ownership-and-access.md).

## Step 5 — Lock Items Down

Say **"I wish to lock this down"** while standing inside your house and click an item, or use the house management gump. Locked-down items stay where you placed them and count against your lockdown limit.

To secure a container, say **"I wish to secure this"**. Secured containers have role-based access (Owner/Co-Owner/Friends/Anyone/Guild).

See [Lockdowns and Secures](lockdowns-and-secures.md).

## Key Things to Know

| Topic | Quick Answer |
|---|---|
| Houses per account | 2 |
| Decay | Disabled — houses are Ageless |
| Cooldown after demolish | None (no built-in cooldown; re-place immediately) |
| Mounts inside | Not allowed (`S_NoMountsInHouses = true`) |
| Building on mounts | Not allowed (`S_NoMountBuilding = true`) |
| Custom foundations | Available via Construction Contract |
| Lawn/exterior items | Up to 15 tiles outside via Lawn System |

## Related Pages

- [Placement](placement.md) — full placement rules
- [House Types](house-types.md) — all classic house stats
- [Custom Foundations](custom-foundations.md) — design-your-own houses
- [Ownership and Access](ownership-and-access.md) — co-owners, friends, bans
- [Lockdowns and Secures](lockdowns-and-secures.md) — storage mechanics
- [Addons](addons.md) — functional and decorative addons
- [Lawn and Remodeling](lawn-and-remodeling.md) — exterior customization

---

**Source references:** `World/Source/Scripts/Items/Houses/HousePlacementTool.cs`, `World/Source/Scripts/Items/Houses/BaseHouse.cs`, `World/Info/Scripts/Settings.cs`
