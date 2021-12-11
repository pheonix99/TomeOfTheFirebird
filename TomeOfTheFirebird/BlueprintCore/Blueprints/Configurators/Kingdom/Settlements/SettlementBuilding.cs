using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Armies.Components;
using Kingmaker.Blueprints;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Kingdom.Buffs;
using Kingmaker.Kingdom.Flags;
using Kingmaker.Kingdom.Settlements;
using Kingmaker.Kingdom.Settlements.BuildingComponents;
using Kingmaker.Localization;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Alignments;
using System;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Kingdom.Settlements
{
  /// <summary>
  /// Configurator for <see cref="BlueprintSettlementBuilding"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintSettlementBuilding))]
  public class SettlementBuildingConfigurator : BaseFactConfigurator<BlueprintSettlementBuilding, SettlementBuildingConfigurator>
  {
    private SettlementBuildingConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static SettlementBuildingConfigurator For(string name)
    {
      return new SettlementBuildingConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static SettlementBuildingConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintSettlementBuilding>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintSettlementBuilding.Name"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SettlementBuildingConfigurator SetName(LocalizedString? name)
    {
      ValidateParam(name);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Name = name ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSettlementBuilding.Description"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SettlementBuildingConfigurator SetDescription(LocalizedString? description)
    {
      ValidateParam(description);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Description = description ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSettlementBuilding.MechanicalDescription"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SettlementBuildingConfigurator SetMechanicalDescription(LocalizedString? mechanicalDescription)
    {
      ValidateParam(mechanicalDescription);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.MechanicalDescription = mechanicalDescription ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSettlementBuilding.CompletedPrefab"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SettlementBuildingConfigurator SetCompletedPrefab(SettlementBuildingItem completedPrefab)
    {
      ValidateParam(completedPrefab);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.CompletedPrefab = completedPrefab;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSettlementBuilding.UnfinishedPrefab"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SettlementBuildingConfigurator SetUnfinishedPrefab(SettlementBuildingItem unfinishedPrefab)
    {
      ValidateParam(unfinishedPrefab);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.UnfinishedPrefab = unfinishedPrefab;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSettlementBuilding.BuildCost"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SettlementBuildingConfigurator SetBuildCost(KingdomResourcesAmount buildCost)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.BuildCost = buildCost;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSettlementBuilding.StatChanges"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SettlementBuildingConfigurator SetStatChanges(KingdomStats.Changes statChanges)
    {
      ValidateParam(statChanges);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.StatChanges = statChanges;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSettlementBuilding.MinLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SettlementBuildingConfigurator SetMinLevel(SettlementState.LevelType minLevel)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MinLevel = minLevel;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSettlementBuilding.SlotSizeX"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SettlementBuildingConfigurator SetSlotSizeX(int slotSizeX)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.SlotSizeX = slotSizeX;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSettlementBuilding.SlotSizeY"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SettlementBuildingConfigurator SetSlotSizeY(int slotSizeY)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.SlotSizeY = slotSizeY;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSettlementBuilding.BuildTime"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SettlementBuildingConfigurator SetBuildTime(int buildTime)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.BuildTime = buildTime;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSettlementBuilding.SpecialSlot"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SettlementBuildingConfigurator SetSpecialSlot(SettlementState.SpecialSlotType specialSlot)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.SpecialSlot = specialSlot;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSettlementBuilding.m_UpgradesTo"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="upgradesTo"><see cref="Kingmaker.Kingdom.Settlements.BlueprintSettlementBuilding"/></param>
    [Generated]
    public SettlementBuildingConfigurator SetUpgradesTo(string? upgradesTo)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_UpgradesTo = BlueprintTool.GetRef<BlueprintSettlementBuildingReference>(upgradesTo);
          });
    }

    /// <summary>
    /// Adds <see cref="LocationRadiusBuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(LocationRadiusBuff))]
    public SettlementBuildingConfigurator AddLocationRadiusBuff(
        float radius = default,
        string? buff = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new LocationRadiusBuff();
      component.Radius = radius;
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AdjacencyRestriction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buildings"><see cref="Kingmaker.Kingdom.Settlements.BlueprintSettlementBuilding"/></param>
    [Generated]
    [Implements(typeof(AdjacencyRestriction))]
    public SettlementBuildingConfigurator AddAdjacencyRestriction(
        bool invert = default,
        string[]? buildings = null)
    {
      var component = new AdjacencyRestriction();
      component.Invert = invert;
      component.Buildings = buildings.Select(name => BlueprintTool.GetRef<BlueprintSettlementBuildingReference>(name)).ToList();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AlignmentRestriction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AlignmentRestriction))]
    public SettlementBuildingConfigurator AddAlignmentRestriction(
        AlignmentMaskType allowed = default)
    {
      var component = new AlignmentRestriction();
      component.Allowed = allowed;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArtisanRestriction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArtisanRestriction))]
    public SettlementBuildingConfigurator AddArtisanRestriction()
    {
      return AddComponent(new ArtisanRestriction());
    }

    /// <summary>
    /// Adds <see cref="Aviary"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(Aviary))]
    public SettlementBuildingConfigurator AddAviary(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new Aviary();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="BuildingAdjacencyBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buildings"><see cref="Kingmaker.Kingdom.Settlements.BlueprintSettlementBuilding"/></param>
    [Generated]
    [Implements(typeof(BuildingAdjacencyBonus))]
    public SettlementBuildingConfigurator AddBuildingAdjacencyBonus(
        KingdomStats.Changes stats,
        bool noSuchBuildings = default,
        BuildingAdjacencyBonus.DistanceRequirementType distance = default,
        BuildingAdjacencyBonus.CalculationType calculation = default,
        bool anyBuilding = default,
        string[]? buildings = null)
    {
      ValidateParam(stats);
    
      var component = new BuildingAdjacencyBonus();
      component.NoSuchBuildings = noSuchBuildings;
      component.Distance = distance;
      component.Calculation = calculation;
      component.Stats = stats;
      component.AnyBuilding = anyBuilding;
      component.Buildings = buildings.Select(name => BlueprintTool.GetRef<BlueprintSettlementBuildingReference>(name)).ToList();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildingAdjacentGrowthIncrease"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuildingAdjacentGrowthIncrease))]
    public SettlementBuildingConfigurator AddBuildingAdjacentGrowthIncrease(
        bool allUnits = default,
        ArmyProperties properties = default,
        BuildingAdjacencyBonus.DistanceRequirementType distance = default,
        int bonusPercent = default)
    {
      var component = new BuildingAdjacentGrowthIncrease();
      component.AllUnits = allUnits;
      component.Properties = properties;
      component.Distance = distance;
      component.BonusPercent = bonusPercent;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildingAdjacentResourceIncrease"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="specificBuilding"><see cref="Kingmaker.Kingdom.Settlements.BlueprintSettlementBuilding"/></param>
    [Generated]
    [Implements(typeof(BuildingAdjacentResourceIncrease))]
    public SettlementBuildingConfigurator AddBuildingAdjacentResourceIncrease(
        int financeModifier = default,
        int basicsModifier = default,
        int favorsModifier = default,
        string? specificBuilding = null,
        BuildingAdjacencyBonus.DistanceRequirementType distance = default,
        int bonusPercent = default)
    {
      var component = new BuildingAdjacentResourceIncrease();
      component.FinanceModifier = financeModifier;
      component.BasicsModifier = basicsModifier;
      component.FavorsModifier = favorsModifier;
      component.m_SpecificBuilding = BlueprintTool.GetRef<BlueprintSettlementBuildingReference>(specificBuilding);
      component.Distance = distance;
      component.BonusPercent = bonusPercent;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildingAttachedBuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomBuff"/></param>
    [Generated]
    [Implements(typeof(BuildingAttachedBuff))]
    public SettlementBuildingConfigurator AddBuildingAttachedBuff(
        string? buff = null,
        bool onlyInRegion = default)
    {
      var component = new BuildingAttachedBuff();
      component.m_Buff = BlueprintTool.GetRef<BlueprintKingdomBuffReference>(buff);
      component.m_OnlyInRegion = onlyInRegion;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildingCountsAs"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buildings"><see cref="Kingmaker.Kingdom.Settlements.BlueprintSettlementBuilding"/></param>
    [Generated]
    [Implements(typeof(BuildingCountsAs))]
    public SettlementBuildingConfigurator AddBuildingCountsAs(
        string[]? buildings = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new BuildingCountsAs();
      component.Buildings = buildings.Select(name => BlueprintTool.GetRef<BlueprintSettlementBuildingReference>(name)).ToList();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="BuildingGlobalGrowthIncrease"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuildingGlobalGrowthIncrease))]
    public SettlementBuildingConfigurator AddBuildingGlobalGrowthIncrease(
        bool allUnits = default,
        ArmyProperties properties = default,
        int bonusPercent = default)
    {
      var component = new BuildingGlobalGrowthIncrease();
      component.AllUnits = allUnits;
      component.Properties = properties;
      component.BonusPercent = bonusPercent;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildingLoneSlotBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuildingLoneSlotBonus))]
    public SettlementBuildingConfigurator AddBuildingLoneSlotBonus(
        KingdomStats.Changes stats)
    {
      ValidateParam(stats);
    
      var component = new BuildingLoneSlotBonus();
      component.Stats = stats;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildingMoraleChangeBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuildingMoraleChangeBonus))]
    public SettlementBuildingConfigurator AddBuildingMoraleChangeBonus(
        bool negative = default,
        bool positive = default,
        int percentBonus = default,
        int flatBonus = default)
    {
      var component = new BuildingMoraleChangeBonus();
      component.Negative = negative;
      component.Positive = positive;
      component.PercentBonus = percentBonus;
      component.FlatBonus = flatBonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildingPartOfQuestObjective"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buildings"><see cref="Kingmaker.Kingdom.Settlements.BlueprintSettlementBuilding"/></param>
    /// <param name="objective"><see cref="Kingmaker.Blueprints.Quests.BlueprintQuestObjective"/></param>
    [Generated]
    [Implements(typeof(BuildingPartOfQuestObjective))]
    public SettlementBuildingConfigurator AddBuildingPartOfQuestObjective(
        string[]? buildings = null,
        string? objective = null)
    {
      var component = new BuildingPartOfQuestObjective();
      component.m_Buildings = buildings.Select(name => BlueprintTool.GetRef<BlueprintSettlementBuildingReference>(name)).ToArray();
      component.m_Objective = BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(objective);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildingResourceGrowthGlobalIncrease"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuildingResourceGrowthGlobalIncrease))]
    public SettlementBuildingConfigurator AddBuildingResourceGrowthGlobalIncrease(
        int modifier = default,
        int financeModifier = default,
        int basicsModifier = default,
        int favorsModifier = default)
    {
      var component = new BuildingResourceGrowthGlobalIncrease();
      component.Modifier = modifier;
      component.FinanceModifier = financeModifier;
      component.BasicsModifier = basicsModifier;
      component.FavorsModifier = favorsModifier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildingResourceGrowthIncrease"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuildingResourceGrowthIncrease))]
    public SettlementBuildingConfigurator AddBuildingResourceGrowthIncrease(
        KingdomResourcesAmount resourcesAmount)
    {
      var component = new BuildingResourceGrowthIncrease();
      component.ResourcesAmount = resourcesAmount;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildingSiegeDurationIncrease"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="affectedFlags"><see cref="Kingmaker.Kingdom.Flags.BlueprintKingdomMoraleFlag"/></param>
    [Generated]
    [Implements(typeof(BuildingSiegeDurationIncrease))]
    public SettlementBuildingConfigurator AddBuildingSiegeDurationIncrease(
        int durationDeltaInDays = default,
        string[]? affectedFlags = null)
    {
      var component = new BuildingSiegeDurationIncrease();
      component.DurationDeltaInDays = durationDeltaInDays;
      component.m_AffectedFlags = affectedFlags.Select(name => BlueprintTool.GetRef<BlueprintKingdomMoraleFlag.Reference>(name)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildingTacticalUnitFactBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="features"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(BuildingTacticalUnitFactBonus))]
    public SettlementBuildingConfigurator AddBuildingTacticalUnitFactBonus(
        BuildingTacticalUnitFactBonus.DistanceType distance = default,
        string[]? features = null,
        bool onlyForCurrentRegion = default)
    {
      var component = new BuildingTacticalUnitFactBonus();
      component.m_Distance = distance;
      component.m_Features = features.Select(name => BlueprintTool.GetRef<BlueprintFeatureReference>(name)).ToArray();
      component.m_OnlyForCurrentRegion = onlyForCurrentRegion;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildingUnitGrowthIncrease"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="unit"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(BuildingUnitGrowthIncrease))]
    public SettlementBuildingConfigurator AddBuildingUnitGrowthIncrease(
        string? unit = null,
        int count = default)
    {
      var component = new BuildingUnitGrowthIncrease();
      component.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(unit);
      component.Count = count;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildingUpgradeBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="upgradeProject"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomUpgrade"/></param>
    [Generated]
    [Implements(typeof(BuildingUpgradeBonus))]
    public SettlementBuildingConfigurator AddBuildingUpgradeBonus(
        KingdomStats.Changes stats,
        string? upgradeProject = null,
        BuildingUpgradeBonus.RegionApplicabilityType region = default)
    {
      ValidateParam(stats);
    
      var component = new BuildingUpgradeBonus();
      component.Stats = stats;
      component.m_UpgradeProject = BlueprintTool.GetRef<BlueprintKingdomUpgradeReference>(upgradeProject);
      component.Region = region;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CaptalLevelRestriction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="settlement"><see cref="Kingmaker.Kingdom.BlueprintSettlement"/></param>
    [Generated]
    [Implements(typeof(CaptalLevelRestriction))]
    public SettlementBuildingConfigurator AddCaptalLevelRestriction(
        string? settlement = null,
        SettlementState.LevelType level = default)
    {
      var component = new CaptalLevelRestriction();
      component.m_Settlement = BlueprintTool.GetRef<BlueprintSettlement.Reference>(settlement);
      component.Level = level;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DLCRestriction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="dlcReward"><see cref="Kingmaker.DLC.BlueprintDlcReward"/></param>
    [Generated]
    [Implements(typeof(DLCRestriction))]
    public SettlementBuildingConfigurator AddDLCRestriction(
        string? dlcReward = null)
    {
      var component = new DLCRestriction();
      component.m_DlcReward = BlueprintTool.GetRef<BlueprintDlcRewardReference>(dlcReward);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LoneSlotRestriction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LoneSlotRestriction))]
    public SettlementBuildingConfigurator AddLoneSlotRestriction()
    {
      return AddComponent(new LoneSlotRestriction());
    }

    /// <summary>
    /// Adds <see cref="OncePerSettlementRestriction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(OncePerSettlementRestriction))]
    public SettlementBuildingConfigurator AddOncePerSettlementRestriction()
    {
      return AddComponent(new OncePerSettlementRestriction());
    }

    /// <summary>
    /// Adds <see cref="OtherBuildingRestriction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buildings"><see cref="Kingmaker.Kingdom.Settlements.BlueprintSettlementBuilding"/></param>
    [Generated]
    [Implements(typeof(OtherBuildingRestriction))]
    public SettlementBuildingConfigurator AddOtherBuildingRestriction(
        bool invert = default,
        bool requireAll = default,
        string[]? buildings = null)
    {
      var component = new OtherBuildingRestriction();
      component.Invert = invert;
      component.RequireAll = requireAll;
      component.Buildings = buildings.Select(name => BlueprintTool.GetRef<BlueprintSettlementBuildingReference>(name)).ToList();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ProjectRestriction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="projects"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomProject"/></param>
    [Generated]
    [Implements(typeof(ProjectRestriction))]
    public SettlementBuildingConfigurator AddProjectRestriction(
        string[]? projects = null)
    {
      var component = new ProjectRestriction();
      component.m_Projects = projects.Select(name => BlueprintTool.GetRef<BlueprintKingdomProjectReference>(name)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpecificSettlementRestriction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="settlement"><see cref="Kingmaker.Kingdom.BlueprintSettlement"/></param>
    [Generated]
    [Implements(typeof(SpecificSettlementRestriction))]
    public SettlementBuildingConfigurator AddSpecificSettlementRestriction(
        string? settlement = null,
        bool not = default)
    {
      var component = new SpecificSettlementRestriction();
      component.m_Settlement = BlueprintTool.GetRef<BlueprintSettlement.Reference>(settlement);
      component.m_Not = not;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="StatRankRestriction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(StatRankRestriction))]
    public SettlementBuildingConfigurator AddStatRankRestriction(
        KingdomStats.Type stat = default,
        int rank = default,
        bool atMost = default)
    {
      var component = new StatRankRestriction();
      component.Stat = stat;
      component.Rank = rank;
      component.AtMost = atMost;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TeleportationCircle"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TeleportationCircle))]
    public SettlementBuildingConfigurator AddTeleportationCircle(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TeleportationCircle();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="UnlockRestriction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="flag"><see cref="Kingmaker.Blueprints.BlueprintUnlockableFlag"/></param>
    [Generated]
    [Implements(typeof(UnlockRestriction))]
    public SettlementBuildingConfigurator AddUnlockRestriction(
        string? flag = null,
        bool mustBeLocked = default)
    {
      var component = new UnlockRestriction();
      component.m_Flag = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(flag);
      component.MustBeLocked = mustBeLocked;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BirthdayTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BirthdayTrigger))]
    public SettlementBuildingConfigurator AddBirthdayTrigger(
        ConditionsBuilder? condition = null,
        ActionsBuilder? actions = null)
    {
      var component = new BirthdayTrigger();
      component.Condition = condition?.Build() ?? Constants.Empty.Conditions;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EventResolutonTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="onlySpecificLeader"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(EventResolutonTrigger))]
    public SettlementBuildingConfigurator AddEventResolutonTrigger(
        BlueprintKingdomEvent.TagList requiredTags,
        bool applyToProblems = default,
        bool applyToOpportunities = default,
        bool onlyInRegion = default,
        EventResult.MarginType onMargin = default,
        LeaderType onlyLeader = default,
        string? onlySpecificLeader = null,
        ConditionsBuilder? condition = null,
        ActionsBuilder? action = null)
    {
      ValidateParam(requiredTags);
    
      var component = new EventResolutonTrigger();
      component.ApplyToProblems = applyToProblems;
      component.ApplyToOpportunities = applyToOpportunities;
      component.OnlyInRegion = onlyInRegion;
      component.OnMargin = onMargin;
      component.RequiredTags = requiredTags;
      component.OnlyLeader = onlyLeader;
      component.m_OnlySpecificLeader = BlueprintTool.GetRef<BlueprintUnitReference>(onlySpecificLeader);
      component.Condition = condition?.Build() ?? Constants.Empty.Conditions;
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EventStartTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EventStartTrigger))]
    public SettlementBuildingConfigurator AddEventStartTrigger(
        BlueprintKingdomEvent.TagList requiredTags,
        bool applyToProblems = default,
        bool applyToOpportunities = default,
        ConditionsBuilder? condition = null,
        ActionsBuilder? action = null)
    {
      ValidateParam(requiredTags);
    
      var component = new EventStartTrigger();
      component.ApplyToProblems = applyToProblems;
      component.ApplyToOpportunities = applyToOpportunities;
      component.RequiredTags = requiredTags;
      component.Condition = condition?.Build() ?? Constants.Empty.Conditions;
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EveryDayTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EveryDayTrigger))]
    public SettlementBuildingConfigurator AddEveryDayTrigger(
        ConditionsBuilder? condition = null,
        ActionsBuilder? actions = null,
        int skipDays = default)
    {
      var component = new EveryDayTrigger();
      component.Condition = condition?.Build() ?? Constants.Empty.Conditions;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.SkipDays = skipDays;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EveryWeekTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EveryWeekTrigger))]
    public SettlementBuildingConfigurator AddEveryWeekTrigger(
        ConditionsBuilder? condition = null,
        ActionsBuilder? actions = null,
        int skipWeeks = default)
    {
      var component = new EveryWeekTrigger();
      component.Condition = condition?.Build() ?? Constants.Empty.Conditions;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.SkipWeeks = skipWeeks;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KingdomAddMercenaryReroll"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomAddMercenaryReroll))]
    public SettlementBuildingConfigurator AddKingdomAddMercenaryReroll(
        int freeRerollsToAdd = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new KingdomAddMercenaryReroll();
      component.m_FreeRerollsToAdd = freeRerollsToAdd;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="KingdomAddMercenarySlot"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomAddMercenarySlot))]
    public SettlementBuildingConfigurator AddKingdomAddMercenarySlot(
        int slotsToAdd = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new KingdomAddMercenarySlot();
      component.m_SlotsToAdd = slotsToAdd;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="KingdomConditionalStatChange"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomConditionalStatChange))]
    public SettlementBuildingConfigurator AddKingdomConditionalStatChange(
        KingdomStats.Changes stats,
        ConditionsBuilder? condition = null)
    {
      ValidateParam(stats);
    
      var component = new KingdomConditionalStatChange();
      component.Condition = condition?.Build() ?? Constants.Empty.Conditions;
      component.Stats = stats;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KingdomEventFixedBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomEventFixedBonus))]
    public SettlementBuildingConfigurator AddKingdomEventFixedBonus(
        LeaderType leader = default,
        int leaderBonus = default)
    {
      var component = new KingdomEventFixedBonus();
      component.Leader = leader;
      component.LeaderBonus = leaderBonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KingdomEventModifier"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="onlySpecificLeader"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(KingdomEventModifier))]
    public SettlementBuildingConfigurator AddKingdomEventModifier(
        BlueprintKingdomEvent.TagList requiredTags,
        DiceFormula dice,
        bool applyToProblems = default,
        bool applyToOpportunities = default,
        bool onlyInRegion = default,
        bool includeAdjacent = default,
        LeaderType onlyLeader = default,
        string? onlySpecificLeader = null,
        ConditionsBuilder? condition = null,
        bool isRoll = default,
        int value = default,
        bool onlyPositive = default,
        bool onlyNegative = default,
        bool addReroll = default,
        bool addDisadvantage = default)
    {
      ValidateParam(requiredTags);
    
      var component = new KingdomEventModifier();
      component.ApplyToProblems = applyToProblems;
      component.ApplyToOpportunities = applyToOpportunities;
      component.OnlyInRegion = onlyInRegion;
      component.IncludeAdjacent = includeAdjacent;
      component.RequiredTags = requiredTags;
      component.OnlyLeader = onlyLeader;
      component.m_OnlySpecificLeader = BlueprintTool.GetRef<BlueprintUnitReference>(onlySpecificLeader);
      component.Condition = condition?.Build() ?? Constants.Empty.Conditions;
      component.IsRoll = isRoll;
      component.Value = value;
      component.Dice = dice;
      component.OnlyPositive = onlyPositive;
      component.OnlyNegative = onlyNegative;
      component.AddReroll = addReroll;
      component.AddDisadvantage = addDisadvantage;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KingdomUnrestChangeTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomUnrestChangeTrigger))]
    public SettlementBuildingConfigurator AddKingdomUnrestChangeTrigger(
        ConditionsBuilder? condition = null,
        ActionsBuilder? action = null)
    {
      var component = new KingdomUnrestChangeTrigger();
      component.Condition = condition?.Build() ?? Constants.Empty.Conditions;
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }
  }
}
