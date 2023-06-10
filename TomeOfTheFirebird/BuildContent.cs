using HarmonyLib;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using TomeOfTheFirebird.Crusade;
using TomeOfTheFirebird.Bugfixes;
using TomeOfTheFirebird.Modified_Content.Bloodlines;
using TomeOfTheFirebird.Modified_Content.Crusade;
using TomeOfTheFirebird.New_Content.Feats;
using TomeOfTheFirebird.New_Content.Items;
using TomeOfTheFirebird.New_Content.Mercies;
using TomeOfTheFirebird.New_Content.Spells;
using TomeOfTheFirebird.New_Spells;
using TomeOfTheFirebird.NewContent.Features;
using TomeOfTheFirebird.QuestTweaks;
using TomeOfTheFirebird.Bugfixes.Classes;
using TomeOfTheFirebird.Modified_Content.Archetypes;
using TomeOfTheFirebird.New_Content.Features;
using TomeOfTheFirebird.Bugfixes.Items;
using System;
using TomeOfTheFirebird.New_Content;
using TomeOfTheFirebird.New_Content.MythicAbilities;
using TomeOfTheFirebird.Modified_Content.Classes;
using TomeOfTheFirebird.New_Content.Bloodlines;
using TomeOfTheFirebird.New_Content.WildTalents;
using TomeOfTheFirebird.Modified_Content.Feats;
using TomeOfTheFirebird.New_Content.Archetypes;
using BlueprintCore.Blueprints.Configurators.Root;
using Kingmaker.Blueprints;
using Kingmaker.Utility;
using Kingmaker.Blueprints.Classes;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes.Selection;
using System.Linq;
using UnityEngine;
using TomeOfTheFirebird.New_Components;
using TomeOfTheFirebird.New_Content.ModifySpellLists;

namespace TomeOfTheFirebird
{
    static class BuildContent
    {
        [HarmonyPatch(typeof(BlueprintsCache), "Init")]
        static class BlueprintsCache_Init_Patch
        {
            static bool Initialized;

            [HarmonyPriority(Priority.First)]
            static void Postfix()
            {
                try
                {
                    if (Initialized) return;
                    Initialized = true;
                    

                    LocalizationTool.LoadLocalizationPack("Mods\\TomeOfTheFirebird\\Localization\\Settings.json");
                    LocalizationTool.LoadLocalizationPack("Mods\\TomeOfTheFirebird\\Localization\\ClassesAndArchetypes.json");
                    //LocalizationTool.LoadLocalizationPack("Mods\\TomeOfTheFirebird\\Localization\\LocalizationPack.json");
                    LocalizationTool.LoadLocalizationPack("Mods\\TomeOfTheFirebird\\Localization\\Spells.json");
                    LocalizationTool.LoadLocalizationPack("Mods\\TomeOfTheFirebird\\Localization\\Bloodlines.json");
                    LocalizationTool.LoadLocalizationPack("Mods\\TomeOfTheFirebird\\Localization\\Feats.json");
                    LocalizationTool.LoadLocalizationPack("Mods\\TomeOfTheFirebird\\Localization\\Kineticist.json");
                    Settings.Make();
                    Main.TotFContext.Logger.Log("Building new spells");


                    //Early class fixes

                   

                    //build spells
                    ChainsOfFire.BuildSpell();

                    BoneFists.BuildSpell();
                    TelekineticStrikes.BuildSpell();
                    SpearOfPurity.BuildSpearOfPurity();
                    HealMount.Build();
                    KeenEdge.BuildSpell();
                    FreezingSphere.Build();
                    GloomblindBolts.BuildSpell();
                    ElementalShieldSpells.Build();
                    EntropicShield.Make();

                    BurstOfRadiance.Make();

                    Fly.Make();

                    //Build Feats
                    ProdigiousTWF.AddProdigiousTWF();
                    SunderingStrike.Build();
                    DiscordantSong.Make();
                    BurnResistance.Make();
                    BreathWeaponFeats.BuildAbilityFocusBreathWeapons();
                    ExtraBurn.Make();
                    AncestralScorn.Make();
                    TwinSpell.AddTwinSpell();
                    KineticLeap.Make();
                    AirsLeap.Make();
                    //New Mythics
                    MythicKineticDefenses.Make();

                    FixBracersOfArmor.Run();
                    PriceFixes.FixTabletopPrices();
                    PriceFixes.FixOwlcatPrices();


                    //Build Class Features

                    PurifierLimitedCures.AddPurifierLimitedCures();
                    FighterArmorTrainingFakeLevel.AddFighterArmorTrainingRank();
                    CelestialArmorRevelation.Make();
                    ExtraMercies.Build();
                    WitchPatrons.Make();
                    KineticistInternalBuffer.Make();
                    KineticistDoubleMetakinesis.Build();

                    //Goes after buffer because uses

                    ExtendedBuffer.Make();

                    //Fix class features
                    DraconicBloodlineModifications.SorcererClawsOverhaul();
                    AbyssalBloodlineModifications.GiveInfiniteUses();


                    //Crusade fixes and tweaks
                    MonavicsUseTwoHanders.Do();
                    CrusadeBuffTweaks.PermaMonsterSlayers();
                    CrusadeBuffTweaks.PermaLocalProduction();

                    //Quest Tweaks
                    DawnOfDragons.Fix();


                    //Loot fixes
                    RadianceLevel2Fix.Fixes();
                    AngelCloak.CloakFix();

                    //New Loot
                    PaladinGear.Build();



                    //FighterCombatBoosts.Setup();

                    PheonixBloodline.MakePheonixBloodline();
                    //BloodlineMutations.Setup();
                   


                    EldritchScionSage.Make();
                    //BloodHavoc.Make();

                    Modified_Content.Archetypes.Witch.ReturnAccursedPatrons();
                    Modified_Content.Classes.Witch.AllPatronFixes();

                    ShimmeringMirage.Make();
                    ClockworkHeart.Make();

                    New_Content.RagePowers.ElementalStance.Make();
                    New_Content.RagePowers.RageStanceMastery.Make();

                    CoordinatedShot.Make();
                    LastwallPhalanx.Make();
                    SwarmStrike.Make();
                    ArcaneStrike.AddDHSScaling();

                  

                    TomeOfTheFirebird.New_Content.RacialOptions.Tiefling.Make();
                    ArmorOfThePit.Make();
                    KineticLancer.Build();
                    
                }
                catch (Exception e)
                {
                    Main.TotFContext.Logger.LogError(e, $"Error caught in early patch");
                }
            }

             
           
        }


        [HarmonyPatch(typeof(BlueprintsCache), "Init")]
        static class BlueprintsCache_Init_Patch2
        {
            static bool Initialized;

            [HarmonyPriority(Priority.Last)]
            static void Postfix()
            {
                try
                {

                    if (Initialized) return;
                    Initialized = true;

                    Main.TotFContext.Logger.Log("Adding to spell lists");





                    CoreGameDeityModifications.Append();

                    AddItemsToShop.Add();
                    Purifier.PatchPurifier();
                    Kineticist.PatchKineticistLate();

                    FixExtraHitsOnProcs.FixFirebrand();
                    FixExtraHitsOnProcs.FixRandomWeaponsRiders();
                    FixExtraHitsOnProcs.FixClawsOfSacredBeast();
                    FixExtraHitsOnProcs.FixElementalStrikes();

                    ElementalStrikesUpgrade.Do();

                    CavalierFixes.FixOrderAbilityDisplays();
                    CavalierFixes.FixOrderOfTheStarChannelAssistance();
                    ExtraMercies.AddToThings();

                    FighterArmorTrainingFakeLevel.Connect();
                    

                    ProdigiousTWF.AddTwoWeaponDefense();
                    Magus.EScionSanityCheck();
                    EldritchScionSage.Link();
                    Bloodrager.FixIcons();
                    // MagusArcanaHandling.MergeEScion();

                    New_Content.RagePowers.ElementalStance.Finish();
                    New_Content.RagePowers.RageStanceMastery.Finish();
                    //EldritchScion.AddSorcBonusFeatsToList();
                  
                    TwinSpell.UpdateSpells();

                    RootConfigurator.ConfigureDelayedBlueprints();

                    

                    //Modified_Content.ImprovedMultiarchetypeProjct.SpellSlots.Execute();                    
                }
                catch (Exception e)
                {

                    Main.TotFContext.Logger.LogError(e, $"Error caught in Late patch");
                }
                try
                {
                    //TODO hack see how this impacts levelups
                    //FighterCombatBoosts.Patch();

                    //HomebrewArchetypesCompFix.ModifyVikingBonusFeats();
                }
                catch (Exception e)
                {
                    Main.TotFContext.Logger.LogError(e, $"Error caught in Fighter Combat Boosts");
                }
            }


           
        }

        [HarmonyPriority(Priority.Last)]
        [HarmonyPatch(typeof(StartGameLoader), "LoadAllJson")]
        
        static class StartGameLoader_LoadAllJson
        {
            private static bool Run = false;

            static void Postfix()
            {
                //This is for running compat with KineticistExpandedElements
                if (Run) return; Run = true;
                try
                {


                    MythicKineticDefenses.MakeLater();
                    Kineticist.FixKEEAbilities();

                    Kineticist.PatchKinecicistLast();

                    KineticLancer.FinalPass();
                }
                catch (Exception e)
                {

                    Main.TotFContext.Logger.LogError(e, $"Error caught in Kineticist Elements Expanded integration");
                }
                try
                {
                    KineticistDoubleMetakinesis.LoadBlasts();
                }
                catch(Exception e)
                {
                    Main.TotFContext.Logger.LogError(e, $"Error caught in Metakinesis (Double) patching");
                }
                try
                {
                    ThieflingInteroperability.AddOtherModRogueTalents();
                }
                catch (Exception e)
                {
                    Main.TotFContext.Logger.LogError(e, $"Error caught in HomebrewArchetypes integration");
                }
                try
                {
                    PriceFixes.FixPricesLate();
                   
                    Main.TotFContext.TerminalWipe();
                }
                catch (Exception e)
                {
                    Main.TotFContext.Logger.LogError(e, $"Error caught in super late patch");
                }
            }

        }
    }
}
