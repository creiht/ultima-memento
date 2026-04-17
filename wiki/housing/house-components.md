# House Components

These are special items and fixtures that provide specific functionality in and around a house.

## House Sign

**Item ID:** 0xBD2  
**Source:** `World/Source/Scripts/Items/Houses/HouseSign.cs`

The House Sign is the central management interface for a house. It appears near the front door on placement and cannot be moved or removed.

- **Single-click:** Displays the house's current decay level (or "This house is Ageless" when decay is disabled).
- **Double-click:** Opens the house management gump. From here the owner can:
  - Set/change the house name.
  - Add and remove Co-Owners, Friends, Access, and Ban list members.
  - Toggle Public/Private.
  - Access vendor-placement options.
  - Transfer ownership.
- **Claim flow:** If the original owner has been gone a long time and the house is in a stale state, a visitor can select a context-menu option to claim the house, subject to restrictions (claims block re-placement for 7 days).
- **Context menu entry — Reclaim Vendor Inventory:** Allows the owner to recover inventory from vendors whose contracts have expired.
- In non-ML AOS mode, a **Friend** viewing the house sign refreshes the decay timer.

## House Teleporter

**Source:** `World/Source/Scripts/Items/Houses/HouseTeleporter.cs`  
Interface: `ISecurable`

A linked pair of teleporter pads that transport the player between two points in the house.

- Placed in pairs; each teleporter links to the other.
- Has a **SecureLevel** setting (see [Doors and Security](doors-and-security.md)) — restricts who can use the teleporter.
- Context menu allows the owner to configure the link destination.
- A **1-second delay** is imposed before teleportation completes.
- Teleportation produces a visual effect and sound (configurable).

## Players House Teleporter

**Source:** `World/Source/Scripts/Items/Houses/PlayersHouseTeleporter.cs`

A more configurable variant of the house teleporter for player use:

- **Dyable** — can be hued with a dye tub.
- Configurable: destination point, visual effect, sound effect, delay duration.
- Options to allow or block creatures and players in combat from using it.

## Moving Crate (Packing Crate)

**Item ID:** 0xE3D  
**Label:** "Packing Crate"  
**Source:** `World/Source/Scripts/Items/Houses/MovingCrate.cs`

The Moving Crate is auto-generated when a house is demolished or a custom foundation enters design mode. It collects all locked-down items and addon deeds that would otherwise be lost.

- Internally uses a 3×5 grid of **PackingBox** sub-containers.
- Each PackingBox holds a maximum of **20 items**.
- Only the **house owner** can access the Moving Crate.
- After **5 minutes**, the crate auto-internalizes to the owner's bank or pack.
- When empty, the crate self-deletes.

## Mailbox

**Item IDs:** 0x4142 (closed) / 0x4144 (open)  
**Source:** `World/Source/Scripts/Items/Houses/Mailbox.cs`

A container that must be **secured** in a house to function.

- **Anyone** can drop items into the mailbox (like dropping through a mail slot).
- **Friends** and higher can open and retrieve items.
- The graphic updates to show "open" (messages present) or "closed" (empty) state automatically.

## Magical Rope

**Item ID:** 0x14F8  
**Source:** `World/Source/Scripts/Items/Houses/MagicalRope.cs`

A rope fixed to the ceiling/wall. Use it to ascend to upper floors.

- Say **"climb"** while standing near the rope to use it.
- The item description tooltip reads: "Say 'climb' to Use the Rope".

## Tavern Table

**Item ID:** 0x55D9 (flipable to 0x55DA)  
**Source:** `World/Source/Scripts/Items/Houses/TavernTable.cs`

A special table used to create a tavern atmosphere.

- Must be **secured** in a house to use.
- Emits **Circle225 light** — a medium radius ambient light source.
- Double-click opens the **TavernGump**, which lets the owner configure seated **Patron NPCs** (`HouseVisitor` mobiles) that sit at the table and create an atmosphere.

## Related Pages

- [Ownership and Access](ownership-and-access.md) — who can use each component
- [Lockdowns and Secures](lockdowns-and-secures.md) — securing containers
- [Doors and Security](doors-and-security.md) — SecureLevel reference

---

**Source references:** `World/Source/Scripts/Items/Houses/HouseSign.cs`, `HouseTeleporter.cs`, `PlayersHouseTeleporter.cs`, `MovingCrate.cs`, `Mailbox.cs`, `MagicalRope.cs`, `TavernTable.cs`
