using Kingmaker.Localization;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using TabletopTweaks.Core.Utilities;

namespace TomeOfTheFirebird.Reference
{
    public static class LocalizedStrings
    {
        public static LocalizedString OneMinutePerLevelDuration => BlueprintTools.GetBlueprint<BlueprintAbility>("a5e23522eda32dc45801e32c05dc9f96").LocalizedDuration;
        public static LocalizedString RefHalf => BlueprintTools.GetBlueprint<BlueprintAbility>("645558d63604747428d55f0dd3a4cb58").LocalizedSavingThrow;

        public static LocalizedString OneRoundPerLevelDuration => BlueprintTools.GetBlueprint<BlueprintAbility>("62888999171921e4dafb46de83f4d67d").LocalizedDuration;
        

        public static LocalizedString ReflexPartial => BlueprintTools.GetBlueprint<BlueprintAbility>("0a2f7c6aa81bc6548ac7780d8b70bcbc").LocalizedSavingThrow;
        public static LocalizedString WillPartial => BlueprintTools.GetBlueprint<BlueprintAbility>("dd2a5a6e76611c04e9eac6254fcf8c6b").LocalizedSavingThrow;
        public static LocalizedString TenMinutePerLevelDuration => BlueprintTools.GetBlueprint<BlueprintAbility>("72d9f5adda6387a40a63c49d7781bbbf").LocalizedDuration;
    }
}
