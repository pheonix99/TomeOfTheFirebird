using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items.Equipment;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Items.Equipment
{
  /// <summary>
  /// Configurator for <see cref="BlueprintItemEquipmentWrist"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItemEquipmentWrist))]
  public class ItemEquipmentWristConfigurator : BaseItemEquipmentSimpleConfigurator<BlueprintItemEquipmentWrist, ItemEquipmentWristConfigurator>
  {
    private ItemEquipmentWristConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ItemEquipmentWristConfigurator For(string name)
    {
      return new ItemEquipmentWristConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ItemEquipmentWristConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintItemEquipmentWrist>(name, guid);
      return For(name);
    }
  }
}
