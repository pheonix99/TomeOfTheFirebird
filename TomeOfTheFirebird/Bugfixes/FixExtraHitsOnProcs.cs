using BlueprintCore.Blueprints.Configurators.Buffs;
using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
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

namespace TomeOfTheFirebird.Bugfixes
{
    public static class FixExtraHitsOnProcs
    {
        public static void FixFirebrand()
        {
            if (Main.TotFContext.Bugfixes.FixExtraHits.IsEnabled("Firebrand"))
            {
                Main.TotFContext.Logger.Log("Fixing Firebrand");
                var firebrandBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("c6cc1c5356db4674dbd2be20ea205c86");
                if (firebrandBuff.Components.OfType<AddInitiatorAttackWithWeaponTrigger>().Any())
                {
                    Main.TotFContext.Logger.Log("Removing base weapon damage effect");
                    //firebrandBuff.Components.Remove(x => x is AddInitiatorAttackWithWeaponTrigger);
                    var editer = BuffConfigurator.For(firebrandBuff.AssetGuidThreadSafe).RemoveComponents(x => x is AddInitiatorAttackWithWeaponTrigger);
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

        public static void FixRandomWeaponsRiders()
        {
            if (Main.TotFContext.Bugfixes.FixExtraHits.IsEnabled("SmallDragon"))
            {
                var smdbuff = BuffConfigurator.For("d37d0c19b37808d4895c836c474f04e3");
                smdbuff.RemoveComponents(x => x is AddInitiatorAttackWithWeaponTrigger);

                ContextDiceValue size = new ContextDiceValue() { BonusValue = 0, DiceCountValue = 1, DiceType = Kingmaker.RuleSystem.DiceType.D4 };
                smdbuff.AdditionalDiceOnAttack(new Feet(), new DamageTypeDescription()
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
            if (Main.TotFContext.Bugfixes.FixExtraHits.IsEnabled("ClawsOfASacredBeast"))
            {
                var natweapons = new WeaponCategory[] { WeaponCategory.Claw, WeaponCategory.Bite, WeaponCategory.Gore, WeaponCategory.OtherNaturalWeapons, WeaponCategory.UnarmedStrike, WeaponCategory.Tail };
                Main.TotFContext.Logger.Log("Patching Claws Of A Sacred Beast");
                var claws = FeatureConfigurator.For("27d7b88ee7438cf4697224a870e0d129").RemoveComponents(x => x is AddInitiatorAttackWithWeaponTrigger);
                claws.AddComponent(new ContextWeaponCategoryPhysDamageDiceWithChangeOnCondition() { categories = natweapons, form = PhysicalDamageForm.Slashing, NormalDamage = new Kingmaker.RuleSystem.DiceFormula() { m_Dice = Kingmaker.RuleSystem.DiceType.D8, m_Rolls = 1 }, IncreasedDamage = new Kingmaker.RuleSystem.DiceFormula() { m_Dice = Kingmaker.RuleSystem.DiceType.D6, m_Rolls = 2 }, TargetConditions = ConditionsBuilder.New().ContextConditionAlignment(false, Kingmaker.Enums.AlignmentComponent.Evil).Build() });

                claws.Configure();
            }
        }

    }
}
