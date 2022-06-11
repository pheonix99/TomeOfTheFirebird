using JetBrains.Annotations;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Root.Strings;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Class.LevelUp;
using System.Text;

namespace TomeOfTheFirebird.New_Components.Prerequisites
{
    public class PrerequisiteProperty : Prerequisite
    {
        public BlueprintUnitPropertyReference propertyReference;
        public int value = 0;
        public bool not = false;
        public string UserFacingPropertyName = string.Empty;
        public override bool CheckInternal([CanBeNull] FeatureSelectionState selectionState, [NotNull] UnitDescriptor unit, [CanBeNull] LevelUpState state)
        {
            if (not)
            {
                return propertyReference.Get().GetInt(unit) < value;
            }
            else
                return propertyReference.Get().GetInt(unit) >= value;
           
        }

        public override string GetUITextInternal(UnitDescriptor unit)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (UserFacingPropertyName == string.Empty)
            {
                stringBuilder.Append(propertyReference.Get().NameSafe());
            }
            else
            {
                stringBuilder.Append(UserFacingPropertyName);
            }
          
            stringBuilder.Append(" ");
            stringBuilder.Append(value);
            stringBuilder.Append("\n");
            stringBuilder.Append(string.Format(UIStrings.Instance.Tooltips.CurrentValue, propertyReference.Get().GetInt(unit)));

            return stringBuilder.ToString();
        }
    }
}
