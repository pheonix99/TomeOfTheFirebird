using Kingmaker.Blueprints;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Abilities;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.New_Components
{
    class DoubleBlastComponent : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleCastSpell>, IRulebookHandler<RuleCastSpell>, ISubscriber, IInitiatorRulebookSubscriber
    {
        public void OnEventAboutToTrigger(RuleCastSpell evt)
        {
            
        }

        public void OnEventDidTrigger(RuleCastSpell evt)
        {
			if (evt.IsDuplicateSpellApplied || !evt.Success || evt.Spell.Blueprint.IsSpell)
			{
				return;
			}
			AbilityData spell = evt.Spell;
			var bp = spell.Blueprint.Parent ?? spell.Blueprint;

            //Insert Validation HERE
            if (!m_appliableTo.HasItem((BlueprintAbilityReference r) => r.Is(bp)))
            {
                return;
            }

            Rulebook.Trigger<RuleCastSpell>(new RuleCastSpell(spell, evt.SpellTarget)
            {
                IsDuplicateSpellApplied = true
            });
        }

        private bool IsKineticBlast(BlueprintAbility blueprint)
        {
            throw new NotImplementedException();
        }

        List<BlueprintAbilityReference> m_appliableTo = new();
    }
}
