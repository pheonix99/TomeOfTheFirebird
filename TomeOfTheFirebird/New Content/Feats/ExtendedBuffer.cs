using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomeOfTheFirebird.Helpers;
using TomeOfTheFirebird.New_Components.Prerequisites;

namespace TomeOfTheFirebird.New_Content.Feats
{
    class ExtendedBuffer
    {

        public static void Make()
        {
            string sysName = "ExtendedBufferFeature";
            BlueprintCore.Blueprints.CustomConfigurators.Classes.FeatureConfigurator config = MakerTools.MakeFeature(sysName, "Extended Buffer", "You may increase the amount of burn you can store within your Internal Buffer class feature by 1.\nSpecial: This feat may be taken once at 7th level, and again at 13th and 19th.");
            config.AddAbilityResources(1, "InternalBufferResource");
            config.AddComponent<PrerequisiteClassLevelPerRank>(x =>
            {
                x.requirements = new int[] { 7, 13, 19 };
                x.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>("42a455d9ec1ad924d889272429eb8391");

            });
            config.AddPrerequisiteFeature("InternalBufferFeature");
            config.SetRanks(3);
            config.AddToGroups(FeatureGroup.Feat);

            BlueprintFeature done = config.Configure();
            Main.TotFContext.Logger.LogPatch(done);
            if (Settings.IsDisabled("InternalBuffer"))
                return;
            if (Settings.IsDisabled("ExtendedBuffer"))
                return;
            TabletopTweaks.Core.Utilities.FeatTools.AddAsFeat(done);

            FeatureConfigurator.For("InternalBufferFeature").AddToIsPrerequisiteFor("ExtendedBufferFeature").Configure();



        }
        /*
         * Extended Buffer

“I just know how to take a hit better, even when I’m doing it myself!”

Prerequisite: Internal Buffer class feature, 7th-level kineticist

Benefit: You may increase the amount of burn you can store within your Internal Buffer class feature by 1.

Special: This feat may be taken once at 7th level, and again at 13th and 19th.
         */
    }
}
