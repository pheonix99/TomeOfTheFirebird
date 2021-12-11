using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Configurator for <see cref="UnitsThreateningConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(UnitsThreateningConsideration))]
  public class UnitsThreateningConsiderationConfigurator : BaseConsiderationConfigurator<UnitsThreateningConsideration, UnitsThreateningConsiderationConfigurator>
  {
    private UnitsThreateningConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static UnitsThreateningConsiderationConfigurator For(string name)
    {
      return new UnitsThreateningConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static UnitsThreateningConsiderationConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<UnitsThreateningConsideration>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="UnitsThreateningConsideration.MinCount"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitsThreateningConsiderationConfigurator SetMinCount(int minCount)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MinCount = minCount;
          });
    }

    /// <summary>
    /// Sets <see cref="UnitsThreateningConsideration.MaxCount"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitsThreateningConsiderationConfigurator SetMaxCount(int maxCount)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MaxCount = maxCount;
          });
    }

    /// <summary>
    /// Sets <see cref="UnitsThreateningConsideration.BelowMinScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitsThreateningConsiderationConfigurator SetBelowMinScore(float belowMinScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.BelowMinScore = belowMinScore;
          });
    }

    /// <summary>
    /// Sets <see cref="UnitsThreateningConsideration.MinScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitsThreateningConsiderationConfigurator SetMinScore(float minScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MinScore = minScore;
          });
    }

    /// <summary>
    /// Sets <see cref="UnitsThreateningConsideration.MaxScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitsThreateningConsiderationConfigurator SetMaxScore(float maxScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MaxScore = maxScore;
          });
    }

    /// <summary>
    /// Sets <see cref="UnitsThreateningConsideration.ExtraTargetScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitsThreateningConsiderationConfigurator SetExtraTargetScore(float extraTargetScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ExtraTargetScore = extraTargetScore;
          });
    }
  }
}
