using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Kingmaker.Armies.TacticalCombat.Grid.TacticalCombatGrid;

namespace TomeOfTheFirebird.Helpers
{
    internal static class InteropHelpers
    {
        public static AbilityConfigurator AddSpellToMedium(this AbilityConfigurator spell, int level)
        {
            if (Settings.IsMediumMpdEnabled())
            {
                spell.AddToSpellList(level, "ff3e034659b64d21ac57dc0d9e893bdb", true);
            }

            return spell;
        }

        public static AbilityConfigurator AddSpellToSummoner(this AbilityConfigurator spell, int level)
        {
            

            return spell;
        }

        public static AbilityConfigurator AddSpellToPsychic(this AbilityConfigurator spell, int level)
        {


            return spell;
        }

        public static AbilityConfigurator AddSpellToOccultist(this AbilityConfigurator spell, int level)
        {


            return spell;
        }

        public static AbilityConfigurator AddSpellToSpiritualist(this AbilityConfigurator spell, int level)
        {


            return spell;
        }
    }
}
