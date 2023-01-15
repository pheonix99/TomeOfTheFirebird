using JetBrains.Annotations;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Class.LevelUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.New_Components.Prerequisites
{
    class PrerequisiteArchetypeCantTakeWithX : Prerequisite
    {
        
        public List<BlueprintArchetypeReference> blockedArchetypes = new();

        public BlueprintFeatureSelectionReference blocked;

        public override bool CheckInternal([CanBeNull] FeatureSelectionState selectionState, [NotNull] UnitDescriptor unit, [CanBeNull] LevelUpState state)
        {
            if (selectionState.Selection is BlueprintFeatureSelection selection)
            {
                if (selection.ToReference<BlueprintFeatureSelectionReference>().Equals(blocked))
                {
                    foreach(var arch in blockedArchetypes)
                    {
                        if (unit.Progression.IsArchetype(arch))
                            return false;
                    }
                    
                }
            }

            return true;
        }

        public override string GetUITextInternal(UnitDescriptor unit)
        {
            return "";
        }
    }
}
