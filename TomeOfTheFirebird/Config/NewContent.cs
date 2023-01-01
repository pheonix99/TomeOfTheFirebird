using TabletopTweaks.Core.Config;

namespace TomeOfTheFirebird.Config
{
    public class NewContent : IUpdatableSettings
    {
        public bool NewSettingsOffByDefault = false;
        public SettingGroup Archetypes;
        public SettingGroup Bloodlines;
       
        public SettingGroup ClassFeatures;


        public SettingGroup Spells;
        public SettingGroup Feats;
        public SettingGroup Mercies;
        public SettingGroup MythicAbilities;
        public SettingGroup Items;
        public SettingGroup WitchPatrons;
        public SettingGroup WildTalents;
        public void Init()
        {
            
                 
        }

        public void OverrideSettings(IUpdatableSettings userSettings)
        {
            NewContent loadedSettings = userSettings as NewContent;
            NewSettingsOffByDefault = loadedSettings.NewSettingsOffByDefault;
            Archetypes.LoadSettingGroup(loadedSettings.Archetypes, NewSettingsOffByDefault);
            Bloodlines.LoadSettingGroup(loadedSettings.Bloodlines, NewSettingsOffByDefault);
            ClassFeatures.LoadSettingGroup(loadedSettings.ClassFeatures, NewSettingsOffByDefault);
            Spells.LoadSettingGroup(loadedSettings.Spells, NewSettingsOffByDefault);
            Feats.LoadSettingGroup(loadedSettings.Feats, NewSettingsOffByDefault);
            Mercies.LoadSettingGroup(loadedSettings.Mercies, NewSettingsOffByDefault);
            MythicAbilities.LoadSettingGroup(loadedSettings.MythicAbilities, NewSettingsOffByDefault);
            Items.LoadSettingGroup(loadedSettings.Items, NewSettingsOffByDefault);
            WitchPatrons.LoadSettingGroup(loadedSettings.WitchPatrons, NewSettingsOffByDefault);
            WildTalents.LoadSettingGroup(loadedSettings.WildTalents, NewSettingsOffByDefault);


        }
    }
}
