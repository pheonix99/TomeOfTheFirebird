using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Armies;
using Kingmaker.Armies.Blueprints;
using Kingmaker.Armies.Components;
using Kingmaker.Armies.TacticalCombat.Components;
using Kingmaker.Armies.TacticalCombat.LeaderSkills;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom;
using Kingmaker.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Armies
{
  /// <summary>
  /// Configurator for <see cref="BlueprintLeaderSkill"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintLeaderSkill))]
  public class LeaderSkillConfigurator : BaseBlueprintConfigurator<BlueprintLeaderSkill, LeaderSkillConfigurator>
  {
    private LeaderSkillConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static LeaderSkillConfigurator For(string name)
    {
      return new LeaderSkillConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static LeaderSkillConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintLeaderSkill>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintLeaderSkill.Icon"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LeaderSkillConfigurator SetIcon(Sprite icon)
    {
      ValidateParam(icon);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Icon = icon;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintLeaderSkill.LocalizedName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LeaderSkillConfigurator SetLocalizedName(LocalizedString? localizedName)
    {
      ValidateParam(localizedName);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.LocalizedName = localizedName ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintLeaderSkill.LocalizedDescription"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LeaderSkillConfigurator SetLocalizedDescription(LocalizedString? localizedDescription)
    {
      ValidateParam(localizedDescription);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.LocalizedDescription = localizedDescription ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintLeaderSkill.BonusAttributes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LeaderSkillConfigurator SetBonusAttributes(LeaderAttributes bonusAttributes)
    {
      ValidateParam(bonusAttributes);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.BonusAttributes = bonusAttributes;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintLeaderSkill.Type"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LeaderSkillConfigurator SetType(ArmyLeaderSkillType type)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Type = type;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintLeaderSkill.StackTag"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LeaderSkillConfigurator SetStackTag(StackTag stackTag)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.StackTag = stackTag;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintLeaderSkill.m_PrerequisiteLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LeaderSkillConfigurator SetPrerequisiteLevel(int prerequisiteLevel)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_PrerequisiteLevel = prerequisiteLevel;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintLeaderSkill.m_Prerequisites"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="prerequisites"><see cref="Kingmaker.Armies.Blueprints.BlueprintLeaderSkill"/></param>
    [Generated]
    public LeaderSkillConfigurator SetPrerequisites(string[]? prerequisites)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Prerequisites = prerequisites.Select(name => BlueprintTool.GetRef<BlueprintLeaderSkillReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintLeaderSkill.m_Prerequisites"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="prerequisites"><see cref="Kingmaker.Armies.Blueprints.BlueprintLeaderSkill"/></param>
    [Generated]
    public LeaderSkillConfigurator AddToPrerequisites(params string[] prerequisites)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Prerequisites = CommonTool.Append(bp.m_Prerequisites, prerequisites.Select(name => BlueprintTool.GetRef<BlueprintLeaderSkillReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintLeaderSkill.m_Prerequisites"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="prerequisites"><see cref="Kingmaker.Armies.Blueprints.BlueprintLeaderSkill"/></param>
    [Generated]
    public LeaderSkillConfigurator RemoveFromPrerequisites(params string[] prerequisites)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = prerequisites.Select(name => BlueprintTool.GetRef<BlueprintLeaderSkillReference>(name));
            bp.m_Prerequisites =
                bp.m_Prerequisites
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Adds <see cref="AddFactOnLeaderUnit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="facts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AddFactOnLeaderUnit))]
    public LeaderSkillConfigurator AddFactOnLeaderUnit(
        string[]? facts = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddFactOnLeaderUnit();
      component.m_Facts = facts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddFactOnTacticalUnit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="facts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AddFactOnTacticalUnit))]
    public LeaderSkillConfigurator AddFactOnTacticalUnit(
        TargetFilter targetController,
        string[]? facts = null)
    {
      ValidateParam(targetController);
    
      var component = new AddFactOnTacticalUnit();
      component.m_Facts = facts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.m_TargetController = targetController;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CastOnTacticalCombatStart"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellToCast"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(CastOnTacticalCombatStart))]
    public LeaderSkillConfigurator AddCastOnTacticalCombatStart(
        string? spellToCast = null,
        bool targetCell = default,
        List<int>? allowedColumns = null)
    {
      var component = new CastOnTacticalCombatStart();
      component.m_SpellToCast = BlueprintTool.GetRef<BlueprintAbilityReference>(spellToCast);
      component.m_TargetCell = targetCell;
      component.m_AllowedColumns = allowedColumns;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LeaderExpBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="bonusSkills"><see cref="Kingmaker.Armies.BlueprintLeaderSkillsList"/></param>
    [Generated]
    [Implements(typeof(LeaderExpBonus))]
    public LeaderSkillConfigurator AddLeaderExpBonus(
        int bonusPercent = default,
        int levelForBonusSkills = default,
        string? bonusSkills = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new LeaderExpBonus();
      component.m_BonusPercent = bonusPercent;
      component.m_LevelForBonusSkills = levelForBonusSkills;
      component.m_BonusSkills = BlueprintTool.GetRef<BlueprintLeaderSkillsList.Reference>(bonusSkills);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="LeaderPercentAttributeBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LeaderPercentAttributeBonus))]
    public LeaderSkillConfigurator AddLeaderPercentAttributeBonus(
        LeaderAttributes percentBonuses,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(percentBonuses);
    
      var component = new LeaderPercentAttributeBonus();
      component.m_PercentBonuses = percentBonuses;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="MaxArmySquadsBonusLeaderComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MaxArmySquadsBonusLeaderComponent))]
    public LeaderSkillConfigurator AddMaxArmySquadsBonusLeaderComponent(
        int armySizeBonus = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new MaxArmySquadsBonusLeaderComponent();
      component.m_ArmySizeBonus = armySizeBonus;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="PlaceLeaderTrapOnCombatStart"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="possibleTrapSkills"><see cref="Kingmaker.Armies.Blueprints.BlueprintLeaderSkill"/></param>
    [Generated]
    [Implements(typeof(PlaceLeaderTrapOnCombatStart))]
    public LeaderSkillConfigurator AddPlaceLeaderTrapOnCombatStart(
        string[]? possibleTrapSkills = null,
        List<int>? allowedColumns = null)
    {
      var component = new PlaceLeaderTrapOnCombatStart();
      component.m_PossibleTrapSkills = possibleTrapSkills.Select(name => BlueprintTool.GetRef<BlueprintLeaderSkillReference>(name)).ToArray();
      component.m_AllowedColumns = allowedColumns;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RemoveFactFromTacticalUnit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="facts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(RemoveFactFromTacticalUnit))]
    public LeaderSkillConfigurator AddRemoveFactFromTacticalUnit(
        TargetFilter targetController,
        string[]? facts = null)
    {
      ValidateParam(targetController);
    
      var component = new RemoveFactFromTacticalUnit();
      component.m_Facts = facts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.m_TargetController = targetController;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SquadsActionOnTacticalCombatStart"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="bannedFacts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(SquadsActionOnTacticalCombatStart))]
    public LeaderSkillConfigurator AddSquadsActionOnTacticalCombatStart(
        TargetFilter filter,
        string[]? bannedFacts = null,
        int maxSquadsCount = default,
        ActionsBuilder? actions = null)
    {
      ValidateParam(filter);
    
      var component = new SquadsActionOnTacticalCombatStart();
      component.m_Filter = filter;
      component.m_BannedFacts = bannedFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToList();
      component.m_MaxSquadsCount = maxSquadsCount;
      component.m_Actions = actions?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalLeaderRitualComponent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ability"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(TacticalLeaderRitualComponent))]
    public LeaderSkillConfigurator AddTacticalLeaderRitualComponent(
        string? ability = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TacticalLeaderRitualComponent();
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(ability);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ArmyLeaderAddResourcesOnBattleEnd"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmyLeaderAddResourcesOnBattleEnd))]
    public LeaderSkillConfigurator AddArmyLeaderAddResourcesOnBattleEnd(
        KingdomResourcesAmount resourcesAmount,
        bool onlyOnVictory = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ArmyLeaderAddResourcesOnBattleEnd();
      component.m_ResourcesAmount = resourcesAmount;
      component.OnlyOnVictory = onlyOnVictory;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TacticalMoraleModifier"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TacticalMoraleModifier))]
    public LeaderSkillConfigurator AddTacticalMoraleModifier(
        TargetFilter targetFilter,
        TacticalMoraleModifier.FactionTarget factionTarget = default,
        int modValue = default)
    {
      ValidateParam(targetFilter);
    
      var component = new TacticalMoraleModifier();
      component.m_TargetFilter = targetFilter;
      component.m_FactionTarget = factionTarget;
      component.m_ModValue = modValue;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyGlobalMapMovementBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmyGlobalMapMovementBonus))]
    public LeaderSkillConfigurator AddArmyGlobalMapMovementBonus(
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
