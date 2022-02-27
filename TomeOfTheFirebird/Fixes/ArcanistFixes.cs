using BlueprintCore.Blueprints.Configurators.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomeOfTheFirebird.Config;

namespace TomeOfTheFirebird.Fixes
{
    public static class ArcanistFixes
    {
        public static void DoFixes()
        {

            DoExploitFixes();
            void DoExploitFixes()
            {
                FixHolyWaterJet();
                void FixHolyWaterJet()
                {
                    if (ModSettings.Bugfixes.Arcanist.IsDisabled("FixHolyWaterJet"))
                        return;

                    FeatureConfigurator.For("3ff84c64d01075d4cbc3dc274c48a4bf").RemoveComponents(x => x is PrerequisiteClassLevel y && y.CharacterClass.IsMythic).Configure();
                }
            }
        }

    }
}
