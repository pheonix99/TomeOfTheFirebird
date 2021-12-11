using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Configurator for <see cref="HitThisRoundConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(HitThisRoundConsideration))]
  public class HitThisRoundConsiderationConfigurator : BaseConsiderationConfigurator<HitThisRoundConsideration, HitThisRoundConsiderationConfigurator>
  {
    private HitThisRoundConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static HitThisRoundConsiderationConfigurator For(string name)
    {
      return new HitThisRoundConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static HitThisRoundConsiderationConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<HitThisRoundConsideration>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="HitThisRoundConsideration.HitScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitThisRoundConsiderationConfigurator SetHitScore(float hitScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.HitScore = hitScore;
          });
    }

    /// <summary>
    /// Sets <see cref="HitThisRoundConsideration.NoHitScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitThisRoundConsiderationConfigurator SetNoHitScore(float noHitScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.NoHitScore = noHitScore;
          });
    }
  }
}
