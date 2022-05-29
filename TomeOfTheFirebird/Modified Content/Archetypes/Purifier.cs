using HarmonyLib;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.JsonSystem;
using System.Linq;
using TomeOfTheFirebird.Config;
using TomeOfTheFirebird.Helpers;

namespace TomeOfTheFirebird.Modified_Content.Archetypes
{
    class Purifier
    {
        [HarmonyPatch(typeof(BlueprintsCache), "Init")]
        static class BlueprintsCache_Init_Patch
        {
            static bool Initialized;

            static void Postfix()
            {
                if (Initialized) return;
                Initialized = true;

                Main.LogHeader("Patching Purifier Resources");

                PatchPurifier();
            }
            static void PatchPurifier()
            {
                var PuriferArchetype = Resources.GetBlueprint<BlueprintArchetype>("c9df67160a77ecd4a97928f2455545d7");




                PatchLevel3Revelation();
                PatchRestoreCure();
                void PatchLevel3Revelation()
                {

                    if (ModSettings.Bugfixes.Purifier.IsDisabled("LevelThreeRevelation")) { return; }
                    
                    //var PuriferArchetype = Resources.GetBlueprint<BlueprintArchetype>("c9df67160a77ecd4a97928f2455545d7");
                    LevelEntry target = PuriferArchetype.RemoveFeatures.FirstOrDefault(x => x.Level == 3);
                    if (target != null)
                    {
                        PuriferArchetype.RemoveFeatures = PuriferArchetype.RemoveFeatures.RemoveFromArray(target);
                    }

                    Main.LogPatch("Patched", PuriferArchetype);
                }

                void PatchRestoreCure()
                {

                    if (ModSettings.Tweaks.Purifier.IsDisabled("RestoreEarlyCures")) { return; }

                    var earlycure = Resources.GetTabletopTweaksBlueprint<BlueprintFeature>("PurifierLimitedCures");

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
                    Main.LogPatch("Patched", earlycure);
                }

            }

        }
    }
}
