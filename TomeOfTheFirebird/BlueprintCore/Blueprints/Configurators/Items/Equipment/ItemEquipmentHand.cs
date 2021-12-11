using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.Blueprints.Items.Weapons;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Items.Equipment
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintItemEquipmentHand"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItemEquipmentHand))]
  public abstract class BaseItemEquipmentHandConfigurator<T, TBuilder>
      : BaseItemEquipmentConfigurator<T, TBuilder>
      where T : BlueprintItemEquipmentHand
      where TBuilder : BaseItemEquipmentHandConfigurator<T, TBuilder>
  {
    protected BaseItemEquipmentHandConfigurator(string name) : base(name) { }

    /// <summary>
    /// Sets <see cref="BlueprintItemEquipmentHand.m_VisualParameters"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetVisualParameters(WeaponVisualParameters visualParameters)
    {
      ValidateParam(visualParameters);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_VisualParameters = visualParameters;
          });
    }
  }
}
