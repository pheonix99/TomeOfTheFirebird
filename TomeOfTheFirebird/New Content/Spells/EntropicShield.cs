using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using TabletopTweaks.Core.Utilities;
using TomeOfTheFirebird.Helpers;
using TomeOfTheFirebird.Reference;
using UnityEngine;

namespace TomeOfTheFirebird.New_Content.Spells
{
    class EntropicShield
    {
        public static void Make()
        {
            Sprite entSprie = BlueprintTools.GetBlueprint<BlueprintAbility>("2433d465095a9984398a0482b1af0877").Icon;
            var maker = MakerTools.MakeSpell("EntropicShield", "Entropic Shield", "A magical field appears around you, glowing with a chaotic blast of multicolored hues. This field deflects incoming arrows, rays, and other ranged attacks. Each ranged attack directed at you for which the attacker must make an attack roll has a 20% miss chance (similar to the effects of concealment). Other attacks that simply work at a distance are not affected.", entSprie, Kingmaker.Blueprints.Classes.Spells.SpellSchool.Abjuration, new Kingmaker.Localization.LocalizedString(), LocalizedStrings.OneMinutePerLevelDuration);
            maker.SetActionType(Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard);
            maker.AllowTargeting(self: true);
            maker.SetRange(Kingmaker.UnitLogic.Abilities.Blueprints.AbilityRange.Personal);
            maker.SetAnimationStyle(Kingmaker.View.Animation.CastAnimationStyle.CastActionSelfTouch);
            maker.SetAvailableMetamagic(Metamagic.Extend, Metamagic.Heighten, Metamagic.CompletelyNormal, Metamagic.Quicken, Metamagic.Reach);

            var buffMaker = MakerTools.MakeBuff("EntropicShieldBuff", "Entropic Shield", "A magical field appears around you, glowing with a chaotic blast of multicolored hues. This field deflects incoming arrows, rays, and other ranged attacks. Each ranged attack directed at you for which the attacker must make an attack roll has a 20% miss chance (similar to the effects of concealment). Other attacks that simply work at a distance are not affected.", entSprie);
            buffMaker.AddSetAttackerMissChance(conditions: ConditionsBuilder.New(), type: Kingmaker.UnitLogic.Mechanics.Components.SetAttackerMissChance.Type.Ranged, value: new Kingmaker.UnitLogic.Mechanics.ContextValue() { Value = 20 });
            buffMaker.AddToFlags(BlueprintBuff.Flags.IsFromSpell);
            var buff = buffMaker.Configure();
            var act = ActionsBuilder.New().ApplyBuff(BlueprintTool.GetRef<BlueprintBuffReference>("EntropicShieldBuff"), durationValue: MakerTools.GetContextDurationValue(Kingmaker.UnitLogic.Mechanics.DurationRate.Minutes, true), isFromSpell: true, isNotDispelable: false, toCaster: true);
            maker.AddAbilityEffectRunAction(act);

            var build = maker.Configure();

            if (Main.TotFContext.NewContent.Spells.IsEnabled("EntropicShield"))
            {
                SpellTools.AddToSpellList(build, SpellTools.SpellList.ClericSpellList, 1);
            }
        }

    }
}
