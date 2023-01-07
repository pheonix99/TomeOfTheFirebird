using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.Classes.Selection;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.ElementsSystem;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using System;
using System.Linq;
using TabletopTweaks.Core.Utilities;
using TomeOfTheFirebird.Helpers;
using UnityEngine;

namespace TomeOfTheFirebird.New_Content.Mercies
{
    class ExtraMercies
    {

        static BlueprintFeature injured;
        static BlueprintFeature ensorcelled;

        public static void Build()
        {
         
            BuildEnsorcelled();
            BuildInjured();
            //Lay On Hands applies dispel effect
            //Unlike standard mercies this one is effective in kill-mode too
            void BuildEnsorcelled()
            {

                BlueprintAbility dispel = BlueprintTools.GetBlueprint<BlueprintAbility>("b9be852b03568064b8d2275a6cf9e2de");
                BlueprintCore.Blueprints.CustomConfigurators.Classes.FeatureConfigurator maker = MakerTools.MakeFeature("MercyEnsorcelled", "Mercy - Ensorcelled", "The paladin’s lay on hands also acts as dispel magic, using the paladin’s level as her caster level.", false, dispel.Icon);
                maker.AddToGroups(FeatureGroup.Mercy);
                maker.AddPrerequisiteClassLevel("bfa11238e7ae3544bbeb4d0b92e897ec", 12);
                maker.SetRanks(1);

                ensorcelled = maker.Configure();
               
                ActionsBuilder dispelActMake = ActionsBuilder.New().Conditional(conditions: ConditionsBuilder.New().HasFact(ensorcelled.AssetGuidThreadSafe), ifTrue: ActionsBuilder.New().DispelMagic(buffType: Kingmaker.UnitLogic.Mechanics.Actions.ContextActionDispelMagic.BuffType.FromSpells, checkType: Kingmaker.RuleSystem.Rules.RuleDispelMagic.CheckType.CasterLevel, maxSpellLevel: new Kingmaker.UnitLogic.Mechanics.ContextValue() { Value = 10 }, onlyTargetEnemyBuffs: true, countToRemove: new Kingmaker.UnitLogic.Mechanics.ContextValue() { Value = 1 }));

                GameAction dispelAct = dispelActMake.Build().Actions[0];

                BlueprintAbility LayOnHandsSelf = BlueprintTools.GetBlueprint<BlueprintAbility>("8d6073201e5395d458b8251386d72df1");
                Conditional LoHMeCond = LayOnHandsSelf.Components.OfType<AbilityEffectRunAction>().First().Actions.Actions.OfType<Conditional>().First();
                LoHMeCond.IfTrue.Actions = LoHMeCond.IfTrue.Actions.Append(dispelAct).ToArray();
                LoHMeCond.IfFalse.Actions = LoHMeCond.IfTrue.Actions.Append(dispelAct).ToArray();

                BlueprintAbility LayOnHandsOther = BlueprintTools.GetBlueprint<BlueprintAbility>("caae1dc6fcf7b37408686971ee27db13");

                Conditional LoHOCond = LayOnHandsOther.Components.OfType<AbilityEffectRunAction>().First().Actions.Actions.OfType<Conditional>().First();


                LoHOCond.IfTrue.Actions = LoHOCond.IfTrue.Actions.Append(dispelAct).ToArray();
                LoHOCond.IfFalse.Actions = LoHOCond.IfTrue.Actions.Append(dispelAct).ToArray();






                BlueprintAbility LayOnHandsSpecial = BlueprintTools.GetBlueprint<BlueprintAbility>("8337cea04c8afd1428aad69defbfc365");

                Conditional LoHSCond = LayOnHandsSpecial.Components.OfType<AbilityEffectRunAction>().First().Actions.Actions.OfType<Conditional>().First();

                LoHSCond.IfTrue.Actions = LoHSCond.IfTrue.Actions.Append(dispelAct).ToArray();
                LoHSCond.IfFalse.Actions = LoHSCond.IfTrue.Actions.Append(dispelAct).ToArray();

                
            }
            void BuildInjured()
            {
                //Create Feature

                //Add To Mercy List

                //Add To All Three LoH types


                Sprite icon = BlueprintTools.GetBlueprint<BlueprintBuff>("9017213d83ccddb4ab720e0a0efe36ff").Icon;
                BlueprintCore.Blueprints.CustomConfigurators.Classes.FeatureConfigurator maker = MakerTools.MakeFeature("MercyInjured", "Mercy - Injured", "The target gains fast healing 3 for a number of rounds equal to 1/2 the paladin’s level.", false, icon);
                maker.AddToGroups(FeatureGroup.Mercy);
                maker.AddPrerequisiteClassLevel("bfa11238e7ae3544bbeb4d0b92e897ec", 9);
                maker.SetRanks(1);



                injured = maker.Configure();

                BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs.BuffConfigurator MercyFastHealingBuff = MakerTools.MakeBuff("MercyInjuredBuff", "Mercy: Injured", "Granted Fast Healing 3 by Lay On Hands", icon);
                MercyFastHealingBuff.AddEffectContextFastHealing(bonus: new ContextValue() { Value = 3 }).SetIsClassFeature(true);
                MercyFastHealingBuff.SetRanks(1);
                ConditionsBuilder conditionsBuilder = ConditionsBuilder.New().CasterHasFact(injured.AssetGuidThreadSafe);

                BlueprintBuff buffDone = MercyFastHealingBuff.Configure();

                ActionsBuilder buffAct = ActionsBuilder.New().ApplyBuff(buffDone.AssetGuidThreadSafe, durationValue: MakerTools.GetContextDurationValue(DurationRate.Minutes, false), isFromSpell: false, isNotDispelable: true);
                ActionsBuilder buffActWrapper = ActionsBuilder.New().Conditional(conditionsBuilder, buffAct);


                GameAction actDone = buffActWrapper.Build().Actions[0];
                BlueprintAbility LayOnHandsSelf = BlueprintTools.GetBlueprint<BlueprintAbility>("8d6073201e5395d458b8251386d72df1");
                Conditional LoHMeCond = LayOnHandsSelf.Components.OfType<AbilityEffectRunAction>().First().Actions.Actions.OfType<Conditional>().First();
                LoHMeCond.IfTrue.Actions = LoHMeCond.IfTrue.Actions.Append(actDone).ToArray();


                BlueprintAbility LayOnHandsOther = BlueprintTools.GetBlueprint<BlueprintAbility>("caae1dc6fcf7b37408686971ee27db13");

                Conditional LoHOCond = LayOnHandsOther.Components.OfType<AbilityEffectRunAction>().First().Actions.Actions.OfType<Conditional>().First();



                LoHOCond.IfTrue.Actions = LoHOCond.IfTrue.Actions.Append(actDone).ToArray();







                BlueprintAbility LayOnHandsSpecial = BlueprintTools.GetBlueprint<BlueprintAbility>("8337cea04c8afd1428aad69defbfc365");

                Conditional LoHSCond = LayOnHandsSpecial.Components.OfType<AbilityEffectRunAction>().First().Actions.Actions.OfType<Conditional>().First();

                LoHSCond.IfTrue.Actions = LoHSCond.IfTrue.Actions.Append(actDone).ToArray();


                
               
            }

        }

        public static void AddToThings()
        {
            string TTTExtraMercies = "6e76496c2748405d9946949977bd3e8d";
            if (Settings.IsEnabled("mercyinjured"))
            {
                FeatureSelectionConfigurator.For("02b187038a8dce545bb34bbfb346428d").AddToAllFeatures(injured.AssetGuidThreadSafe).Configure();
                try
                {
                    //FeatureSelectionConfigurator.For(TTTExtraMercies).AddToAllFeatures(injured.AssetGuidThreadSafe).Configure();

                   
                }
                catch (Exception e)
                {
                    Main.TotFContext.Logger.Log("Outright error throwin trying to add to TTT selector");
                }
            }
            if (Settings.IsEnabled("mercyensorcelled"))
            {
                FeatureSelectionConfigurator.For("02b187038a8dce545bb34bbfb346428d").AddToAllFeatures(ensorcelled.AssetGuidThreadSafe).Configure();
                try
                {
                    //FeatureSelectionConfigurator.For(TTTExtraMercies).AddToAllFeatures(ensorcelled.AssetGuidThreadSafe).Configure();


                }
                catch (Exception e)
                {
                    Main.TotFContext.Logger.Log("Outright error throwin trying to add to TTT selector");
                }
            }
        }
    }
}
