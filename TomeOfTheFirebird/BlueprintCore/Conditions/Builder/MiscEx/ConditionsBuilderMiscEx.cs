using BlueprintCore.Utils;
using Kingmaker.Assets.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;
using Kingmaker.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.ElementsSystem;
using Kingmaker.GameModes;
using Kingmaker.Settings.Difficulty;
using Kingmaker.UnitLogic.Mechanics.Conditions;
#nullable enable
namespace BlueprintCore.Conditions.Builder.MiscEx
{
  /// <summary>
  /// Extension to <see cref="ConditionsBuilder"/> for conditions without a better extension container such as
  /// difficulty.
  /// </summary>
  /// <inheritdoc cref="ConditionsBuilder"/>
  public static class ConditionsBuilderMiscEx
  {
    //----- Auto Generated -----/

    /// <summary>
    /// Adds <see cref="ContextConditionDifficultyHigherThan"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionDifficultyHigherThan))]
    public static ConditionsBuilder ContextConditionDifficultyHigherThan(
        this ConditionsBuilder builder,
        DifficultyPresetAsset difficulty,
        bool less = default,
        bool reverse = default,
        bool checkOnlyForMonster = default,
        bool negate = false)
    {
      builder.Validate(difficulty);
    
      var element = ElementTool.Create<ContextConditionDifficultyHigherThan>();
      element.Less = less;
      element.Reverse = reverse;
      element.CheckOnlyForMonster = checkOnlyForMonster;
      element.m_Difficulty = difficulty;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DifficultyHigherThan"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DifficultyHigherThan))]
    public static ConditionsBuilder DifficultyHigherThan(
        this ConditionsBuilder builder,
        DifficultyPresetAsset difficulty,
        bool negate = false)
    {
      builder.Validate(difficulty);
    
      var element = ElementTool.Create<DifficultyHigherThan>();
      element.m_Difficulty = difficulty;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="EnlargedEncountersCapacity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EnlargedEncountersCapacity))]
    public static ConditionsBuilder EnlargedEncountersCapacity(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<EnlargedEncountersCapacity>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="Paused"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(Paused))]
    public static ConditionsBuilder Paused(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<Paused>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="GameModeActive"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(GameModeActive))]
    public static ConditionsBuilder GameModeActive(
        this ConditionsBuilder builder,
        GameModeType.Enum gameMode = default,
        bool negate = false)
    {
      var element = ElementTool.Create<GameModeActive>();
      element.m_GameMode = gameMode;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="HasEnoughMoneyForCustomCompanion"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(HasEnoughMoneyForCustomCompanion))]
    public static ConditionsBuilder HasEnoughMoneyForCustomCompanion(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<HasEnoughMoneyForCustomCompanion>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="HasEnoughMoneyForRespec"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(HasEnoughMoneyForRespec))]
    public static ConditionsBuilder HasEnoughMoneyForRespec(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<HasEnoughMoneyForRespec>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsDLCEnabled"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="blueprintDlcReward"><see cref="Kingmaker.DLC.BlueprintDlcReward"/></param>
    [Generated]
    [Implements(typeof(IsDLCEnabled))]
    public static ConditionsBuilder IsDLCEnabled(
        this ConditionsBuilder builder,
        string? blueprintDlcReward = null,
        bool negate = false)
    {
      var element = ElementTool.Create<IsDLCEnabled>();
      element.m_BlueprintDlcReward = BlueprintTool.GetRef<BlueprintDlcRewardReference>(blueprintDlcReward);
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsListContainsItem"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="list"><see cref="Kingmaker.Blueprints.Items.BlueprintItemsList"/></param>
    [Generated]
    [Implements(typeof(IsListContainsItem))]
    public static ConditionsBuilder IsListContainsItem(
        this ConditionsBuilder builder,
        ItemEvaluator item,
        string? list = null,
        bool negate = false)
    {
      builder.Validate(item);
    
      var element = ElementTool.Create<IsListContainsItem>();
      element.Item = item;
      element.List = BlueprintTool.GetRef<BlueprintItemsList.Reference>(list);
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsRespecAllowed"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IsRespecAllowed))]
    public static ConditionsBuilder IsRespecAllowed(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<IsRespecAllowed>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsUnitCustomCompanion"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IsUnitCustomCompanion))]
    public static ConditionsBuilder IsUnitCustomCompanion(
        this ConditionsBuilder builder,
        UnitEvaluator unit,
        bool negate = false)
    {
      builder.Validate(unit);
    
      var element = ElementTool.Create<IsUnitCustomCompanion>();
      element.Unit = unit;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RespecIsFree"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RespecIsFree))]
    public static ConditionsBuilder RespecIsFree(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<RespecIsFree>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsleStateCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IsleStateCondition))]
    public static ConditionsBuilder IsleStateCondition(
        this ConditionsBuilder builder,
        IsleEvaluator isle,
        string state,
        bool negate = false)
    {
      builder.Validate(isle);
    
      var element = ElementTool.Create<IsleStateCondition>();
      element.m_Isle = isle;
      element.m_State = state;
      element.Not = negate;
      return builder.Add(element);
    }
  }
}
