using HarmonyLib;
using JetBrains.Annotations;
using Kingmaker;
using Kingmaker.Blueprints.JsonSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using TomeOfTheFirebird.Config;
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
                ModSettings.ModEntry.OnGUI = UMMSettingsUI.OnGUI;
                
                
                harmony.PatchAll();
                
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
            ModSettings.SaveSettings("NewContent.json", ModSettings.NewContent);
            ModSettings.SaveSettings("Tweaks.json", ModSettings.Tweaks);
            ModSettings.SaveSettings("Bugfixes.json", ModSettings.Bugfixes);
            ModSettings.SaveSettings("ContentModifications.json", ModSettings.ContentModifications);



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

