using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Armies;
using Kingmaker.Armies.Components;
using Kingmaker.Blueprints;
using Kingmaker.Crusade.GlobalMagic;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.Armies;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Kingdom.Buffs;
using Kingmaker.Kingdom.Settlements.BuildingComponents;
using Kingmaker.Localization;
using Kingmaker.RuleSystem;
using System;
using System.Linq;
using UnityEngine;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>
  /// Configurator for <see cref="BlueprintKingdomBuff"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintKingdomBuff))]
  public class KingdomBuffConfigurator : BaseFactConfigurator<BlueprintKingdomBuff, KingdomBuffConfigurator>
  {
    private KingdomBuffConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static KingdomBuffConfigurator For(string name)
    {
      return new KingdomBuffConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static KingdomBuffConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintKingdomBuff>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomBuff.DisplayName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomBuffConfigurator SetDisplayName(LocalizedString? displayName)
    {
      ValidateParam(displayName);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.DisplayName = displayName ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomBuff.Description"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomBuffConfigurator SetDescription(LocalizedString? description)
    {
      ValidateParam(description);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Description = description ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomBuff.Icon"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomBuffConfigurator SetIcon(Sprite icon)
    {
      ValidateParam(icon);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Icon = icon;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomBuff.DurationDays"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomBuffConfigurator SetDurationDays(int durationDays)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DurationDays = durationDays;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomBuff.StatChanges"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomBuffConfigurator SetStatChanges(KingdomStats.Changes statChanges)
    {
      ValidateParam(statChanges);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.StatChanges = statChanges;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomBuff.OnApply"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomBuffConfigurator SetOnApply(ActionsBuilder? onApply)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.OnApply = onApply?.Build() ?? Constants.Empty.Actions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomBuff.OnRemove"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomBuffConfigurator SetOnRemove(ActionsBuilder? onRemove)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.OnRemove = onRemove?.Build() ?? Constants.Empty.Actions;
          });
    }

    /// <summary>
    /// Adds <see cref="ChangeGlobalMagicPower"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ChangeGlobalMagicPower))]
    public KingdomBuffConfigurator AddChangeGlobalMagicPower(
        GlobalMagicValue changeValue,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(changeValue);
    
      var component = new ChangeGlobalMagicPower();
      component.m_ChangeValue = changeValue;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="KingdomUnitsGrowthIncrease"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="units"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(KingdomUnitsGrowthIncrease))]
    public KingdomBuffConfigurator AddKingdomUnitsGrowthIncrease(
        bool allUnits = default,
        ArmyProperties properties = default,
        KingdomUnitsGrowthIncrease.UnitListOperation operation = default,
        string[]? units = null,
        int bonusPercent = default)
    {
      var component = new KingdomUnitsGrowthIncrease();
      component.AllUnits = allUnits;
      component.Properties = properties;
      component.Operation = operation;
      component.Units = units.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name)).ToList();
      component.BonusPercent = bonusPercent;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BirthdayTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BirthdayTrigger))]
    public KingdomBuffConfigurator AddBirthdayTrigger(
        ConditionsBuilder? condition = null,
        ActionsBuilder? actions = null)
    {
      var component = new BirthdayTrigger();
      component.Condition = condition?.Build() ?? Constants.Empty.Conditions;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildingCostModifier"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buildings"><see cref="Kingmaker.Kingdom.Settlements.BlueprintSettlementBuilding"/></param>
    [Generated]
    [Implements(typeof(BuildingCostModifier))]
    public KingdomBuffConfigurator AddBuildingCostModifier(
        float modifier = default,
        string[]? buildings = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new BuildingCostModifier();
      component.Modifier = modifier;
      component.Buildings = buildings.Select(name => BlueprintTool.GetRef<BlueprintSettlementBuildingReference>(name)).ToList();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="BuildingSequenceCostMultiplierReduce"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buildings"><see cref="Kingmaker.Kingdom.Settlements.BlueprintSettlementBuilding"/></param>
    [Generated]
    [Implements(typeof(BuildingSequenceCostMultiplierReduce))]
    public KingdomBuffConfigurator AddBuildingSequenceCostMultiplierReduce(
        float reduceMultiplierBy = default,
        string[]? buildings = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new BuildingSequenceCostMultiplierReduce();
      component.ReduceMultiplierBy = reduceMultiplierBy;
      component.Buildings = buildings.Select(name => BlueprintTool.GetRef<BlueprintSettlementBuildingReference>(name)).ToList();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="BuildingTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="specificSettlement"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintRegion"/></param>
    /// <param name="specificBuilding"><see cref="Kingmaker.Kingdom.Settlements.BlueprintSettlementBuilding"/></param>
    [Generated]
    [Implements(typeof(BuildingTrigger))]
    public KingdomBuffConfigurator AddBuildingTrigger(
        string? specificSettlement = null,
        string? specificBuilding = null,
        int atLeastThisManyBuildings = default,
        ConditionsBuilder? condition = null,
        ActionsBuilder? actions = null)
    {
      var component = new BuildingTrigger();
      component.m_SpecificSettlement = BlueprintTool.GetRef<BlueprintRegionReference>(specificSettlement);
      component.m_SpecificBuilding = BlueprintTool.GetRef<BlueprintSettlementBuildingReference>(specificBuilding);
      component.AtLeastThisManyBuildings = atLeastThisManyBuildings;
      component.Condition = condition?.Build() ?? Constants.Empty.Conditions;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ChangeKingdomMoraleMinimum"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ChangeKingdomMoraleMinimum))]
    public KingdomBuffConfigurator AddChangeKingdomMoraleMinimum(
        int minValueDelta = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ChangeKingdomMoraleMinimum();
      component.m_MinValueDelta = minValueDelta;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="EventResolutonTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="onlySpecificLeader"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(EventResolutonTrigger))]
    public KingdomBuffConfigurator AddEventResolutonTrigger(
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
    public KingdomBuffConfigurator AddEventStartTrigger(
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
    public KingdomBuffConfigurator AddEveryDayTrigger(
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
    public KingdomBuffConfigurator AddEveryWeekTrigger(
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
    /// Adds <see cref="GlobalArmiesMoraleModifier"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(GlobalArmiesMoraleModifier))]
    public KingdomBuffConfigurator AddGlobalArmiesMoraleModifier(
        ArmyFaction faction = default,
        int moraleModifier = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new GlobalArmiesMoraleModifier();
      component.m_Faction = faction;
      component.m_MoraleModifier = moraleModifier;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="KingdomAddMercenaryReroll"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomAddMercenaryReroll))]
    public KingdomBuffConfigurator AddKingdomAddMercenaryReroll(
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
    public KingdomBuffConfigurator AddKingdomAddMercenarySlot(
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
    public KingdomBuffConfigurator AddKingdomConditionalStatChange(
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
    public KingdomBuffConfigurator AddKingdomEventFixedBonus(
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
    public KingdomBuffConfigurator AddKingdomEventModifier(
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
    /// Adds <see cref="KingdomIncomeModifier"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomIncomeModifier))]
    public KingdomBuffConfigurator AddKingdomIncomeModifier(
        int modifier = default,
        int financeModifier = default,
        int basicsModifier = default,
        int favorsModifier = default)
    {
      var component = new KingdomIncomeModifier();
      component.Modifier = modifier;
      component.FinanceModifier = financeModifier;
      component.BasicsModifier = basicsModifier;
      component.FavorsModifier = favorsModifier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KingdomIncomePerSettlement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomIncomePerSettlement))]
    public KingdomBuffConfigurator AddKingdomIncomePerSettlement(
        KingdomResourcesAmount resourcesPerVillage,
        KingdomResourcesAmount resourcesPerTown,
        KingdomResourcesAmount resourcesPerCity)
    {
      var component = new KingdomIncomePerSettlement();
      component.ResourcesPerVillage = resourcesPerVillage;
      component.ResourcesPerTown = resourcesPerTown;
      component.ResourcesPerCity = resourcesPerCity;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KingdomIncomePerStat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomIncomePerStat))]
    public KingdomBuffConfigurator AddKingdomIncomePerStat(
        KingdomResourcesAmount resourcesPerRank,
        KingdomStats.Type stat = default)
    {
      var component = new KingdomIncomePerStat();
      component.ResourcesPerRank = resourcesPerRank;
      component.Stat = stat;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KingdomIncomePerUnrest"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomIncomePerUnrest))]
    public KingdomBuffConfigurator AddKingdomIncomePerUnrest(
        KingdomResourcesAmount resourcesPerUnrest)
    {
      var component = new KingdomIncomePerUnrest();
      component.ResourcesPerUnrest = resourcesPerUnrest;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KingdomMoraleEffectMultiplier"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomMoraleEffectMultiplier))]
    public KingdomBuffConfigurator AddKingdomMoraleEffectMultiplier(
        float incomeMultiplier = default,
        float unitMultiplier = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new KingdomMoraleEffectMultiplier();
      component.IncomeMultiplier = incomeMultiplier;
      component.UnitMultiplier = unitMultiplier;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="KingdomMoraleForArmies"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomMoraleForArmies))]
    public KingdomBuffConfigurator AddKingdomMoraleForArmies(
        ArmyFaction faction = default,
        float multiplier = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new KingdomMoraleForArmies();
      component.m_Faction = faction;
      component.m_Multiplier = multiplier;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="KingdomTacticalArmyFeature"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="armyUnits"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    /// <param name="features"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(KingdomTacticalArmyFeature))]
    public KingdomBuffConfigurator AddKingdomTacticalArmyFeature(
        MercenariesIncludeOption mercenariesFilter = default,
        bool byTag = default,
        ArmyProperties armyTag = default,
        bool byUnits = default,
        string[]? armyUnits = null,
        string[]? features = null,
        ArmyFaction faction = default)
    {
      var component = new KingdomTacticalArmyFeature();
      component.m_MercenariesFilter = mercenariesFilter;
      component.m_ByTag = byTag;
      component.m_ArmyTag = armyTag;
      component.m_ByUnits = byUnits;
      component.m_ArmyUnits = armyUnits.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name)).ToArray();
      component.m_Features = features.Select(name => BlueprintTool.GetRef<BlueprintFeatureReference>(name)).ToArray();
      component.m_Faction = faction;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KingdomUnrestChangeTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomUnrestChangeTrigger))]
    public KingdomBuffConfigurator AddKingdomUnrestChangeTrigger(
        ConditionsBuilder? condition = null,
        ActionsBuilder? action = null)
    {
      var component = new KingdomUnrestChangeTrigger();
      component.Condition = condition?.Build() ?? Constants.Empty.Conditions;
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MaxArmySquadsBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MaxArmySquadsBonus))]
    public KingdomBuffConfigurator AddMaxArmySquadsBonus(
        int bonus = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new MaxArmySquadsBonus();
      component.m_Bonus = bonus;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="RecruitCostModifier"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="units"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(RecruitCostModifier))]
    public KingdomBuffConfigurator AddRecruitCostModifier(
        float modifier = default,
        bool allUnits = default,
        MercenariesIncludeOption mercenariesFilter = default,
        ArmyProperties properties = default,
        KingdomUnitsGrowthIncrease.UnitListOperation operation = default,
        string[]? units = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new RecruitCostModifier();
      component.Modifier = modifier;
      component.AllUnits = allUnits;
      component.MercenariesFilter = mercenariesFilter;
      component.Properties = properties;
      component.Operation = operation;
      component.Units = units.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name)).ToList();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="RecruitDisable"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RecruitDisable))]
    public KingdomBuffConfigurator AddRecruitDisable(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new RecruitDisable();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="RegionBasedPartyBuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(RegionBasedPartyBuff))]
    public KingdomBuffConfigurator AddRegionBasedPartyBuff(
        RegionBasedPartyBuff.TargetType target = default,
        string? buff = null)
    {
      var component = new RegionBasedPartyBuff();
      component.Target = target;
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SettlementTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="specificSettlement"><see cref="Kingmaker.Kingdom.BlueprintSettlement"/></param>
    [Generated]
    [Implements(typeof(SettlementTrigger))]
    public KingdomBuffConfigurator AddSettlementTrigger(
        string? specificSettlement = null,
        ConditionsBuilder? condition = null,
        ActionsBuilder? actions = null)
    {
      var component = new SettlementTrigger();
      component.m_SpecificSettlement = BlueprintTool.GetRef<BlueprintSettlement.Reference>(specificSettlement);
      component.Condition = condition?.Build() ?? Constants.Empty.Conditions;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KingdomStatFromCrusadeResources"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomStatFromCrusadeResources))]
    public KingdomBuffConfigurator AddKingdomStatFromCrusadeResources(
        KingdomStats.Type stat = default,
        float statPerFinances = default,
        float statPerMaterials = default,
        float statPerFavors = default)
    {
      var component = new KingdomStatFromCrusadeResources();
      component.m_Stat = stat;
      component.m_StatPerFinances = statPerFinances;
      component.m_StatPerMaterials = statPerMaterials;
      component.m_StatPerFavors = statPerFavors;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KingdomStatFromLeaderExperience"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomStatFromLeaderExperience))]
    public KingdomBuffConfigurator AddKingdomStatFromLeaderExperience(
        KingdomStats.Type stat = default,
        float statPerLeaderExperience = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new KingdomStatFromLeaderExperience();
      component.m_Stat = stat;
      component.m_StatPerLeaderExperience = statPerLeaderExperience;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="KingdomStatFromRecruitment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KingdomStatFromRecruitment))]
    public KingdomBuffConfigurator AddKingdomStatFromRecruitment(
        KingdomStats.Type stat = default,
        float statPerExp = default)
    {
      var component = new KingdomStatFromRecruitment();
      component.m_Stat = stat;
      component.m_StatPerExp = statPerExp;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KingdomGainSkillToLeaders"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="skill"><see cref="Kingmaker.Armies.Blueprints.BlueprintLeaderSkill"/></param>
    /// <param name="skillsList"><see cref="Kingmaker.Armies.Blueprints.BlueprintLeaderSkill"/></param>
    [Generated]
    [Implements(typeof(KingdomGainSkillToLeaders))]
    public KingdomBuffConfigurator AddKingdomGainSkillToLeaders(
        ArmyFaction targetFactions = default,
        int minLevel = default,
        string? skill = null,
        bool useSkillsList = default,
        string[]? skillsList = null)
    {
      var component = new KingdomGainSkillToLeaders();
      component.m_TargetFactions = targetFactions;
      component.m_MinLevel = minLevel;
      component.m_Skill = BlueprintTool.GetRef<BlueprintLeaderSkillReference>(skill);
      component.m_UseSkillsList = useSkillsList;
      component.m_SkillsList = skillsList.Select(name => BlueprintTool.GetRef<BlueprintLeaderSkillReference>(name)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyGlobalMapMovementBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmyGlobalMapMovementBonus))]
    public KingdomBuffConfigurator AddArmyGlobalMapMovementBonus(
        int dailyMovementPoints = default,
        int maxMovementPoints = default)
    {
      var component = new ArmyGlobalMapMovementBonus();
      component.DailyMovementPoints = dailyMovementPoints;
      component.MaxMovementPoints = maxMovementPoints;
      return AddComponent(component);
    }
  }
}
