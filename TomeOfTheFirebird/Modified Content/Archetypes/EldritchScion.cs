using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomeOfTheFirebird.Helpers;
using TomeOfTheFirebird.New_Content.Bloodlines;

namespace TomeOfTheFirebird.Modified_Content.Archetypes
{
    class EldritchScion
    { 
        public static void AddSorcBonusFeatsToList()
        {
           var selector = MakerTools.MakeFeatureSelector("EldritchScionBloodlineFeatSelector", "Bloodline Feat", "Eldritch Scions can select sorcerer bloodline feats with their class bonus feats").Configure();

            if (Settings.IsDisabled("EldritchScionBonusFeats"))
                return;
            


            FeatureSelectionConfigurator.For("66befe7b24c42dd458952e3c47c93563").AddToAllFeatures("3a60f0c0442acfb419b0c03b584e1394").Configure();
            var sorcFeat = FeatureSelectionConfigurator.For("3a60f0c0442acfb419b0c03b584e1394").AddPrerequisiteArchetypeLevel("d078b2ef073f2814c9e338a789d97b73", "45a4607686d96a1498891b3286121780", false, group: Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite.GroupType.Any, level: 1);
            if (Settings.IsEnabled("EldritchScionSage") && TotFBloodlineTools.BloodlineRequisiteFeature != null)
            {
                sorcFeat.AddPrerequisiteArchetypeLevel("EldritchScionSageArchetype", "45a4607686d96a1498891b3286121780", false, group: Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite.GroupType.Any, level: 1);
            }
            sorcFeat.Configure();
        }
            
    }
}
