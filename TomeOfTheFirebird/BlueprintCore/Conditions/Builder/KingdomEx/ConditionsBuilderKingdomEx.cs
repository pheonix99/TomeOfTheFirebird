using BlueprintCore.Utils;
using Kingmaker.Armies.Components;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.Conditions;
using Kingmaker.Kingdom.Flags;
using Kingmaker.Kingdom.Settlements;
using Kingmaker.UnitLogic.Alignments;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using System.Linq;
#nullable enable
namespace BlueprintCore.Conditions.Builder.KingdomEx
{
  /// <summary>
  /// Extension to <see cref="ConditionsBuilder"/> for conditions involving the Kingdom and Crusade system.
  /// </summary>
  /// <inheritdoc cref="ConditionsBuilder"/>
  public static class ConditionsBuilderKingdomEx
  {
    //----- Auto Generated -----//

    /// <summary>
    /// Adds <see cref="HasTacticalMorale"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(HasTacticalMorale))]
    public static ConditionsBuilder HasTacticalMorale(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<HasTacticalMorale>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatSquadHitPointsCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TacticalCombatSquadHitPointsCondition))]
    public static ConditionsBuilder TacticalCombatSquadHitPointsCondition(
        this ConditionsBuilder builder,
        bool checkInitiatorHP = default,
        CompareOperation.Type operation = default,
        ContextValue? referenceValue = null,
        bool negate = false)
    {
      builder.Validate(referenceValue);
    
      var element = ElementTool.Create<TacticalCombatSquadHitPointsCondition>();
      element.CheckInitiatorHP = checkInitiatorHP;
      element.Operation = operation;
      element.ReferenceValue = referenceValue ?? ContextValues.Constant(0);
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="TargetHasArmyTag"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TargetHasArmyTag))]
    public static ConditionsBuilder TargetHasArmyTag(
        this ConditionsBuilder builder,
        ArmyProperties tags = default,
        bool needAllTags = default,
        bool negate = false)
    {
      var element = ElementTool.Create<TargetHasArmyTag>();
      element.m_Tags = tags;
      element.m_NeedAllTags = needAllTags;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionGarrisonClear"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="globalMapPoint"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMapPoint"/></param>
    [Generated]
    [Implements(typeof(ContextConditionGarrisonClear))]
    public static ConditionsBuilder ContextConditionGarrisonClear(
        this ConditionsBuilder builder,
        string? globalMapPoint = null,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionGarrisonClear>();
      element.m_GlobalMapPoint = BlueprintTool.GetRef<BlueprintGlobalMapPointReference>(globalMapPoint);
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AnySettlementUnderSiege"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AnySettlementUnderSiege))]
    public static ConditionsBuilder AnySettlementUnderSiege(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<AnySettlementUnderSiege>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomMoraleFlagCondition"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="flag"><see cref="Kingmaker.Kingdom.Flags.BlueprintKingdomMoraleFlag"/></param>
    [Generated]
    [Implements(typeof(KingdomMoraleFlagCondition))]
    public static ConditionsBuilder KingdomMoraleFlagCondition(
        this ConditionsBuilder builder,
        string? flag = null,
        KingdomMoraleFlag.State state = default,
        bool negate = false)
    {
      var element = ElementTool.Create<KingdomMoraleFlagCondition>();
      element.m_Flag = BlueprintTool.GetRef<BlueprintKingdomMoraleFlag.Reference>(flag);
      element.m_State = state;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ArmyInLocationDefeated"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="location"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMapPoint"/></param>
    [Generated]
    [Implements(typeof(ArmyInLocationDefeated))]
    public static ConditionsBuilder ArmyInLocationDefeated(
        this ConditionsBuilder builder,
        string? location = null,
        bool negate = false)
    {
      var element = ElementTool.Create<ArmyInLocationDefeated>();
      element.m_Location = BlueprintTool.GetRef<BlueprintGlobalMapPointReference>(location);
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AutoKingdom"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AutoKingdom))]
    public static ConditionsBuilder AutoKingdom(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<AutoKingdom>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="BuildingHasNeighbours"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="specificBuildings"><see cref="Kingmaker.Kingdom.Settlements.BlueprintSettlementBuilding"/></param>
    [Generated]
    [Implements(typeof(BuildingHasNeighbours))]
    public static ConditionsBuilder BuildingHasNeighbours(
        this ConditionsBuilder builder,
        string[]? specificBuildings = null,
        bool anywhereInTown = default,
        bool negate = false)
    {
      var element = ElementTool.Create<BuildingHasNeighbours>();
      element.m_SpecificBuildings = specificBuildings.Select(name => BlueprintTool.GetRef<BlueprintSettlementBuildingReference>(name)).ToArray();
      element.AnywhereInTown = anywhereInTown;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DaysTillNextMonth"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DaysTillNextMonth))]
    public static ConditionsBuilder DaysTillNextMonth(
        this ConditionsBuilder builder,
        bool atMost = default,
        int days = default,
        bool negate = false)
    {
      var element = ElementTool.Create<DaysTillNextMonth>();
      element.AtMost = atMost;
      element.Days = days;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="EventLifetime"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EventLifetime))]
    public static ConditionsBuilder EventLifetime(
        this ConditionsBuilder builder,
        int lessThan = default,
        int moreThan = default,
        bool negate = false)
    {
      var element = ElementTool.Create<EventLifetime>();
      element.LessThan = lessThan;
      element.MoreThan = moreThan;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomAlignmentIs"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomAlignmentIs))]
    public static ConditionsBuilder KingdomAlignmentIs(
        this ConditionsBuilder builder,
        AlignmentMaskType alignment = default,
        bool negate = false)
    {
      var element = ElementTool.Create<KingdomAlignmentIs>();
      element.Alignment = alignment;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomAllArmiesInRegionDefeated"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="region"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintRegion"/></param>
    [Generated]
    [Implements(typeof(KingdomAllArmiesInRegionDefeated))]
    public static ConditionsBuilder KingdomAllArmiesInRegionDefeated(
        this ConditionsBuilder builder,
        string? region = null,
        bool negate = false)
    {
      var element = ElementTool.Create<KingdomAllArmiesInRegionDefeated>();
      element.m_Region = BlueprintTool.GetRef<BlueprintRegionReference>(region);
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomArtisanState"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="artisan"><see cref="Kingmaker.Kingdom.Artisans.BlueprintKingdomArtisan"/></param>
    [Generated]
    [Implements(typeof(KingdomArtisanState))]
    public static ConditionsBuilder KingdomArtisanState(
        this ConditionsBuilder builder,
        string? artisan = null,
        KingdomArtisanState.CheckType _Check = default,
        int tier = default,
        bool negate = false)
    {
      var element = ElementTool.Create<KingdomArtisanState>();
      element.m_Artisan = BlueprintTool.GetRef<BlueprintKingdomArtisanReference>(artisan);
      element._Check = _Check;
      element.Tier = tier;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomBuffIsActive"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="blueprint"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomBuff"/></param>
    /// <param name="region"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintRegion"/></param>
    [Generated]
    [Implements(typeof(KingdomBuffIsActive))]
    public static ConditionsBuilder KingdomBuffIsActive(
        this ConditionsBuilder builder,
        string? blueprint = null,
        string? region = null,
        bool negate = false)
    {
      var element = ElementTool.Create<KingdomBuffIsActive>();
      element.m_Blueprint = BlueprintTool.GetRef<BlueprintKingdomBuffReference>(blueprint);
      element.m_Region = BlueprintTool.GetRef<BlueprintRegionReference>(region);
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomChapterWeek"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomChapterWeek))]
    public static ConditionsBuilder KingdomChapterWeek(
        this ConditionsBuilder builder,
        int week = default,
        bool negate = false)
    {
      var element = ElementTool.Create<KingdomChapterWeek>();
      element.Week = week;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomDay"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomDay))]
    public static ConditionsBuilder KingdomDay(
        this ConditionsBuilder builder,
        bool atMost = default,
        int day = default,
        bool negate = false)
    {
      var element = ElementTool.Create<KingdomDay>();
      element.AtMost = atMost;
      element.Day = day;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomEventCanStart"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="eventValue"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomEvent"/></param>
    /// <param name="region"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintRegion"/></param>
    [Generated]
    [Implements(typeof(KingdomEventCanStart))]
    public static ConditionsBuilder KingdomEventCanStart(
        this ConditionsBuilder builder,
        string? eventValue = null,
        string? region = null,
        bool negate = false)
    {
      var element = ElementTool.Create<KingdomEventCanStart>();
      element.m_Event = BlueprintTool.GetRef<BlueprintKingdomEventReference>(eventValue);
      element.m_Region = BlueprintTool.GetRef<BlueprintRegionReference>(region);
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomEventIsActive"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="eventValue"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomEvent"/></param>
    [Generated]
    [Implements(typeof(KingdomEventIsActive))]
    public static ConditionsBuilder KingdomEventIsActive(
        this ConditionsBuilder builder,
        string? eventValue = null,
        bool negate = false)
    {
      var element = ElementTool.Create<KingdomEventIsActive>();
      element.m_Event = BlueprintTool.GetRef<BlueprintKingdomEventReference>(eventValue);
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomEventIsBeingResolved"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="eventValue"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomEventBase"/></param>
    [Generated]
    [Implements(typeof(KingdomEventIsBeingResolved))]
    public static ConditionsBuilder KingdomEventIsBeingResolved(
        this ConditionsBuilder builder,
        string? eventValue = null,
        bool negate = false)
    {
      var element = ElementTool.Create<KingdomEventIsBeingResolved>();
      element.m_Event = BlueprintTool.GetRef<BlueprintKingdomEventBaseReference>(eventValue);
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomExists"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomExists))]
    public static ConditionsBuilder KingdomExists(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<KingdomExists>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomHasResolvableEvent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomHasResolvableEvent))]
    public static ConditionsBuilder KingdomHasResolvableEvent(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<KingdomHasResolvableEvent>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomHasUpgradeableSettlement"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="specificSettlement"><see cref="Kingmaker.Kingdom.BlueprintSettlement"/></param>
    [Generated]
    [Implements(typeof(KingdomHasUpgradeableSettlement))]
    public static ConditionsBuilder KingdomHasUpgradeableSettlement(
        this ConditionsBuilder builder,
        SettlementState.LevelType level = default,
        string? specificSettlement = null,
        bool negate = false)
    {
      var element = ElementTool.Create<KingdomHasUpgradeableSettlement>();
      element.Level = level;
      element.m_SpecificSettlement = BlueprintTool.GetRef<BlueprintSettlement.Reference>(specificSettlement);
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomIsVisible"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomIsVisible))]
    public static ConditionsBuilder KingdomIsVisible(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<KingdomIsVisible>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomLeaderIs"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="unit"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(KingdomLeaderIs))]
    public static ConditionsBuilder KingdomLeaderIs(
        this ConditionsBuilder builder,
        LeaderType leader = default,
        string? unit = null,
        bool allowCustomCompanions = default,
        bool negate = false)
    {
      var element = ElementTool.Create<KingdomLeaderIs>();
      element.Leader = leader;
      element.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(unit);
      element.AllowCustomCompanions = allowCustomCompanions;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomProjectIsAvailable"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="project"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomProject"/></param>
    [Generated]
    [Implements(typeof(KingdomProjectIsAvailable))]
    public static ConditionsBuilder KingdomProjectIsAvailable(
        this ConditionsBuilder builder,
        string? project = null,
        bool checkResources = default,
        bool checkLeader = default,
        bool finishableThisMonth = default,
        bool negate = false)
    {
      var element = ElementTool.Create<KingdomProjectIsAvailable>();
      element.m_Project = BlueprintTool.GetRef<BlueprintKingdomProjectReference>(project);
      element.CheckResources = checkResources;
      element.CheckLeader = checkLeader;
      element.FinishableThisMonth = finishableThisMonth;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomProjectIsDone"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="project"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomProject"/></param>
    [Generated]
    [Implements(typeof(KingdomProjectIsDone))]
    public static ConditionsBuilder KingdomProjectIsDone(
        this ConditionsBuilder builder,
        string? project = null,
        bool negate = false)
    {
      var element = ElementTool.Create<KingdomProjectIsDone>();
      element.m_Project = BlueprintTool.GetRef<BlueprintKingdomProjectReference>(project);
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomRankUpConditions"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomRankUpConditions))]
    public static ConditionsBuilder KingdomRankUpConditions(
        this ConditionsBuilder builder,
        KingdomStats.Type stat = default,
        int nextRank = default,
        bool negate = false)
    {
      var element = ElementTool.Create<KingdomRankUpConditions>();
      element.Stat = stat;
      element.NextRank = nextRank;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomRegionIsConquered"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="region"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintRegion"/></param>
    [Generated]
    [Implements(typeof(KingdomRegionIsConquered))]
    public static ConditionsBuilder KingdomRegionIsConquered(
        this ConditionsBuilder builder,
        string? region = null,
        bool negate = false)
    {
      var element = ElementTool.Create<KingdomRegionIsConquered>();
      element.m_Region = BlueprintTool.GetRef<BlueprintRegionReference>(region);
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomRegionIsUpgraded"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="region"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintRegion"/></param>
    /// <param name="eventValue"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomUpgrade"/></param>
    [Generated]
    [Implements(typeof(KingdomRegionIsUpgraded))]
    public static ConditionsBuilder KingdomRegionIsUpgraded(
        this ConditionsBuilder builder,
        string? region = null,
        string? eventValue = null,
        bool negate = false)
    {
      var element = ElementTool.Create<KingdomRegionIsUpgraded>();
      element.m_Region = BlueprintTool.GetRef<BlueprintRegionReference>(region);
      element.m_Event = BlueprintTool.GetRef<BlueprintKingdomUpgradeReference>(eventValue);
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomSettlementCount"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomSettlementCount))]
    public static ConditionsBuilder KingdomSettlementCount(
        this ConditionsBuilder builder,
        SettlementState.LevelType minLevel = default,
        int count = default,
        bool negate = false)
    {
      var element = ElementTool.Create<KingdomSettlementCount>();
      element.MinLevel = minLevel;
      element.Count = count;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomSettlementHasBuilding"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="settlement"><see cref="Kingmaker.Kingdom.BlueprintSettlement"/></param>
    /// <param name="building"><see cref="Kingmaker.Kingdom.Settlements.BlueprintSettlementBuilding"/></param>
    [Generated]
    [Implements(typeof(KingdomSettlementHasBuilding))]
    public static ConditionsBuilder KingdomSettlementHasBuilding(
        this ConditionsBuilder builder,
        string? settlement = null,
        string? building = null,
        bool negate = false)
    {
      var element = ElementTool.Create<KingdomSettlementHasBuilding>();
      element.m_Settlement = BlueprintTool.GetRef<BlueprintSettlement.Reference>(settlement);
      element.m_Building = BlueprintTool.GetRef<BlueprintSettlementBuildingReference>(building);
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomStatCheck"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomStatCheck))]
    public static ConditionsBuilder KingdomStatCheck(
        this ConditionsBuilder builder,
        KingdomStats.Type statType = default,
        int value = default,
        bool atMost = default,
        bool checkRank = default,
        bool negate = false)
    {
      var element = ElementTool.Create<KingdomStatCheck>();
      element.StatType = statType;
      element.Value = value;
      element.AtMost = atMost;
      element.CheckRank = checkRank;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomStatIsMaximum"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomStatIsMaximum))]
    public static ConditionsBuilder KingdomStatIsMaximum(
        this ConditionsBuilder builder,
        KingdomStats.Type statType = default,
        bool negate = false)
    {
      var element = ElementTool.Create<KingdomStatIsMaximum>();
      element.StatType = statType;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomTaskResolvedBy"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomTaskResolvedBy))]
    public static ConditionsBuilder KingdomTaskResolvedBy(
        this ConditionsBuilder builder,
        LeaderType[]? leaders = null,
        bool negate = false)
    {
      var element = ElementTool.Create<KingdomTaskResolvedBy>();
      element.Leaders = leaders;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="KingdomUnrestCheck"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomUnrestCheck))]
    public static ConditionsBuilder KingdomUnrestCheck(
        this ConditionsBuilder builder,
        KingdomStatusType value = default,
        bool atMost = default,
        bool negate = false)
    {
      var element = ElementTool.Create<KingdomUnrestCheck>();
      element.Value = value;
      element.AtMost = atMost;
      element.Not = negate;
      return builder.Add(element);
    }
  }
}
