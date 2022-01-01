using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.BasicEx;
using BlueprintCore.Blueprints.Configurators.AreaLogic.Etudes;
using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.StoryEx;
using BlueprintCore.Utils;
using Kingmaker.AreaLogic.Etudes;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Designers.EventConditionActionSystem.Evaluators;
using Kingmaker.Designers.EventConditionActionSystem.Events;
using Kingmaker.ElementsSystem;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomeOfTheFirebird.Components;
using TomeOfTheFirebird.Config;
using TomeOfTheFirebird.Helpers;

namespace TomeOfTheFirebird.QuestTweaks
{
    /// <summary>
    /// For some shitty reason the good pick gets a perma buff (that won't persist over respec and might be dispellable) and some vendor trash while evil gets you a contendor for Best-In-Slot
    /// And Angel Already *has* an uprated version of said buff
    /// </summary>
    
    public static class DawnOfDragons
    {
        public static void Fix()
        {

            FeatureConfigurator auraFeature = FeatureConfigurator.New("DragonHolyAuraFeature", ModSettings.Blueprints.GetGUID("DragonHolyAuraFeature").ToString()).SetDisplayName(LocalizationTool.CreateString("HukugolHolyAuraFeature.Name", "Hokugol's Blessing (Aura)")).SetDescription(LocalizationTool.CreateString("HukugolHolyAuraFeature.Desc", "The silver dragon Hokugol blessed you with a permanent Holy Aura effect for aiding him")).AddFacts(new string[] { "a33bf327207a5904d9e38d6a80eb09e2" }, casterLevel: 23);
            string isAngelEtude = "3a82aba4de71b89458ac82949ed957c4";
            var AuraFeatureBuilt = auraFeature.Configure();

            var AngelIce = new ContextWeaponCategoryExtraDamageDice()
            {
                Ascendant = true,
                ToAllAttacks = true,
                Element = new Kingmaker.RuleSystem.Rules.Damage.DamageTypeDescription() { Energy = Kingmaker.Enums.Damage.DamageEnergyType.Cold, Type = Kingmaker.RuleSystem.Rules.Damage.DamageType.Energy, Common = new Kingmaker.RuleSystem.Rules.Damage.DamageTypeDescription.CommomData() { Reality = Kingmaker.Enums.Damage.DamageRealityType.Ghost } },
                DamageDice = new Kingmaker.RuleSystem.DiceFormula(1, Kingmaker.RuleSystem.DiceType.D6)

            };
            var AngelIceResist = new AddDamageResistanceEnergy() { Type = Kingmaker.Enums.Damage.DamageEnergyType.Cold, Value = 20 };
            var angelBlessingFeature = MakerTools.MakeFeature("DragonAngelBlessingFeature", "Hokugol's Blessing (Frost)", "The silver dragon Hokugol blessed you with a portion of his frost for aiding him").AddComponent(AngelIce).AddResistEnergy(Kingmaker.Enums.Damage.DamageEnergyType.Cold, value: new ContextValue() { Value = 10 }).AddStatBonus(Kingmaker.Enums.ModifierDescriptor.NaturalArmorEnhancement, stat: Kingmaker.EntitySystem.Stats.StatType.AC, value: 5);
            var angelBuilt = angelBlessingFeature.Configure();
            if (ModSettings.Tweaks.Quests.IsDisabled("DawnOfDragonsRewardFeaturize"))
                return;
            BlueprintEtude BuffGiver = Resources.GetBlueprint<BlueprintEtude>("ed86bf33a6a58cd40bf17ed141b6b94a");
            ActionList BuffGiverList = BuffGiver.Components.OfType<EtudePlayTrigger>().First().Actions;
            var AuraFeatureAdder = ActionsBuilder.New().AddFact(AuraFeatureBuilt.AssetGuidThreadSafe, new PlayerCharacter());
            var DragonPowerAdd = ActionsBuilder.New().AddFact(angelBuilt.AssetGuidThreadSafe, new PlayerCharacter());

            GameAction adder;
            if (ModSettings.Tweaks.Quests.IsEnabled("DawnOfDragonsCustomRewardEveryone"))
            {
                adder = DragonPowerAdd.Build().Actions[0];
            }
            else if (ModSettings.Tweaks.Quests.IsEnabled("DawnOfDragonsCustomRewardAngelOnly"))
            {
                
                

                


                //TODO add paralysis and sleep save bonus!



                

                var isAngel = ConditionsBuilder.New().EtudeStatus(etude: isAngelEtude, started: true);
                var angelOnlyAct = ActionsBuilder.New().Conditional(isAngel, ifTrue: DragonPowerAdd, ifFalse: AuraFeatureAdder).Build();
                //var act = ActionsBuilder.New().AddFact(AuraFeatureBuilt.AssetGuidThreadSafe, new PlayerCharacter()).Build();
                adder = angelOnlyAct.Actions[0];

                
            }
            else
            {
                adder = AuraFeatureAdder.Build().Actions[0];
            }
            BuffGiverList.Actions.Remove(x => x is AttachBuff);
            BuffGiverList.Actions = BuffGiverList.Actions.Append(adder).ToArray();





        }

    }
}
