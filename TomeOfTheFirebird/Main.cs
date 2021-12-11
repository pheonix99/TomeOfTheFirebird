using CrusaderForge.Config;
using CrusaderForge.Utilities;
using HarmonyLib;
using JetBrains.Annotations;
using Kingmaker;
using Kingmaker.Blueprints.JsonSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityModManagerNet;

namespace TomeOfTheFirebird
{
    static class Main
    {

        public static bool IsInGame => Game.Instance.Player?.Party.Any() ?? false;

        public static bool Enabled;
        static bool Load(UnityModManager.ModEntry modEntry)
        {
            try
            {


                var harmony = new Harmony(modEntry.Info.Id);
                ModSettings.ModEntry = modEntry;
                modEntry.OnToggle = OnToggle;

                ModSettings.LoadAllSettings();
                ModSettings.ModEntry.OnSaveGUI = OnSaveGUI;
                //ModSettings.ModEntry.OnGUI = UMMSettingsUI.OnGUI;
                //AssetLoader.AddBundle("tutorialcanvas");
                if (UnityModManager.gameVersion.Minor == 1)
                    UIHelpers.WidgetPaths = new WidgetPaths_1_1();
                else
                    UIHelpers.WidgetPaths = new WidgetPaths_1_0();
                harmony.PatchAll();
                //CraftSystemWrapper.Install();
                //PostPatchInitializer.Initialize();

                return true;
            }
            catch (Exception e)
            {
                Error(e, e.Message);
                return false;
            }
        }

        static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
        {
            Enabled = value;
            return true;
        }

        static void OnSaveGUI(UnityModManager.ModEntry modEntry)
        {
            ModSettings.SaveSettings("GeneralSettings.json", ModSettings.GeneralSettings);

        }

        internal static void LogPatch(string v, object coupDeGraceAbility)
        {
            throw new NotImplementedException();
        }

        public static void Log(string msg)
        {
            ModSettings.ModEntry.Logger.Log(msg);
        }
        [System.Diagnostics.Conditional("DEBUG")]
        public static void LogDebug(string msg)
        {
            ModSettings.ModEntry.Logger.Log(msg);
        }
        public static void LogPatch(string action, [NotNull] IScriptableObjectWithAssetId bp)
        {
            Log($"{action}: {bp.AssetGuid} - {bp.name}");
        }
        public static void LogHeader(string msg)
        {
            Log($"--{msg.ToUpper()}--");
        }
        public static void Error(Exception e, string message)
        {
            Log(message);
            Log(e.ToString());
            PFLog.Mods.Error(message);
        }
        public static void Error(string message)
        {
            Log(message);
            PFLog.Mods.Error(message);
        }

        public static void Safely(Action act)
        {
            try
            {
                act();
            }
            catch (Exception ex)
            {
                Main.Error(ex, "trying to safely invoke action");
            }
        }
        static HashSet<string> filtersEnabled = new()
        {
            //"state",
            //"minority",
            //"rejection",
            "interop",
        };


        static bool suppressUnfiltered = false;
        internal static void Verbose(string v, string filter = null)
        {
#if true && DEBUG
            if ((filter == null && !suppressUnfiltered) || filtersEnabled.Contains(filter))
                Main.Log(v);
#endif
        }
    }
}

