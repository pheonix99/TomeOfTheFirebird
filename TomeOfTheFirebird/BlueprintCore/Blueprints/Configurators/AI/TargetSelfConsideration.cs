using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Configurator for <see cref="TargetSelfConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(TargetSelfConsideration))]
  public class TargetSelfConsiderationConfigurator : BaseConsiderationConfigurator<TargetSelfConsideration, TargetSelfConsiderationConfigurator>
  {
    private TargetSelfConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static TargetSelfConsiderationConfigurator For(string name)
    {
      return new TargetSelfConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static TargetSelfConsiderationConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<TargetSelfConsideration>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="TargetSelfConsideration.SelfScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TargetSelfConsiderationConfigurator SetSelfScore(float selfScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.SelfScore = selfScore;
          });
    }

    /// <summary>
    /// Sets <see cref="TargetSelfConsideration.OthersScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TargetSelfConsiderationConfigurator SetOthersScore(float othersScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.OthersScore = othersScore;
          });
    }
  }
}
