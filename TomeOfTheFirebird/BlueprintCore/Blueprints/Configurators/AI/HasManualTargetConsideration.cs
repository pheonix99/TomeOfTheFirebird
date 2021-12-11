using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Configurator for <see cref="HasManualTargetConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(HasManualTargetConsideration))]
  public class HasManualTargetConsiderationConfigurator : BaseConsiderationConfigurator<HasManualTargetConsideration, HasManualTargetConsiderationConfigurator>
  {
    private HasManualTargetConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static HasManualTargetConsiderationConfigurator For(string name)
    {
      return new HasManualTargetConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static HasManualTargetConsiderationConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<HasManualTargetConsideration>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="HasManualTargetConsideration.HasManualTargetScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HasManualTargetConsiderationConfigurator SetHasManualTargetScore(float hasManualTargetScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.HasManualTargetScore = hasManualTargetScore;
          });
    }

    /// <summary>
    /// Sets <see cref="HasManualTargetConsideration.NoManualTargetScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HasManualTargetConsiderationConfigurator SetNoManualTargetScore(float noManualTargetScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.NoManualTargetScore = noManualTargetScore;
          });
    }
  }
}
