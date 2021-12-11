using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Enums;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.AI;
using Kingmaker.Kingdom.Buffs;
using Kingmaker.Localization;
using Kingmaker.RandomEncounters.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintArea"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintArea))]
  public abstract class BaseAreaConfigurator<T, TBuilder>
      : BaseAreaPartConfigurator<T, TBuilder>
      where T : BlueprintArea
      where TBuilder : BaseAreaConfigurator<T, TBuilder>
  {
    protected BaseAreaConfigurator(string name) : base(name) { }

    /// <summary>
    /// Sets <see cref="BlueprintArea.m_Parts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="parts"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaPart"/></param>
    [Generated]
    public TBuilder SetParts(string[]? parts)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Parts = parts.Select(name => BlueprintTool.GetRef<BlueprintAreaPartReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintArea.m_Parts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="parts"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaPart"/></param>
    [Generated]
    public TBuilder AddToParts(params string[] parts)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Parts.AddRange(parts.Select(name => BlueprintTool.GetRef<BlueprintAreaPartReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintArea.m_Parts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="parts"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaPart"/></param>
    [Generated]
    public TBuilder RemoveFromParts(params string[] parts)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = parts.Select(name => BlueprintTool.GetRef<BlueprintAreaPartReference>(name));
            bp.m_Parts =
                bp.m_Parts
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.IsGlobalMap"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetIsGlobalMap(bool isGlobalMap)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IsGlobalMap = isGlobalMap;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.CameraScrollMultiplier"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetCameraScrollMultiplier(float cameraScrollMultiplier)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CameraScrollMultiplier = cameraScrollMultiplier;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.SetDefaultCameraRotation"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetDefaultCameraRotation(bool setDefaultCameraRotation)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.SetDefaultCameraRotation = setDefaultCameraRotation;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.CameraRotation"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetCameraRotation(float cameraRotation)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CameraRotation = cameraRotation;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.CampingSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetCampingSettings(CampingSettings campingSettings)
    {
      ValidateParam(campingSettings);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.CampingSettings = campingSettings;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.RandomEncounterSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetRandomEncounterSettings(RandomEncounterSettings randomEncounterSettings)
    {
      ValidateParam(randomEncounterSettings);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.RandomEncounterSettings = randomEncounterSettings;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.Designer"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetDesigner(BlueprintArea.Designers designer)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Designer = designer;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.ArtSetting"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetArtSetting(BlueprintArea.SettingType artSetting)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ArtSetting = artSetting;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.AreaName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetAreaName(LocalizedString? areaName)
    {
      ValidateParam(areaName);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.AreaName = areaName ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.ExcludeFromSave"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetExcludeFromSave(bool excludeFromSave)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ExcludeFromSave = excludeFromSave;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.PS4ChunkId"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetPS4ChunkId(PS4ChunkId pS4ChunkId)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.PS4ChunkId = pS4ChunkId;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.LoadingScreenSprites"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetLoadingScreenSprites(List<Sprite>? loadingScreenSprites)
    {
      ValidateParam(loadingScreenSprites);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.LoadingScreenSprites = loadingScreenSprites;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintArea.LoadingScreenSprites"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder AddToLoadingScreenSprites(params Sprite[] loadingScreenSprites)
    {
      ValidateParam(loadingScreenSprites);
      return OnConfigureInternal(
          bp =>
          {
            bp.LoadingScreenSprites.AddRange(loadingScreenSprites.ToList() ?? new List<Sprite>());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintArea.LoadingScreenSprites"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder RemoveFromLoadingScreenSprites(params Sprite[] loadingScreenSprites)
    {
      ValidateParam(loadingScreenSprites);
      return OnConfigureInternal(
          bp =>
          {
            bp.LoadingScreenSprites = bp.LoadingScreenSprites.Where(item => !loadingScreenSprites.Contains(item)).ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.m_DefaultPreset"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="defaultPreset"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaPreset"/></param>
    [Generated]
    public TBuilder SetDefaultPreset(string? defaultPreset)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DefaultPreset = BlueprintTool.GetRef<BlueprintAreaPresetReference>(defaultPreset);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.CR"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetCR(int cR)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CR = cR;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.OverrideCorruption"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetOverrideCorruption(bool overrideCorruption)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.OverrideCorruption = overrideCorruption;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.CorruptionGrowth"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetCorruptionGrowth(int corruptionGrowth)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CorruptionGrowth = corruptionGrowth;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.LootSetting"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetLootSetting(LootSetting lootSetting)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.LootSetting = lootSetting;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.m_HotAreas"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="hotAreas"><see cref="Kingmaker.Blueprints.Area.BlueprintArea"/></param>
    [Generated]
    public TBuilder SetHotAreas(string[]? hotAreas)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_HotAreas = hotAreas.Select(name => BlueprintTool.GetRef<BlueprintAreaReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintArea.m_HotAreas"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="hotAreas"><see cref="Kingmaker.Blueprints.Area.BlueprintArea"/></param>
    [Generated]
    public TBuilder AddToHotAreas(params string[] hotAreas)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_HotAreas = CommonTool.Append(bp.m_HotAreas, hotAreas.Select(name => BlueprintTool.GetRef<BlueprintAreaReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintArea.m_HotAreas"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="hotAreas"><see cref="Kingmaker.Blueprints.Area.BlueprintArea"/></param>
    [Generated]
    public TBuilder RemoveFromHotAreas(params string[] hotAreas)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = hotAreas.Select(name => BlueprintTool.GetRef<BlueprintAreaReference>(name));
            bp.m_HotAreas =
                bp.m_HotAreas
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Adds <see cref="CombatRandomEncounterAreaSettings"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="defaultEnterPoint"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaEnterPoint"/></param>
    /// <param name="goodAvoidanceEnterPoint"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaEnterPoint"/></param>
    [Generated]
    [Implements(typeof(CombatRandomEncounterAreaSettings))]
    public TBuilder AddCombatRandomEncounterAreaSettings(
        string? defaultEnterPoint = null,
        string? goodAvoidanceEnterPoint = null,
        GlobalMapZone[]? allowedNaturalSettings = null,
        CombatRandomEncounterAreaSettings.Formation[]? formations = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(formations);
    
      var component = new CombatRandomEncounterAreaSettings();
      component.m_DefaultEnterPoint = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(defaultEnterPoint);
      component.m_GoodAvoidanceEnterPoint = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(goodAvoidanceEnterPoint);
      component.AllowedNaturalSettings = allowedNaturalSettings;
      component.Formations = formations;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AreaSettlementLink"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="settlementRef"><see cref="Kingmaker.Kingdom.BlueprintSettlement"/></param>
    [Generated]
    [Implements(typeof(AreaSettlementLink))]
    public TBuilder AddAreaSettlementLink(
        string? settlementRef = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AreaSettlementLink();
      component.SettlementRef = BlueprintTool.GetRef<BlueprintSettlement.Reference>(settlementRef);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="OverrideCampingAction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(OverrideCampingAction))]
    public TBuilder AddOverrideCampingAction(
        ActionsBuilder? onRestActions = null,
        bool skipRest = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new OverrideCampingAction();
      component.OnRestActions = onRestActions?.Build() ?? Constants.Empty.Actions;
      component.SkipRest = skipRest;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="BirthdayTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BirthdayTrigger))]
    public TBuilder AddBirthdayTrigger(
        ConditionsBuilder? condition = null,
        ActionsBuilder? actions = null)
    {
      var component = new BirthdayTrigger();
      component.Condition = condition?.Build() ?? Constants.Empty.Conditions;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EveryDayTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EveryDayTrigger))]
    public TBuilder AddEveryDayTrigger(
        ConditionsBuilder? condition = null,
        ActionsBuilder? actions = null,
        int skipDays = default)
    {
      var component = new EveryDayTrigger();
      component.Condition = condition?.Build() ?? Constants.Empty.Conditions;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.SkipDays = skipDays;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EveryWeekTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EveryWeekTrigger))]
    public TBuilder AddEveryWeekTrigger(
        ConditionsBuilder? condition = null,
        ActionsBuilder? actions = null,
        int skipWeeks = default)
    {
      var component = new EveryWeekTrigger();
      component.Condition = condition?.Build() ?? Constants.Empty.Conditions;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.SkipWeeks = skipWeeks;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SettlementAISettings"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="aIBuildListVillage"><see cref="Kingmaker.Kingdom.AI.SettlementBuildList"/></param>
    /// <param name="aIBuildListTown"><see cref="Kingmaker.Kingdom.AI.SettlementBuildList"/></param>
    /// <param name="aIBuildListCity"><see cref="Kingmaker.Kingdom.AI.SettlementBuildList"/></param>
    [Generated]
    [Implements(typeof(SettlementAISettings))]
    public TBuilder AddSettlementAISettings(
        string? aIBuildListVillage = null,
        string? aIBuildListTown = null,
        string? aIBuildListCity = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new SettlementAISettings();
      component.m_AIBuildListVillage = BlueprintTool.GetRef<SettlementBuildListReference>(aIBuildListVillage);
      component.m_AIBuildListTown = BlueprintTool.GetRef<SettlementBuildListReference>(aIBuildListTown);
      component.m_AIBuildListCity = BlueprintTool.GetRef<SettlementBuildListReference>(aIBuildListCity);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }
  }

  /// <summary>
  /// Configurator for <see cref="BlueprintArea"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintArea))]
  public class AreaConfigurator : BaseAreaPartConfigurator<BlueprintArea, AreaConfigurator>
  {
    private AreaConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AreaConfigurator For(string name)
    {
      return new AreaConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AreaConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintArea>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.m_Parts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="parts"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaPart"/></param>
    [Generated]
    public AreaConfigurator SetParts(string[]? parts)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Parts = parts.Select(name => BlueprintTool.GetRef<BlueprintAreaPartReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintArea.m_Parts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="parts"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaPart"/></param>
    [Generated]
    public AreaConfigurator AddToParts(params string[] parts)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Parts.AddRange(parts.Select(name => BlueprintTool.GetRef<BlueprintAreaPartReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintArea.m_Parts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="parts"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaPart"/></param>
    [Generated]
    public AreaConfigurator RemoveFromParts(params string[] parts)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = parts.Select(name => BlueprintTool.GetRef<BlueprintAreaPartReference>(name));
            bp.m_Parts =
                bp.m_Parts
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.IsGlobalMap"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaConfigurator SetIsGlobalMap(bool isGlobalMap)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IsGlobalMap = isGlobalMap;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.CameraScrollMultiplier"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaConfigurator SetCameraScrollMultiplier(float cameraScrollMultiplier)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CameraScrollMultiplier = cameraScrollMultiplier;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.SetDefaultCameraRotation"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaConfigurator SetDefaultCameraRotation(bool setDefaultCameraRotation)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.SetDefaultCameraRotation = setDefaultCameraRotation;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.CameraRotation"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaConfigurator SetCameraRotation(float cameraRotation)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CameraRotation = cameraRotation;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.CampingSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaConfigurator SetCampingSettings(CampingSettings campingSettings)
    {
      ValidateParam(campingSettings);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.CampingSettings = campingSettings;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.RandomEncounterSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaConfigurator SetRandomEncounterSettings(RandomEncounterSettings randomEncounterSettings)
    {
      ValidateParam(randomEncounterSettings);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.RandomEncounterSettings = randomEncounterSettings;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.Designer"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaConfigurator SetDesigner(BlueprintArea.Designers designer)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Designer = designer;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.ArtSetting"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaConfigurator SetArtSetting(BlueprintArea.SettingType artSetting)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ArtSetting = artSetting;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.AreaName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaConfigurator SetAreaName(LocalizedString? areaName)
    {
      ValidateParam(areaName);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.AreaName = areaName ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.ExcludeFromSave"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaConfigurator SetExcludeFromSave(bool excludeFromSave)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ExcludeFromSave = excludeFromSave;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.PS4ChunkId"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaConfigurator SetPS4ChunkId(PS4ChunkId pS4ChunkId)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.PS4ChunkId = pS4ChunkId;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.LoadingScreenSprites"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaConfigurator SetLoadingScreenSprites(List<Sprite>? loadingScreenSprites)
    {
      ValidateParam(loadingScreenSprites);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.LoadingScreenSprites = loadingScreenSprites;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintArea.LoadingScreenSprites"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaConfigurator AddToLoadingScreenSprites(params Sprite[] loadingScreenSprites)
    {
      ValidateParam(loadingScreenSprites);
      return OnConfigureInternal(
          bp =>
          {
            bp.LoadingScreenSprites.AddRange(loadingScreenSprites.ToList() ?? new List<Sprite>());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintArea.LoadingScreenSprites"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaConfigurator RemoveFromLoadingScreenSprites(params Sprite[] loadingScreenSprites)
    {
      ValidateParam(loadingScreenSprites);
      return OnConfigureInternal(
          bp =>
          {
            bp.LoadingScreenSprites = bp.LoadingScreenSprites.Where(item => !loadingScreenSprites.Contains(item)).ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.m_DefaultPreset"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="defaultPreset"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaPreset"/></param>
    [Generated]
    public AreaConfigurator SetDefaultPreset(string? defaultPreset)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DefaultPreset = BlueprintTool.GetRef<BlueprintAreaPresetReference>(defaultPreset);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.CR"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaConfigurator SetCR(int cR)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CR = cR;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.OverrideCorruption"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaConfigurator SetOverrideCorruption(bool overrideCorruption)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.OverrideCorruption = overrideCorruption;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.CorruptionGrowth"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaConfigurator SetCorruptionGrowth(int corruptionGrowth)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CorruptionGrowth = corruptionGrowth;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.LootSetting"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaConfigurator SetLootSetting(LootSetting lootSetting)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.LootSetting = lootSetting;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.m_HotAreas"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="hotAreas"><see cref="Kingmaker.Blueprints.Area.BlueprintArea"/></param>
    [Generated]
    public AreaConfigurator SetHotAreas(string[]? hotAreas)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_HotAreas = hotAreas.Select(name => BlueprintTool.GetRef<BlueprintAreaReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintArea.m_HotAreas"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="hotAreas"><see cref="Kingmaker.Blueprints.Area.BlueprintArea"/></param>
    [Generated]
    public AreaConfigurator AddToHotAreas(params string[] hotAreas)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_HotAreas = CommonTool.Append(bp.m_HotAreas, hotAreas.Select(name => BlueprintTool.GetRef<BlueprintAreaReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintArea.m_HotAreas"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="hotAreas"><see cref="Kingmaker.Blueprints.Area.BlueprintArea"/></param>
    [Generated]
    public AreaConfigurator RemoveFromHotAreas(params string[] hotAreas)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = hotAreas.Select(name => BlueprintTool.GetRef<BlueprintAreaReference>(name));
            bp.m_HotAreas =
                bp.m_HotAreas
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Adds <see cref="CombatRandomEncounterAreaSettings"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="defaultEnterPoint"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaEnterPoint"/></param>
    /// <param name="goodAvoidanceEnterPoint"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaEnterPoint"/></param>
    [Generated]
    [Implements(typeof(CombatRandomEncounterAreaSettings))]
    public AreaConfigurator AddCombatRandomEncounterAreaSettings(
        string? defaultEnterPoint = null,
        string? goodAvoidanceEnterPoint = null,
        GlobalMapZone[]? allowedNaturalSettings = null,
        CombatRandomEncounterAreaSettings.Formation[]? formations = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(formations);
    
      var component = new CombatRandomEncounterAreaSettings();
      component.m_DefaultEnterPoint = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(defaultEnterPoint);
      component.m_GoodAvoidanceEnterPoint = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(goodAvoidanceEnterPoint);
      component.AllowedNaturalSettings = allowedNaturalSettings;
      component.Formations = formations;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AreaSettlementLink"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="settlementRef"><see cref="Kingmaker.Kingdom.BlueprintSettlement"/></param>
    [Generated]
    [Implements(typeof(AreaSettlementLink))]
    public AreaConfigurator AddAreaSettlementLink(
        string? settlementRef = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AreaSettlementLink();
      component.SettlementRef = BlueprintTool.GetRef<BlueprintSettlement.Reference>(settlementRef);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="OverrideCampingAction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(OverrideCampingAction))]
    public AreaConfigurator AddOverrideCampingAction(
        ActionsBuilder? onRestActions = null,
        bool skipRest = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new OverrideCampingAction();
      component.OnRestActions = onRestActions?.Build() ?? Constants.Empty.Actions;
      component.SkipRest = skipRest;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="BirthdayTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BirthdayTrigger))]
    public AreaConfigurator AddBirthdayTrigger(
        ConditionsBuilder? condition = null,
        ActionsBuilder? actions = null)
    {
      var component = new BirthdayTrigger();
      component.Condition = condition?.Build() ?? Constants.Empty.Conditions;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EveryDayTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EveryDayTrigger))]
    public AreaConfigurator AddEveryDayTrigger(
        ConditionsBuilder? condition = null,
        ActionsBuilder? actions = null,
        int skipDays = default)
    {
      var component = new EveryDayTrigger();
      component.Condition = condition?.Build() ?? Constants.Empty.Conditions;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.SkipDays = skipDays;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EveryWeekTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EveryWeekTrigger))]
    public AreaConfigurator AddEveryWeekTrigger(
        ConditionsBuilder? condition = null,
        ActionsBuilder? actions = null,
        int skipWeeks = default)
    {
      var component = new EveryWeekTrigger();
      component.Condition = condition?.Build() ?? Constants.Empty.Conditions;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.SkipWeeks = skipWeeks;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SettlementAISettings"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="aIBuildListVillage"><see cref="Kingmaker.Kingdom.AI.SettlementBuildList"/></param>
    /// <param name="aIBuildListTown"><see cref="Kingmaker.Kingdom.AI.SettlementBuildList"/></param>
    /// <param name="aIBuildListCity"><see cref="Kingmaker.Kingdom.AI.SettlementBuildList"/></param>
    [Generated]
    [Implements(typeof(SettlementAISettings))]
    public AreaConfigurator AddSettlementAISettings(
        string? aIBuildListVillage = null,
        string? aIBuildListTown = null,
        string? aIBuildListCity = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new SettlementAISettings();
      component.m_AIBuildListVillage = BlueprintTool.GetRef<SettlementBuildListReference>(aIBuildListVillage);
      component.m_AIBuildListTown = BlueprintTool.GetRef<SettlementBuildListReference>(aIBuildListTown);
      component.m_AIBuildListCity = BlueprintTool.GetRef<SettlementBuildListReference>(aIBuildListCity);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }
  }
}
