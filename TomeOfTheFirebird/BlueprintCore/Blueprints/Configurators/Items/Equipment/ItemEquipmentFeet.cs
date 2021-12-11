using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items.Equipment;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Items.Equipment
{
  /// <summary>
  /// Configurator for <see cref="BlueprintItemEquipmentFeet"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItemEquipmentFeet))]
  public class ItemEquipmentFeetConfigurator : BaseItemEquipmentSimpleConfigurator<BlueprintItemEquipmentFeet, ItemEquipmentFeetConfigurator>
  {
    private ItemEquipmentFeetConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ItemEquipmentFeetConfigurator For(string name)
    {
      return new ItemEquipmentFeetConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ItemEquipmentFeetConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintItemEquipmentFeet>(name, guid);
      return For(name);
    }
  }
}
