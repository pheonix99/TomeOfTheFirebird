using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Mechanics;

namespace TomeOfTheFirebird.New_Components
{
    class ContextDamageValueEnergyDamageDice : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleCalculateWeaponStats>, IRulebookHandler<RuleCalculateWeaponStats>, ISubscriber, IInitiatorRulebookSubscriber
    {
        public ContextDiceValue Value;

        public DamageTypeDescription damageType;

        public void OnEventAboutToTrigger(RuleCalculateWeaponStats evt)
        {
            evt.DamageDescription.Add(new DamageDescription()
            {
                Dice = new Kingmaker.RuleSystem.DiceFormula(Value.DiceCountValue.Calculate(this.Fact.MaybeContext), Value.DiceType),
                TypeDescription = damageType,
                Bonus = Value.BonusValue.Calculate(this.Fact.MaybeContext),
                
            });

        }

        public void OnEventDidTrigger(RuleCalculateWeaponStats evt)
        {
            
        }
    }
}
