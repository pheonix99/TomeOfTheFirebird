using BlueprintCore.Blueprints.Configurators.Classes.Selection;
using Kingmaker.Blueprints.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomeOfTheFirebird.Helpers;

namespace TomeOfTheFirebird.New_Content.WildTalents
{
    class ClockworkHeart
    {
        public static void Make()
        {
            var config = MakerTools.MakeFeature("WildTalentClockworkHeart", "Clockwork Heart", "You have used your power over metal to add clockwork components to your own body. So long as these clockwork components are kept wound (per the winding ability of the clockwork subtypeB3), you gain the benefits of both the Improved Initiative and Lightning Reflexes feats.", false);
            config.SetIsClassFeature(true);
            config.SetRanks(1);
            config.AddToGroups(FeatureGroup.KineticWildTalent);
            config.AddPrerequisiteClassLevel("42a455d9ec1ad924d889272429eb8391", 6);
            config.AddPrerequisiteFeature("ad20bc4e586278c4996d4a81b2448998");
            config.AddFacts(facts: new() { "797f25d709f559546b29e7bcb181cc74", "15e7da6645a7f3d41bdad7c8c4b9de1e" });

            var made = config.Configure();

            if (Main.TotFContext.NewContent.WildTalents.IsDisabled("ClockworkHeart"))
                return;
            FeatureSelectionConfigurator.For("5c883ae0cd6d7d5448b7a420f51f8459").AddToAllFeatures(made).Configure();




        }

        /*
         * Clockwork Heart

Source PPC:HoG

Element earth; Type utility (Su); Level 3; Burn —
Prerequisite(s) metal blast

You have used your power over metal to add clockwork components to your own body. So long as these clockwork components are kept wound (per the winding ability of the clockwork subtypeB3), you gain the benefits of both the Improved Initiative and Lightning Reflexes feats.
         */

    }
}
