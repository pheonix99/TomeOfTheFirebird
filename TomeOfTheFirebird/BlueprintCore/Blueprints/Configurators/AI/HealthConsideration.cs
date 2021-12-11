using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Configurator for <see cref="HealthConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(HealthConsideration))]
  public class HealthConsiderationConfigurator : BaseConsiderationConfigurator<HealthConsideration, HealthConsiderationConfigurator>
  {
    private HealthConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static HealthConsiderationConfigurator For(string name)
    {
      return new HealthConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static HealthConsiderationConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<HealthConsideration>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="HealthConsideration.FullBorder"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HealthConsiderationConfigurator SetFullBorder(int fullBorder)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.FullBorder = fullBorder;
          });
    }

    /// <summary>
    /// Sets <see cref="HealthConsideration.DeadBorder"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HealthConsiderationConfigurator SetDeadBorder(int deadBorder)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DeadBorder = deadBorder;
          });
    }

    /// <summary>
    /// Sets <see cref="HealthConsideration.AboveFullScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HealthConsiderationConfigurator SetAboveFullScore(float aboveFullScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AboveFullScore = aboveFullScore;
          });
    }

    /// <summary>
    /// Sets <see cref="HealthConsideration.BelowDeadScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HealthConsiderationConfigurator SetBelowDeadScore(float belowDeadScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.BelowDeadScore = belowDeadScore;
          });
    }

    /// <summary>
    /// Sets <see cref="HealthConsideration.FullScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HealthConsiderationConfigurator SetFullScore(float fullScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.FullScore = fullScore;
          });
    }

    /// <summary>
    /// Sets <see cref="HealthConsideration.DeadScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HealthConsiderationConfigurator SetDeadScore(float deadScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DeadScore = deadScore;
          });
    }
  }
}
