using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using System;
using TabletopTweaks.Core.Utilities;
using TomeOfTheFirebird.Helpers;

namespace TomeOfTheFirebird.NewContent.Features
{
    class PurifierLimitedCures
    {
        public static void AddPurifierLimitedCures()
        {
            var PuriferArchetype = BlueprintTools.GetBlueprint<BlueprintArchetype>("c9df67160a77ecd4a97928f2455545d7");
            var Oracle = PuriferArchetype.GetParentClass();


            BlueprintFeature oracleCures = BlueprintTools.GetBlueprint<BlueprintFeature>("0f7fb23d8f97b024388a433c5a8d493f").ToReference<BlueprintFeatureReference>();
            //var cure1 = oracleCures.Components.FirstOrDefault(x => (x as AddKnownSpell).SpellLevel == 1);
            //var cure2 = oracleCures.Components.FirstOrDefault(x => (x as AddKnownSpell).SpellLevel == 2);
            var make = MakerTools.MakeFeature("PurifierLimitedCures", "Basic Cure Spells", "Purifers still can cast the most basic cure spells", icon:oracleCures.Icon);
            make.SetIsClassFeature(true);
            make.SetHideInUi(false);
            
            make.SetHideInCharacterSheetAndLevelUp(false);
           
            make.SetRanks(1);
            make.SetReapplyOnLevelUp(true);
            make.AddKnownSpell(Oracle.AssetGuidThreadSafe, 1, "5590652e1c2225c4ca30c4a699ab3649", PuriferArchetype.AssetGuidThreadSafe);
            make.AddKnownSpell(Oracle.AssetGuidThreadSafe, 2, "6b90c773a6543dc49b2505858ce33db5", PuriferArchetype.AssetGuidThreadSafe);
            make.Configure();



        }
    }
}
