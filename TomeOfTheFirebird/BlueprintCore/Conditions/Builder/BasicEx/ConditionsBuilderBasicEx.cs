using BlueprintCore.Utils;
using Kingmaker.Assets.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.Blueprints;
using Kingmaker.Designers;
using Kingmaker.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.Designers.EventConditionActionSystem.NamedParameters;
using Kingmaker.ElementsSystem;
using Kingmaker.UnitLogic.Buffs.Conditions;
#nullable enable
namespace BlueprintCore.Conditions.Builder.BasicEx
{
  /// <summary>
  /// Extension to <see cref="ConditionsBuilder"/> for most game mechanics related conditions not included in
  /// <see cref="ContextEx.ConditionsBuilderContextEx">ContextEx</see>.
  /// </summary>
  /// <inheritdoc cref="ConditionsBuilder"/>
  public static class ConditionsBuilderBasicEx
  {
    //----- Auto Generated -----//

    /// <summary>
    /// Adds <see cref="DualCompanionInactive"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DualCompanionInactive))]
    public static ConditionsBuilder DualCompanionInactive(
        this ConditionsBuilder builder,
        UnitEvaluator unit,
        bool negate = false)
    {
      builder.Validate(unit);
    
      var element = ElementTool.Create<DualCompanionInactive>();
      element.Unit = unit;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="BuffConditionCheckRoundNumber"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffConditionCheckRoundNumber))]
    public static ConditionsBuilder BuffConditionCheckRoundNumber(
        this ConditionsBuilder builder,
        int roundNumber = default,
        bool negate = false)
    {
      var element = ElementTool.Create<BuffConditionCheckRoundNumber>();
      element.RoundNumber = roundNumber;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CheckConditionsHolder"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="conditionsHolder"><see cref="Kingmaker.ElementsSystem.ConditionsHolder"/></param>
    [Generated]
    [Implements(typeof(CheckConditionsHolder))]
    public static ConditionsBuilder CheckConditionsHolder(
        this ConditionsBuilder builder,
        ParametrizedContextSetter parameters,
        string? conditionsHolder = null,
        bool negate = false)
    {
      builder.Validate(parameters);
    
      var element = ElementTool.Create<CheckConditionsHolder>();
      element.ConditionsHolder = BlueprintTool.GetRef<ConditionsReference>(conditionsHolder);
      element.Parameters = parameters;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CheckItemCondition"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="targetItem"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    [Implements(typeof(CheckItemCondition))]
    public static ConditionsBuilder CheckItemCondition(
        this ConditionsBuilder builder,
        UnitEvaluator unitEvaluator,
        string? targetItem = null,
        CheckItemCondition.RequiredState requiredState = default,
        bool negate = false)
    {
      builder.Validate(unitEvaluator);
    
      var element = ElementTool.Create<CheckItemCondition>();
      element.m_TargetItem = BlueprintTool.GetRef<BlueprintItemReference>(targetItem);
      element.m_RequiredState = requiredState;
      element.m_UnitEvaluator = unitEvaluator;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CompanionInParty"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="companion"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(CompanionInParty))]
    public static ConditionsBuilder CompanionInParty(
        this ConditionsBuilder builder,
        string? companion = null,
        bool matchWhenActive = default,
        bool matchWhenDetached = default,
        bool matchWhenRemote = default,
        bool matchWhenDead = default,
        bool matchWhenEx = default,
        bool negate = false)
    {
      var element = ElementTool.Create<CompanionInParty>();
      element.m_companion = BlueprintTool.GetRef<BlueprintUnitReference>(companion);
      element.MatchWhenActive = matchWhenActive;
      element.MatchWhenDetached = matchWhenDetached;
      element.MatchWhenRemote = matchWhenRemote;
      element.MatchWhenDead = matchWhenDead;
      element.MatchWhenEx = matchWhenEx;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CompanionIsDead"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="companion"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(CompanionIsDead))]
    public static ConditionsBuilder CompanionIsDead(
        this ConditionsBuilder builder,
        string? companion = null,
        bool anyCompanion = default,
        bool negate = false)
    {
      var element = ElementTool.Create<CompanionIsDead>();
      element.m_companion = BlueprintTool.GetRef<BlueprintUnitReference>(companion);
      element.anyCompanion = anyCompanion;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CompanionIsLost"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="companion"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(CompanionIsLost))]
    public static ConditionsBuilder CompanionIsLost(
        this ConditionsBuilder builder,
        string? companion = null,
        bool negate = false)
    {
      var element = ElementTool.Create<CompanionIsLost>();
      element.m_Companion = BlueprintTool.GetRef<BlueprintUnitReference>(companion);
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CompanionIsUnconscious"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="companion"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(CompanionIsUnconscious))]
    public static ConditionsBuilder CompanionIsUnconscious(
        this ConditionsBuilder builder,
        string? companion = null,
        bool anyCompanion = default,
        bool negate = false)
    {
      var element = ElementTool.Create<CompanionIsUnconscious>();
      element.companion = BlueprintTool.GetRef<BlueprintUnitReference>(companion);
      element.anyCompanion = anyCompanion;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CheckLos"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CheckLos))]
    public static ConditionsBuilder CheckLos(
        this ConditionsBuilder builder,
        PositionEvaluator point1,
        PositionEvaluator point2,
        bool negate = false)
    {
      builder.Validate(point1);
      builder.Validate(point2);
    
      var element = ElementTool.Create<CheckLos>();
      element.Point1 = point1;
      element.Point2 = point2;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="HasBuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(HasBuff))]
    public static ConditionsBuilder HasBuff(
        this ConditionsBuilder builder,
        UnitEvaluator target,
        string? buff = null,
        bool negate = false)
    {
      builder.Validate(target);
    
      var element = ElementTool.Create<HasBuff>();
      element.Target = target;
      element.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="HasFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="fact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(HasFact))]
    public static ConditionsBuilder HasFact(
        this ConditionsBuilder builder,
        UnitEvaluator unit,
        string? fact = null,
        bool negate = false)
    {
      builder.Validate(unit);
    
      var element = ElementTool.Create<HasFact>();
      element.Unit = unit;
      element.m_Fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(fact);
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsEnemy"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IsEnemy))]
    public static ConditionsBuilder IsEnemy(
        this ConditionsBuilder builder,
        UnitEvaluator firstUnit,
        UnitEvaluator secondUnit,
        bool negate = false)
    {
      builder.Validate(firstUnit);
      builder.Validate(secondUnit);
    
      var element = ElementTool.Create<IsEnemy>();
      element.FirstUnit = firstUnit;
      element.SecondUnit = secondUnit;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsInCombat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IsInCombat))]
    public static ConditionsBuilder IsInCombat(
        this ConditionsBuilder builder,
        UnitEvaluator unit,
        bool player = default,
        bool negate = false)
    {
      builder.Validate(unit);
    
      var element = ElementTool.Create<IsInCombat>();
      element.Unit = unit;
      element.Player = player;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsInTurnBasedCombat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IsInTurnBasedCombat))]
    public static ConditionsBuilder IsInTurnBasedCombat(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<IsInTurnBasedCombat>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsPartyMember"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IsPartyMember))]
    public static ConditionsBuilder IsPartyMember(
        this ConditionsBuilder builder,
        UnitEvaluator unit,
        bool negate = false)
    {
      builder.Validate(unit);
    
      var element = ElementTool.Create<IsPartyMember>();
      element.Unit = unit;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsUnconscious"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IsUnconscious))]
    public static ConditionsBuilder IsUnconscious(
        this ConditionsBuilder builder,
        UnitEvaluator unit,
        bool negate = false)
    {
      builder.Validate(unit);
    
      var element = ElementTool.Create<IsUnconscious>();
      element.Unit = unit;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsUnitLevelLessThan"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IsUnitLevelLessThan))]
    public static ConditionsBuilder IsUnitLevelLessThan(
        this ConditionsBuilder builder,
        UnitEvaluator unit,
        int level = default,
        bool checkExperience = default,
        bool negate = false)
    {
      builder.Validate(unit);
    
      var element = ElementTool.Create<IsUnitLevelLessThan>();
      element.Unit = unit;
      element.Level = level;
      element.CheckExperience = checkExperience;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ItemBlueprint"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="blueprint"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    [Implements(typeof(ItemBlueprint))]
    public static ConditionsBuilder ItemBlueprint(
        this ConditionsBuilder builder,
        ItemEvaluator item,
        string? blueprint = null,
        bool negate = false)
    {
      builder.Validate(item);
    
      var element = ElementTool.Create<ItemBlueprint>();
      element.Item = item;
      element.Blueprint = BlueprintTool.GetRef<BlueprintItemReference>(blueprint);
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ItemFromCollectionCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ItemFromCollectionCondition))]
    public static ConditionsBuilder ItemFromCollectionCondition(
        this ConditionsBuilder builder,
        ItemsCollectionEvaluator items,
        bool any = default,
        ConditionsBuilder? condition = null,
        bool negate = false)
    {
      builder.Validate(items);
    
      var element = ElementTool.Create<ItemFromCollectionCondition>();
      element.Items = items;
      element.Any = any;
      element.Condition = condition?.Build() ?? Constants.Empty.Conditions;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ItemsEnough"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="itemToCheck"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    [Implements(typeof(ItemsEnough))]
    public static ConditionsBuilder ItemsEnough(
        this ConditionsBuilder builder,
        bool money = default,
        string? itemToCheck = null,
        int quantity = default,
        bool negate = false)
    {
      var element = ElementTool.Create<ItemsEnough>();
      element.Money = money;
      element.m_ItemToCheck = BlueprintTool.GetRef<BlueprintItemReference>(itemToCheck);
      element.Quantity = quantity;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PartyCanUseAbility"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PartyCanUseAbility))]
    public static ConditionsBuilder PartyCanUseAbility(
        this ConditionsBuilder builder,
        AbilitiesHelper.AbilityDescription description,
        bool allowItems = default,
        bool negate = false)
    {
      builder.Validate(description);
    
      var element = ElementTool.Create<PartyCanUseAbility>();
      element.Description = description;
      element.AllowItems = allowItems;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PartyUnits"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PartyUnits))]
    public static ConditionsBuilder PartyUnits(
        this ConditionsBuilder builder,
        bool any = default,
        ConditionsBuilder? conditions = null,
        bool negate = false)
    {
      var element = ElementTool.Create<PartyUnits>();
      element.Any = any;
      element.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PcFemale"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PcFemale))]
    public static ConditionsBuilder PcFemale(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<PcFemale>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PcMale"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PcMale))]
    public static ConditionsBuilder PcMale(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<PcMale>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PcRace"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PcRace))]
    public static ConditionsBuilder PcRace(
        this ConditionsBuilder builder,
        Race race = default,
        bool negate = false)
    {
      var element = ElementTool.Create<PcRace>();
      element.Race = race;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SummonPoolExistsAndEmpty"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="summonPool"><see cref="Kingmaker.Blueprints.BlueprintSummonPool"/></param>
    [Generated]
    [Implements(typeof(SummonPoolExistsAndEmpty))]
    public static ConditionsBuilder SummonPoolExistsAndEmpty(
        this ConditionsBuilder builder,
        string? summonPool = null,
        bool negate = false)
    {
      var element = ElementTool.Create<SummonPoolExistsAndEmpty>();
      element.m_SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(summonPool);
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnitIsDead"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UnitIsDead))]
    public static ConditionsBuilder UnitIsDead(
        this ConditionsBuilder builder,
        UnitEvaluator target,
        bool negate = false)
    {
      builder.Validate(target);
    
      var element = ElementTool.Create<UnitIsDead>();
      element.Target = target;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnitIsHidden"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UnitIsHidden))]
    public static ConditionsBuilder UnitIsHidden(
        this ConditionsBuilder builder,
        UnitEvaluator unit,
        bool negate = false)
    {
      builder.Validate(unit);
    
      var element = ElementTool.Create<UnitIsHidden>();
      element.Unit = unit;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnitBlueprint"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="blueprint"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(UnitBlueprint))]
    public static ConditionsBuilder UnitBlueprint(
        this ConditionsBuilder builder,
        UnitEvaluator unit,
        string? blueprint = null,
        bool negate = false)
    {
      builder.Validate(unit);
    
      var element = ElementTool.Create<UnitBlueprint>();
      element.Unit = unit;
      element.m_Blueprint = BlueprintTool.GetRef<BlueprintUnitReference>(blueprint);
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnitClass"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="clazz"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(UnitClass))]
    public static ConditionsBuilder UnitClass(
        this ConditionsBuilder builder,
        UnitEvaluator unit,
        IntEvaluator minLevel,
        string? clazz = null,
        bool negate = false)
    {
      builder.Validate(unit);
      builder.Validate(minLevel);
    
      var element = ElementTool.Create<UnitClass>();
      element.Unit = unit;
      element.m_Class = BlueprintTool.GetRef<BlueprintCharacterClassReference>(clazz);
      element.MinLevel = minLevel;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnitEqual"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UnitEqual))]
    public static ConditionsBuilder UnitEqual(
        this ConditionsBuilder builder,
        UnitEvaluator firstUnit,
        UnitEvaluator secondUnit,
        bool negate = false)
    {
      builder.Validate(firstUnit);
      builder.Validate(secondUnit);
    
      var element = ElementTool.Create<UnitEqual>();
      element.FirstUnit = firstUnit;
      element.SecondUnit = secondUnit;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnitFromSpawnerIsDead"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UnitFromSpawnerIsDead))]
    public static ConditionsBuilder UnitFromSpawnerIsDead(
        this ConditionsBuilder builder,
        EntityReference target,
        bool negate = false)
    {
      builder.Validate(target);
    
      var element = ElementTool.Create<UnitFromSpawnerIsDead>();
      element.Target = target;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnitFromSummonPool"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="summonPool"><see cref="Kingmaker.Blueprints.BlueprintSummonPool"/></param>
    [Generated]
    [Implements(typeof(UnitFromSummonPool))]
    public static ConditionsBuilder UnitFromSummonPool(
        this ConditionsBuilder builder,
        UnitEvaluator unit,
        string? summonPool = null,
        bool negate = false)
    {
      builder.Validate(unit);
    
      var element = ElementTool.Create<UnitFromSummonPool>();
      element.Unit = unit;
      element.m_SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(summonPool);
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnitGender"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UnitGender))]
    public static ConditionsBuilder UnitGender(
        this ConditionsBuilder builder,
        UnitEvaluator unit,
        Gender gender = default,
        bool negate = false)
    {
      builder.Validate(unit);
    
      var element = ElementTool.Create<UnitGender>();
      element.Unit = unit;
      element.Gender = gender;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnitIsNull"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UnitIsNull))]
    public static ConditionsBuilder UnitIsNull(
        this ConditionsBuilder builder,
        UnitEvaluator target,
        bool negate = false)
    {
      builder.Validate(target);
    
      var element = ElementTool.Create<UnitIsNull>();
      element.Target = target;
      element.Not = negate;
      return builder.Add(element);
    }
  }
}
