using Kingmaker.EntitySystem.Entities;
using Kingmaker.UnitLogic.Mechanics.Properties;

namespace TomeOfTheFirebird.New_Components.Properties
{
    public abstract class ConditionalPropertyGetter : PropertyValueGetter
    {
        public abstract bool Condition(UnitEntityData unit);
        public override int GetBaseValue(UnitEntityData unit)
        {
            if (Condition(unit))
                return Property.GetBaseValue(unit);
            else
                return 0;
                    
        }

        public PropertyValueGetter Property;

    }
}
