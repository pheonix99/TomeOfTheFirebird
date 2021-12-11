using BlueprintCore.Blueprints.Configurators.Items.Equipment;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Shields;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Items.Shields
{
  /// <summary>
  /// Configurator for <see cref="BlueprintItemShield"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItemShield))]
  public class ItemShieldConfigurator : BaseItemEquipmentHandConfigurator<BlueprintItemShield, ItemShieldConfigurator>
  {
    private ItemShieldConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ItemShieldConfigurator For(string name)
    {
      return new ItemShieldConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ItemShieldConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintItemShield>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemShield.m_WeaponComponent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponComponent"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintItemWeapon"/></param>
    [Generated]
    public ItemShieldConfigurator SetWeaponComponent(string? weaponComponent)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_WeaponComponent = BlueprintTool.GetRef<BlueprintItemWeaponReference>(weaponComponent);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemShield.m_ArmorComponent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="armorComponent"><see cref="Kingmaker.Blueprints.Items.Armors.BlueprintItemArmor"/></param>
    [Generated]
    public ItemShieldConfigurator SetArmorComponent(string? armorComponent)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ArmorComponent = BlueprintTool.GetRef<BlueprintItemArmorReference>(armorComponent);
          });
    }
  }
}
