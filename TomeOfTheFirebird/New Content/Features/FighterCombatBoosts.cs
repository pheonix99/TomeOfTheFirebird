using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomeOfTheFirebird.Helpers;

namespace TomeOfTheFirebird.New_Content.Features
{
    public static class FighterCombatBoosts
    {
        private static List<string> MinorBoosts = new();

        public static void MakeSelector()
        {
            var selector = MakerTools.MakeFeatureSelector("FighterCombatBoostSelector", "Select Combat Boost", "Fighters can select a minor combat boost at levels 2, 6, 10, 14 and 18. This is a generalization of Bravery");
            selector.SetIsClassFeature(true);

            selector.Configure();

        }

        public static void ImplementSelector()
        {
            foreach(string guid in MinorBoosts)
            {
                var boost = BlueprintTool.GetRef<BlueprintFeatureReference>(guid);
            }
        }

        public static void RegisterMinorBoost(string guid)
        {
            if (!MinorBoosts.Contains(guid))
                MinorBoosts.Add(guid);
        }


    }
}
