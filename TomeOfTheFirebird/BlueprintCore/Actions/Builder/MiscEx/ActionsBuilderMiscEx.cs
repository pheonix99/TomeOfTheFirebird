using BlueprintCore.Utils;
using Kingmaker;
using Kingmaker.Achievements.Actions;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Loot;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.ElementsSystem;
using Kingmaker.Tutorial;
using Kingmaker.Tutorial.Actions;
using Kingmaker.UnitLogic.FactLogic;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace BlueprintCore.Actions.Builder.MiscEx
{
  /// <summary>
  /// Extension to <see cref="ActionsBuilder"/> for actions without a better extension container such as achievements
  /// vendor actions, and CustomEvent.
  /// </summary>
  /// <inheritdoc cref="ActionsBuilder"/>
  public static class ActionsBuilderMiscEx
  {
    //----- Kingmaker.Achievements.Actions -----//

    /// <summary>
    /// Adds <see cref="ActionAchievementIncrementCounter"/>
    /// </summary>
    /// 
    /// <param name="achievement"><see cref="Kingmaker.Achievements.Blueprints.AchievementData">AchievementData</see></param>
    [Implements(typeof(ActionAchievementIncrementCounter))]
    public static ActionsBuilder IncrementAchievement(this ActionsBuilder builder, string achievement)
    {
      var increment = ElementTool.Create<ActionAchievementIncrementCounter>();
      increment.m_Achievement = BlueprintTool.GetRef<AchievementDataReference>(achievement);
      return builder.Add(increment);
    }

    /// <summary>
    /// Adds <see cref="ActionAchievementUnlock"/>
    /// </summary>
    /// 
    /// <param name="achievement"><see cref="Kingmaker.Achievements.Blueprints.AchievementData">AchievementData</see></param>
    [Implements(typeof(ActionAchievementUnlock))]
    public static ActionsBuilder UnlockAchievement(this ActionsBuilder builder, string achievement)
    {
      var unlock = ElementTool.Create<ActionAchievementUnlock>();
      unlock.m_Achievement = BlueprintTool.GetRef<AchievementDataReference>(achievement);
      return builder.Add(unlock);
    }

    //----- Kingmaker.Designers.EventConditionActionSystem.Actions -----//

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.CreateCustomCompanion">CreateCustomCompanion</see>
    /// </summary>
    [Implements(typeof(CreateCustomCompanion))]
    public static ActionsBuilder CreateCustomCompanion(
        this ActionsBuilder builder,
        bool free = false,
        bool matchPlayerXp = false,
        ActionsBuilder? onCreate = null)
    {
      var createCompanion = ElementTool.Create<CreateCustomCompanion>();
      createCompanion.ForFree = free;
      createCompanion.MatchPlayerXpExactly = matchPlayerXp;
      createCompanion.OnCreate = onCreate?.Build() ?? Constants.Empty.Actions;
      return builder.Add(createCompanion);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.CustomEvent">CustomEvent</see>
    /// </summary>
    [Implements(typeof(CustomEvent))]
    public static ActionsBuilder CustomEvent(this ActionsBuilder builder, string eventId)
    {
      var customEvent = ElementTool.Create<CustomEvent>();
      customEvent.EventId = eventId;
      return builder.Add(customEvent);
    }

    //----- Auto Generated -----//

    /// <summary>
    /// Adds <see cref="ShowNewTutorial"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="tutorial"><see cref="Kingmaker.Tutorial.BlueprintTutorial"/></param>
    [Generated]
    [Implements(typeof(ShowNewTutorial))]
    public static ActionsBuilder ShowNewTutorial(
        this ActionsBuilder builder,
        string? tutorial = null,
        TutorialContextDataEvaluator[]? evaluators = null)
    {
      builder.Validate(evaluators);
    
      var element = ElementTool.Create<ShowNewTutorial>();
      element.m_Tutorial = BlueprintTool.GetRef<BlueprintTutorial.Reference>(tutorial);
      element.Evaluators = evaluators;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AddVendorItemsAction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="vendorTable"><see cref="Kingmaker.Blueprints.Loot.BlueprintUnitLoot"/></param>
    [Generated]
    [Implements(typeof(AddVendorItemsAction))]
    public static ActionsBuilder AddVendorItemsAction(
        this ActionsBuilder builder,
        VendorEvaluator vendorEvaluator,
        string? vendorTable = null)
    {
      builder.Validate(vendorEvaluator);
    
      var element = ElementTool.Create<AddVendorItemsAction>();
      element.m_VendorEvaluator = vendorEvaluator;
      element.m_VendorTable = BlueprintTool.GetRef<BlueprintUnitLootReference>(vendorTable);
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ClearVendorTable"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="table"><see cref="Kingmaker.Blueprints.Items.BlueprintSharedVendorTable"/></param>
    [Generated]
    [Implements(typeof(ClearVendorTable))]
    public static ActionsBuilder ClearVendorTable(
        this ActionsBuilder builder,
        string? table = null)
    {
      var element = ElementTool.Create<ClearVendorTable>();
      element.m_Table = BlueprintTool.GetRef<BlueprintSharedVendorTableReference>(table);
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AddPremiumReward"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="dlcReward"><see cref="Kingmaker.DLC.BlueprintDlcReward"/></param>
    /// <param name="items"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    /// <param name="playerFeatures"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(AddPremiumReward))]
    public static ActionsBuilder AddPremiumReward(
        this ActionsBuilder builder,
        string? dlcReward = null,
        string[]? items = null,
        string[]? playerFeatures = null,
        ActionsBuilder? additionalActions = null)
    {
      var element = ElementTool.Create<AddPremiumReward>();
      element.m_DlcReward = BlueprintTool.GetRef<BlueprintDlcRewardReference>(dlcReward);
      element.Items = items.Select(name => BlueprintTool.GetRef<BlueprintItemReference>(name)).ToList();
      element.PlayerFeatures = playerFeatures.Select(name => BlueprintTool.GetRef<BlueprintFeatureReference>(name)).ToList();
      element.AdditionalActions = additionalActions?.Build() ?? Constants.Empty.Actions;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DebugLog"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DebugLog))]
    public static ActionsBuilder DebugLog(
        this ActionsBuilder builder,
        string log,
        bool breakValue = default)
    {
      var element = ElementTool.Create<DebugLog>();
      element.Log = log;
      element.Break = breakValue;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="GameOver"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(GameOver))]
    public static ActionsBuilder GameOver(
        this ActionsBuilder builder,
        Player.GameOverReasonType reason = default)
    {
      var element = ElementTool.Create<GameOver>();
      element.Reason = reason;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="MakeAutoSave"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MakeAutoSave))]
    public static ActionsBuilder MakeAutoSave(
        this ActionsBuilder builder,
        bool saveForImport = default)
    {
      var element = ElementTool.Create<MakeAutoSave>();
      element.SaveForImport = saveForImport;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="MakeItemNonRemovable"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="item"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    [Implements(typeof(MakeItemNonRemovable))]
    public static ActionsBuilder MakeItemNonRemovable(
        this ActionsBuilder builder,
        string? item = null,
        bool nonRemovable = default)
    {
      var element = ElementTool.Create<MakeItemNonRemovable>();
      element.m_Item = BlueprintTool.GetRef<BlueprintItemReference>(item);
      element.NonRemovable = nonRemovable;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="MovePartyItemsAction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MovePartyItemsAction))]
    public static ActionsBuilder MovePartyItemsAction(
        this ActionsBuilder builder,
        ItemsCollectionEvaluator targetCollection,
        MovePartyItemsAction.LeaveSettings leaveEquipmentOf,
        MovePartyItemsAction.ItemType pickupTypes = default)
    {
      builder.Validate(targetCollection);
      builder.Validate(leaveEquipmentOf);
    
      var element = ElementTool.Create<MovePartyItemsAction>();
      element.PickupTypes = pickupTypes;
      element.TargetCollection = targetCollection;
      element.m_LeaveEquipmentOf = leaveEquipmentOf;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="OpenSelectMythicUI"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(OpenSelectMythicUI))]
    public static ActionsBuilder OpenSelectMythicUI(
        this ActionsBuilder builder,
        ActionsBuilder? afterCommitActions = null,
        bool lockStopChargen = default,
        ActionsBuilder? afterStopActions = null)
    {
      var element = ElementTool.Create<OpenSelectMythicUI>();
      element.m_AfterCommitActions = afterCommitActions?.Build() ?? Constants.Empty.Actions;
      element.m_LockStopChargen = lockStopChargen;
      element.m_AfterStopActions = afterStopActions?.Build() ?? Constants.Empty.Actions;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveItemFromPlayer"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="itemToRemove"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    [Implements(typeof(RemoveItemFromPlayer))]
    public static ActionsBuilder RemoveItemFromPlayer(
        this ActionsBuilder builder,
        bool money = default,
        bool removeAll = default,
        string? itemToRemove = null,
        bool silent = default,
        int quantity = default,
        float percentage = default)
    {
      var element = ElementTool.Create<RemoveItemFromPlayer>();
      element.Money = money;
      element.RemoveAll = removeAll;
      element.m_ItemToRemove = BlueprintTool.GetRef<BlueprintItemReference>(itemToRemove);
      element.m_Silent = silent;
      element.Quantity = quantity;
      element.Percentage = percentage;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveItemsFromCollection"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RemoveItemsFromCollection))]
    public static ActionsBuilder RemoveItemsFromCollection(
        this ActionsBuilder builder,
        ItemsCollectionEvaluator collection,
        List<LootEntry>? loot = null)
    {
      builder.Validate(collection);
      builder.Validate(loot);
    
      var element = ElementTool.Create<RemoveItemsFromCollection>();
      element.Collection = collection;
      element.Loot = loot;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveDuplicateItems"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="blueprint"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    [Implements(typeof(RemoveDuplicateItems))]
    public static ActionsBuilder RemoveDuplicateItems(
        this ActionsBuilder builder,
        UnitEvaluator unit,
        string? blueprint = null)
    {
      builder.Validate(unit);
    
      var element = ElementTool.Create<RemoveDuplicateItems>();
      element.Unit = unit;
      element.m_Blueprint = BlueprintTool.GetRef<BlueprintItemReference>(blueprint);
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RestoreItemsCountInCollection"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="item"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    [Implements(typeof(RestoreItemsCountInCollection))]
    public static ActionsBuilder RestoreItemsCountInCollection(
        this ActionsBuilder builder,
        ItemsCollectionEvaluator collection,
        IntEvaluator count,
        string? item = null)
    {
      builder.Validate(collection);
      builder.Validate(count);
    
      var element = ElementTool.Create<RestoreItemsCountInCollection>();
      element.m_Item = BlueprintTool.GetRef<BlueprintItemReference>(item);
      element.Collection = collection;
      element.Count = count;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SellCollectibleItems"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="itemToSell"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    [Implements(typeof(SellCollectibleItems))]
    public static ActionsBuilder SellCollectibleItems(
        this ActionsBuilder builder,
        string? itemToSell = null,
        bool halfPrice = default)
    {
      var element = ElementTool.Create<SellCollectibleItems>();
      element.m_ItemToSell = BlueprintTool.GetRef<BlueprintItemReference>(itemToSell);
      element.HalfPrice = halfPrice;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SetStartDate"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SetStartDate))]
    public static ActionsBuilder SetStartDate(
        this ActionsBuilder builder,
        string date)
    {
      var element = ElementTool.Create<SetStartDate>();
      element.Date = date;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SetVendorPriceModifier"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SetVendorPriceModifier))]
    public static ActionsBuilder SetVendorPriceModifier(
        this ActionsBuilder builder,
        UnitEvaluator vendorUnit,
        SetVendorPriceModifier.Entry[]? entries = null)
    {
      builder.Validate(vendorUnit);
      builder.Validate(entries);
    
      var element = ElementTool.Create<SetVendorPriceModifier>();
      element.VendorUnit = vendorUnit;
      element.m_Entries = entries;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ShowPartySelection"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ShowPartySelection))]
    public static ActionsBuilder ShowPartySelection(
        this ActionsBuilder builder,
        ActionsBuilder? actionsAfterPartySelection = null,
        ActionsBuilder? actionsIfCanceled = null)
    {
      var element = ElementTool.Create<ShowPartySelection>();
      element.ActionsAfterPartySelection = actionsAfterPartySelection?.Build() ?? Constants.Empty.Actions;
      element.ActionsIfCanceled = actionsIfCanceled?.Build() ?? Constants.Empty.Actions;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="StartTrade"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(StartTrade))]
    public static ActionsBuilder StartTrade(
        this ActionsBuilder builder,
        UnitEvaluator vendor)
    {
      builder.Validate(vendor);
    
      var element = ElementTool.Create<StartTrade>();
      element.Vendor = vendor;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnequipAllItems"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UnequipAllItems))]
    public static ActionsBuilder UnequipAllItems(
        this ActionsBuilder builder,
        UnitEvaluator target,
        ItemsCollectionEvaluator destinationContainer,
        bool silent = default)
    {
      builder.Validate(target);
      builder.Validate(destinationContainer);
    
      var element = ElementTool.Create<UnequipAllItems>();
      element.Target = target;
      element.DestinationContainer = destinationContainer;
      element.Silent = silent;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnequipItem"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="item"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    [Implements(typeof(UnequipItem))]
    public static ActionsBuilder UnequipItem(
        this ActionsBuilder builder,
        UnitEvaluator unit,
        ItemsCollectionEvaluator destinationContainer,
        bool silent = default,
        string? item = null,
        bool all = default)
    {
      builder.Validate(unit);
      builder.Validate(destinationContainer);
    
      var element = ElementTool.Create<UnequipItem>();
      element.Unit = unit;
      element.DestinationContainer = destinationContainer;
      element.Silent = silent;
      element.m_Item = BlueprintTool.GetRef<BlueprintItemReference>(item);
      element.All = all;
      return builder.Add(element);
    }
  }
}
