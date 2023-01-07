using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using System.Linq;
using TabletopTweaks.Core.Utilities;

namespace TomeOfTheFirebird.Modified_Content.Archetypes
{
    class Witch
    {
        public static void ReturnAccursedPatrons()
        {
            if (Settings.IsDisabled("WitchRestoreStigmatizedPatron"))
                return;

            BlueprintArchetype accursed = BlueprintTools.GetBlueprint<BlueprintArchetype>("c5f6e53e71059fb4d802ce81a277a12d");
            BlueprintFeatureSelection patron = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("381cf4c890815d049a4420c6f31d063f");
            accursed.RemoveFeatures.FirstOrDefault(x => x.Level == 1).m_Features.RemoveAll(x => x.deserializedGuid == patron.AssetGuidThreadSafe);

            BlueprintFeature emberFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("b38df30d993476640a17f8c44bd2fffe");
            Settings.EmberPatron patronSetting = Settings.GetDD<Settings.EmberPatron>("WitchEmberPatron");
            switch (patronSetting)
            {
                case Settings.EmberPatron.Elements:
                    emberFeature.Components.OfType<AddClassLevels>().FirstOrDefault().Selections = emberFeature.Components.OfType<AddClassLevels>().FirstOrDefault().Selections.AppendToArray(new SelectionEntry
                    {
                        m_Selection = patron.ToReference<BlueprintFeatureSelectionReference>(),
                        m_Features = new BlueprintFeatureReference[] { BlueprintTools.GetBlueprintReference<BlueprintFeatureReference>("67e85f52b1f020847aaa738d8999d4cd") }

                    });
                    break;
                case Settings.EmberPatron.Healing:
                    emberFeature.Components.OfType<AddClassLevels>().FirstOrDefault().Selections = emberFeature.Components.OfType<AddClassLevels>().FirstOrDefault().Selections.AppendToArray(new SelectionEntry
                    {
                        m_Selection = patron.ToReference<BlueprintFeatureSelectionReference>(),
                        m_Features = new BlueprintFeatureReference[] { BlueprintTools.GetBlueprintReference<BlueprintFeatureReference>("a3e4ef40ad99f4d47af15cc5f16afc97") }

                    });
                    break;
                case Settings.EmberPatron.Endurance:
                    emberFeature.Components.OfType<AddClassLevels>().FirstOrDefault().Selections = emberFeature.Components.OfType<AddClassLevels>().FirstOrDefault().Selections.AppendToArray(new SelectionEntry
                    {
                        m_Selection = patron.ToReference<BlueprintFeatureSelectionReference>(),
                        m_Features = new BlueprintFeatureReference[] { BlueprintTools.GetBlueprintReference<BlueprintFeatureReference>("8fe0a14c90d3ea94a833d087b8a09bb9") }

                    });
                    break;
                default:
                    break;
            }
            


        }
    }
}
