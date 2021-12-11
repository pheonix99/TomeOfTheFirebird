using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;
using Kingmaker.Blueprints.Items.Components;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Designers.Mechanics.EquipmentEnchants;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Enums;
using Kingmaker.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Items
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintItem"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItem))]
  public abstract class BaseItemConfigurator<T, TBuilder>
      : BaseFactConfigurator<T, TBuilder>
      where T : BlueprintItem
      where TBuilder : BaseItemConfigurator<T, TBuilder>
  {
    protected BaseItemConfigurator(string name) : base(name) { }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_DisplayNameText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetDisplayNameText(LocalizedString? displayNameText)
    {
      ValidateParam(displayNameText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DisplayNameText = displayNameText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_DescriptionText"/> (Auto Generated)
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
    /// Sets <see cref="BlueprintItem.m_FlavorText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetFlavorText(LocalizedString? flavorText)
    {
      ValidateParam(flavorText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_FlavorText = flavorText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_NonIdentifiedNameText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetNonIdentifiedNameText(LocalizedString? nonIdentifiedNameText)
    {
      ValidateParam(nonIdentifiedNameText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_NonIdentifiedNameText = nonIdentifiedNameText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_NonIdentifiedDescriptionText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetNonIdentifiedDescriptionText(LocalizedString? nonIdentifiedDescriptionText)
    {
      ValidateParam(nonIdentifiedDescriptionText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_NonIdentifiedDescriptionText = nonIdentifiedDescriptionText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_Icon"/> (Auto Generated)
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
    /// Sets <see cref="BlueprintItem.m_Cost"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetCost(int cost)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Cost = cost;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_Weight"/> (Auto Generated)
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
    /// Sets <see cref="BlueprintItem.m_IsNotable"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetIsNotable(bool isNotable)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_IsNotable = isNotable;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_ForceStackable"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetForceStackable(bool forceStackable)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ForceStackable = forceStackable;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_Destructible"/> (Auto Generated)
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
    /// Sets <see cref="BlueprintItem.m_ShardItem"/> (Auto Generated)
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

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_MiscellaneousType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetMiscellaneousType(BlueprintItem.MiscellaneousItemType miscellaneousType)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_MiscellaneousType = miscellaneousType;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_InventoryPutSound"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetInventoryPutSound(string inventoryPutSound)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_InventoryPutSound = inventoryPutSound;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_InventoryTakeSound"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetInventoryTakeSound(string inventoryTakeSound)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_InventoryTakeSound = inventoryTakeSound;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.NeedSkinningForCollect"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetNeedSkinningForCollect(bool needSkinningForCollect)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.NeedSkinningForCollect = needSkinningForCollect;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.TrashLootTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetTrashLootTypes(TrashLootType[]? trashLootTypes)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.TrashLootTypes = trashLootTypes;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintItem.TrashLootTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder AddToTrashLootTypes(params TrashLootType[] trashLootTypes)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.TrashLootTypes = CommonTool.Append(bp.TrashLootTypes, trashLootTypes ?? new TrashLootType[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintItem.TrashLootTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder RemoveFromTrashLootTypes(params TrashLootType[] trashLootTypes)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.TrashLootTypes = bp.TrashLootTypes.Where(item => !trashLootTypes.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_CachedEnchantments"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetCachedEnchantments(List<BlueprintItemEnchantment>? cachedEnchantments)
    {
      ValidateParam(cachedEnchantments);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedEnchantments = cachedEnchantments;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintItem.m_CachedEnchantments"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder AddToCachedEnchantments(params BlueprintItemEnchantment[] cachedEnchantments)
    {
      ValidateParam(cachedEnchantments);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedEnchantments.AddRange(cachedEnchantments.ToList() ?? new List<BlueprintItemEnchantment>());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintItem.m_CachedEnchantments"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder RemoveFromCachedEnchantments(params BlueprintItemEnchantment[] cachedEnchantments)
    {
      ValidateParam(cachedEnchantments);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedEnchantments = bp.m_CachedEnchantments.Where(item => !cachedEnchantments.Contains(item)).ToList();
          });
    }

    /// <summary>
    /// Adds <see cref="ItemEnchantmentEnableWhileEtudePlaying"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="etude"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude"/></param>
    [Generated]
    [Implements(typeof(ItemEnchantmentEnableWhileEtudePlaying))]
    public TBuilder AddItemEnchantmentEnableWhileEtudePlaying(
        string? etude = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ItemEnchantmentEnableWhileEtudePlaying();
      component.m_Etude = BlueprintTool.GetRef<BlueprintEtudeReference>(etude);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddItemShowInfoCallback"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddItemShowInfoCallback))]
    public TBuilder AddItemShowInfoCallback(
        bool once = default,
        ActionsBuilder? action = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddItemShowInfoCallback();
      component.Once = once;
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="BuildPointsReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuildPointsReplacement))]
    public TBuilder AddBuildPointsReplacement(
        int cost = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new BuildPointsReplacement();
      component.Cost = cost;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ConsumableEventBonusReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ConsumableEventBonusReplacement))]
    public TBuilder AddConsumableEventBonusReplacement(
        int cost = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ConsumableEventBonusReplacement();
      component.Cost = cost;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="CopyRecipe"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="recipe"><see cref="Kingmaker.Controllers.Rest.Cooking.BlueprintCookingRecipe"/></param>
    [Generated]
    [Implements(typeof(CopyRecipe))]
    public TBuilder AddCopyRecipe(
        string? recipe = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new CopyRecipe();
      component.m_Recipe = BlueprintTool.GetRef<BlueprintCookingRecipeReference>(recipe);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="CopyScroll"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="customSpell"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(CopyScroll))]
    public TBuilder AddCopyScroll(
        string? customSpell = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new CopyScroll();
      component.m_CustomSpell = BlueprintTool.GetRef<BlueprintAbilityReference>(customSpell);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="IdentifySkillReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IdentifySkillReplacement))]
    public TBuilder AddIdentifySkillReplacement(
        IdentifySkillReplacement.SkillType skillType = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new IdentifySkillReplacement();
      component.m_SkillType = skillType;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ItemDialog"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="dialogReference"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintDialog"/></param>
    [Generated]
    [Implements(typeof(ItemDialog))]
    public TBuilder AddItemDialog(
        ConditionsBuilder? conditions = null,
        LocalizedString? itemName = null,
        string? dialogReference = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(itemName);
    
      var component = new ItemDialog();
      component.m_Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
      component.m_ItemName = itemName ?? Constants.Empty.String;
      component.m_DialogReference = BlueprintTool.GetRef<BlueprintDialogReference>(dialogReference);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ItemDlcRestriction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="dlcReward"><see cref="Kingmaker.DLC.BlueprintDlcReward"/></param>
    /// <param name="changeTo"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    [Implements(typeof(ItemDlcRestriction))]
    public TBuilder AddItemDlcRestriction(
        string? dlcReward = null,
        string? changeTo = null,
        bool hideInVendors = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ItemDlcRestriction();
      component.m_DlcReward = BlueprintTool.GetRef<BlueprintDlcRewardReference>(dlcReward);
      component.m_ChangeTo = BlueprintTool.GetRef<BlueprintItemReference>(changeTo);
      component.HideInVendors = hideInVendors;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ItemPolymorph"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="flagToCheck"><see cref="Kingmaker.Blueprints.BlueprintUnlockableFlag"/></param>
    /// <param name="polymorphItems"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    [Implements(typeof(ItemPolymorph))]
    public TBuilder AddItemPolymorph(
        string? flagToCheck = null,
        string[]? polymorphItems = null)
    {
      var component = new ItemPolymorph();
      component.m_FlagToCheck = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(flagToCheck);
      component.m_PolymorphItems = polymorphItems.Select(name => BlueprintTool.GetRef<BlueprintItemReference>(name)).ToList();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MoneyReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MoneyReplacement))]
    public TBuilder AddMoneyReplacement(
        long cost = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new MoneyReplacement();
      component.Cost = cost;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="EnchantmentAddBuffWhileInStealth"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EnchantmentAddBuffWhileInStealth))]
    public TBuilder AddEnchantmentAddBuffWhileInStealth(
        EnchantmentAddBuffWhileInStealth.BuffAndDeactivateDuration[]? buffs = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(buffs);
    
      var component = new EnchantmentAddBuffWhileInStealth();
      component.Buffs = buffs;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="IgnoreResistanceForDamageFromEnchantment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IgnoreResistanceForDamageFromEnchantment))]
    public TBuilder AddIgnoreResistanceForDamageFromEnchantment(
        IgnoreResistanceForDamageFromEnchantment.IgnoreType type = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new IgnoreResistanceForDamageFromEnchantment();
      component.m_Type = type;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="WeaponTypeAttackEnchant"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="type"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(WeaponTypeAttackEnchant))]
    public TBuilder AddWeaponTypeAttackEnchant(
        string? type = null,
        int bonus = default,
        ModifierDescriptor descriptor = default)
    {
      var component = new WeaponTypeAttackEnchant();
      component.m_Type = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(type);
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      return AddComponent(component);
    }
  }

  /// <summary>
  /// Configurator for <see cref="BlueprintItem"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItem))]
  public class ItemConfigurator : BaseFactConfigurator<BlueprintItem, ItemConfigurator>
  {
    private ItemConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ItemConfigurator For(string name)
    {
      return new ItemConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ItemConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintItem>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_DisplayNameText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemConfigurator SetDisplayNameText(LocalizedString? displayNameText)
    {
      ValidateParam(displayNameText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DisplayNameText = displayNameText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_DescriptionText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemConfigurator SetDescriptionText(LocalizedString? descriptionText)
    {
      ValidateParam(descriptionText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DescriptionText = descriptionText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_FlavorText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemConfigurator SetFlavorText(LocalizedString? flavorText)
    {
      ValidateParam(flavorText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_FlavorText = flavorText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_NonIdentifiedNameText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemConfigurator SetNonIdentifiedNameText(LocalizedString? nonIdentifiedNameText)
    {
      ValidateParam(nonIdentifiedNameText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_NonIdentifiedNameText = nonIdentifiedNameText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_NonIdentifiedDescriptionText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemConfigurator SetNonIdentifiedDescriptionText(LocalizedString? nonIdentifiedDescriptionText)
    {
      ValidateParam(nonIdentifiedDescriptionText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_NonIdentifiedDescriptionText = nonIdentifiedDescriptionText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_Icon"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemConfigurator SetIcon(Sprite icon)
    {
      ValidateParam(icon);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Icon = icon;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_Cost"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemConfigurator SetCost(int cost)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Cost = cost;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_Weight"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemConfigurator SetWeight(float weight)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Weight = weight;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_IsNotable"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemConfigurator SetIsNotable(bool isNotable)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_IsNotable = isNotable;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_ForceStackable"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemConfigurator SetForceStackable(bool forceStackable)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ForceStackable = forceStackable;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_Destructible"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemConfigurator SetDestructible(bool destructible)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Destructible = destructible;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_ShardItem"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="shardItem"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    public ItemConfigurator SetShardItem(string? shardItem)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ShardItem = BlueprintTool.GetRef<BlueprintItemReference>(shardItem);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_MiscellaneousType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemConfigurator SetMiscellaneousType(BlueprintItem.MiscellaneousItemType miscellaneousType)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_MiscellaneousType = miscellaneousType;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_InventoryPutSound"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemConfigurator SetInventoryPutSound(string inventoryPutSound)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_InventoryPutSound = inventoryPutSound;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_InventoryTakeSound"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemConfigurator SetInventoryTakeSound(string inventoryTakeSound)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_InventoryTakeSound = inventoryTakeSound;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.NeedSkinningForCollect"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemConfigurator SetNeedSkinningForCollect(bool needSkinningForCollect)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.NeedSkinningForCollect = needSkinningForCollect;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.TrashLootTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemConfigurator SetTrashLootTypes(TrashLootType[]? trashLootTypes)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.TrashLootTypes = trashLootTypes;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintItem.TrashLootTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemConfigurator AddToTrashLootTypes(params TrashLootType[] trashLootTypes)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.TrashLootTypes = CommonTool.Append(bp.TrashLootTypes, trashLootTypes ?? new TrashLootType[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintItem.TrashLootTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemConfigurator RemoveFromTrashLootTypes(params TrashLootType[] trashLootTypes)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.TrashLootTypes = bp.TrashLootTypes.Where(item => !trashLootTypes.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItem.m_CachedEnchantments"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemConfigurator SetCachedEnchantments(List<BlueprintItemEnchantment>? cachedEnchantments)
    {
      ValidateParam(cachedEnchantments);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedEnchantments = cachedEnchantments;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintItem.m_CachedEnchantments"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemConfigurator AddToCachedEnchantments(params BlueprintItemEnchantment[] cachedEnchantments)
    {
      ValidateParam(cachedEnchantments);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedEnchantments.AddRange(cachedEnchantments.ToList() ?? new List<BlueprintItemEnchantment>());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintItem.m_CachedEnchantments"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemConfigurator RemoveFromCachedEnchantments(params BlueprintItemEnchantment[] cachedEnchantments)
    {
      ValidateParam(cachedEnchantments);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedEnchantments = bp.m_CachedEnchantments.Where(item => !cachedEnchantments.Contains(item)).ToList();
          });
    }

    /// <summary>
    /// Adds <see cref="ItemEnchantmentEnableWhileEtudePlaying"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="etude"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude"/></param>
    [Generated]
    [Implements(typeof(ItemEnchantmentEnableWhileEtudePlaying))]
    public ItemConfigurator AddItemEnchantmentEnableWhileEtudePlaying(
        string? etude = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ItemEnchantmentEnableWhileEtudePlaying();
      component.m_Etude = BlueprintTool.GetRef<BlueprintEtudeReference>(etude);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddItemShowInfoCallback"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddItemShowInfoCallback))]
    public ItemConfigurator AddItemShowInfoCallback(
        bool once = default,
        ActionsBuilder? action = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddItemShowInfoCallback();
      component.Once = once;
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="BuildPointsReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuildPointsReplacement))]
    public ItemConfigurator AddBuildPointsReplacement(
        int cost = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new BuildPointsReplacement();
      component.Cost = cost;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ConsumableEventBonusReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ConsumableEventBonusReplacement))]
    public ItemConfigurator AddConsumableEventBonusReplacement(
        int cost = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ConsumableEventBonusReplacement();
      component.Cost = cost;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="CopyRecipe"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="recipe"><see cref="Kingmaker.Controllers.Rest.Cooking.BlueprintCookingRecipe"/></param>
    [Generated]
    [Implements(typeof(CopyRecipe))]
    public ItemConfigurator AddCopyRecipe(
        string? recipe = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new CopyRecipe();
      component.m_Recipe = BlueprintTool.GetRef<BlueprintCookingRecipeReference>(recipe);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="CopyScroll"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="customSpell"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(CopyScroll))]
    public ItemConfigurator AddCopyScroll(
        string? customSpell = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new CopyScroll();
      component.m_CustomSpell = BlueprintTool.GetRef<BlueprintAbilityReference>(customSpell);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="IdentifySkillReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IdentifySkillReplacement))]
    public ItemConfigurator AddIdentifySkillReplacement(
        IdentifySkillReplacement.SkillType skillType = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new IdentifySkillReplacement();
      component.m_SkillType = skillType;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ItemDialog"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="dialogReference"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintDialog"/></param>
    [Generated]
    [Implements(typeof(ItemDialog))]
    public ItemConfigurator AddItemDialog(
        ConditionsBuilder? conditions = null,
        LocalizedString? itemName = null,
        string? dialogReference = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(itemName);
    
      var component = new ItemDialog();
      component.m_Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
      component.m_ItemName = itemName ?? Constants.Empty.String;
      component.m_DialogReference = BlueprintTool.GetRef<BlueprintDialogReference>(dialogReference);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ItemDlcRestriction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="dlcReward"><see cref="Kingmaker.DLC.BlueprintDlcReward"/></param>
    /// <param name="changeTo"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    [Implements(typeof(ItemDlcRestriction))]
    public ItemConfigurator AddItemDlcRestriction(
        string? dlcReward = null,
        string? changeTo = null,
        bool hideInVendors = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ItemDlcRestriction();
      component.m_DlcReward = BlueprintTool.GetRef<BlueprintDlcRewardReference>(dlcReward);
      component.m_ChangeTo = BlueprintTool.GetRef<BlueprintItemReference>(changeTo);
      component.HideInVendors = hideInVendors;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ItemPolymorph"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="flagToCheck"><see cref="Kingmaker.Blueprints.BlueprintUnlockableFlag"/></param>
    /// <param name="polymorphItems"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    [Implements(typeof(ItemPolymorph))]
    public ItemConfigurator AddItemPolymorph(
        string? flagToCheck = null,
        string[]? polymorphItems = null)
    {
      var component = new ItemPolymorph();
      component.m_FlagToCheck = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(flagToCheck);
      component.m_PolymorphItems = polymorphItems.Select(name => BlueprintTool.GetRef<BlueprintItemReference>(name)).ToList();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MoneyReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MoneyReplacement))]
    public ItemConfigurator AddMoneyReplacement(
        long cost = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new MoneyReplacement();
      component.Cost = cost;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="EnchantmentAddBuffWhileInStealth"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EnchantmentAddBuffWhileInStealth))]
    public ItemConfigurator AddEnchantmentAddBuffWhileInStealth(
        EnchantmentAddBuffWhileInStealth.BuffAndDeactivateDuration[]? buffs = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(buffs);
    
      var component = new EnchantmentAddBuffWhileInStealth();
      component.Buffs = buffs;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="IgnoreResistanceForDamageFromEnchantment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IgnoreResistanceForDamageFromEnchantment))]
    public ItemConfigurator AddIgnoreResistanceForDamageFromEnchantment(
        IgnoreResistanceForDamageFromEnchantment.IgnoreType type = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new IgnoreResistanceForDamageFromEnchantment();
      component.m_Type = type;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="WeaponTypeAttackEnchant"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="type"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(WeaponTypeAttackEnchant))]
    public ItemConfigurator AddWeaponTypeAttackEnchant(
        string? type = null,
        int bonus = default,
        ModifierDescriptor descriptor = default)
    {
      var component = new WeaponTypeAttackEnchant();
      component.m_Type = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(type);
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      return AddComponent(component);
    }
  }
}
