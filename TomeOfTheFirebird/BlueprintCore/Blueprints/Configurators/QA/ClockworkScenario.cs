using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.ElementsSystem;
using Kingmaker.QA.Clockwork;
using Kingmaker.Settings.Difficulty;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.QA
{
  /// <summary>
  /// Configurator for <see cref="BlueprintClockworkScenario"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintClockworkScenario))]
  public class ClockworkScenarioConfigurator : BaseBlueprintConfigurator<BlueprintClockworkScenario, ClockworkScenarioConfigurator>
  {
    private ClockworkScenarioConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ClockworkScenarioConfigurator For(string name)
    {
      return new ClockworkScenarioConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ClockworkScenarioConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintClockworkScenario>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.m_ScenarioName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetScenarioName(string scenarioName)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ScenarioName = scenarioName;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.ScenarioAuthor"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetScenarioAuthor(BlueprintClockworkScenario.ScenarioQA scenarioAuthor)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ScenarioAuthor = scenarioAuthor;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.TestMode"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetTestMode(BlueprintClockworkScenario.ClockworkTestMode testMode)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.TestMode = testMode;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.startMode"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetStartMode(BlueprintClockworkScenario.StartMode startMode)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.startMode = startMode;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.Preset"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="preset"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaPreset"/></param>
    [Generated]
    public ClockworkScenarioConfigurator SetPreset(string? preset)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Preset = BlueprintTool.GetRef<BlueprintAreaPresetReference>(preset);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.Save"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetSave(string save)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Save = save;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.RemoteSave"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetRemoteSave(string remoteSave)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.RemoteSave = remoteSave;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.BlueprintPlayerUnit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="blueprintPlayerUnit"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public ClockworkScenarioConfigurator SetBlueprintPlayerUnit(string? blueprintPlayerUnit)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.BlueprintPlayerUnit = BlueprintTool.GetRef<BlueprintUnitReference>(blueprintPlayerUnit);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.OverridePresetDifficulty"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetOverridePresetDifficulty(DifficultyPresetAsset overridePresetDifficulty)
    {
      ValidateParam(overridePresetDifficulty);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.OverridePresetDifficulty = overridePresetDifficulty;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.OnAreaEnterDelay"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetOnAreaEnterDelay(float onAreaEnterDelay)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.OnAreaEnterDelay = onAreaEnterDelay;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.AreaTimeout"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetAreaTimeout(float areaTimeout)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AreaTimeout = areaTimeout;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.CutsceneTimeout"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetCutsceneTimeout(float cutsceneTimeout)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CutsceneTimeout = cutsceneTimeout;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.TaskTimeout"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetTaskTimeout(float taskTimeout)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.TaskTimeout = taskTimeout;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.TaskMaxAttempts"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetTaskMaxAttempts(int taskMaxAttempts)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.TaskMaxAttempts = taskMaxAttempts;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.AreaGameOverLimit"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetAreaGameOverLimit(int areaGameOverLimit)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AreaGameOverLimit = areaGameOverLimit;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.AutoLevelUp"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetAutoLevelUp(bool autoLevelUp)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AutoLevelUp = autoLevelUp;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.AutoUseRest"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetAutoUseRest(bool autoUseRest)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AutoUseRest = autoUseRest;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.CheaterCombat"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetCheaterCombat(bool cheaterCombat)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CheaterCombat = cheaterCombat;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.CheaterTacticalCombat"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetCheaterTacticalCombat(bool cheaterTacticalCombat)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CheaterTacticalCombat = cheaterTacticalCombat;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.SellTrashOnly"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetSellTrashOnly(bool sellTrashOnly)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.SellTrashOnly = sellTrashOnly;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.SaveLoadSmokeTest"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetSaveLoadSmokeTest(bool saveLoadSmokeTest)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.SaveLoadSmokeTest = saveLoadSmokeTest;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.UploadSavesToSavesStorage"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetUploadSavesToSavesStorage(bool uploadSavesToSavesStorage)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.UploadSavesToSavesStorage = uploadSavesToSavesStorage;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.ScenarioParts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="scenarioParts"><see cref="Kingmaker.QA.Clockwork.BlueprintClockworkScenarioPart"/></param>
    [Generated]
    public ClockworkScenarioConfigurator SetScenarioParts(string[]? scenarioParts)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ScenarioParts = scenarioParts.Select(name => BlueprintTool.GetRef<BlueprintClockworkScenarioPartReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintClockworkScenario.ScenarioParts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="scenarioParts"><see cref="Kingmaker.QA.Clockwork.BlueprintClockworkScenarioPart"/></param>
    [Generated]
    public ClockworkScenarioConfigurator AddToScenarioParts(params string[] scenarioParts)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ScenarioParts.AddRange(scenarioParts.Select(name => BlueprintTool.GetRef<BlueprintClockworkScenarioPartReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintClockworkScenario.ScenarioParts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="scenarioParts"><see cref="Kingmaker.QA.Clockwork.BlueprintClockworkScenarioPart"/></param>
    [Generated]
    public ClockworkScenarioConfigurator RemoveFromScenarioParts(params string[] scenarioParts)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = scenarioParts.Select(name => BlueprintTool.GetRef<BlueprintClockworkScenarioPartReference>(name));
            bp.ScenarioParts =
                bp.ScenarioParts
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.RetrySkillChecks"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetRetrySkillChecks(List<EntityReference>? retrySkillChecks)
    {
      ValidateParam(retrySkillChecks);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.RetrySkillChecks = retrySkillChecks;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintClockworkScenario.RetrySkillChecks"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator AddToRetrySkillChecks(params EntityReference[] retrySkillChecks)
    {
      ValidateParam(retrySkillChecks);
      return OnConfigureInternal(
          bp =>
          {
            bp.RetrySkillChecks.AddRange(retrySkillChecks.ToList() ?? new List<EntityReference>());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintClockworkScenario.RetrySkillChecks"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator RemoveFromRetrySkillChecks(params EntityReference[] retrySkillChecks)
    {
      ValidateParam(retrySkillChecks);
      return OnConfigureInternal(
          bp =>
          {
            bp.RetrySkillChecks = bp.RetrySkillChecks.Where(item => !retrySkillChecks.Contains(item)).ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.HighPriorityAnswers"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="highPriorityAnswers"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintAnswer"/></param>
    [Generated]
    public ClockworkScenarioConfigurator SetHighPriorityAnswers(string[]? highPriorityAnswers)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.HighPriorityAnswers = highPriorityAnswers.Select(name => BlueprintTool.GetRef<BlueprintAnswerReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintClockworkScenario.HighPriorityAnswers"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="highPriorityAnswers"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintAnswer"/></param>
    [Generated]
    public ClockworkScenarioConfigurator AddToHighPriorityAnswers(params string[] highPriorityAnswers)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.HighPriorityAnswers.AddRange(highPriorityAnswers.Select(name => BlueprintTool.GetRef<BlueprintAnswerReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintClockworkScenario.HighPriorityAnswers"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="highPriorityAnswers"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintAnswer"/></param>
    [Generated]
    public ClockworkScenarioConfigurator RemoveFromHighPriorityAnswers(params string[] highPriorityAnswers)
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
    /// Sets <see cref="BlueprintClockworkScenario.DoNotSellItems"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="doNotSellItems"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    public ClockworkScenarioConfigurator SetDoNotSellItems(string[]? doNotSellItems)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DoNotSellItems = doNotSellItems.Select(name => BlueprintTool.GetRef<BlueprintItemReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintClockworkScenario.DoNotSellItems"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="doNotSellItems"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    public ClockworkScenarioConfigurator AddToDoNotSellItems(params string[] doNotSellItems)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DoNotSellItems.AddRange(doNotSellItems.Select(name => BlueprintTool.GetRef<BlueprintItemReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintClockworkScenario.DoNotSellItems"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="doNotSellItems"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    public ClockworkScenarioConfigurator RemoveFromDoNotSellItems(params string[] doNotSellItems)
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
    /// Sets <see cref="BlueprintClockworkScenario.DoNotInterract"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetDoNotInterract(List<ClockworkEntityReference>? doNotInterract)
    {
      ValidateParam(doNotInterract);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.DoNotInterract = doNotInterract;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintClockworkScenario.DoNotInterract"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator AddToDoNotInterract(params ClockworkEntityReference[] doNotInterract)
    {
      ValidateParam(doNotInterract);
      return OnConfigureInternal(
          bp =>
          {
            bp.DoNotInterract.AddRange(doNotInterract.ToList() ?? new List<ClockworkEntityReference>());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintClockworkScenario.DoNotInterract"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator RemoveFromDoNotInterract(params ClockworkEntityReference[] doNotInterract)
    {
      ValidateParam(doNotInterract);
      return OnConfigureInternal(
          bp =>
          {
            bp.DoNotInterract = bp.DoNotInterract.Where(item => !doNotInterract.Contains(item)).ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.DoNotInterractUnits"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="doNotInterractUnits"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public ClockworkScenarioConfigurator SetDoNotInterractUnits(string[]? doNotInterractUnits)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DoNotInterractUnits = doNotInterractUnits.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintClockworkScenario.DoNotInterractUnits"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="doNotInterractUnits"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public ClockworkScenarioConfigurator AddToDoNotInterractUnits(params string[] doNotInterractUnits)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DoNotInterractUnits.AddRange(doNotInterractUnits.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintClockworkScenario.DoNotInterractUnits"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="doNotInterractUnits"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public ClockworkScenarioConfigurator RemoveFromDoNotInterractUnits(params string[] doNotInterractUnits)
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
    /// Sets <see cref="BlueprintClockworkScenario.DoNotUseAnswer"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="doNotUseAnswer"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintAnswer"/></param>
    [Generated]
    public ClockworkScenarioConfigurator SetDoNotUseAnswer(string[]? doNotUseAnswer)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DoNotUseAnswer = doNotUseAnswer.Select(name => BlueprintTool.GetRef<BlueprintAnswerReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintClockworkScenario.DoNotUseAnswer"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="doNotUseAnswer"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintAnswer"/></param>
    [Generated]
    public ClockworkScenarioConfigurator AddToDoNotUseAnswer(params string[] doNotUseAnswer)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DoNotUseAnswer.AddRange(doNotUseAnswer.Select(name => BlueprintTool.GetRef<BlueprintAnswerReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintClockworkScenario.DoNotUseAnswer"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="doNotUseAnswer"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintAnswer"/></param>
    [Generated]
    public ClockworkScenarioConfigurator RemoveFromDoNotUseAnswer(params string[] doNotUseAnswer)
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
    /// Sets <see cref="BlueprintClockworkScenario.DoNotEnterAreas"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="doNotEnterAreas"><see cref="Kingmaker.Blueprints.Area.BlueprintArea"/></param>
    [Generated]
    public ClockworkScenarioConfigurator SetDoNotEnterAreas(string[]? doNotEnterAreas)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DoNotEnterAreas = doNotEnterAreas.Select(name => BlueprintTool.GetRef<BlueprintAreaReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintClockworkScenario.DoNotEnterAreas"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="doNotEnterAreas"><see cref="Kingmaker.Blueprints.Area.BlueprintArea"/></param>
    [Generated]
    public ClockworkScenarioConfigurator AddToDoNotEnterAreas(params string[] doNotEnterAreas)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DoNotEnterAreas.AddRange(doNotEnterAreas.Select(name => BlueprintTool.GetRef<BlueprintAreaReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintClockworkScenario.DoNotEnterAreas"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="doNotEnterAreas"><see cref="Kingmaker.Blueprints.Area.BlueprintArea"/></param>
    [Generated]
    public ClockworkScenarioConfigurator RemoveFromDoNotEnterAreas(params string[] doNotEnterAreas)
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
    /// Sets <see cref="BlueprintClockworkScenario.m_AreaTests"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetAreaTests(Dictionary<BlueprintArea,List<AreaTest>> areaTests)
    {
      ValidateParam(areaTests);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AreaTests = areaTests;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.m_ConditionalCommandLists"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetConditionalCommandLists(List<ConditionalCommandList>? conditionalCommandLists)
    {
      ValidateParam(conditionalCommandLists);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ConditionalCommandLists = conditionalCommandLists;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintClockworkScenario.m_ConditionalCommandLists"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator AddToConditionalCommandLists(params ConditionalCommandList[] conditionalCommandLists)
    {
      ValidateParam(conditionalCommandLists);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ConditionalCommandLists.AddRange(conditionalCommandLists.ToList() ?? new List<ConditionalCommandList>());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintClockworkScenario.m_ConditionalCommandLists"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator RemoveFromConditionalCommandLists(params ConditionalCommandList[] conditionalCommandLists)
    {
      ValidateParam(conditionalCommandLists);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ConditionalCommandLists = bp.m_ConditionalCommandLists.Where(item => !conditionalCommandLists.Contains(item)).ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintClockworkScenario.m_ComponentId"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClockworkScenarioConfigurator SetComponentId(Dictionary<string,int> componentId)
    {
      ValidateParam(componentId);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ComponentId = componentId;
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
    public ClockworkScenarioConfigurator AddAreaTest(
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
    public ClockworkScenarioConfigurator AddConditionalCommandList(
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
    /// Adds <see cref="ExploreFlyingIsles"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="areas"><see cref="Kingmaker.Blueprints.Area.BlueprintArea"/></param>
    [Generated]
    [Implements(typeof(ExploreFlyingIsles))]
    public ClockworkScenarioConfigurator AddExploreFlyingIsles(
        bool justIgnoreWalls = default,
        float waitTimeAfterCamRotation = default,
        string[]? areas = null)
    {
      var component = new ExploreFlyingIsles();
      component.JustIgnoreWalls = justIgnoreWalls;
      component.WaitTimeAfterCamRotation = waitTimeAfterCamRotation;
      component.Areas = areas.Select(name => BlueprintTool.GetRef<BlueprintAreaReference>(name)).ToList();
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
    public ClockworkScenarioConfigurator AddMythicLevelUpPlan(
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
