using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using TabletopTweaks.Core.Utilities;
using TomeOfTheFirebird.Components;
using TomeOfTheFirebird.Helpers;
using TomeOfTheFirebird.Reference;
using UnityEngine;

namespace TomeOfTheFirebird.New_Spells
{
    class TelekineticStrikes
    {

        public static void BuildSpell()
        {
            Sprite TKStrikeSprite = BlueprintTools.GetBlueprint<BlueprintAbility>("810992c76efdde84db707a0444cf9a1c").Icon;//Transmutation school TK PUUUUNCH
            BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities.AbilityConfigurator TKStrikeBuilder = MakerTools.MakeSpell("TelekineticStrikes", "Telekinetic Strikes", "The touched creature’s limbs are charged with telekinetic force. \n \n For the duration of the spell, the target’s unarmed attacks or natural weapons deal an additional 1d4 points of force damage on each successful unarmed melee attack.", TKStrikeSprite, SpellSchool.Evocation, new Kingmaker.Localization.LocalizedString(), LocalizedStrings.OneMinutePerLevelDuration);
            BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities.AbilityConfigurator TKStrikeBuilderCast = MakerTools.MakeSpell("TelekineticStrikesCast", "Telekinetic Strikes", "The touched creature’s limbs are charged with telekinetic force. \n \n For the duration of the spell, the target’s unarmed attacks or natural weapons deal an additional 1d4 points of force damage on each successful unarmed melee attack.", TKStrikeSprite, SpellSchool.Evocation, new Kingmaker.Localization.LocalizedString(), LocalizedStrings.OneMinutePerLevelDuration);

            TKStrikeBuilder.AddSpellDescriptorComponent(SpellDescriptor.Force);
            TKStrikeBuilderCast.AddSpellDescriptorComponent(SpellDescriptor.Force);

            TKStrikeBuilder.AllowTargeting(false, false, true, true);
            TKStrikeBuilderCast.AllowTargeting(false, false, true, true);
            TKStrikeBuilder.SetEffectOnAlly (AbilityEffectOnUnit.Helpful);
            TKStrikeBuilderCast.SetEffectOnAlly(AbilityEffectOnUnit.Helpful);

            TKStrikeBuilder.SetAnimation(UnitAnimationActionCastSpell.CastAnimationStyle.Touch);
            TKStrikeBuilderCast.SetAnimation(UnitAnimationActionCastSpell.CastAnimationStyle.Touch);
            TKStrikeBuilder.SetActionType(Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard);
            TKStrikeBuilderCast.SetActionType(Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard);
            TKStrikeBuilder.SetAvailableMetamagic(Metamagic.Quicken, Metamagic.Heighten, Metamagic.Extend, Metamagic.CompletelyNormal, Metamagic.Reach);
            TKStrikeBuilderCast.SetAvailableMetamagic(Metamagic.Quicken, Metamagic.Heighten, Metamagic.Extend, Metamagic.CompletelyNormal, Metamagic.Reach);

            TKStrikeBuilder.SetLocalizedSavingThrow(new Kingmaker.Localization.LocalizedString());
            TKStrikeBuilderCast.SetLocalizedSavingThrow(new Kingmaker.Localization.LocalizedString());

            BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs.BuffConfigurator TKStrikeBuff = MakerTools.MakeBuff("TelekineticStrikesBuff", "Telekinetic Strikes", "Your limbs are charged with telekinetic force. \n \n For the duration of the spell,  your unarmed attacks or natural weapons deal an additional 1d4 points of force damage on each successful unarmed melee attack.", TKStrikeSprite);
            WeaponCategory[] allowed_categories = new WeaponCategory[] { WeaponCategory.Claw, WeaponCategory.Bite, WeaponCategory.Gore, WeaponCategory.OtherNaturalWeapons, WeaponCategory.UnarmedStrike, WeaponCategory.Tail };
            ContextWeaponCategoryExtraDamageDice dmg = new ContextWeaponCategoryExtraDamageDice()
            {
                categories = allowed_categories,
                DamageDice = new Kingmaker.RuleSystem.DiceFormula() { m_Dice = Kingmaker.RuleSystem.DiceType.D4, m_Rolls = 1},
                Element = new Kingmaker.RuleSystem.Rules.Damage.DamageTypeDescription()
                {
                    Type = Kingmaker.RuleSystem.Rules.Damage.DamageType.Force
                }
            };
            TKStrikeBuff.AddComponent(dmg);
            //TKStrikeBuff.AdditionalDiceOnAttack(new Kingmaker.Utility.Feet(0f), new DamageTypeDescription() { Type = DamageType.Force }, onHit: true, allNaturalAndUnarmed: true, value: new Kingmaker.UnitLogic.Mechanics.ContextDiceValue() { DiceType = Kingmaker.RuleSystem.DiceType.D4, DiceCountValue = 1 }, initiatorConditions: ConditionsBuilder.New(), targetConditions: ConditionsBuilder.New());
            TKStrikeBuff.AddToFlags(flags: BlueprintBuff.Flags.IsFromSpell);
            BlueprintBuff buildbuff = TKStrikeBuff.Configure();
            
            TKStrikeBuilder.AddAbilityEffectRunAction(ActionsBuilder.New().ApplyBuff(buildbuff.AssetGuidThreadSafe, durationValue: MakerTools.GetContextDurationValue(Kingmaker.UnitLogic.Mechanics.DurationRate.Minutes, true)));
            TKStrikeBuilder.AddAbilityDeliverTouch(touchWeapon: "bb337517547de1a4189518d404ec49d4");
            BlueprintAbility builtTouch = TKStrikeBuilder.Configure();
            
            TKStrikeBuilderCast.AddAbilityEffectStickyTouch(touchDeliveryAbility: builtTouch.AssetGuidThreadSafe);
            TKStrikeBuilderCast.AddCraftInfoComponent(Kingmaker.Craft.CraftAOE.None, savingThrow: Kingmaker.Craft.CraftSavingThrow.None,spellType: Kingmaker.Craft.CraftSpellType.Buff);
            BlueprintAbility builtCast = TKStrikeBuilderCast.Configure();
            
            if (Settings.IsEnabled("TelekineticStrikes"))
            {
                builtCast.AddToSpellList(SpellTools.SpellList.MagusSpellList, 2);
                builtCast.AddToSpellList(SpellTools.SpellList.WizardSpellList, 2);
                
            }

        }
        //        Telekinetic Strikes

        //School evocation[force]; Level magus 2, psychic 2, sorcerer/ wizard 2

        //CASTING

        //Casting Time 1 standard action
        //Components V, S

        //EFFECT

        //Range touch
        //Target one creature
        //Duration 1 minute/level
        //Saving Throw Will negates(harmless); Spell Resistance yes(harmless)

        //DESCRIPTION

        //The touched creature’s limbs are charged with telekinetic force.

        //For the duration of the spell, the target’s unarmed attacks or natural weapons deal an additional 1d4 points of force damage on each successful unarmed melee attack.
    }
}
