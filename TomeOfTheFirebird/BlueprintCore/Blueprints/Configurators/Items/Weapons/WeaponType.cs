using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.Localization;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.Utility;
using System.Linq;
using UnityEngine;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Items.Weapons
{
  /// <summary>
  /// Configurator for <see cref="BlueprintWeaponType"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintWeaponType))]
  public class WeaponTypeConfigurator : BaseBlueprintConfigurator<BlueprintWeaponType, WeaponTypeConfigurator>
  {
    private WeaponTypeConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static WeaponTypeConfigurator For(string name)
    {
      return new WeaponTypeConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static WeaponTypeConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintWeaponType>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.Category"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetCategory(WeaponCategory category)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Category = category;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_TypeNameText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetTypeNameText(LocalizedString? typeNameText)
    {
      ValidateParam(typeNameText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_TypeNameText = typeNameText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_DefaultNameText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetDefaultNameText(LocalizedString? defaultNameText)
    {
      ValidateParam(defaultNameText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DefaultNameText = defaultNameText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_DescriptionText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetDescriptionText(LocalizedString? descriptionText)
    {
      ValidateParam(descriptionText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DescriptionText = descriptionText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_MasterworkDescriptionText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetMasterworkDescriptionText(LocalizedString? masterworkDescriptionText)
    {
      ValidateParam(masterworkDescriptionText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_MasterworkDescriptionText = masterworkDescriptionText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_MagicDescriptionText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetMagicDescriptionText(LocalizedString? magicDescriptionText)
    {
      ValidateParam(magicDescriptionText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_MagicDescriptionText = magicDescriptionText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_Icon"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetIcon(Sprite icon)
    {
      ValidateParam(icon);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Icon = icon;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_VisualParameters"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetVisualParameters(WeaponVisualParameters visualParameters)
    {
      ValidateParam(visualParameters);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_VisualParameters = visualParameters;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_AttackType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetAttackType(AttackType attackType)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AttackType = attackType;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_AttackRange"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetAttackRange(Feet attackRange)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AttackRange = attackRange;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_BaseDamage"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetBaseDamage(DiceFormula baseDamage)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_BaseDamage = baseDamage;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_DamageType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetDamageType(DamageTypeDescription damageType)
    {
      ValidateParam(damageType);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DamageType = damageType;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_CriticalRollEdge"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetCriticalRollEdge(int criticalRollEdge)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CriticalRollEdge = criticalRollEdge;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_CriticalModifier"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetCriticalModifier(DamageCriticalModifierType criticalModifier)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CriticalModifier = criticalModifier;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_FighterGroupFlags"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetFighterGroupFlags(WeaponFighterGroupFlags fighterGroupFlags)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_FighterGroupFlags = fighterGroupFlags;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_Weight"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetWeight(float weight)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Weight = weight;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_IsTwoHanded"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetIsTwoHanded(bool isTwoHanded)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_IsTwoHanded = isTwoHanded;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_IsLight"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetIsLight(bool isLight)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_IsLight = isLight;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_IsMonk"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetIsMonk(bool isMonk)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_IsMonk = isMonk;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_IsNatural"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetIsNatural(bool isNatural)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_IsNatural = isNatural;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_IsUnarmed"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetIsUnarmed(bool isUnarmed)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_IsUnarmed = isUnarmed;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_OverrideAttackBonusStat"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetOverrideAttackBonusStat(bool overrideAttackBonusStat)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_OverrideAttackBonusStat = overrideAttackBonusStat;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_AttackBonusStatOverride"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetAttackBonusStatOverride(StatType attackBonusStatOverride)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AttackBonusStatOverride = attackBonusStatOverride;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_Enchantments"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enchantments"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintWeaponEnchantment"/></param>
    [Generated]
    public WeaponTypeConfigurator SetEnchantments(string[]? enchantments)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Enchantments = enchantments.Select(name => BlueprintTool.GetRef<BlueprintWeaponEnchantmentReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintWeaponType.m_Enchantments"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enchantments"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintWeaponEnchantment"/></param>
    [Generated]
    public WeaponTypeConfigurator AddToEnchantments(params string[] enchantments)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Enchantments = CommonTool.Append(bp.m_Enchantments, enchantments.Select(name => BlueprintTool.GetRef<BlueprintWeaponEnchantmentReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintWeaponType.m_Enchantments"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enchantments"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintWeaponEnchantment"/></param>
    [Generated]
    public WeaponTypeConfigurator RemoveFromEnchantments(params string[] enchantments)
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
    /// Sets <see cref="BlueprintWeaponType.m_Destructible"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetDestructible(bool destructible)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Destructible = destructible;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_ShardItem"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="shardItem"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    public WeaponTypeConfigurator SetShardItem(string? shardItem)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ShardItem = BlueprintTool.GetRef<BlueprintItemReference>(shardItem);
          });
    }
  }
}
