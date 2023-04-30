using BlueprintCore.Utils;
using TomeOfTheFirebird.Helpers;

namespace TomeOfTheFirebird.New_Content.Feats
{
    class KineticLeap
    {
        public static void Make()
        {
            var config = MakerTools.MakeFeature("KineticLeapFeature", LocalizationTool.GetString("KineticLeap.Name"), LocalizationTool.GetString("KineticLeap.Desc"));
            var baseFeatureConfig = MakerTools.MakeLocalizedAbility("KineticLeapBaseAbility", "KineticLeap.Name", "KineticLeapBaseAbility.Desc");
            if (Settings.EnableJumpContent())
            {

            }

            baseFeatureConfig.Configure();
            config.Configure();
        }

        /*
         *  Kinetic Leap
Source Occult Adventures pg. 136
Kinetic energy propels you when you jump.

Prerequisites: Acrobatics 3 ranks, kinetic blast class feature.

Benefit: Once per day as a swift action, you can conjure a burst of energy from your kinetic blast to help you jump a long distance, adding a +10 bonus on your Acrobatics check to jump; if you have at least 10 ranks in Acrobatics, the bonus increases to +20. By accepting 1 point of burn, you can use this ability at will until your burn is removed.
         */
    }
}
