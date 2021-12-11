using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Configurator for <see cref="InRangeConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(InRangeConsideration))]
  public class InRangeConsiderationConfigurator : BaseConsiderationConfigurator<InRangeConsideration, InRangeConsiderationConfigurator>
  {
    private InRangeConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static InRangeConsiderationConfigurator For(string name)
    {
      return new InRangeConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static InRangeConsiderationConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<InRangeConsideration>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="InRangeConsideration.InRangeScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public InRangeConsiderationConfigurator SetInRangeScore(float inRangeScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.InRangeScore = inRangeScore;
          });
    }

    /// <summary>
    /// Sets <see cref="InRangeConsideration.OutOfRangeScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public InRangeConsiderationConfigurator SetOutOfRangeScore(float outOfRangeScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.OutOfRangeScore = outOfRangeScore;
          });
    }

    /// <summary>
    /// Sets <see cref="InRangeConsideration.OnlyIfThreated"/> (Auto Generated)
    /// </summary>
    [Generated]
    public InRangeConsiderationConfigurator SetOnlyIfThreated(bool onlyIfThreated)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.OnlyIfThreated = onlyIfThreated;
          });
    }
  }
}
