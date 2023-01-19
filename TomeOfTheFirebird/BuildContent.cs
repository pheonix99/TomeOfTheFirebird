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

namespace TomeOfTheFirebird
{
    static class BuildContent
    {
        static BlueprintAbility gloomblind;



        static BlueprintAbility keenEdge;
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
                    Settings.Make();

                    Main.TotFContext.Logger.Log("Building new spells");


                    //Early class fixes

                    ArcanistFixes.DoFixes();

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

                    //Build Feats
                    ProdigiousTWF.AddProdigiousTWF();
                    SunderingStrike.Build();
                    DiscordantSong.Make();
                    BurnResistance.Make();
                    BreathWeaponFeats.BuildAbilityFocusBreathWeapons();
                    ExtraBurn.Make();
                    //New Mythics
                    MythicKineticDefenses.Make();

                    //Build Class Features

                    PurifierLimitedCures.AddPurifierLimitedCures();
                    FighterArmorTrainingFakeLevel.AddFighterArmorTrainingRank();
                    CelestialArmorRevelation.Make();
                    ExtraMercies.Build();
                    WitchPatrons.Make();
                    KineticistInternalBuffer.Make();

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
                   


                    EldritchScionSage.Make();

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







                    AddItemsToShop.Add();
                    Purifier.PatchPurifier();
                    Kineticist.PatchKineticist();

                    FixExtraHitsOnProcs.FixFirebrand();
                    FixExtraHitsOnProcs.FixRandomWeaponsRiders();
                    FixExtraHitsOnProcs.FixClawsOfSacredBeast();
                    FixExtraHitsOnProcs.FixElementalStrikes();


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

                    Main.TotFContext.TerminalWipe();
                }
                catch (Exception e)
                {

                    Main.TotFContext.Logger.LogError(e, $"Error caught in KineticistExpandedElements integration");
                }
                
                

            }

        }
    }
}
