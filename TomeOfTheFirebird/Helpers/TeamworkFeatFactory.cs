using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using System;
using System.Linq;
using UnityEngine;

namespace TomeOfTheFirebird.Helpers
{
    class TeamworkFeatFactory
    {
        

        public static void Make(string sysNameBase, string displayName, string description, Func<bool> enabled, Action<FeatureConfigurator> makeFeature, Sprite icon, FeatureGroup[] additionalGroups, FeatureTag tags)
        {
            FeatureTag tags2 = tags | FeatureTag.Teamwork;
            var displayNameLoc = LocalizationTool.CreateString(sysNameBase + ".Name", displayName, false);
            var descLoc = LocalizationTool.CreateString(sysNameBase + ".Desc", description, false);

            string FeatName = sysNameBase + "Feat";
            string CavBuffName = sysNameBase + "Cavalier";
            string vgBuffName = sysNameBase + "VanguardBuff";
            string vgAbilityName = sysNameBase + "VanguardAbility";

            string ragerBuffName = sysNameBase + "RagerBuff";
            string ragerAreaName = sysNameBase + "RagerArea";

            string ragerAreaBuffName = sysNameBase + "RagerAreaBuff";
            string ragerToggleBuffName = sysNameBase + "RagerToggleBuff";
            string ragerToggleName = sysNameBase + "RagerToggle";

            BlueprintGuid featguid = Main.TotFContext.Blueprints.GetGUID(FeatName);
            BlueprintGuid cavalier = Main.TotFContext.Blueprints.GetGUID(CavBuffName);
            BlueprintGuid vanguardBuff = Main.TotFContext.Blueprints.GetGUID(vgBuffName);
            BlueprintGuid vanguardAbility = Main.TotFContext.Blueprints.GetGUID(vgAbilityName);
            BlueprintGuid RagerBuff = Main.TotFContext.Blueprints.GetGUID(ragerBuffName);
            BlueprintGuid RagerArea = Main.TotFContext.Blueprints.GetGUID(ragerAreaName);
            BlueprintGuid RagerAreaBuff = Main.TotFContext.Blueprints.GetGUID(ragerAreaBuffName);
            BlueprintGuid RagerToggleBuff = Main.TotFContext.Blueprints.GetGUID(ragerToggleBuffName);
            BlueprintGuid RagerToggle = Main.TotFContext.Blueprints.GetGUID(ragerToggleName);
           

            if (enabled.Invoke())
            {
                Main.TotFContext.Logger.Log($"Configuring {displayName}");


              
                var featureconfig = FeatureConfigurator.New(
                    FeatName, featguid.ToString(), groups: (new FeatureGroup[] { FeatureGroup.Feat, FeatureGroup.TeamworkFeat }.Concat(additionalGroups).ToArray()))
                  .SetDisplayName(displayNameLoc)
                  .SetDescription(descLoc)
                  .SetIcon(icon)
                  .AddFeatureTagsComponent(tags2)
                  /*.AddRecommendationHasFeature(FeatureRefs.BattleProwessFeature.ToString())
                  .AddRecommendationHasFeature(FeatureRefs.MonsterTacticsFeature.ToString())
                  .AddRecommendationHasFeature(FeatureRefs.CavalierTacticianFeature.ToString())
                  .AddRecommendationHasFeature(FeatureRefs.VanguardTacticianFeature.ToString())
                  .AddRecommendationHasFeature(FeatureRefs.TacticalLeaderFeatShareFeature.ToString())
                  .AddRecommendationHasFeature(FeatureRefs.HunterTactics.ToString())
                  .AddRecommendationHasFeature(FeatureRefs.SacredHuntsmasterTactics.ToString())
                  .AddRecommendationHasFeature(FeatureRefs.PackRagerRagingTacticianBaseFeature.ToString())
                  .AddRecommendationHasFeature(FeatureRefs.SoloTactics.ToString())
                  .AddRecommendationHasFeature(FeatureRefs.InquisitorSoloTactician.ToString())*/ //TODO RESTORE
                  .AddAsTeamworkFeat(
                    cavalier.ToString(),
                    vanguardBuff.ToString(),
                    vanguardAbility.ToString(),
                    RagerBuff.ToString(),
                    RagerArea.ToString(),
                    RagerAreaBuff.ToString(),
                    RagerToggleBuff.ToString(),
                    RagerToggle.ToString())
                  ;

                makeFeature.Invoke(featureconfig);
                featureconfig.Configure(delayed: true);



            }
            else
            {
                Main.TotFContext.Logger.Log($"Configuring {displayName} (Disabled)");



                FeatureConfigurator.New(FeatName, featguid.ToString())
                  .SetDisplayName(displayNameLoc)
                  .SetDescription(descLoc)
                  .Configure();

                //Save Compat For AddTeamwork

                BuffConfigurator.New(CavBuffName, cavalier.ToString())
                  .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                  .Configure();

                BuffConfigurator.New(vgBuffName, vanguardBuff.ToString())
                  .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                  .Configure();

                AbilityConfigurator.New(vgAbilityName, vanguardAbility.ToString())
                  .Configure();

                BuffConfigurator.New(ragerBuffName, RagerBuff.ToString())
                    .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                     .Configure();
                AbilityAreaEffectConfigurator.New(ragerAreaName, RagerArea.ToString()).Configure();


                BuffConfigurator.New(ragerToggleBuffName, ragerToggleBuffName.ToString())
                    .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                     .Configure();
            }
        }
    }
}
