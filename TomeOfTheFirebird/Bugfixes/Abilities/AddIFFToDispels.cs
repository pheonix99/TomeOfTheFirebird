using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using HarmonyLib;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Utility;
using Owlcat.Runtime.Core;
using System.Linq;

namespace TomeOfTheFirebird.Bugfixes.Abilities
{
    static class AddIFFToDispels
    {

        [HarmonyPatch(typeof(BlueprintsCache), "Init")]
        static class BlueprintsCache_Init_Patch
        {
            static bool Initialized;

            [HarmonyPriority(Priority.Last)]
            static void Postfix()
            {
                if (Initialized) return;
                Initialized = true;
                if (Settings.IsDisabled("DispelsAreBuffSafe"))
                    return;
                Main.TotFContext.Logger.Log("Patching Dispel IFF");
                FeatureConfigurator.For("1b92146b8a9830d4bb97ab694335fa7c").EditComponent<AddInitiatorAttackRollTrigger>(x => x.Action.Actions.OfType<ContextActionDispelMagic>().FirstOrDefault().OnlyTargetEnemyBuffs = true).Configure();
                
                AbilityConfigurator.For("b9be852b03568064b8d2275a6cf9e2de").EditComponent<AbilityEffectRunAction>(x =>
                {

                    Conditional outer = x.Actions.Actions.OfType<Conditional>().FirstOrDefault();
                    outer.IfTrue.Actions.OfType<Conditional>().FirstOrDefault().IfFalse.Actions.OfType<ContextActionDispelMagic>().FirstOrDefault().OnlyTargetEnemyBuffs = true;
                    outer.IfFalse.Actions.OfType<ContextActionDispelMagic>().FirstOrDefault().OnlyTargetEnemyBuffs = true;
                }

                ).Configure();
                AbilityConfigurator.For("6d490c80598f1d34bb277735b52d52c1").EditComponent<AbilityEffectRunAction>(x => x.Actions.Actions.OfType<ContextActionDispelMagic>().FirstOrDefault().OnlyTargetEnemyBuffs = true).Configure();//Greater Dispel, point

                AbilityConfigurator.For("9f6daa93291737c40b8a432c374226a7").EditComponent<AbilityEffectRunAction>(x => x.Actions.Actions.OfType<ContextActionDispelMagic>().FirstOrDefault().OnlyTargetEnemyBuffs = true).Configure();//Dispel, point


                AbilityConfigurator.For("143775c49ae6b7446b805d3b2e702298").EditComponent<AbilityEffectRunAction>(x => x.Actions.Actions.OfType<ContextActionDispelMagic>().FirstOrDefault().OnlyTargetEnemyBuffs = true).Configure();//Regular Dispel, target
                AbilityConfigurator.For("f80896af0e10d7c4f9454cf1ce50ada4").EditComponent<AbilityEffectRunAction>(x => x.Actions.Actions.OfType<ContextActionDispelMagic>().FirstOrDefault().OnlyTargetEnemyBuffs = true).Configure();//Dispelling Bombs
                


            }
        }
        /*
        [HarmonyPatch(typeof(ContextActionDispelMagic), "TryDispelBuff")]
        [HarmonyPatch(new Type[] { typeof(Buff), typeof(ContextActionDispelMagic) })]
        static class ContextActionDispelMagicPatch
        {
            [HarmonyPriority(Priority.Last)]
            static void Prefix(ref bool __result, Buff buff, ContextActionDispelMagic __instance)
            {
                Main.Log($"{__instance.Owner.name} dispelling {buff.Name} on {__instance.Target.Unit.CharacterName}, IFF flag: {__instance.OnlyTargetEnemyBuffs}");

            }
        }
        */
    }
}
