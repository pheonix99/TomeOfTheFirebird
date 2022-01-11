using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Mechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.Components
{
    [AllowedOn(typeof(BlueprintUnitFact))]
    [ComponentName("Damage bonus for specific weapon types")]
    public class ContextWeaponCategoryFlatDamageBonus : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleCalculateWeaponStats>, IRulebookHandler<RuleCalculateWeaponStats>, ISubscriber, IInitiatorRulebookSubscriber
    {
        public WeaponCategory[] categories;
        public ContextValue Value;
        public ModifierDescriptor descriptor;
        public void OnEventAboutToTrigger(RuleCalculateWeaponStats evt)
        {
            int num = Value.Calculate(this.Fact.MaybeContext);
            if (evt.Weapon == null)
                return;
            if (categories.Contains(evt.Weapon.Blueprint.Category))
            {
               
                evt.DamageModifiers.Add(new Modifier(num, descriptor));
            }
        }

        public void OnEventDidTrigger(RuleCalculateWeaponStats evt)
        {
            
        }
    }
}
