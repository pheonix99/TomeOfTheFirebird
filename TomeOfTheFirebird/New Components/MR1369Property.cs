﻿using Kingmaker.EntitySystem.Entities;
using Kingmaker.UnitLogic.Mechanics.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.New_Components
{
    public class MR1369Property : PropertyValueGetter
    {
        public override int GetBaseValue(UnitEntityData unit)
        {
            if (unit.Progression.MythicLevel == 0)
                return 0;
            else return 1 + (unit.Progression.MythicLevel / 3);
        }

    }
}
