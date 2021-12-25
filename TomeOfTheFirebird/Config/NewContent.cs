using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.Config
{
    public class NewContent : IUpdatableSettings
    {
        public bool NewSettingsOffByDefault = false;
        public SettingGroup Spells;

        public void Init()
        {
            
                 
        }

        public void OverrideSettings(IUpdatableSettings userSettings)
        {
            var loadedSettings = userSettings as NewContent;
            NewSettingsOffByDefault = loadedSettings.NewSettingsOffByDefault;
            Spells.LoadSettingGroup(loadedSettings.Spells, NewSettingsOffByDefault);
        }
    }
}
