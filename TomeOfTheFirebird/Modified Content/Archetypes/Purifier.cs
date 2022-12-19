using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using System.Linq;
using TabletopTweaks.Core.Utilities;
using UnityModManagerNet;

namespace TomeOfTheFirebird.Modified_Content.Archetypes
{
    class Purifier
    {

        public static void PatchPurifier()
        {
            BlueprintArchetype PuriferArchetype = BlueprintTools.GetBlueprint<BlueprintArchetype>("c9df67160a77ecd4a97928f2455545d7");




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


                BlueprintFeature earlycure = BlueprintTool.Get<BlueprintFeature>("PurifierLimitedCures");

              
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
                if (UnityModManager.FindMod("TabletopTweaks-Base") == null)
                    return;
                BlueprintFeatureSelection ArmorTrainingSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("354f1a4426d24ea38718905108f48e72");
                if (ArmorTrainingSelection == null)
                {
                    Main.TotFContext.Logger.Log($"Couldn't find ArmorTrainingSelection, aborting Celestial Armor Training");
                    return;
                }
                BlueprintFeatureSelection FighterFeatSelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("41c8486641f7d6d4283ca9dae4147a9f");
                BlueprintFeatureSelection ArmorTraining = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("c1e7a208b5a544f58071af88a61ab842");
                if (!FighterFeatSelection.AllFeatures.Any(x=>x.AssetGuidThreadSafe == ArmorTraining.AssetGuidThreadSafe))
                {
                    Main.TotFContext.Logger.Log($"Couldn't find AdvancedArmorTraining1 in Fighter Feat selection, aborting Celestial Armor Training");
                    return;
                }
                //if (fighter.Progression.LevelEntries.Any(x=>x.))
                BlueprintArchetype PuriferArchetype = BlueprintTools.GetBlueprint<BlueprintArchetype>("c9df67160a77ecd4a97928f2455545d7");
                BlueprintFeatureBaseReference CelestialArmor = BlueprintTools.GetBlueprint<BlueprintFeature>("7dc8d7dede2704640956f7bc4102760a").ToReference<BlueprintFeatureBaseReference>();

                BlueprintProgression NeoCelestialArmor = BlueprintTool.Get<BlueprintProgression>("CelestialArmorProgression");
                foreach(LevelEntry v in PuriferArchetype.AddFeatures)
                {
                    v.m_Features.RemoveAll(x => x.deserializedGuid == CelestialArmor.deserializedGuid);
                }
                PuriferArchetype.AddFeatures.FirstOrDefault(x => x.Level == 7)?.m_Features.Add(NeoCelestialArmor.ToReference<BlueprintFeatureBaseReference>());
                Main.TotFContext.Logger.LogPatch("Deployed new version:", NeoCelestialArmor);
            }

        }


    }
}
