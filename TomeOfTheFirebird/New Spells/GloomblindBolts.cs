using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Components;
using BlueprintCore.Blueprints.Configurators.Abilities;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums.Damage;
using Kingmaker.Localization;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomeOfTheFirebird.Config;
using TomeOfTheFirebird.Helpers;
using TomeOfTheFirebird.Reference;
using UnityEngine;
using static Kingmaker.UnitLogic.Commands.Base.UnitCommand;

namespace TomeOfTheFirebird.New_Spells
{
    public static class GloomblindBolts
    {
        public static BlueprintAbility BuildSpell()
        {
            
            string umbralStrikeGUid = "474ed0aa656cc38499cc9a073d113716";
            Sprite gloomicon = Resources.GetBlueprint<BlueprintAbility>(umbralStrikeGUid).Icon;
            Main.Log($"Got Umbral Strike");
            string beamGUID = "72aa6191e153a31468d76668cbc72fc7"; //Enervation
            
                ConditionsBuilder undead = ConditionsBuilder.New().HasFact("734a29b693e9ec346ba2951b27987e33", true);
                Main.Log($"Built isUndead ConditionsBuilder");
                ConditionsBuilder construct = ConditionsBuilder.New().HasFact("fd389783027d63343b4a5634bd81645f", false);
                Main.Log("Built is not Construct condition");
                ContextDiceValue damage = new ContextDiceValue()
                {
                    DiceCountValue = new ContextValue() { Value = 4 },
                    DiceType = Kingmaker.RuleSystem.DiceType.D6
                };
            
                string blind = "187f88d96a0ef464280706b63635f2af";
            Main.Log("Built damage dice");
            var gloomblind = SpellMakerTools.MakeSpell("GloomblindBolts", "Gloomblind Bolts", "You create one or more bolts of negative energy infused with shadow pulled from the Shadow Plane. You can fire one bolt, plus one for every four levels beyond 5th (to a maximum of three bolts at 13th level) at the same or different targets, but all bolts must be aimed at targets within 30 feet of each other and require a ranged touch attack to hit. Each bolt deals 4d6 points of damage to a living creature or heals 4d6 points of damage to an undead creature. Furthermore, the bolt’s energy spreads over the skin of creature, possibly blinding it for a short time. Any creature struck by a bolt must succeed at a Reflex saving throw or become blinded for 1 round.", gloomicon, SpellSchool.Conjuration);


            gloomblind.SetRange(AbilityRange.Close);
            gloomblind.AllowTargeting(enemies: true, self: true);
                
                gloomblind.ApplySpellResistance(true).SetEffectOn(onEnemy: AbilityEffectOnUnit.Harmful).SetAnimationStyle(UnitAnimationActionCastSpell.CastAnimationStyle.Directional).SetActionType(CommandType.Standard).SetMetamagics(new Metamagic[] { Metamagic.Empower, Metamagic.Maximize, Metamagic.Quicken, Metamagic.Heighten, Metamagic.Reach, Metamagic.CompletelyNormal, Metamagic.Bolstered, Metamagic.Persistent });

            gloomblind.AddSpellDescriptors(new SpellDescriptor[] { SpellDescriptor.None });

            gloomblind.AddSpellListComponent(Guids.BloodragerSpellList, 3).AddSpellListComponent(Guids.MagusSpellList, 3).AddSpellListComponent(Guids.WitchSpellList, 3).AddSpellListComponent(Guids.WizSpellList, 3);

            Main.Log("Building Damage/blind living for gloomblind");
            var damageAndBlindLiving = ActionsBuilder.New().Conditional(construct, ActionsBuilder.New().DealDamage(new DamageTypeDescription() { Energy = DamageEnergyType.NegativeEnergy }, value: damage).SavingThrow(SavingThrowType.Reflex, onResult: ActionsBuilder.New().AfterSavingThrow(ifFailed: ActionsBuilder.New().ApplyBuff(blind, useDurationSeconds: true, durationSeconds: 6))));






            Main.Log("Adding effect to gloomblind");


              gloomblind.AddAbilityEffectRunActionOnClickedUnit(ActionsBuilder.New().Conditional(undead, ActionsBuilder.New().HealTarget(damage), damageAndBlindLiving));
            Main.Log("Adding Projectile To Gloomblind");
            gloomblind.AddAbilityDeliverProjectile(new Kingmaker.Utility.Feet(), new Kingmaker.Utility.Feet(5.0f), new string[] { beamGUID, beamGUID, beamGUID }, needAttackRoll: true, weapon: "f6ef95b1f7bb52b408a5b345a330ffe8", useMaxProjectilesCount: true, delayBetweenProjectiles: 0.2f);
            Main.Log("Adding CL to gloomblind");
            gloomblind.AddContextRankConfig(ContextRankConfigs.CasterLevel(max: 3, min: 1).WithStartPlusDivStepProgression(4, 3));
            Main.Log("Building Gloomblind");
            
                Main.Log("Built Gloomblind");
                return gloomblind.Configure();
            
        }

    }
}
