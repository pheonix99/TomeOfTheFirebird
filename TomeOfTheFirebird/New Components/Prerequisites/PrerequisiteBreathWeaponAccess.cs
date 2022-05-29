using JetBrains.Annotations;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Class.LevelUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTweaks.Core.Utilities;

namespace TomeOfTheFirebird.New_Components.Prerequisites
{
    class PrerequisiteBreathWeaponAccess : Prerequisite
    {
        public override bool CheckInternal([CanBeNull] FeatureSelectionState selectionState, [NotNull] UnitDescriptor unit, [CanBeNull] LevelUpState state)
        {
            if (unit.Abilities.Enumerable.Any(x => x.Name.Contains("FormOfTheDragon")|| x.Blueprint.Components.OfType<SpellDescriptorComponent>().Any(x => x.Descriptor.HasAnyFlag(SpellDescriptor.BreathWeapon) && !x.Descriptor.HasAnyFlag(SpellDescriptor.Bomb))))
                return true;
            if (unit.Spellbooks.Any(x => x.GetAllKnownSpells().Any(y => y.Name.Contains("FormOfTheDragon") || y.Name.Equals("Shapechange") || y.Blueprint.Components.OfType<SpellDescriptorComponent>().Any(x => x.Descriptor.HasAnyFlag(SpellDescriptor.BreathWeapon)))))
                return true;
            if (unit.Progression.IsArchetype(BlueprintTools.GetBlueprint<BlueprintArchetype>("10d92d54d19e4a59b5bbd4259ec0974f")))
                return true;
            return false;
        }

        public override string GetUITextInternal(UnitDescriptor unit)
        {
            return "Can Use A Breath Weapon";
        }
    }
}
