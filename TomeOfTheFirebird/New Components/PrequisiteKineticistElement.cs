using JetBrains.Annotations;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Class.LevelUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.New_Components
{
    class PrequisiteKineticistElement : PrerequisiteFeaturesFromList
    {
        public override string GetUITextInternal(UnitDescriptor unit)
        {
            return $"Has Kineticist Element: {Element}";
        }

        public string Element;

    }
}
