using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.ActivatableAbilities;
using TomeOfTheFirebird.Helpers;
using TomeOfTheFirebird.New_Components;

namespace TomeOfTheFirebird.New_Content.Features
{
    class KineticistInternalBuffer
    {
        public static void Make()
        {
            string resourceSysName = "InternalBufferResource";
            UnityEngine.Sprite icon = BlueprintTool.Get<BlueprintActivatableAbility>("00b6d36e31548dc4ab0ac9d15e64a980").Icon;
            string desc = "At 6th level, a kineticist’s study of her body and the elemental forces that course through it allow her to form an internal buffer to store extra energy.\nWhen she would otherwise accept burn, a kineticist can spend energy from her buffer to avoid accepting 1 point of burn. She can do it once per day. Kineticist gets an additional use of this ability at levels 11 and 16.";
            BlueprintGuid guid = Main.TotFContext.Blueprints.GetGUID(resourceSysName);
            AbilityResourceConfigurator internalbufferResourceCOnfig = AbilityResourceConfigurator.New("InternalBufferResource", guid.ToString());
            internalbufferResourceCOnfig.SetLocalizedName(LocalizationTool.CreateString("InternalBufferResource.Name", "Internal Buffer", false));
            internalbufferResourceCOnfig.SetLocalizedDescription(LocalizationTool.CreateString("InternalBufferResource.Desc", desc, false));
            internalbufferResourceCOnfig.SetMaxAmount(ResourceAmountBuilder.New(1));
            
            internalbufferResourceCOnfig.SetIcon(icon);

            BlueprintAbilityResource resourceMade = internalbufferResourceCOnfig.Configure();

            BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs.BuffConfigurator buffConfig = MakerTools.MakeBuff("InternalBufferBuff", "Internal Buffer", desc, icon);
            buffConfig.AddComponent<InternalBufferComponent>(x =>
            {
                x.actions = ActionsBuilder.New().ContextSpendResource(resourceMade, ContextValues.Constant(1)).Build();
            });
            Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff buff = buffConfig.Configure();

            BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities.ActivatableAbilityConfigurator abilityConfig = MakerTools.MakeToggle("InternalBufferActivatableAbility", "Internal Buffer", desc, icon);
            abilityConfig.SetBuff(buff);
            abilityConfig.SetActivationType(AbilityActivationType.Immediately);
            abilityConfig.SetActivateWithUnitCommand(Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Free);
            abilityConfig.AddActivatableAbilityResourceLogic(requiredResource: resourceMade, spendType: ActivatableAbilityResourceLogic.ResourceSpendType.Never);
            abilityConfig.SetDeactivateImmediately(true);
            
            
            BlueprintActivatableAbility ability = abilityConfig.Configure();

            FeatureConfigurator featureConfig = MakerTools.MakeFeature("InternalBufferFeature", "Internal Buffer", desc, hide:false, icon: icon);
            featureConfig.SetIsClassFeature(true);
          
            featureConfig.AddFacts(facts: new() { ability });
            featureConfig.AddAbilityResources(0, resourceMade, restoreOnLevelUp: true);
            BlueprintFeature feature = featureConfig.Configure();

            FeatureConfigurator featureConfig2 = MakerTools.MakeFeature("InternalBufferExtraUseFeature", "Internal Buffer", desc, hide: false, icon: icon);
            featureConfig2.SetIsClassFeature(true);

            featureConfig2.AddFacts(facts: new() { ability });
            featureConfig2.AddIncreaseResourceAmount(resourceMade, 1);
            BlueprintFeature feature2 = featureConfig2.Configure();


            Main.TotFContext.Logger.LogPatch(feature);

        }
    }
}
