using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Configurator for <see cref="HealthAroundConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(HealthAroundConsideration))]
  public class HealthAroundConsiderationConfigurator : BaseUnitsAroundConsiderationConfigurator<HealthAroundConsideration, HealthAroundConsiderationConfigurator>
  {
    private HealthAroundConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static HealthAroundConsiderationConfigurator For(string name)
    {
      return new HealthAroundConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static HealthAroundConsiderationConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<HealthAroundConsideration>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="HealthAroundConsideration.RequiredMissingHealth"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HealthAroundConsiderationConfigurator SetRequiredMissingHealth(int requiredMissingHealth)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.RequiredMissingHealth = requiredMissingHealth;
          });
    }

    /// <summary>
    /// Sets <see cref="HealthAroundConsideration.RequiredHealthLeft"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HealthAroundConsiderationConfigurator SetRequiredHealthLeft(int requiredHealthLeft)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.RequiredHealthLeft = requiredHealthLeft;
          });
    }
  }
}
