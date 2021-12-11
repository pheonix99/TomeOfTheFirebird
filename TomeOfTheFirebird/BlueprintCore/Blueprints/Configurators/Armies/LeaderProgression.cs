using BlueprintCore.Utils;
using Kingmaker.Armies;
using Kingmaker.Localization;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Armies
{
  /// <summary>
  /// Configurator for <see cref="BlueprintLeaderProgression"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintLeaderProgression))]
  public class LeaderProgressionConfigurator : BaseBlueprintConfigurator<BlueprintLeaderProgression, LeaderProgressionConfigurator>
  {
    private LeaderProgressionConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static LeaderProgressionConfigurator For(string name)
    {
      return new LeaderProgressionConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static LeaderProgressionConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintLeaderProgression>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintLeaderProgression.m_ProgressionType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LeaderProgressionConfigurator SetProgressionType(LeaderProgressionType progressionType)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ProgressionType = progressionType;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintLeaderProgression.m_ProgressionName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LeaderProgressionConfigurator SetProgressionName(LocalizedString? progressionName)
    {
      ValidateParam(progressionName);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ProgressionName = progressionName ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintLeaderProgression.m_Levels"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LeaderProgressionConfigurator SetLevels(LeaderLevel[]? levels)
    {
      ValidateParam(levels);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Levels = levels;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintLeaderProgression.m_Levels"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LeaderProgressionConfigurator AddToLevels(params LeaderLevel[] levels)
    {
      ValidateParam(levels);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Levels = CommonTool.Append(bp.m_Levels, levels ?? new LeaderLevel[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintLeaderProgression.m_Levels"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LeaderProgressionConfigurator RemoveFromLevels(params LeaderLevel[] levels)
    {
      ValidateParam(levels);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Levels = bp.m_Levels.Where(item => !levels.Contains(item)).ToArray();
          });
    }
  }
}
