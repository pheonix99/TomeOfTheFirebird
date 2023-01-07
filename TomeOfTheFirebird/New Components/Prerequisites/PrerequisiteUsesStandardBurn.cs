using JetBrains.Annotations;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Class.Kineticist;
using Kingmaker.UnitLogic.Class.LevelUp;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Actions;
using System.Linq;


namespace TomeOfTheFirebird.New_Components.Prerequisites
{
    class PrerequisiteUsesStandardBurn : Prerequisite
    {
        public override bool CheckInternal([CanBeNull] FeatureSelectionState selectionState, [NotNull] UnitDescriptor unit, [CanBeNull] LevelUpState state)
        {
            return unit.Progression.Features.Enumerable.Any(x => x.Blueprint.GetComponent<AddKineticistPart>() != null && x.Blueprint.GetComponent<AddKineticistBurnValueChangedTrigger>(x => x.Action.Actions.OfType<ContextActionApplyBuff>().Any(x => x.Buff.GetComponent<AddContextStatBonus>()?.Stat == Kingmaker.EntitySystem.Stats.StatType.DamageNonLethal)));
        }

        public override string GetUITextInternal(UnitDescriptor unit)
        {
            return "Takes Nonlethal Damage From Burn";
        }
    }
}
