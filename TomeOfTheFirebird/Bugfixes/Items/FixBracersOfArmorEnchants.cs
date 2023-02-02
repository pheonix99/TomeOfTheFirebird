using BlueprintCore.Blueprints.Configurators.Items.Ecnchantments;
using BlueprintCore.Utils;
using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.Bugfixes.Items
{
    public static class FixBracersOfArmor
    {
        public static string[] bracerEnchantGUIDs = new string[]
            {
                            "183e268ab1ba71a47b548b9408e34ae0", "761cb57f05e40e04281f6b930175f290", "8b35eda0cd2ab994cbfb41bbb14756a1", "7ee8802804a2b05478b19042fc3ddcf8", "25ea4926377d23b48bf6f225e8a831a3", "f4088bbd8c450ae4498c056f932d1c8e", "04a1ff33d8f45de46a3ba819aa343a1e", "eff702c8c75385e409de56c32b81c48b"

            };
        static string[] incorporealFeatureGUIDs = new string[]
        {
            "52bb405096f0e604997f58dfa0549303", "e8521c3d8efe421448c1ffb430aaba65", "3bbd7b1a17f3f814fbd7e2f9e3ec690b", "ac1f09f87630f5543b84de3d1d7dc5ea", "5672eabb78149d8419aa4d037308988c", "cfc5348738262074083a7358085dfacd", "041bdbd1cf61a314c936ece4580f3dea", "860d2a8f4dbc3ca489e4fb3e8f6b2fc5"
        };


        static string[] itemsIdsToFix = new string[]
            {
                "c9a0fe9921ec0034c9f8895c47f51e94",
               "9482c62934be44044918c3aac3730232",
"bf063663cdb3df34c8ffa05ff1d1c877",
"cc5f45518020a324b8c51d0a231984a3",
"0a8cda1aaee1178419b32722c89dae64",
"33179b698a3264e45bc3495a2181a0ea",
"4811d69bde8fb0243b61c2b41300ebe7",
"a106eeb09f2ef5a48ab8507f39cbabd8",
"bade8137f5101834c849c277ba0301a1",
"c08a6bfecf66b3341828b7d454077c6e",
"b474319876ac44f46a934d640bbe52a0",
"341bdc12a923fbb4097bc68492f67420",
"d7ac91cca37741c4bc743ad658498bb0",
"c903f7c0f0a7437dae32ce25d7c10a9e"

            };
        static string[] antiIncorporealEnchants = new string[] {
            "d1420feff4707244fb10d46ef3eb2a5c",
            "038186a064f461644bcf1c94086c724a.json",
            "2d17a99cd3a73c14e9f821b77131d710",
            "81d89e6d46b262a46b40670ca84a1a67",
            "261b2a837951ff949bb51c0ae3c818ea",
            "512b18c5ea7655a419feb9cb1f7c8e26",
            "30f1ab1aec26afa43a23604b5a412f6b",
            "3c01fdc61d0564f46a994098af5df186"
            };
        static BlueprintItemEquipment[] itemsTofix;
        private static void ApplyBracersOfArmorEnchantmentFixes()
        {

            Main.TotFContext.Logger.Log("Applying Bracers Enchant Fixes");

            for (int i = 0; i < bracerEnchantGUIDs.Length; i++)
            {
                EquipmentEnchantmentConfigurator.For(bracerEnchantGUIDs[i]).AddUnitFeatureEquipment(incorporealFeatureGUIDs[i]).Configure();



            }
        }

        private static void KillIncorporealEnchant(ItemEntity e)
        {
            if (e.Enchantments.Any(z => bracerEnchantGUIDs.Contains(z.Blueprint.AssetGuidThreadSafe)))
            {
                e.Enchantments.RemoveAll(x => antiIncorporealEnchants.Contains(x.Blueprint.AssetGuidThreadSafe));
            }

        }

        public static void Run()
        {
            if (Settings.IsDisabled("FixBracersOfArmor"))
                return;
            ApplyBracersOfArmorEnchantmentFixes();
            ApplyBracersOfArmorItemFixes();
        }

        private static bool IsKillable(BlueprintScriptableObject o)
        {

            if (antiIncorporealEnchants.Contains(o.AssetGuidThreadSafe))
                return true;



            return false;
        }

        private static void ApplyBracersOfArmorItemFixes()
        {
            Main.TotFContext.Logger.Log("Applying Bracers Item FIxes");
            itemsTofix = itemsIdsToFix.Select(x =>BlueprintTool.Get< BlueprintItemEquipment>(x)).ToArray();
            foreach (BlueprintItemEquipment x in itemsTofix)
            {

                x.Enchantments.RemoveAll(IsKillable);
                Main.TotFContext.Logger.LogPatch("Killed Extra Enchants on", x);
            }



        }

        [HarmonyPatch(typeof(ItemEntity), "OnPostLoad")]
        class ItemEntity__PostLoad__Patch
        {
            static void Postfix(ItemEntity __instance)
            {
                if (Settings.IsDisabled("FixBracersOfArmor"))
                    return;
                KillIncorporealEnchant(__instance);
            }
        }
    }
}
