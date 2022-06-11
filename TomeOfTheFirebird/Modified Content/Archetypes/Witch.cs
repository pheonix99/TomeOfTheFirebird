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
            if (Main.TotFContext.Tweaks.Witch.IsDisabled("ReturnStigmatizedWitchPatron"))
                return;

            var accursed = BlueprintTools.GetBlueprint<BlueprintArchetype>("c5f6e53e71059fb4d802ce81a277a12d");
            var patron = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("381cf4c890815d049a4420c6f31d063f");
            accursed.RemoveFeatures.FirstOrDefault(x => x.Level == 1).m_Features.RemoveAll(x => x.deserializedGuid == patron.AssetGuidThreadSafe);

            var emberFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("b38df30d993476640a17f8c44bd2fffe");
            if (Main.TotFContext.Tweaks.Witch.IsEnabled("EmberHasElementsPatron"))
            {
                emberFeature.Components.OfType<AddClassLevels>().FirstOrDefault().Selections = emberFeature.Components.OfType<AddClassLevels>().FirstOrDefault().Selections.AppendToArray(new SelectionEntry
                {
                    m_Selection = patron.ToReference<BlueprintFeatureSelectionReference>(),
                    m_Features = new BlueprintFeatureReference[] { BlueprintTools.GetBlueprintReference<BlueprintFeatureReference>("67e85f52b1f020847aaa738d8999d4cd") }

                });
            }
            else if(Main.TotFContext.Tweaks.Witch.IsEnabled("EmberHasHealingPatron"))
            {
                emberFeature.Components.OfType<AddClassLevels>().FirstOrDefault().Selections = emberFeature.Components.OfType<AddClassLevels>().FirstOrDefault().Selections.AppendToArray(new SelectionEntry
                {
                    m_Selection = patron.ToReference<BlueprintFeatureSelectionReference>(),
                    m_Features = new BlueprintFeatureReference[] { BlueprintTools.GetBlueprintReference<BlueprintFeatureReference>("a3e4ef40ad99f4d47af15cc5f16afc97") }

                });
            }
            else
            {
                emberFeature.Components.OfType<AddClassLevels>().FirstOrDefault().Selections = emberFeature.Components.OfType<AddClassLevels>().FirstOrDefault().Selections.AppendToArray(new SelectionEntry
                {
                    m_Selection = patron.ToReference<BlueprintFeatureSelectionReference>(),
                    m_Features = new BlueprintFeatureReference[] { BlueprintTools.GetBlueprintReference<BlueprintFeatureReference>("8fe0a14c90d3ea94a833d087b8a09bb9") }

                });
            }


        }
    }
}
