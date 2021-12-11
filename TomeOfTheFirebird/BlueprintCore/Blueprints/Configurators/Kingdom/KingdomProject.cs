using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Localization;
using System;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintKingdomProject"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintKingdomProject))]
  public abstract class BaseKingdomProjectConfigurator<T, TBuilder>
      : BaseKingdomEventBaseConfigurator<T, TBuilder>
      where T : BlueprintKingdomProject
      where TBuilder : BaseKingdomProjectConfigurator<T, TBuilder>
  {
    protected BaseKingdomProjectConfigurator(string name) : base(name) { }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomProject.ProjectType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetProjectType(KingdomProjectType projectType)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ProjectType = projectType;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomProject.ProjectStartCost"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetProjectStartCost(KingdomResourcesAmount projectStartCost)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ProjectStartCost = projectStartCost;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomProject.m_MechanicalDescription"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetMechanicalDescription(LocalizedString? mechanicalDescription)
    {
      ValidateParam(mechanicalDescription);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_MechanicalDescription = mechanicalDescription ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomProject.SpendRulerTimeDays"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetSpendRulerTimeDays(int spendRulerTimeDays)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.SpendRulerTimeDays = spendRulerTimeDays;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomProject.Repeatable"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetRepeatable(bool repeatable)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Repeatable = repeatable;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomProject.Cooldown"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetCooldown(int cooldown)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Cooldown = cooldown;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomProject.IsRankUpProject"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetIsRankUpProject(bool isRankUpProject)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IsRankUpProject = isRankUpProject;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomProject.RankupProjectFor"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetRankupProjectFor(KingdomStats.Type rankupProjectFor)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.RankupProjectFor = rankupProjectFor;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomProject.AIPriority"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetAIPriority(int aIPriority)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AIPriority = aIPriority;
          });
    }

    /// <summary>
    /// Adds <see cref="EventItemCost"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="items"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    [Implements(typeof(EventItemCost))]
    public TBuilder AddEventItemCost(
        string[]? items = null,
        int amount = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new EventItemCost();
      component.m_Items = items.Select(name => BlueprintTool.GetRef<BlueprintItemReference>(name)).ToArray();
      component.Amount = amount;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ExclusiveProjects"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="projects"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomProject"/></param>
    [Generated]
    [Implements(typeof(ExclusiveProjects))]
    public TBuilder AddExclusiveProjects(
        string[]? projects = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ExclusiveProjects();
      component.m_Projects = projects.Select(name => BlueprintTool.GetRef<BlueprintKingdomProjectReference>(name)).ToArray();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="FinishObjectiveOnTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="objective"><see cref="Kingmaker.Blueprints.Quests.BlueprintQuestObjective"/></param>
    [Generated]
    [Implements(typeof(FinishObjectiveOnTrigger))]
    public TBuilder AddFinishObjectiveOnTrigger(
        string? objective = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new FinishObjectiveOnTrigger();
      component.m_Objective = BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(objective);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="MarkAsCrusadeProject"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MarkAsCrusadeProject))]
    public TBuilder AddMarkAsCrusadeProject(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new MarkAsCrusadeProject();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }
  }

  /// <summary>
  /// Configurator for <see cref="BlueprintKingdomProject"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintKingdomProject))]
  public class KingdomProjectConfigurator : BaseKingdomEventBaseConfigurator<BlueprintKingdomProject, KingdomProjectConfigurator>
  {
    private KingdomProjectConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static KingdomProjectConfigurator For(string name)
    {
      return new KingdomProjectConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static KingdomProjectConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintKingdomProject>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomProject.ProjectType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomProjectConfigurator SetProjectType(KingdomProjectType projectType)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ProjectType = projectType;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomProject.ProjectStartCost"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomProjectConfigurator SetProjectStartCost(KingdomResourcesAmount projectStartCost)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ProjectStartCost = projectStartCost;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomProject.m_MechanicalDescription"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomProjectConfigurator SetMechanicalDescription(LocalizedString? mechanicalDescription)
    {
      ValidateParam(mechanicalDescription);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_MechanicalDescription = mechanicalDescription ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomProject.SpendRulerTimeDays"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomProjectConfigurator SetSpendRulerTimeDays(int spendRulerTimeDays)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.SpendRulerTimeDays = spendRulerTimeDays;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomProject.Repeatable"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomProjectConfigurator SetRepeatable(bool repeatable)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Repeatable = repeatable;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomProject.Cooldown"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomProjectConfigurator SetCooldown(int cooldown)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Cooldown = cooldown;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomProject.IsRankUpProject"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomProjectConfigurator SetIsRankUpProject(bool isRankUpProject)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IsRankUpProject = isRankUpProject;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomProject.RankupProjectFor"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomProjectConfigurator SetRankupProjectFor(KingdomStats.Type rankupProjectFor)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.RankupProjectFor = rankupProjectFor;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomProject.AIPriority"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomProjectConfigurator SetAIPriority(int aIPriority)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AIPriority = aIPriority;
          });
    }

    /// <summary>
    /// Adds <see cref="EventItemCost"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="items"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    [Implements(typeof(EventItemCost))]
    public KingdomProjectConfigurator AddEventItemCost(
        string[]? items = null,
        int amount = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new EventItemCost();
      component.m_Items = items.Select(name => BlueprintTool.GetRef<BlueprintItemReference>(name)).ToArray();
      component.Amount = amount;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ExclusiveProjects"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="projects"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomProject"/></param>
    [Generated]
    [Implements(typeof(ExclusiveProjects))]
    public KingdomProjectConfigurator AddExclusiveProjects(
        string[]? projects = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ExclusiveProjects();
      component.m_Projects = projects.Select(name => BlueprintTool.GetRef<BlueprintKingdomProjectReference>(name)).ToArray();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="FinishObjectiveOnTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="objective"><see cref="Kingmaker.Blueprints.Quests.BlueprintQuestObjective"/></param>
    [Generated]
    [Implements(typeof(FinishObjectiveOnTrigger))]
    public KingdomProjectConfigurator AddFinishObjectiveOnTrigger(
        string? objective = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new FinishObjectiveOnTrigger();
      component.m_Objective = BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(objective);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="MarkAsCrusadeProject"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MarkAsCrusadeProject))]
    public KingdomProjectConfigurator AddMarkAsCrusadeProject(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new MarkAsCrusadeProject();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }
  }
}
