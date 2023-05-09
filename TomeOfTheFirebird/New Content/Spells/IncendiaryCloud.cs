using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomeOfTheFirebird.Helpers;

namespace TomeOfTheFirebird.New_Content.Spells
{
    class IncendiaryCloud
    {

        public static void Make()
        {
            //On hold until Fog Cloud Stuff implemented
            if (Settings.IsEnabled("IncendiaryCloud"))
            {
                var icon = BlueprintTool.Get<BlueprintAbility>("ba303565ad91ae542ac7eba89f59a9c4").Icon;
                var spellConfig = AbilityConfigurator.NewSpell("IncendiaryCloud", Main.TotFContext.Blueprints.GetGUID("IncendiaryCloud").ToString(), Kingmaker.Blueprints.Classes.Spells.SpellSchool.Conjuration, true, SpellDescriptor.Fire);
               
                var areaConfig = AbilityAreaEffectConfigurator.New("IncendiaryCloudArea", Main.TotFContext.Blueprints.GetGUID("IncendiaryCloudArea").ToString());
               
                
                spellConfig.AddToSpellLists(8, SpellList.Wizard);
                spellConfig.SetIcon(icon);
                spellConfig.AddSpellToSummoner(6);
                spellConfig.AddAbilityAoERadius(radius: new Kingmaker.Utility.Feet(20f),targetType: Kingmaker.UnitLogic.Abilities.Components.TargetType.Any);
                spellConfig.AddCraftInfoComponent(aOEType: Kingmaker.Craft.CraftAOE.AOE, savingThrow: Kingmaker.Craft.CraftSavingThrow.Reflex, spellType: Kingmaker.Craft.CraftSpellType.Debuff);
                spellConfig.SetDisplayName("IncendiaryCloud.Name").SetDescription("IncendiaryCloud.Desc");
                ActionsBuilder actionsBuilder = ActionsBuilder.New().SpawnAreaEffect(areaEffect: "IncendiaryCloudArea", durationValue: ContextDuration.Variable(value: ContextValues.Rank(Kingmaker.Enums.AbilityRankType.Default), rate: Kingmaker.UnitLogic.Mechanics.DurationRate.Minutes, isExtendable: true), onUnit: false);

                spellConfig.AddAbilityEffectRunAction(actionsBuilder);

                areaConfig.AddAbilityAreaEffectMovement(distancePerRound: new Kingmaker.Utility.Feet(10f));

                var damage = ActionsBuilder.New().DealDamage(damageType: DamageTypes.Energy(Kingmaker.Enums.Damage.DamageEnergyType.Fire), value: ContextDice.Value(Kingmaker.RuleSystem.DiceType.D6, diceCount: ContextValues.Constant(8)));
                areaConfig.AddAbilityAreaEffectRunAction(round:damage);
                areaConfig.Configure();
                var spell = spellConfig.Configure();

                //TODO optional adds to fire domain / flame mystery
            }
            else
            {
                AbilityConfigurator.New("IncendiaryCloud", Main.TotFContext.Blueprints.GetGUID("IncendiaryCloud").ToString()).SetDisplayName("IncendiaryCloud.Name").SetDescription("IncendiaryCloud.Desc").Configure();
                AbilityAreaEffectConfigurator.New("IncendiaryCloudArea", Main.TotFContext.Blueprints.GetGUID("IncendiaryCloudArea").ToString()).Configure();
                
            }

        }

        /*
         * Incendiary Cloud

School conjuration (creation) [fire]; Level sorcerer/wizard 8, summoner 6; Domain fire 8; Elemental School fire 8; Mystery apocalypse 8, flame 8

CASTING

Casting Time 1 standard action
Components V, S

EFFECT

Range medium (100 ft. + 10 ft./level)
Area cloud spreads in 20-ft. radius, 20 ft. high
Duration 1 round/level (D)
Saving Throw: Reflex half, see text; Spell Resistance: no

DESCRIPTION

An incendiary cloud spell creates a cloud of roiling smoke shot through with white-hot embers. The smoke obscures all sight as a fog cloud does. In addition, the white-hot embers within the cloud deal 6d6 points of fire damage to everything within the cloud on your turn each round. All targets can make Reflex saves each round to take half damage.

As with a cloudkill spell, the smoke moves away from you at 10 feet per round. Figure out the smoke’s new spread each round based on its new point of origin, which is 10 feet farther away from where you were when you cast the spell. By concentrating, you can make the cloud move as much as 60 feet each round. Any portion of the cloud that would extend beyond your maximum range dissipates harmlessly, reducing the remainder’s spread thereafter.

As with fog cloud, wind disperses the smoke, and the spell can’t be cast underwater.
         */
    }
}
