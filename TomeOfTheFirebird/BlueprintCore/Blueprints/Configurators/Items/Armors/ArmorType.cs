using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Localization;
using System.Linq;
using UnityEngine;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Items.Armors
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintArmorType"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintArmorType))]
  public abstract class BaseArmorTypeConfigurator<T, TBuilder>
      : BaseBlueprintConfigurator<T, TBuilder>
      where T : BlueprintArmorType
      where TBuilder : BaseArmorTypeConfigurator<T, TBuilder>
  {
    protected BaseArmorTypeConfigurator(string name) : base(name) { }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_TypeNameText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetTypeNameText(LocalizedString? typeNameText)
    {
      ValidateParam(typeNameText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_TypeNameText = typeNameText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_DefaultNameText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetDefaultNameText(LocalizedString? defaultNameText)
    {
      ValidateParam(defaultNameText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DefaultNameText = defaultNameText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_DescriptionText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetDescriptionText(LocalizedString? descriptionText)
    {
      ValidateParam(descriptionText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DescriptionText = descriptionText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_MagicDescriptionText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetMagicDescriptionText(LocalizedString? magicDescriptionText)
    {
      ValidateParam(magicDescriptionText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_MagicDescriptionText = magicDescriptionText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_Icon"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetIcon(Sprite icon)
    {
      ValidateParam(icon);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Icon = icon;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_VisualParameters"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetVisualParameters(ArmorVisualParameters visualParameters)
    {
      ValidateParam(visualParameters);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_VisualParameters = visualParameters;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_ArmorBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetArmorBonus(int armorBonus)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ArmorBonus = armorBonus;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_ArmorChecksPenalty"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetArmorChecksPenalty(int armorChecksPenalty)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ArmorChecksPenalty = armorChecksPenalty;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_HasDexterityBonusLimit"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetHasDexterityBonusLimit(bool hasDexterityBonusLimit)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_HasDexterityBonusLimit = hasDexterityBonusLimit;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_MaxDexterityBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetMaxDexterityBonus(int maxDexterityBonus)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_MaxDexterityBonus = maxDexterityBonus;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_ProficiencyGroup"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetProficiencyGroup(ArmorProficiencyGroup proficiencyGroup)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ProficiencyGroup = proficiencyGroup;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_ArcaneSpellFailureChance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetArcaneSpellFailureChance(int arcaneSpellFailureChance)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ArcaneSpellFailureChance = arcaneSpellFailureChance;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_Weight"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetWeight(float weight)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Weight = weight;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_IsArmor"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetIsArmor(bool isArmor)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_IsArmor = isArmor;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_IsShield"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetIsShield(bool isShield)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_IsShield = isShield;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_EquipmentEntity"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="equipmentEntity"><see cref="Kingmaker.Visual.CharacterSystem.KingmakerEquipmentEntity"/></param>
    [Generated]
    public TBuilder SetEquipmentEntity(string? equipmentEntity)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_EquipmentEntity = BlueprintTool.GetRef<KingmakerEquipmentEntityReference>(equipmentEntity);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_EquipmentEntityAlternatives"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="equipmentEntityAlternatives"><see cref="Kingmaker.Visual.CharacterSystem.KingmakerEquipmentEntity"/></param>
    [Generated]
    public TBuilder SetEquipmentEntityAlternatives(string[]? equipmentEntityAlternatives)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_EquipmentEntityAlternatives = equipmentEntityAlternatives.Select(name => BlueprintTool.GetRef<KingmakerEquipmentEntityReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintArmorType.m_EquipmentEntityAlternatives"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="equipmentEntityAlternatives"><see cref="Kingmaker.Visual.CharacterSystem.KingmakerEquipmentEntity"/></param>
    [Generated]
    public TBuilder AddToEquipmentEntityAlternatives(params string[] equipmentEntityAlternatives)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_EquipmentEntityAlternatives = CommonTool.Append(bp.m_EquipmentEntityAlternatives, equipmentEntityAlternatives.Select(name => BlueprintTool.GetRef<KingmakerEquipmentEntityReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintArmorType.m_EquipmentEntityAlternatives"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="equipmentEntityAlternatives"><see cref="Kingmaker.Visual.CharacterSystem.KingmakerEquipmentEntity"/></param>
    [Generated]
    public TBuilder RemoveFromEquipmentEntityAlternatives(params string[] equipmentEntityAlternatives)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = equipmentEntityAlternatives.Select(name => BlueprintTool.GetRef<KingmakerEquipmentEntityReference>(name));
            bp.m_EquipmentEntityAlternatives =
                bp.m_EquipmentEntityAlternatives
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_Enchantments"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enchantments"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintArmorEnchantment"/></param>
    [Generated]
    public TBuilder SetEnchantments(string[]? enchantments)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Enchantments = enchantments.Select(name => BlueprintTool.GetRef<BlueprintArmorEnchantmentReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintArmorType.m_Enchantments"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enchantments"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintArmorEnchantment"/></param>
    [Generated]
    public TBuilder AddToEnchantments(params string[] enchantments)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Enchantments = CommonTool.Append(bp.m_Enchantments, enchantments.Select(name => BlueprintTool.GetRef<BlueprintArmorEnchantmentReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintArmorType.m_Enchantments"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enchantments"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintArmorEnchantment"/></param>
    [Generated]
    public TBuilder RemoveFromEnchantments(params string[] enchantments)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = enchantments.Select(name => BlueprintTool.GetRef<BlueprintArmorEnchantmentReference>(name));
            bp.m_Enchantments =
                bp.m_Enchantments
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_ForcedRampColorPresetIndex"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetForcedRampColorPresetIndex(int forcedRampColorPresetIndex)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ForcedRampColorPresetIndex = forcedRampColorPresetIndex;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_Destructible"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetDestructible(bool destructible)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Destructible = destructible;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_ShardItem"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="shardItem"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    public TBuilder SetShardItem(string? shardItem)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ShardItem = BlueprintTool.GetRef<BlueprintItemReference>(shardItem);
          });
    }
  }

  /// <summary>
  /// Configurator for <see cref="BlueprintArmorType"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintArmorType))]
  public class ArmorTypeConfigurator : BaseBlueprintConfigurator<BlueprintArmorType, ArmorTypeConfigurator>
  {
    private ArmorTypeConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ArmorTypeConfigurator For(string name)
    {
      return new ArmorTypeConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ArmorTypeConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintArmorType>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_TypeNameText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmorTypeConfigurator SetTypeNameText(LocalizedString? typeNameText)
    {
      ValidateParam(typeNameText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_TypeNameText = typeNameText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_DefaultNameText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmorTypeConfigurator SetDefaultNameText(LocalizedString? defaultNameText)
    {
      ValidateParam(defaultNameText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DefaultNameText = defaultNameText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_DescriptionText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmorTypeConfigurator SetDescriptionText(LocalizedString? descriptionText)
    {
      ValidateParam(descriptionText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DescriptionText = descriptionText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_MagicDescriptionText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmorTypeConfigurator SetMagicDescriptionText(LocalizedString? magicDescriptionText)
    {
      ValidateParam(magicDescriptionText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_MagicDescriptionText = magicDescriptionText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_Icon"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmorTypeConfigurator SetIcon(Sprite icon)
    {
      ValidateParam(icon);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Icon = icon;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_VisualParameters"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmorTypeConfigurator SetVisualParameters(ArmorVisualParameters visualParameters)
    {
      ValidateParam(visualParameters);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_VisualParameters = visualParameters;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_ArmorBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmorTypeConfigurator SetArmorBonus(int armorBonus)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ArmorBonus = armorBonus;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_ArmorChecksPenalty"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmorTypeConfigurator SetArmorChecksPenalty(int armorChecksPenalty)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ArmorChecksPenalty = armorChecksPenalty;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_HasDexterityBonusLimit"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmorTypeConfigurator SetHasDexterityBonusLimit(bool hasDexterityBonusLimit)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_HasDexterityBonusLimit = hasDexterityBonusLimit;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_MaxDexterityBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmorTypeConfigurator SetMaxDexterityBonus(int maxDexterityBonus)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_MaxDexterityBonus = maxDexterityBonus;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_ProficiencyGroup"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmorTypeConfigurator SetProficiencyGroup(ArmorProficiencyGroup proficiencyGroup)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ProficiencyGroup = proficiencyGroup;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_ArcaneSpellFailureChance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmorTypeConfigurator SetArcaneSpellFailureChance(int arcaneSpellFailureChance)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ArcaneSpellFailureChance = arcaneSpellFailureChance;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_Weight"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmorTypeConfigurator SetWeight(float weight)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Weight = weight;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_IsArmor"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmorTypeConfigurator SetIsArmor(bool isArmor)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_IsArmor = isArmor;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_IsShield"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmorTypeConfigurator SetIsShield(bool isShield)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_IsShield = isShield;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_EquipmentEntity"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="equipmentEntity"><see cref="Kingmaker.Visual.CharacterSystem.KingmakerEquipmentEntity"/></param>
    [Generated]
    public ArmorTypeConfigurator SetEquipmentEntity(string? equipmentEntity)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_EquipmentEntity = BlueprintTool.GetRef<KingmakerEquipmentEntityReference>(equipmentEntity);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_EquipmentEntityAlternatives"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="equipmentEntityAlternatives"><see cref="Kingmaker.Visual.CharacterSystem.KingmakerEquipmentEntity"/></param>
    [Generated]
    public ArmorTypeConfigurator SetEquipmentEntityAlternatives(string[]? equipmentEntityAlternatives)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_EquipmentEntityAlternatives = equipmentEntityAlternatives.Select(name => BlueprintTool.GetRef<KingmakerEquipmentEntityReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintArmorType.m_EquipmentEntityAlternatives"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="equipmentEntityAlternatives"><see cref="Kingmaker.Visual.CharacterSystem.KingmakerEquipmentEntity"/></param>
    [Generated]
    public ArmorTypeConfigurator AddToEquipmentEntityAlternatives(params string[] equipmentEntityAlternatives)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_EquipmentEntityAlternatives = CommonTool.Append(bp.m_EquipmentEntityAlternatives, equipmentEntityAlternatives.Select(name => BlueprintTool.GetRef<KingmakerEquipmentEntityReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintArmorType.m_EquipmentEntityAlternatives"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="equipmentEntityAlternatives"><see cref="Kingmaker.Visual.CharacterSystem.KingmakerEquipmentEntity"/></param>
    [Generated]
    public ArmorTypeConfigurator RemoveFromEquipmentEntityAlternatives(params string[] equipmentEntityAlternatives)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = equipmentEntityAlternatives.Select(name => BlueprintTool.GetRef<KingmakerEquipmentEntityReference>(name));
            bp.m_EquipmentEntityAlternatives =
                bp.m_EquipmentEntityAlternatives
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_Enchantments"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enchantments"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintArmorEnchantment"/></param>
    [Generated]
    public ArmorTypeConfigurator SetEnchantments(string[]? enchantments)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Enchantments = enchantments.Select(name => BlueprintTool.GetRef<BlueprintArmorEnchantmentReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintArmorType.m_Enchantments"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enchantments"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintArmorEnchantment"/></param>
    [Generated]
    public ArmorTypeConfigurator AddToEnchantments(params string[] enchantments)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Enchantments = CommonTool.Append(bp.m_Enchantments, enchantments.Select(name => BlueprintTool.GetRef<BlueprintArmorEnchantmentReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintArmorType.m_Enchantments"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enchantments"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintArmorEnchantment"/></param>
    [Generated]
    public ArmorTypeConfigurator RemoveFromEnchantments(params string[] enchantments)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = enchantments.Select(name => BlueprintTool.GetRef<BlueprintArmorEnchantmentReference>(name));
            bp.m_Enchantments =
                bp.m_Enchantments
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_ForcedRampColorPresetIndex"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmorTypeConfigurator SetForcedRampColorPresetIndex(int forcedRampColorPresetIndex)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ForcedRampColorPresetIndex = forcedRampColorPresetIndex;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_Destructible"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmorTypeConfigurator SetDestructible(bool destructible)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Destructible = destructible;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_ShardItem"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="shardItem"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    public ArmorTypeConfigurator SetShardItem(string? shardItem)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ShardItem = BlueprintTool.GetRef<BlueprintItemReference>(shardItem);
          });
    }
  }
}
