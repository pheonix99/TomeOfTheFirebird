using Kingmaker;
using Kingmaker.Blueprints;
using Kingmaker.Enums.Damage;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.New_Components
{
    [AllowMultipleComponents]
    [AllowedOn(typeof(BlueprintBuff))]
    class ElementalStanceComponent : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleCalculateWeaponStats>, IRulebookHandler<RuleCalculateWeaponStats>, ISubscriber, IInitiatorRulebookSubscriber, IInitiatorRulebookHandler<RuleDealDamage>, IRulebookHandler<RuleDealDamage>
    {
    
            public DamageEnergyType damage;
   

        public ContextValue scalar;

        public void OnEventAboutToTrigger(RuleCalculateWeaponStats evt)
        {
            if (evt.Weapon.Blueprint.IsMelee)
            {
                int scale = this.scalar.Calculate(base.Context);
                DiceFormula bonusDMG;
                if (scale < 8)
                {
                    bonusDMG = new DiceFormula()
                    {
                        m_Rolls = 1,
                        m_Dice = DiceType.D4

                    };
                }
                else
                {
                    bonusDMG = new DiceFormula()
                    {
                        m_Rolls = 1,
                        m_Dice = DiceType.D8

                    };
                }
                evt.DamageDescription.Add(new() { 
                    Dice = bonusDMG,
                    TypeDescription = new DamageTypeDescription() { Type = DamageType.Energy, Energy = damage},
                    SourceFact = base.Fact
                });
            }
        }

        public void OnEventAboutToTrigger(RuleDealDamage evt)
        {
            if (evt.DamageBundle.Weapon?.Blueprint?.IsMelee == true)
            {
                RuleAttackRoll attackRoll = evt.AttackRoll;
                if (base.Owner == null || attackRoll == null || !attackRoll.IsCriticalConfirmed || attackRoll.FortificationNegatesCriticalHit)
                {
                    return;
                }
                RuleCalculateWeaponStats ruleCalculateWeaponStats = Rulebook.Trigger<RuleCalculateWeaponStats>(new RuleCalculateWeaponStats(Owner, evt.AttackRoll.Weapon, null, null));
                DiceFormula dice = new DiceFormula(Math.Max(ruleCalculateWeaponStats.CriticalMultiplier - 1, 1), diceType: DiceType.D10);
                evt.Add(new EnergyDamage(dice, damage));
            }
        }

        public void OnEventDidTrigger(RuleCalculateWeaponStats evt)
        {
           

        }
        public void OnEventDidTrigger(RuleDealDamage evt)
        {
            
        }
    }
}
