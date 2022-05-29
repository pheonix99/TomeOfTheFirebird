using TabletopTweaks.Core.Config;

namespace TomeOfTheFirebird.Config
{
    public class NewContent : IUpdatableSettings
    {
        public bool NewSettingsOffByDefault = false;
        public SettingGroup Spells;
        public SettingGroup Feats;
        public SettingGroup Mercies;
        public SettingGroup Items;
        public void Init()
        {
            
                 
        }

        public void OverrideSettings(IUpdatableSettings userSettings)
        {
            var loadedSettings = userSettings as NewContent;
            NewSettingsOffByDefault = loadedSettings.NewSettingsOffByDefault;
            Spells.LoadSettingGroup(loadedSettings.Spells, NewSettingsOffByDefault);
            Feats.LoadSettingGroup(loadedSettings.Feats, NewSettingsOffByDefault);
            Mercies.LoadSettingGroup(loadedSettings.Mercies, NewSettingsOffByDefault);
            Items.LoadSettingGroup(loadedSettings.Items, NewSettingsOffByDefault);


        }
    }
}
