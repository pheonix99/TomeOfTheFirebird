using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Configurator for <see cref="CanMakeFullAttackConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(CanMakeFullAttackConsideration))]
  public class CanMakeFullAttackConsiderationConfigurator : BaseConsiderationConfigurator<CanMakeFullAttackConsideration, CanMakeFullAttackConsiderationConfigurator>
  {
    private CanMakeFullAttackConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CanMakeFullAttackConsiderationConfigurator For(string name)
    {
      return new CanMakeFullAttackConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CanMakeFullAttackConsiderationConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<CanMakeFullAttackConsideration>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="CanMakeFullAttackConsideration.SuccessScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CanMakeFullAttackConsiderationConfigurator SetSuccessScore(float successScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.SuccessScore = successScore;
          });
    }

    /// <summary>
    /// Sets <see cref="CanMakeFullAttackConsideration.FailScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CanMakeFullAttackConsiderationConfigurator SetFailScore(float failScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.FailScore = failScore;
          });
    }
  }
}
