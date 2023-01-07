using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TomeOfTheFirebird.Helpers;

namespace TomeOfTheFirebird.New_Content.Feats
{
    class ExtraBurn
    {
        public static void Make()
        {
            MakeNormal();
            MakePK();
            void MakeNormal()
            {
                BlueprintCore.Blueprints.CustomConfigurators.Classes.FeatureConfigurator config = MakerTools.MakeFeature("ExtraBurnFeature", "Extra Burn", "You can accept an additional 2 burn per day.\nSpecial: You may take this feat multiple times; its effects stack.");
                config.AddPrerequisiteFeature("57e3577a0eb53294e9d7cc649d5239a3");
                config.AddIncreaseResourceAmount("066ac4b762e32be4b953703174ed925c", 2);
                config.AddToGroups(FeatureGroup.Feat);
                BlueprintFeature done = config.Configure();



              

                BlueprintFeature burnFeature = BlueprintTool.Get<BlueprintFeature>("57e3577a0eb53294e9d7cc649d5239a3");
                AddAbilityResources comp = burnFeature.GetComponent<AddAbilityResources>(x => x.m_Resource.Get().m_MaxAmount.BaseValue == 3);
                comp.RestoreOnLevelUp = true;


                Main.TotFContext.Logger.LogPatch(done);
                if (Settings.IsDisabled("ExtraBurn"))
                    return;
                FeatureConfigurator.For("57e3577a0eb53294e9d7cc649d5239a3").AddToIsPrerequisiteFor("ExtraBurnFeature").Configure();
                TabletopTweaks.Core.Utilities.FeatTools.AddAsFeat(done);
            }
           
            void MakePK()
            {
                BlueprintCore.Blueprints.CustomConfigurators.Classes.FeatureConfigurator config = MakerTools.MakeFeature("ExtraBurnFeaturePK", "Extra Burn (Psychokineticist)", "You can accept an additional 2 burn per day.\nSpecial: You may take this feat multiple times; its effects stack.");
                config.AddPrerequisiteFeature("2fa48527ba627254ba9bf4556330a4d4");
                config.AddIncreaseResourceAmount("4b8b95612529a8640bb6e07c580b947b", 2);
                config.AddToGroups(FeatureGroup.Feat);
                BlueprintFeature done = config.Configure();


                BlueprintAbilityResource pkBurn = BlueprintTool.Get<BlueprintAbilityResource>("4b8b95612529a8640bb6e07c580b947b");
                BlueprintFeature burnFeature = BlueprintTool.Get<BlueprintFeature>("2fa48527ba627254ba9bf4556330a4d4");
                AddAbilityResources comp = burnFeature.GetComponent<AddAbilityResources>(x => x.m_Resource.Get().Equals(pkBurn));
                comp.RestoreOnLevelUp = true;

                Main.TotFContext.Logger.LogPatch(done);
                if (Settings.IsDisabled("ExtraBurn"))
                    return;
                FeatureConfigurator.For("2fa48527ba627254ba9bf4556330a4d4").AddToIsPrerequisiteFor("ExtraBurnFeaturePK").Configure();
                TabletopTweaks.Core.Utilities.FeatTools.AddAsFeat(done);
            }
        }


        /*
         * Extra Burn

“If I must suffer for my cause, so be it!”

Prerequisite: Burn class feature

Benefit: You can accept an additional 2 burn per day.

Special: You may take this feat multiple times; its effects stack.
         */
    }
}
