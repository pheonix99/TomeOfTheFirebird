using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items.Equipment;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Items.Equipment
{
  /// <summary>
  /// Configurator for <see cref="BlueprintItemEquipmentHandSimple"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItemEquipmentHandSimple))]
  public class ItemEquipmentHandSimpleConfigurator : BaseItemEquipmentHandConfigurator<BlueprintItemEquipmentHandSimple, ItemEquipmentHandSimpleConfigurator>
  {
    private ItemEquipmentHandSimpleConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ItemEquipmentHandSimpleConfigurator For(string name)
    {
      return new ItemEquipmentHandSimpleConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ItemEquipmentHandSimpleConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintItemEquipmentHandSimple>(name, guid);
      return For(name);
    }
  }
}
