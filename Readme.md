# Tome Of The Firebird
---
A package of spells, feats, other abilities and some fixes.

And also some more random stuff I made when I got annoyed at the game.

All homebrew content or divergences from TT will be called out.

NOW REQUIRES TabletopTweaks Core Module and ModMenu




## Changelog

### 1.4.11
Hotfix for localization issue with Phoenix Bloodrager Bloodline


### 1.4.10

Official 2.1.2 release - Don't thing this will work with 2.1.0 or 2.1.1
Fix for fly localization
Fix for everything breaking because of Owlcat changing Lethal Stance implementation when I was cloning it.
Fix for Kineticist Internal Buffer keeping on working when you run out of charges - KNOWN ISSUE, TOGGLE STAYS ACTIVE WHEN OUT OF RESOURCES


### 1.4.9
2.1 Beta experimental patch. WARNING: Has not been signficantly tested!
Added Spells: Fly
Buffed Elemental Bloodline Elemental Strikes - now always-on at level 1, gains burst effect at level 20



### 1.4.8
Fix for Maw And Claw (Claw) natural weapons vanishing - replacing with toggle as game likes to do
Added Ancestral Scorn feat

### 1.4.7
Burst Of Radiance has been returned to spell lists from the Shadow Realm?
Price Fixes for some horribly overpriced act 1 items - expect further changes here
Option to replace Dragonkind 1: Red with Chains Of Fire for Oracle Flames Mystery as proxy for Fire Seeds
Fixed Owlcat's silly implementation of Bracer's of Armor so various unique bracers don't forget to help vs incorporeal.


### 1.4.6
Disabling spells works again.
If Expanded Content is installed and Gloomblind Bolts is disabled, Death Patron will use the Expanded Content version of Gloomblind Bolts



### 1.4.5
Cross mod compat patch for Thiefling from Homebrew Archetypes - spreading mod rogue talents around
Fix for the mod asploding if TTT-Base is not installed



### 1.4.4
Fix for accidentally blocking then new patron selections

### 1.4.3
Added Tiefling Alternate Racial Abilities

Scaled Skin - trade energy resist for natural armor

Maw And Claw - trade SLA for bite or claw attack

Armor Of The Pit - tiefling racial feat. +2 natural armor without Scaled Skin, +1 and regain missing energy resists with

Fix for setting Ember's default patron to Light breaking the mod.

Fix for Winter Witch not progressing non-winter patrons acquired via second patron.

Fixed Burst Of Radiance not doing damage.

Fixed Bloodrager Elemental Strikes doing an extra hit


### 1.4.2
Emergency hotfix to catch Burn Resistance being backwards

### 1.4.1
Added Homebrew Rage Power: Rage Stance Mastery. Use two Barbarian stances at once.

Add Burst Of Radiance

Fixed Death Patron being missing from Second Patron

Added Light, Animal, Protection and Plague patrons

Added Light to default patron selection list for Ember

Made Witch Patron spell features use the spell icon.

### 1.4.0

Switched to building UI with ModMenu

Added Coordinated Strike, Lastwall Phalanx and Swarm Strike teamwork feats.

Improved prerequisite for handling in several places

Patch for Phoenix Bloodline / Metamagic Rager compatibility

Elemental Stance barbarian rage power

### 1.3.6

Eldritch Scion (Sage) learns bloodline spells!

### 1.3.5

Added Eldritch Scion (Sage) - it's just the Sage Bloodline / Sage Wildblood version of the Arcane Bloodline applied to Eldritch Scion. Warning: Odd thingss may happen when crossclassing with sorc. Fixes/enforcing sage/sage awaiting Tabletop Tweaks Base updates.

Owlcat Eldritch Scion Magus was adding and removing the Arcane Weapon upgrades, creating some UI weirdness and possibly (not sure) causing issues with the multiple archetypes mod. Fixed this

Improved Readme Formatting

Dragonheir Scion gets Arcane Strike scaling now

### 1.3.4
Phoenix Bloodline for Bloodrager

--Difference from tabletop, damage aura from level 20 power is save for half, rather than save for none

--Soft dependency on Tabletop Tweaks Base's Bloodline Fixes for this component because I could not be bothered to write Owlcat bloodline logic then convert it to use Vek's if that's installed

Clockwork Heart wild talent



### 1.3.3

Patch for Mythic Kinetic Aegis not actually scaling with rank

Removed Mythic Kinetic Aegis support for Expanded Elements Force Ward until I figure out what is supposed to be happening with that talent - sorry!

### 1.3.2

Emergency fix for GUID issue

### 1.3.1

Added Kineticist Internal Buffer class feature

Added Burn Resistance, Extra Burn, Extended Buffer feats

Added Mythic Kinetic Aegis mythic ability

Added Shimmering Mirage wild talent

Added Flame Shield wild talent's cold damage halving effect

Hooked Kineticist Elemental Defense talents into the rest of the burn mechanics

### 1.3.0

Upgraded to EE

Removed redundant fixes to the Angel Path Artifact cloak (they still haven't fixed the weapon damage portion)

Made Prodigious TWF alter requirements for Two Weapon Defense from Tabletop Tweaks Base

Added Dispelling Bombs to the Dispel IFF Fix

### 1.2.7

Added Death Witch Patron

Fixed Feature-version of the vanilla Good reward from Dawn Of Dragons not working

Reworked to bundle all files into one .dll

### 1.2.6

Fix freezing sphere not doing damage

### 1.2.5

Fix for discordant song UI errors

### 1.2.4

Actually fixed the Prodigious TWF penalty-reduction.

In unlimited-use mode Dragon and Abyssal bloodlines claws stay on after rest.


### 1.2.3

Fixed Prodigious TWF penalty-reduction being active when it shouldn't be.

Fixed Angel Cloak Artifact.

### 1.2.2

Claws should stay active after combat if infinite-uses is active

Improved Tabletop Tweaks Base detection

### 1.2.1

Fixed bug with Oracle not being able to learn Bone Fists

### 1.2.0

Requires Tabletop Tweaks Core Module

Added Infinite-use sorc bloodline claw powers

Added merged sorc draconic bloodline claw powers

Added Ability Focus: Breath Weapon

Added option to give Stigmatized Witch patron back, and options for Ember's default patron

Purifier unique revelation Celestial Armor now behaves exactly as Armor Training including Advanced Armor Training access (Requires Tabletop Tweaks Base Module and Advanced Armor Training to be enabled)

Discordant Song should now work with Martyr and Sensei

### 1.1.1

Fixed Mercy: Injured always applying

Fixed Chains Of Fire doing all hits on primary target.


1.1
Updated for v1.2 beta
Added Arcanist Holy Water Jet fix
Added Monster Slayers and Local Production Crusade Event Modifications


## New Content
---
### Spells
---
Bone Fists: Level 2 Bloodrager/Cleric/Druid/Shaman/Hunter/Ranger/Wizard/Witch. 1/minute per level party buff giving +1 natural armor (form-type) and +2 damage to natural weapons.

Chains Of Fire: Level 6  Wizard/Magus evocation. Is literally just Chain Lightning but dealing fire damage.

Fire Shield: Level 4 Alchemist/Bloodrager/Magus/Wizard/ Sun Domain, Level 5 Fire Domain. Pick between Warm and Cold shield. Warm shield cuts incoming cold damage in half, reduces to none on successful save, and retaliates with fire damage when hit in melee. Cold Shield works the same but protecting from fire and retaliating with cold.
Existing domain picks were not removed - Sun 4 / Fire 5 have two picks. 1 round per level.
Changes From Tabletop: Damage cancel on successful save works on all saves not reflex. Will patch this one later, if I can figure out how

Vitrolic Mist: Level 4 Alchemist/Bloodrager/Magus/Wizard: Fire Sheild, only the protection and backlash are both acid.
Changes From Tabletop: Damage cancel on successful save works on all saves not reflex. Will patch this one later.

Entropic Shield: Cleric 1 self-buff. Incoming ranged attacks have 20% miss chance, non-illusion. 1 minute per level.

Freezing Sphere: Wizard/Magus 6 evocation. 1d6/level cold damage to a spherical area, increased damage to water subtype.

Changes From Tabletop: Damage cap is 20d6 instead of 15d6 to make vaguely relevant at the same level as chain lightning/chains of fire (effectively have selective baked in), Hellfire Ray (massively more damage and defenses against it are rarer) and Cold Ice Strike (natively quickened). Available in both tabletop 40ft blast and fireball standard 20ft blast - again, to make relevant when other on-level spells have much better form factor than nuking almost everything you can see.

Gloomblind bolts: Level 3 Bloodrager/Magus/Witch/Wizard necromancy. Scorching ray, only dealing negative energy damage and blinding if the target doesn't save. 

Changes From Tabletop: Was Conjuration (creation)[shadow] on TT but that makes about zero kinds of sense so I changed it to necromancy.

Heal Mount: Level 3 Paladin. Is literally heal but you can only cast it on your animal companion. At last something to do with Paladin level 3 spell slots!

Keen Edge: Level 3 Bloodrager/Magus/Inquistor/Wizard. Gives a weapon Keen for 10 minutes per level.

Spear Of Purity: Level 2 Cleric / Angel: Range touch attack, deals 1d8 per 2 levels (max 5d8) to target - half to neutral, none to good, unless target is evil outsider in which case 1d6 per level (max 10d6). Half damage on will save. Evil targets are blinded on save fail.

Telekinetic Strikes: Level 2 Magus/Wizard buff: Target ally deals 1d4 extra force damage on natural weapon hits, 1 minute per level

### Feats:
---
Ability Focus- Breath Weapon: Adds +2 DC to breath weapons. Requires a breath weapon to take (or mixblooded bloodrager). This prereq uses significant hardcoding to detect polymorphs granting breath attacks and hasn't been fully tested.

Burn Resistance: Treat your level as two lower for determining nonlethal damage from burn

Discordant Song: Bardsong adds 1d6 sonic damage to ally weapon attacks. For ranged attacks, targets must also be in the area of effect.

Extra Burn: Increases daily burn limit by two points

Extended Buffer: Increases internal buffer size by one

Prodigious TWF: Use strength rather than dex for TWF prereqs, no penalty for large offhand weapon.

Sundering Strike: On critical hit, attempt Sunder maneuver.

### Paladin Mercies:
---
Injured: Grants fast healing for 1 round per 2 paladin levels.

Ensorcelled: Attempts Dispel Magic on lay on hands - does not ever dispel buffs on friendlies.
(Arguable) Changes from Tabletop: Unlike other mercies this effect makes sense when used offensively so it works when used on enemies - it dispels buffs there.

### Items:
---
Bracers Of The Merciful Knight: Available for purchase from Arsinoe, these increase a paladin's effective level for Lay On Hands power and uses by four. 

Bracers Of The Avenging Knight: Available for purchase from Arsinoe, these increase the wearer's effective level when using Smite abilities by four.

### Mythic Abilities:
Mythic Kinetic Aegis: Treat Kineticist Elemental Defense as having had 1 burn invested for free, one more at MR 3/6/9.

## Bugfixes
---
### Items
---
Radiance +6 (uncorrupted) now gets Holy like it should

### Classes
Arcanist: Holy Water Jet no longer requires Azata/Angel mythic class

Cavalier: Made Order abilities actually show up in the UI. 

Made Order Of The Stars's Calling Channeling support ability work. 
Changes from Tabletop: Works on anything with a Channel Positive / Channel Negative keyword set, which means it will work on Warpriest and Oracle and Necromancer channels. No idea if it works on Warpriest fervor used normally.

Kineticist: Now has the Internal Buffer feature - reduce accepted burn by one a limited number of times per day

### Archetypes
---
Purifier: Gets back level 3 revelation - TT purifier has forced unique pick, said ability is not implemented and probably not implementable so giving the pick back.

### Bloodlines

Blooderager Phoenix Bloodline is in.
Tabletop Tweaks Base is required.

### Wild Talents:

Elemental Defenses and Aerial Evasion now use the main burn cost system - this is *not* disableable

Flame Shield correctly halves incoming frost damage

### Other
---
Fixed extra hits: Fixed some (not all) cases where an effect that should add extra damage to an attack added extra hits instead. Currently: Firebrand, Claws Of A Sacred Beast, and the chibi dragon from Dawn Of Dragons
ONLY USE ONE OF TABLETOP TWEAKS's FIX AND MINE! The game won't load if you have both active!

Note: Custom Implementation used on Claws of a Sacred Beast to preserve DR peirce properties from weapon attack isn't getting the damage type completely right - is doing all phys types instead of just slashing. 

## Tweaks
---
Little things that aren't new content but aren't bug fixes either:
### Spells
---
Dispels are now buff/debuff safe - dispel magic series and slayer Dispelling Attack don't dispel buffs on user's allies or debuffs on their enemies. 

### Reward Feature Conversion
---
Dawn Of Dragons gave you a perma Holy Aura effect for one resolution but this was implemented as a perma-buff meaning it wouldn't persist on respec and might be losable other ways. I turned this into a feature - see modified content for more.

### Crusade
---
Movanic Devas now use greatswords properly

### Archetypes
---
Purifers now get Cure Light / Cure Moderate automatically - the archetype takes till level five to not be Oracle But Worse In Literally Every Way otherwise.

Purifier Celestial Armor now works exactly like Armor Training of a fighter with 4 less fighter levels - including Advanced Armor Training. This hard-requires Tabletop Tweaks Base and will not activate if it can't detect that.

Stigmatized Witch gets Patron selection back - I consider switching from prepared to spontaneous a side-grade at best, with Witch's weak spell list downgrading patron to curse at the same time was just a nerfing. Comes with options to select Ember's patron. Disabled by default.

### Bloodline Powers
Unlimited Sorcerer Bloodline Claws: Removes use limit on abyssal/draconic bloodline claws. 
Combine Sorcerer Dragon Claws: Unifies all sorc bloodline claw abilities into one - if you have multiple bloodlines you get the lvl 11 energy damage for every last one.

## Content Modifications
---
Not-so-little changes I've made to base game things. These all default to off.
These have nothing to do with the tabletop game - my changes to Owlcat Original Content.

### Dawn Of Dragons Custom Reward
---
The reward for picking the good option in this quest is almost insultingly bad. A vendor trash item and a perma-buff of a spell you almost certainly already have on most paths and that Angel gets a strictly better version of automatically.

This annoyed me so I changed it.

If you enable the Custom Reward, instead of giving you a perma holy aura buff the silver dragon gives you what's more or less perma-sorta-geniekind with this setting enabled. 1d6 cold on attacks (not an extra hit just damage, it's like having Elder Frost on everything) and +5 natural armor enhancement. Overall weaker effect but one that's much less likely to overlapped. Can set to be Angel only or for all paths with settings.

### Crusade Events
---
Made rewards from Monster Slayers and Local Production crusade events permanent if options are selected because it makes more sense.


##Coming Soon:

Bloodline Mutations (Havoc first)

Some Crusade Mode goodies

Earth Tremor spell

Mountain Witch Patron

Witch Unique Patrons

Seasonal Witch archetype

Banishing Warden Paladin Archetype

Something for characters who get wings from multiple sources (bloodlines, mythic paths)

Goodies for Aivu

Overhaul Discordant Song and Hat Of Heartening Song to work through the auras directly, not their own buffs, so range modification effects them

Phoenix Sorcerer Bloodline? Maybe?


