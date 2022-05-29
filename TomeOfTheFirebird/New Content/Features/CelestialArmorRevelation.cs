using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTweaks.Core.Utilities;
using TomeOfTheFirebird.Helpers;

namespace TomeOfTheFirebird.New_Content.Features
{
    class CelestialArmorRevelation
    {
        public static void Make()
        {
            var CelestialArmor = BlueprintTools.GetBlueprint<BlueprintFeature>("7dc8d7dede2704640956f7bc4102760a");
            var ArmorTrainingScaling = BlueprintTool.Get<BlueprintFeature>("ArmorTrainingRank");
            var OracleClass = BlueprintTools.GetBlueprint<BlueprintCharacterClass>("20ce9bf8af32bee4c8557a045ab499b1");
            var ArmorTraining = BlueprintTools.GetBlueprint<BlueprintFeature>("3c380607706f209499d951b29d3c44f3");
            var ArmorTrainingSelection = BlueprintTools.GetModBlueprint<BlueprintFeatureSelection>(Main.TotFContext, "ArmorTrainingSelection");
            var ArmorTrainingSpeedFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(Main.TotFContext, "ArmorTrainingSpeedFeature");
            var HeavyArmor = BlueprintTools.GetBlueprint<BlueprintFeature>("1b0f68188dcc435429fb87a022239681").ToReference<BlueprintFeatureBaseReference>();
            var CelestialArmorProgressionMaker = MakerTools.MakeProg("CelestialArmorProgression", "Celestial Armor", "At 7th level, a purifier’s armor takes on a golden or silvery sheen and becomes light as a feather. She gains armor training as a fighter 4 levels lower than her oracle level. At 11th level, a purifier gains heavy armor proficiency.", ArmorTraining.Icon);
            CelestialArmorProgressionMaker.SetRanks(1);
            CelestialArmorProgressionMaker.SetIsClassFeature(true);
            CelestialArmorProgressionMaker.SetGiveFeaturesForPreviousLevels(true);
            CelestialArmorProgressionMaker.SetReapplyOnLevelUp(true);
            var entries = Enumerable.Range(4, 20).Select(i => new LevelEntry
            {
                Level = i,
                m_Features = new List<BlueprintFeatureBaseReference> {
                            ArmorTrainingScaling.ToReference<BlueprintFeatureBaseReference>()
                        },

            });
            entries.First(x => x.Level == 7).m_Features.Add(ArmorTraining.ToReference<BlueprintFeatureBaseReference>());
            if (ArmorTrainingSpeedFeature != null)
            {
                entries.First(x => x.Level == 7).m_Features.Add(ArmorTrainingSpeedFeature.ToReference<BlueprintFeatureBaseReference>());
                entries.First(x => x.Level == 11).m_Features.Add(ArmorTrainingSpeedFeature.ToReference<BlueprintFeatureBaseReference>());
            }
            else
            {
                Main.TotFContext.Logger.Log("Couldn't find ArmorTrainingSpeedFeature, Celestial Armor Will Not Have speed improvement");
            }
            entries.First(x => x.Level == 11).m_Features.Add(HeavyArmor);

            if (ArmorTrainingSelection != null)
            {
                entries.First(x => x.Level == 11).m_Features.Add(ArmorTrainingSelection.ToReference<BlueprintFeatureBaseReference>());
                entries.First(x => x.Level == 15).m_Features.Add(ArmorTrainingSelection.ToReference<BlueprintFeatureBaseReference>());
                entries.First(x => x.Level == 19).m_Features.Add(ArmorTrainingSelection.ToReference<BlueprintFeatureBaseReference>());
            }
            else
            {
                Main.TotFContext.Logger.Log("Couldn't find ArmorTrainingSpeedFeature, Celestial Armor Will Not Have Selections");
            }

            CelestialArmorProgressionMaker.AddToLevelEntries(entries.ToArray());
            CelestialArmorProgressionMaker.AddToClasses(new BlueprintProgression.ClassWithLevel() { m_Class = OracleClass.ToReference<BlueprintCharacterClassReference>() });

            
            Main.TotFContext.Logger.LogPatch("Made", CelestialArmorProgressionMaker.Configure());
        }

        
    }
}
