using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Configurator for <see cref="ArmorTypeConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(ArmorTypeConsideration))]
  public class ArmorTypeConsiderationConfigurator : BaseConsiderationConfigurator<ArmorTypeConsideration, ArmorTypeConsiderationConfigurator>
  {
    private ArmorTypeConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ArmorTypeConsiderationConfigurator For(string name)
    {
      return new ArmorTypeConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ArmorTypeConsiderationConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<ArmorTypeConsideration>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="ArmorTypeConsideration.LightArmorScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmorTypeConsiderationConfigurator SetLightArmorScore(float lightArmorScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.LightArmorScore = lightArmorScore;
          });
    }

    /// <summary>
    /// Sets <see cref="ArmorTypeConsideration.HeavyArmorScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmorTypeConsiderationConfigurator SetHeavyArmorScore(float heavyArmorScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.HeavyArmorScore = heavyArmorScore;
          });
    }
  }
}
