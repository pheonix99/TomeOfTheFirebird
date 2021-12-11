using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Configurator for <see cref="SwarmTargetsConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(SwarmTargetsConsideration))]
  public class SwarmTargetsConsiderationConfigurator : BaseConsiderationConfigurator<SwarmTargetsConsideration, SwarmTargetsConsiderationConfigurator>
  {
    private SwarmTargetsConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static SwarmTargetsConsiderationConfigurator For(string name)
    {
      return new SwarmTargetsConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static SwarmTargetsConsiderationConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<SwarmTargetsConsideration>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="SwarmTargetsConsideration.HasEnemiesScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SwarmTargetsConsiderationConfigurator SetHasEnemiesScore(float hasEnemiesScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.HasEnemiesScore = hasEnemiesScore;
          });
    }

    /// <summary>
    /// Sets <see cref="SwarmTargetsConsideration.NoEnemiesScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SwarmTargetsConsiderationConfigurator SetNoEnemiesScore(float noEnemiesScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.NoEnemiesScore = noEnemiesScore;
          });
    }
  }
}
