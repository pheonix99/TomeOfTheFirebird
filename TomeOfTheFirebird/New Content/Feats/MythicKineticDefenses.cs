using Kingmaker.UnitLogic.Mechanics.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTweaks.Core.NewComponents.Properties;
using TabletopTweaks.Core.Utilities;

namespace TomeOfTheFirebird.New_Content.Feats
{
    class MythicKineticDefenses
    {
        public static void Make()
        {
            string airid = "c8719b3c5c0d4694cb13abcc3b7e893b";
            string airbuffId = "de4f4b6aa7f62204c95f5d03ac0bc459";
            string coldid = "1ff5d6e76b7c2fa48be555b77d1ad8b2";
            string fireId = "2825e3a53c76ad944a47c5c44fb6109f";
            string shroudFeatureid = "29ec36fa2a5b8b94ebce170bd369083a";
            string searingFleshId = "8ad77685e64842c45a6f5b19f9086c6c";
            string fleshOfStoneId = "a275b35f282601944a97e694f6bc79f8";
            string windsId = "bb0de2047c448bd46aff120be3b39b7a";

            TabletopTweaks.Core.Utilities.Helpers.CreateBlueprint<BlueprintUnitProperty>(Main.TotFContext, "KineticAdaptProperty", x =>
            {
                x.AddComponent<CompositeCustomPropertyGetter>(x =>
                {


                });

            });
        }

        /*
         * Defense talents act as if 1 point of burn had been invested +1 at MR 3/6/9
         * Adaptation talents act as if burn was 1 higher per MR
         * 
         * 
         */

    }
}
