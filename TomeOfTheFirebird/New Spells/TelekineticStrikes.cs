﻿using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTweaks.Utilities;
using TomeOfTheFirebird.Components;
using TomeOfTheFirebird.Config;
using TomeOfTheFirebird.Helpers;
using TomeOfTheFirebird.Reference;
using UnityEngine;

namespace TomeOfTheFirebird.New_Spells
{
    class TelekineticStrikes
    {

        public static void BuildSpell()
        {
            Sprite TKStrikeSprite = Resources.GetBlueprint<BlueprintAbility>("810992c76efdde84db707a0444cf9a1c").Icon;//Transmutation school TK PUUUUNCH
            var TKStrikeBuilder = MakerTools.MakeSpell("TelekineticStrikes", "Telekinetic Strike", "The touched creature’s limbs are charged with telekinetic force. \n \n For the duration of the spell, the target’s unarmed attacks or natural weapons deal an additional 1d4 points of force damage on each successful unarmed melee attack.", TKStrikeSprite, SpellSchool.Evocation);
            var TKStrikeBuilderCast = MakerTools.MakeSpell("TelekineticStrikesCast", "Telekinetic Strike", "The touched creature’s limbs are charged with telekinetic force. \n \n For the duration of the spell, the target’s unarmed attacks or natural weapons deal an additional 1d4 points of force damage on each successful unarmed melee attack.", TKStrikeSprite, SpellSchool.Evocation);
       
            TKStrikeBuilder.AddSpellDescriptors(SpellDescriptor.Force);
            TKStrikeBuilderCast.AddSpellDescriptors(SpellDescriptor.Force);
            TKStrikeBuilder.SetDurationText(LocalizedStrings.OneMinutePerLevelDuration);
            TKStrikeBuilderCast.SetDurationText(LocalizedStrings.OneMinutePerLevelDuration);
            TKStrikeBuilder.AllowTargeting(false, false, true, true);
            TKStrikeBuilderCast.AllowTargeting(false, false, true, true);
            TKStrikeBuilder.SetEffectOn(AbilityEffectOnUnit.Helpful);
            TKStrikeBuilderCast.SetEffectOn(AbilityEffectOnUnit.Helpful);
           
            TKStrikeBuilder.SetAnimationStyle(Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.Touch);
            TKStrikeBuilderCast.SetAnimationStyle(Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.Touch);
            TKStrikeBuilder.SetActionType(Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard);
            TKStrikeBuilderCast.SetActionType(Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard);
            TKStrikeBuilder.SetMetamagics(Metamagic.Quicken, Metamagic.Heighten, Metamagic.Extend, Metamagic.CompletelyNormal, Metamagic.Reach);
            TKStrikeBuilderCast.SetMetamagics(Metamagic.Quicken, Metamagic.Heighten, Metamagic.Extend, Metamagic.CompletelyNormal, Metamagic.Reach);

            TKStrikeBuilder.SetSavingThrowText(new Kingmaker.Localization.LocalizedString());
            TKStrikeBuilderCast.SetSavingThrowText(new Kingmaker.Localization.LocalizedString());
            
            var TKStrikeBuff = MakerTools.MakeBuff("TelekineticStrikesBuff", "Telekinetic Strikes", "Your limbs are charged with telekinetic force. \n \n For the duration of the spell,  your unarmed attacks or natural weapons deal an additional 1d4 points of force damage on each successful unarmed melee attack.", TKStrikeSprite);
            var allowed_categories = new WeaponCategory[] { WeaponCategory.Claw, WeaponCategory.Bite, WeaponCategory.Gore, WeaponCategory.OtherNaturalWeapons, WeaponCategory.UnarmedStrike, WeaponCategory.Tail };
            ContextWeaponCategoryEnergyDamageDice dmg = new ContextWeaponCategoryEnergyDamageDice()
            {
                categories = allowed_categories,
                EnergyDamageDice = new Kingmaker.RuleSystem.DiceFormula() { m_Dice = Kingmaker.RuleSystem.DiceType.D4, m_Rolls = 1},
                Element = new Kingmaker.RuleSystem.Rules.Damage.DamageTypeDescription()
                {
                    Type = Kingmaker.RuleSystem.Rules.Damage.DamageType.Force
                }
            };
            TKStrikeBuff.AddComponent(dmg);
            TKStrikeBuff.AddToFlags(flags: BlueprintBuff.Flags.IsFromSpell);
            var buildbuff = TKStrikeBuff.Configure();
            
            TKStrikeBuilder.RunActions(ActionsBuilder.New().ApplyBuff(buildbuff.AssetGuidThreadSafe, duration: MakerTools.GetContextDurationValue(Kingmaker.UnitLogic.Mechanics.DurationRate.Minutes, true)));

            var builtTouch = TKStrikeBuilder.Configure();
            TKStrikeBuilderCast.AddAbilityEffectStickyTouch(builtTouch.AssetGuidThreadSafe);

            var builtCast = TKStrikeBuilderCast.Configure();

            if (ModSettings.NewContent.Spells.IsEnabled("TelekineticStrikes"))
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
