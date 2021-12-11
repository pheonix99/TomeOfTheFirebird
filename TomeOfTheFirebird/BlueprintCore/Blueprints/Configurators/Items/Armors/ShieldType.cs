using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Blueprints.Items.Weapons;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Items.Armors
{
  /// <summary>
  /// Configurator for <see cref="BlueprintShieldType"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintShieldType))]
  public class ShieldTypeConfigurator : BaseArmorTypeConfigurator<BlueprintShieldType, ShieldTypeConfigurator>
  {
    private ShieldTypeConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ShieldTypeConfigurator For(string name)
    {
      return new ShieldTypeConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ShieldTypeConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintShieldType>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintShieldType.m_HandVisualParameters"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ShieldTypeConfigurator SetHandVisualParameters(WeaponVisualParameters handVisualParameters)
    {
      ValidateParam(handVisualParameters);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_HandVisualParameters = handVisualParameters;
          });
    }
  }
}
