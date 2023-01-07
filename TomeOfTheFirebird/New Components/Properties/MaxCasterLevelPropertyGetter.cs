using Kingmaker.EntitySystem.Entities;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Mechanics.Properties;
using System;

namespace TomeOfTheFirebird.New_Components.Properties
{
    class MaxCasterLevelPropertyGetter : PropertyValueGetter
    {
        public override int GetBaseValue(UnitEntityData unit)
        {
            int property = 0;
            foreach (ClassData classData2 in unit.Descriptor.Progression.Classes)
            {
                if (classData2.Spellbook != null)
                {
                   
                   property = Math.Max(classData2.Level + classData2.Spellbook.CasterLevelModifier, property);
                }
            }
            return property;
        }
    }

}
