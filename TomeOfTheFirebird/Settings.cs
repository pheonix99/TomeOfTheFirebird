using BlueprintCore.Utils;
using Kingmaker.Localization;
using Kingmaker.UI.SettingsUI;
using ModMenu.Settings;
using System;
using System.Linq;
using UnityModManagerNet;
using Menu = ModMenu.ModMenu;

namespace TomeOfTheFirebird
{
    class Settings
    {
        

        private const string RootKey = "totf.settings";
        private static readonly string RootStringKey = "TotF.Settings";

        private static string GetKey(string partialKey)
        {
            return ($"{RootKey}.{partialKey}").ToLower();
        }

        internal static bool IsEnabled(string key)
        {
            return Menu.GetSettingValue<bool>(GetKey(key.ToLower()));
        }

        internal static T GetDD <T>(string key) where T : Enum
        {
            return Menu.GetSettingValue<T>(GetKey(key));
        }

        internal static bool IsDisabled(string key)
        {
            return !IsEnabled(key);
        }

        internal static bool IsTTTBaseEnabled()
        {
            return UnityModManager.modEntries.Where(
                mod => mod.Info.Id.Equals("TabletopTweaks-Base") && mod.Enabled && !mod.ErrorOnLoading)
              .Any();
        }

        
        public static void Make()
        {
            LocalizationTool.LoadLocalizationPack("Mods\\TomeOfTheFirebird\\Localization\\Settings.json");
            var builder = SettingsBuilder.New(RootKey, LocalizationTool.CreateString(RootKey + ".Title", "Tome Of The Firebird", false));
         
            builder.AddDefaultButton(OnDefaultsApplied);



            builder.AddSubHeader(GetString("Archetypes.Title"), startExpanded: true);
            builder.AddToggle(MakeToggle("eldritchscionsage", "Eldritch Scion (Sage)", true, "Adds Eldritch Scion version of Sage Sorc"));

            builder.AddSubHeader(GetString("ClassFeatures.Title"), startExpanded: true);
            builder.AddToggle(MakeToggle("MercyEnsorcelled", "Mercy: Ensorcelled", true, "Attempt to dispel hostile effects on the target while healing with lay on hands, or dispel buffs while using Lay on Hands offensively."));
            builder.AddToggle(MakeToggle("MercyInjured", "Mercy: Injured", true, "Grant target fast healing 3 for one round per two paladin levels."));
            builder.AddToggle(MakeToggle("internalbuffer", "Kineticist: Internal Buffer", true, "Restores Kineticist Internal Buffer Class Feature"));
            builder.AddToggle(MakeToggle("phoenixbloodline", "Phoenix Bloodline", true, "Adds Phoenix Bloodline (Bloodrager Only)"));
            builder.AddToggle(MakeToggle("RagePowerElementalStance", "Rage Power: Elemental Stance", true, "Adds barbarian rage power elemental stance to the game. Increasess low-level damage from TT to get closer to balance with damage stances"));
            builder.AddToggle(MakeToggle("witchpatrondeath", "Witch Patron: Death", true, "Adds the Death witch patron, focusing on necromantic attack spells. Some deviation from tabletop to account for unimplmentable (speak with dead, rest eternal), unimplemented (suffocate, symbol of death) and just plain bad (power word kill) TT spells. Requires Gloomblind Bolts to be enabled."));
            builder.AddToggle(MakeToggle("witchpatronl2replace", "Death Patron: Replace Blessing Of Courage And Life", true, "Replaces TT Death level 2 : Blessing Of Courage and Life with Boneshaker to go all in on necromantic attack"));


            builder.AddSubHeader(GetString("Feats.Title"), startExpanded: true);
            builder.AddToggle(MakeToggle("AbilityFocusBreathWeapons", "Ability Focus Breath Weapons", true, "Increases DC of breath weapon attacks by 2"));
            builder.AddToggle(MakeToggle("BurnResistance", "Burn Resistance", true, "Treat character level as two lower when calculating nonlethal damage from burn"));
            builder.AddToggle(MakeToggle("CoordinatedShot", "Coordinated Shot", true, "Teamwork Feat: +1 to hit if ally engaging target of ranged attack has feat, another if target is flanked by allies"));
            builder.AddToggle(MakeToggle("discordantsong", "Discordant Song", true, "Bard Song adds 1d6 sonic damage rider"));
           
            builder.AddToggle(MakeToggle("ExtraBurn", "Extra Burn", true, "Increase max burn by two"));
            builder.AddToggle(MakeToggle("ExtendedBuffer", "Extended Buffer", true, "Increase internal buffer size by one"));
            builder.AddToggle(MakeToggle("LastwallPhalanx", "Lastwall Phalanx", true, "Teamwork Feat: Sacred bonus to AC and saves vs evil when adjacent to allies with feat."));

            builder.AddToggle(MakeToggle("ProdigiousTWF", "Prodigious Two Weapon Fighting", true, "Use Strength For TWF Prerequisites, Ignore Heavy Offhand Weapon Penalty"));
            builder.AddToggle(MakeToggle("SunderingStrike", "Sundering Strike", true, "Perform Sunder Armor on critical hit"));
            builder.AddToggle(MakeToggle("SwarmStrike", "Swarm Strike", true, "Teamwork Feat: +1 to hit on AoO, +1 per flanking ally with feat"));


            builder.AddSubHeader(GetString("Fixes.Title"), startExpanded: true);

            builder.AddToggle(MakeToggle("FixHolyWaterJet", "Arcanist: Fix Holy Water Jet", true, "Holy Water Jet has correct prereqs - no more mythic path requirement"));

            builder.AddToggle(MakeToggle("FixAngelArtifactCloak", "Bound Of Possibility: Fix Angel Version", true, "The Angel version of Bound Of Possibility now properly applies to weapon attacks - they partially fixed in EE"));
            builder.AddToggle(MakeToggle("FixBloodragerSpellIcons", "Bloodrager: Fix Bloodline SpellIcons", true, "Gives Bloodline Spell features the icon of the spell."));

            builder.AddToggle(MakeToggle("FixExtraHitsFirebrand", "Fix Extra Hits: Firebrand", true, "Firebrand now adds a 1d6 fire rider to all attacks, rather than a 1d6 fire extra hit."));

            builder.AddToggle(MakeToggle("FixExtraHitsSmallDragon", "Fix Extra Hits: Small Dragon", true, "The adorable little dragon from Dawn Of Dragons now gives his random extra damage as part of the attack, not as an extra hit."));
            builder.AddToggle(MakeToggle("FixExtraHitsClawsOfASacredBeast", "Fix Extra Hits: Claws Of A Sacred Beast", true, "Claws Of A Sacred Beast no longer gives an extra hit, now simply adds the correct slash damage."));

          
            builder.AddToggle(MakeToggle("CleanupEldritchScion", "Eldritch Scion: Cleanup Progression", true, "Dynamically kills weird add / remove of Arcane Weapon upgrades on Eldritch Scion"));
            
            builder.AddToggle(MakeToggle("FixRadianceFinalForm", "Radiance: Fix Final (Holy) Form", true, "The good version of Radiance's final form now properly retains its holy effect"));

            

            builder.AddToggle(MakeToggle("FixOrderOfTheStarCallingChannelingSupport", "Order Of The Star: Add Calling Channeling Support", true, "Order Of The Stars is supposed to grant half class level to Paladin and Cleric channeling progression. It didn't. Now it does."));

            builder.AddToggle(MakeToggle("FixFlameShield", "Flame Shield Wild Talent: Cold Protection", true, "Flame Shield wild talent correctly halves incoming cold damage."));

            builder.AddSubHeader(GetString("Items.Title"), startExpanded: true);
            builder.AddToggle(MakeToggle("BracersOfTheMercifulKnight", "Bracers Of The Merciful Knight", true, "Adds a set of magic bracers that improve Paladin Lay On Hands to Arsinoe's stock. Uncaps Lay On Hands healing as a side effect. I do not know what will happen if you disable this mid-game."));
            builder.AddToggle(MakeToggle("BracersOfTheAvengingKnight", "Bracers Of The Merciful Knight", true, "Adds a set of magic bracers that improve Paladin Smite Evil to Arsinoe's stock. I do not know what will happen if you disable this mid-game."));


            builder.AddSubHeader(GetString("MythicAbilities.Title"), startExpanded: true);
            builder.AddToggle(MakeToggle("MythicKineticAegis", "Mythic Kinetic Aegis", true, "(Homebrew) Improves Kineticist Elemental Defenses with Mythic Rank."));
            builder.AddSubHeader(GetString("Spells.Title"), startExpanded: true);
            builder.AddToggle(MakeToggle("BoneFists", "Bone Fists", true, "Level 2 spell for many classes, gives +1 natural armor (form-type) and +2 natural weapons damage to group."));
            builder.AddToggle(MakeToggle("ChainsOfFire", "Chains Of Fire", true, "A fire damage knockoff of chain lightning."));
            builder.AddToggle(MakeToggle("EntropicShield", "Entropic Shield", true, "Level 1 Cleric/Oracle spell, gives 20% miss chance to incoming ranged attacks"));
            builder.AddToggle(MakeToggle("FireShield", "Fire Shield", true, "Resist Fire/Cold, deal backlash damage of other element."));
            builder.AddToggle(MakeToggle("FreezingSphere", "Freezing Sphere", true, "Level 6 ice spherical AoE attack, has normal and supersized blast modes"));
            builder.AddToggle(MakeToggle("GloomblindBolts", "Gloomblind Bolts", true, "Basically Negative Energy Scorching Ray with a very short duration blind rider. Made it Necromancy unlike TT because it doesn't use Illusion mechanics"));
            builder.AddToggle(MakeToggle("KeenEdge", "Keen Edge", true, "Make your weapons Keen for a while"));
            builder.AddToggle(MakeToggle("HealMount", "Heal Mount", true, "Cast Heal on mount only. Paladin Level 3"));
            builder.AddToggle(MakeToggle("SpearOfPurity", "Spear Of Purity", true, "Arrow Of Law, only [Good] rather than [Lawful]. Level 2 divine ray spell."));
            
            builder.AddToggle(MakeToggle("TelekineticStrikes", "Telekinetic Strikes", true, "Add 1d4 force damage rider to natural weapons"));
            builder.AddToggle(MakeToggle("VitrolicMist", "Vitrolic Mist", true, "Fire Shield, but for acid damage"));
            

            builder.AddSubHeader(GetString("WildTalents.Title"), startExpanded: true);
            builder.AddToggle(MakeToggle("ClockworkHeart", "Clockwork Heart", true, "Passive Earth Wild Talent. Requires Metal Blast (earth + earth), grants Improved Initiative and Lightning Reflexes"));
            builder.AddToggle(MakeToggle("ShimmeringMirage", "Shimmering Mirage", true, "Water Wild Talent. Requires Shroud Of Water. Adds 20 percent miss chance as long as shroud of water is up."));

            builder.AddSubHeader(GetString("Tweaks.Title"), startExpanded: true);
            builder.AddToggle(MakeToggle("DragonheirScionArcaneStrikeScaling", "Dragonheir Scion: Arcane Strike Scaling", true, "Arcane Strike scales with DHS plus Dragon Disciple level if that's better than max caster level"));
            builder.AddToggle(MakeToggle("UnlimitedSorcererBloodlineClaws", "Bloodlines: Unlimited Sorcerer Bloodline Claws", true, "Abyssal and Draconic sorcerer bloodline power claws no longer have a use limit."));
            builder.AddToggle(MakeToggle("CombineSorcererDragonClaws", "Bloodlines: Combine Sorcerer Dragon Claws", true, "Combine all sorcerer dragon bloodline claw powers into the same ability, stacking elemental damage from each bloodline."));
               builder.AddToggle(MakeToggle("DispelsAreBuffSafe", "Dispels Are Buff Safe", true, "Dispel Magic, Greater Dispel Magic, Alchemist Dispelling Bombs and Slayer Dispelling Attacks should no longer dispel buffs on the casters allies or debuffs on enemies."));
            builder.AddToggle(MakeToggle("PurifierRestoreEarlyCures", "Purifier: Restore Early Cures", true, "Owlcat Purifier loses its cure spells but gains absolutely nothing relative to stock oracle before level 5. This setting restores CLW/CMW access."));
            builder.AddToggle(MakeToggle("PurifierLevelThreeRevelation", "Purifier: Restore Level Three Revelation", true, "Restores Purifier Level 3 relevation - TT forced pick was not implemented and is unimplementable so pick should be available."));
            builder.AddToggle(MakeToggle("PurifierCelestialArmorTraining", "Purifier: Enhance Celestial Armor Training", true, "Purifier's Celestial Armor unique revelation now grants advanced armor training access. Note: Absolutely Requires Tabletop Tweaks Base."));
            builder.AddToggle(MakeToggle("WitchRestoreStigmatizedPatron", "Stigmatized Witch: Restore Patron", true, "Moves stigmatized somewhat out of the suck by cancelling the patron removal. By default, this will give Ember the Endurance Patron when first met"));
            builder.AddDropdown<EmberPatron>(MakeDropdown<EmberPatron>("WitchEmberPatron", "Stigmatized Witch: Select Ember's Patron", EmberPatron.Endurance, UnityEngine.ScriptableObject.CreateInstance<EmberUnityEnumEnum>()));

            builder.AddToggle(MakeToggle("DawnOfDragonsRewardFeatureConversion", "Dawn Of Dragons: Convert Reward To Feature", true, "Converts the Holy Aura you get from siding with the silver dragon in Dawn Of Dragons to a feature from a permabuff to make it harder to lose and clear what is up."));
            builder.AddDropdown<DawnOfDragonsCustomReward>(MakeDropdown<DawnOfDragonsCustomReward>("DawnOfDragonsCustomReward", "Dawn Of Dragons: Custom Reward Selector", DawnOfDragonsCustomReward.Everyone, UnityEngine.ScriptableObject.CreateInstance<DawnOfDragonsCustomRewardEnum>(), "The custom reward replaces the often redundant perma-Holy-Aura effect with a more thematic perk - bit of cold weapon damage, natural armor and cold resist. Perks are comparable to the level 5 Geniekind as opposed to the level 8 Holy Aura. Requires the above setting to be active."));


            builder.AddSubHeader(GetString("Crusade.Title"), startExpanded: true);
            builder.AddToggle(MakeToggle("MovanicDevasWeaponFix", "Movanic Devas Use Correct Weapon", true, "Fixes Movanic Devas to greatswords as per TT rather than longswords wielded in both hands, making their damage quite a bit less bad."));
            builder.AddToggle(MakeToggle("CrusadeMonsterSlayers", "Permanent Upgrade: Ready For Anything", true, "Makes Ready For Anything training decree from one outcome of Crusade Event 54: Monster Slayers permanent rather than a one off 60-day buff."));
            builder.AddToggle(MakeToggle("CrusadeLocalProduction", "Permanent Upgrade: LocalProduction", true, "Makes Ready For Anything training decree from one outcome of Crusade Event 54: Monster Slayers permanent rather than a one off 60-day buff."));
            ModMenu.ModMenu.AddSettings(builder);
        }

        private static Dropdown<T> MakeDropdown<T>(string keyStub, string name, T defaultVal, UISettingsEntityDropdownEnum<T> dd, string desc = null) where T : Enum
        {

            var dropper = new Dropdown<T>(GetKey(keyStub), defaultVal, LocalizationTool.CreateString($"{RootStringKey}.{keyStub}", name), dd);
            if (desc != null)
                dropper.WithLongDescription(LocalizationTool.CreateString($"{RootStringKey}.{keyStub}.Desc|", name));
            return dropper;
        }

        private static Toggle MakeToggle(string keyStub, string name, bool defaultVal, string desc = null)
        {
         
            var toggle = new Toggle($"{RootKey}.{keyStub.ToLower()}", defaultVal, LocalizationTool.CreateString($"{RootStringKey}.{keyStub}", name));
            if (desc != null)
                toggle.WithLongDescription(LocalizationTool.CreateString($"{RootStringKey}.{keyStub}.Desc|", name));

            return toggle;
        }
       
        private static LocalizedString GetString(string key, bool usePrefix = true)
        {
            var fullKey = usePrefix ? $"{RootStringKey}.{key}" : key;
            return LocalizationTool.GetString(fullKey);
        }

        private static   void OnDefaultsApplied()
        {
            Main.TotFContext.Logger.Log("Defaults were applied!");
        }


        private static LocalizedString GetString(string key, string value, bool usePrefix = true)
        {
            var fullKey = usePrefix ? $"{RootStringKey}.{key}" : key;
            return LocalizationTool.CreateString(fullKey, value, false);
        }

        public enum EmberPatron
        {
            Elements,
            Healing,
            Endurance
        }
        // Declare a non-generic class which inherits from the generic type
        private class EmberUnityEnumEnum : UISettingsEntityDropdownEnum<EmberPatron>
        { }

        public enum DawnOfDragonsCustomReward
        {
            Everyone,
            Angel,
            Nobody
        }
        // Declare a non-generic class which inherits from the generic type
        private class DawnOfDragonsCustomRewardEnum : UISettingsEntityDropdownEnum<DawnOfDragonsCustomReward>
        { }
    }
}
