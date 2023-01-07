using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using Kingmaker.Blueprints;
using System.Collections.Generic;
using TomeOfTheFirebird.Helpers;

namespace TomeOfTheFirebird.Modified_Content.KineticistOverhaul
{
    class CreateProperElementalFoci
    {
        static List<BlueprintFeatureSelectionReference> BlastSelectors = new();
        public static void Make()
        {

            var fireblasts = MakeFireBlastSelector();
            var primaryFireFocus = MakePrimaryFireFocus();

            BlueprintFeatureSelectionReference MakeFireBlastSelector()
            {
                var maker = MakerTools.MakeFeatureSelector("TotFFireBlastSelector", "Fire Blast Selection", "Placeholder fire blast selector");
                maker.AddToAllFeatures("fbed3ca8c0d89124ebb3299ccf68c439");

                

                maker.AddToAllFeatures("89dfce413170db049b0386fff333e9e1");

                var made = maker.Configure();
                FeatureConfigurator.For("89dfce413170db049b0386fff333e9e1").AddPrerequisiteFeature("TotFFireBlastSelector").Configure();

                var refernce = made.ToReference<BlueprintFeatureSelectionReference>();
                BlastSelectors.Add(refernce);

                return refernce;

            }

            
            BlueprintFeatureReference MakePrimaryFireFocus()
            {
                var maker = MakerTools.MakeFeature("TotFPrimaryFireFocus", "Primary Element: Fire", "Kineticists who focus on the element of fire are called pyrokineticists. Pyrokineticists wield elemental fire as a potent weapon, and they possess a powerful offense.");

                maker.AddPrerequisiteNoArchetype(archetype: "365b50dba54efb74fa24c07e9b7a838c", "42a455d9ec1ad924d889272429eb8391");
                //TODO add fire equip entity
                //assetID: f83e7c4b89bffef4eb2892a78649e855
                maker.AddFacts(facts: new() { "e76a453abe7a7304cbde17a8c123ad76", "TotFFireBlastSelector" });
                
                var made = maker.Configure();



                return made.ToReference<BlueprintFeatureReference>();
                
            }

            BlueprintFeatureReference MakeExpandedFireFocus()
            {
                var maker = MakerTools.MakeFeature("TotFExpandedFireFocus", "Expanded Element: Fire", "Kineticists who focus on the element of fire are called pyrokineticists. Pyrokineticists wield elemental fire as a potent weapon, and they possess a powerful offense.");

                maker.AddPrerequisiteNoArchetype(archetype: "365b50dba54efb74fa24c07e9b7a838c", "42a455d9ec1ad924d889272429eb8391");
                //TODO add fire equip entity
                //assetID: f83e7c4b89bffef4eb2892a78649e855
                maker.AddFacts(facts: new() { "TotFFireBlastSelector" });

                var made = maker.Configure();



                return made.ToReference<BlueprintFeatureReference>();

            }

        }
    }
}
