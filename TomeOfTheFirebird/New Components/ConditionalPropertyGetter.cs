using Kingmaker.EntitySystem.Entities;
using Kingmaker.UnitLogic.Mechanics.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.New_Components
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
