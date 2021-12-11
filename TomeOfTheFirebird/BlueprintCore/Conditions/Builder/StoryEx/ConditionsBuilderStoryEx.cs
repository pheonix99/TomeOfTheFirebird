using BlueprintCore.Utils;
using Kingmaker.AreaLogic;
using Kingmaker.AreaLogic.QuestSystem;
using Kingmaker.Assets.Code.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.Assets.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Alignments;
using System;
using System.Collections.Generic;
#nullable enable
namespace BlueprintCore.Conditions.Builder.StoryEx
{
  /// <summary>
  /// Extension to <see cref="ConditionsBuilder"/> for conditions related to the story such as companion stories, quests,
  /// name changes, and etudes.
  /// </summary>
  /// <inheritdoc cref="ConditionsBuilder"/>
  public static class ConditionsBuilderStoryEx
  {
    //----- Auto Generated -----//

    /// <summary>
    /// Adds <see cref="CheckUnitSeeUnit"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CheckUnitSeeUnit))]
    public static ConditionsBuilder CheckUnitSeeUnit(
        this ConditionsBuilder builder,
        UnitEvaluator unit,
        UnitEvaluator target,
        bool negate = false)
    {
      builder.Validate(unit);
      builder.Validate(target);
    
      var element = ElementTool.Create<CheckUnitSeeUnit>();
      element.Unit = unit;
      element.Target = target;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="BarkBanterPlayed"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="banter"><see cref="Kingmaker.BarkBanters.BlueprintBarkBanter"/></param>
    [Generated]
    [Implements(typeof(BarkBanterPlayed))]
    public static ConditionsBuilder BarkBanterPlayed(
        this ConditionsBuilder builder,
        string? banter = null,
        bool negate = false)
    {
      var element = ElementTool.Create<BarkBanterPlayed>();
      element.m_Banter = BlueprintTool.GetRef<BlueprintBarkBanterReference>(banter);
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DialogSeen"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="dialog"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintDialog"/></param>
    [Generated]
    [Implements(typeof(DialogSeen))]
    public static ConditionsBuilder DialogSeen(
        this ConditionsBuilder builder,
        string? dialog = null,
        bool negate = false)
    {
      var element = ElementTool.Create<DialogSeen>();
      element.m_Dialog = BlueprintTool.GetRef<BlueprintDialogReference>(dialog);
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AlignmentCheck"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AlignmentCheck))]
    public static ConditionsBuilder AlignmentCheck(
        this ConditionsBuilder builder,
        AlignmentComponent alignment = default,
        bool negate = false)
    {
      var element = ElementTool.Create<AlignmentCheck>();
      element.Alignment = alignment;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AnotherEtudeOfGroupIsPlaying"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="group"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtudeConflictingGroup"/></param>
    [Generated]
    [Implements(typeof(AnotherEtudeOfGroupIsPlaying))]
    public static ConditionsBuilder AnotherEtudeOfGroupIsPlaying(
        this ConditionsBuilder builder,
        string? group = null,
        bool negate = false)
    {
      var element = ElementTool.Create<AnotherEtudeOfGroupIsPlaying>();
      element.m_Group = BlueprintTool.GetRef<BlueprintEtudeConflictingGroupReference>(group);
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AnswerListShown"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="answersList"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintAnswersList"/></param>
    [Generated]
    [Implements(typeof(AnswerListShown))]
    public static ConditionsBuilder AnswerListShown(
        this ConditionsBuilder builder,
        string? answersList = null,
        bool currentDialog = default,
        bool negate = false)
    {
      var element = ElementTool.Create<AnswerListShown>();
      element.m_AnswersList = BlueprintTool.GetRef<BlueprintAnswersListReference>(answersList);
      element.CurrentDialog = currentDialog;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AnswerSelected"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="answer"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintAnswer"/></param>
    [Generated]
    [Implements(typeof(AnswerSelected))]
    public static ConditionsBuilder AnswerSelected(
        this ConditionsBuilder builder,
        string? answer = null,
        bool currentDialog = default,
        bool negate = false)
    {
      var element = ElementTool.Create<AnswerSelected>();
      element.m_Answer = BlueprintTool.GetRef<BlueprintAnswerReference>(answer);
      element.CurrentDialog = currentDialog;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ChangeableDynamicIsLoaded"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ChangeableDynamicIsLoaded))]
    public static ConditionsBuilder ChangeableDynamicIsLoaded(
        this ConditionsBuilder builder,
        SceneReference scene,
        bool negate = false)
    {
      builder.Validate(scene);
    
      var element = ElementTool.Create<ChangeableDynamicIsLoaded>();
      element.Scene = scene;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CheckFailed"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="check"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintCheck"/></param>
    [Generated]
    [Implements(typeof(CheckFailed))]
    public static ConditionsBuilder CheckFailed(
        this ConditionsBuilder builder,
        string? check = null,
        bool negate = false)
    {
      var element = ElementTool.Create<CheckFailed>();
      element.m_Check = BlueprintTool.GetRef<BlueprintCheckReference>(check);
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CheckPassed"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="check"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintCheck"/></param>
    [Generated]
    [Implements(typeof(CheckPassed))]
    public static ConditionsBuilder CheckPassed(
        this ConditionsBuilder builder,
        string? check = null,
        bool negate = false)
    {
      var element = ElementTool.Create<CheckPassed>();
      element.m_Check = BlueprintTool.GetRef<BlueprintCheckReference>(check);
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CompanionStoryUnlocked"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="companionStory"><see cref="Kingmaker.Blueprints.BlueprintCompanionStory"/></param>
    [Generated]
    [Implements(typeof(CompanionStoryUnlocked))]
    public static ConditionsBuilder CompanionStoryUnlocked(
        this ConditionsBuilder builder,
        string? companionStory = null,
        bool negate = false)
    {
      var element = ElementTool.Create<CompanionStoryUnlocked>();
      element.m_CompanionStory = BlueprintTool.GetRef<BlueprintCompanionStoryReference>(companionStory);
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CueSeen"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="cue"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintCueBase"/></param>
    [Generated]
    [Implements(typeof(CueSeen))]
    public static ConditionsBuilder CueSeen(
        this ConditionsBuilder builder,
        string? cue = null,
        bool currentDialog = default,
        bool negate = false)
    {
      var element = ElementTool.Create<CueSeen>();
      element.m_Cue = BlueprintTool.GetRef<BlueprintCueBaseReference>(cue);
      element.CurrentDialog = currentDialog;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CurrentChapter"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CurrentChapter))]
    public static ConditionsBuilder CurrentChapter(
        this ConditionsBuilder builder,
        int chapter = default,
        bool negate = false)
    {
      var element = ElementTool.Create<CurrentChapter>();
      element.Chapter = chapter;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CutsceneQueueState"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CutsceneQueueState))]
    public static ConditionsBuilder CutsceneQueueState(
        this ConditionsBuilder builder,
        bool first = default,
        bool last = default,
        bool negate = false)
    {
      var element = ElementTool.Create<CutsceneQueueState>();
      element.First = first;
      element.Last = last;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DayOfTheMonth"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DayOfTheMonth))]
    public static ConditionsBuilder DayOfTheMonth(
        this ConditionsBuilder builder,
        int day = default,
        bool negate = false)
    {
      var element = ElementTool.Create<DayOfTheMonth>();
      element.Day = day;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DayOfTheWeek"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DayOfTheWeek))]
    public static ConditionsBuilder DayOfTheWeek(
        this ConditionsBuilder builder,
        DayOfWeek day = default,
        bool negate = false)
    {
      var element = ElementTool.Create<DayOfTheWeek>();
      element.Day = day;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DayTime"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DayTime))]
    public static ConditionsBuilder DayTime(
        this ConditionsBuilder builder,
        TimeOfDay time = default,
        bool negate = false)
    {
      var element = ElementTool.Create<DayTime>();
      element.Time = time;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="EtudeStatus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="etude"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude"/></param>
    [Generated]
    [Implements(typeof(EtudeStatus))]
    public static ConditionsBuilder EtudeStatus(
        this ConditionsBuilder builder,
        string? etude = null,
        bool notStarted = default,
        bool started = default,
        bool playing = default,
        bool completionInProgress = default,
        bool completed = default,
        bool negate = false)
    {
      var element = ElementTool.Create<EtudeStatus>();
      element.m_Etude = BlueprintTool.GetRef<BlueprintEtudeReference>(etude);
      element.NotStarted = notStarted;
      element.Started = started;
      element.Playing = playing;
      element.CompletionInProgress = completionInProgress;
      element.Completed = completed;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="FlagInRange"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="flag"><see cref="Kingmaker.Blueprints.BlueprintUnlockableFlag"/></param>
    [Generated]
    [Implements(typeof(FlagInRange))]
    public static ConditionsBuilder FlagInRange(
        this ConditionsBuilder builder,
        string? flag = null,
        int minValue = default,
        int maxValue = default,
        bool negate = false)
    {
      var element = ElementTool.Create<FlagInRange>();
      element.m_Flag = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(flag);
      element.MinValue = minValue;
      element.MaxValue = maxValue;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="FlagUnlocked"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="conditionFlag"><see cref="Kingmaker.Blueprints.BlueprintUnlockableFlag"/></param>
    [Generated]
    [Implements(typeof(FlagUnlocked))]
    public static ConditionsBuilder FlagUnlocked(
        this ConditionsBuilder builder,
        string? conditionFlag = null,
        bool exceptSpecifiedValues = default,
        List<int>? specifiedValues = null,
        bool negate = false)
    {
      var element = ElementTool.Create<FlagUnlocked>();
      element.m_ConditionFlag = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(conditionFlag);
      element.ExceptSpecifiedValues = exceptSpecifiedValues;
      element.SpecifiedValues = specifiedValues;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsLegendPathSelected"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IsLegendPathSelected))]
    public static ConditionsBuilder IsLegendPathSelected(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<IsLegendPathSelected>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="MonthFromList"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MonthFromList))]
    public static ConditionsBuilder MonthFromList(
        this ConditionsBuilder builder,
        int[]? months = null,
        bool negate = false)
    {
      var element = ElementTool.Create<MonthFromList>();
      element.Months = months;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ObjectiveStatus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="questObjective"><see cref="Kingmaker.Blueprints.Quests.BlueprintQuestObjective"/></param>
    [Generated]
    [Implements(typeof(ObjectiveStatus))]
    public static ConditionsBuilder ObjectiveStatus(
        this ConditionsBuilder builder,
        string? questObjective = null,
        QuestObjectiveState state = default,
        bool negate = false)
    {
      var element = ElementTool.Create<ObjectiveStatus>();
      element.m_QuestObjective = BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(questObjective);
      element.State = state;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PlayerAlignmentIs"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PlayerAlignmentIs))]
    public static ConditionsBuilder PlayerAlignmentIs(
        this ConditionsBuilder builder,
        AlignmentMaskType alignment = default,
        bool negate = false)
    {
      var element = ElementTool.Create<PlayerAlignmentIs>();
      element.Alignment = alignment;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PlayerHasNoCharactersOnRoster"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PlayerHasNoCharactersOnRoster))]
    public static ConditionsBuilder PlayerHasNoCharactersOnRoster(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<PlayerHasNoCharactersOnRoster>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PlayerHasRecruitsOnRoster"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PlayerHasRecruitsOnRoster))]
    public static ConditionsBuilder PlayerHasRecruitsOnRoster(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<PlayerHasRecruitsOnRoster>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PlayerSignificantClassIs"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    /// <param name="characterClassGroup"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClassGroup"/></param>
    [Generated]
    [Implements(typeof(PlayerSignificantClassIs))]
    public static ConditionsBuilder PlayerSignificantClassIs(
        this ConditionsBuilder builder,
        bool checkGroup = default,
        string? characterClass = null,
        string? characterClassGroup = null,
        bool negate = false)
    {
      var element = ElementTool.Create<PlayerSignificantClassIs>();
      element.CheckGroup = checkGroup;
      element.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      element.m_CharacterClassGroup = BlueprintTool.GetRef<BlueprintCharacterClassGroupReference>(characterClassGroup);
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PlayerTopClassIs"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    /// <param name="characterClassGroup"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClassGroup"/></param>
    [Generated]
    [Implements(typeof(PlayerTopClassIs))]
    public static ConditionsBuilder PlayerTopClassIs(
        this ConditionsBuilder builder,
        bool checkGroup = default,
        string? characterClass = null,
        string? characterClassGroup = null,
        bool negate = false)
    {
      var element = ElementTool.Create<PlayerTopClassIs>();
      element.CheckGroup = checkGroup;
      element.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      element.m_CharacterClassGroup = BlueprintTool.GetRef<BlueprintCharacterClassGroupReference>(characterClassGroup);
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="QuestStatus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="quest"><see cref="Kingmaker.Blueprints.Quests.BlueprintQuest"/></param>
    [Generated]
    [Implements(typeof(QuestStatus))]
    public static ConditionsBuilder QuestStatus(
        this ConditionsBuilder builder,
        string? quest = null,
        QuestState state = default,
        bool negate = false)
    {
      var element = ElementTool.Create<QuestStatus>();
      element.m_Quest = BlueprintTool.GetRef<BlueprintQuestReference>(quest);
      element.State = state;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RomanceLocked"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="romance"><see cref="Kingmaker.Blueprints.BlueprintRomanceCounter"/></param>
    [Generated]
    [Implements(typeof(RomanceLocked))]
    public static ConditionsBuilder RomanceLocked(
        this ConditionsBuilder builder,
        string? romance = null,
        bool negate = false)
    {
      var element = ElementTool.Create<RomanceLocked>();
      element.m_Romance = BlueprintTool.GetRef<BlueprintRomanceCounterReference>(romance);
      element.Not = negate;
      return builder.Add(element);
    }
  }
}
