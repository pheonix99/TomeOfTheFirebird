using BlueprintCore.Blueprints.Configurators.Buffs;
using Kingmaker.Enums.Damage;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomeOfTheFirebird.Components;

namespace TomeOfTheFirebird.Fixes
{
    public static class FixExtraHitsOnProcs
    {
        public static void FixFirebrand()
        {
            Main.Log("Fixing Firebrand");
            var firebrandBuff = Resources.GetBlueprint<BlueprintBuff>("c6cc1c5356db4674dbd2be20ea205c86");
            if (firebrandBuff.Components.OfType<AddInitiatorAttackWithWeaponTrigger>().Any())
            {
                Main.Log("Removing base weapon damage effect");
                //firebrandBuff.Components.Remove(x => x is AddInitiatorAttackWithWeaponTrigger);
               var editer=  BuffConfigurator.For(firebrandBuff.AssetGuidThreadSafe).RemoveComponents(x => x is AddInitiatorAttackWithWeaponTrigger);
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

        public static void FixRandomWeaponsRiders()
        {
            var smdbuff = BuffConfigurator.For("d37d0c19b37808d4895c836c474f04e3");
            smdbuff.RemoveComponents(x => x is AddInitiatorAttackWithWeaponTrigger);
            smdbuff.AddComponent(new RandomEnergyDamageOnWeaponAttack()
            {
                amount = new Kingmaker.RuleSystem.DiceFormula(1, Kingmaker.RuleSystem.DiceType.D4),
                damageDescriptions = new DamageEnergyType[] { DamageEnergyType.Acid, DamageEnergyType.Fire, DamageEnergyType.Cold, DamageEnergyType.Electricity }

            }) ;
            //If I find hodos torch and it's busted, fix
            smdbuff.Configure();
        }

    }
}
