using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.New_Content.Features
{
    class BloodlineMutations
    {
        public static void Setup()
        {
            var sorc = BlueprintTool.Get<BlueprintFeatureSelection>("24bef8d1bee12274686f6da6ccbc8914").AllFeatures.Where(x => x is BlueprintProgression).Select(x => x as BlueprintProgression);

            
        }
        private static void ProcessProgression(BlueprintProgression blueprintProgression)
        {

        }
    }
}
