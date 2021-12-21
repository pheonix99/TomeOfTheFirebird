using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.Config
{
    public class GeneralSettings : IUpdatableSettings
    {
        public bool NewSettingsOffByDefault = false;
        //public SettingGroup SlotlessItems;

        public void Init()
        {
            
                 
        }

        public void OverrideSettings(IUpdatableSettings userSettings)
        {
            var loadedSettings = userSettings as GeneralSettings;
            NewSettingsOffByDefault = loadedSettings.NewSettingsOffByDefault;
            //SlotlessItems.LoadSettingGroup(loadedSettings.SlotlessItems, NewSettingsOffByDefault);
        }
    }
}
