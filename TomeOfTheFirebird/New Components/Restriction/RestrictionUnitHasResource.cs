using Kingmaker.Armies.TacticalCombat.LeaderSkills;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.New_Components.Restriction
{
    [AllowedOn(typeof(BlueprintActivatableAbilityReference))]
    public class RestrictionUnitHasResource : UnitFactComponentDelegate, IAbilityRestriction
    {
        public BlueprintAbilityResourceReference _blueprintAbilityResourceReference;

        public string GetAbilityRestrictionUIText()
        {
            return $"Unit must have {_blueprintAbilityResourceReference.Get().Name} left";
        }

        public bool IsAbilityRestrictionPassed(AbilityData ability)
        {
            return Owner.Resources.HasEnoughResource(_blueprintAbilityResourceReference.Get(), 1);

        }
    }
}
