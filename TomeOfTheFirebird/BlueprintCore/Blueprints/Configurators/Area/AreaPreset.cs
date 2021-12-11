using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Enums;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Kingdom;
using Kingmaker.Settings.Difficulty;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintAreaPreset"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintAreaPreset))]
  public abstract class BaseAreaPresetConfigurator<T, TBuilder>
      : BaseBlueprintConfigurator<T, TBuilder>
      where T : BlueprintAreaPreset
      where TBuilder : BaseAreaPresetConfigurator<T, TBuilder>
  {
    protected BaseAreaPresetConfigurator(string name) : base(name) { }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_Area"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="area"><see cref="Kingmaker.Blueprints.Area.BlueprintArea"/></param>
    [Generated]
    public TBuilder SetArea(string? area)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Area = BlueprintTool.GetRef<BlueprintAreaReference>(area);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_EnterPoint"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enterPoint"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaEnterPoint"/></param>
    [Generated]
    public TBuilder SetEnterPoint(string? enterPoint)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_EnterPoint = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(enterPoint);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_GlobalMapLocation"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="globalMapLocation"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMapPoint"/></param>
    [Generated]
    public TBuilder SetGlobalMapLocation(string? globalMapLocation)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_GlobalMapLocation = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(globalMapLocation);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.AlsoLoadMechanics"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="alsoLoadMechanics"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaMechanics"/></param>
    [Generated]
    public TBuilder SetAlsoLoadMechanics(string[]? alsoLoadMechanics)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AlsoLoadMechanics = alsoLoadMechanics.Select(name => BlueprintTool.GetRef<BlueprintAreaMechanicsReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAreaPreset.AlsoLoadMechanics"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="alsoLoadMechanics"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaMechanics"/></param>
    [Generated]
    public TBuilder AddToAlsoLoadMechanics(params string[] alsoLoadMechanics)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AlsoLoadMechanics.AddRange(alsoLoadMechanics.Select(name => BlueprintTool.GetRef<BlueprintAreaMechanicsReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAreaPreset.AlsoLoadMechanics"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="alsoLoadMechanics"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaMechanics"/></param>
    [Generated]
    public TBuilder RemoveFromAlsoLoadMechanics(params string[] alsoLoadMechanics)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = alsoLoadMechanics.Select(name => BlueprintTool.GetRef<BlueprintAreaMechanicsReference>(name));
            bp.AlsoLoadMechanics =
                bp.AlsoLoadMechanics
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.MakeAutosave"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetMakeAutosave(bool makeAutosave)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MakeAutosave = makeAutosave;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_OverrideGameDifficulty"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetOverrideGameDifficulty(DifficultyPresetAsset overrideGameDifficulty)
    {
      ValidateParam(overrideGameDifficulty);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_OverrideGameDifficulty = overrideGameDifficulty;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_PlayerCharacter"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="playerCharacter"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public TBuilder SetPlayerCharacter(string? playerCharacter)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_PlayerCharacter = BlueprintTool.GetRef<BlueprintUnitReference>(playerCharacter);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.CharGen"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetCharGen(bool charGen)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CharGen = charGen;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.Alignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetAlignment(Alignment alignment)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Alignment = alignment;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.PartyXp"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetPartyXp(int partyXp)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.PartyXp = partyXp;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.Companions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="companions"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public TBuilder SetCompanions(string[]? companions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Companions = companions.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAreaPreset.Companions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="companions"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public TBuilder AddToCompanions(params string[] companions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Companions.AddRange(companions.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAreaPreset.Companions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="companions"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public TBuilder RemoveFromCompanions(params string[] companions)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = companions.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name));
            bp.Companions =
                bp.Companions
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.CompanionsRemote"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="companionsRemote"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public TBuilder SetCompanionsRemote(string[]? companionsRemote)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CompanionsRemote = companionsRemote.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAreaPreset.CompanionsRemote"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="companionsRemote"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public TBuilder AddToCompanionsRemote(params string[] companionsRemote)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CompanionsRemote.AddRange(companionsRemote.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAreaPreset.CompanionsRemote"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="companionsRemote"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public TBuilder RemoveFromCompanionsRemote(params string[] companionsRemote)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = companionsRemote.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name));
            bp.CompanionsRemote =
                bp.CompanionsRemote
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.ExCompanions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="exCompanions"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public TBuilder SetExCompanions(string[]? exCompanions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ExCompanions = exCompanions.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAreaPreset.ExCompanions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="exCompanions"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public TBuilder AddToExCompanions(params string[] exCompanions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ExCompanions.AddRange(exCompanions.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAreaPreset.ExCompanions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="exCompanions"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public TBuilder RemoveFromExCompanions(params string[] exCompanions)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = exCompanions.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name));
            bp.ExCompanions =
                bp.ExCompanions
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.StartGameActions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetStartGameActions(ActionsBuilder? startGameActions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.StartGameActions = startGameActions?.Build() ?? Constants.Empty.Actions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_DlcCampaign"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="dlcCampaign"><see cref="Kingmaker.DLC.BlueprintDlcRewardCampaign"/></param>
    [Generated]
    public TBuilder SetDlcCampaign(string? dlcCampaign)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DlcCampaign = BlueprintTool.GetRef<BlueprintDlcRewardCampaignReference>(dlcCampaign);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.UnlockedFlags"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetUnlockedFlags(List<UnlockValuePair>? unlockedFlags)
    {
      ValidateParam(unlockedFlags);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.UnlockedFlags = unlockedFlags;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAreaPreset.UnlockedFlags"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder AddToUnlockedFlags(params UnlockValuePair[] unlockedFlags)
    {
      ValidateParam(unlockedFlags);
      return OnConfigureInternal(
          bp =>
          {
            bp.UnlockedFlags.AddRange(unlockedFlags.ToList() ?? new List<UnlockValuePair>());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAreaPreset.UnlockedFlags"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder RemoveFromUnlockedFlags(params UnlockValuePair[] unlockedFlags)
    {
      ValidateParam(unlockedFlags);
      return OnConfigureInternal(
          bp =>
          {
            bp.UnlockedFlags = bp.UnlockedFlags.Where(item => !unlockedFlags.Contains(item)).ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.StartedQuests"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="startedQuests"><see cref="Kingmaker.Blueprints.Quests.BlueprintQuestObjective"/></param>
    [Generated]
    public TBuilder SetStartedQuests(string[]? startedQuests)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.StartedQuests = startedQuests.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAreaPreset.StartedQuests"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="startedQuests"><see cref="Kingmaker.Blueprints.Quests.BlueprintQuestObjective"/></param>
    [Generated]
    public TBuilder AddToStartedQuests(params string[] startedQuests)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.StartedQuests.AddRange(startedQuests.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAreaPreset.StartedQuests"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="startedQuests"><see cref="Kingmaker.Blueprints.Quests.BlueprintQuestObjective"/></param>
    [Generated]
    public TBuilder RemoveFromStartedQuests(params string[] startedQuests)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = startedQuests.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name));
            bp.StartedQuests =
                bp.StartedQuests
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.FinishedQuests"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="finishedQuests"><see cref="Kingmaker.Blueprints.Quests.BlueprintQuestObjective"/></param>
    [Generated]
    public TBuilder SetFinishedQuests(string[]? finishedQuests)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.FinishedQuests = finishedQuests.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAreaPreset.FinishedQuests"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="finishedQuests"><see cref="Kingmaker.Blueprints.Quests.BlueprintQuestObjective"/></param>
    [Generated]
    public TBuilder AddToFinishedQuests(params string[] finishedQuests)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.FinishedQuests.AddRange(finishedQuests.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAreaPreset.FinishedQuests"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="finishedQuests"><see cref="Kingmaker.Blueprints.Quests.BlueprintQuestObjective"/></param>
    [Generated]
    public TBuilder RemoveFromFinishedQuests(params string[] finishedQuests)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = finishedQuests.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name));
            bp.FinishedQuests =
                bp.FinishedQuests
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.FailedQuests"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="failedQuests"><see cref="Kingmaker.Blueprints.Quests.BlueprintQuestObjective"/></param>
    [Generated]
    public TBuilder SetFailedQuests(string[]? failedQuests)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.FailedQuests = failedQuests.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAreaPreset.FailedQuests"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="failedQuests"><see cref="Kingmaker.Blueprints.Quests.BlueprintQuestObjective"/></param>
    [Generated]
    public TBuilder AddToFailedQuests(params string[] failedQuests)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.FailedQuests.AddRange(failedQuests.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAreaPreset.FailedQuests"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="failedQuests"><see cref="Kingmaker.Blueprints.Quests.BlueprintQuestObjective"/></param>
    [Generated]
    public TBuilder RemoveFromFailedQuests(params string[] failedQuests)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = failedQuests.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name));
            bp.FailedQuests =
                bp.FailedQuests
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.StartEtudesNonRecursively"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="startEtudesNonRecursively"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude"/></param>
    [Generated]
    public TBuilder SetStartEtudesNonRecursively(string[]? startEtudesNonRecursively)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.StartEtudesNonRecursively = startEtudesNonRecursively.Select(name => BlueprintTool.GetRef<BlueprintEtudeReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAreaPreset.StartEtudesNonRecursively"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="startEtudesNonRecursively"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude"/></param>
    [Generated]
    public TBuilder AddToStartEtudesNonRecursively(params string[] startEtudesNonRecursively)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.StartEtudesNonRecursively.AddRange(startEtudesNonRecursively.Select(name => BlueprintTool.GetRef<BlueprintEtudeReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAreaPreset.StartEtudesNonRecursively"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="startEtudesNonRecursively"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude"/></param>
    [Generated]
    public TBuilder RemoveFromStartEtudesNonRecursively(params string[] startEtudesNonRecursively)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = startEtudesNonRecursively.Select(name => BlueprintTool.GetRef<BlueprintEtudeReference>(name));
            bp.StartEtudesNonRecursively =
                bp.StartEtudesNonRecursively
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.StartEtudes"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="startEtudes"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude"/></param>
    [Generated]
    public TBuilder SetStartEtudes(string[]? startEtudes)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.StartEtudes = startEtudes.Select(name => BlueprintTool.GetRef<BlueprintEtudeReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAreaPreset.StartEtudes"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="startEtudes"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude"/></param>
    [Generated]
    public TBuilder AddToStartEtudes(params string[] startEtudes)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.StartEtudes.AddRange(startEtudes.Select(name => BlueprintTool.GetRef<BlueprintEtudeReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAreaPreset.StartEtudes"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="startEtudes"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude"/></param>
    [Generated]
    public TBuilder RemoveFromStartEtudes(params string[] startEtudes)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = startEtudes.Select(name => BlueprintTool.GetRef<BlueprintEtudeReference>(name));
            bp.StartEtudes =
                bp.StartEtudes
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.ForceCompleteEtudes"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="forceCompleteEtudes"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude"/></param>
    [Generated]
    public TBuilder SetForceCompleteEtudes(string[]? forceCompleteEtudes)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ForceCompleteEtudes = forceCompleteEtudes.Select(name => BlueprintTool.GetRef<BlueprintEtudeReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAreaPreset.ForceCompleteEtudes"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="forceCompleteEtudes"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude"/></param>
    [Generated]
    public TBuilder AddToForceCompleteEtudes(params string[] forceCompleteEtudes)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ForceCompleteEtudes.AddRange(forceCompleteEtudes.Select(name => BlueprintTool.GetRef<BlueprintEtudeReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAreaPreset.ForceCompleteEtudes"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="forceCompleteEtudes"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude"/></param>
    [Generated]
    public TBuilder RemoveFromForceCompleteEtudes(params string[] forceCompleteEtudes)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = forceCompleteEtudes.Select(name => BlueprintTool.GetRef<BlueprintEtudeReference>(name));
            bp.ForceCompleteEtudes =
                bp.ForceCompleteEtudes
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.CuesSeen"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="cuesSeen"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintCueBase"/></param>
    [Generated]
    public TBuilder SetCuesSeen(string[]? cuesSeen)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CuesSeen = cuesSeen.Select(name => BlueprintTool.GetRef<BlueprintCueBaseReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAreaPreset.CuesSeen"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="cuesSeen"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintCueBase"/></param>
    [Generated]
    public TBuilder AddToCuesSeen(params string[] cuesSeen)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CuesSeen.AddRange(cuesSeen.Select(name => BlueprintTool.GetRef<BlueprintCueBaseReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAreaPreset.CuesSeen"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="cuesSeen"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintCueBase"/></param>
    [Generated]
    public TBuilder RemoveFromCuesSeen(params string[] cuesSeen)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = cuesSeen.Select(name => BlueprintTool.GetRef<BlueprintCueBaseReference>(name));
            bp.CuesSeen =
                bp.CuesSeen
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.AnswersSelected"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="answersSelected"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintAnswer"/></param>
    [Generated]
    public TBuilder SetAnswersSelected(string[]? answersSelected)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AnswersSelected = answersSelected.Select(name => BlueprintTool.GetRef<BlueprintAnswerReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAreaPreset.AnswersSelected"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="answersSelected"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintAnswer"/></param>
    [Generated]
    public TBuilder AddToAnswersSelected(params string[] answersSelected)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AnswersSelected.AddRange(answersSelected.Select(name => BlueprintTool.GetRef<BlueprintAnswerReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAreaPreset.AnswersSelected"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="answersSelected"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintAnswer"/></param>
    [Generated]
    public TBuilder RemoveFromAnswersSelected(params string[] answersSelected)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = answersSelected.Select(name => BlueprintTool.GetRef<BlueprintAnswerReference>(name));
            bp.AnswersSelected =
                bp.AnswersSelected
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.HasKingdom"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetHasKingdom(bool hasKingdom)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.HasKingdom = hasKingdom;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.KingdomManagementIsVisible"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetKingdomManagementIsVisible(bool kingdomManagementIsVisible)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.KingdomManagementIsVisible = kingdomManagementIsVisible;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.ActiveEvents"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="activeEvents"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomEventBase"/></param>
    [Generated]
    public TBuilder SetActiveEvents(string[]? activeEvents)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ActiveEvents = activeEvents.Select(name => BlueprintTool.GetRef<BlueprintKingdomEventBaseReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAreaPreset.ActiveEvents"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="activeEvents"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomEventBase"/></param>
    [Generated]
    public TBuilder AddToActiveEvents(params string[] activeEvents)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ActiveEvents.AddRange(activeEvents.Select(name => BlueprintTool.GetRef<BlueprintKingdomEventBaseReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAreaPreset.ActiveEvents"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="activeEvents"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomEventBase"/></param>
    [Generated]
    public TBuilder RemoveFromActiveEvents(params string[] activeEvents)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = activeEvents.Select(name => BlueprintTool.GetRef<BlueprintKingdomEventBaseReference>(name));
            bp.ActiveEvents =
                bp.ActiveEvents
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.AddResources"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetAddResources(KingdomResourcesAmount addResources)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AddResources = addResources;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.AddConsumableEventBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetAddConsumableEventBonus(int addConsumableEventBonus)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AddConsumableEventBonus = addConsumableEventBonus;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_KingdomDay"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetKingdomDay(int kingdomDay)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_KingdomDay = kingdomDay;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_KingdomIncomePerClaimed"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetKingdomIncomePerClaimed(KingdomResourcesAmount kingdomIncomePerClaimed)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_KingdomIncomePerClaimed = kingdomIncomePerClaimed;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_KingdomIncomePerUpgraded"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetKingdomIncomePerUpgraded(KingdomResourcesAmount kingdomIncomePerUpgraded)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_KingdomIncomePerUpgraded = kingdomIncomePerUpgraded;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_Stats"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetStats(BlueprintAreaPreset.KingdomsStatsPreset stats)
    {
      ValidateParam(stats);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Stats = stats;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_Regions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetRegions(BlueprintAreaPreset.KingdomsRegionPreset[]? regions)
    {
      ValidateParam(regions);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Regions = regions;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAreaPreset.m_Regions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder AddToRegions(params BlueprintAreaPreset.KingdomsRegionPreset[] regions)
    {
      ValidateParam(regions);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Regions = CommonTool.Append(bp.m_Regions, regions ?? new BlueprintAreaPreset.KingdomsRegionPreset[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAreaPreset.m_Regions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder RemoveFromRegions(params BlueprintAreaPreset.KingdomsRegionPreset[] regions)
    {
      ValidateParam(regions);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Regions = bp.m_Regions.Where(item => !regions.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_History"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetHistory(BlueprintAreaPreset.KingdomsEventHistoryPreset[]? history)
    {
      ValidateParam(history);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_History = history;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAreaPreset.m_History"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder AddToHistory(params BlueprintAreaPreset.KingdomsEventHistoryPreset[] history)
    {
      ValidateParam(history);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_History = CommonTool.Append(bp.m_History, history ?? new BlueprintAreaPreset.KingdomsEventHistoryPreset[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAreaPreset.m_History"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder RemoveFromHistory(params BlueprintAreaPreset.KingdomsEventHistoryPreset[] history)
    {
      ValidateParam(history);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_History = bp.m_History.Where(item => !history.Contains(item)).ToArray();
          });
    }
  }

  /// <summary>
  /// Configurator for <see cref="BlueprintAreaPreset"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintAreaPreset))]
  public class AreaPresetConfigurator : BaseBlueprintConfigurator<BlueprintAreaPreset, AreaPresetConfigurator>
  {
    private AreaPresetConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AreaPresetConfigurator For(string name)
    {
      return new AreaPresetConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AreaPresetConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintAreaPreset>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_Area"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="area"><see cref="Kingmaker.Blueprints.Area.BlueprintArea"/></param>
    [Generated]
    public AreaPresetConfigurator SetArea(string? area)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Area = BlueprintTool.GetRef<BlueprintAreaReference>(area);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_EnterPoint"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enterPoint"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaEnterPoint"/></param>
    [Generated]
    public AreaPresetConfigurator SetEnterPoint(string? enterPoint)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_EnterPoint = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(enterPoint);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_GlobalMapLocation"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="globalMapLocation"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMapPoint"/></param>
    [Generated]
    public AreaPresetConfigurator SetGlobalMapLocation(string? globalMapLocation)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_GlobalMapLocation = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(globalMapLocation);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.AlsoLoadMechanics"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="alsoLoadMechanics"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaMechanics"/></param>
    [Generated]
    public AreaPresetConfigurator SetAlsoLoadMechanics(string[]? alsoLoadMechanics)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AlsoLoadMechanics = alsoLoadMechanics.Select(name => BlueprintTool.GetRef<BlueprintAreaMechanicsReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAreaPreset.AlsoLoadMechanics"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="alsoLoadMechanics"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaMechanics"/></param>
    [Generated]
    public AreaPresetConfigurator AddToAlsoLoadMechanics(params string[] alsoLoadMechanics)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AlsoLoadMechanics.AddRange(alsoLoadMechanics.Select(name => BlueprintTool.GetRef<BlueprintAreaMechanicsReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAreaPreset.AlsoLoadMechanics"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="alsoLoadMechanics"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaMechanics"/></param>
    [Generated]
    public AreaPresetConfigurator RemoveFromAlsoLoadMechanics(params string[] alsoLoadMechanics)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = alsoLoadMechanics.Select(name => BlueprintTool.GetRef<BlueprintAreaMechanicsReference>(name));
            bp.AlsoLoadMechanics =
                bp.AlsoLoadMechanics
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.MakeAutosave"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPresetConfigurator SetMakeAutosave(bool makeAutosave)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MakeAutosave = makeAutosave;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_OverrideGameDifficulty"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPresetConfigurator SetOverrideGameDifficulty(DifficultyPresetAsset overrideGameDifficulty)
    {
      ValidateParam(overrideGameDifficulty);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_OverrideGameDifficulty = overrideGameDifficulty;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_PlayerCharacter"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="playerCharacter"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public AreaPresetConfigurator SetPlayerCharacter(string? playerCharacter)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_PlayerCharacter = BlueprintTool.GetRef<BlueprintUnitReference>(playerCharacter);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.CharGen"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPresetConfigurator SetCharGen(bool charGen)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CharGen = charGen;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.Alignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPresetConfigurator SetAlignment(Alignment alignment)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Alignment = alignment;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.PartyXp"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPresetConfigurator SetPartyXp(int partyXp)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.PartyXp = partyXp;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.Companions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="companions"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public AreaPresetConfigurator SetCompanions(string[]? companions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Companions = companions.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAreaPreset.Companions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="companions"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public AreaPresetConfigurator AddToCompanions(params string[] companions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Companions.AddRange(companions.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAreaPreset.Companions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="companions"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public AreaPresetConfigurator RemoveFromCompanions(params string[] companions)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = companions.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name));
            bp.Companions =
                bp.Companions
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.CompanionsRemote"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="companionsRemote"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public AreaPresetConfigurator SetCompanionsRemote(string[]? companionsRemote)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CompanionsRemote = companionsRemote.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAreaPreset.CompanionsRemote"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="companionsRemote"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public AreaPresetConfigurator AddToCompanionsRemote(params string[] companionsRemote)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CompanionsRemote.AddRange(companionsRemote.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAreaPreset.CompanionsRemote"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="companionsRemote"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public AreaPresetConfigurator RemoveFromCompanionsRemote(params string[] companionsRemote)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = companionsRemote.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name));
            bp.CompanionsRemote =
                bp.CompanionsRemote
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.ExCompanions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="exCompanions"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public AreaPresetConfigurator SetExCompanions(string[]? exCompanions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ExCompanions = exCompanions.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAreaPreset.ExCompanions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="exCompanions"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public AreaPresetConfigurator AddToExCompanions(params string[] exCompanions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ExCompanions.AddRange(exCompanions.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAreaPreset.ExCompanions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="exCompanions"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public AreaPresetConfigurator RemoveFromExCompanions(params string[] exCompanions)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = exCompanions.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name));
            bp.ExCompanions =
                bp.ExCompanions
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.StartGameActions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPresetConfigurator SetStartGameActions(ActionsBuilder? startGameActions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.StartGameActions = startGameActions?.Build() ?? Constants.Empty.Actions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_DlcCampaign"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="dlcCampaign"><see cref="Kingmaker.DLC.BlueprintDlcRewardCampaign"/></param>
    [Generated]
    public AreaPresetConfigurator SetDlcCampaign(string? dlcCampaign)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DlcCampaign = BlueprintTool.GetRef<BlueprintDlcRewardCampaignReference>(dlcCampaign);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.UnlockedFlags"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPresetConfigurator SetUnlockedFlags(List<UnlockValuePair>? unlockedFlags)
    {
      ValidateParam(unlockedFlags);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.UnlockedFlags = unlockedFlags;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAreaPreset.UnlockedFlags"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPresetConfigurator AddToUnlockedFlags(params UnlockValuePair[] unlockedFlags)
    {
      ValidateParam(unlockedFlags);
      return OnConfigureInternal(
          bp =>
          {
            bp.UnlockedFlags.AddRange(unlockedFlags.ToList() ?? new List<UnlockValuePair>());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAreaPreset.UnlockedFlags"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPresetConfigurator RemoveFromUnlockedFlags(params UnlockValuePair[] unlockedFlags)
    {
      ValidateParam(unlockedFlags);
      return OnConfigureInternal(
          bp =>
          {
            bp.UnlockedFlags = bp.UnlockedFlags.Where(item => !unlockedFlags.Contains(item)).ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.StartedQuests"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="startedQuests"><see cref="Kingmaker.Blueprints.Quests.BlueprintQuestObjective"/></param>
    [Generated]
    public AreaPresetConfigurator SetStartedQuests(string[]? startedQuests)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.StartedQuests = startedQuests.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAreaPreset.StartedQuests"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="startedQuests"><see cref="Kingmaker.Blueprints.Quests.BlueprintQuestObjective"/></param>
    [Generated]
    public AreaPresetConfigurator AddToStartedQuests(params string[] startedQuests)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.StartedQuests.AddRange(startedQuests.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAreaPreset.StartedQuests"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="startedQuests"><see cref="Kingmaker.Blueprints.Quests.BlueprintQuestObjective"/></param>
    [Generated]
    public AreaPresetConfigurator RemoveFromStartedQuests(params string[] startedQuests)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = startedQuests.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name));
            bp.StartedQuests =
                bp.StartedQuests
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.FinishedQuests"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="finishedQuests"><see cref="Kingmaker.Blueprints.Quests.BlueprintQuestObjective"/></param>
    [Generated]
    public AreaPresetConfigurator SetFinishedQuests(string[]? finishedQuests)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.FinishedQuests = finishedQuests.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAreaPreset.FinishedQuests"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="finishedQuests"><see cref="Kingmaker.Blueprints.Quests.BlueprintQuestObjective"/></param>
    [Generated]
    public AreaPresetConfigurator AddToFinishedQuests(params string[] finishedQuests)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.FinishedQuests.AddRange(finishedQuests.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAreaPreset.FinishedQuests"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="finishedQuests"><see cref="Kingmaker.Blueprints.Quests.BlueprintQuestObjective"/></param>
    [Generated]
    public AreaPresetConfigurator RemoveFromFinishedQuests(params string[] finishedQuests)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = finishedQuests.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name));
            bp.FinishedQuests =
                bp.FinishedQuests
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.FailedQuests"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="failedQuests"><see cref="Kingmaker.Blueprints.Quests.BlueprintQuestObjective"/></param>
    [Generated]
    public AreaPresetConfigurator SetFailedQuests(string[]? failedQuests)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.FailedQuests = failedQuests.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAreaPreset.FailedQuests"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="failedQuests"><see cref="Kingmaker.Blueprints.Quests.BlueprintQuestObjective"/></param>
    [Generated]
    public AreaPresetConfigurator AddToFailedQuests(params string[] failedQuests)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.FailedQuests.AddRange(failedQuests.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAreaPreset.FailedQuests"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="failedQuests"><see cref="Kingmaker.Blueprints.Quests.BlueprintQuestObjective"/></param>
    [Generated]
    public AreaPresetConfigurator RemoveFromFailedQuests(params string[] failedQuests)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = failedQuests.Select(name => BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(name));
            bp.FailedQuests =
                bp.FailedQuests
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.StartEtudesNonRecursively"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="startEtudesNonRecursively"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude"/></param>
    [Generated]
    public AreaPresetConfigurator SetStartEtudesNonRecursively(string[]? startEtudesNonRecursively)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.StartEtudesNonRecursively = startEtudesNonRecursively.Select(name => BlueprintTool.GetRef<BlueprintEtudeReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAreaPreset.StartEtudesNonRecursively"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="startEtudesNonRecursively"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude"/></param>
    [Generated]
    public AreaPresetConfigurator AddToStartEtudesNonRecursively(params string[] startEtudesNonRecursively)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.StartEtudesNonRecursively.AddRange(startEtudesNonRecursively.Select(name => BlueprintTool.GetRef<BlueprintEtudeReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAreaPreset.StartEtudesNonRecursively"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="startEtudesNonRecursively"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude"/></param>
    [Generated]
    public AreaPresetConfigurator RemoveFromStartEtudesNonRecursively(params string[] startEtudesNonRecursively)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = startEtudesNonRecursively.Select(name => BlueprintTool.GetRef<BlueprintEtudeReference>(name));
            bp.StartEtudesNonRecursively =
                bp.StartEtudesNonRecursively
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.StartEtudes"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="startEtudes"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude"/></param>
    [Generated]
    public AreaPresetConfigurator SetStartEtudes(string[]? startEtudes)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.StartEtudes = startEtudes.Select(name => BlueprintTool.GetRef<BlueprintEtudeReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAreaPreset.StartEtudes"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="startEtudes"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude"/></param>
    [Generated]
    public AreaPresetConfigurator AddToStartEtudes(params string[] startEtudes)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.StartEtudes.AddRange(startEtudes.Select(name => BlueprintTool.GetRef<BlueprintEtudeReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAreaPreset.StartEtudes"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="startEtudes"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude"/></param>
    [Generated]
    public AreaPresetConfigurator RemoveFromStartEtudes(params string[] startEtudes)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = startEtudes.Select(name => BlueprintTool.GetRef<BlueprintEtudeReference>(name));
            bp.StartEtudes =
                bp.StartEtudes
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.ForceCompleteEtudes"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="forceCompleteEtudes"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude"/></param>
    [Generated]
    public AreaPresetConfigurator SetForceCompleteEtudes(string[]? forceCompleteEtudes)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ForceCompleteEtudes = forceCompleteEtudes.Select(name => BlueprintTool.GetRef<BlueprintEtudeReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAreaPreset.ForceCompleteEtudes"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="forceCompleteEtudes"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude"/></param>
    [Generated]
    public AreaPresetConfigurator AddToForceCompleteEtudes(params string[] forceCompleteEtudes)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ForceCompleteEtudes.AddRange(forceCompleteEtudes.Select(name => BlueprintTool.GetRef<BlueprintEtudeReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAreaPreset.ForceCompleteEtudes"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="forceCompleteEtudes"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude"/></param>
    [Generated]
    public AreaPresetConfigurator RemoveFromForceCompleteEtudes(params string[] forceCompleteEtudes)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = forceCompleteEtudes.Select(name => BlueprintTool.GetRef<BlueprintEtudeReference>(name));
            bp.ForceCompleteEtudes =
                bp.ForceCompleteEtudes
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.CuesSeen"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="cuesSeen"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintCueBase"/></param>
    [Generated]
    public AreaPresetConfigurator SetCuesSeen(string[]? cuesSeen)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CuesSeen = cuesSeen.Select(name => BlueprintTool.GetRef<BlueprintCueBaseReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAreaPreset.CuesSeen"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="cuesSeen"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintCueBase"/></param>
    [Generated]
    public AreaPresetConfigurator AddToCuesSeen(params string[] cuesSeen)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CuesSeen.AddRange(cuesSeen.Select(name => BlueprintTool.GetRef<BlueprintCueBaseReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAreaPreset.CuesSeen"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="cuesSeen"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintCueBase"/></param>
    [Generated]
    public AreaPresetConfigurator RemoveFromCuesSeen(params string[] cuesSeen)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = cuesSeen.Select(name => BlueprintTool.GetRef<BlueprintCueBaseReference>(name));
            bp.CuesSeen =
                bp.CuesSeen
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.AnswersSelected"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="answersSelected"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintAnswer"/></param>
    [Generated]
    public AreaPresetConfigurator SetAnswersSelected(string[]? answersSelected)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AnswersSelected = answersSelected.Select(name => BlueprintTool.GetRef<BlueprintAnswerReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAreaPreset.AnswersSelected"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="answersSelected"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintAnswer"/></param>
    [Generated]
    public AreaPresetConfigurator AddToAnswersSelected(params string[] answersSelected)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AnswersSelected.AddRange(answersSelected.Select(name => BlueprintTool.GetRef<BlueprintAnswerReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAreaPreset.AnswersSelected"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="answersSelected"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintAnswer"/></param>
    [Generated]
    public AreaPresetConfigurator RemoveFromAnswersSelected(params string[] answersSelected)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = answersSelected.Select(name => BlueprintTool.GetRef<BlueprintAnswerReference>(name));
            bp.AnswersSelected =
                bp.AnswersSelected
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.HasKingdom"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPresetConfigurator SetHasKingdom(bool hasKingdom)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.HasKingdom = hasKingdom;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.KingdomManagementIsVisible"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPresetConfigurator SetKingdomManagementIsVisible(bool kingdomManagementIsVisible)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.KingdomManagementIsVisible = kingdomManagementIsVisible;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.ActiveEvents"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="activeEvents"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomEventBase"/></param>
    [Generated]
    public AreaPresetConfigurator SetActiveEvents(string[]? activeEvents)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ActiveEvents = activeEvents.Select(name => BlueprintTool.GetRef<BlueprintKingdomEventBaseReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAreaPreset.ActiveEvents"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="activeEvents"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomEventBase"/></param>
    [Generated]
    public AreaPresetConfigurator AddToActiveEvents(params string[] activeEvents)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ActiveEvents.AddRange(activeEvents.Select(name => BlueprintTool.GetRef<BlueprintKingdomEventBaseReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAreaPreset.ActiveEvents"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="activeEvents"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomEventBase"/></param>
    [Generated]
    public AreaPresetConfigurator RemoveFromActiveEvents(params string[] activeEvents)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = activeEvents.Select(name => BlueprintTool.GetRef<BlueprintKingdomEventBaseReference>(name));
            bp.ActiveEvents =
                bp.ActiveEvents
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.AddResources"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPresetConfigurator SetAddResources(KingdomResourcesAmount addResources)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AddResources = addResources;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.AddConsumableEventBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPresetConfigurator SetAddConsumableEventBonus(int addConsumableEventBonus)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AddConsumableEventBonus = addConsumableEventBonus;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_KingdomDay"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPresetConfigurator SetKingdomDay(int kingdomDay)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_KingdomDay = kingdomDay;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_KingdomIncomePerClaimed"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPresetConfigurator SetKingdomIncomePerClaimed(KingdomResourcesAmount kingdomIncomePerClaimed)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_KingdomIncomePerClaimed = kingdomIncomePerClaimed;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_KingdomIncomePerUpgraded"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPresetConfigurator SetKingdomIncomePerUpgraded(KingdomResourcesAmount kingdomIncomePerUpgraded)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_KingdomIncomePerUpgraded = kingdomIncomePerUpgraded;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_Stats"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPresetConfigurator SetStats(BlueprintAreaPreset.KingdomsStatsPreset stats)
    {
      ValidateParam(stats);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Stats = stats;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_Regions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPresetConfigurator SetRegions(BlueprintAreaPreset.KingdomsRegionPreset[]? regions)
    {
      ValidateParam(regions);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Regions = regions;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAreaPreset.m_Regions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPresetConfigurator AddToRegions(params BlueprintAreaPreset.KingdomsRegionPreset[] regions)
    {
      ValidateParam(regions);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Regions = CommonTool.Append(bp.m_Regions, regions ?? new BlueprintAreaPreset.KingdomsRegionPreset[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAreaPreset.m_Regions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPresetConfigurator RemoveFromRegions(params BlueprintAreaPreset.KingdomsRegionPreset[] regions)
    {
      ValidateParam(regions);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Regions = bp.m_Regions.Where(item => !regions.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaPreset.m_History"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPresetConfigurator SetHistory(BlueprintAreaPreset.KingdomsEventHistoryPreset[]? history)
    {
      ValidateParam(history);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_History = history;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAreaPreset.m_History"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPresetConfigurator AddToHistory(params BlueprintAreaPreset.KingdomsEventHistoryPreset[] history)
    {
      ValidateParam(history);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_History = CommonTool.Append(bp.m_History, history ?? new BlueprintAreaPreset.KingdomsEventHistoryPreset[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAreaPreset.m_History"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaPresetConfigurator RemoveFromHistory(params BlueprintAreaPreset.KingdomsEventHistoryPreset[] history)
    {
      ValidateParam(history);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_History = bp.m_History.Where(item => !history.Contains(item)).ToArray();
          });
    }
  }
}
