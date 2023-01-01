using TabletopTweaks.Core.Config;

namespace TomeOfTheFirebird.Config
{
    public class ContentModifications : IUpdatableSettings
    {
        public bool NewSettingsOffByDefault = true;
        public SettingGroup DawnOfDragons;
        public SettingGroup Crusade;
        public SettingGroup Fighter;
        public void Init()
        {
            
        }

        public void OverrideSettings(IUpdatableSettings userSettings)
        {
            ContentModifications loadedSettings = userSettings as ContentModifications;
            NewSettingsOffByDefault = loadedSettings.NewSettingsOffByDefault;
            DawnOfDragons.LoadSettingGroup(loadedSettings.DawnOfDragons, NewSettingsOffByDefault);
            Crusade.LoadSettingGroup(loadedSettings.Crusade, NewSettingsOffByDefault);
            Fighter.LoadSettingGroup(loadedSettings.Fighter, NewSettingsOffByDefault);
        }
    }
}
