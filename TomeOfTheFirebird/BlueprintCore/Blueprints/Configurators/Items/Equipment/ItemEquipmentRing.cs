using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items.Equipment;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Items.Equipment
{
  /// <summary>
  /// Configurator for <see cref="BlueprintItemEquipmentRing"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItemEquipmentRing))]
  public class ItemEquipmentRingConfigurator : BaseItemEquipmentSimpleConfigurator<BlueprintItemEquipmentRing, ItemEquipmentRingConfigurator>
  {
    private ItemEquipmentRingConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ItemEquipmentRingConfigurator For(string name)
    {
      return new ItemEquipmentRingConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ItemEquipmentRingConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintItemEquipmentRing>(name, guid);
      return For(name);
    }
  }
}
