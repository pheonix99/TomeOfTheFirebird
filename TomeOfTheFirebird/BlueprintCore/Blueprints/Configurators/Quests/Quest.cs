using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Experience;
using Kingmaker.Blueprints.Quests;
using Kingmaker.Blueprints.Quests.Logic;
using Kingmaker.Blueprints.Quests.Logic.CrusadeQuests;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.Localization;
using System;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Quests
{
  /// <summary>
  /// Configurator for <see cref="BlueprintQuest"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintQuest))]
  public class QuestConfigurator : BaseFactConfigurator<BlueprintQuest, QuestConfigurator>
  {
    private QuestConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static QuestConfigurator For(string name)
    {
      return new QuestConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static QuestConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintQuest>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintQuest.Description"/> (Auto Generated)
    /// </summary>
    [Generated]
    public QuestConfigurator SetDescription(LocalizedString? description)
    {
      ValidateParam(description);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Description = description ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintQuest.Title"/> (Auto Generated)
    /// </summary>
    [Generated]
    public QuestConfigurator SetTitle(LocalizedString? title)
    {
      ValidateParam(title);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Title = title ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintQuest.CompletionText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public QuestConfigurator SetCompletionText(LocalizedString? completionText)
    {
      ValidateParam(completionText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.CompletionText = completionText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintQuest.m_Group"/> (Auto Generated)
    /// </summary>
    [Generated]
    public QuestConfigurator SetGroup(QuestGroupId group)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Group = group;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintQuest.m_DescriptionPriority"/> (Auto Generated)
    /// </summary>
    [Generated]
    public QuestConfigurator SetDescriptionPriority(int descriptionPriority)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DescriptionPriority = descriptionPriority;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintQuest.m_Type"/> (Auto Generated)
    /// </summary>
    [Generated]
    public QuestConfigurator SetType(QuestType type)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Type = type;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintQuest.m_LastChapter"/> (Auto Generated)
    /// </summary>
    [Generated]
    public QuestConfigurator SetLastChapter(int lastChapter)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_LastChapter = lastChapter;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintQuest.m_Objectives"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="objectives"><see cref="Kingmaker.Blueprints.Quests.BlueprintQuestObjective"/></param>
    [Generated]
    public QuestConfigurator SetObjectives(string[]? objectives)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Objectives = objectives.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintQuest.m_Objectives"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="objectives"><see cref="Kingmaker.Blueprints.Quests.BlueprintQuestObjective"/></param>
    [Generated]
    public QuestConfigurator AddToObjectives(params string[] objectives)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Objectives.AddRange(objectives.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintQuest.m_Objectives"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="objectives"><see cref="Kingmaker.Blueprints.Quests.BlueprintQuestObjective"/></param>
    [Generated]
    public QuestConfigurator RemoveFromObjectives(params string[] objectives)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = objectives.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name));
            bp.m_Objectives =
                bp.m_Objectives
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Adds <see cref="QuestRelatesToCompanionStory"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="companion"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(QuestRelatesToCompanionStory))]
    public QuestConfigurator AddQuestRelatesToCompanionStory(
        string? companion = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new QuestRelatesToCompanionStory();
      component.m_Companion = BlueprintTool.GetRef<BlueprintUnitReference>(companion);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="CrusadeMissionComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CrusadeMissionComponent))]
    public QuestConfigurator AddCrusadeMissionComponent(
        int chapter = default)
    {
      var component = new CrusadeMissionComponent();
      component.Chapter = chapter;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="NobilityArmyRequestComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(NobilityArmyRequestComponent))]
    public QuestConfigurator AddNobilityArmyRequestComponent()
    {
      return AddComponent(new NobilityArmyRequestComponent());
    }

    /// <summary>
    /// Adds <see cref="NobilityBuildingsRequestComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(NobilityBuildingsRequestComponent))]
    public QuestConfigurator AddNobilityBuildingsRequestComponent()
    {
      return AddComponent(new NobilityBuildingsRequestComponent());
    }

    /// <summary>
    /// Adds <see cref="NobilityIncomeRequestComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(NobilityIncomeRequestComponent))]
    public QuestConfigurator AddNobilityIncomeRequestComponent()
    {
      return AddComponent(new NobilityIncomeRequestComponent());
    }

    /// <summary>
    /// Adds <see cref="NobilitySettlementsRequestComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(NobilitySettlementsRequestComponent))]
    public QuestConfigurator AddNobilitySettlementsRequestComponent()
    {
      return AddComponent(new NobilitySettlementsRequestComponent());
    }

    /// <summary>
    /// Adds <see cref="RoyalCourtLeaderRequestComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RoyalCourtLeaderRequestComponent))]
    public QuestConfigurator AddRoyalCourtLeaderRequestComponent()
    {
      return AddComponent(new RoyalCourtLeaderRequestComponent());
    }

    /// <summary>
    /// Adds <see cref="RoyalCourtMissionsRequestComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RoyalCourtMissionsRequestComponent))]
    public QuestConfigurator AddRoyalCourtMissionsRequestComponent()
    {
      return AddComponent(new RoyalCourtMissionsRequestComponent());
    }

    /// <summary>
    /// Adds <see cref="RoyalCourtRanksRequestComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RoyalCourtRanksRequestComponent))]
    public QuestConfigurator AddRoyalCourtRanksRequestComponent()
    {
      return AddComponent(new RoyalCourtRanksRequestComponent());
    }

    /// <summary>
    /// Adds <see cref="RoyalCourtVictoryRequestComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RoyalCourtVictoryRequestComponent))]
    public QuestConfigurator AddRoyalCourtVictoryRequestComponent()
    {
      return AddComponent(new RoyalCourtVictoryRequestComponent());
    }

    /// <summary>
    /// Adds <see cref="Experience"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(Experience))]
    public QuestConfigurator AddExperience(
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
  }
}
