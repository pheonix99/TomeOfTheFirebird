using HarmonyLib;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using TabletopTweaks.Core.Utilities;
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
using UnityModManagerNet;

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
                    Main.TotFContext.Logger.Log("Building new spells");

                    


                    ArcanistFixes.DoFixes();
                    ChainsOfFire.BuildSpell();

                    BoneFists.BuildSpell();
                    TelekineticStrikes.BuildSpell();
                    SpearOfPurity.BuildSpearOfPurity();
                    HealMount.Build();
                    KeenEdge.BuildSPell();
                    FreezingSphere.Build();
                    GloomblindBolts.BuildSpell();
                    PurifierLimitedCures.AddPurifierLimitedCures();

                    FighterArmorTrainingFakeLevel.AddFighterArmorTrainingRank();

                    CelestialArmorRevelation.Make();


                    ElementalShieldSpells.Build();
                    ProdigiousTWF.AddProdigiousTWF();

                    MonavicsUseTwoHanders.Do();
                    CrusadeBuffTweaks.PermaMonsterSlayers();
                    CrusadeBuffTweaks.PermaLocalProduction();
                    DawnOfDragons.Fix();

                    RadianceLevel2Fix.Fixes();
                    AngelCloak.CloakFix();
                    PaladinGear.Build();
                    ExtraMercies.Build();

                    SunderingStrike.Build();
                    DiscordantSong.Make();
                    EntropicShield.Make();

                    DraconicBloodlineModifications.SorcererClawsOverhaul();
                    AbyssalBloodlineModifications.GiveInfiniteUses();
                    BreathWeaponFeats.BuildAbilityFocusBreathWeapons();
                    Witch.ReturnAccursedPatrons();


                    BlueprintFeature ActsBook = BlueprintTools.GetBlueprint<BlueprintFeature>("f16ea400ed67470b83cfd6c0dedbce6f");
                    if (ActsBook.Icon != null)
                    {
                        Main.TotFContext.Logger.Log($"Acts Of Iomedae reports Icon Name {ActsBook.Icon.name} ");

                    }
                    else
                    {
                        Main.TotFContext.Logger.Log($"Acts Of Iomedae Reports No Icon");
                    }
                    BoneFists.AddToLists();
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
                    FixExtraHitsOnProcs.FixFirebrand();
                    FixExtraHitsOnProcs.FixRandomWeaponsRiders();
                    FixExtraHitsOnProcs.FixClawsOfSacredBeast();


                    CavalierFixes.FixOrderAbilityDisplays();
                    CavalierFixes.FixOrderOfTheStarChannelAssistance();
                    ExtraMercies.AddToThings();

                    FighterArmorTrainingFakeLevel.Connect();
                }
                catch (Exception e)
                {
                    
                    Main.TotFContext.Logger.LogError(e, $"Error caught in Late patch");
                }
            }
        }


    }
}
