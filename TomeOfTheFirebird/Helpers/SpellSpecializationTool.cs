using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTweaks.Core.Utilities;

namespace TomeOfTheFirebird.Helpers
{
    public static class SpellSpecializationTool
    {

        public static void AddToSpellSpecialization(this BlueprintAbility spell)
        {
            BlueprintFeatureSelection selector = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("fe67bc3b04f1cd542b4df6e28b6e0ff5");

            foreach(Kingmaker.Blueprints.Classes.BlueprintFeature list in selector.Features)
            {
                BlueprintParametrizedFeature paramList = (list as BlueprintParametrizedFeature);
                if (paramList == null)
                    continue;
                else
                {
                    if (paramList.BlueprintParameterVariants.Any(x=>x.deserializedGuid.Equals(spell.AssetGuid)))
                    {
                        
                        continue;
                    }
                    else
                    {
                        Main.TotFContext.Logger.Log($"Adding {spell.Name} to {paramList.name}");
                        paramList.BlueprintParameterVariants = paramList.BlueprintParameterVariants.AppendToArray(spell.ToReference<AnyBlueprintReference>());

                    }
                }
            }

            


        }
    }
}
