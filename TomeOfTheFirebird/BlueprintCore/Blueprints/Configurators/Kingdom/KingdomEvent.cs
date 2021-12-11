using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Localization;
using System;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>
  /// Configurator for <see cref="BlueprintKingdomEvent"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintKingdomEvent))]
  public class KingdomEventConfigurator : BaseKingdomEventBaseConfigurator<BlueprintKingdomEvent, KingdomEventConfigurator>
  {
    private KingdomEventConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static KingdomEventConfigurator For(string name)
    {
      return new KingdomEventConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static KingdomEventConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintKingdomEvent>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEvent.IsOpportunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomEventConfigurator SetIsOpportunity(bool isOpportunity)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IsOpportunity = isOpportunity;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEvent.ForceOneTimeOnly"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomEventConfigurator SetForceOneTimeOnly(bool forceOneTimeOnly)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ForceOneTimeOnly = forceOneTimeOnly;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEvent.m_DependsOnQuest"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="dependsOnQuest"><see cref="Kingmaker.Blueprints.Quests.BlueprintQuest"/></param>
    [Generated]
    public KingdomEventConfigurator SetDependsOnQuest(string? dependsOnQuest)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DependsOnQuest = BlueprintTool.GetRef<BlueprintQuestReference>(dependsOnQuest);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEvent.m_Tags"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomEventConfigurator SetTags(BlueprintKingdomEvent.TagList tags)
    {
      ValidateParam(tags);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Tags = tags;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEvent.RequiredTags"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomEventConfigurator SetRequiredTags(EventLocationTagList requiredTags)
    {
      ValidateParam(requiredTags);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.RequiredTags = requiredTags;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEvent.OnTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomEventConfigurator SetOnTrigger(ActionsBuilder? onTrigger)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.OnTrigger = onTrigger?.Build() ?? Constants.Empty.Actions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEvent.StatsOnTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomEventConfigurator SetStatsOnTrigger(KingdomStats.Changes statsOnTrigger)
    {
      ValidateParam(statsOnTrigger);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.StatsOnTrigger = statsOnTrigger;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEvent.UnapplyTriggerOnResolve"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomEventConfigurator SetUnapplyTriggerOnResolve(bool unapplyTriggerOnResolve)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.UnapplyTriggerOnResolve = unapplyTriggerOnResolve;
          });
    }

    /// <summary>
    /// Adds <see cref="EventRecurrence"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EventRecurrence))]
    public KingdomEventConfigurator AddEventRecurrence(
        KingdomStats.Changes statsOnRecurrence,
        int recurrencePeriod = default,
        bool tickOnStart = default,
        ActionsBuilder? onRecurrence = null,
        LocalizedString? description = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(statsOnRecurrence);
      ValidateParam(description);
    
      var component = new EventRecurrence();
      component.RecurrencePeriod = recurrencePeriod;
      component.TickOnStart = tickOnStart;
      component.OnRecurrence = onRecurrence?.Build() ?? Constants.Empty.Actions;
      component.StatsOnRecurrence = statsOnRecurrence;
      component.Description = description ?? Constants.Empty.String;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }
  }
}
