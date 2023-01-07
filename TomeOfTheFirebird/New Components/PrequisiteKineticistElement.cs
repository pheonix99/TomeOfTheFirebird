using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.UnitLogic;

namespace TomeOfTheFirebird.New_Components
{
    class PrequisiteKineticistElement : PrerequisiteFeaturesFromList
    {
        public override string GetUITextInternal(UnitDescriptor unit)
        {
            return $"Has Kineticist Element: {Element}";
        }

        public string Element;

    }
}
