using BlueprintCore.Utils;
using TomeOfTheFirebird.Helpers;

namespace TomeOfTheFirebird.New_Content.WildTalents
{
    class AirsLeap
    {
        public static void Make()
        {
            var config = MakerTools.MakeFeature("AirsLeapFeature", LocalizationTool.GetString("AirsLeap.Name"), LocalizationTool.GetString("AirsLeap.Desc"));
            if (Settings.EnableJumpContent())
            {

            }


            config.Configure();
        }
        /*
         *  [PFS Legal] Air's Leap
Source Occult Adventures pg. 23
Talent Link Link
Element air; Type utility (Su); Level 1; Burn 0
You are always considered to have a running start when jumping, you add your kineticist level as a bonus on all Acrobatics checks to jump, you jump twice as far or high as the results of your check indicate, and you can accept 1 point of burn when jumping to double the distance you jump again (to a total of four times as far).
        */
        //Until self-yyeeting is developed just mobility bonus
    }
}
