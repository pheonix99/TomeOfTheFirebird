using Kingmaker.Localization;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.Reference
{
    public static class LocalizedStrings
    {
        public static LocalizedString OneMinutePerLevelDuration => Resources.GetBlueprint<BlueprintAbility>("a5e23522eda32dc45801e32c05dc9f96").LocalizedDuration;
        public static LocalizedString RefHalf => Resources.GetBlueprint<BlueprintAbility>("645558d63604747428d55f0dd3a4cb58").LocalizedSavingThrow;

    }
}
