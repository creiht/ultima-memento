# Ownership and Access

Every house has a strict permission hierarchy. Each role controls what actions a player may take inside and around the house.

## Permission Pyramid

```
Owner
  └─ Co-Owner (up to 15)
       └─ Friend (up to 50 / 140 in AOS)
            └─ Access
            └─ Public visitor
            └─ Banned (blocked)
```

## Role Reference

| Role | Limit | Who Sets It | Capabilities |
|---|---|---|---|
| **Owner** | 1 (unique) | Transferred explicitly | Full control: all management gump options, locks and secures, vendor access, ban/friend/co-owner lists, demolish/transfer |
| **Co-Owner** | 15 | Owner only | Lock/unlock items and containers, manage Friends, kick banned players; cannot manage other co-owners |
| **Friend** | 50 (non-AOS) / 140 (AOS) | Owner or Co-Owner | Enter private house, use locked-down items (per type), refresh decay by opening a door |
| **Access** | Same pool as Bans | Owner or Friend (AOS) | Enter private house; cannot use most locked items |
| **Banned** | 50 (non-AOS) / 140 (AOS) | Any Friend or higher | Cannot enter the house at all; ban is account-wide |

Limits: `BaseHouse.cs:21–23`  
`MaxCoOwners = 15`, `MaxFriends = 50 / 140`, `MaxBans = 50 / 140`

## Public vs Private

- **Public** — anyone can enter and walk around; banned players still cannot enter.
- **Private** — only Friends and higher can enter. In AOS mode, banning someone from a private house is not allowed.

Toggle via the house management gump (double-click the house sign).

## House Transfer

To transfer ownership:

1. Both the current owner and the recipient must be outside the house.
2. Both must be within 2 tiles of the house sign.
3. The owner double-clicks the sign and uses the transfer option; the recipient must confirm.

On transfer:
- All Co-Owner, Friend, Access, and Ban lists are cleared.
- Keys are rotated (locks changed).
- Vendor sub-ownership is cleared.

Note: `S_HouseOwners = false` (default) means co-owners are **not** treated as full owners for access purposes.

## Banning Rules

- Banning is account-wide — all characters on the banned account are blocked.
- Any Friend or higher can ban a visitor who is not already on the Friend list.
- A banned player cannot enter even if the house is Public.
- In AOS mode you cannot ban someone from inside a Private house.

## Co-Owner Notes

- Co-owners can lock and unlock items, add/remove friends, and secure containers.
- They cannot remove other co-owners; only the Owner can do that.
- A StrongBox is created for each co-owner (see [Lockdowns and Secures](lockdowns-and-secures.md)).

## Related Pages

- [Lockdowns and Secures](lockdowns-and-secures.md) — what each role can do with items
- [House Components](house-components.md) — the house sign management gump
- [Vendors](vendors.md) — vendor ownership rules
- [Admin and Settings](admin-and-settings.md) — `S_HouseOwners` flag

---

**Source references:** `World/Source/Scripts/Items/Houses/BaseHouse.cs:21–23`, `BaseHouse.cs:2283–2325`, `World/Info/Scripts/Settings.cs:614`
