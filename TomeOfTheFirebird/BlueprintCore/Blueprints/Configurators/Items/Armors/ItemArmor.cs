using BlueprintCore.Blueprints.Configurators.Items.Equipment;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Enums;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Items.Armors
{
  /// <summary>
  /// Configurator for <see cref="BlueprintItemArmor"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItemArmor))]
  public class ItemArmorConfigurator : BaseItemEquipmentConfigurator<BlueprintItemArmor, ItemArmorConfigurator>
  {
    private ItemArmorConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ItemArmorConfigurator For(string name)
    {
      return new ItemArmorConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ItemArmorConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintItemArmor>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemArmor.m_Type"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="type"><see cref="Kingmaker.Blueprints.Items.Armors.BlueprintArmorType"/></param>
    [Generated]
    public ItemArmorConfigurator SetType(string? type)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Type = BlueprintTool.GetRef<BlueprintArmorTypeReference>(type);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemArmor.m_Size"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemArmorConfigurator SetSize(Size size)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Size = size;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemArmor.m_VisualParameters"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemArmorConfigurator SetVisualParameters(ArmorVisualParameters visualParameters)
    {
      ValidateParam(visualParameters);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_VisualParameters = visualParameters;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemArmor.m_Enchantments"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enchantments"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintEquipmentEnchantment"/></param>
    [Generated]
    public ItemArmorConfigurator SetEnchantments(string[]? enchantments)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Enchantments = enchantments.Select(name => BlueprintTool.GetRef<BlueprintEquipmentEnchantmentReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintItemArmor.m_Enchantments"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enchantments"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintEquipmentEnchantment"/></param>
    [Generated]
    public ItemArmorConfigurator AddToEnchantments(params string[] enchantments)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Enchantments = CommonTool.Append(bp.m_Enchantments, enchantments.Select(name => BlueprintTool.GetRef<BlueprintEquipmentEnchantmentReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintItemArmor.m_Enchantments"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enchantments"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintEquipmentEnchantment"/></param>
    [Generated]
    public ItemArmorConfigurator RemoveFromEnchantments(params string[] enchantments)
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
    /// Sets <see cref="BlueprintItemArmor.m_OverrideShardItem"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemArmorConfigurator SetOverrideShardItem(bool overrideShardItem)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_OverrideShardItem = overrideShardItem;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemArmor.m_OverrideDestructible"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemArmorConfigurator SetOverrideDestructible(bool overrideDestructible)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_OverrideDestructible = overrideDestructible;
          });
    }
  }
}
