using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Configurator for <see cref="LastTargetConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(LastTargetConsideration))]
  public class LastTargetConsiderationConfigurator : BaseConsiderationConfigurator<LastTargetConsideration, LastTargetConsiderationConfigurator>
  {
    private LastTargetConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static LastTargetConsiderationConfigurator For(string name)
    {
      return new LastTargetConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static LastTargetConsiderationConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<LastTargetConsideration>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="LastTargetConsideration.SameLastTargetScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LastTargetConsiderationConfigurator SetSameLastTargetScore(float sameLastTargetScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.SameLastTargetScore = sameLastTargetScore;
          });
    }

    /// <summary>
    /// Sets <see cref="LastTargetConsideration.OtherLastTargetScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LastTargetConsiderationConfigurator SetOtherLastTargetScore(float otherLastTargetScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.OtherLastTargetScore = otherLastTargetScore;
          });
    }

    /// <summary>
    /// Sets <see cref="LastTargetConsideration.NoLastTargetScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LastTargetConsiderationConfigurator SetNoLastTargetScore(float noLastTargetScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.NoLastTargetScore = noLastTargetScore;
          });
    }
  }
}
