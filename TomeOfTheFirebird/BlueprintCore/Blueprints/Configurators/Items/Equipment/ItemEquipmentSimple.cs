using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Equipment;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Items.Equipment
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintItemEquipmentSimple"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItemEquipmentSimple))]
  public abstract class BaseItemEquipmentSimpleConfigurator<T, TBuilder>
      : BaseItemEquipmentConfigurator<T, TBuilder>
      where T : BlueprintItemEquipmentSimple
      where TBuilder : BaseItemEquipmentSimpleConfigurator<T, TBuilder>
  {
    protected BaseItemEquipmentSimpleConfigurator(string name) : base(name) { }

    /// <summary>
    /// Sets <see cref="BlueprintItemEquipmentSimple.m_Enchantments"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enchantments"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintEquipmentEnchantment"/></param>
    [Generated]
    public TBuilder SetEnchantments(string[]? enchantments)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Enchantments = enchantments.Select(name => BlueprintTool.GetRef<BlueprintEquipmentEnchantmentReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintItemEquipmentSimple.m_Enchantments"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enchantments"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintEquipmentEnchantment"/></param>
    [Generated]
    public TBuilder AddToEnchantments(params string[] enchantments)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Enchantments = CommonTool.Append(bp.m_Enchantments, enchantments.Select(name => BlueprintTool.GetRef<BlueprintEquipmentEnchantmentReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintItemEquipmentSimple.m_Enchantments"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enchantments"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintEquipmentEnchantment"/></param>
    [Generated]
    public TBuilder RemoveFromEnchantments(params string[] enchantments)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = enchantments.Select(name => BlueprintTool.GetRef<BlueprintEquipmentEnchantmentReference>(name));
            bp.m_Enchantments =
                bp.m_Enchantments
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemEquipmentSimple.m_InventoryEquipSound"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetInventoryEquipSound(string inventoryEquipSound)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_InventoryEquipSound = inventoryEquipSound;
          });
    }
  }
}
