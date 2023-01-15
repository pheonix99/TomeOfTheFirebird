using BlueprintCore.Blueprints.Configurators.Classes.Selection;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using System.Linq;
using Kingmaker.Utility;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;

namespace TomeOfTheFirebird.Modified_Content.ImprovedMultiarchetypeProjct
{
    class HomebrewArchetypesCompFix
    {
        public static void ModifyVikingBonusFeats()
        {
            var vikingID = "23d88af5a9470b845b893b31895b20c9";
            var fighterID = "48ac8db94d5de7645906c7d0ad3bcfbd";
            var vikingArch = BlueprintTool.Get<BlueprintArchetype>(vikingID);
            if (vikingArch is null)
                return;
            var fighterFeatSelectionGUID = "41c8486641f7d6d4283ca9dae4147a9f";

            var vikingFeatSelectionGUID = "f3f4399e9bd93c6459a82aee386339c3";
            var vikingFeatSelection = BlueprintTool.Get<BlueprintFeatureSelection>(vikingFeatSelectionGUID);
            var vikingHCSelector = BlueprintTool.Get<BlueprintFeatureSelection>("fbedfd5cb9e6c6a4eb5a3e9343de87b9");
            FeatureSelectionConfigurator.For(vikingHCSelector).AddPrerequisiteArchetypeLevel(vikingID, fighterID, level: 6).Configure();
            Main.TotFContext.Logger.LogPatch("Patched Requirements", vikingHCSelector);
            var fighterselect = FeatureSelectionConfigurator.For(fighterFeatSelectionGUID).AddToAllFeatures(vikingHCSelector).Configure() ;

            Main.TotFContext.Logger.LogPatch("Added Rage Power To Fighter List", fighterselect);
            for (int i = 6; i <= 20; i += 2)
                FixVikingLevel(i);
            void FixVikingLevel(int i)
            {

                LevelEntry removeEntry = vikingArch.RemoveFeatures?.FirstOrDefault(x => x.Level == i);
                if (removeEntry is null || removeEntry.m_Features is null || !removeEntry.m_Features.Any())
                {
                    Main.TotFContext.Logger.LogError($"Viking remove entry at level {i} is null");
                    return;
                }
                LevelEntry addEntry = vikingArch.AddFeatures?.FirstOrDefault(x => x.Level == i);
                if (addEntry is null || addEntry.m_Features is null || !addEntry.m_Features.Any())
                {
                    Main.TotFContext.Logger.LogError($"Viking add entry at level {i} is null");
                    return;
                }
                removeEntry.m_Features.Remove(x => x.deserializedGuid.Equals(fighterselect.AssetGuid));
                addEntry.m_Features.Remove(x => x.deserializedGuid.Equals(vikingFeatSelection.AssetGuid));
                Main.TotFContext.Logger.Log($"Improved viking level {i}");
            }

        }
    }
}
