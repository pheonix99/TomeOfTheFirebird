using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Components;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
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
            var BigFreezeBuild = MakerTools.MakeSpell("FreezingSphereBig", "Freezing Sphere: Large Blast", "Freezing sphere creates a frigid globe of cold energy that streaks from your fingertips to the location you select, where it explodes in a 40-foot-radius burst, dealing 1d6 points of cold damage per caster level(maximum 20d6) to each creature in the area.A creature of the water subtype instead takes 1d8 points of cold damage per caster level (maximum 20d8) and is staggered for 1d4 rounds.", freezingSphere, Kingmaker.Blueprints.Classes.Spells.SpellSchool.Evocation, LocalizedStrings.RefHalf, new Kingmaker.Localization.LocalizedString());
            var SmallFreezeBuild = MakerTools.MakeSpell("FreezingSphereSmall", "Freezing Sphere: Small Blast", "Freezing sphere creates a frigid globe of cold energy that streaks from your fingertips to the location you select, where it explodes in a 20-foot-radius burst, dealing 1d6 points of cold damage per caster level(maximum 20d6) to each creature in the area.A creature of the water subtype instead takes 1d8 points of cold damage per caster level (maximum 20d8) and is staggered for 1d4 rounds.", freezingSphere, Kingmaker.Blueprints.Classes.Spells.SpellSchool.Evocation, LocalizedStrings.RefHalf, new Kingmaker.Localization.LocalizedString());
            var SelectFreezeBuild = MakerTools.MakeSpell("FreezingSphere", "Freezing Sphere", "Freezing sphere creates a frigid globe of cold energy that streaks from your fingertips to the location you select, where it explodes in a 20 or 40-foot-radius burst, dealing 1d6 points of cold damage per caster level(maximum 20d6) to each creature in the area.A creature of the water subtype instead takes 1d8 points of cold damage per caster level (maximum 20d8) and is staggered for 1d4 rounds.", freezingSphere, Kingmaker.Blueprints.Classes.Spells.SpellSchool.Evocation, LocalizedStrings.RefHalf, new Kingmaker.Localization.LocalizedString());

            BigFreezeBuild.AddSpellDescriptors(SpellDescriptor.Cold);
            SmallFreezeBuild.AddSpellDescriptors(SpellDescriptor.Cold);
            SelectFreezeBuild.AddSpellDescriptors(SpellDescriptor.Cold);
            BigFreezeBuild.SetRange(Kingmaker.UnitLogic.Abilities.Blueprints.AbilityRange.Long);
            SmallFreezeBuild.SetRange(Kingmaker.UnitLogic.Abilities.Blueprints.AbilityRange.Long);
            SelectFreezeBuild.SetRange(Kingmaker.UnitLogic.Abilities.Blueprints.AbilityRange.Long);
          
            BigFreezeBuild.ApplySpellResistance(true);
            SmallFreezeBuild.ApplySpellResistance(true);
            SelectFreezeBuild.ApplySpellResistance(true);
            BigFreezeBuild.SetEffectOn(onAlly: AbilityEffectOnUnit.Harmful, onEnemy: AbilityEffectOnUnit.Harmful).AllowTargeting(true, true, true, true).SetAnimationStyle(Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.Directional).SetMetamagics(Metamagic.Empower, Metamagic.Maximize, Metamagic.Quicken, Metamagic.Bolstered, Metamagic.CompletelyNormal, Metamagic.Persistent, Metamagic.Selective,(Metamagic)CustomMetamagic.Intensified, (Metamagic)CustomMetamagic.Rime, (Metamagic)CustomMetamagic.Piercing).SetDurationText(new Kingmaker.Localization.LocalizedString());
            SelectFreezeBuild.SetEffectOn(onAlly: AbilityEffectOnUnit.Harmful, onEnemy: AbilityEffectOnUnit.Harmful).AllowTargeting(true, true, true, true).SetAnimationStyle(Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.Directional).SetMetamagics(Metamagic.Empower, Metamagic.Maximize, Metamagic.Quicken, Metamagic.Bolstered, Metamagic.CompletelyNormal, Metamagic.Persistent, Metamagic.Selective, (Metamagic)CustomMetamagic.Intensified, (Metamagic)CustomMetamagic.Rime, (Metamagic)CustomMetamagic.Piercing).SetDurationText(new Kingmaker.Localization.LocalizedString());
            SmallFreezeBuild.SetEffectOn(onAlly: AbilityEffectOnUnit.Harmful, onEnemy: AbilityEffectOnUnit.Harmful).AllowTargeting(true, true, true, true).SetAnimationStyle(Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.Directional).SetMetamagics(Metamagic.Empower, Metamagic.Maximize, Metamagic.Quicken, Metamagic.Bolstered, Metamagic.CompletelyNormal, Metamagic.Persistent, Metamagic.Selective, (Metamagic)CustomMetamagic.Intensified, (Metamagic)CustomMetamagic.Rime, (Metamagic)CustomMetamagic.Piercing).SetDurationText(new Kingmaker.Localization.LocalizedString()); 

            var standardDamageAction = ActionsBuilder.New().DealDamage(new DamageTypeDescription() { Type = DamageType.Energy, Energy = Kingmaker.Enums.Damage.DamageEnergyType.Cold }, new Kingmaker.UnitLogic.Mechanics.ContextDiceValue() { DiceType = Kingmaker.RuleSystem.DiceType.D6, DiceCountValue = new Kingmaker.UnitLogic.Mechanics.ContextValue() { ValueType = Kingmaker.UnitLogic.Mechanics.ContextValueType.Rank } }, isAOE: true);

            var waterDamageAction = ActionsBuilder.New().DealDamage(new DamageTypeDescription() { Type = DamageType.Energy, Energy = Kingmaker.Enums.Damage.DamageEnergyType.Cold }, new Kingmaker.UnitLogic.Mechanics.ContextDiceValue() { DiceType = Kingmaker.RuleSystem.DiceType.D8, DiceCountValue = new Kingmaker.UnitLogic.Mechanics.ContextValue() { ValueType = Kingmaker.UnitLogic.Mechanics.ContextValueType.Rank } }, isAOE: true).AfterSavingThrow(ifFailed: ActionsBuilder.New().ApplyBuff("df3950af5a783bd4d91ab73eb8fa0fd3", duration: new Kingmaker.UnitLogic.Mechanics.ContextDurationValue() { DiceCountValue = 1, DiceType = Kingmaker.RuleSystem.DiceType.D4, m_IsExtendable = false }, isFromSpell: true, dispellable: false));

            var isWater = ConditionsBuilder.New().HasFact("bf7ee56ec9e43c14fa17727997e91993");

            var effectAction = ActionsBuilder.New().Conditional(isWater, waterDamageAction, standardDamageAction);

            BigFreezeBuild.AddAbilityDeliverProjectile(new Kingmaker.Utility.Feet(), new Kingmaker.Utility.Feet(5f), new string[] {"99be5f02870297b48b0342ba44156dc2" } ).RunActions(effectAction, Kingmaker.EntitySystem.Stats.SavingThrowType.Reflex).AddContextRankConfig(ContextRankConfigs.CasterLevel(true, max: 20)).AddAbilityTargetsAround(radius: new Kingmaker.Utility.Feet(40f), new Kingmaker.Utility.Feet());
            SmallFreezeBuild.AddAbilityDeliverProjectile(new Kingmaker.Utility.Feet(), new Kingmaker.Utility.Feet(5f), new string[] {"99be5f02870297b48b0342ba44156dc2" } ).RunActions(effectAction, Kingmaker.EntitySystem.Stats.SavingThrowType.Reflex).AddContextRankConfig(ContextRankConfigs.CasterLevel(true, max: 20)).AddAbilityTargetsAround(radius: new Kingmaker.Utility.Feet(20f), new Kingmaker.Utility.Feet());
            BigFreezeBuild.AddCraftInfoComponent(Kingmaker.Craft.CraftSpellType.Damage, Kingmaker.Craft.CraftSavingThrow.Reflex, Kingmaker.Craft.CraftAOE.AOE);
            SmallFreezeBuild.AddCraftInfoComponent(Kingmaker.Craft.CraftSpellType.Damage, Kingmaker.Craft.CraftSavingThrow.Reflex, Kingmaker.Craft.CraftAOE.AOE);
            var bigbuilt = BigFreezeBuild.Configure();
            var smallbuilt = SmallFreezeBuild.Configure();

            SelectFreezeBuild.AddVariants(bigbuilt.AssetGuidThreadSafe, smallbuilt.AssetGuidThreadSafe);
            var built = SelectFreezeBuild.Configure();
            if (Main.TotFContext.NewContent.Spells.IsEnabled("FreezingSphere"))
            {
                //built.AddToSpellList(SpellTools.SpellList.FrostSpiritSpellList, 6);
                built.AddToSpellList(SpellTools.SpellList.WizardSpellList, 6);
                built.AddToSpellList(SpellTools.SpellList.MagusSpellList, 6);
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
