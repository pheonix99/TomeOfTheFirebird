using Kingmaker;
using Kingmaker.Enums.Damage;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.New_Components
{
    class BurstDamageComponent : UnitFactComponentDelegate, ISubscriber, IInitiatorRulebookSubscriber, IInitiatorRulebookHandler<RuleDealDamage>, IRulebookHandler<RuleDealDamage>
    {

		public void OnEventAboutToTrigger(RuleDealDamage evt)
		{
			if (evt.DamageBundle.Weapon is not null)
			{
				RuleAttackRoll attackRoll = evt.AttackRoll;
				if (base.Owner == null || attackRoll == null || !attackRoll.IsCriticalConfirmed || attackRoll.FortificationNegatesCriticalHit)
				{
					return;
				}
				RuleCalculateWeaponStats ruleCalculateWeaponStats = Rulebook.Trigger<RuleCalculateWeaponStats>(new RuleCalculateWeaponStats(Owner, evt.AttackRoll.Weapon, null, null));
				DiceFormula dice = new DiceFormula(Math.Max(ruleCalculateWeaponStats.CriticalMultiplier - 1, 1), this.Dice);
				evt.Add(new EnergyDamage(dice, this.Element));
			}
		}

		// Token: 0x0600E2D6 RID: 58070 RVA: 0x003A09DA File Offset: 0x0039EBDA
		public void OnEventDidTrigger(RuleDealDamage evt)
		{
		}

		// Token: 0x040094D8 RID: 38104
		public DamageEnergyType Element;

		// Token: 0x040094D9 RID: 38105
		public DiceType Dice = DiceType.D8;
		
    }
}
