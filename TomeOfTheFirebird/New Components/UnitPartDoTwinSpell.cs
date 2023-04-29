using Kingmaker.Blueprints;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.RuleSystem.Rules.Abilities;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TabletopTweaks.Core.MechanicsChanges.MetamagicExtention;

namespace TomeOfTheFirebird.New_Components
{
    internal class UnitPartDoTwinSpell : OldStyleUnitPart, IInitiatorRulebookSubscriber, ISubscriber, IInitiatorRulebookHandler<RuleCastSpell>
    {
        public void OnEventAboutToTrigger(RuleCastSpell evt)
        {

        }

        public void OnEventDidTrigger(RuleCastSpell evt)
        {
            if (evt.Context?.HasMetamagic((Metamagic)CustomMetamagic.Twin) == true)
            {
                if (evt.IsDuplicateSpellApplied || !evt.Success || evt.SpellTarget == null || (evt.Spell.Range == AbilityRange.Touch && evt.Spell.Blueprint.GetComponent<AbilityEffectStickyTouch>() != null))
                {
                    return;
                }


                Rulebook.Trigger<RuleCastSpell>(new RuleCastSpell(evt.Spell, evt.SpellTarget)
                {
                    IsDuplicateSpellApplied = true
                });
            }
        }
    }
}
