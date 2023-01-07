using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using System.Linq;
using TomeOfTheFirebird.Helpers;

namespace TomeOfTheFirebird.Modified_Content.Classes
{
    class Paladin
    {
        public static void FixSmiteEvilExtraDamageOnFirstHit()
        {
            var HiddenPaladinFeature = Helpers.MakerTools.MakeFeature("HiddenPaladinExtraDamageOnSmiteFeature", "You Shouldn't See This", "", true).SetRanks(1).SetIsClassFeature(true).Configure();

            var PaladinSmiteEvilAbility = BlueprintTool.Get<BlueprintAbility>("7bb9eb2042e67bf489ccd1374423cdec");
            var PaladinSmiteEvilBuff = BlueprintTool.Get<BlueprintBuff>("b6570b8cbb32eaf4ca8255d0ec3310b0");

            var BonusHitBuffConfig = MakerTools.MakeBuff("HiddenPaladinExtraDamageOnSmiteBuff", "You shouldn't see this", "");
            BonusHitBuffConfig.SetFlags(BlueprintBuff.Flags.HiddenInUi);
            

            var actions = PaladinSmiteEvilAbility.GetComponent<AbilityEffectRunAction>().Actions;
            actions.Actions = actions.Actions.Concat(ActionsBuilder.New().Conditional(ConditionsBuilder.New().CasterHasFact("HiddenPaladinFeature").HasBuffFromCaster(PaladinSmiteEvilBuff), ifTrue: ActionsBuilder.New()).Build().Actions).ToArray();
        }
    }
}
