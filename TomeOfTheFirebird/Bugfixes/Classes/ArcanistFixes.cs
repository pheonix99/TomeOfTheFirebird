using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;

namespace TomeOfTheFirebird.Bugfixes.Classes
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
                    //Still needed in EE
                    if (Settings.IsDisabled("FixHolyWaterJet"))
                        return;

                    FeatureConfigurator.For("3ff84c64d01075d4cbc3dc274c48a4bf").RemoveComponents(x => x is PrerequisiteClassLevel y && y.CharacterClass.IsMythic).Configure();
                }
            }
        }

    }
}
