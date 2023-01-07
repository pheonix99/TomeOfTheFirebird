using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;

namespace TomeOfTheFirebird.Modified_Content.Classes
{
    class Bloodrager
    {
        public static void FixIcons()
        {
            if (Settings.IsDisabled("FixBloodragerSpellIcons"))
                return;

            var bloodlineselector = BlueprintTool.Get<BlueprintFeatureSelection>("62b33ac8ceb18dd47ad4c8f06849bc01");

            foreach (var v in bloodlineselector.m_AllFeatures)
            {
                var v2 = BlueprintTools.GetBlueprint<BlueprintProgression>(v.Guid);
                if (v2 != null)
                {
                    ProgressionConfigurator.For(v2).ModifyLevelEntries(x =>
                    {
                        foreach (var q in x.m_Features)
                        {
                            var feature = q.Get();

                            AddKnownSpell referant = feature.GetComponent<AddKnownSpell>();
                            if (referant != null)
                            {
                                FeatureConfigurator.For(feature).SetIcon(referant.m_Spell.Get().Icon).Configure() ;
                                
                            }
                            Main.TotFContext.Logger.LogPatch($"Patched Icon on", feature);
                        }
                    }).Configure();
                }
            }

        }


    }
}
