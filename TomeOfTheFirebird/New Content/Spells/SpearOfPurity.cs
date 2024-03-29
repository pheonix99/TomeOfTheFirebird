﻿using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using TabletopTweaks.Core.Utilities;
using TomeOfTheFirebird.Helpers;
using TomeOfTheFirebird.Reference;
using UnityEngine;
using static TabletopTweaks.Core.MechanicsChanges.MetamagicExtention;
using BlueprintCore.Utils;
using System.Collections.Generic;
using Kingmaker.Visual.Animation.Kingmaker.Actions;

namespace TomeOfTheFirebird.New_Spells
{
    class SpearOfPurity
    {
        public static void BuildSpearOfPurity()
        {
            Sprite sprite = AssetLoader.LoadInternal(Main.TotFContext, "Spells", "SpearOfPurity.png"); 
            string desc = "You hurl a pure white or golden spear of light from your holy symbol, affecting any one target within range as a ranged touch attack.\n\nAn evil creature struck by the spear takes 1d8 points of damage per two caster levels (maximum 5d8). An evil outsider instead takes 1d6 points of damage per caster level(maximum 10d6) and is blinded for 1 round.A successful Will save reduces the damage to half and negates the blinded effect. This spell deals only half damage to creatures that are neither evil nor good, and they are not blinded. The spear has no effect on good creatures.";
            AbilityConfigurator builder = MakerTools.MakeSpell("SpearOfPurity", "Spear Of Purity", desc, sprite, Kingmaker.Blueprints.Classes.Spells.SpellSchool.Evocation, LocalizedStrings.WillPartial, new Kingmaker.Localization.LocalizedString());
            string blind = "187f88d96a0ef464280706b63635f2af";
            builder.SetRange(AbilityRange.Close);
            builder.AllowTargeting(enemies: true, self: true);//No idea why this can be self-targeted - possibly related to eldritch archer logic? Ported from Arrow Of Law
            builder.SetSpellResistance(true);
            builder.SetEffectOnEnemy( AbilityEffectOnUnit.Harmful);
            builder.SetAnimation(UnitAnimationActionCastSpell.CastAnimationStyle.Directional);
            builder.SetActionType(Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard);
            builder.SetAvailableMetamagic(new Metamagic[] { Metamagic.Empower, Metamagic.Maximize, Metamagic.Quicken, Metamagic.Heighten, Metamagic.Reach, Metamagic.CompletelyNormal, Metamagic.Bolstered, Metamagic.Persistent, (Metamagic)CustomMetamagic.Piercing, (Metamagic)CustomMetamagic.Intensified });
        
            void BlindEff(ActionsBuilder b)
            {
                b.ConditionalSaved(failed: ActionsBuilder.New().ApplyBuff(blind, durationValue:new ContextDurationValue() { m_IsExtendable = true, BonusValue = 1  }, isFromSpell: true, isNotDispelable:false));
            }
            ContextDiceValue evilOutsiderDice = new ContextDiceValue()
            {
                DiceType = Kingmaker.RuleSystem.DiceType.D6,
                DiceCountValue = new ContextValue()
                {
                    ValueType = ContextValueType.Rank,
                    ValueRank = Kingmaker.Enums.AbilityRankType.DamageDice,
                    ValueShared = AbilitySharedValue.DamageBonus

                },
                BonusValue = new ContextValue()
                {
                    ValueShared = AbilitySharedValue.DamageBonus
                }
            };

            ActionsBuilder ifEvilOutsider = ActionsBuilder.New().DealDamage(new Kingmaker.RuleSystem.Rules.Damage.DamageTypeDescription() {Type = Kingmaker.RuleSystem.Rules.Damage.DamageType.Energy, Energy = Kingmaker.Enums.Damage.DamageEnergyType.Holy, Common = new Kingmaker.RuleSystem.Rules.Damage.DamageTypeDescription.CommomData() {Alignment = Kingmaker.Enums.Damage.DamageAlignment.Good }  }, evilOutsiderDice, halfIfSaved:true);
            BlindEff(ifEvilOutsider);

            ContextDiceValue vanillaEvilDice = new ContextDiceValue()
            {
                DiceType = Kingmaker.RuleSystem.DiceType.D8,
                DiceCountValue = new ContextValue()
                {
                    ValueType = ContextValueType.Rank

                },
                BonusValue = new ContextValue()
                {
                    
                }
            };

            ActionsBuilder ifVanillaEvil = ActionsBuilder.New().DealDamage(new Kingmaker.RuleSystem.Rules.Damage.DamageTypeDescription() { Type = Kingmaker.RuleSystem.Rules.Damage.DamageType.Energy, Energy = Kingmaker.Enums.Damage.DamageEnergyType.Holy, Common = new Kingmaker.RuleSystem.Rules.Damage.DamageTypeDescription.CommomData() { Alignment = Kingmaker.Enums.Damage.DamageAlignment.Good } }, vanillaEvilDice, halfIfSaved:true);
            BlindEff(ifVanillaEvil);

            ActionsBuilder ifEvil = ActionsBuilder.New().Conditional(ConditionsBuilder.New().CharacterClass(false, "92ab5f2fe00631b44810deffcc1a97fd"), ifEvilOutsider, ifVanillaEvil);
            ActionsBuilder ifNeutral = ActionsBuilder.New().DealDamage(new Kingmaker.RuleSystem.Rules.Damage.DamageTypeDescription() { Type = Kingmaker.RuleSystem.Rules.Damage.DamageType.Energy, Energy = Kingmaker.Enums.Damage.DamageEnergyType.Holy, Common = new Kingmaker.RuleSystem.Rules.Damage.DamageTypeDescription.CommomData() { Alignment = Kingmaker.Enums.Damage.DamageAlignment.Good } }, new ContextDiceValue() { DiceType = Kingmaker.RuleSystem.DiceType.D8, DiceCountValue = new ContextValue() { ValueType = Kingmaker.UnitLogic.Mechanics.ContextValueType.Rank } }, half:true, halfIfSaved: true);
            ActionsBuilder ifNotEvil = ActionsBuilder.New().Conditional(ConditionsBuilder.New().Alignment(Kingmaker.Enums.AlignmentComponent.Good, false), ifFalse: ifNeutral );

            ActionsBuilder act = ActionsBuilder.New().Conditional(ConditionsBuilder.New().Alignment(Kingmaker.Enums.AlignmentComponent.Evil, false), ifEvil, ifNotEvil);
          
            builder.AddAbilityEffectRunAction(act, savingThrowType: Kingmaker.EntitySystem.Stats.SavingThrowType.Will);
            builder.AddAbilityDeliverProjectile(lineWidth: new Kingmaker.Utility.Feet(5f), projectiles: new List<Blueprint<Kingmaker.Blueprints.BlueprintProjectileReference>>() { "d543d55f7fdb60340af40ea8fc5e686d" }, needAttackRoll: true, weapon: "f6ef95b1f7bb52b408a5b345a330ffe8");
            builder.AddContextRankConfig(new Kingmaker.UnitLogic.Mechanics.Components.ContextRankConfig() { m_Progression = Kingmaker.UnitLogic.Mechanics.Components.ContextRankProgression.Div2, m_UseMax = true, m_Max = 5 });
            builder.AddContextRankConfig(new Kingmaker.UnitLogic.Mechanics.Components.ContextRankConfig() {  m_UseMax = true, m_Max = 10, m_Type = Kingmaker.Enums.AbilityRankType.DamageDice });
            builder.AddSpellDescriptorComponent(SpellDescriptor.Good);
            builder.AddCraftInfoComponent(Kingmaker.Craft.CraftAOE.None, savingThrow: Kingmaker.Craft.CraftSavingThrow.Will,spellType:  Kingmaker.Craft.CraftSpellType.Damage);

            if (Settings.IsEnabled("SpearOfPurity"))
            {
                builder.AddToSpellLists(2, SpellList.Cleric, SpellList.Angel);
              

            }
            BlueprintAbility result = builder.Configure();

            


        }

//        Spear of Purity

//School evocation[good]; Level cleric/oracle 2

//CASTING

//Casting Time 1 standard action
//Components V, S, DF

//EFFECT

//Range close(25 ft. + 5 ft./2 levels)
//Effect spear-shaped projectile of good energy
//Duration instantaneous(1 round)
//Saving Throw Will partial(see text); Spell Resistance yes

//DESCRIPTION

//You hurl a pure white or golden spear of light from your holy symbol, affecting any one target within range as a ranged touch attack.

//An evil creature struck by the spear takes 1d8 points of damage per two caster levels (maximum 5d8). An evil outsider instead takes 1d6 points of damage per caster level(maximum 10d6) and is blinded for 1 round.A successful Will save reduces the damage to half and negates the blinded effect.This spell deals only half damage to creatures that are neither evil nor good, and they are not blinded.The spear has no effect on good creatures.
    }
}
