using Kingmaker.Enums.Damage;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic;
using System;

namespace TomeOfTheFirebird.Components
{
    class RandomEnergyDamageOnWeaponAttack : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleCalculateWeaponStats>, IRulebookHandler<RuleCalculateWeaponStats>, ISubscriber, IInitiatorRulebookSubscriber
    {

        public void OnEventAboutToTrigger(RuleCalculateWeaponStats evt)
        {
            if (evt.AttackWithWeapon.Target == null)
                return;
            DamageEnergyType damageDescription;
            Random random = new Random();

            int val = random.Next(damageDescriptions.Length);
            damageDescription = damageDescriptions[val];
            
            DamageDescription item = new DamageDescription
            {
                TypeDescription = new DamageTypeDescription() {
                    Energy = damageDescription,
                    Type = DamageType.Energy
                },
                Dice = this.amount,
                SourceFact = base.Fact,
               
            };
            evt.DamageDescription.Add(item);

        }

        public void OnEventDidTrigger(RuleCalculateWeaponStats evt)
        {

        }

        // Token: 0x0600C42D RID: 50221 RVA: 0x00317574 File Offset: 0x00315774
       

        public DiceFormula amount;

        public DamageEnergyType[] damageDescriptions;
    }
}

