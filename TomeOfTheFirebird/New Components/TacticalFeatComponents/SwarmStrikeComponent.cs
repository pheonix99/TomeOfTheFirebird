using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.New_Components.TacticalFeatComponents
{
    class SwarmStrikeComponent : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleCalculateAttackBonus>, IRulebookHandler<RuleCalculateAttackBonus>, ISubscriber, IInitiatorRulebookSubscriber
    {
      

        public void OnEventAboutToTrigger(RuleCalculateAttackBonus evt)
        {
            if (evt.Reason.Rule is not RuleAttackWithWeapon attack || !attack.IsAttackOfOpportunity)
            {
                return;
            }
            bool solotactics = base.Owner.State.Features.SoloTactics;
            int bonus = 1;//Yes, this one works even totally alone!
            foreach (var unitEntityData in evt.Target.CombatState.EngagedBy)
            {
                if (unitEntityData != base.Owner && unitEntityData.IsAlly(Owner))
                {
                    if (solotactics || (unitEntityData.Descriptor.HasFact(this.OwnerBlueprint.ToReference<BlueprintUnitFactReference>())))
                        bonus++;

                }
            }
            evt.AddModifier(bonus, base.Fact, ModifierDescriptor.UntypedStackable);
        }

        public void OnEventDidTrigger(RuleCalculateAttackBonus evt)
        {
            
        }
    }
}
