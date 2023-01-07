using Kingmaker.Blueprints;
using Kingmaker.Designers;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;

namespace TomeOfTheFirebird.New_Components.TacticalFeatComponents
{
    public class LastwallPhalanxComponent : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleSavingThrow>, IRulebookHandler<RuleSavingThrow>, ITargetRulebookHandler<RuleCalculateAC>, IRulebookHandler<RuleCalculateAC>, ISubscriber, IInitiatorRulebookSubscriber, ITargetRulebookSubscriber
    {
       


        public void OnEventAboutToTrigger(RuleCalculateAC evt)
        {
            int attackerAlignmentInt = ((int)evt.Initiator.Alignment.m_Value.Value);
            if (attackerAlignmentInt == 5 || attackerAlignmentInt == 12 || attackerAlignmentInt == 20)
            {

                int counter = AllyCount();
                if (counter > 0)
                {
                    evt.AddModifier(counter, base.Fact, ModifierDescriptor.Sacred);
                }
            }
        }

        private int AllyCount()
        {
            int counter = 0;
            foreach (UnitEntityData unitEntityData in GameHelper.GetTargetsAround(base.Owner.Position, (float)this.Radius, true, false))
            {
                if ((unitEntityData.Descriptor.HasFact(this.OwnerBlueprint.ToReference<BlueprintUnitFactReference>()) || base.Owner.State.Features.SoloTactics) && unitEntityData != base.Owner && unitEntityData.IsAlly(base.Owner))
                {
                    counter++;


                }
            }

            return counter;
        }

        public void OnEventDidTrigger(RuleCalculateAC evt)
        {
            
        }

        public void OnEventAboutToTrigger(RuleSavingThrow evt)
        {
            int attackerAlignmentInt = (int)(evt.Reason.Caster.Alignment.m_Value.Value);
            if (attackerAlignmentInt == 5 || attackerAlignmentInt == 12 || attackerAlignmentInt == 20)
            {

                int value = AllyCount();
                evt.AddTemporaryModifier(evt.Initiator.Stats.SaveWill.AddModifier(value, base.Runtime, ModifierDescriptor.Sacred));
                evt.AddTemporaryModifier(evt.Initiator.Stats.SaveReflex.AddModifier(value, base.Runtime, ModifierDescriptor.Sacred));
                evt.AddTemporaryModifier(evt.Initiator.Stats.SaveFortitude.AddModifier(value, base.Runtime, ModifierDescriptor.Sacred));
            }
        }

        public void OnEventDidTrigger(RuleSavingThrow evt)
        {
            
        }

        public int Radius;

       
    }
}
