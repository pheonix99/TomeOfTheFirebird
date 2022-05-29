using BlueprintCore.Utils;
using HarmonyLib;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.JsonSystem;
using System.Linq;
using TabletopTweaks.Core.Utilities;

namespace TomeOfTheFirebird.Modified_Content.Archetypes
{
    class Purifier
    {

        public static void PatchPurifier()
        {
            var PuriferArchetype = BlueprintTools.GetBlueprint<BlueprintArchetype>("c9df67160a77ecd4a97928f2455545d7");




            PatchLevel3Revelation();
            PatchRestoreCure();
            void PatchLevel3Revelation()
            {

                if (Main.TotFContext.Bugfixes.Purifier.IsDisabled("LevelThreeRevelation")) { return; }

                //var PuriferArchetype = Resources.GetBlueprint<BlueprintArchetype>("c9df67160a77ecd4a97928f2455545d7");
                LevelEntry target = PuriferArchetype.RemoveFeatures.FirstOrDefault(x => x.Level == 3);
                if (target != null)
                {
                    PuriferArchetype.RemoveFeatures = PuriferArchetype.RemoveFeatures.RemoveFromArray(target);
                }

                Main.TotFContext.Logger.LogPatch("Patched", PuriferArchetype);
            }

            void PatchRestoreCure()
            {

                if (Main.TotFContext.Tweaks.Purifier.IsDisabled("RestoreEarlyCures")) { return; }

               
                var earlycure = BlueprintTool.Get<BlueprintFeature>("PurifierLimitedCures");

                LevelEntry l = PuriferArchetype.AddFeatures.FirstOrDefault(x => x.Level == 1);
                if (l == null)
                {
                    l = new LevelEntry
                    {
                        Level = 1,
                        Features = { earlycure }
                    };


                    PuriferArchetype.AddFeatures = PuriferArchetype.AddFeatures.AddToArray(l);
                }
                else
                {

                    l.Features.Add(earlycure);//Doubling up here won't hurt
                }
                Main.TotFContext.Logger.LogPatch("Patched", earlycure);
            }

        }


    }
}
