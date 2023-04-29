using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.New_Components
{
    internal class UnitPartJump : UnitFactComponentDelegate
    {
        public bool AutoRunup { get; private set; }

        public bool IgnoreSpeedCap { get; private set; }

        public bool DoubleDistance { get; private set; }

        public int JumpDistance(bool hasRunUp)
        {
            int finalDistance = 0;
            int baseFakeCheck = 10;

            ModifiableValueSkill skill = Owner.Stats.SkillAthletics;

            //INSERT KIN LEAP/AIR'S LEAP Modifier CHecks Here CHECK HERE


            int finalSkillVal = skill.ModifiedValue + baseFakeCheck;

            int baseSpeedShift = (Owner.Stats.Speed.PermanentValue - 30) / 5 * 4;

            finalSkillVal += baseSpeedShift;

          

            if (DoubleDistance)
            {
                finalSkillVal *= 2;
            }


            if (!hasRunUp && !AutoRunup)
            {
                finalSkillVal /= 2;
            }

            if (!IgnoreSpeedCap)
            {
                finalDistance = Math.Min(finalSkillVal, Owner.Stats.Speed.ModifiedValue);
            }
            else
            {
                finalDistance = finalSkillVal;
            }

            return finalDistance;
        }

    }
}
