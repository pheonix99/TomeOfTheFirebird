using TabletopTweaks.Core.Config;

namespace TomeOfTheFirebird.Config
{
    public class Tweaks : IUpdatableSettings
    {
        public bool NewSettingsOffByDefault = false;
        public SettingGroup Mythic;
        public SettingGroup Spells;
        public SettingGroup RewardFeatureConversion;
        public SettingGroup Crusade;
        public SettingGroup Purifier;
        public SettingGroup Witch;
        public SettingGroup Bloodlines;
        public void Init()
        {


        }


        
        public void OverrideSettings(IUpdatableSettings userSettings)
        {
            Tweaks loadedSettings = userSettings as Tweaks;
            NewSettingsOffByDefault = loadedSettings.NewSettingsOffByDefault;
            Mythic.LoadSettingGroup(loadedSettings.Mythic, NewSettingsOffByDefault);
            Spells.LoadSettingGroup(loadedSettings.Spells, NewSettingsOffByDefault);
            RewardFeatureConversion.LoadSettingGroup(loadedSettings.RewardFeatureConversion, NewSettingsOffByDefault);
            Crusade.LoadSettingGroup(loadedSettings.Crusade, NewSettingsOffByDefault);
            Purifier.LoadSettingGroup(loadedSettings.Purifier, NewSettingsOffByDefault);
            Witch.LoadSettingGroup(loadedSettings.Witch, NewSettingsOffByDefault);
            Bloodlines.LoadSettingGroup(loadedSettings.Bloodlines, NewSettingsOffByDefault);

            


        }

        

    }
}
