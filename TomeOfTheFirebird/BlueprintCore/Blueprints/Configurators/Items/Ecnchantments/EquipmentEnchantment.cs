using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Designers.Mechanics.EquipmentEnchants;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using System;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Items.Ecnchantments
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintEquipmentEnchantment"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintEquipmentEnchantment))]
  public abstract class BaseEquipmentEnchantmentConfigurator<T, TBuilder>
      : BaseItemEnchantmentConfigurator<T, TBuilder>
      where T : BlueprintEquipmentEnchantment
      where TBuilder : BaseEquipmentEnchantmentConfigurator<T, TBuilder>
  {
    protected BaseEquipmentEnchantmentConfigurator(string name) : base(name) { }

    /// <summary>
    /// Adds <see cref="AllSavesBonusEquipment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AllSavesBonusEquipment))]
    public TBuilder AddAllSavesBonusEquipment(
        ModifierDescriptor descriptor = default,
        int value = default)
    {
      var component = new AllSavesBonusEquipment();
      component.Descriptor = descriptor;
      component.Value = value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EquipmentWeaponTypeDamageStatReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EquipmentWeaponTypeDamageStatReplacement))]
    public TBuilder AddEquipmentWeaponTypeDamageStatReplacement(
        StatType stat = default,
        bool allNaturalAndUnarmed = default,
        WeaponCategory category = default,
        bool requiresFinesse = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new EquipmentWeaponTypeDamageStatReplacement();
      component.Stat = stat;
      component.AllNaturalAndUnarmed = allNaturalAndUnarmed;
      component.Category = category;
      component.RequiresFinesse = requiresFinesse;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="EquipmentWeaponTypeEnhancement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EquipmentWeaponTypeEnhancement))]
    public TBuilder AddEquipmentWeaponTypeEnhancement(
        int enhancement = default,
        bool allNaturalAndUnarmed = default,
        WeaponCategory category = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new EquipmentWeaponTypeEnhancement();
      component.Enhancement = enhancement;
      component.AllNaturalAndUnarmed = allNaturalAndUnarmed;
      component.Category = category;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="NaturalDamageStatReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(NaturalDamageStatReplacement))]
    public TBuilder AddNaturalDamageStatReplacement(
        StatType stat = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new NaturalDamageStatReplacement();
      component.Stat = stat;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="WeaponGroupAttackBonusEquipment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponGroupAttackBonusEquipment))]
    public TBuilder AddWeaponGroupAttackBonusEquipment(
        WeaponFighterGroup weaponGroup = default,
        int attackBonus = default,
        ModifierDescriptor descriptor = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new WeaponGroupAttackBonusEquipment();
      component.WeaponGroup = weaponGroup;
      component.AttackBonus = attackBonus;
      component.Descriptor = descriptor;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="WeaponGroupDamageBonusEquipment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponGroupDamageBonusEquipment))]
    public TBuilder AddWeaponGroupDamageBonusEquipment(
        WeaponFighterGroup weaponGroup = default,
        int attackBonus = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new WeaponGroupDamageBonusEquipment();
      component.WeaponGroup = weaponGroup;
      component.AttackBonus = attackBonus;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="WeaponRangeTypeAttackBonusEquipment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponRangeTypeAttackBonusEquipment))]
    public TBuilder AddWeaponRangeTypeAttackBonusEquipment(
        WeaponRangeType rangeType = default,
        int attackBonus = default,
        ModifierDescriptor descriptor = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new WeaponRangeTypeAttackBonusEquipment();
      component.RangeType = rangeType;
      component.AttackBonus = attackBonus;
      component.Descriptor = descriptor;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }
  }

  /// <summary>
  /// Configurator for <see cref="BlueprintEquipmentEnchantment"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintEquipmentEnchantment))]
  public class EquipmentEnchantmentConfigurator : BaseItemEnchantmentConfigurator<BlueprintEquipmentEnchantment, EquipmentEnchantmentConfigurator>
  {
    private EquipmentEnchantmentConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static EquipmentEnchantmentConfigurator For(string name)
    {
      return new EquipmentEnchantmentConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static EquipmentEnchantmentConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintEquipmentEnchantment>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Adds <see cref="AllSavesBonusEquipment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AllSavesBonusEquipment))]
    public EquipmentEnchantmentConfigurator AddAllSavesBonusEquipment(
        ModifierDescriptor descriptor = default,
        int value = default)
    {
      var component = new AllSavesBonusEquipment();
      component.Descriptor = descriptor;
      component.Value = value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EquipmentWeaponTypeDamageStatReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EquipmentWeaponTypeDamageStatReplacement))]
    public EquipmentEnchantmentConfigurator AddEquipmentWeaponTypeDamageStatReplacement(
        StatType stat = default,
        bool allNaturalAndUnarmed = default,
        WeaponCategory category = default,
        bool requiresFinesse = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new EquipmentWeaponTypeDamageStatReplacement();
      component.Stat = stat;
      component.AllNaturalAndUnarmed = allNaturalAndUnarmed;
      component.Category = category;
      component.RequiresFinesse = requiresFinesse;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="EquipmentWeaponTypeEnhancement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EquipmentWeaponTypeEnhancement))]
    public EquipmentEnchantmentConfigurator AddEquipmentWeaponTypeEnhancement(
        int enhancement = default,
        bool allNaturalAndUnarmed = default,
        WeaponCategory category = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new EquipmentWeaponTypeEnhancement();
      component.Enhancement = enhancement;
      component.AllNaturalAndUnarmed = allNaturalAndUnarmed;
      component.Category = category;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="NaturalDamageStatReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(NaturalDamageStatReplacement))]
    public EquipmentEnchantmentConfigurator AddNaturalDamageStatReplacement(
        StatType stat = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new NaturalDamageStatReplacement();
      component.Stat = stat;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="WeaponGroupAttackBonusEquipment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponGroupAttackBonusEquipment))]
    public EquipmentEnchantmentConfigurator AddWeaponGroupAttackBonusEquipment(
        WeaponFighterGroup weaponGroup = default,
        int attackBonus = default,
        ModifierDescriptor descriptor = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new WeaponGroupAttackBonusEquipment();
      component.WeaponGroup = weaponGroup;
      component.AttackBonus = attackBonus;
      component.Descriptor = descriptor;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="WeaponGroupDamageBonusEquipment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponGroupDamageBonusEquipment))]
    public EquipmentEnchantmentConfigurator AddWeaponGroupDamageBonusEquipment(
        WeaponFighterGroup weaponGroup = default,
        int attackBonus = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new WeaponGroupDamageBonusEquipment();
      component.WeaponGroup = weaponGroup;
      component.AttackBonus = attackBonus;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="WeaponRangeTypeAttackBonusEquipment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponRangeTypeAttackBonusEquipment))]
    public EquipmentEnchantmentConfigurator AddWeaponRangeTypeAttackBonusEquipment(
        WeaponRangeType rangeType = default,
        int attackBonus = default,
        ModifierDescriptor descriptor = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new WeaponRangeTypeAttackBonusEquipment();
      component.RangeType = rangeType;
      component.AttackBonus = attackBonus;
      component.Descriptor = descriptor;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }
  }
}
