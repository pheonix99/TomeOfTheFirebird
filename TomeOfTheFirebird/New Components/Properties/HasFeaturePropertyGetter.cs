using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.New_Components.Properties
{
    public class HasFeaturePropertyGetter : ConditionalPropertyGetter
    {
        public override bool Condition(UnitEntityData unit)
        {
            return unit.Progression.Features.HasFact(featureBaseReference);
        }
        public BlueprintFeatureBaseReference featureBaseReference;
    }
}
