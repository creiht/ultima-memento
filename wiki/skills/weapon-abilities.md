# Weapon Abilities

Weapon abilities are special combat moves attached to weapons. Each weapon has up to **five** ability slots (Primary through Fifth), unlocked as your weapon skill and Tactics increase.

## How Weapon Abilities Work

### Activation

Weapon abilities can be activated in several ways:
- Click the ability icon on the **Weapon Ability Bar** (opens automatically on login if enabled)
- Use commands: `[Set1`, `[Set2`, `[Set3`, `[Set4`, `[Set5`
- Or the longer forms: `[SetPrimaryAbility`, `[SetSecondaryAbility`, etc.

Once activated, the ability fires on your **next successful melee hit**, consuming mana.

### Skill Requirements

Each ability slot requires a minimum weapon skill **and** Tactics skill:

| Slot | Required Skill |
|---|---|
| Primary | Base (server-configured) |
| Secondary | Base + 10 |
| Third | Base + 20 |
| Fourth | Base + 30 |
| Fifth | Base + 40 |

The "Use Best Skill" weapon property allows any combat skill (Swords, Bludgeoning, Fencing, Fist Fighting) to satisfy the requirement.

### Mana Cost

Each ability has a base mana cost, reduced by:
- **Combined combat skill total** (300+ total: -10 mana; 200+: -5 mana). Relevant skills: Swords, Bludgeoning, Fencing, Marksmanship, Parry, Lumberjacking, Stealth, Fist Fighting, Poisoning, Bushido, Ninjitsu.
- **Lower Mana Cost** equipment property (up to the server cap).
- Using a special move within **3 seconds** of the previous one **doubles** the mana cost.

### Validation

You must have enough mana, the required weapon skill, and the ability must be one of your current weapon's abilities. If any check fails, the ability is cleared.

---

## Base Weapon Abilities

| Ability | Mana | Damage | Effect |
|---|---|---|---|
| Armor Ignore | 20 | 90% | Ignores target's armor on hit |
| Armor Pierce | 20 | 125% | Reduces target's armor rating |
| Bladeweave | 10 | 100% | Random bonus effect on hit |
| Bleed Attack | 30 | 100% | Target bleeds over time |
| Block | 20 | 100% | Grants temporary melee/magic damage absorption |
| Concussion Blow | 20 | 100% | Reduces target's intelligence temporarily |
| Crushing Blow | 25 | 125% | Heavy damage strike |
| Defense Mastery | 20 | 100% | Reduces defender's defense chance |
| Disarm | 20 | 100% | Knocks weapon from target's hands |
| Dismount | 20 | 100% | Knocks target off their mount |
| Disrobe | 15 | 100% | Removes a piece of target's armor |
| Double Shot | 30 | 100% | Fires two arrows in rapid succession |
| Double Strike | 30 | 90% | Strikes twice in a single attack |
| Dual Wield | 30 | 100% | Temporarily enables off-hand attacks |
| Feint | 25 | 100% | Increases your defense chance temporarily |
| Force Arrow | 20 | 100% | Pushes target back with force |
| Force of Nature | 40 | 100% | Powerful nature-damage attack over time |
| Frenzied Whirlwind | 30 | 100% | Hits all targets in range in a frenzy |
| Infectious Strike | 15 | 100% | Transfers weapon poison to target on hit |
| Lightning Arrow | 20 | 100% | Deals lightning damage to nearby targets |
| Mortal Strike | 25 | 100% | Prevents target from healing for several seconds |
| Moving Shot | 15 | 100% | Allows firing while moving (-25% accuracy) |
| Nerve Strike | 20 | 100% | Paralyzes and drains stamina |
| Paralyzing Blow | 20 | 100% | Paralyzes the target briefly |
| Psychic Attack | 30 | 100% | Reduces target's mana regeneration |
| Riding Swipe | 30 | 100% | Special mounted attack |
| Serpent Arrow | 30 | 100% | Applies lethal poison via arrows |
| Shadow Strike | 20 | 125% | Bonus damage from stealth; extra damage if hidden |
| Talon Strike | 30 | 120% | Powerful strike with bleeding |
| Whirlwind Attack | 15 | 100% | Hits all enemies in melee range |

---

## Extra Weapon Abilities

These additional abilities extend the base set with elemental, tactical, and situational options:

| Ability | Mana | Damage | Effect |
|---|---|---|---|
| Achilles Strike | 20 | 100% | Targets weak points to slow the enemy |
| Consecrated Strike | 20 | 100% | Deals holy damage against undead/evil |
| Death Blow | 50 | 150% | Massive damage finisher |
| Devastating Blow | 30 | 200% | Highest damage multiplier strike |
| Double Whirlwind | 25 | 100% | Two whirlwind attacks in succession |
| Earth Strike | 20 | 100% | Physical/earth elemental damage |
| Elemental Strike | 20 | 100% | Random elemental damage type |
| Fire Strike | 20 | 100% | Fire elemental damage |
| Fists of Fury | 20 | 90% | Rapid fist-fighting combo attack |
| Freeze Strike | 20 | 100% | Cold elemental damage |
| Lightning Strike | 20 | 100% | Energy/lightning elemental damage |
| Magic Protection | 25 | 100% | Absorbs incoming magic damage |
| Magic Protection II | 30 | 100% | Greater magic damage absorption |
| Melee Protection | 25 | 100% | Absorbs incoming melee damage |
| Melee Protection II | 30 | 100% | Greater melee damage absorption |
| Riding Attack | 20 | 100% | Bonus damage while mounted |
| Shadow Infectious Strike | 25 | 100% | Infectious Strike from stealth |
| Spin Attack | 20 | 90% | Spinning area attack |
| Stunning Strike | 20 | 100% | Stuns the target briefly |
| Toxic Strike | 20 | 100% | Poison elemental damage |
| Zap Dex | 25 | 100% | Temporarily drains target's Dexterity |
| Zap Int | 25 | 100% | Temporarily drains target's Intelligence |
| Zap Mana | 25 | 100% | Drains target's Mana |
| Zap Stamina | 25 | 100% | Drains target's Stamina |
| Zap Str | 25 | 100% | Temporarily drains target's Strength |

---

## Tips

- Keep mana-efficient abilities (Infectious Strike at 15, Whirlwind at 15, Moving Shot at 15) in mind for sustained combat.
- High-damage abilities like Devastating Blow (200%) and Death Blow (150%) are best saved for critical moments.
- Crowd control abilities (Paralyzing Blow, Mortal Strike, Nerve Strike) are extremely valuable in PvP.
- Defensive abilities (Block, Defense Mastery, Magic/Melee Protection) help tanks survive.
- The 3-second double-mana penalty means you should pace your special moves rather than spamming them.
