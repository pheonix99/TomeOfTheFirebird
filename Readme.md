# Tome Of The Firebird
---
A package of spells, feats, other abilities and some fixes.

And also some more random stuff I made when I got annoyed at the game.

All homebrew content or divergences from TT will be called out.

NOW REQUIRES TabletopTweaks Core Module!
##Changelog
1.2.5
Fix for discordant song UI errors

1.2.4
Actually fixed the Prodigious TWF penalty-reduction.
In unlimited-use mode Dragon and Abyssal bloodlines claws stay on after rest.

1.2.3
Fixed Prodigious TWF penalty-reduction being active when it shouldn't be.
Fixed Angel Cloak Artifact.

1.2.2
Claws should stay active after combat if infinite-uses is active
Improved Tabletop Tweaks Base detection

1.2.1
Fixed bug with Oracle not being able to learn Bone Fists

1.2.0
Requires Tabletop Tweaks Core Module
Added Infinite-use sorc bloodline claw powers
Added merged sorc draconic bloodline claw powers
Added Ability Focus: Breath Weapon
Added option to give Stigmatized Witch patron back, and options for Ember's default patron
Purifier unique revelation Celestial Armor now behaves exactly as Armor Training including Advanced Armor Training access (Requires Tabletop Tweaks Base Module and Advanced Armor Training to be enabled)
Discordant Song should now work with Martyr and Sensei

1.1.1
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
Changes From Tabletop: Damage cancel on successful save works on all saves not reflex. Will patch this one later.

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

Discordant Song: Bardsong adds 1d6 sonic damage to ally weapon attacks. For ranged attacks, targets must also be in the area of effect.

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


## Bugfixes
---
### Items
---
Radiance +6 (uncorrupted) now gets Holy like it should

### Classes
Cavalier: Made Order abilities actually show up in the UI. 

Made Order Of The Stars's Calling Channeling support ability work. 
Changes from Tabletop: Works on anything with a Channel Positive / Channel Negative keyword set, which means it will work on Warpriest and Oracle and Necromancer channels. No idea if it works on Warpriest fervor used normally.

Arcanist: Holy Water Jet no longer requires Azata/Angel mythic class

### Archetypes
---
Purifier: Gets back level 3 revelation - TT purifier has forced unique pick, said ability is not implemented and probably not implementable so giving the pick back.

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
Shield Other + Unwilling Shield
Draconic Bloodline Claw Merges for Bloodrager
More Breath Weapon Fun


