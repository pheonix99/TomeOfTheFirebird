using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Localization;
using Kingmaker.UI.Kingdom;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>
  /// Configurator for <see cref="KingdomRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(KingdomRoot))]
  public class KingdomRootConfigurator : BaseBlueprintConfigurator<KingdomRoot, KingdomRootConfigurator>
  {
    private KingdomRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static KingdomRootConfigurator For(string name)
    {
      return new KingdomRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static KingdomRootConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<KingdomRoot>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.m_BlueprintRegionCapital"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="blueprintRegionCapital"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintRegion"/></param>
    [Generated]
    public KingdomRootConfigurator SetBlueprintRegionCapital(string? blueprintRegionCapital)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_BlueprintRegionCapital = BlueprintTool.GetRef<BlueprintRegionReference>(blueprintRegionCapital);
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.m_CapitalSettlement"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="capitalSettlement"><see cref="Kingmaker.Kingdom.BlueprintSettlement"/></param>
    [Generated]
    public KingdomRootConfigurator SetCapitalSettlement(string? capitalSettlement)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CapitalSettlement = BlueprintTool.GetRef<BlueprintSettlement.Reference>(capitalSettlement);
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.m_ThroneRoom"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="throneRoom"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaEnterPoint"/></param>
    [Generated]
    public KingdomRootConfigurator SetThroneRoom(string? throneRoom)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ThroneRoom = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(throneRoom);
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.SettlementEmptyMarker"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SettlementEmptyMarker(KingdomUISettlementEmptyMarker settlementEmptyMarker)
    {
      ValidateParam(settlementEmptyMarker);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.SettlementEmptyMarker = settlementEmptyMarker;
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.m_StartingEventDecks"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="startingEventDecks"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomDeck"/></param>
    [Generated]
    public KingdomRootConfigurator SetStartingEventDecks(string[]? startingEventDecks)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_StartingEventDecks = startingEventDecks.Select(name => BlueprintTool.GetRef<BlueprintKingdomDeckReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="KingdomRoot.m_StartingEventDecks"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="startingEventDecks"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomDeck"/></param>
    [Generated]
    public KingdomRootConfigurator AddToStartingEventDecks(params string[] startingEventDecks)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_StartingEventDecks = CommonTool.Append(bp.m_StartingEventDecks, startingEventDecks.Select(name => BlueprintTool.GetRef<BlueprintKingdomDeckReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="KingdomRoot.m_StartingEventDecks"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="startingEventDecks"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomDeck"/></param>
    [Generated]
    public KingdomRootConfigurator RemoveFromStartingEventDecks(params string[] startingEventDecks)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = startingEventDecks.Select(name => BlueprintTool.GetRef<BlueprintKingdomDeckReference>(name));
            bp.m_StartingEventDecks =
                bp.m_StartingEventDecks
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.m_KingdomProjectEvents"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="kingdomProjectEvents"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomProject"/></param>
    [Generated]
    public KingdomRootConfigurator SetKingdomProjectEvents(string[]? kingdomProjectEvents)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_KingdomProjectEvents = kingdomProjectEvents.Select(name => BlueprintTool.GetRef<BlueprintKingdomProjectReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="KingdomRoot.m_KingdomProjectEvents"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="kingdomProjectEvents"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomProject"/></param>
    [Generated]
    public KingdomRootConfigurator AddToKingdomProjectEvents(params string[] kingdomProjectEvents)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_KingdomProjectEvents.AddRange(kingdomProjectEvents.Select(name => BlueprintTool.GetRef<BlueprintKingdomProjectReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="KingdomRoot.m_KingdomProjectEvents"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="kingdomProjectEvents"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomProject"/></param>
    [Generated]
    public KingdomRootConfigurator RemoveFromKingdomProjectEvents(params string[] kingdomProjectEvents)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = kingdomProjectEvents.Select(name => BlueprintTool.GetRef<BlueprintKingdomProjectReference>(name));
            bp.m_KingdomProjectEvents =
                bp.m_KingdomProjectEvents
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.m_Buildings"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buildings"><see cref="Kingmaker.Kingdom.Settlements.BlueprintSettlementBuilding"/></param>
    [Generated]
    public KingdomRootConfigurator SetBuildings(string[]? buildings)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Buildings = buildings.Select(name => BlueprintTool.GetRef<BlueprintSettlementBuildingReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="KingdomRoot.m_Buildings"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buildings"><see cref="Kingmaker.Kingdom.Settlements.BlueprintSettlementBuilding"/></param>
    [Generated]
    public KingdomRootConfigurator AddToBuildings(params string[] buildings)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Buildings = CommonTool.Append(bp.m_Buildings, buildings.Select(name => BlueprintTool.GetRef<BlueprintSettlementBuildingReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="KingdomRoot.m_Buildings"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buildings"><see cref="Kingmaker.Kingdom.Settlements.BlueprintSettlementBuilding"/></param>
    [Generated]
    public KingdomRootConfigurator RemoveFromBuildings(params string[] buildings)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = buildings.Select(name => BlueprintTool.GetRef<BlueprintSettlementBuildingReference>(name));
            bp.m_Buildings =
                bp.m_Buildings
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.m_UnrestPriorityDeck"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="unrestPriorityDeck"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomDeck"/></param>
    [Generated]
    public KingdomRootConfigurator SetUnrestPriorityDeck(string? unrestPriorityDeck)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_UnrestPriorityDeck = BlueprintTool.GetRef<BlueprintKingdomDeckReference>(unrestPriorityDeck);
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.UnrestDeckTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetUnrestDeckTrigger(KingdomStatusType unrestDeckTrigger)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.UnrestDeckTrigger = unrestDeckTrigger;
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.m_UnrestMitigationEvents"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="unrestMitigationEvents"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomProject"/></param>
    [Generated]
    public KingdomRootConfigurator SetUnrestMitigationEvents(string[]? unrestMitigationEvents)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_UnrestMitigationEvents = unrestMitigationEvents.Select(name => BlueprintTool.GetRef<BlueprintKingdomProjectReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="KingdomRoot.m_UnrestMitigationEvents"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="unrestMitigationEvents"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomProject"/></param>
    [Generated]
    public KingdomRootConfigurator AddToUnrestMitigationEvents(params string[] unrestMitigationEvents)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_UnrestMitigationEvents = CommonTool.Append(bp.m_UnrestMitigationEvents, unrestMitigationEvents.Select(name => BlueprintTool.GetRef<BlueprintKingdomProjectReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="KingdomRoot.m_UnrestMitigationEvents"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="unrestMitigationEvents"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomProject"/></param>
    [Generated]
    public KingdomRootConfigurator RemoveFromUnrestMitigationEvents(params string[] unrestMitigationEvents)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = unrestMitigationEvents.Select(name => BlueprintTool.GetRef<BlueprintKingdomProjectReference>(name));
            bp.m_UnrestMitigationEvents =
                bp.m_UnrestMitigationEvents
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.m_UIRoot"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="uIRoot"><see cref="Kingmaker.Kingdom.KingdomUIRoot"/></param>
    [Generated]
    public KingdomRootConfigurator SetUIRoot(string? uIRoot)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_UIRoot = BlueprintTool.GetRef<KingdomUIRootReference>(uIRoot);
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.LeaderSlots"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetLeaderSlots(LeaderSlot[]? leaderSlots)
    {
      ValidateParam(leaderSlots);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.LeaderSlots = leaderSlots;
          });
    }

    /// <summary>
    /// Adds to <see cref="KingdomRoot.LeaderSlots"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator AddToLeaderSlots(params LeaderSlot[] leaderSlots)
    {
      ValidateParam(leaderSlots);
      return OnConfigureInternal(
          bp =>
          {
            bp.LeaderSlots = CommonTool.Append(bp.LeaderSlots, leaderSlots ?? new LeaderSlot[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="KingdomRoot.LeaderSlots"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator RemoveFromLeaderSlots(params LeaderSlot[] leaderSlots)
    {
      ValidateParam(leaderSlots);
      return OnConfigureInternal(
          bp =>
          {
            bp.LeaderSlots = bp.LeaderSlots.Where(item => !leaderSlots.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.m_StartingNPCLeaders"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="startingNPCLeaders"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public KingdomRootConfigurator SetStartingNPCLeaders(string[]? startingNPCLeaders)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_StartingNPCLeaders = startingNPCLeaders.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="KingdomRoot.m_StartingNPCLeaders"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="startingNPCLeaders"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public KingdomRootConfigurator AddToStartingNPCLeaders(params string[] startingNPCLeaders)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_StartingNPCLeaders = CommonTool.Append(bp.m_StartingNPCLeaders, startingNPCLeaders.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="KingdomRoot.m_StartingNPCLeaders"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="startingNPCLeaders"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public KingdomRootConfigurator RemoveFromStartingNPCLeaders(params string[] startingNPCLeaders)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = startingNPCLeaders.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name));
            bp.m_StartingNPCLeaders =
                bp.m_StartingNPCLeaders
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.m_Timeline"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="timeline"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomEventTimeline"/></param>
    [Generated]
    public KingdomRootConfigurator SetTimeline(string? timeline)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Timeline = BlueprintTool.GetRef<BlueprintKingdomEventTimelineReference>(timeline);
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.m_CrusadeEventsTimeline"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="crusadeEventsTimeline"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintCrusadeEventTimeline"/></param>
    [Generated]
    public KingdomRootConfigurator SetCrusadeEventsTimeline(string? crusadeEventsTimeline)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CrusadeEventsTimeline = BlueprintTool.GetRef<BlueprintCrusadeEventTimeline.Reference>(crusadeEventsTimeline);
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.m_RegionUpgradesAvailable"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="regionUpgradesAvailable"><see cref="Kingmaker.Blueprints.BlueprintUnlockableFlag"/></param>
    [Generated]
    public KingdomRootConfigurator SetRegionUpgradesAvailable(string? regionUpgradesAvailable)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_RegionUpgradesAvailable = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(regionUpgradesAvailable);
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.m_BpVendorItem"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="bpVendorItem"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    public KingdomRootConfigurator SetBpVendorItem(string? bpVendorItem)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_BpVendorItem = BlueprintTool.GetRef<BlueprintItemReference>(bpVendorItem);
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.m_ConsumableEventBonusVendorItem"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="consumableEventBonusVendorItem"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    public KingdomRootConfigurator SetConsumableEventBonusVendorItem(string? consumableEventBonusVendorItem)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ConsumableEventBonusVendorItem = BlueprintTool.GetRef<BlueprintItemReference>(consumableEventBonusVendorItem);
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.StatIncreaseOnEvent"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetStatIncreaseOnEvent(int statIncreaseOnEvent)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.StatIncreaseOnEvent = statIncreaseOnEvent;
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.StatMaxRankInBarony"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetStatMaxRankInBarony(int statMaxRankInBarony)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.StatMaxRankInBarony = statMaxRankInBarony;
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.ResourcesPerEconomyRank"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetResourcesPerEconomyRank(KingdomResourcesAmount resourcesPerEconomyRank)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ResourcesPerEconomyRank = resourcesPerEconomyRank;
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.SettlementCost"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SettlementCost(KingdomResourcesAmount settlementCost)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.SettlementCost = settlementCost;
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.KingdomStatRankStep"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetKingdomStatRankStep(int kingdomStatRankStep)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.KingdomStatRankStep = kingdomStatRankStep;
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.BaronySubsidy"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetBaronySubsidy(KingdomResourcesAmount baronySubsidy)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.BaronySubsidy = baronySubsidy;
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.BaronyResourcesModifier"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetBaronyResourcesModifier(float baronyResourcesModifier)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.BaronyResourcesModifier = baronyResourcesModifier;
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.ResourcesAtStart"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetResourcesAtStart(KingdomResourcesAmount resourcesAtStart)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ResourcesAtStart = resourcesAtStart;
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.ResourcesAtStartPerTurn"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetResourcesAtStartPerTurn(KingdomResourcesAmount resourcesAtStartPerTurn)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ResourcesAtStartPerTurn = resourcesAtStartPerTurn;
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.ConsumableEventBonusAtStart"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetConsumableEventBonusAtStart(int consumableEventBonusAtStart)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ConsumableEventBonusAtStart = consumableEventBonusAtStart;
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.ConsumableEventBonusPerRankUp"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetConsumableEventBonusPerRankUp(int consumableEventBonusPerRankUp)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ConsumableEventBonusPerRankUp = consumableEventBonusPerRankUp;
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.ConsumableEventBonusModifierValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetConsumableEventBonusModifierValue(int consumableEventBonusModifierValue)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ConsumableEventBonusModifierValue = consumableEventBonusModifierValue;
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.CustomLeaderPenalty"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetCustomLeaderPenalty(int customLeaderPenalty)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CustomLeaderPenalty = customLeaderPenalty;
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.BuildingSequenceCostMultiplier"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetBuildingSequenceCostMultiplier(float buildingSequenceCostMultiplier)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.BuildingSequenceCostMultiplier = buildingSequenceCostMultiplier;
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.DefaultMapResourceCost"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetDefaultMapResourceCost(KingdomResourcesAmount defaultMapResourceCost)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DefaultMapResourceCost = defaultMapResourceCost;
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.RavenVisitDelayDays"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetRavenVisitDelayDays(int ravenVisitDelayDays)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.RavenVisitDelayDays = ravenVisitDelayDays;
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.DefaultName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetDefaultName(LocalizedString? defaultName)
    {
      ValidateParam(defaultName);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.DefaultName = defaultName ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.MoraleMaxValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetMoraleMaxValue(int moraleMaxValue)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MoraleMaxValue = moraleMaxValue;
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.MoraleDefaultMaxValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetMoraleDefaultMaxValue(int moraleDefaultMaxValue)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MoraleDefaultMaxValue = moraleDefaultMaxValue;
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.MoraleMinValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetMoraleMinValue(int moraleMinValue)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MoraleMinValue = moraleMinValue;
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.MoraleStartValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetMoraleStartValue(int moraleStartValue)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MoraleStartValue = moraleStartValue;
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.StartArmySquadsCount"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetStartArmySquadsCount(int startArmySquadsCount)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.StartArmySquadsCount = startArmySquadsCount;
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.MaxArmySquadsCount"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetMaxArmySquadsCount(int maxArmySquadsCount)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MaxArmySquadsCount = maxArmySquadsCount;
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.m_StoryModeBuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="storyModeBuff"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomBuff"/></param>
    [Generated]
    public KingdomRootConfigurator SetStoryModeBuff(string? storyModeBuff)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_StoryModeBuff = BlueprintTool.GetRef<BlueprintKingdomBuffReference>(storyModeBuff);
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.m_CasualModeBuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="casualModeBuff"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomBuff"/></param>
    [Generated]
    public KingdomRootConfigurator SetCasualModeBuff(string? casualModeBuff)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CasualModeBuff = BlueprintTool.GetRef<BlueprintKingdomBuffReference>(casualModeBuff);
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.Village"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetVillage(KingdomRoot.SettlementLevelData village)
    {
      ValidateParam(village);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Village = village;
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.Town"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetTown(KingdomRoot.SettlementLevelData town)
    {
      ValidateParam(town);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Town = town;
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.City"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetCity(KingdomRoot.SettlementLevelData city)
    {
      ValidateParam(city);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.City = city;
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.Stats"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetStats(KingdomRoot.StatData[]? stats)
    {
      ValidateParam(stats);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Stats = stats;
          });
    }

    /// <summary>
    /// Adds to <see cref="KingdomRoot.Stats"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator AddToStats(params KingdomRoot.StatData[] stats)
    {
      ValidateParam(stats);
      return OnConfigureInternal(
          bp =>
          {
            bp.Stats = CommonTool.Append(bp.Stats, stats ?? new KingdomRoot.StatData[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="KingdomRoot.Stats"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator RemoveFromStats(params KingdomRoot.StatData[] stats)
    {
      ValidateParam(stats);
      return OnConfigureInternal(
          bp =>
          {
            bp.Stats = bp.Stats.Where(item => !stats.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.m_EntryPoint"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="entryPoint"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaEnterPoint"/></param>
    [Generated]
    public KingdomRootConfigurator SetEntryPoint(string? entryPoint)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_EntryPoint = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(entryPoint);
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.m_Regions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="regions"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintRegion"/></param>
    [Generated]
    public KingdomRootConfigurator SetRegions(string[]? regions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Regions = regions.Select(name => BlueprintTool.GetRef<BlueprintRegionReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="KingdomRoot.m_Regions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="regions"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintRegion"/></param>
    [Generated]
    public KingdomRootConfigurator AddToRegions(params string[] regions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Regions = CommonTool.Append(bp.m_Regions, regions.Select(name => BlueprintTool.GetRef<BlueprintRegionReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="KingdomRoot.m_Regions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="regions"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintRegion"/></param>
    [Generated]
    public KingdomRootConfigurator RemoveFromRegions(params string[] regions)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = regions.Select(name => BlueprintTool.GetRef<BlueprintRegionReference>(name));
            bp.m_Regions =
                bp.m_Regions
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.m_Locations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="locations"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMapPoint"/></param>
    [Generated]
    public KingdomRootConfigurator SetLocations(string[]? locations)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Locations = locations.Select(name => BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="KingdomRoot.m_Locations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="locations"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMapPoint"/></param>
    [Generated]
    public KingdomRootConfigurator AddToLocations(params string[] locations)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Locations = CommonTool.Append(bp.m_Locations, locations.Select(name => BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="KingdomRoot.m_Locations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="locations"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMapPoint"/></param>
    [Generated]
    public KingdomRootConfigurator RemoveFromLocations(params string[] locations)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = locations.Select(name => BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(name));
            bp.m_Locations =
                bp.m_Locations
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.ArtisanTierChances"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetArtisanTierChances(int[]? artisanTierChances)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ArtisanTierChances = artisanTierChances;
          });
    }

    /// <summary>
    /// Adds to <see cref="KingdomRoot.ArtisanTierChances"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator AddToArtisanTierChances(params int[] artisanTierChances)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ArtisanTierChances = CommonTool.Append(bp.ArtisanTierChances, artisanTierChances ?? new int[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="KingdomRoot.ArtisanTierChances"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator RemoveFromArtisanTierChances(params int[] artisanTierChances)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ArtisanTierChances = bp.ArtisanTierChances.Where(item => !artisanTierChances.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.ArtisanTierChancesRequest"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetArtisanTierChancesRequest(int[]? artisanTierChancesRequest)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ArtisanTierChancesRequest = artisanTierChancesRequest;
          });
    }

    /// <summary>
    /// Adds to <see cref="KingdomRoot.ArtisanTierChancesRequest"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator AddToArtisanTierChancesRequest(params int[] artisanTierChancesRequest)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ArtisanTierChancesRequest = CommonTool.Append(bp.ArtisanTierChancesRequest, artisanTierChancesRequest ?? new int[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="KingdomRoot.ArtisanTierChancesRequest"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator RemoveFromArtisanTierChancesRequest(params int[] artisanTierChancesRequest)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ArtisanTierChancesRequest = bp.ArtisanTierChancesRequest.Where(item => !artisanTierChancesRequest.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.ArtisanMasterpieceChance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetArtisanMasterpieceChance(float artisanMasterpieceChance)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ArtisanMasterpieceChance = artisanMasterpieceChance;
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.DifficultyDCMod"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetDifficultyDCMod(int[]? difficultyDCMod)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DifficultyDCMod = difficultyDCMod;
          });
    }

    /// <summary>
    /// Adds to <see cref="KingdomRoot.DifficultyDCMod"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator AddToDifficultyDCMod(params int[] difficultyDCMod)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DifficultyDCMod = CommonTool.Append(bp.DifficultyDCMod, difficultyDCMod ?? new int[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="KingdomRoot.DifficultyDCMod"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator RemoveFromDifficultyDCMod(params int[] difficultyDCMod)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DifficultyDCMod = bp.DifficultyDCMod.Where(item => !difficultyDCMod.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.AutoCheatResources"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetAutoCheatResources(KingdomResourcesAmount autoCheatResources)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AutoCheatResources = autoCheatResources;
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.AutoCheatResourcesPerDay"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetAutoCheatResourcesPerDay(KingdomResourcesAmount autoCheatResourcesPerDay)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AutoCheatResourcesPerDay = autoCheatResourcesPerDay;
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.AviaryTimeReduction"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetAviaryTimeReduction(int aviaryTimeReduction)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AviaryTimeReduction = aviaryTimeReduction;
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.ProjectRefundFactor"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetProjectRefundFactor(float projectRefundFactor)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ProjectRefundFactor = projectRefundFactor;
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.RankUps"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetRankUps(KingdomRankUpsRoot rankUps)
    {
      ValidateParam(rankUps);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.RankUps = rankUps;
          });
    }

    /// <summary>
    /// Sets <see cref="KingdomRoot.SiegeCooldownHours"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomRootConfigurator SetSiegeCooldownHours(int siegeCooldownHours)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.SiegeCooldownHours = siegeCooldownHours;
          });
    }
  }
}
