using TabletopTweaks.Core.Config;

namespace TomeOfTheFirebird.Config
{
    public class Bugfixes : IUpdatableSettings
    {
        public bool NewSettingsOffByDefault = false;
        public SettingGroup FixExtraHits;
        public SettingGroup Purifier;
        public SettingGroup Cavalier;
        public SettingGroup Arcanist;
        public SettingGroup Items;
        public void Init()
        {
            
        }

        public void OverrideSettings(IUpdatableSettings userSettings)
        {
            Bugfixes loadedSettings = userSettings as Bugfixes;
            NewSettingsOffByDefault = loadedSettings.NewSettingsOffByDefault;
            FixExtraHits.LoadSettingGroup(loadedSettings.FixExtraHits, NewSettingsOffByDefault);
            Purifier.LoadSettingGroup(loadedSettings.Purifier, NewSettingsOffByDefault);
            Cavalier.LoadSettingGroup(loadedSettings.Cavalier, NewSettingsOffByDefault);
            Arcanist.LoadSettingGroup(loadedSettings.Arcanist, NewSettingsOffByDefault);
            Items.LoadSettingGroup(loadedSettings.Items, NewSettingsOffByDefault);
            

        }
    }
}
