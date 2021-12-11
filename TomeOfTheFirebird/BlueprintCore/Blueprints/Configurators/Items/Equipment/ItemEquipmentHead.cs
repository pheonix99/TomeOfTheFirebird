using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items.Equipment;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Items.Equipment
{
  /// <summary>
  /// Configurator for <see cref="BlueprintItemEquipmentHead"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItemEquipmentHead))]
  public class ItemEquipmentHeadConfigurator : BaseItemEquipmentSimpleConfigurator<BlueprintItemEquipmentHead, ItemEquipmentHeadConfigurator>
  {
    private ItemEquipmentHeadConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ItemEquipmentHeadConfigurator For(string name)
    {
      return new ItemEquipmentHeadConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ItemEquipmentHeadConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintItemEquipmentHead>(name, guid);
      return For(name);
    }
  }
}
