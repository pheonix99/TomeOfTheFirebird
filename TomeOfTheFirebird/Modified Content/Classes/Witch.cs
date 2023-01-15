using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.UnitLogic.FactLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTweaks.Core.Utilities;

namespace TomeOfTheFirebird.Modified_Content.Classes
{
    class Witch
    {
        //TODO patch freezing sphere into Elements 6
        //TODO patch firestorm into Elements 8
        //TODO patch meteor swarm into Elements 9?

        public static void FixIcons()
        {
            if (Settings.IsDisabled("FixWitchSpellIcons"))
                return;

            var bloodlineselector = BlueprintTool.Get<BlueprintFeatureSelection>("381cf4c890815d049a4420c6f31d063f");

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
                                FeatureConfigurator.For(feature).SetIcon(referant.m_Spell.Get().Icon).Configure();

                            }
                            Main.TotFContext.Logger.LogPatch($"Patched Icon on", feature);
                        }
                    }).Configure();
                }
            }

        }

    }
}
