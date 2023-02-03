using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.Mechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.New_Components.BloodlineMutation
{
    class BloodHavocComponent : AbstractBloodlineMutationComponent, IInitiatorRulebookHandler<RuleCalculateDamage>, IRulebookHandler<RuleCalculateDamage>, ISubscriber, IInitiatorRulebookSubscriber
    {
        public void OnEventAboutToTrigger(RuleCalculateDamage evt)
        {
			MechanicsContext context = evt.Reason.Context;
			if (((context != null) ? context.SourceAbility : null) == null)
			{
				return;
			}
			if (context.SourceAbilityContext?.Ability == null)
            {
				return;
            }
			else if (AppliesToAbility(context.SourceAbilityContext.Ability))
            {
				foreach (BaseDamage baseDamage in evt.DamageBundle)
				{
					if (!baseDamage.Precision)
					{
						DiceFormula modifiedValue = baseDamage.Dice.ModifiedValue;
						int bonus = modifiedValue.Rolls;
						baseDamage.AddModifier(bonus, base.Fact);
					}
				}
			}

			
		}

        public void OnEventDidTrigger(RuleCalculateDamage evt)
        {
           
        }
    }
}
