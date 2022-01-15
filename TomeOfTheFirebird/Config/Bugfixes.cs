using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.Config
{
    public class Bugfixes : IUpdatableSettings
    {
        public bool NewSettingsOffByDefault = false;
        public SettingGroup FixExtraHits;
        public SettingGroup Purifier;
        public SettingGroup Items;
        public void Init()
        {
            
        }

        public void OverrideSettings(IUpdatableSettings userSettings)
        {
            var loadedSettings = userSettings as Bugfixes;
            NewSettingsOffByDefault = loadedSettings.NewSettingsOffByDefault;
            FixExtraHits.LoadSettingGroup(loadedSettings.FixExtraHits, NewSettingsOffByDefault);
            Purifier.LoadSettingGroup(loadedSettings.Purifier, NewSettingsOffByDefault);
            Items.LoadSettingGroup(loadedSettings.Items, NewSettingsOffByDefault);
            

        }
    }
}
