using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items.Equipment;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Items.Equipment
{
  /// <summary>
  /// Configurator for <see cref="BlueprintItemEquipmentShoulders"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItemEquipmentShoulders))]
  public class ItemEquipmentShouldersConfigurator : BaseItemEquipmentSimpleConfigurator<BlueprintItemEquipmentShoulders, ItemEquipmentShouldersConfigurator>
  {
    private ItemEquipmentShouldersConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ItemEquipmentShouldersConfigurator For(string name)
    {
      return new ItemEquipmentShouldersConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ItemEquipmentShouldersConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintItemEquipmentShoulders>(name, guid);
      return For(name);
    }
  }
}
