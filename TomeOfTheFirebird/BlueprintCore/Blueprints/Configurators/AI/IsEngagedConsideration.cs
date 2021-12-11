using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Configurator for <see cref="IsEngagedConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(IsEngagedConsideration))]
  public class IsEngagedConsiderationConfigurator : BaseConsiderationConfigurator<IsEngagedConsideration, IsEngagedConsiderationConfigurator>
  {
    private IsEngagedConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static IsEngagedConsiderationConfigurator For(string name)
    {
      return new IsEngagedConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static IsEngagedConsiderationConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<IsEngagedConsideration>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="IsEngagedConsideration.EngagedScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public IsEngagedConsiderationConfigurator SetEngagedScore(float engagedScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.EngagedScore = engagedScore;
          });
    }

    /// <summary>
    /// Sets <see cref="IsEngagedConsideration.NotEngagedScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public IsEngagedConsiderationConfigurator SetNotEngagedScore(float notEngagedScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.NotEngagedScore = notEngagedScore;
          });
    }
  }
}
