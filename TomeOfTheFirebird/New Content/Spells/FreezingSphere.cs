using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using System.Collections.Generic;
using TabletopTweaks.Core.Utilities;
using TomeOfTheFirebird.Helpers;
using TomeOfTheFirebird.Reference;
using UnityEngine;
using static TabletopTweaks.Core.MechanicsChanges.MetamagicExtention;

namespace TomeOfTheFirebird.New_Spells
{
    public class FreezingSphere
    {
        public static void Build()
        {
            Sprite freezingSphere = AssetLoader.LoadInternal(Main.TotFContext, "Spells", "FreezingSphere.png");
            BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities.AbilityConfigurator BigFreezeBuild = MakerTools.MakeSpell("FreezingSphereBig", "Freezing Sphere: Large Blast", "Freezing sphere creates a frigid globe of cold energy that streaks from your fingertips to the location you select, where it explodes in a 40-foot-radius burst, dealing 1d6 points of cold damage per caster level(maximum 20d6) to each creature in the area.A creature of the water subtype instead takes 1d8 points of cold damage per caster level (maximum 20d8) and is staggered for 1d4 rounds.", freezingSphere, SpellSchool.Evocation, LocalizedStrings.RefHalf, new Kingmaker.Localization.LocalizedString());
            BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities.AbilityConfigurator SmallFreezeBuild = MakerTools.MakeSpell("FreezingSphereSmall", "Freezing Sphere: Small Blast", "Freezing sphere creates a frigid globe of cold energy that streaks from your fingertips to the location you select, where it explodes in a 20-foot-radius burst, dealing 1d6 points of cold damage per caster level(maximum 20d6) to each creature in the area.A creature of the water subtype instead takes 1d8 points of cold damage per caster level (maximum 20d8) and is staggered for 1d4 rounds.", freezingSphere, SpellSchool.Evocation, LocalizedStrings.RefHalf, new Kingmaker.Localization.LocalizedString());
            BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities.AbilityConfigurator SelectFreezeBuild = MakerTools.MakeSpell("FreezingSphere", "Freezing Sphere", "Freezing sphere creates a frigid globe of cold energy that streaks from your fingertips to the location you select, where it explodes in a 20 or 40-foot-radius burst, dealing 1d6 points of cold damage per caster level(maximum 20d6) to each creature in the area.A creature of the water subtype instead takes 1d8 points of cold damage per caster level (maximum 20d8) and is staggered for 1d4 rounds.", freezingSphere, SpellSchool.Evocation, LocalizedStrings.RefHalf, new Kingmaker.Localization.LocalizedString());

            BigFreezeBuild.SetSpellDescriptor(SpellDescriptor.Cold);
            SmallFreezeBuild.SetSpellDescriptor(SpellDescriptor.Cold);
            SelectFreezeBuild.SetSpellDescriptor(SpellDescriptor.Cold);
            BigFreezeBuild.SetRange(AbilityRange.Long);
            SmallFreezeBuild.SetRange(AbilityRange.Long);
            SelectFreezeBuild.SetRange(AbilityRange.Long);

            BigFreezeBuild.SetSpellResistance(true);
            SmallFreezeBuild.SetSpellResistance(true);
            SelectFreezeBuild.SetSpellResistance(true);
            BigFreezeBuild.SetEffectOnAlly(AbilityEffectOnUnit.Harmful).SetEffectOnEnemy(AbilityEffectOnUnit.Harmful).AllowTargeting(true, true, true, true).SetAnimation(UnitAnimationActionCastSpell.CastAnimationStyle.Directional).SetAvailableMetamagic(Metamagic.Empower, Metamagic.Maximize, Metamagic.Quicken, Metamagic.Bolstered, Metamagic.CompletelyNormal, Metamagic.Persistent, Metamagic.Selective, (Metamagic)CustomMetamagic.Intensified, (Metamagic)CustomMetamagic.Rime, (Metamagic)CustomMetamagic.Piercing).SetLocalizedDuration(new Kingmaker.Localization.LocalizedString());
            SelectFreezeBuild.SetEffectOnAlly(AbilityEffectOnUnit.Harmful).SetEffectOnEnemy(AbilityEffectOnUnit.Harmful).AllowTargeting(true, true, true, true).SetAnimation(UnitAnimationActionCastSpell.CastAnimationStyle.Directional).SetAvailableMetamagic(Metamagic.Empower, Metamagic.Maximize, Metamagic.Quicken, Metamagic.Bolstered, Metamagic.CompletelyNormal, Metamagic.Persistent, Metamagic.Selective, (Metamagic)CustomMetamagic.Intensified, (Metamagic)CustomMetamagic.Rime, (Metamagic)CustomMetamagic.Piercing).SetLocalizedDuration(new Kingmaker.Localization.LocalizedString());
            SmallFreezeBuild.SetEffectOnAlly(AbilityEffectOnUnit.Harmful).SetEffectOnEnemy(AbilityEffectOnUnit.Harmful).AllowTargeting(true, true, true, true).SetAnimation(UnitAnimationActionCastSpell.CastAnimationStyle.Directional).SetAvailableMetamagic(Metamagic.Empower, Metamagic.Maximize, Metamagic.Quicken, Metamagic.Bolstered, Metamagic.CompletelyNormal, Metamagic.Persistent, Metamagic.Selective, (Metamagic)CustomMetamagic.Intensified, (Metamagic)CustomMetamagic.Rime, (Metamagic)CustomMetamagic.Piercing).SetLocalizedDuration(new Kingmaker.Localization.LocalizedString());

            ActionsBuilder getPayload()
            {
                ActionsBuilder standardDamageAction = ActionsBuilder.New().DealDamage(damageType: new DamageTypeDescription() { Type = DamageType.Energy, Energy = Kingmaker.Enums.Damage.DamageEnergyType.Cold }, value: new ContextDiceValue() { DiceType = DiceType.D6, DiceCountValue = new ContextValue() { ValueType = ContextValueType.Rank }, BonusValue = new() }, halfIfSaved: true, isAoE: true) ;

                ActionsBuilder waterDamageAction = ActionsBuilder.New().DealDamage(damageType: new DamageTypeDescription() { Type = DamageType.Energy, Energy = Kingmaker.Enums.Damage.DamageEnergyType.Cold }, value: new ContextDiceValue() { DiceType = DiceType.D8, DiceCountValue = new ContextValue() { ValueType = ContextValueType.Rank }, BonusValue = new() }, halfIfSaved:true, isAoE: true);


                waterDamageAction.ConditionalSaved(failed: ActionsBuilder.New().ApplyBuff("df3950af5a783bd4d91ab73eb8fa0fd3", durationValue: new ContextDurationValue() { DiceCountValue = 1, DiceType = DiceType.D4, m_IsExtendable = false }, isFromSpell: true, isNotDispelable: true));

                ConditionsBuilder isWater = ConditionsBuilder.New().HasFact("bf7ee56ec9e43c14fa17727997e91993");

                return ActionsBuilder.New().Conditional(isWater, waterDamageAction, standardDamageAction);
            }
            BigFreezeBuild.AddAbilityDeliverProjectile(lineWidth: new Kingmaker.Utility.Feet(5f), projectiles: new List<Blueprint<BlueprintProjectileReference>>() { "99be5f02870297b48b0342ba44156dc2" });
            BigFreezeBuild.AddAbilityEffectRunAction(getPayload(), savingThrowType: Kingmaker.EntitySystem.Stats.SavingThrowType.Reflex).AddContextRankConfig(ContextRankConfigs.CasterLevel(true, max: 20)).AddAbilityTargetsAround(radius: new Kingmaker.Utility.Feet(40f), spreadSpeed: new Kingmaker.Utility.Feet(50f));



            SmallFreezeBuild.AddAbilityDeliverProjectile(lineWidth: new Kingmaker.Utility.Feet(5f), projectiles: new List<Blueprint<BlueprintProjectileReference>>() { "99be5f02870297b48b0342ba44156dc2" });

            SmallFreezeBuild.AddAbilityEffectRunAction(getPayload(), savingThrowType: Kingmaker.EntitySystem.Stats.SavingThrowType.Reflex).AddContextRankConfig(ContextRankConfigs.CasterLevel(true,  max: 20)).AddAbilityTargetsAround(radius: new Kingmaker.Utility.Feet(20f), spreadSpeed: new Kingmaker.Utility.Feet(25f));
          
            BigFreezeBuild.AddCraftInfoComponent(Kingmaker.Craft.CraftAOE.AOE,savingThrow: Kingmaker.Craft.CraftSavingThrow.Reflex,spellType: Kingmaker.Craft.CraftSpellType.Damage);
            SmallFreezeBuild.AddCraftInfoComponent(Kingmaker.Craft.CraftAOE.AOE, savingThrow: Kingmaker.Craft.CraftSavingThrow.Reflex, spellType: Kingmaker.Craft.CraftSpellType.Damage);
            BlueprintAbility bigbuilt = BigFreezeBuild.Configure();
            BlueprintAbility smallbuilt = SmallFreezeBuild.Configure();

            SelectFreezeBuild.AddAbilityVariants(new List<Blueprint<BlueprintAbilityReference>>() { bigbuilt.AssetGuidThreadSafe, smallbuilt.AssetGuidThreadSafe });
            BlueprintAbility built = SelectFreezeBuild.Configure();
            if (Main.TotFContext.NewContent.Spells.IsEnabled("FreezingSphere"))
            {
                //built.AddToSpellList(SpellTools.SpellList.FrostSpiritSpellList, 6);
                built.AddToSpellList(SpellTools.SpellList.WizardSpellList, 6);
                built.AddToSpellList(SpellTools.SpellList.MagusSpellList, 6);
                built.AddToSpellSpecialization();
            }




        }



//        School evocation[cold]; Level magus 6, sorcerer/wizard 6; Subdomain ice 7; Elemental School water 6

//CASTING

//Casting Time 1 standard action
//Components V, S, F (a small crystal sphere)

//EFFECT

//Range long (400 ft. + 40 ft./level)
//Target, Effect, or Area see text
//Duration instantaneous or 1 round/level; see text
//Saving Throw Reflex half; see text; Spell Resistance yes

//DESCRIPTION

//Freezing sphere creates a frigid globe of cold energy that streaks from your fingertips to the location you select, where it explodes in a 40-foot-radius burst, dealing 1d6 points of cold damage per caster level(maximum 15d6) to each creature in the area.A creature of the water subtype instead takes 1d8 points of cold damage per caster level (maximum 15d8) and is staggered for 1d4 rounds.

//If the freezing sphere strikes a body of water or a liquid that is principally water(not including water-based creatures), it freezes the liquid to a depth of 6 inches in a 40-foot radius.This ice lasts for 1 round per caster level. Creatures that were swimming on the surface of a targeted body of water become trapped in the ice. Attempting to break free is a full-round action. A trapped creature must make a DC 25 Strength check or a DC 25 Escape Artist check to do so.

//You can refrain from firing the globe after completing the spell, if you wish. Treat this as a touch spell for which you are holding the charge. You can hold the charge for as long as 1 round per level, at the end of which time the freezing sphere bursts centered on you (and you receive no saving throw to resist its effect). Firing the globe in a later round is a standard action.
    }
}
