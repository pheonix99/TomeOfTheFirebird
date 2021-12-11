using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items.Equipment;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Items.Equipment
{
  /// <summary>
  /// Configurator for <see cref="BlueprintItemEquipmentGloves"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItemEquipmentGloves))]
  public class ItemEquipmentGlovesConfigurator : BaseItemEquipmentSimpleConfigurator<BlueprintItemEquipmentGloves, ItemEquipmentGlovesConfigurator>
  {
    private ItemEquipmentGlovesConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ItemEquipmentGlovesConfigurator For(string name)
    {
      return new ItemEquipmentGlovesConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ItemEquipmentGlovesConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintItemEquipmentGloves>(name, guid);
      return For(name);
    }
  }
}
