using BlueprintCore.Utils;
using Kingmaker.AreaLogic;
using Kingmaker.AreaLogic.Etudes;
using Kingmaker.Blueprints;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Designers.EventConditionActionSystem.NamedParameters;
using Kingmaker.Designers.Quests.Common;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Localization;
using Kingmaker.UI;
using Kingmaker.UnitLogic.Alignments;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace BlueprintCore.Actions.Builder.StoryEx
{
  /// <summary>
  /// Extension to <see cref="ActionsBuilder"/> for actions related to the story such as companion stories, quests,
  /// name changes, and etudes.
  /// </summary>
  /// <inheritdoc cref="ActionsBuilder"/>
  public static class ActionsBuilderStoryEx
  {
    //----- Kingmaker.Designers.EventConditionActionSystem.Actions -----//

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.CompleteEtude">CompleteEtude</see>
    /// </summary>
    /// 
    /// <param name="etude"><see cref="BlueprintEtude"/></param>
    [Implements(typeof(CompleteEtude))]
    public static ActionsBuilder CompleteEtude(
        this ActionsBuilder builder, string etude, BlueprintEvaluator? evaluator = null)
    {
      var completeEtude = ElementTool.Create<CompleteEtude>();
      completeEtude.Etude = BlueprintTool.GetRef<BlueprintEtudeReference>(etude);
      if (evaluator != null)
      {
        completeEtude.EtudeEvaluator = evaluator;
        completeEtude.Evaluate = true;
      }
      return builder.Add(completeEtude);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.ChangeRomance">ChangeRomance</see>
    /// </summary>
    /// 
    /// <param name="romance"><see cref="BlueprintRomanceCounter"/></param>
    [Implements(typeof(ChangeRomance))]
    public static ActionsBuilder ChangeRomance(
       this ActionsBuilder builder, string romance, IntEvaluator value)
    {
      builder.Validate(value);

      var changeRomance = ElementTool.Create<ChangeRomance>();
      changeRomance.m_Romance = BlueprintTool.GetRef<BlueprintRomanceCounterReference>(romance);
      changeRomance.ValueEvaluator = value;
      return builder.Add(changeRomance);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.ChangeUnitName">ChangeUnitName</see>
    /// </summary>
    [Implements(typeof(ChangeUnitName))]
    public static ActionsBuilder ChangeUnitName(
        this ActionsBuilder builder,
        UnitEvaluator unit,
        LocalizedString name,
        bool appendName = false)
    {
      builder.Validate(unit);

      var changeName = ElementTool.Create<ChangeUnitName>();
      changeName.Unit = unit;
      changeName.NewName = name;
      changeName.AddToTheName = appendName;
      return builder.Add(changeName);
    }

    /// <inheritdoc cref="ChangeUnitName"/>
    [Implements(typeof(ChangeUnitName))]
    public static ActionsBuilder ResetUnitName(
        this ActionsBuilder builder, UnitEvaluator unit)
    {
      builder.Validate(unit);

      var changeName = ElementTool.Create<ChangeUnitName>();
      changeName.Unit = unit;
      changeName.ReturnTheOldName = true;
      return builder.Add(changeName);
    }

    //----- Auto Generated -----//

    /// <summary>
    /// Adds <see cref="AlignmentSelector"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AlignmentSelector))]
    public static ActionsBuilder AlignmentSelector(
        this ActionsBuilder builder,
        AlignmentSelector.ActionAndCondition lawfulGood,
        AlignmentSelector.ActionAndCondition neutralGood,
        AlignmentSelector.ActionAndCondition chaoticGood,
        AlignmentSelector.ActionAndCondition lawfulNeutral,
        AlignmentSelector.ActionAndCondition trueNeutral,
        AlignmentSelector.ActionAndCondition chaoticNeutral,
        AlignmentSelector.ActionAndCondition lawfulEvil,
        AlignmentSelector.ActionAndCondition neutralEvil,
        AlignmentSelector.ActionAndCondition chaoticEvil,
        Dictionary<Alignment,AlignmentSelector.ActionAndCondition> actionsByAlignment,
        bool selectClosest = default)
    {
      builder.Validate(actionsByAlignment);
    
      var element = ElementTool.Create<AlignmentSelector>();
      element.SelectClosest = selectClosest;
      element.LawfulGood = lawfulGood;
      element.NeutralGood = neutralGood;
      element.ChaoticGood = chaoticGood;
      element.LawfulNeutral = lawfulNeutral;
      element.TrueNeutral = trueNeutral;
      element.ChaoticNeutral = chaoticNeutral;
      element.LawfulEvil = lawfulEvil;
      element.NeutralEvil = neutralEvil;
      element.ChaoticEvil = chaoticEvil;
      element.m_ActionsByAlignment = actionsByAlignment;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DismissAllCompanions"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DismissAllCompanions))]
    public static ActionsBuilder DismissAllCompanions(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<DismissAllCompanions>());
    }

    /// <summary>
    /// Adds <see cref="GiveObjective"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="objective"><see cref="Kingmaker.Blueprints.Quests.BlueprintQuestObjective"/></param>
    [Generated]
    [Implements(typeof(GiveObjective))]
    public static ActionsBuilder GiveObjective(
        this ActionsBuilder builder,
        string? objective = null)
    {
      var element = ElementTool.Create<GiveObjective>();
      element.m_Objective = BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(objective);
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="HideUnit"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(HideUnit))]
    public static ActionsBuilder HideUnit(
        this ActionsBuilder builder,
        UnitEvaluator target,
        bool unhide = default,
        bool fade = default)
    {
      builder.Validate(target);
    
      var element = ElementTool.Create<HideUnit>();
      element.Target = target;
      element.Unhide = unhide;
      element.Fade = fade;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="HideWeapons"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(HideWeapons))]
    public static ActionsBuilder HideWeapons(
        this ActionsBuilder builder,
        UnitEvaluator target,
        bool hide = default)
    {
      builder.Validate(target);
    
      var element = ElementTool.Create<HideWeapons>();
      element.Target = target;
      element.Hide = hide;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IncrementFlagValue"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="flag"><see cref="Kingmaker.Blueprints.BlueprintUnlockableFlag"/></param>
    [Generated]
    [Implements(typeof(IncrementFlagValue))]
    public static ActionsBuilder IncrementFlagValue(
        this ActionsBuilder builder,
        IntEvaluator value,
        string? flag = null,
        bool unlockIfNot = default)
    {
      builder.Validate(value);
    
      var element = ElementTool.Create<IncrementFlagValue>();
      element.m_Flag = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(flag);
      element.Value = value;
      element.UnlockIfNot = unlockIfNot;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="InterruptAllActions"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(InterruptAllActions))]
    public static ActionsBuilder InterruptAllActions(
        this ActionsBuilder builder,
        UnitEvaluator unit)
    {
      builder.Validate(unit);
    
      var element = ElementTool.Create<InterruptAllActions>();
      element.m_Unit = unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="LockAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LockAlignment))]
    public static ActionsBuilder LockAlignment(
        this ActionsBuilder builder,
        UnitEvaluator unit,
        AlignmentMaskType alignmentMask = default,
        Alignment targetAlignment = default)
    {
      builder.Validate(unit);
    
      var element = ElementTool.Create<LockAlignment>();
      element.Unit = unit;
      element.AlignmentMask = alignmentMask;
      element.TargetAlignment = targetAlignment;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="LockFlag"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="flag"><see cref="Kingmaker.Blueprints.BlueprintUnlockableFlag"/></param>
    [Generated]
    [Implements(typeof(LockFlag))]
    public static ActionsBuilder LockFlag(
        this ActionsBuilder builder,
        string? flag = null)
    {
      var element = ElementTool.Create<LockFlag>();
      element.m_Flag = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(flag);
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="LockRomance"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="romance"><see cref="Kingmaker.Blueprints.BlueprintRomanceCounter"/></param>
    [Generated]
    [Implements(typeof(LockRomance))]
    public static ActionsBuilder LockRomance(
        this ActionsBuilder builder,
        string? romance = null)
    {
      var element = ElementTool.Create<LockRomance>();
      element.m_Romance = BlueprintTool.GetRef<BlueprintRomanceCounterReference>(romance);
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="MarkAnswersSelected"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="answers"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintAnswer"/></param>
    [Generated]
    [Implements(typeof(MarkAnswersSelected))]
    public static ActionsBuilder MarkAnswersSelected(
        this ActionsBuilder builder,
        string[]? answers = null)
    {
      var element = ElementTool.Create<MarkAnswersSelected>();
      element.m_Answers = answers.Select(name => BlueprintTool.GetRef<BlueprintAnswerReference>(name)).ToArray();
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="MarkCuesSeen"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="cues"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintCueBase"/></param>
    [Generated]
    [Implements(typeof(MarkCuesSeen))]
    public static ActionsBuilder MarkCuesSeen(
        this ActionsBuilder builder,
        string[]? cues = null)
    {
      var element = ElementTool.Create<MarkCuesSeen>();
      element.m_Cues = cues.Select(name => BlueprintTool.GetRef<BlueprintCueBaseReference>(name)).ToArray();
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="MoveAzataIslandToLocation"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="globalMap"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMap"/></param>
    /// <param name="location"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMapPoint"/></param>
    [Generated]
    [Implements(typeof(MoveAzataIslandToLocation))]
    public static ActionsBuilder MoveAzataIslandToLocation(
        this ActionsBuilder builder,
        string? globalMap = null,
        string? location = null)
    {
      var element = ElementTool.Create<MoveAzataIslandToLocation>();
      element.m_GlobalMap = BlueprintTool.GetRef<BlueprintGlobalMap.Reference>(globalMap);
      element.m_Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(location);
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="MoveAzataIslandToNearestCrossroad"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="globalMap"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMap"/></param>
    [Generated]
    [Implements(typeof(MoveAzataIslandToNearestCrossroad))]
    public static ActionsBuilder MoveAzataIslandToNearestCrossroad(
        this ActionsBuilder builder,
        string? globalMap = null)
    {
      var element = ElementTool.Create<MoveAzataIslandToNearestCrossroad>();
      element.m_GlobalMap = BlueprintTool.GetRef<BlueprintGlobalMap.Reference>(globalMap);
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="OverrideUnitReturnPosition"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(OverrideUnitReturnPosition))]
    public static ActionsBuilder OverrideUnitReturnPosition(
        this ActionsBuilder builder,
        UnitEvaluator unit,
        PositionEvaluator position,
        FloatEvaluator orientation)
    {
      builder.Validate(unit);
      builder.Validate(position);
      builder.Validate(orientation);
    
      var element = ElementTool.Create<OverrideUnitReturnPosition>();
      element.Unit = unit;
      element.Position = position;
      element.Orientation = orientation;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PartyMembersAttach"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PartyMembersAttach))]
    public static ActionsBuilder PartyMembersAttach(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<PartyMembersAttach>());
    }

    /// <summary>
    /// Adds <see cref="PartyMembersDetach"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="detachAllExcept"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(PartyMembersDetach))]
    public static ActionsBuilder PartyMembersDetach(
        this ActionsBuilder builder,
        string[]? detachAllExcept = null,
        bool restrictPartySize = default,
        int partySize = default,
        ActionsBuilder? afterDetach = null)
    {
      var element = ElementTool.Create<PartyMembersDetach>();
      element.m_DetachAllExcept = detachAllExcept.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name)).ToArray();
      element.m_RestrictPartySize = restrictPartySize;
      element.m_PartySize = partySize;
      element.AfterDetach = afterDetach?.Build() ?? Constants.Empty.Actions;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PartyMembersDetachEvaluated"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PartyMembersDetachEvaluated))]
    public static ActionsBuilder PartyMembersDetachEvaluated(
        this ActionsBuilder builder,
        UnitEvaluator[]? detachThese = null,
        ActionsBuilder? afterDetach = null,
        bool restrictPartySize = default,
        int partySize = default)
    {
      builder.Validate(detachThese);
    
      var element = ElementTool.Create<PartyMembersDetachEvaluated>();
      element.DetachThese = detachThese;
      element.AfterDetach = afterDetach?.Build() ?? Constants.Empty.Actions;
      element.m_RestrictPartySize = restrictPartySize;
      element.m_PartySize = partySize;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PartyMembersSwapAttachedAndDetached"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PartyMembersSwapAttachedAndDetached))]
    public static ActionsBuilder PartyMembersSwapAttachedAndDetached(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<PartyMembersSwapAttachedAndDetached>());
    }

    /// <summary>
    /// Adds <see cref="Recruit"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(Recruit))]
    public static ActionsBuilder Recruit(
        this ActionsBuilder builder,
        Recruit.RecruitData[]? recruited = null,
        bool addToParty = default,
        bool matchPlayerXpExactly = default,
        ActionsBuilder? onRecruit = null,
        ActionsBuilder? onRecruitImmediate = null)
    {
      builder.Validate(recruited);
    
      var element = ElementTool.Create<Recruit>();
      element.Recruited = recruited;
      element.AddToParty = addToParty;
      element.MatchPlayerXpExactly = matchPlayerXpExactly;
      element.OnRecruit = onRecruit?.Build() ?? Constants.Empty.Actions;
      element.OnRecruitImmediate = onRecruitImmediate?.Build() ?? Constants.Empty.Actions;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RecruitInactive"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="companionBlueprint"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(RecruitInactive))]
    public static ActionsBuilder RecruitInactive(
        this ActionsBuilder builder,
        string? companionBlueprint = null,
        ActionsBuilder? onRecruit = null)
    {
      var element = ElementTool.Create<RecruitInactive>();
      element.m_CompanionBlueprint = BlueprintTool.GetRef<BlueprintUnitReference>(companionBlueprint);
      element.OnRecruit = onRecruit?.Build() ?? Constants.Empty.Actions;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RelockInteraction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RelockInteraction))]
    public static ActionsBuilder RelockInteraction(
        this ActionsBuilder builder,
        MapObjectEvaluator mapObject)
    {
      builder.Validate(mapObject);
    
      var element = ElementTool.Create<RelockInteraction>();
      element.MapObject = mapObject;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveMythicLevels"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RemoveMythicLevels))]
    public static ActionsBuilder RemoveMythicLevels(
        this ActionsBuilder builder,
        int levels = default)
    {
      var element = ElementTool.Create<RemoveMythicLevels>();
      element.Levels = levels;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ReplaceAllMythicLevelsWithMythicHeroLevels"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ReplaceAllMythicLevelsWithMythicHeroLevels))]
    public static ActionsBuilder ReplaceAllMythicLevelsWithMythicHeroLevels(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ReplaceAllMythicLevelsWithMythicHeroLevels>());
    }

    /// <summary>
    /// Adds <see cref="ReplaceFeatureInProgression"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="remove"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    /// <param name="add"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(ReplaceFeatureInProgression))]
    public static ActionsBuilder ReplaceFeatureInProgression(
        this ActionsBuilder builder,
        UnitEvaluator unit,
        string? remove = null,
        string? add = null)
    {
      builder.Validate(unit);
    
      var element = ElementTool.Create<ReplaceFeatureInProgression>();
      element.Unit = unit;
      element.m_Remove = BlueprintTool.GetRef<BlueprintFeatureReference>(remove);
      element.m_Add = BlueprintTool.GetRef<BlueprintFeatureReference>(add);
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ResetQuest"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="quest"><see cref="Kingmaker.Blueprints.Quests.BlueprintQuest"/></param>
    /// <param name="objectiveToStart"><see cref="Kingmaker.Blueprints.Quests.BlueprintQuestObjective"/></param>
    /// <param name="objectivesToReset"><see cref="Kingmaker.Blueprints.Quests.BlueprintQuestObjective"/></param>
    [Generated]
    [Implements(typeof(ResetQuest))]
    public static ActionsBuilder ResetQuest(
        this ActionsBuilder builder,
        string? quest = null,
        string? objectiveToStart = null,
        string[]? objectivesToReset = null)
    {
      var element = ElementTool.Create<ResetQuest>();
      element.m_Quest = BlueprintTool.GetRef<BlueprintQuestReference>(quest);
      element.m_ObjectiveToStart = BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(objectiveToStart);
      element.m_ObjectivesToReset = objectivesToReset.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name)).ToArray();
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ResetQuestObjective"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="objective"><see cref="Kingmaker.Blueprints.Quests.BlueprintQuestObjective"/></param>
    [Generated]
    [Implements(typeof(ResetQuestObjective))]
    public static ActionsBuilder ResetQuestObjective(
        this ActionsBuilder builder,
        string? objective = null)
    {
      var element = ElementTool.Create<ResetQuestObjective>();
      element.m_Objective = BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(objective);
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RespecCompanion"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RespecCompanion))]
    public static ActionsBuilder RespecCompanion(
        this ActionsBuilder builder,
        bool forFree = default,
        bool matchPlayerXpExactly = default)
    {
      var element = ElementTool.Create<RespecCompanion>();
      element.ForFree = forFree;
      element.MatchPlayerXpExactly = matchPlayerXpExactly;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RomanceSetMaximum"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="romance"><see cref="Kingmaker.Blueprints.BlueprintRomanceCounter"/></param>
    [Generated]
    [Implements(typeof(RomanceSetMaximum))]
    public static ActionsBuilder RomanceSetMaximum(
        this ActionsBuilder builder,
        IntEvaluator valueEvaluator,
        string? romance = null)
    {
      builder.Validate(valueEvaluator);
    
      var element = ElementTool.Create<RomanceSetMaximum>();
      element.m_Romance = BlueprintTool.GetRef<BlueprintRomanceCounterReference>(romance);
      element.ValueEvaluator = valueEvaluator;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RomanceSetMinimum"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="romance"><see cref="Kingmaker.Blueprints.BlueprintRomanceCounter"/></param>
    [Generated]
    [Implements(typeof(RomanceSetMinimum))]
    public static ActionsBuilder RomanceSetMinimum(
        this ActionsBuilder builder,
        IntEvaluator valueEvaluator,
        string? romance = null)
    {
      builder.Validate(valueEvaluator);
    
      var element = ElementTool.Create<RomanceSetMinimum>();
      element.m_Romance = BlueprintTool.GetRef<BlueprintRomanceCounterReference>(romance);
      element.ValueEvaluator = valueEvaluator;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SetDialogPosition"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SetDialogPosition))]
    public static ActionsBuilder SetDialogPosition(
        this ActionsBuilder builder,
        PositionEvaluator position)
    {
      builder.Validate(position);
    
      var element = ElementTool.Create<SetDialogPosition>();
      element.Position = position;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SetMythicLevelForMainCharacter"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SetMythicLevelForMainCharacter))]
    public static ActionsBuilder SetMythicLevelForMainCharacter(
        this ActionsBuilder builder,
        int desireLevel = default)
    {
      var element = ElementTool.Create<SetMythicLevelForMainCharacter>();
      element.DesireLevel = desireLevel;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SetObjectiveStatus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="objective"><see cref="Kingmaker.Blueprints.Quests.BlueprintQuestObjective"/></param>
    [Generated]
    [Implements(typeof(SetObjectiveStatus))]
    public static ActionsBuilder SetObjectiveStatus(
        this ActionsBuilder builder,
        SummonPoolCountTrigger.ObjectiveStatus status = default,
        string? objective = null,
        bool startObjectiveIfNone = default)
    {
      var element = ElementTool.Create<SetObjectiveStatus>();
      element.Status = status;
      element.m_Objective = BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(objective);
      element.StartObjectiveIfNone = startObjectiveIfNone;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SetPortrait"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="portrait"><see cref="Kingmaker.Blueprints.BlueprintPortrait"/></param>
    [Generated]
    [Implements(typeof(SetPortrait))]
    public static ActionsBuilder SetPortrait(
        this ActionsBuilder builder,
        UnitEvaluator unit,
        string? portrait = null)
    {
      builder.Validate(unit);
    
      var element = ElementTool.Create<SetPortrait>();
      element.Unit = unit;
      element.m_Portrait = BlueprintTool.GetRef<BlueprintPortraitReference>(portrait);
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ShiftAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ShiftAlignment))]
    public static ActionsBuilder ShiftAlignment(
        this ActionsBuilder builder,
        UnitEvaluator unit,
        IntEvaluator amount,
        AlignmentShiftDirection alignment = default)
    {
      builder.Validate(unit);
      builder.Validate(amount);
    
      var element = ElementTool.Create<ShiftAlignment>();
      element.Unit = unit;
      element.Alignment = alignment;
      element.Amount = amount;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ShowDialogBox"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ShowDialogBox))]
    public static ActionsBuilder ShowDialogBox(
        this ActionsBuilder builder,
        ParametrizedContextSetter parameters,
        LocalizedString? text = null,
        ActionsBuilder? onAccept = null,
        ActionsBuilder? onCancel = null)
    {
      builder.Validate(text);
      builder.Validate(parameters);
    
      var element = ElementTool.Create<ShowDialogBox>();
      element.Text = text ?? Constants.Empty.String;
      element.Parameters = parameters;
      element.OnAccept = onAccept?.Build() ?? Constants.Empty.Actions;
      element.OnCancel = onCancel?.Build() ?? Constants.Empty.Actions;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ShowMessageBox"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ShowMessageBox))]
    public static ActionsBuilder ShowMessageBox(
        this ActionsBuilder builder,
        LocalizedString? text = null,
        ActionsBuilder? onClose = null,
        int waitTime = default)
    {
      builder.Validate(text);
    
      var element = ElementTool.Create<ShowMessageBox>();
      element.Text = text ?? Constants.Empty.String;
      element.OnClose = onClose?.Build() ?? Constants.Empty.Actions;
      element.WaitTime = waitTime;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ShowUIWarning"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ShowUIWarning))]
    public static ActionsBuilder ShowUIWarning(
        this ActionsBuilder builder,
        WarningNotificationType type = default,
        LocalizedString? stringValue = null)
    {
      builder.Validate(stringValue);
    
      var element = ElementTool.Create<ShowUIWarning>();
      element.Type = type;
      element.String = stringValue ?? Constants.Empty.String;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SplitUnitGroup"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SplitUnitGroup))]
    public static ActionsBuilder SplitUnitGroup(
        this ActionsBuilder builder,
        UnitEvaluator target)
    {
      builder.Validate(target);
    
      var element = ElementTool.Create<SplitUnitGroup>();
      element.Target = target;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="StartCombat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(StartCombat))]
    public static ActionsBuilder StartCombat(
        this ActionsBuilder builder,
        UnitEvaluator unit1,
        UnitEvaluator unit2)
    {
      builder.Validate(unit1);
      builder.Validate(unit2);
    
      var element = ElementTool.Create<StartCombat>();
      element.Unit1 = unit1;
      element.Unit2 = unit2;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="StartDialog"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="dialogue"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintDialog"/></param>
    [Generated]
    [Implements(typeof(StartDialog))]
    public static ActionsBuilder StartDialog(
        this ActionsBuilder builder,
        UnitEvaluator dialogueOwner,
        BlueprintEvaluator dialogEvaluator,
        string? dialogue = null,
        LocalizedString? speakerName = null)
    {
      builder.Validate(dialogueOwner);
      builder.Validate(dialogEvaluator);
      builder.Validate(speakerName);
    
      var element = ElementTool.Create<StartDialog>();
      element.DialogueOwner = dialogueOwner;
      element.m_Dialogue = BlueprintTool.GetRef<BlueprintDialogReference>(dialogue);
      element.DialogEvaluator = dialogEvaluator;
      element.SpeakerName = speakerName ?? Constants.Empty.String;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="StartEncounter"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="encounter"><see cref="Kingmaker.RandomEncounters.Settings.BlueprintRandomEncounter"/></param>
    [Generated]
    [Implements(typeof(StartEncounter))]
    public static ActionsBuilder StartEncounter(
        this ActionsBuilder builder,
        string? encounter = null)
    {
      var element = ElementTool.Create<StartEncounter>();
      element.m_Encounter = BlueprintTool.GetRef<BlueprintRandomEncounterReference>(encounter);
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="StartEtude"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="etude"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude"/></param>
    [Generated]
    [Implements(typeof(StartEtude))]
    public static ActionsBuilder StartEtude(
        this ActionsBuilder builder,
        BlueprintEvaluator etudeEvaluator,
        string? etude = null,
        bool evaluate = default)
    {
      builder.Validate(etudeEvaluator);
    
      var element = ElementTool.Create<StartEtude>();
      element.Etude = BlueprintTool.GetRef<BlueprintEtudeReference>(etude);
      element.EtudeEvaluator = etudeEvaluator;
      element.Evaluate = evaluate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SwitchAzataIsland"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="globalMap"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMap"/></param>
    [Generated]
    [Implements(typeof(SwitchAzataIsland))]
    public static ActionsBuilder SwitchAzataIsland(
        this ActionsBuilder builder,
        string? globalMap = null,
        bool isOn = default)
    {
      var element = ElementTool.Create<SwitchAzataIsland>();
      element.m_GlobalMap = BlueprintTool.GetRef<BlueprintGlobalMap.Reference>(globalMap);
      element.IsOn = isOn;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SwitchChapter"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SwitchChapter))]
    public static ActionsBuilder SwitchChapter(
        this ActionsBuilder builder,
        int chapter = default)
    {
      var element = ElementTool.Create<SwitchChapter>();
      element.Chapter = chapter;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SwitchDoor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SwitchDoor))]
    public static ActionsBuilder SwitchDoor(
        this ActionsBuilder builder,
        MapObjectEvaluator door,
        bool unlockIfLocked = default,
        bool closeIfAlreadyOpen = default,
        bool openIfAlreadyClosed = default)
    {
      builder.Validate(door);
    
      var element = ElementTool.Create<SwitchDoor>();
      element.Door = door;
      element.UnlockIfLocked = unlockIfLocked;
      element.CloseIfAlreadyOpen = closeIfAlreadyOpen;
      element.OpenIfAlreadyClosed = openIfAlreadyClosed;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SwitchFaction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="faction"><see cref="Kingmaker.Blueprints.BlueprintFaction"/></param>
    [Generated]
    [Implements(typeof(SwitchFaction))]
    public static ActionsBuilder SwitchFaction(
        this ActionsBuilder builder,
        UnitEvaluator target,
        string? faction = null,
        bool includeGroup = default,
        bool resetAllRelations = default)
    {
      builder.Validate(target);
    
      var element = ElementTool.Create<SwitchFaction>();
      element.Target = target;
      element.m_Faction = BlueprintTool.GetRef<BlueprintFactionReference>(faction);
      element.IncludeGroup = includeGroup;
      element.ResetAllRelations = resetAllRelations;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SwitchInteraction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SwitchInteraction))]
    public static ActionsBuilder SwitchInteraction(
        this ActionsBuilder builder,
        MapObjectEvaluator mapObject,
        bool enableIfAlreadyDisabled = default,
        bool disableIfAlreadyEnabled = default)
    {
      builder.Validate(mapObject);
    
      var element = ElementTool.Create<SwitchInteraction>();
      element.MapObject = mapObject;
      element.EnableIfAlreadyDisabled = enableIfAlreadyDisabled;
      element.DisableIfAlreadyEnabled = disableIfAlreadyEnabled;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SwitchRoaming"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SwitchRoaming))]
    public static ActionsBuilder SwitchRoaming(
        this ActionsBuilder builder,
        UnitEvaluator unit,
        bool disable = default)
    {
      builder.Validate(unit);
    
      var element = ElementTool.Create<SwitchRoaming>();
      element.Unit = unit;
      element.Disable = disable;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SwitchToEnemy"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="factionToAttack"><see cref="Kingmaker.Blueprints.BlueprintFaction"/></param>
    [Generated]
    [Implements(typeof(SwitchToEnemy))]
    public static ActionsBuilder SwitchToEnemy(
        this ActionsBuilder builder,
        UnitEvaluator target,
        string? factionToAttack = null)
    {
      builder.Validate(target);
    
      var element = ElementTool.Create<SwitchToEnemy>();
      element.Target = target;
      element.m_FactionToAttack = BlueprintTool.GetRef<BlueprintFactionReference>(factionToAttack);
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SwitchToNeutral"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="faction"><see cref="Kingmaker.Blueprints.BlueprintFaction"/></param>
    [Generated]
    [Implements(typeof(SwitchToNeutral))]
    public static ActionsBuilder SwitchToNeutral(
        this ActionsBuilder builder,
        UnitEvaluator target,
        string? faction = null,
        bool includeGroup = default)
    {
      builder.Validate(target);
    
      var element = ElementTool.Create<SwitchToNeutral>();
      element.Target = target;
      element.Faction = BlueprintTool.GetRef<BlueprintFactionReference>(faction);
      element.IncludeGroup = includeGroup;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="TimeSkip"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TimeSkip))]
    public static ActionsBuilder TimeSkip(
        this ActionsBuilder builder,
        IntEvaluator minutesToSkip,
        TimeSkip.SkipType type = default,
        TimeOfDay timeOfDay = default,
        bool noFatigue = default,
        bool matchTimeOfDay = default)
    {
      builder.Validate(minutesToSkip);
    
      var element = ElementTool.Create<TimeSkip>();
      element.m_Type = type;
      element.MinutesToSkip = minutesToSkip;
      element.TimeOfDay = timeOfDay;
      element.NoFatigue = noFatigue;
      element.MatchTimeOfDay = matchTimeOfDay;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnitLookAt"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UnitLookAt))]
    public static ActionsBuilder UnitLookAt(
        this ActionsBuilder builder,
        UnitEvaluator unit,
        PositionEvaluator position)
    {
      builder.Validate(unit);
      builder.Validate(position);
    
      var element = ElementTool.Create<UnitLookAt>();
      element.Unit = unit;
      element.Position = position;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnlinkDualCompanions"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UnlinkDualCompanions))]
    public static ActionsBuilder UnlinkDualCompanions(
        this ActionsBuilder builder,
        UnitEvaluator first,
        UnitEvaluator second)
    {
      builder.Validate(first);
      builder.Validate(second);
    
      var element = ElementTool.Create<UnlinkDualCompanions>();
      element.First = first;
      element.Second = second;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnlockCompanionStory"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="story"><see cref="Kingmaker.Blueprints.BlueprintCompanionStory"/></param>
    [Generated]
    [Implements(typeof(UnlockCompanionStory))]
    public static ActionsBuilder UnlockCompanionStory(
        this ActionsBuilder builder,
        string? story = null)
    {
      var element = ElementTool.Create<UnlockCompanionStory>();
      element.m_Story = BlueprintTool.GetRef<BlueprintCompanionStoryReference>(story);
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnlockFlag"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="flag"><see cref="Kingmaker.Blueprints.BlueprintUnlockableFlag"/></param>
    [Generated]
    [Implements(typeof(UnlockFlag))]
    public static ActionsBuilder UnlockFlag(
        this ActionsBuilder builder,
        string? flag = null,
        int flagValue = default)
    {
      var element = ElementTool.Create<UnlockFlag>();
      element.m_flag = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(flag);
      element.flagValue = flagValue;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnmarkAnswersSelected"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="answers"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintAnswer"/></param>
    [Generated]
    [Implements(typeof(UnmarkAnswersSelected))]
    public static ActionsBuilder UnmarkAnswersSelected(
        this ActionsBuilder builder,
        string[]? answers = null)
    {
      var element = ElementTool.Create<UnmarkAnswersSelected>();
      element.m_Answers = answers.Select(name => BlueprintTool.GetRef<BlueprintAnswerReference>(name)).ToArray();
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="Unrecruit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="companionBlueprint"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(Unrecruit))]
    public static ActionsBuilder Unrecruit(
        this ActionsBuilder builder,
        string? companionBlueprint = null,
        ActionsBuilder? onUnrecruit = null)
    {
      var element = ElementTool.Create<Unrecruit>();
      element.m_CompanionBlueprint = BlueprintTool.GetRef<BlueprintUnitReference>(companionBlueprint);
      element.OnUnrecruit = onUnrecruit?.Build() ?? Constants.Empty.Actions;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UpdateEtudeProgressBar"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="etude"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude"/></param>
    [Generated]
    [Implements(typeof(UpdateEtudeProgressBar))]
    public static ActionsBuilder UpdateEtudeProgressBar(
        this ActionsBuilder builder,
        IntEvaluator progress,
        string? etude = null)
    {
      builder.Validate(progress);
    
      var element = ElementTool.Create<UpdateEtudeProgressBar>();
      element.Progress = progress;
      element.Etude = BlueprintTool.GetRef<BlueprintEtudeReference>(etude);
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UpdateEtudes"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UpdateEtudes))]
    public static ActionsBuilder UpdateEtudes(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<UpdateEtudes>());
    }
  }
}
