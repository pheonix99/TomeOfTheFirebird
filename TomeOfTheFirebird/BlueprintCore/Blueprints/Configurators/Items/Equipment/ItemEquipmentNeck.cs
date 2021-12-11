using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items.Equipment;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Items.Equipment
{
  /// <summary>
  /// Configurator for <see cref="BlueprintItemEquipmentNeck"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItemEquipmentNeck))]
  public class ItemEquipmentNeckConfigurator : BaseItemEquipmentSimpleConfigurator<BlueprintItemEquipmentNeck, ItemEquipmentNeckConfigurator>
  {
    private ItemEquipmentNeckConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ItemEquipmentNeckConfigurator For(string name)
    {
      return new ItemEquipmentNeckConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ItemEquipmentNeckConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintItemEquipmentNeck>(name, guid);
      return For(name);
    }
  }
}
