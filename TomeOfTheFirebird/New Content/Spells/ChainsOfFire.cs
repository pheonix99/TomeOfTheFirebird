using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Components;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTweaks.Utilities;
using TomeOfTheFirebird.Config;
using TomeOfTheFirebird.Helpers;
using TomeOfTheFirebird.Reference;
using UnityEngine;

namespace TomeOfTheFirebird.New_Spells
{
    static class ChainsOfFire
    {
        public static void BuildSpell()
        {
            var ChainLightning = Resources.GetBlueprint<BlueprintAbility>("645558d63604747428d55f0dd3a4cb58");
            Sprite ChainsOfFireSprite = ChainLightning.Icon;
            BlueprintProjectile ScorchingRayBeam = Resources.GetBlueprint<BlueprintProjectile>("8cc159ce94d29fe46a94b80ce549161f");
            
            var ChainsMaker = MakerTools.MakeSpell("ChainsOfFire", "Chains Of Fire", $"This spell functions like chain lightning, except as noted above, and the spell deals fire damage instead of electricity damage. \n \nChain Lightning: {ChainLightning.Description}", ChainsOfFireSprite, SpellSchool.Evocation, LocalizedStrings.RefHalf, new Kingmaker.Localization.LocalizedString());
            ChainsMaker.SetRange(AbilityRange.Medium);
            ChainsMaker.AllowTargeting(enemies: true);
            ChainsMaker.ApplySpellResistance(true);
            ChainsMaker.SetEffectOn(onEnemy: AbilityEffectOnUnit.Harmful);
            ChainsMaker.SetAnimationStyle(Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.Directional);
            ChainsMaker.SetMetamagics(Metamagic.Empower, Metamagic.Maximize, Metamagic.Quicken, Metamagic.Bolstered, Metamagic.CompletelyNormal, Metamagic.Persistent);
            
            //ChainsMaker.SetIcon(ChainsOfFireSprite);
     
            
            ChainsMaker.AddSpellDescriptors(SpellDescriptor.Fire);
            ChainsMaker.AddAbilityEffectRunActionOnClickedTarget(ActionsBuilder.New().DealDamage(new Kingmaker.RuleSystem.Rules.Damage.DamageTypeDescription() { Energy = Kingmaker.Enums.Damage.DamageEnergyType.Fire }, new Kingmaker.UnitLogic.Mechanics.ContextDiceValue() { DiceType = Kingmaker.RuleSystem.DiceType.D6, DiceCountValue = new Kingmaker.UnitLogic.Mechanics.ContextValue() { ValueType = Kingmaker.UnitLogic.Mechanics.ContextValueType.Rank }, BonusValue = new Kingmaker.UnitLogic.Mechanics.ContextValue() { ValueType = Kingmaker.UnitLogic.Mechanics.ContextValueType.Shared } }, dealHalfIfSaved: true, isAOE: true)).AddContextRankConfig(ContextRankConfigs.CasterLevel(type: Kingmaker.Enums.AbilityRankType.DamageDice, min: 1, max: 20)).AddContextRankConfig(ContextRankConfigs.CasterLevel(min: 1, max: 2, type: Kingmaker.Enums.AbilityRankType.ProjectilesCount, useMax: true)).AddAbilityDeliverChain(radius: new Kingmaker.Utility.Feet(30), projectile: "8cc159ce94d29fe46a94b80ce549161f", projectileFirst: "8cc159ce94d29fe46a94b80ce549161f", targetsCount: new ContextValue() { ValueType = ContextValueType.Rank, ValueRank = Kingmaker.Enums.AbilityRankType.ProjectilesCount });
            ChainsMaker.AddCraftInfoComponent(Kingmaker.Craft.CraftSpellType.Damage, Kingmaker.Craft.CraftSavingThrow.Reflex, Kingmaker.Craft.CraftAOE.AOE);
            var made = ChainsMaker.Configure();



            if (ModSettings.NewContent.Spells.IsEnabled("ChainsOfFire"))
            {
                made.AddToSpellList(SpellTools.SpellList.WizardSpellList, 6);
                made.AddToSpellList(SpellTools.SpellList.MagusSpellList, 6);

            }
          
        }


//        Chains of Fire

//School evocation[fire]; Level magus 6, sorcerer/wizard 6

//CASTING

//Casting Time 1 standard action
//Components V, S, F (a drop of oil and a small piece of flint)

//EFFECT

//Range medium(100 ft. + 10 ft./level)
//Targets one primary target, plus one secondary target/level(each of which must be within 30 ft.of the primary target)
//Duration instantaneous
//Saving Throw Reflex half; Spell Resistance yes

//DESCRIPTION

//This spell functions like chain lightning, except as noted above, and the spell deals fire damage instead of electricity damage.
    }
}
