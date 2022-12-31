using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.PubSubSystem;
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
    [AllowedOn(typeof(BlueprintUnitFact))]
    class PhoenixHeartOfFireHealingComponent : UnitFactComponentDelegate, ITargetRulebookHandler<RuleHealDamage>, IRulebookHandler<RuleHealDamage>, ITargetRulebookSubscriber, ISubscriber
    {
        public void OnEventAboutToTrigger(RuleHealDamage evt)
        {
            if (evt.Reason.Ability?.Blueprint?.IsSpell != true)
            {
                return;
            }
            if (evt.Reason.Ability?.Blueprint.SpellDescriptor != Kingmaker.Blueprints.Classes.Spells.SpellDescriptor.Cure)
                return;
            evt.AddModifier(healIncreasePerDie.Calculate(base.Context) * evt.HealFormula.BaseFormula.Rolls, Owner.GetFact(OwnerBlueprint as BlueprintUnitFact));
            
        }

        public void OnEventDidTrigger(RuleHealDamage evt)
        {
            
        }
        public ContextValue healIncreasePerDie;
    }
}
