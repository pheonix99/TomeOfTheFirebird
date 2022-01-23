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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomeOfTheFirebird.Config;
using TomeOfTheFirebird.Helpers;

namespace TomeOfTheFirebird.New_Content.Mercies
{
    class Ensorcelled
    {
        //Lay On Hands applies dispel effect
        //Unlike standard mercies this one is effective in kill-mode too
        //May need new dispel spell or effect to make sure no dispelling wrong things

        public static void Build()
        {

            var dispel = Resources.GetBlueprint<BlueprintAbility>("b9be852b03568064b8d2275a6cf9e2de");
            var maker = MakerTools.MakeFeature("MercyEnsorcelled", "Mercy - Ensorcelled", "The paladin’s lay on hands also acts as dispel magic, using the paladin’s level as her caster level.", false, dispel.Icon);
            maker.SetFeatureGroups(FeatureGroup.Mercy);
            maker.PrerequisiteClassLevel("bfa11238e7ae3544bbeb4d0b92e897ec", 12);
            maker.SetRanks(1);

            var madeFeature = maker.Configure();

            ActionsBuilder dispelActMake = ActionsBuilder.New().Conditional(conditions: ConditionsBuilder.New().HasFact(madeFeature.AssetGuidThreadSafe), ifTrue: ActionsBuilder.New().Dispel(type: Kingmaker.UnitLogic.Mechanics.Actions.ContextActionDispelMagic.BuffType.FromSpells, checkType: Kingmaker.RuleSystem.Rules.RuleDispelMagic.CheckType.CasterLevel, maxSpellLevel: new Kingmaker.UnitLogic.Mechanics.ContextValue() { Value = 10 }, onlyDispelEnemyBuffs: true, countToRemove: new Kingmaker.UnitLogic.Mechanics.ContextValue() { Value = 1 }));

            GameAction dispelAct = dispelActMake.Build().Actions[0];

            var LayOnHandsSelf = Resources.GetBlueprint<BlueprintAbility>("8d6073201e5395d458b8251386d72df1");
            Conditional LoHMeCond = LayOnHandsSelf.Components.OfType<AbilityEffectRunAction>().First().Actions.Actions.OfType<Conditional>().First();
            LoHMeCond.IfTrue.Actions = LoHMeCond.IfTrue.Actions.Append(dispelAct).ToArray();
            LoHMeCond.IfFalse.Actions = LoHMeCond.IfTrue.Actions.Append(dispelAct).ToArray();

            var LayOnHandsOther = Resources.GetBlueprint<BlueprintAbility>("caae1dc6fcf7b37408686971ee27db13");

            Conditional LoHOCond = LayOnHandsOther.Components.OfType<AbilityEffectRunAction>().First().Actions.Actions.OfType<Conditional>().First();


            LoHOCond.IfTrue.Actions = LoHOCond.IfTrue.Actions.Append(dispelAct).ToArray();
            LoHOCond.IfFalse.Actions = LoHOCond.IfTrue.Actions.Append(dispelAct).ToArray();






            var LayOnHandsSpecial = Resources.GetBlueprint<BlueprintAbility>("8337cea04c8afd1428aad69defbfc365");

            Conditional LoHSCond = LayOnHandsSpecial.Components.OfType<AbilityEffectRunAction>().First().Actions.Actions.OfType<Conditional>().First();

            LoHSCond.IfTrue.Actions = LoHSCond.IfTrue.Actions.Append(dispelAct).ToArray();
            LoHSCond.IfFalse.Actions = LoHSCond.IfTrue.Actions.Append(dispelAct).ToArray();

            if (ModSettings.NewContent.Mercies.IsEnabled("Ensorcelled"))
            {
                FeatureSelectionConfigurator.For("02b187038a8dce545bb34bbfb346428d").AddToFeatures(madeFeature.AssetGuidThreadSafe).Configure();
            }
        }
    }
}
