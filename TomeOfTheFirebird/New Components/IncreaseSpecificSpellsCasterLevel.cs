using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules.Abilities;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.New_Components
{
    // Token: 0x02001DBF RID: 7615
    [ComponentName("Increase specific spells CL")]
    [AllowedOn(typeof(BlueprintUnitFact), false)]

    public class IncreaseSpecificSPellsCasterLevel : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleCalculateAbilityParams>, IRulebookHandler<RuleCalculateAbilityParams>, ISubscriber, IInitiatorRulebookSubscriber
    {
        // Token: 0x0600C1B9 RID: 49593 RVA: 0x0030FAA1 File Offset: 0x0030DCA1
        public void OnEventAboutToTrigger(RuleCalculateAbilityParams evt)
        {
            if (spells.Select(x => x.ToReference<BlueprintAbilityReference>()).Contains(evt.AbilityData.Blueprint.ToReference<BlueprintAbilityReference>()))
            {

                evt.AddBonusCasterLevel(this.Value.Calculate(base.Context), this.Descriptor);
                
            }

          
        }

        // Token: 0x0600C1BA RID: 49594 RVA: 0x00003AE3 File Offset: 0x00001CE3
        public void OnEventDidTrigger(RuleCalculateAbilityParams evt)
        {
        }

        // Token: 0x04007EC2 RID: 32450
        public ContextValue Value;

        public BlueprintAbility[] spells = new BlueprintAbility[] { };

        public ModifierDescriptor Descriptor = ModifierDescriptor.UntypedStackable;
    }
}
