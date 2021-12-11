using BlueprintCore.Blueprints.Configurators.Items.Equipment;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.Class.Kineticist;
using System;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Items.Weapons
{
  /// <summary>
  /// Configurator for <see cref="BlueprintItemWeapon"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItemWeapon))]
  public class ItemWeaponConfigurator : BaseItemEquipmentHandConfigurator<BlueprintItemWeapon, ItemWeaponConfigurator>
  {
    private ItemWeaponConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ItemWeaponConfigurator For(string name)
    {
      return new ItemWeaponConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ItemWeaponConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintItemWeapon>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemWeapon.m_Type"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="type"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintWeaponType"/></param>
    [Generated]
    public ItemWeaponConfigurator SetType(string? type)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Type = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(type);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemWeapon.m_Size"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemWeaponConfigurator SetSize(Size size)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Size = size;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemWeapon.m_Enchantments"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enchantments"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintWeaponEnchantment"/></param>
    [Generated]
    public ItemWeaponConfigurator SetEnchantments(string[]? enchantments)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Enchantments = enchantments.Select(name => BlueprintTool.GetRef<BlueprintWeaponEnchantmentReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintItemWeapon.m_Enchantments"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enchantments"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintWeaponEnchantment"/></param>
    [Generated]
    public ItemWeaponConfigurator AddToEnchantments(params string[] enchantments)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Enchantments = CommonTool.Append(bp.m_Enchantments, enchantments.Select(name => BlueprintTool.GetRef<BlueprintWeaponEnchantmentReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintItemWeapon.m_Enchantments"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enchantments"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintWeaponEnchantment"/></param>
    [Generated]
    public ItemWeaponConfigurator RemoveFromEnchantments(params string[] enchantments)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = enchantments.Select(name => BlueprintTool.GetRef<BlueprintWeaponEnchantmentReference>(name));
            bp.m_Enchantments =
                bp.m_Enchantments
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemWeapon.m_OverrideDamageDice"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemWeaponConfigurator SetOverrideDamageDice(bool overrideDamageDice)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_OverrideDamageDice = overrideDamageDice;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemWeapon.m_DamageDice"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemWeaponConfigurator SetDamageDice(DiceFormula damageDice)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DamageDice = damageDice;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemWeapon.m_OverrideDamageType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemWeaponConfigurator SetOverrideDamageType(bool overrideDamageType)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_OverrideDamageType = overrideDamageType;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemWeapon.m_DamageType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemWeaponConfigurator SetDamageType(DamageTypeDescription damageType)
    {
      ValidateParam(damageType);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DamageType = damageType;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemWeapon.Double"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemWeaponConfigurator SetDouble(bool doubleValue)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Double = doubleValue;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemWeapon.m_SecondWeapon"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="secondWeapon"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintItemWeapon"/></param>
    [Generated]
    public ItemWeaponConfigurator SetSecondWeapon(string? secondWeapon)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_SecondWeapon = BlueprintTool.GetRef<BlueprintItemWeaponReference>(secondWeapon);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemWeapon.KeepInPolymorph"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemWeaponConfigurator SetKeepInPolymorph(bool keepInPolymorph)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.KeepInPolymorph = keepInPolymorph;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemWeapon.m_OverrideShardItem"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemWeaponConfigurator SetOverrideShardItem(bool overrideShardItem)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_OverrideShardItem = overrideShardItem;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemWeapon.m_OverrideDestructible"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemWeaponConfigurator SetOverrideDestructible(bool overrideDestructible)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_OverrideDestructible = overrideDestructible;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemWeapon.m_AlwaysPrimary"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemWeaponConfigurator SetAlwaysPrimary(bool alwaysPrimary)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AlwaysPrimary = alwaysPrimary;
          });
    }

    /// <summary>
    /// Adds <see cref="WeaponKineticBlade"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="activationAbility"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    /// <param name="blast"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(WeaponKineticBlade))]
    public ItemWeaponConfigurator AddWeaponKineticBlade(
        string? activationAbility = null,
        string? blast = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new WeaponKineticBlade();
      component.m_ActivationAbility = BlueprintTool.GetRef<BlueprintAbilityReference>(activationAbility);
      component.m_Blast = BlueprintTool.GetRef<BlueprintAbilityReference>(blast);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }
  }
}
