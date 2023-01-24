using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Kingmaker.Blueprints.BlueprintUnit;

namespace TomeOfTheFirebird.Modified_Content.Archetypes
{
    class ThieflingInteroperability
    {
        public static void AddOtherModRogueTalents()
        {
            if (Settings.IsDisabled("ThieflingTalentsInterop"))
                return;
            string theiflingTalentSelect = "ea908dd2576b79f418814a99b788f882";
            var theiflingTalentSelectLive = BlueprintTool.Get<BlueprintFeatureSelection>(theiflingTalentSelect);
            if (theiflingTalentSelectLive == null)
                return;

            List<string> guidBlockList = new() { "90defe72b89cb7f448736f4d0a3335e8", "59e9a1c3739586647a317d975321ea9e" };

            
            string thieflingExtraTalent = "674f3b547a2e7f3409f514b17c49dee6";

            string vanillaRogueTalent = "c074a5d615200494b8f2a9c845799d93";

            var vanillaRogueList = BlueprintTool.Get<BlueprintFeatureSelection>(vanillaRogueTalent).m_AllFeatures;
            


            var config = FeatureSelectionConfigurator.For(theiflingTalentSelect);
            var config2 = FeatureSelectionConfigurator.For(thieflingExtraTalent);

            foreach (var featurref in vanillaRogueList)
            {
            

                if (!theiflingTalentSelectLive.m_AllFeatures.Contains(featurref))
                {
                    string candidateid = featurref.Guid.ToString();
                    if (guidBlockList.Any(x => x.Equals( candidateid)))
                    {
                        continue;
                    }
                    else
                    {
                        //Main.TotFContext.Logger.Log($"Didn't block {candidateid}");
                    }
                    
                    

                    config.AddToAllFeatures(featurref);
                    config2.AddToAllFeatures(featurref);
                    Main.TotFContext.Logger.LogPatch("Added to thiefling talent selectors", featurref.Get());
                }
            }
            config.Configure();
            config2.Configure();

        }
    }
}
