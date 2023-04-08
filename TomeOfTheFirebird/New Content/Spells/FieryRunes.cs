using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Newtonsoft.Json.Linq;
using TomeOfTheFirebird.Helpers;
using TomeOfTheFirebird.New_Components;
using TomeOfTheFirebird.Reference;
using UnityEngine;

namespace TomeOfTheFirebird.New_Spells
{
    public static class FieryRunes
    {

        //Elements that are different between the two versions
        //Records (other than for toggle and attack effect)
        //Localization
        //Spell level
        //Charges

        //Objects with two instances
        //Spell applied buff
        //Touch spell
        //Cast
        static Sprite evocIcon => BlueprintTool.Get<BlueprintProgression>("f8019b7724d72a241a97157bc37f1c3b").Icon;
        private static AbilityConfigurator MakeCast(string sysname, string touch, int spellLevel)
        {

            var guid = Main.TotFContext.Blueprints.GetGUID(sysname);
            var castRaw = AbilityConfigurator.NewSpell(sysname, guid.ToString(), SpellSchool.Evocation, true, SpellDescriptor.Fire);
            castRaw.SetDisplayName(sysname + ".Name");
            castRaw.SetDescription(sysname + ".Desc");
            castRaw.SetCanTargetSelf(true);
            castRaw.SetCanTargetFriends(true);
            castRaw.SetRange(AbilityRange.Touch);
            castRaw.SetIcon(evocIcon);
            castRaw.SetEffectOnAlly(AbilityEffectOnUnit.Helpful);
            
            castRaw.AddToSpellLists(spellLevel, SpellList.Alchemist, SpellList.Bloodrager, SpellList.Druid,SpellList.Magus, SpellList.Wizard);
            castRaw.AddAbilityEffectStickyTouch(touchDeliveryAbility: touch);

            return castRaw;
        }

        private static BuffConfigurator MakeBuff(string sysname)
        {
            var guid = Main.TotFContext.Blueprints.GetGUID(sysname + "Buff");
            var buff = BuffConfigurator.New(sysname + "Buff", guid.ToString());
            buff.SetDisplayName(sysname + ".Name");
            buff.SetDescription(sysname + ".Desc");
            buff.SetIcon(evocIcon);
            buff.AddAbilityResources(amount: 0, resource: "FieryRunesCharges", restoreAmount: false);

            buff.AddFacts(new() { "FieryRunesToggle" });
            buff.AddComponent<SpellstrikeAlikeComponent>(x =>
            {
                x.PayloadBlueprint = BlueprintTool.Get<BlueprintAbility>("FieryRunesAttack");
                x.Condition = ConditionsBuilder.New().HasBuff("FieryRunesAllowBuff").Build();
            });



            return buff;
        }

        private static AbilityConfigurator MakeTouch(string sysname, string buff, bool array)
        {
            var guid = Main.TotFContext.Blueprints.GetGUID(sysname + "Touch");
            var castRaw = AbilityConfigurator.NewSpell(sysname + "Touch", guid.ToString(), SpellSchool.Evocation, false, SpellDescriptor.Fire);
            castRaw.SetDisplayName(sysname + ".Name");
            castRaw.SetDescription(sysname + ".Desc");
            castRaw.SetCanTargetSelf(true);
            castRaw.SetCanTargetFriends(true);
            castRaw.SetRange(AbilityRange.Touch);
            castRaw.SetIcon(evocIcon);
            castRaw.SetEffectOnAlly(AbilityEffectOnUnit.Helpful);
            castRaw.AddAbilityDeliverTouch(touchWeapon: "bb337517547de1a4189518d404ec49d4");

            var act = ActionsBuilder.New().RemoveBuff("FieryRunesBuff").RemoveBuff("FieryRunesArrayBuff").ApplyBuff(buff, ContextDuration.Variable(ContextValues.Rank(Kingmaker.Enums.AbilityRankType.Default), Kingmaker.UnitLogic.Mechanics.DurationRate.Minutes), isFromSpell: true);
            if (array)
            {
                act.RestoreResource("FieryRunesCharges", ContextValues.Rank(Kingmaker.Enums.AbilityRankType.ProjectilesCount));
            }
            else
            {
                act.RestoreResource("FieryRunesCharges", ContextValues.Constant(1));
            }

            castRaw.AddAbilityEffectRunAction(act);
            castRaw.AddContextRankConfig(ContextRankConfigs.CasterLevel());
            if (array)
            {
                castRaw.AddContextRankConfig(new Kingmaker.UnitLogic.Mechanics.Components.ContextRankConfig()
                {
                    m_BaseValueType = Kingmaker.UnitLogic.Mechanics.Components.ContextRankBaseValueType.CasterLevel,
                    m_Type = Kingmaker.Enums.AbilityRankType.ProjectilesCount,
                    m_Progression = Kingmaker.UnitLogic.Mechanics.Components.ContextRankProgression.Custom,
                    m_CustomProgression = new Kingmaker.UnitLogic.Mechanics.Components.ContextRankConfig.CustomProgressionItem[]
                    {
                    new Kingmaker.UnitLogic.Mechanics.Components.ContextRankConfig.CustomProgressionItem
                    {
                        BaseValue= 0,
                        ProgressionValue = 1,
                    },
                    new Kingmaker.UnitLogic.Mechanics.Components.ContextRankConfig.CustomProgressionItem
                    {
                        BaseValue= 5,
                        ProgressionValue = 2,
                    },
                    new Kingmaker.UnitLogic.Mechanics.Components.ContextRankConfig.CustomProgressionItem
                    {
                        BaseValue= 10,
                        ProgressionValue = 3,
                    },
                    new Kingmaker.UnitLogic.Mechanics.Components.ContextRankConfig.CustomProgressionItem
                    {
                        BaseValue= 15,
                        ProgressionValue = 4,
                    },
                    new Kingmaker.UnitLogic.Mechanics.Components.ContextRankConfig.CustomProgressionItem
                    {
                        BaseValue= 20,
                        ProgressionValue = 5,
                    }
                    }

                });
            }
            return castRaw;

        }

        

        public static void Make()
        {
            
            var guid = Main.TotFContext.Blueprints.GetGUID("FieryRunesCharges");
            var resourceConfig = AbilityResourceConfigurator.New("FieryRunesCharges", guid.ToString());
            resourceConfig.SetMax(20);
            resourceConfig.SetUseMax(true);

            resourceConfig.Configure();
            if (Settings.IsEnabled("FieryRunes"))
            {
                var fieryRunesAttack = MakerTools.MakeSpell("FieryRunesAttack", LocalizationTool.GetString("FieryRunesDischarge.Name"), "", evocIcon, Kingmaker.Blueprints.Classes.Spells.SpellSchool.Evocation, null, descriptors: SpellDescriptor.Fire);
                fieryRunesAttack.AddAbilityEffectRunAction(ActionsBuilder.New().DealDamage(new Kingmaker.RuleSystem.Rules.Damage.DamageTypeDescription() { Type = Kingmaker.RuleSystem.Rules.Damage.DamageType.Energy, Energy = Kingmaker.Enums.Damage.DamageEnergyType.Fire }, new Kingmaker.UnitLogic.Mechanics.ContextDiceValue() { DiceType = Kingmaker.RuleSystem.DiceType.D4, DiceCountValue = ContextValues.Rank(Kingmaker.Enums.AbilityRankType.DamageDice), BonusValue = ContextValues.Rank(Kingmaker.Enums.AbilityRankType.DamageDice) }));
                fieryRunesAttack.AddContextRankConfig(new Kingmaker.UnitLogic.Mechanics.Components.ContextRankConfig()
                {
                    m_Type = Kingmaker.Enums.AbilityRankType.DamageDice,
                    m_BaseValueType = Kingmaker.UnitLogic.Mechanics.Components.ContextRankBaseValueType.CasterLevel,
                    m_Progression = Kingmaker.UnitLogic.Mechanics.Components.ContextRankProgression.OnePlusDiv2,
                    m_Max = 5
                });
                fieryRunesAttack.AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: "FieryRunesCharges");
                fieryRunesAttack.Configure();
                var allowBuff = MakerTools.MakeBuff("FieryRunesAllowBuff", "FieryRunesAllowBuff", "");


                allowBuff.Configure();

                var toggle = MakerTools.MakeToggle("FieryRunesToggle", LocalizationTool.GetString("FieryRunes.Name"), LocalizationTool.GetString("FieryRunes.Desc"), evocIcon);
                toggle.SetBuff("FieryRunesAllowBuff");
                toggle.Configure();


                var regularBuff = MakeBuff("FieryRunes");
                var arrayBuff = MakeBuff("FieryRuneArray");

                regularBuff.Configure();
                arrayBuff.Configure();

                var regularTouch = MakeTouch("FieryRunes", "FieryRunesBuff", false);
                var arrayTouch = MakeTouch("FieryRuneArray", "FieryRuneArrayBuff", false);

                MakeCast("FieryRunes", "FieryRunesTouch", 2).Configure();
                MakeCast("FieryRuneArray", "FieryRuneArrayTouch", 4).Configure();

            }
            else
            {
                MakerTools.MakeSpell("FieryRunesAttack", LocalizationTool.GetString("FieryRunesDischarge.Name"), "", null, Kingmaker.Blueprints.Classes.Spells.SpellSchool.Evocation, null, descriptors: SpellDescriptor.Fire).Configure();
                MakerTools.MakeBuff("FieryRunesAllowBuff", "FieryRunesAllowBuff", "").Configure();
                MakerTools.MakeToggle("FieryRunesToggle", LocalizationTool.GetString("FieryRunes.Name"), LocalizationTool.GetString("FieryRunes.Desc")).Configure();

                MakerTools.MakeBuffWithLocalizationTools("FieryRunesBuff", LocalizationTool.GetString("FieryRunes.Name"), LocalizationTool.GetString("FieryRunes.Desc"), evocIcon).Configure(); 
                MakerTools.MakeBuffWithLocalizationTools("FieryRuneArrayBuff", LocalizationTool.GetString("FieryRuneArray.Name"), LocalizationTool.GetString("FieryRuneArray.Desc"), evocIcon).Configure();

                
                AbilityConfigurator.New("FieryRunesTouch", Main.TotFContext.Blueprints.GetGUID("FieryRunesTouch").ToString()).Configure();
                AbilityConfigurator.New("FieryRuneArrayTouch", Main.TotFContext.Blueprints.GetGUID("FieryRuneArrayTouch").ToString()).Configure();

                AbilityConfigurator.New("FieryRunes", Main.TotFContext.Blueprints.GetGUID("FieryRunes").ToString()).Configure();
                AbilityConfigurator.New("FieryRuneArray", Main.TotFContext.Blueprints.GetGUID("FieryRuneArray").ToString()).Configure();

            }
        }

       

//        Fiery Runes

//School evocation[fire]; Level alchemist 2, bloodrager 2, druid 2, magus 2, sorcerer/wizard 2

//CASTING

//Casting Time1 standard action
//Components V, S

//EFFECT

//Range touch
//Target melee weapon touched
//Duration 1 minute/level or until discharged(see text)
//Saving Throw none; Spell Resistance yes(see text)

//DESCRIPTION

//You charge a weapon with a magic rune of fire.

//When the wielder of the weapon successfully strikes a foe in melee with the weapon, the wielder can discharge the rune as a swift action to deal 1d4+1 points of fire damage to the target.This damage isn’t multiplied on a critical hit.If the target has spell resistance, you attempt a caster level check (1d20 + caster level) against that spell resistance when the rune is discharged.If the rune is successfully resisted, the spell is dispelled; otherwise, the rune deals damage normally.

//For every 2 caster levels beyond 3rd the caster possesses, the rune deals an additional 1d4+1 points of fire damage(2d4+2 at caster level 5th, 3d4+3 at 7th, and so on) to a maximum of 5d4+5 points of fire damage at caster level 11th.
//Balance Adjustment: Multiply On Critical Hit - this is Scorching Touch (fire) that's increased a level to allow for 'hang' shenanigans. Make activation free action toggle with 'smart' rules (don't activate if target has fire immunity or resist above damage limit

        //Firey Rune Array
        //Level 4, as Fiery Runes but one rune per 4 CL
        //
    }
}
