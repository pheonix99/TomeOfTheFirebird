using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
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
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintKingdomEventBase"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintKingdomEventBase))]
  public abstract class BaseKingdomEventBaseConfigurator<T, TBuilder>
      : BaseBlueprintConfigurator<T, TBuilder>
      where T : BlueprintKingdomEventBase
      where TBuilder : BaseKingdomEventBaseConfigurator<T, TBuilder>
  {
    protected BaseKingdomEventBaseConfigurator(string name) : base(name) { }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEventBase.InfoType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetInfoType(KingomEventInfoType infoType)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.InfoType = infoType;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEventBase.LocalizedName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetLocalizedName(LocalizedString? localizedName)
    {
      ValidateParam(localizedName);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.LocalizedName = localizedName ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEventBase.LocalizedDescription"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetLocalizedDescription(LocalizedString? localizedDescription)
    {
      ValidateParam(localizedDescription);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.LocalizedDescription = localizedDescription ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEventBase.TriggerCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetTriggerCondition(ConditionsBuilder? triggerCondition)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.TriggerCondition = triggerCondition?.Build() ?? Constants.Empty.Conditions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEventBase.ResolutionTime"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetResolutionTime(int resolutionTime)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ResolutionTime = resolutionTime;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEventBase.ResolveAutomatically"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetResolveAutomatically(bool resolveAutomatically)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ResolveAutomatically = resolveAutomatically;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEventBase.NeedToVisitTheThroneRoom"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetNeedToVisitTheThroneRoom(bool needToVisitTheThroneRoom)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.NeedToVisitTheThroneRoom = needToVisitTheThroneRoom;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEventBase.AICanCheat"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetAICanCheat(bool aICanCheat)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AICanCheat = aICanCheat;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEventBase.SkipRoll"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetSkipRoll(bool skipRoll)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.SkipRoll = skipRoll;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEventBase.ResolutionDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetResolutionDC(int resolutionDC)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ResolutionDC = resolutionDC;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEventBase.AutoResolveResult"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetAutoResolveResult(EventResult.MarginType autoResolveResult)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AutoResolveResult = autoResolveResult;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEventBase.Solutions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetSolutions(PossibleEventSolutions solutions)
    {
      ValidateParam(solutions);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Solutions = solutions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEventBase.DefaultResolutionType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetDefaultResolutionType(LeaderType defaultResolutionType)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DefaultResolutionType = defaultResolutionType;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEventBase.DefaultResolutionDescription"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetDefaultResolutionDescription(LocalizedString? defaultResolutionDescription)
    {
      ValidateParam(defaultResolutionDescription);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.DefaultResolutionDescription = defaultResolutionDescription ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEventBase.AIStopping"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetAIStopping(bool aIStopping)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AIStopping = aIStopping;
          });
    }

    /// <summary>
    /// Adds <see cref="EventDynamicCostFeast"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="blueprint"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomEventBase"/></param>
    [Generated]
    [Implements(typeof(EventDynamicCostFeast))]
    public TBuilder AddEventDynamicCostFeast(
        KingdomResourcesAmount costPerUse,
        string? blueprint = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new EventDynamicCostFeast();
      component.m_Blueprint = BlueprintTool.GetRef<BlueprintKingdomEventBaseReference>(blueprint);
      component.CostPerUse = costPerUse;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="EventAISolution"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="dialog"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintDialog"/></param>
    /// <param name="answers"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintAnswer"/></param>
    [Generated]
    [Implements(typeof(EventAISolution))]
    public TBuilder AddEventAISolution(
        ConditionsBuilder? condition = null,
        string? dialog = null,
        string[]? answers = null,
        ActionsBuilder? additionalActions = null)
    {
      var component = new EventAISolution();
      component.Condition = condition?.Build() ?? Constants.Empty.Conditions;
      component.m_Dialog = BlueprintTool.GetRef<BlueprintDialogReference>(dialog);
      component.m_Answers = answers.Select(name => BlueprintTool.GetRef<BlueprintAnswerReference>(name)).ToArray();
      component.AdditionalActions = additionalActions?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EventFinalResults"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EventFinalResults))]
    public TBuilder AddEventFinalResults(
        EventResult[]? results = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(results);
    
      var component = new EventFinalResults();
      component.Results = results;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }
  }
}
