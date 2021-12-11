using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items.Equipment;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Items.Equipment
{
  /// <summary>
  /// Configurator for <see cref="BlueprintItemEquipmentBelt"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItemEquipmentBelt))]
  public class ItemEquipmentBeltConfigurator : BaseItemEquipmentSimpleConfigurator<BlueprintItemEquipmentBelt, ItemEquipmentBeltConfigurator>
  {
    private ItemEquipmentBeltConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ItemEquipmentBeltConfigurator For(string name)
    {
      return new ItemEquipmentBeltConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ItemEquipmentBeltConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintItemEquipmentBelt>(name, guid);
      return For(name);
    }
  }
}
