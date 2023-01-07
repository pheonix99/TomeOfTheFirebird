using Kingmaker.Blueprints;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Abilities;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Class.Kineticist;
using Kingmaker.Utility;
using System.Linq;

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
            
            var part = evt.Spell.Caster?.Get<UnitPartKineticist>();
            if (part == null)
                return;
            else if (part.Blasts.Any(x=>x.ToReference<BlueprintAbilityReference>().Is(bp)))
            {
                Rulebook.Trigger<RuleCastSpell>(new RuleCastSpell(spell, evt.SpellTarget)
                {
                    IsDuplicateSpellApplied = true
                });
            }

            

            
        }

        
        
    }
}
