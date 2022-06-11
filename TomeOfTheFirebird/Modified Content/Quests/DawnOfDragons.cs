using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.BasicEx;
using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.StoryEx;
using BlueprintCore.Utils;
using Kingmaker.AreaLogic.Etudes;
using Kingmaker.Blueprints;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Designers.EventConditionActionSystem.Evaluators;
using Kingmaker.Designers.EventConditionActionSystem.Events;
using Kingmaker.ElementsSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Utility;
using System.Collections.Generic;
using System.Linq;
using TabletopTweaks.Core.Utilities;
using TomeOfTheFirebird.Components;
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

            FeatureConfigurator auraFeature = FeatureConfigurator.New("DragonHolyAuraFeature", Main.TotFContext.Blueprints.GetGUID("DragonHolyAuraFeature").ToString()).SetDisplayName(LocalizationTool.CreateString("HukugolHolyAuraFeature.Name", "Hokugol's Blessing (Aura)")).SetDescription(LocalizationTool.CreateString("HukugolHolyAuraFeature.Desc", "The silver dragon Hokugol blessed you with a permanent Holy Aura effect for aiding him")).AddFacts(new List<Blueprint<BlueprintUnitFactReference>>() { "a33bf327207a5904d9e38d6a80eb09e2" }, casterLevel: 23);
            string isAngelEtude = "3a82aba4de71b89458ac82949ed957c4";
            //auraFeature.AddFeatureSurvivesRespec();
            auraFeature.SetRanks(1);
            var AuraFeatureBuilt = auraFeature.Configure();
            
            var AngelIce = new ContextWeaponCategoryExtraDamageDice()
            {
                Ascendant = true,
                ToAllAttacks = true,
                Element = new Kingmaker.RuleSystem.Rules.Damage.DamageTypeDescription() { Energy = Kingmaker.Enums.Damage.DamageEnergyType.Cold, Type = DamageType.Energy, Common = new Kingmaker.RuleSystem.Rules.Damage.DamageTypeDescription.CommomData() { Reality = Kingmaker.Enums.Damage.DamageRealityType.Ghost } },
                DamageDice = new Kingmaker.RuleSystem.DiceFormula(1, Kingmaker.RuleSystem.DiceType.D6)

            };

            

            var AngelIceResist = new AddDamageResistanceEnergy() { Type = Kingmaker.Enums.Damage.DamageEnergyType.Cold, Value = 20 };
            var angelBlessingFeature = MakerTools.MakeFeature("DragonAngelBlessingFeature", "Hokugol's Blessing (Frost)", "The silver dragon Hokugol blessed you with a portion of his frost for aiding him");

            angelBlessingFeature.AddComponent(AngelIce);
            angelBlessingFeature.SetRanks(1);
            //angelBlessingFeature.AddComponent(new IncorperateAdditonalDiceOnAttackIntoUI());
            //angelBlessingFeature.AdditionalDiceOnAttack(new Feet(0f), new DamageTypeDescription() { Type = DamageType.Energy, Energy = Kingmaker.Enums.Damage.DamageEnergyType.Cold }, onHit: true, value: new ContextDiceValue() { DiceType = Kingmaker.RuleSystem.DiceType.D6, DiceCountValue = 1, BonusValue = 0 }, initiatorConditions: ConditionsBuilder.New(), targetConditions: ConditionsBuilder.New());
            angelBlessingFeature.AddResistEnergy(type: Kingmaker.Enums.Damage.DamageEnergyType.Cold, value: new ContextValue() { Value = 10 }).AddStatBonus(Kingmaker.Enums.ModifierDescriptor.NaturalArmorEnhancement, stat: Kingmaker.EntitySystem.Stats.StatType.AC, value: 5);
            //angelBlessingFeature.AddFeatureSurvivesRespec();
            var angelBuilt = angelBlessingFeature.Configure();
            if (Main.TotFContext.Tweaks.RewardFeatureConversion.IsDisabled("DawnOfDragons"))
                return;
            BlueprintEtude BuffGiver = BlueprintTools.GetBlueprint<BlueprintEtude>("ed86bf33a6a58cd40bf17ed141b6b94a");
            ActionList BuffGiverList = BuffGiver.Components.OfType<EtudePlayTrigger>().First().Actions;
            var AuraFeatureAdder = ActionsBuilder.New().AddFact(AuraFeatureBuilt.AssetGuidThreadSafe, new PlayerCharacter());
            var DragonPowerAdd = ActionsBuilder.New().AddFact(angelBuilt.AssetGuidThreadSafe, new PlayerCharacter());

            GameAction adder;
            if (Main.TotFContext.ContentModifications.DawnOfDragons.IsEnabled("CustomRewardForEveryone"))
            {
                adder = DragonPowerAdd.Build().Actions[0];
            }
            else if (Main.TotFContext.ContentModifications.DawnOfDragons.IsEnabled("CustomRewardForAngelOnly"))
            {
                
                

                





                

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
