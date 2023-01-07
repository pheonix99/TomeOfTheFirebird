using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.UnitLogic.Mechanics.Properties;
using System.Collections.Generic;

namespace TomeOfTheFirebird.New_Components.Properties
{
    class FeatureRanksWithExtrasPropertyValueGetter : PropertyValueGetter
    {
        public override int GetBaseValue(UnitEntityData unit)
        {
            int basevalue = 0;

            foreach(BlueprintFeatureReference f in Features)
            {
                int? unitFeatureRank = unit?.Progression.Features.GetRank(f);
                if (unitFeatureRank != null)
                    basevalue += unitFeatureRank.Value;
            }

            
           
            return basevalue + bonus;
        }

        public int bonus;
        public List<BlueprintFeatureReference> Features = new();
    }
}
