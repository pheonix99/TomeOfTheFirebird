using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TomeOfTheFirebird.Bugfixes.Classes
{
    class Magus
    {
        public static void EScionSanityCheck()
        {
            if (Settings.IsDisabled("CleanupEldritchScion"))
                return;

            BlueprintArchetype escion = BlueprintTool.Get<BlueprintArchetype>("d078b2ef073f2814c9e338a789d97b73");
            BlueprintArchetype escionSage = BlueprintTool.Get<BlueprintArchetype>("EldritchScionSageArchetype");
            List<Tuple<int, string>> levelArcaneWeaponPairs = new();
            levelArcaneWeaponPairs.Add(new(5, "36b609a6946733c42930c55ac540416b"));
            levelArcaneWeaponPairs.Add(new(9, "70be888059f99a245a79d6d61b90edc5"));
            levelArcaneWeaponPairs.Add(new(13, "1804187264121cd439d70a96234d4ddb"));
            levelArcaneWeaponPairs.Add(new(17, "3cbe3e308342b3247ba2f4fbaf5e6307"));

            CleanArche(escion, levelArcaneWeaponPairs);
            if (escionSage != null)
            {
                CleanArche(escionSage, levelArcaneWeaponPairs);
            }
        }
        private static void CleanArche(BlueprintArchetype arche, List<Tuple<int, string>> levelArcaneWeaponPairs)
        {
            foreach (var pair in levelArcaneWeaponPairs)
            {
                var weapon = BlueprintTool.GetRef<BlueprintFeatureBaseReference>(pair.Item2);
                var addlist = arche.AddFeatures.FirstOrDefault(x => x.Level == pair.Item1 && x.m_Features.Any(x => x.deserializedGuid.Equals(weapon.deserializedGuid)));
                var removeList = arche.RemoveFeatures.FirstOrDefault(x => x.Level == pair.Item1 && x.m_Features.Any(x => x.deserializedGuid.Equals(weapon.deserializedGuid)));
                if (addlist?.m_Features == null || removeList?.m_Features == null)
                    continue;

                bool killedAdd = addlist.m_Features.Remove(weapon);
                bool killedRemove = removeList.m_Features.Remove(weapon);
                if (killedAdd)
                    Main.TotFContext.Logger.LogPatch($"killed add element of add/remove cancelling pair on escion level {pair.Item1}", weapon.Get());
                if (killedRemove)
                    Main.TotFContext.Logger.LogPatch($"killed remove element of add/remove cancelling pair on escion level {pair.Item1}", weapon.Get());
                if (killedAdd != killedRemove)
                    Main.TotFContext.Logger.LogError($"redundancy kill incomplete on escion level {pair.Item1}");

            }
        }

    }
}
