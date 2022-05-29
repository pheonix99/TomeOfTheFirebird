using BlueprintCore.Blueprints.Configurators.Abilities;
using HarmonyLib;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.UnitLogic.Abilities.Blueprints;

namespace TomeOfTheFirebird.Bugfixes
{
    class FixingIFFTagging
    {
        [HarmonyPatch(typeof(BlueprintsCache), "Init")]
        static class BlueprintsCache_Init_Patch
        {
            static bool Initialized;

            [HarmonyPriority(Priority.First)]
            static void Postfix()
            {
                if (Initialized) return;
                Initialized = true;

                var goodHope = AbilityConfigurator.For("a5e23522eda32dc45801e32c05dc9f96").SetEffectOn(AbilityEffectOnUnit.Helpful, AbilityEffectOnUnit.None).AllowTargeting(true, false, true, true).Configure();

                
            }
        }
    }
}
