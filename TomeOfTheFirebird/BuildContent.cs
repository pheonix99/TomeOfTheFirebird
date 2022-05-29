using BlueprintCore.Blueprints.Configurators.Classes.Spells;
using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using System.Collections.Generic;
using System.Linq;
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
using TomeOfTheFirebird.Reference;
using TomeOfTheFirebird.Bugfixes.Classes;
using TomeOfTheFirebird.Modified_Content.Archetypes;
using TomeOfTheFirebird.New_Content.Features;

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
                if (Initialized) return;
                Initialized = true;
                Main.TotFContext.Logger.Log("Building new spells");
                
                 gloomblind = GloomblindBolts.BuildSpell();
               
                BoneFists.BuildSpell();
                TelekineticStrikes.BuildSpell();
                SpearOfPurity.BuildSpearOfPurity();

                ArcanistFixes.DoFixes();
                ChainsOfFire.BuildSpell();
                PurifierLimitedCures.AddPurifierLimitedCures();

                FighterArmorTrainingFakeLevel.AddFighterArmorTrainingRank();

                CelestialArmorRevelation.Make();


                ElementalShieldSpells.Build();
                ProdigiousTWF.AddProdigiousTWF();
                HealMount.Build();
                keenEdge = KeenEdge.BuildSPell();
                FreezingSphere.Build();
                MonavicsUseTwoHanders.Do();
                CrusadeBuffTweaks.PermaMonsterSlayers();
                CrusadeBuffTweaks.PermaLocalProduction();
                DawnOfDragons.Fix();
                
                RadianceLevel2Fix.Fixes();
                PaladinGear.Build();
                ExtraMercies.Build();
              
                SunderingStrike.Build();
                DiscordantSong.Make();
                EntropicShield.Make();

                DraconicBloodlineModifications.SorcererClawsOverhaul();
                AbyssalBloodlineModifications.GiveInfiniteUses();
                BreathWeaponFeats.BuildAbilityFocusBreathWeapons();

               

                BlueprintFeature ActsBook = BlueprintTools.GetBlueprint<BlueprintFeature>("f16ea400ed67470b83cfd6c0dedbce6f");
                if (ActsBook.Icon != null)
                {
                    Main.TotFContext.Logger.Log($"Acts Of Iomedae reports Icon Name {ActsBook.Icon.name} ");
                    
                }
                else
                {
                    Main.TotFContext.Logger.Log($"Acts Of Iomedae Reports No Icon");
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
                if (Initialized) return;
                Initialized = true;
          
                Main.TotFContext.Logger.Log("Adding to spell lists");

                if (Main.TotFContext.NewContent.Spells.IsEnabled("GloomblindBolts"))
                {
                    //TODO check bloodrager access
                    gloomblind.AddToSpellList(SpellTools.SpellList.BloodragerSpellList, 3);
                    gloomblind.AddToSpellList(SpellTools.SpellList.MagusSpellList, 3);
                    gloomblind.AddToSpellList(SpellTools.SpellList.WizardSpellList, 3);
                    gloomblind.AddToSpellList(SpellTools.SpellList.WitchSpellList, 3);
                }
                
               
                

                if (Main.TotFContext.NewContent.Spells.IsEnabled("KeenEdge"))
                {
                    keenEdge.AddToSpellList(SpellTools.SpellList.BloodragerSpellList, 3);
                    keenEdge.AddToSpellList(SpellTools.SpellList.InquisitorSpellList, 3);
                    keenEdge.AddToSpellList(SpellTools.SpellList.MagusSpellList, 3);
                    keenEdge.AddToSpellList(SpellTools.SpellList.WizardSpellList, 3);
                }
                AddItemsToShop.Add();
                Purifier.PatchPurifier();
                FixExtraHitsOnProcs.FixFirebrand();
                FixExtraHitsOnProcs.FixRandomWeaponsRiders();
                FixExtraHitsOnProcs.FixClawsOfSacredBeast();

                BoneFists.AddToLists();
                CavalierFixes.FixOrderAbilityDisplays();
                CavalierFixes.FixOrderOfTheStarChannelAssistance();
                ExtraMercies.AddToThings();

                FighterArmorTrainingFakeLevel.Connect();
               
            }
        }


    }
}
