using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using System;

namespace TomeOfTheFirebird.New_Components.TacticalFeatComponents
{
    public class CoordinatedShotComponent : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleCalculateAttackBonus>, IRulebookHandler<RuleCalculateAttackBonus>, ISubscriber, IInitiatorRulebookSubscriber
    {
      

        public void OnEventAboutToTrigger(RuleCalculateAttackBonus evt)
        {
            

            if (!evt.Weapon.Blueprint.IsRanged)
                return;
            bool solotactics = base.Owner.State.Features.SoloTactics;
            int foundEngagers = 0;
            bool foundTriggerer = false;
            foreach (UnitEntityData unitEntityData in evt.Target.CombatState.EngagedBy)
            {
                if (unitEntityData != base.Owner && unitEntityData.IsAlly(Owner))
                {
                    if (solotactics || (unitEntityData.Descriptor.HasFact(this.OwnerBlueprint.ToReference<BlueprintUnitFactReference>())))
                        foundTriggerer = true;
                    

                    foundEngagers++;
                    if (foundTriggerer && foundEngagers >= 2)
                        break;
                        
                }
                
            }
            if (foundTriggerer)
            {
                
                evt.AddModifier(Math.Min(2, foundEngagers), base.Fact, ModifierDescriptor.UntypedStackable);
            }
        }

        public void OnEventDidTrigger(RuleCalculateAttackBonus evt)
        {
            
        }

        
    }
}
