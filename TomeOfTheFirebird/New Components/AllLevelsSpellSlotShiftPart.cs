using Kingmaker.Blueprints;
using Kingmaker.UnitLogic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.New_Components
{
    class AllLevelsSpellSlotShiftPart : OldStyleUnitPart
    {
        [JsonProperty]
        public Dictionary<BlueprintSpellbookReference, Shift> Changes = new();

        public class Shift
        {
            [JsonProperty]
            public int ShiftVal;
        }
    }
}
