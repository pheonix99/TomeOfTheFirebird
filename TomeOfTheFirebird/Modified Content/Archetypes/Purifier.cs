using BlueprintCore.Utils;
using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.JsonSystem;
using System.Linq;
using TabletopTweaks.Core.Utilities;

namespace TomeOfTheFirebird.Modified_Content.Archetypes
{
    class Purifier
    {

        public static void PatchPurifier()
        {
            var PuriferArchetype = BlueprintTools.GetBlueprint<BlueprintArchetype>("c9df67160a77ecd4a97928f2455545d7");




            PatchLevel3Revelation();
            PatchRestoreCure();
            CelestialArmorTraining();
            void PatchLevel3Revelation()
            {

                if (Main.TotFContext.Bugfixes.Purifier.IsDisabled("LevelThreeRevelation")) { return; }

                //var PuriferArchetype = Resources.GetBlueprint<BlueprintArchetype>("c9df67160a77ecd4a97928f2455545d7");
                LevelEntry target = PuriferArchetype.RemoveFeatures.FirstOrDefault(x => x.Level == 3);
                if (target != null)
                {
                    PuriferArchetype.RemoveFeatures = PuriferArchetype.RemoveFeatures.RemoveFromArray(target);
                }

                Main.TotFContext.Logger.LogPatch("Patched", PuriferArchetype);
            }

            void PatchRestoreCure()
            {

                if (Main.TotFContext.Tweaks.Purifier.IsDisabled("RestoreEarlyCures")) { return; }

               
                var earlycure = BlueprintTool.Get<BlueprintFeature>("PurifierLimitedCures");

              
                    LevelEntry level1 = new LevelEntry
                    {
                        Level = 1,
                        m_Features = { earlycure.ToReference<BlueprintFeatureBaseReference>() }
                    };

                    
                    PuriferArchetype.AddFeatures = PuriferArchetype.AddFeatures.AppendToArray(level1);
                    
                
                
                if (PuriferArchetype.AddFeatures.FirstOrDefault(x=>x.Level == 1)?.Features.Any(x=>x.AssetGuidThreadSafe == earlycure.AssetGuidThreadSafe) == true)
                {
                    Main.TotFContext.Logger.Log("Found earlycures on purifier");
                }
                else
                {
                    Main.TotFContext.Logger.Log("Didn't find earlycures on purifier");
                }

                Main.TotFContext.Logger.LogPatch("Patched", earlycure);
            }

            void CelestialArmorTraining()
            {
                if (Main.TotFContext.Tweaks.Purifier.IsDisabled("CelestialArmorTraining"))
                    return;
                var ArmorTrainingSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(Main.TotFContext, "ArmorTrainingSelection");
                if (ArmorTrainingSelection == null)
                {
                    Main.TotFContext.Logger.Log($"Couldn't find ArmorTrainingSelection, aborting Celestial Armor Training");
                    return;
                }
                var FighterFeatSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("41c8486641f7d6d4283ca9dae4147a9f");
                var ArmorTraining = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(Main.TotFContext, "AdvancedArmorTraining1");
                if (!FighterFeatSelection.AllFeatures.Any(x=>x.AssetGuidThreadSafe == ArmorTraining.AssetGuidThreadSafe))
                {
                    Main.TotFContext.Logger.Log($"Couldn't find AdvancedArmorTraining1 in Fighter Feat selection, aborting Celestial Armor Training");
                    return;
                }
                //if (fighter.Progression.LevelEntries.Any(x=>x.))
                var PuriferArchetype = BlueprintTools.GetBlueprint<BlueprintArchetype>("c9df67160a77ecd4a97928f2455545d7");
                var CelestialArmor = BlueprintTools.GetBlueprint<BlueprintFeature>("7dc8d7dede2704640956f7bc4102760a").ToReference<BlueprintFeatureBaseReference>();

                var NeoCelestialArmor = BlueprintTool.Get<BlueprintProgression>("CelestialArmorProgression");
                foreach(var v in PuriferArchetype.AddFeatures)
                {
                    v.m_Features.RemoveAll(x => x.deserializedGuid == CelestialArmor.deserializedGuid);
                }
                PuriferArchetype.AddFeatures.FirstOrDefault(x => x.Level == 7)?.m_Features.Add(NeoCelestialArmor.ToReference<BlueprintFeatureBaseReference>());
                Main.TotFContext.Logger.LogPatch("Deployed new version:", NeoCelestialArmor);
            }

        }


    }
}
