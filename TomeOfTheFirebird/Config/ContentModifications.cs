using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.Config
{
    public class ContentModifications : IUpdatableSettings
    {
        public bool NewSettingsOffByDefault = true;
        public SettingGroup DawnOfDragons;
        public void Init()
        {
            
        }

        public void OverrideSettings(IUpdatableSettings userSettings)
        {
            var loadedSettings = userSettings as ContentModifications;
            NewSettingsOffByDefault = loadedSettings.NewSettingsOffByDefault;
            DawnOfDragons.LoadSettingGroup(loadedSettings.DawnOfDragons, NewSettingsOffByDefault);
        }
    }
}
