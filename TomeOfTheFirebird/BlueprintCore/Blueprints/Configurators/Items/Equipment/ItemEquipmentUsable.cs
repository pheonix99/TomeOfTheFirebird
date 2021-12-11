using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.ResourceLinks;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Items.Equipment
{
  /// <summary>
  /// Configurator for <see cref="BlueprintItemEquipmentUsable"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItemEquipmentUsable))]
  public class ItemEquipmentUsableConfigurator : BaseItemEquipmentConfigurator<BlueprintItemEquipmentUsable, ItemEquipmentUsableConfigurator>
  {
    private ItemEquipmentUsableConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ItemEquipmentUsableConfigurator For(string name)
    {
      return new ItemEquipmentUsableConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ItemEquipmentUsableConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintItemEquipmentUsable>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemEquipmentUsable.Type"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemEquipmentUsableConfigurator SetType(UsableItemType type)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Type = type;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemEquipmentUsable.m_IdentifyDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemEquipmentUsableConfigurator SetIdentifyDC(int identifyDC)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_IdentifyDC = identifyDC;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemEquipmentUsable.m_InventoryEquipSound"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemEquipmentUsableConfigurator SetInventoryEquipSound(string inventoryEquipSound)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_InventoryEquipSound = inventoryEquipSound;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemEquipmentUsable.m_BeltItemPrefab"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemEquipmentUsableConfigurator SetBeltItemPrefab(PrefabLink? beltItemPrefab)
    {
      ValidateParam(beltItemPrefab);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_BeltItemPrefab = beltItemPrefab ?? Constants.Empty.PrefabLink;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemEquipmentUsable.m_Enchantments"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enchantments"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintEquipmentEnchantment"/></param>
    [Generated]
    public ItemEquipmentUsableConfigurator SetEnchantments(string[]? enchantments)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Enchantments = enchantments.Select(name => BlueprintTool.GetRef<BlueprintEquipmentEnchantmentReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintItemEquipmentUsable.m_Enchantments"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enchantments"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintEquipmentEnchantment"/></param>
    [Generated]
    public ItemEquipmentUsableConfigurator AddToEnchantments(params string[] enchantments)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Enchantments = CommonTool.Append(bp.m_Enchantments, enchantments.Select(name => BlueprintTool.GetRef<BlueprintEquipmentEnchantmentReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintItemEquipmentUsable.m_Enchantments"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enchantments"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintEquipmentEnchantment"/></param>
    [Generated]
    public ItemEquipmentUsableConfigurator RemoveFromEnchantments(params string[] enchantments)
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
  }
}
