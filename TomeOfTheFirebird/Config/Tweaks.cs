using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.Config
{
    class Tweaks : IUpdatableSettings
    {
        public bool NewSettingsOffByDefault = false;
        public SettingGroup Mythic;

        public void Init()
        {


        }

        public void OverrideSettings(IUpdatableSettings userSettings)
        {
            var loadedSettings = userSettings as NewContent;
            NewSettingsOffByDefault = loadedSettings.NewSettingsOffByDefault;
            Mythic.LoadSettingGroup(loadedSettings.Spells, NewSettingsOffByDefault);
        }
    
    }
}
