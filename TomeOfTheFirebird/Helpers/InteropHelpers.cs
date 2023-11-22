using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;


namespace TomeOfTheFirebird.Helpers
{
    internal static class InteropHelpers
    {
        public static AbilityConfigurator AddSpellToMedium(this AbilityConfigurator spell, int level)
        {
            if (Settings.IsMediumModEnabled())
            {
                spell.AddToSpellList(level, "ff3e034659b64d21ac57dc0d9e893bdb", true);
            }

            return spell;
        }

        public static AbilityConfigurator AddSpellToSummoner(this AbilityConfigurator spell, int level)
        {
            if (Settings.IsSummonerModEnabled())
            {
                spell.AddToSpellList(level, "d1ae05197677491eb236e0aa97080da1", true);

                //Second summoner spell list
                //92e4f9a45b6148dc87a7cc6aab966fd9
            }

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
