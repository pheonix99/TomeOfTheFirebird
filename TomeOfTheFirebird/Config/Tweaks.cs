using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.Config
{
    public class Tweaks : IUpdatableSettings
    {
        public bool NewSettingsOffByDefault = false;
        public SettingGroup Mythic;
        public SettingGroup Spells;
        public SettingGroup Quests;
        public SettingGroup Crusade;
        public void Init()
        {


        }

        public void OverrideSettings(IUpdatableSettings userSettings)
        {
            var loadedSettings = userSettings as Tweaks;
            NewSettingsOffByDefault = loadedSettings.NewSettingsOffByDefault;
            Mythic.LoadSettingGroup(loadedSettings.Mythic, NewSettingsOffByDefault);
            Spells.LoadSettingGroup(loadedSettings.Spells, NewSettingsOffByDefault);
            Quests.LoadSettingGroup(loadedSettings.Quests, NewSettingsOffByDefault);
            Crusade.LoadSettingGroup(loadedSettings.Crusade, NewSettingsOffByDefault);



        }
    
    }
}
