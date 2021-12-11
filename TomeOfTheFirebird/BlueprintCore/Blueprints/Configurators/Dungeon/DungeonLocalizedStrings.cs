using BlueprintCore.Utils;
using Kingmaker.Dungeon.Blueprints;
using Kingmaker.Localization;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Dungeon
{
  /// <summary>
  /// Configurator for <see cref="BlueprintDungeonLocalizedStrings"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintDungeonLocalizedStrings))]
  public class DungeonLocalizedStringsConfigurator : BaseBlueprintConfigurator<BlueprintDungeonLocalizedStrings, DungeonLocalizedStringsConfigurator>
  {
    private DungeonLocalizedStringsConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static DungeonLocalizedStringsConfigurator For(string name)
    {
      return new DungeonLocalizedStringsConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static DungeonLocalizedStringsConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintDungeonLocalizedStrings>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonLocalizedStrings.StageNameParameterized"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonLocalizedStringsConfigurator SetStageNameParameterized(LocalizedString? stageNameParameterized)
    {
      ValidateParam(stageNameParameterized);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.StageNameParameterized = stageNameParameterized ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonLocalizedStrings.LeaderboardRecordValues"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonLocalizedStringsConfigurator SetLeaderboardRecordValues(BlueprintDungeonLocalizedStrings.LeaderboardRecordValue[]? leaderboardRecordValues)
    {
      ValidateParam(leaderboardRecordValues);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.LeaderboardRecordValues = leaderboardRecordValues;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintDungeonLocalizedStrings.LeaderboardRecordValues"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonLocalizedStringsConfigurator AddToLeaderboardRecordValues(params BlueprintDungeonLocalizedStrings.LeaderboardRecordValue[] leaderboardRecordValues)
    {
      ValidateParam(leaderboardRecordValues);
      return OnConfigureInternal(
          bp =>
          {
            bp.LeaderboardRecordValues = CommonTool.Append(bp.LeaderboardRecordValues, leaderboardRecordValues ?? new BlueprintDungeonLocalizedStrings.LeaderboardRecordValue[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintDungeonLocalizedStrings.LeaderboardRecordValues"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonLocalizedStringsConfigurator RemoveFromLeaderboardRecordValues(params BlueprintDungeonLocalizedStrings.LeaderboardRecordValue[] leaderboardRecordValues)
    {
      ValidateParam(leaderboardRecordValues);
      return OnConfigureInternal(
          bp =>
          {
            bp.LeaderboardRecordValues = bp.LeaderboardRecordValues.Where(item => !leaderboardRecordValues.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonLocalizedStrings.LeaderboardCharacterValues"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonLocalizedStringsConfigurator SetLeaderboardCharacterValues(BlueprintDungeonLocalizedStrings.LeaderboardCharacterValue[]? leaderboardCharacterValues)
    {
      ValidateParam(leaderboardCharacterValues);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.LeaderboardCharacterValues = leaderboardCharacterValues;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintDungeonLocalizedStrings.LeaderboardCharacterValues"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonLocalizedStringsConfigurator AddToLeaderboardCharacterValues(params BlueprintDungeonLocalizedStrings.LeaderboardCharacterValue[] leaderboardCharacterValues)
    {
      ValidateParam(leaderboardCharacterValues);
      return OnConfigureInternal(
          bp =>
          {
            bp.LeaderboardCharacterValues = CommonTool.Append(bp.LeaderboardCharacterValues, leaderboardCharacterValues ?? new BlueprintDungeonLocalizedStrings.LeaderboardCharacterValue[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintDungeonLocalizedStrings.LeaderboardCharacterValues"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonLocalizedStringsConfigurator RemoveFromLeaderboardCharacterValues(params BlueprintDungeonLocalizedStrings.LeaderboardCharacterValue[] leaderboardCharacterValues)
    {
      ValidateParam(leaderboardCharacterValues);
      return OnConfigureInternal(
          bp =>
          {
            bp.LeaderboardCharacterValues = bp.LeaderboardCharacterValues.Where(item => !leaderboardCharacterValues.Contains(item)).ToArray();
          });
    }
  }
}
