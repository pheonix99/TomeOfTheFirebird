using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Configurator for <see cref="ThreatedByConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(ThreatedByConsideration))]
  public class ThreatedByConsiderationConfigurator : BaseConsiderationConfigurator<ThreatedByConsideration, ThreatedByConsiderationConfigurator>
  {
    private ThreatedByConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ThreatedByConsiderationConfigurator For(string name)
    {
      return new ThreatedByConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ThreatedByConsiderationConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<ThreatedByConsideration>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="ThreatedByConsideration.MinCount"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ThreatedByConsiderationConfigurator SetMinCount(int minCount)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MinCount = minCount;
          });
    }

    /// <summary>
    /// Sets <see cref="ThreatedByConsideration.MaxCount"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ThreatedByConsiderationConfigurator SetMaxCount(int maxCount)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MaxCount = maxCount;
          });
    }

    /// <summary>
    /// Sets <see cref="ThreatedByConsideration.BelowMinScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ThreatedByConsiderationConfigurator SetBelowMinScore(float belowMinScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.BelowMinScore = belowMinScore;
          });
    }

    /// <summary>
    /// Sets <see cref="ThreatedByConsideration.MinScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ThreatedByConsiderationConfigurator SetMinScore(float minScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MinScore = minScore;
          });
    }

    /// <summary>
    /// Sets <see cref="ThreatedByConsideration.MaxScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ThreatedByConsiderationConfigurator SetMaxScore(float maxScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MaxScore = maxScore;
          });
    }

    /// <summary>
    /// Sets <see cref="ThreatedByConsideration.ExtraTargetScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ThreatedByConsiderationConfigurator SetExtraTargetScore(float extraTargetScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ExtraTargetScore = extraTargetScore;
          });
    }
  }
}
