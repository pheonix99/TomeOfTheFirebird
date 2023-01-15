using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.Modified_Content.ImprovedMultiarchetypeProjct
{
    class WitchPatronUpgrade
    {
        public static void Handle()
        {
            List<BlueprintProgression> MasterList = new();
            BlueprintFeatureSelection master = BlueprintTool.Get<BlueprintFeatureSelection>("381cf4c890815d049a4420c6f31d063f");
            foreach(var patron in master.m_AllFeatures)
            {
                var progression = BlueprintTool.Get<BlueprintProgression>(patron.Guid.ToString());
                if (progression != null)//Failsafe for when I do Celestial Agenda
                {

                }

            }    


        }

    }
}
