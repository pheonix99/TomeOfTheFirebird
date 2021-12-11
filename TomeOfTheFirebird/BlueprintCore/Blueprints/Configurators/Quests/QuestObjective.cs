using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.AreaLogic.QuestSystem;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Experience;
using Kingmaker.Blueprints.Quests;
using Kingmaker.Blueprints.Quests.Logic;
using Kingmaker.Designers.EventConditionActionSystem.ObjectiveEvents;
using Kingmaker.Designers.Quests.Common;
using Kingmaker.ElementsSystem;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Localization;
using System;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Quests
{
  /// <summary>
  /// Configurator for <see cref="BlueprintQuestObjective"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintQuestObjective))]
  public class QuestObjectiveConfigurator : BaseFactConfigurator<BlueprintQuestObjective, QuestObjectiveConfigurator>
  {
    private QuestObjectiveConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static QuestObjectiveConfigurator For(string name)
    {
      return new QuestObjectiveConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static QuestObjectiveConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintQuestObjective>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintQuestObjective.m_Addendums"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="addendums"><see cref="Kingmaker.Blueprints.Quests.BlueprintQuestObjective"/></param>
    [Generated]
    public QuestObjectiveConfigurator SetAddendums(string[]? addendums)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Addendums = addendums.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintQuestObjective.m_Addendums"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="addendums"><see cref="Kingmaker.Blueprints.Quests.BlueprintQuestObjective"/></param>
    [Generated]
    public QuestObjectiveConfigurator AddToAddendums(params string[] addendums)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Addendums.AddRange(addendums.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintQuestObjective.m_Addendums"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="addendums"><see cref="Kingmaker.Blueprints.Quests.BlueprintQuestObjective"/></param>
    [Generated]
    public QuestObjectiveConfigurator RemoveFromAddendums(params string[] addendums)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = addendums.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name));
            bp.m_Addendums =
                bp.m_Addendums
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintQuestObjective.m_Areas"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="areas"><see cref="Kingmaker.Blueprints.Area.BlueprintArea"/></param>
    [Generated]
    public QuestObjectiveConfigurator SetAreas(string[]? areas)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Areas = areas.Select(name => BlueprintTool.GetRef<BlueprintAreaReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintQuestObjective.m_Areas"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="areas"><see cref="Kingmaker.Blueprints.Area.BlueprintArea"/></param>
    [Generated]
    public QuestObjectiveConfigurator AddToAreas(params string[] areas)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Areas.AddRange(areas.Select(name => BlueprintTool.GetRef<BlueprintAreaReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintQuestObjective.m_Areas"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="areas"><see cref="Kingmaker.Blueprints.Area.BlueprintArea"/></param>
    [Generated]
    public QuestObjectiveConfigurator RemoveFromAreas(params string[] areas)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = areas.Select(name => BlueprintTool.GetRef<BlueprintAreaReference>(name));
            bp.m_Areas =
                bp.m_Areas
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintQuestObjective.Title"/> (Auto Generated)
    /// </summary>
    [Generated]
    public QuestObjectiveConfigurator SetTitle(LocalizedString? title)
    {
      ValidateParam(title);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Title = title ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintQuestObjective.Locations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="locations"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMapPoint"/></param>
    [Generated]
    public QuestObjectiveConfigurator SetLocations(string[]? locations)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Locations = locations.Select(name => BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintQuestObjective.Locations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="locations"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMapPoint"/></param>
    [Generated]
    public QuestObjectiveConfigurator AddToLocations(params string[] locations)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Locations.AddRange(locations.Select(name => BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintQuestObjective.Locations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="locations"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMapPoint"/></param>
    [Generated]
    public QuestObjectiveConfigurator RemoveFromLocations(params string[] locations)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = locations.Select(name => BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(name));
            bp.Locations =
                bp.Locations
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintQuestObjective.MultiEntranceEntries"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="multiEntranceEntries"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintMultiEntranceEntry"/></param>
    [Generated]
    public QuestObjectiveConfigurator SetMultiEntranceEntries(string[]? multiEntranceEntries)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MultiEntranceEntries = multiEntranceEntries.Select(name => BlueprintTool.GetRef<BlueprintMultiEntranceEntry.Reference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintQuestObjective.MultiEntranceEntries"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="multiEntranceEntries"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintMultiEntranceEntry"/></param>
    [Generated]
    public QuestObjectiveConfigurator AddToMultiEntranceEntries(params string[] multiEntranceEntries)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MultiEntranceEntries.AddRange(multiEntranceEntries.Select(name => BlueprintTool.GetRef<BlueprintMultiEntranceEntry.Reference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintQuestObjective.MultiEntranceEntries"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="multiEntranceEntries"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintMultiEntranceEntry"/></param>
    [Generated]
    public QuestObjectiveConfigurator RemoveFromMultiEntranceEntries(params string[] multiEntranceEntries)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = multiEntranceEntries.Select(name => BlueprintTool.GetRef<BlueprintMultiEntranceEntry.Reference>(name));
            bp.MultiEntranceEntries =
                bp.MultiEntranceEntries
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintQuestObjective.Description"/> (Auto Generated)
    /// </summary>
    [Generated]
    public QuestObjectiveConfigurator SetDescription(LocalizedString? description)
    {
      ValidateParam(description);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Description = description ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintQuestObjective.AutoFailDays"/> (Auto Generated)
    /// </summary>
    [Generated]
    public QuestObjectiveConfigurator SetAutoFailDays(int autoFailDays)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AutoFailDays = autoFailDays;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintQuestObjective.IsFakeFail"/> (Auto Generated)
    /// </summary>
    [Generated]
    public QuestObjectiveConfigurator SetIsFakeFail(bool isFakeFail)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IsFakeFail = isFakeFail;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintQuestObjective.StartOnKingdomTime"/> (Auto Generated)
    /// </summary>
    [Generated]
    public QuestObjectiveConfigurator SetStartOnKingdomTime(bool startOnKingdomTime)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.StartOnKingdomTime = startOnKingdomTime;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintQuestObjective.m_FinishParent"/> (Auto Generated)
    /// </summary>
    [Generated]
    public QuestObjectiveConfigurator SetFinishParent(bool finishParent)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_FinishParent = finishParent;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintQuestObjective.m_Hidden"/> (Auto Generated)
    /// </summary>
    [Generated]
    public QuestObjectiveConfigurator SetHidden(bool hidden)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Hidden = hidden;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintQuestObjective.m_NextObjectives"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="nextObjectives"><see cref="Kingmaker.Blueprints.Quests.BlueprintQuestObjective"/></param>
    [Generated]
    public QuestObjectiveConfigurator SetNextObjectives(string[]? nextObjectives)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_NextObjectives = nextObjectives.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintQuestObjective.m_NextObjectives"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="nextObjectives"><see cref="Kingmaker.Blueprints.Quests.BlueprintQuestObjective"/></param>
    [Generated]
    public QuestObjectiveConfigurator AddToNextObjectives(params string[] nextObjectives)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_NextObjectives.AddRange(nextObjectives.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintQuestObjective.m_NextObjectives"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="nextObjectives"><see cref="Kingmaker.Blueprints.Quests.BlueprintQuestObjective"/></param>
    [Generated]
    public QuestObjectiveConfigurator RemoveFromNextObjectives(params string[] nextObjectives)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = nextObjectives.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name));
            bp.m_NextObjectives =
                bp.m_NextObjectives
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintQuestObjective.m_Quest"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="quest"><see cref="Kingmaker.Blueprints.Quests.BlueprintQuest"/></param>
    [Generated]
    public QuestObjectiveConfigurator SetQuest(string? quest)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Quest = BlueprintTool.GetRef<BlueprintQuestReference>(quest);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintQuestObjective.m_Type"/> (Auto Generated)
    /// </summary>
    [Generated]
    public QuestObjectiveConfigurator SetType(BlueprintQuestObjective.Type type)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Type = type;
          });
    }

    /// <summary>
    /// Adds <see cref="QuestObjectiveCallback"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(QuestObjectiveCallback))]
    public QuestObjectiveConfigurator AddQuestObjectiveCallback(
        ActionsBuilder? onComplete = null,
        ActionsBuilder? onFail = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new QuestObjectiveCallback();
      component.m_OnComplete = onComplete?.Build() ?? Constants.Empty.Actions;
      component.m_OnFail = onFail?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TimedObjectiveTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TimedObjectiveTrigger))]
    public QuestObjectiveConfigurator AddTimedObjectiveTrigger(
        int daysTillTrigger = default,
        ActionsBuilder? action = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TimedObjectiveTrigger();
      component.DaysTillTrigger = daysTillTrigger;
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="Experience"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(Experience))]
    public QuestObjectiveConfigurator AddExperience(
        IntEvaluator count,
        EncounterType encounter = default,
        int cR = default,
        float modifier = default,
        bool dummy = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(count);
    
      var component = new Experience();
      component.Encounter = encounter;
      component.CR = cR;
      component.Modifier = modifier;
      component.Count = count;
      component.Dummy = dummy;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ChangeObjectiveOnUnlockTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="targetObjective"><see cref="Kingmaker.Blueprints.Quests.BlueprintQuestObjective"/></param>
    /// <param name="unlock"><see cref="Kingmaker.Blueprints.BlueprintUnlockableFlag"/></param>
    [Generated]
    [Implements(typeof(ChangeObjectiveOnUnlockTrigger))]
    public QuestObjectiveConfigurator AddChangeObjectiveOnUnlockTrigger(
        bool checkUnlockStatusOnStart = default,
        ChangeObjectiveOnUnlockTrigger.ObjectiveStatus setStatus = default,
        string? targetObjective = null,
        string? unlock = null,
        ChangeObjectiveOnUnlockTrigger.UnlockStatus unlockStatus = default)
    {
      var component = new ChangeObjectiveOnUnlockTrigger();
      component.checkUnlockStatusOnStart = checkUnlockStatusOnStart;
      component.setStatus = setStatus;
      component.m_targetObjective = BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(targetObjective);
      component.m_unlock = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(unlock);
      component.unlockStatus = unlockStatus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="GiveUnlockOnObjectiveTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="unlock"><see cref="Kingmaker.Blueprints.BlueprintUnlockableFlag"/></param>
    [Generated]
    [Implements(typeof(GiveUnlockOnObjectiveTrigger))]
    public QuestObjectiveConfigurator AddGiveUnlockOnObjectiveTrigger(
        QuestObjectiveState objectiveState = default,
        string? unlock = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new GiveUnlockOnObjectiveTrigger();
      component.objectiveState = objectiveState;
      component.m_unlock = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(unlock);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="SummonPoolCountTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="summonPool"><see cref="Kingmaker.Blueprints.BlueprintSummonPool"/></param>
    [Generated]
    [Implements(typeof(SummonPoolCountTrigger))]
    public QuestObjectiveConfigurator AddSummonPoolCountTrigger(
        int count = default,
        SummonPoolCountTrigger.ObjectiveStatus setStatus = default,
        string? summonPool = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new SummonPoolCountTrigger();
      component.count = count;
      component.setStatus = setStatus;
      component.m_summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(summonPool);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ObjectiveStatusTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ObjectiveStatusTrigger))]
    public QuestObjectiveConfigurator AddObjectiveStatusTrigger(
        QuestObjectiveState objectiveState = default,
        ConditionsBuilder? conditions = null,
        ActionsBuilder? actions = null)
    {
      var component = new ObjectiveStatusTrigger();
      component.objectiveState = objectiveState;
      component.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }
  }
}
