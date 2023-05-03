using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Utils;
using TomeOfTheFirebird.Helpers;
using TomeOfTheFirebird.New_Components;

namespace TomeOfTheFirebird.New_Content.Feats
{
    class KineticLeap
    {
        private static bool IsEnabled()
        {
            return Settings.EnableJumpContent();
        }

        public static void Make()
        {
            FeatureConfigurator config = MakerTools.MakeFeature("KineticLeapFeature", LocalizationTool.GetString("KineticLeap.Name"), LocalizationTool.GetString("KineticLeap.Desc"));
            AbilityConfigurator baseAbilityConfig = MakerTools.MakeLocalizedAbility("KineticLeapBaseAbility", "KineticLeap.Name", "KineticLeapBaseAbility.Desc");
            AbilityConfigurator commitAbilityConfig = MakerTools.MakeLocalizedAbility("KineticLeapCommitBurnAbility", "KineticLeapCommitBurnAbility.Name", "KineticLeapCommitBurnAbility.Desc");
            BuffConfigurator commitBuffConfig = MakerTools.MakeLocalizedBuff("KineticLeapCommitBurnBuff", "KineticLeapCommitBurnAbility.Name", "KineticLeapCommitBurnAbility.Desc");//TODO GET ICON
            if (IsEnabled())
            {
                config.AddPrerequisiteFeature("93efbde2764b5504e98e6824cab3d27c");
                config.AddPrerequisiteStatValue(Kingmaker.EntitySystem.Stats.StatType.SkillMobility, 3);
                config.AddFacts(facts: new() { "KineticLeapBaseAbility" });
                baseAbilityConfig.AddAbilityVariants(new System.Collections.Generic.List<Blueprint<Kingmaker.Blueprints.BlueprintAbilityReference>>() { "KineticLeapCommitBurnAbility" });
                commitAbilityConfig.AddAbilityCasterHasNoFacts(facts: new() { "KineticLeapCommitBurnBuff" });
                
                
            }

            commitBuffConfig.Configure();
            commitAbilityConfig.Configure();
            baseAbilityConfig.Configure();
            config.Configure();
        }

        /*
         *  Kinetic Leap
Source Occult Adventures pg. 136
Kinetic energy propels you when you jump.

Prerequisites: Acrobatics 3 ranks, kinetic blast class feature.

Benefit: Once per day as a swift action, you can conjure a burst of energy from your kinetic blast to help you jump a long distance, adding a +10 bonus on your Acrobatics check to jump; if you have at least 10 ranks in Acrobatics, the bonus increases to +20. By accepting 1 point of burn, you can use this ability at will until your burn is removed.
         */
    }
}
