using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TabletopTweaks.Core.Utilities;

namespace TomeOfTheFirebird.New_Content.Bloodlines
{
    class TotFBloodlineTools
    {
        private static readonly BlueprintCharacterClass BloodragerClass = BlueprintTools.GetBlueprint<BlueprintCharacterClass>("d77e67a814d686842802c9cfd8ef8499");
        public static void MetamagicSupport(BlueprintProgression bloodline)
        {
            
            var archetype = BlueprintTool.Get<BlueprintArchetype>("e4142305e74f438c90b9fe9a545a41af");
            int[] featLevels = { 6, 9, 12, 15, 18 };
            var metamagicFeats = FeatTools.GetMetamagicFeats();

            BlueprintFeatureSelection MetamagicRagerFeatSelection = null;
            foreach (var levelEntry in bloodline.LevelEntries.Where(entry => featLevels.Contains(entry.Level)))
            {
                Main.TotFContext.Logger.Log($"Scanning level {levelEntry.Level} in phoenix bloodline");
                foreach (var selection in levelEntry.Features.Where(f => f is BlueprintFeatureSelection))
                {
                    Main.TotFContext.Logger.Log($"Scanning {selection.name} in  level {levelEntry.Level} in phoenix bloodline");
                    if (selection.GetComponents<PrerequisiteNoArchetype>().Any(c => c.m_Archetype.Get().AssetGuid == archetype.AssetGuid)) { continue; }
                    Main.TotFContext.Logger.Log($"Processing {selection.name} in  level {levelEntry.Level} in phoenix bloodline");
                    var featSelect = selection as BlueprintFeatureSelection;
                    if (MetamagicRagerFeatSelection == null)
                    {
                        Main.TotFContext.Logger.Log($"Building metamagic feat selectors in phoenix bloodline");
                        MetamagicRagerFeatSelection = featSelect.CreateCopy(Main.TotFContext, GenerateName(bloodline), bp =>
                        {
                            bp.HideNotAvailibleInUI = true;
                            
                            bp.AddFeatures(metamagicFeats);
                            bp.AddComponent(TabletopTweaks.Core.Utilities.Helpers.Create<PrerequisiteArchetypeLevel>(c =>
                            {
                                c.HideInUI = true;
                                c.CheckInProgression = true;
                                c.m_CharacterClass = BloodragerClass.ToReference<BlueprintCharacterClassReference>();
                                c.m_Archetype = archetype.ToReference<BlueprintArchetypeReference>();
                            }));
                        });
                        Main.TotFContext.Logger.Log($"Built metamagic feat selectors in phoenix bloodline, guid is {MetamagicRagerFeatSelection.AssetGuid.ToString()}");
                    }

                    selection.AddComponent(TabletopTweaks.Core.Utilities.Helpers.Create<PrerequisiteNoArchetype>(c =>
                    {
                        c.HideInUI = true;
                        c.m_CharacterClass = BloodragerClass.ToReference<BlueprintCharacterClassReference>();
                        c.m_Archetype = archetype.ToReference<BlueprintArchetypeReference>();
                        c.CheckInProgression = true;
                    }));
                }
                Main.TotFContext.Logger.Log($"Adding metamagic selector to level {levelEntry.Level} in phoenix bloodline");
                levelEntry.m_Features.Add(MetamagicRagerFeatSelection.ToReference<BlueprintFeatureBaseReference>());
            }
            string GenerateName(BlueprintFeature bloodline)
            {
                string[] split = Regex.Split(bloodline.name, @"(?<!^)(?=[A-Z])");
                return $"{split[0]}{split[1]}MetamagicRagerFeatSelection";
            }
        }

    }
}
