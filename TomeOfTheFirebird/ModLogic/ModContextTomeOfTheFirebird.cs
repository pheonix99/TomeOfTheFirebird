using TabletopTweaks.Core.ModLogic;
using TomeOfTheFirebird.Config;
using UnityModManagerNet;

namespace TomeOfTheFirebird.ModLogic
{
    class ModContextTomeOfTheFirebird : ModContextBase
    {
        public TomeOfTheFirebird.Config.Bugfixes Bugfixes;
        public ContentModifications ContentModifications;
        public Config.NewContent NewContent;
        public Config.Tweaks Tweaks;
        public ModContextTomeOfTheFirebird(UnityModManager.ModEntry modEntry) : base(modEntry)
        {
            LoadSettings("Bugfixes.json", "TomeOfTheFirebird.Config", ref Bugfixes);
            LoadSettings("ContentModifications.json", "TomeOfTheFirebird.Config", ref ContentModifications);
            LoadSettings("NewContent.json", "TomeOfTheFirebird.Config", ref NewContent);
            LoadSettings("Tweaks.json", "TomeOfTheFirebird.Config", ref Tweaks);
            LoadBlueprints("TomeOfTheFirebird.Config", this);
            //LoadLocalization("TomeOfTheFirebird.Localization");

        }

        public override void LoadAllSettings()
        {
            base.AfterBlueprintCachePatches();
       
        }

        public override void AfterBlueprintCachePatches()
        {
            base.AfterBlueprintCachePatches();
            if (Debug)
            {
                Blueprints.RemoveUnused();
                SaveSettings(BlueprintsFile, Blueprints);
                ModLocalizationPack.RemoveUnused();
                SaveLocalization(ModLocalizationPack);
            }
        }
        public override void SaveAllSettings()
        {
            base.SaveAllSettings();
            SaveSettings("Bugfixes.json", Bugfixes);
            SaveSettings("NewContent.json", NewContent);
            SaveSettings("ContentModifications.json", ContentModifications);
            SaveSettings("Tweaks.json", Tweaks);
        }
    }
}
