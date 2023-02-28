using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Enums.Damage;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomeOfTheFirebird.New_Components;

namespace TomeOfTheFirebird.Modified_Content.Bloodlines
{
    class ElementalStrikesUpgrade
    {
        public static void Do()
        {
            if (Settings.IsEnabled("BuffElementalStrikes"))
            {
                //Fire Progression: 12f7b4c5d603f3744b2b1def28c0a4fa

                var baseElementalRageBuff = BuffConfigurator.For("527fe5d35a1da104490a4518ec55a0a3");


                string fireStrikesFeature = "0fb267c8f74fa5f4ea2e31b0f2384286";
                string fireStrikesBuff = "eb71b69ec2b317140b950fbc879efdc3";
                string fireStrikes20Feature = "837067e4608bc5948994d79a3f3b9e17";

                AlterBloodline(fireStrikesFeature, fireStrikesBuff, fireStrikes20Feature, DamageEnergyType.Fire);
                AlterBloodline("3e87f0f796a4eeb409a6998eedc1a5ef", "11fd8bc21f8de6a408859f8f2e845094", "c1710599b2f72e644918a3f7b0e2b44a", DamageEnergyType.Cold);
                AlterBloodline("c4617f07db3d84443b13ff71d9d396c3", "ad90034a6f8a6f144bf8f329917e1d38", "d37a8f6f5df057a4ea50b2c065288263", DamageEnergyType.Acid);
                AlterBloodline("8e1cbcd869e27b44c9af52adc384921b", "8792f9cb9a9b03d4ebb057137bf853d9", "99e577bf8876f294eaaa47dec8dae994", DamageEnergyType.Electricity);
                void AlterBloodline(string strikesBaseFeature, string strikesBuff, string strikes20Feature, DamageEnergyType energy)
                {
                    string sysname = $"ElementalStrikes{energy}BurstBuff";
                    var guid = Main.TotFContext.Blueprints.GetGUID(sysname);

                    var at20Buff = BuffConfigurator.New(sysname, guid.ToString()).SetFlags(flags: BlueprintBuff.Flags.HiddenInUi);
                    at20Buff.SetDisplayName(LocalizationTool.CreateString(sysname + ".Name", "Elemental Strikes Burst Mode", false));
                    at20Buff.SetDescription(LocalizationTool.CreateString(sysname + ".Desc", "Elemental Strikes Burst Mode (SYSTEM BUFF)", false));
                    at20Buff.AddComponent<BurstDamageComponent>(x =>
                    {
                        x.Dice = Kingmaker.RuleSystem.DiceType.D8;
                        x.Element = energy;
                    });
                    at20Buff.Configure();

                    baseElementalRageBuff.AddFactContextActions(activated: ActionsBuilder.New().Conditional(conditions: ConditionsBuilder.New().HasFact(strikesBaseFeature), ifTrue: ActionsBuilder.New().ApplyBuff(strikesBuff, ContextDuration.Fixed(0), asChild: true)).Conditional(conditions: ConditionsBuilder.New().HasFact(strikes20Feature), ifTrue: ActionsBuilder.New().ApplyBuff(sysname, ContextDuration.Fixed(0), asChild: true)), deactivated: ActionsBuilder.New().RemoveBuff(strikesBuff).RemoveBuff(sysname));



                    FeatureConfigurator.For(strikesBaseFeature).RemoveComponents(x => x is AddFeatureOnClassLevel classLevel && classLevel.BeforeThisLevel == true).Configure();
                    FeatureConfigurator.For(strikes20Feature).RemoveComponents(x => true).Configure();
                    Main.TotFContext.Logger.Log($"Buffed {energy} Elemental Strikes");
                }

                baseElementalRageBuff.Configure();
                Main.TotFContext.Logger.Log("Buffed All Elemental Strikes");
            }
            else
            {
                List<DamageEnergyType> energies = new() { DamageEnergyType.Fire, DamageEnergyType.Cold, DamageEnergyType.Electricity, DamageEnergyType.Acid };
                foreach(var energy in energies)
                {
                    string sysname = $"ElementalStrikes{energy}BurstBuff";
                    var guid = Main.TotFContext.Blueprints.GetGUID(sysname);

                    var at20Buff = BuffConfigurator.New(sysname, guid.ToString()).SetFlags(flags: BlueprintBuff.Flags.HiddenInUi).Configure();
                }
            }
        }
    }
}
