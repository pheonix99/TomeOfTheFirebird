using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Configurator for <see cref="DistanceRangeConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(DistanceRangeConsideration))]
  public class DistanceRangeConsiderationConfigurator : BaseConsiderationConfigurator<DistanceRangeConsideration, DistanceRangeConsiderationConfigurator>
  {
    private DistanceRangeConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static DistanceRangeConsiderationConfigurator For(string name)
    {
      return new DistanceRangeConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static DistanceRangeConsiderationConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<DistanceRangeConsideration>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="DistanceRangeConsideration.MinDistance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DistanceRangeConsiderationConfigurator SetMinDistance(float minDistance)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MinDistance = minDistance;
          });
    }

    /// <summary>
    /// Sets <see cref="DistanceRangeConsideration.MaxDistance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DistanceRangeConsiderationConfigurator SetMaxDistance(float maxDistance)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MaxDistance = maxDistance;
          });
    }

    /// <summary>
    /// Sets <see cref="DistanceRangeConsideration.InsideDistanceRangeScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DistanceRangeConsiderationConfigurator SetInsideDistanceRangeScore(float insideDistanceRangeScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.InsideDistanceRangeScore = insideDistanceRangeScore;
          });
    }

    /// <summary>
    /// Sets <see cref="DistanceRangeConsideration.OutsideDistanceRangeScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DistanceRangeConsiderationConfigurator SetOutsideDistanceRangeScore(float outsideDistanceRangeScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.OutsideDistanceRangeScore = outsideDistanceRangeScore;
          });
    }
  }
}
