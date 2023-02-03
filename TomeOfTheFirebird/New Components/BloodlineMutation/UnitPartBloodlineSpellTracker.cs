using Kingmaker.Blueprints;
using Kingmaker.UnitLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.New_Components.BloodlineMutation
{
    class UnitPartBloodlineSpellTracker : OldStyleUnitPart
    {
        private Dictionary<UnitFact, BlueprintAbilityReference> mappings = new();

        public void RegisterBloodlineSpell(UnitFact source, BlueprintAbilityReference spell)
        {
            if (!mappings.ContainsKey(source))
                mappings.Add(source, spell);
        }

        public bool IsBloodlineSpell(BlueprintAbilityReference spell)
        {
           return mappings.ContainsValue(spell);
        }

        public void UnregisterBloodlineSpell(UnitFact source, BlueprintAbilityReference spell)
        {
            
                mappings.Remove(source);
        }
    }
}
