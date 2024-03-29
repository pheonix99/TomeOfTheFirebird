﻿using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using TabletopTweaks.Core.Utilities;
using TomeOfTheFirebird.Helpers;
using TomeOfTheFirebird.Reference;
using static TabletopTweaks.Core.MechanicsChanges.MetamagicExtention;

namespace TomeOfTheFirebird.New_Spells
{
    class BurstOfRadiance
    {
        public static void Make()
        {
            var flare = BlueprintTools.GetBlueprint<BlueprintAbility>("39a602aa80cc96f4597778b6d4d49c0a");
            var icon = flare.Icon;
            var flarefx = flare.GetComponent<AbilitySpawnFx>();

            var burst = MakerTools.MakeSpell("BurstOfRadiance", "Burst Of Radiance", "This spell fills the area with a brilliant flash of shimmering light.Creatures in the area are blinded for 1d4 rounds, or dazzled for 1d4 rounds if they succeed at a Reflex save. Evil creatures in the area of the burst take 1d4 points of damage per caster level (max 5d4), whether they succeed at the Reflex save or not.", icon, Kingmaker.Blueprints.Classes.Spells.SpellSchool.Evocation, LocalizedStrings.ReflexPartial, descriptors: new SpellDescriptor[] { SpellDescriptor.Good ,SpellDescriptor.Blindness } );
            if (Settings.IsEnabled("BurstOfRadiance"))
            {
                burst.AddToSpellLists(2, SpellList.Wizard, SpellList.Cleric, SpellList.Druid, SpellList.Warpriest, SpellList.Hunter);
                
            }
            burst.SetActionType(Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard);
            burst.SetType(AbilityType.Spell);
            burst.SetRange(AbilityRange.Close);
            burst.SetCanTargetPoint(true);
            burst.SetCanTargetEnemies(true);
            burst.SetCanTargetFriends(true);
            burst.SetSpellResistance(true);
            burst.SetAnimation(Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.Directional);
            burst.SetAvailableMetamagic(Metamagic.Quicken, Metamagic.Heighten, Metamagic.CompletelyNormal, Metamagic.Reach, Metamagic.Bolstered, Metamagic.Empower, Metamagic.Heighten, Metamagic.Maximize, Metamagic.Persistent, Metamagic.Selective, (Metamagic)CustomMetamagic.Flaring, (Metamagic)CustomMetamagic.Intensified, (Metamagic)CustomMetamagic.Piercing);
            ActionsBuilder burstAction = ActionsBuilder.New().Conditional(conditions: ConditionsBuilder.New().Alignment(Kingmaker.Enums.AlignmentComponent.Evil), ifTrue: ActionsBuilder.New().DealDamage(damageType: new Kingmaker.RuleSystem.Rules.Damage.DamageTypeDescription()
            {
                Type = Kingmaker.RuleSystem.Rules.Damage.DamageType.Energy,
                Energy = Kingmaker.Enums.Damage.DamageEnergyType.Divine

            }, new Kingmaker.UnitLogic.Mechanics.ContextDiceValue()
            {
                DiceType = Kingmaker.RuleSystem.DiceType.D4,
                DiceCountValue = new Kingmaker.UnitLogic.Mechanics.ContextValue()
                {
                    ValueType = Kingmaker.UnitLogic.Mechanics.ContextValueType.Rank,
                    ValueRank = Kingmaker.Enums.AbilityRankType.DamageDice
                },
                BonusValue = ContextValues.Constant(0)
            }, isAoE: true, halfIfSaved: false).ConditionalSaved(failed: ActionsBuilder.New().ApplyBuff("187f88d96a0ef464280706b63635f2af", ContextDuration.FixedDice(diceType: Kingmaker.RuleSystem.DiceType.D4)), succeed: ActionsBuilder.New().ApplyBuff("df6d1025da07524429afbae248845ecc", ContextDuration.FixedDice(diceType: Kingmaker.RuleSystem.DiceType.D4)))) ;


            burst.AddAbilityEffectRunAction(savingThrowType: Kingmaker.EntitySystem.Stats.SavingThrowType.Reflex, actions: burstAction);
            burst.AddAbilityTargetsAround(radius: new Kingmaker.Utility.Feet(10f), targetType: Kingmaker.UnitLogic.Abilities.Components.TargetType.Any, spreadSpeed: new Kingmaker.Utility.Feet(10f));
            burst.AddContextRankConfig(ContextRankConfigs.CasterLevel(type: Kingmaker.Enums.AbilityRankType.DamageDice, max: 5));
            burst.AddAbilitySpawnFx(anchor: flarefx.Anchor, delay: flarefx.Delay, prefabLink: flarefx.PrefabLink);
           
            burst.AddCraftInfoComponent(aOEType: Kingmaker.Craft.CraftAOE.AOE, savingThrow: Kingmaker.Craft.CraftSavingThrow.Reflex, spellType: Kingmaker.Craft.CraftSpellType.Damage);
            var made = burst.Configure();

            
        }

        //        Burst of Radiance

        //School evocation[good, light]; Level cleric 2, druid 2, sorcerer/wizard 2

        //CASTING

        //Casting Time 1 standard action
        //Components V, S, M/DF(a piece of flint and a pinch of silver dust)

        //EFFECT

        //Range long (400 ft. + 40 ft./level)
        //Area 10-ft.-radius burst
        //Duration instantaneous
        //Saving Throw Reflex partial; Spell Resistance yes

        //DESCRIPTION

        //This spell fills the area with a brilliant flash of shimmering light.Creatures in the area are blinded for 1d4 rounds, or dazzled for 1d4 rounds if they succeed at a Reflex save. Evil creatures in the area of the burst take 1d4 points of damage per caster level (max 5d4), whether they succeed at the Reflex save or not.
    }
}
