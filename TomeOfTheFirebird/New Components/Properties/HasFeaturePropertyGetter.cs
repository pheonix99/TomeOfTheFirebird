using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Entities;

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
