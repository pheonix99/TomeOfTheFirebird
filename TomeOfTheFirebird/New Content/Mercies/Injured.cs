using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.Classes.Selection;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.BasicEx;
using BlueprintCore.Conditions.Builder.ContextEx;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.ElementsSystem;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomeOfTheFirebird.Helpers;
using UnityEngine;

namespace TomeOfTheFirebird.New_Content.Mercies
{
    class Injured
    {
        //Apply Fast Healing 3 for 1/2 effective Paladin Level
        public static void Build()
        {
            //Create Feature

            //Add To Mercy List

            //Add To All Three LoH types


            Sprite icon = Resources.GetBlueprint<BlueprintBuff>("9017213d83ccddb4ab720e0a0efe36ff").Icon;
            var maker = MakerTools.MakeFeature("MercyInjured", "Injured", "Temp: Grant Fast Healing", false, icon);
            maker.SetFeatureGroups(FeatureGroup.Mercy);

            maker.SetRanks(1);



            var madeFeature = maker.Configure();

            var MercyFastHealingBuff = MakerTools.MakeBuff("MercyInjuredBuff", "Mercy: Injured", "Fast Healing Three", icon);
            MercyFastHealingBuff.AddEffectContextFastHealing(bonus: new ContextValue() { Value = 3 });
            

            var buffDone = MercyFastHealingBuff.Configure();
            var buffAct = ActionsBuilder.New().ApplyBuff(buffDone.AssetGuidThreadSafe, duration: MakerTools.GetContextDurationValue(DurationRate.Minutes, false));


            var actDone = buffAct.Build().Actions[0];
            var LayOnHandsSelf = Resources.GetBlueprint<BlueprintAbility>("8d6073201e5395d458b8251386d72df1");
            Conditional LoHMeCond = LayOnHandsSelf.Components.OfType<AbilityEffectRunAction>().First().Actions.Actions.OfType<Conditional>().First();
            LoHMeCond.IfTrue.Actions = LoHMeCond.IfTrue.Actions.Append(actDone).ToArray();
            

            var LayOnHandsOther = Resources.GetBlueprint<BlueprintAbility>("caae1dc6fcf7b37408686971ee27db13");

            Conditional LoHOCond = LayOnHandsOther.Components.OfType<AbilityEffectRunAction>().First().Actions.Actions.OfType<Conditional>().First();

            Main.Log($"LoHO Actions before add{LoHOCond.IfTrue.Actions.Length}");

            LoHOCond.IfTrue.Actions = LoHOCond.IfTrue.Actions.Append(actDone).ToArray();



            Main.Log($"LoHO Actions after add{LoHOCond.IfTrue.Actions.Length}");



            var LayOnHandsSpecial = Resources.GetBlueprint<BlueprintAbility>("8337cea04c8afd1428aad69defbfc365");

            Conditional LoHSCond = LayOnHandsSpecial.Components.OfType<AbilityEffectRunAction>().First().Actions.Actions.OfType<Conditional>().First();

            LoHSCond.IfTrue.Actions = LoHSCond.IfTrue.Actions.Append(actDone).ToArray();
            

            //Make Feature

            //Add To Selectors

            //Add Effect On Heal to all three

            //Add Effect On Kill Mode to LoH - Ohter

            FeatureSelectionConfigurator.For("02b187038a8dce545bb34bbfb346428d").AddToFeatures(madeFeature.AssetGuidThreadSafe).Configure();

        }

    }
}
