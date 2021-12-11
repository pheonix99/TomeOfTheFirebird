using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.QA.Clockwork;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.QA
{
  /// <summary>
  /// Configurator for <see cref="BlueprintClockworkScenarioPart"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintClockworkScenarioPart))]
  public class ClockworkScenarioPartConfigurator : BaseBlueprintConfigurator<BlueprintClockworkScenarioPart, ClockworkScenarioPartConfigurator>
  {
    private ClockworkScenarioPartConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ClockworkScenarioPartConfigurator For(string name)
    {
      return new ClockworkScenarioPartConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ClockworkScenarioPartConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintClockworkScenarioPart>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenarioPart.RetrySkillChecks"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioPartConfigurator SetRetrySkillChecks(List<EntityReference>? retrySkillChecks)
    {
      ValidateParam(retrySkillChecks);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.RetrySkillChecks = retrySkillChecks;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintClockworkScenarioPart.RetrySkillChecks"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioPartConfigurator AddToRetrySkillChecks(params EntityReference[] retrySkillChecks)
    {
      ValidateParam(retrySkillChecks);
      return OnConfigureInternal(
          bp =>
          {
            bp.RetrySkillChecks.AddRange(retrySkillChecks.ToList() ?? new List<EntityReference>());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintClockworkScenarioPart.RetrySkillChecks"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioPartConfigurator RemoveFromRetrySkillChecks(params EntityReference[] retrySkillChecks)
    {
      ValidateParam(retrySkillChecks);
      return OnConfigureInternal(
          bp =>
          {
            bp.RetrySkillChecks = bp.RetrySkillChecks.Where(item => !retrySkillChecks.Contains(item)).ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenarioPart.HighPriorityAnswers"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="highPriorityAnswers"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintAnswer"/></param>
    [Generated]
    public ClockworkScenarioPartConfigurator SetHighPriorityAnswers(string[]? highPriorityAnswers)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.HighPriorityAnswers = highPriorityAnswers.Select(name => BlueprintTool.GetRef<BlueprintAnswerReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintClockworkScenarioPart.HighPriorityAnswers"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="highPriorityAnswers"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintAnswer"/></param>
    [Generated]
    public ClockworkScenarioPartConfigurator AddToHighPriorityAnswers(params string[] highPriorityAnswers)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.HighPriorityAnswers.AddRange(highPriorityAnswers.Select(name => BlueprintTool.GetRef<BlueprintAnswerReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintClockworkScenarioPart.HighPriorityAnswers"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="highPriorityAnswers"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintAnswer"/></param>
    [Generated]
    public ClockworkScenarioPartConfigurator RemoveFromHighPriorityAnswers(params string[] highPriorityAnswers)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = highPriorityAnswers.Select(name => BlueprintTool.GetRef<BlueprintAnswerReference>(name));
            bp.HighPriorityAnswers =
                bp.HighPriorityAnswers
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenarioPart.DoNotSellItems"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="doNotSellItems"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    public ClockworkScenarioPartConfigurator SetDoNotSellItems(string[]? doNotSellItems)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DoNotSellItems = doNotSellItems.Select(name => BlueprintTool.GetRef<BlueprintItemReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintClockworkScenarioPart.DoNotSellItems"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="doNotSellItems"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    public ClockworkScenarioPartConfigurator AddToDoNotSellItems(params string[] doNotSellItems)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DoNotSellItems.AddRange(doNotSellItems.Select(name => BlueprintTool.GetRef<BlueprintItemReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintClockworkScenarioPart.DoNotSellItems"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="doNotSellItems"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    public ClockworkScenarioPartConfigurator RemoveFromDoNotSellItems(params string[] doNotSellItems)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = doNotSellItems.Select(name => BlueprintTool.GetRef<BlueprintItemReference>(name));
            bp.DoNotSellItems =
                bp.DoNotSellItems
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenarioPart.DoNotInterract"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioPartConfigurator SetDoNotInterract(List<ClockworkEntityReference>? doNotInterract)
    {
      ValidateParam(doNotInterract);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.DoNotInterract = doNotInterract;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintClockworkScenarioPart.DoNotInterract"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioPartConfigurator AddToDoNotInterract(params ClockworkEntityReference[] doNotInterract)
    {
      ValidateParam(doNotInterract);
      return OnConfigureInternal(
          bp =>
          {
            bp.DoNotInterract.AddRange(doNotInterract.ToList() ?? new List<ClockworkEntityReference>());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintClockworkScenarioPart.DoNotInterract"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioPartConfigurator RemoveFromDoNotInterract(params ClockworkEntityReference[] doNotInterract)
    {
      ValidateParam(doNotInterract);
      return OnConfigureInternal(
          bp =>
          {
            bp.DoNotInterract = bp.DoNotInterract.Where(item => !doNotInterract.Contains(item)).ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenarioPart.DoNotInterractUnits"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="doNotInterractUnits"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public ClockworkScenarioPartConfigurator SetDoNotInterractUnits(string[]? doNotInterractUnits)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DoNotInterractUnits = doNotInterractUnits.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintClockworkScenarioPart.DoNotInterractUnits"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="doNotInterractUnits"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public ClockworkScenarioPartConfigurator AddToDoNotInterractUnits(params string[] doNotInterractUnits)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DoNotInterractUnits.AddRange(doNotInterractUnits.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintClockworkScenarioPart.DoNotInterractUnits"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="doNotInterractUnits"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public ClockworkScenarioPartConfigurator RemoveFromDoNotInterractUnits(params string[] doNotInterractUnits)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = doNotInterractUnits.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name));
            bp.DoNotInterractUnits =
                bp.DoNotInterractUnits
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenarioPart.DoNotUseAnswer"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="doNotUseAnswer"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintAnswer"/></param>
    [Generated]
    public ClockworkScenarioPartConfigurator SetDoNotUseAnswer(string[]? doNotUseAnswer)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DoNotUseAnswer = doNotUseAnswer.Select(name => BlueprintTool.GetRef<BlueprintAnswerReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintClockworkScenarioPart.DoNotUseAnswer"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="doNotUseAnswer"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintAnswer"/></param>
    [Generated]
    public ClockworkScenarioPartConfigurator AddToDoNotUseAnswer(params string[] doNotUseAnswer)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DoNotUseAnswer.AddRange(doNotUseAnswer.Select(name => BlueprintTool.GetRef<BlueprintAnswerReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintClockworkScenarioPart.DoNotUseAnswer"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="doNotUseAnswer"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintAnswer"/></param>
    [Generated]
    public ClockworkScenarioPartConfigurator RemoveFromDoNotUseAnswer(params string[] doNotUseAnswer)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = doNotUseAnswer.Select(name => BlueprintTool.GetRef<BlueprintAnswerReference>(name));
            bp.DoNotUseAnswer =
                bp.DoNotUseAnswer
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenarioPart.DoNotEnterAreas"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="doNotEnterAreas"><see cref="Kingmaker.Blueprints.Area.BlueprintArea"/></param>
    [Generated]
    public ClockworkScenarioPartConfigurator SetDoNotEnterAreas(string[]? doNotEnterAreas)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DoNotEnterAreas = doNotEnterAreas.Select(name => BlueprintTool.GetRef<BlueprintAreaReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintClockworkScenarioPart.DoNotEnterAreas"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="doNotEnterAreas"><see cref="Kingmaker.Blueprints.Area.BlueprintArea"/></param>
    [Generated]
    public ClockworkScenarioPartConfigurator AddToDoNotEnterAreas(params string[] doNotEnterAreas)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DoNotEnterAreas.AddRange(doNotEnterAreas.Select(name => BlueprintTool.GetRef<BlueprintAreaReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintClockworkScenarioPart.DoNotEnterAreas"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="doNotEnterAreas"><see cref="Kingmaker.Blueprints.Area.BlueprintArea"/></param>
    [Generated]
    public ClockworkScenarioPartConfigurator RemoveFromDoNotEnterAreas(params string[] doNotEnterAreas)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = doNotEnterAreas.Select(name => BlueprintTool.GetRef<BlueprintAreaReference>(name));
            bp.DoNotEnterAreas =
                bp.DoNotEnterAreas
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Adds <see cref="AreaTest"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="area"><see cref="Kingmaker.Blueprints.Area.BlueprintArea"/></param>
    /// <param name="areaPart"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaPart"/></param>
    [Generated]
    [Implements(typeof(AreaTest))]
    public ClockworkScenarioPartConfigurator AddAreaTest(
        Condition condition,
        ClockworkCommandList commandList,
        string? area = null,
        string? areaPart = null,
        bool everyVisit = default)
    {
      ValidateParam(condition);
      ValidateParam(commandList);
    
      var component = new AreaTest();
      component.Area = BlueprintTool.GetRef<BlueprintAreaReference>(area);
      component.AreaPart = BlueprintTool.GetRef<BlueprintAreaPartReference>(areaPart);
      component.EveryVisit = everyVisit;
      component.Condition = condition;
      component.CommandList = commandList;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ConditionalCommandList"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ConditionalCommandList))]
    public ClockworkScenarioPartConfigurator AddConditionalCommandList(
        Condition condition,
        ClockworkCommandList commandList)
    {
      ValidateParam(condition);
      ValidateParam(commandList);
    
      var component = new ConditionalCommandList();
      component.Condition = condition;
      component.CommandList = commandList;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MythicLevelUpPlan"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="beginnerMythic"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    /// <param name="earlyMythic"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    /// <param name="lateMythic"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(MythicLevelUpPlan))]
    public ClockworkScenarioPartConfigurator AddMythicLevelUpPlan(
        string? beginnerMythic = null,
        string? earlyMythic = null,
        string? lateMythic = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new MythicLevelUpPlan();
      component.BeginnerMythic = BlueprintTool.GetRef<BlueprintFeatureReference>(beginnerMythic);
      component.EarlyMythic = BlueprintTool.GetRef<BlueprintFeatureReference>(earlyMythic);
      component.LateMythic = BlueprintTool.GetRef<BlueprintFeatureReference>(lateMythic);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }
  }
}
