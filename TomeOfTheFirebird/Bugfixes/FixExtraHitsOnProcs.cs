using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils.Types;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Utility;
using System.Collections.Generic;
using System.Linq;
using TabletopTweaks.Core.Utilities;
using TomeOfTheFirebird.Components;
using TomeOfTheFirebird.New_Components;

namespace TomeOfTheFirebird.Bugfixes
{
    public static class FixExtraHitsOnProcs
    {
        public static void FixHellfireCharge()
        {
            //f88081f3d2ed69c429736051f2fb80ae
        }

        public static void FixFirebrand()
        {
            if (Settings.IsEnabled("FixExtraHitsFirebrand"))
            {
                Main.TotFContext.Logger.Log("Fixing Firebrand");
                BlueprintBuff firebrandBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("c6cc1c5356db4674dbd2be20ea205c86");
                if (firebrandBuff.Components.OfType<AddInitiatorAttackWithWeaponTrigger>().Any())
                {
                    Main.TotFContext.Logger.Log("Removing base weapon damage effect");
                    //firebrandBuff.Components.Remove(x => x is AddInitiatorAttackWithWeaponTrigger);
                    BuffConfigurator editer = BuffConfigurator.For(firebrandBuff.AssetGuidThreadSafe).RemoveComponents(x => x is AddInitiatorAttackWithWeaponTrigger);
                    editer.AddComponent(new ContextWeaponCategoryExtraDamageDice()
                    {
                        ToAllAttacks = true,
                        Element = new DamageTypeDescription()
                        {
                            Energy = Kingmaker.Enums.Damage.DamageEnergyType.Fire,
                            Type = DamageType.Energy,

                        },
                        DamageDice = new Kingmaker.RuleSystem.DiceFormula(1, Kingmaker.RuleSystem.DiceType.D6)
                    });
                    editer.Configure();
                }

            }
        }

        public static void FixElementalStrikes()
        {
            if (Settings.IsDisabled("FixExtraHitsElementalStrikes"))
                return;

            BuffConfigurator.For("eb71b69ec2b317140b950fbc879efdc3").RemoveComponents(x => x is AddInitiatorAttackWithWeaponTrigger).AddComponent<ContextDamageValueEnergyDamageDice>(x =>
              {
                  x.damageType = new DamageTypeDescription() { Type = DamageType.Energy, Energy = DamageEnergyType.Fire };
                  x.Value = new ContextDiceValue()
                  {
                      DiceCountValue = ContextValues.Rank(),
                      DiceType = Kingmaker.RuleSystem.DiceType.D6,
                      BonusValue = ContextValues.Constant(0)
                  };

              }).Configure();//Fire strikes before 20

            FeatureConfigurator.For("837067e4608bc5948994d79a3f3b9e17").RemoveComponents(x => x is AddInitiatorAttackWithWeaponTrigger).AddComponent<ContextDamageValueEnergyDamageDice>(x =>
            {
                x.damageType = new DamageTypeDescription() { Type = DamageType.Energy, Energy = DamageEnergyType.Fire };
                x.Value = new ContextDiceValue()
                {
                    DiceCountValue = ContextValues.Rank(),
                    DiceType = Kingmaker.RuleSystem.DiceType.D6,
                    BonusValue = ContextValues.Constant(0)
                };

            }).Configure();//Fire strikes at 20



            BuffConfigurator.For("11fd8bc21f8de6a408859f8f2e845094").RemoveComponents(x => x is AddInitiatorAttackWithWeaponTrigger).AddComponent<ContextDamageValueEnergyDamageDice>(x =>
            {
                x.damageType = new DamageTypeDescription() { Type = DamageType.Energy, Energy = DamageEnergyType.Cold };
                x.Value = new ContextDiceValue()
                {
                    DiceCountValue = ContextValues.Rank(),
                    DiceType = Kingmaker.RuleSystem.DiceType.D6,
                    BonusValue = ContextValues.Constant(0)
                };

            }).Configure();//Cold strikes before 20

            FeatureConfigurator.For("c1710599b2f72e644918a3f7b0e2b44a").RemoveComponents(x => x is AddInitiatorAttackWithWeaponTrigger).AddComponent<ContextDamageValueEnergyDamageDice>(x =>
            {
                x.damageType = new DamageTypeDescription() { Type = DamageType.Energy, Energy = DamageEnergyType.Cold };
                x.Value = new ContextDiceValue()
                {
                    DiceCountValue = ContextValues.Rank(),
                    DiceType = Kingmaker.RuleSystem.DiceType.D6,
                    BonusValue = ContextValues.Constant(0)
                };

            }).Configure();//Cold strikes at 20

            BuffConfigurator.For("8792f9cb9a9b03d4ebb057137bf853d9").RemoveComponents(x => x is AddInitiatorAttackWithWeaponTrigger).AddComponent<ContextDamageValueEnergyDamageDice>(x =>
            {
                x.damageType = new DamageTypeDescription() { Type = DamageType.Energy, Energy = DamageEnergyType.Electricity };
                x.Value = new ContextDiceValue()
                {
                    DiceCountValue = ContextValues.Rank(),
                    DiceType = Kingmaker.RuleSystem.DiceType.D6,
                    BonusValue = ContextValues.Constant(0)
                };

            }).Configure();//Elect strikes before 20

            FeatureConfigurator.For("99e577bf8876f294eaaa47dec8dae994").RemoveComponents(x => x is AddInitiatorAttackWithWeaponTrigger).AddComponent<ContextDamageValueEnergyDamageDice>(x =>
            {
                x.damageType = new DamageTypeDescription() { Type = DamageType.Energy, Energy = DamageEnergyType.Electricity };
                x.Value = new ContextDiceValue()
                {
                    DiceCountValue = ContextValues.Rank(),
                    DiceType = Kingmaker.RuleSystem.DiceType.D6,
                    BonusValue = ContextValues.Constant(0)
                };

            }).Configure();//Elect strikes at 20

            BuffConfigurator.For("ad90034a6f8a6f144bf8f329917e1d38").RemoveComponents(x => x is AddInitiatorAttackWithWeaponTrigger).AddComponent<ContextDamageValueEnergyDamageDice>(x =>
            {
                x.damageType = new DamageTypeDescription() { Type = DamageType.Energy, Energy = DamageEnergyType.Acid };
                x.Value = new ContextDiceValue()
                {
                    DiceCountValue = ContextValues.Rank(),
                    DiceType = Kingmaker.RuleSystem.DiceType.D6,
                    BonusValue = ContextValues.Constant(0)
                };

            }).Configure();//Acid strikes before 20

            FeatureConfigurator.For("d37a8f6f5df057a4ea50b2c065288263").RemoveComponents(x => x is AddInitiatorAttackWithWeaponTrigger).AddComponent<ContextDamageValueEnergyDamageDice>(x =>
            {
                x.damageType = new DamageTypeDescription() { Type = DamageType.Energy, Energy = DamageEnergyType.Acid };
                x.Value = new ContextDiceValue()
                {
                    DiceCountValue = ContextValues.Rank(),
                    DiceType = Kingmaker.RuleSystem.DiceType.D6,
                    BonusValue = ContextValues.Constant(0)
                };

            }).Configure();//Acid strikes at 20


        }

        public static void FixRandomWeaponsRiders()
        {
            if (Settings.IsEnabled("FixExtraHitsSmallDragon"))
            {
                BuffConfigurator smdbuff = BuffConfigurator.For("d37d0c19b37808d4895c836c474f04e3");
                smdbuff.RemoveComponents(x => x is AddInitiatorAttackWithWeaponTrigger);

                ContextDiceValue size = new ContextDiceValue() { BonusValue = 0, DiceCountValue = 1, DiceType = Kingmaker.RuleSystem.DiceType.D4 };
                smdbuff.AdditionalDiceOnAttack(distanceLessEqual: new Kingmaker.Utility.Feet(), damageType: new DamageTypeDescription()
                {
                    Type = DamageType.Energy,
                    Energy = DamageEnergyType.Fire
                }, randomizeDamage: true, value: new Kingmaker.UnitLogic.Mechanics.ContextDiceValue()
                {
                    BonusValue = 0,
                    DiceCountValue = 1,
                    DiceType = Kingmaker.RuleSystem.DiceType.D4
                }, damageEntries: new List<AdditionalDiceOnAttack.DamageEntry>() { new AdditionalDiceOnAttack.DamageEntry() { DamageType = new DamageTypeDescription() {  Type = DamageType.Energy, Energy = DamageEnergyType.Fire}, Value = size  }, new AdditionalDiceOnAttack.DamageEntry() { DamageType = new DamageTypeDescription() { Type = DamageType.Energy, Energy = DamageEnergyType.Cold }, Value = size }, new AdditionalDiceOnAttack.DamageEntry() { DamageType = new DamageTypeDescription() { Type = DamageType.Energy, Energy = DamageEnergyType.Acid }, Value = size }, new AdditionalDiceOnAttack.DamageEntry() { DamageType = new DamageTypeDescription() { Type = DamageType.Energy, Energy = DamageEnergyType.Electricity }, Value = size } }); 
               /* smdbuff.AddComponent(new RandomEnergyDamageOnWeaponAttack()
                {
                    amount = new Kingmaker.RuleSystem.DiceFormula(1, Kingmaker.RuleSystem.DiceType.D4),
                    damageDescriptions = new DamageEnergyType[] { DamageEnergyType.Acid, DamageEnergyType.Fire, DamageEnergyType.Cold, DamageEnergyType.Electricity }

                });*/
                //If I find hodos torch and it's busted, fix
                smdbuff.Configure();
            }
        }

        public static void FixClawsOfSacredBeast()
        {
            if (Settings.IsEnabled("FixExtraHitsClawsOfASacredBeast"))
            {
                WeaponCategory[] natweapons = new WeaponCategory[] { WeaponCategory.Claw, WeaponCategory.Bite, WeaponCategory.Gore, WeaponCategory.OtherNaturalWeapons, WeaponCategory.UnarmedStrike, WeaponCategory.Tail };
                Main.TotFContext.Logger.Log("Patching Claws Of A Sacred Beast");
                FeatureConfigurator claws = FeatureConfigurator.For("27d7b88ee7438cf4697224a870e0d129").RemoveComponents(x => x is AddInitiatorAttackWithWeaponTrigger);
                claws.AddComponent(new ContextWeaponCategoryPhysDamageDiceWithChangeOnCondition() { categories = natweapons, form = PhysicalDamageForm.Slashing, NormalDamage = new Kingmaker.RuleSystem.DiceFormula() { m_Dice = Kingmaker.RuleSystem.DiceType.D8, m_Rolls = 1 }, IncreasedDamage = new Kingmaker.RuleSystem.DiceFormula() { m_Dice = Kingmaker.RuleSystem.DiceType.D6, m_Rolls = 2 }, TargetConditions = ConditionsBuilder.New().Alignment( Kingmaker.Enums.AlignmentComponent.Evil, checkCaster:false).Build() });

                claws.Configure();
            }
        }

    }
}
