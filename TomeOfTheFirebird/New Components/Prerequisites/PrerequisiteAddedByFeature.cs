using JetBrains.Annotations;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Class.LevelUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.New_Components.Prerequisites
{
    class PrerequisiteAddedByFeature : Prerequisite
    {
        public override bool CheckInternal([CanBeNull] FeatureSelectionState selectionState, [NotNull] UnitDescriptor unit, [CanBeNull] LevelUpState state)
        {
            if (!unit.HasFact(m_FeatureAddsRequirement.Get()))
            {
                return true;
            }
            else return (satisfies.CheckInternal(selectionState, unit, state));

        }

        public override string GetUITextInternal(UnitDescriptor unit)
        {
            if (!unit.HasFact(m_FeatureAddsRequirement.Get()))
            {
                return "";
            }
            else
            {
                return satisfies.GetUIText(unit);
            }
        }

        public BlueprintFeatureReference m_FeatureAddsRequirement;

        public Prerequisite satisfies;
    }
}
