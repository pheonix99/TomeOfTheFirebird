using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="UnitsAroundConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(UnitsAroundConsideration))]
  public abstract class BaseUnitsAroundConsiderationConfigurator<T, TBuilder>
      : BaseConsiderationConfigurator<T, TBuilder>
      where T : UnitsAroundConsideration
      where TBuilder : BaseUnitsAroundConsiderationConfigurator<T, TBuilder>
  {
    protected BaseUnitsAroundConsiderationConfigurator(string name) : base(name) { }

    /// <summary>
    /// Sets <see cref="UnitsAroundConsideration.Filter"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetFilter(Kingmaker.AI.Blueprints.TargetType filter)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Filter = filter;
          });
    }

    /// <summary>
    /// Sets <see cref="UnitsAroundConsideration.MinCount"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetMinCount(int minCount)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MinCount = minCount;
          });
    }

    /// <summary>
    /// Sets <see cref="UnitsAroundConsideration.MaxCount"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetMaxCount(int maxCount)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MaxCount = maxCount;
          });
    }

    /// <summary>
    /// Sets <see cref="UnitsAroundConsideration.IncludeUnconscious"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetIncludeUnconscious(bool includeUnconscious)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IncludeUnconscious = includeUnconscious;
          });
    }

    /// <summary>
    /// Sets <see cref="UnitsAroundConsideration.BelowMinScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetBelowMinScore(float belowMinScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.BelowMinScore = belowMinScore;
          });
    }

    /// <summary>
    /// Sets <see cref="UnitsAroundConsideration.MinScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetMinScore(float minScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MinScore = minScore;
          });
    }

    /// <summary>
    /// Sets <see cref="UnitsAroundConsideration.MaxScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetMaxScore(float maxScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MaxScore = maxScore;
          });
    }

    /// <summary>
    /// Sets <see cref="UnitsAroundConsideration.ExtraTargetScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetExtraTargetScore(float extraTargetScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ExtraTargetScore = extraTargetScore;
          });
    }

    /// <summary>
    /// Sets <see cref="UnitsAroundConsideration.UseAbilityShape"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetUseAbilityShape(bool useAbilityShape)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.UseAbilityShape = useAbilityShape;
          });
    }
  }

  /// <summary>
  /// Configurator for <see cref="UnitsAroundConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(UnitsAroundConsideration))]
  public class UnitsAroundConsiderationConfigurator : BaseConsiderationConfigurator<UnitsAroundConsideration, UnitsAroundConsiderationConfigurator>
  {
    private UnitsAroundConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static UnitsAroundConsiderationConfigurator For(string name)
    {
      return new UnitsAroundConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static UnitsAroundConsiderationConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<UnitsAroundConsideration>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="UnitsAroundConsideration.Filter"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitsAroundConsiderationConfigurator SetFilter(Kingmaker.AI.Blueprints.TargetType filter)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Filter = filter;
          });
    }

    /// <summary>
    /// Sets <see cref="UnitsAroundConsideration.MinCount"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitsAroundConsiderationConfigurator SetMinCount(int minCount)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MinCount = minCount;
          });
    }

    /// <summary>
    /// Sets <see cref="UnitsAroundConsideration.MaxCount"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitsAroundConsiderationConfigurator SetMaxCount(int maxCount)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MaxCount = maxCount;
          });
    }

    /// <summary>
    /// Sets <see cref="UnitsAroundConsideration.IncludeUnconscious"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitsAroundConsiderationConfigurator SetIncludeUnconscious(bool includeUnconscious)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IncludeUnconscious = includeUnconscious;
          });
    }

    /// <summary>
    /// Sets <see cref="UnitsAroundConsideration.BelowMinScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitsAroundConsiderationConfigurator SetBelowMinScore(float belowMinScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.BelowMinScore = belowMinScore;
          });
    }

    /// <summary>
    /// Sets <see cref="UnitsAroundConsideration.MinScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitsAroundConsiderationConfigurator SetMinScore(float minScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MinScore = minScore;
          });
    }

    /// <summary>
    /// Sets <see cref="UnitsAroundConsideration.MaxScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitsAroundConsiderationConfigurator SetMaxScore(float maxScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MaxScore = maxScore;
          });
    }

    /// <summary>
    /// Sets <see cref="UnitsAroundConsideration.ExtraTargetScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitsAroundConsiderationConfigurator SetExtraTargetScore(float extraTargetScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ExtraTargetScore = extraTargetScore;
          });
    }

    /// <summary>
    /// Sets <see cref="UnitsAroundConsideration.UseAbilityShape"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitsAroundConsiderationConfigurator SetUseAbilityShape(bool useAbilityShape)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.UseAbilityShape = useAbilityShape;
          });
    }
  }
}
