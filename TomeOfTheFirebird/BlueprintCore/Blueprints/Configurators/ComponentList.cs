using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.AreaLogic.Etudes;
using Kingmaker.Blueprints;
using Kingmaker.Corruption;
using Kingmaker.Crusade.GlobalMagic;
using Kingmaker.Designers.EventConditionActionSystem.Events;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Localization;
using Kingmaker.Sound;
using Kingmaker.Tutorial;
using Kingmaker.Tutorial.Etudes;
using Owlcat.Runtime.Visual.Effects.WeatherSystem;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Configurator for <see cref="BlueprintComponentList"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintComponentList))]
  public class ComponentListConfigurator : BaseBlueprintConfigurator<BlueprintComponentList, ComponentListConfigurator>
  {
    private ComponentListConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ComponentListConfigurator For(string name)
    {
      return new ComponentListConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ComponentListConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintComponentList>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketEnableTutorialSingle"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="tutorial"><see cref="Kingmaker.Tutorial.BlueprintTutorial"/></param>
    [Generated]
    [Implements(typeof(EtudeBracketEnableTutorialSingle))]
    public ComponentListConfigurator AddEtudeBracketEnableTutorialSingle(
        string? tutorial = null)
    {
      var component = new EtudeBracketEnableTutorialSingle();
      component.m_Tutorial = BlueprintTool.GetRef<BlueprintTutorial.Reference>(tutorial);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketEnableTutorials"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="tutorials"><see cref="Kingmaker.Tutorial.BlueprintTutorial"/></param>
    [Generated]
    [Implements(typeof(EtudeBracketEnableTutorials))]
    public ComponentListConfigurator AddEtudeBracketEnableTutorials(
        string[]? tutorials = null)
    {
      var component = new EtudeBracketEnableTutorials();
      component.m_Tutorials = tutorials.Select(name => BlueprintTool.GetRef<BlueprintTutorial.Reference>(name)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeCorruptionFreeZone"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeCorruptionFreeZone))]
    public ComponentListConfigurator AddEtudeCorruptionFreeZone(
        bool clearAllCorruption = default)
    {
      var component = new EtudeCorruptionFreeZone();
      component.m_ClearAllCorruption = clearAllCorruption;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeDisableCooking"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeDisableCooking))]
    public ComponentListConfigurator AddEtudeDisableCooking()
    {
      return AddComponent(new EtudeDisableCooking());
    }

    /// <summary>
    /// Adds <see cref="EtudeDisableCraft"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeDisableCraft))]
    public ComponentListConfigurator AddEtudeDisableCraft()
    {
      return AddComponent(new EtudeDisableCraft());
    }

    /// <summary>
    /// Adds <see cref="EtudeOverrideCorruptionGrowth"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeOverrideCorruptionGrowth))]
    public ComponentListConfigurator AddEtudeOverrideCorruptionGrowth(
        int corruptionGrowth = default)
    {
      var component = new EtudeOverrideCorruptionGrowth();
      component.m_CorruptionGrowth = corruptionGrowth;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeCompleteTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeCompleteTrigger))]
    public ComponentListConfigurator AddEtudeCompleteTrigger(
        ActionsBuilder? actions = null)
    {
      var component = new EtudeCompleteTrigger();
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudePlayTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudePlayTrigger))]
    public ComponentListConfigurator AddEtudePlayTrigger(
        bool once = default,
        ConditionsBuilder? conditions = null,
        ActionsBuilder? actions = null)
    {
      var component = new EtudePlayTrigger();
      component.m_Once = once;
      component.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketAudioEvents"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketAudioEvents))]
    public ComponentListConfigurator AddEtudeBracketAudioEvents(
        AkEventReference[]? onEtudeStart = null,
        AkEventReference[]? onEtudeStop = null)
    {
      ValidateParam(onEtudeStart);
      ValidateParam(onEtudeStop);
    
      var component = new EtudeBracketAudioEvents();
      component.OnEtudeStart = onEtudeStart;
      component.OnEtudeStop = onEtudeStop;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketAudioObjects"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketAudioObjects))]
    public ComponentListConfigurator AddEtudeBracketAudioObjects(
        string connectedObjectName)
    {
      var component = new EtudeBracketAudioObjects();
      component.ConnectedObjectName = connectedObjectName;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketCampingAction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketCampingAction))]
    public ComponentListConfigurator AddEtudeBracketCampingAction(
        ActionsBuilder? actions = null,
        bool skipRest = default)
    {
      var component = new EtudeBracketCampingAction();
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.SkipRest = skipRest;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketDetachPet"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketDetachPet))]
    public ComponentListConfigurator AddEtudeBracketDetachPet(
        UnitEvaluator master,
        PetType petType = default)
    {
      ValidateParam(master);
    
      var component = new EtudeBracketDetachPet();
      component.Master = master;
      component.PetType = petType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketDisablePlayerRespec"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketDisablePlayerRespec))]
    public ComponentListConfigurator AddEtudeBracketDisablePlayerRespec()
    {
      return AddComponent(new EtudeBracketDisablePlayerRespec());
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketDisableRandomEncounters"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketDisableRandomEncounters))]
    public ComponentListConfigurator AddEtudeBracketDisableRandomEncounters()
    {
      return AddComponent(new EtudeBracketDisableRandomEncounters());
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketEnableAzataIsland"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="globalMap"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMap"/></param>
    /// <param name="globalMapSpell"><see cref="Kingmaker.Crusade.GlobalMagic.BlueprintGlobalMagicSpell"/></param>
    [Generated]
    [Implements(typeof(EtudeBracketEnableAzataIsland))]
    public ComponentListConfigurator AddEtudeBracketEnableAzataIsland(
        string? globalMap = null,
        string? globalMapSpell = null)
    {
      var component = new EtudeBracketEnableAzataIsland();
      component.m_GlobalMap = BlueprintTool.GetRef<BlueprintGlobalMap.Reference>(globalMap);
      component.m_GlobalMapSpell = BlueprintTool.GetRef<BlueprintGlobalMagicSpell.Reference>(globalMapSpell);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketEnableWarcamp"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="globalMap"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMap"/></param>
    [Generated]
    [Implements(typeof(EtudeBracketEnableWarcamp))]
    public ComponentListConfigurator AddEtudeBracketEnableWarcamp(
        string? globalMap = null)
    {
      var component = new EtudeBracketEnableWarcamp();
      component.m_GlobalMap = BlueprintTool.GetRef<BlueprintGlobalMap.Reference>(globalMap);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketFollowUnit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="summonPool"><see cref="Kingmaker.Blueprints.BlueprintSummonPool"/></param>
    [Generated]
    [Implements(typeof(EtudeBracketFollowUnit))]
    public ComponentListConfigurator AddEtudeBracketFollowUnit(
        UnitEvaluator leader,
        UnitEvaluator unit,
        bool useSummonPool = default,
        string? summonPool = null,
        bool alwaysRun = default,
        bool canBeSlowerThanLeader = default)
    {
      ValidateParam(leader);
      ValidateParam(unit);
    
      var component = new EtudeBracketFollowUnit();
      component.Leader = leader;
      component.UseSummonPool = useSummonPool;
      component.Unit = unit;
      component.SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(summonPool);
      component.AlwaysRun = alwaysRun;
      component.CanBeSlowerThanLeader = canBeSlowerThanLeader;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketForceCombatMode"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketForceCombatMode))]
    public ComponentListConfigurator AddEtudeBracketForceCombatMode()
    {
      return AddComponent(new EtudeBracketForceCombatMode());
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketIgnoreGameover"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketIgnoreGameover))]
    public ComponentListConfigurator AddEtudeBracketIgnoreGameover(
        EtudeBracketGameModeWaiter gameModeWaiter,
        ActionsBuilder? actionList = null)
    {
      ValidateParam(gameModeWaiter);
    
      var component = new EtudeBracketIgnoreGameover();
      component.ActionList = actionList?.Build() ?? Constants.Empty.Actions;
      component.m_GameModeWaiter = gameModeWaiter;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketMakePassive"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketMakePassive))]
    public ComponentListConfigurator AddEtudeBracketMakePassive(
        UnitEvaluator unit)
    {
      ValidateParam(unit);
    
      var component = new EtudeBracketMakePassive();
      component.Unit = unit;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketMarkUnitEssential"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketMarkUnitEssential))]
    public ComponentListConfigurator AddEtudeBracketMarkUnitEssential(
        UnitEvaluator target)
    {
      ValidateParam(target);
    
      var component = new EtudeBracketMarkUnitEssential();
      component.Target = target;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketMusic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketMusic))]
    public ComponentListConfigurator AddEtudeBracketMusic(
        AkEventReference startTheme,
        AkEventReference stopTheme)
    {
      ValidateParam(startTheme);
      ValidateParam(stopTheme);
    
      var component = new EtudeBracketMusic();
      component.StartTheme = startTheme;
      component.StopTheme = stopTheme;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketOverrideActionsOnClick"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketOverrideActionsOnClick))]
    public ComponentListConfigurator AddEtudeBracketOverrideActionsOnClick(
        UnitEvaluator unit,
        ActionsBuilder? actions = null,
        float distance = default)
    {
      ValidateParam(unit);
    
      var component = new EtudeBracketOverrideActionsOnClick();
      component.Unit = unit;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.m_Distance = distance;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketOverrideBark"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketOverrideBark))]
    public ComponentListConfigurator AddEtudeBracketOverrideBark(
        UnitEvaluator unit,
        SharedStringAsset whatToBarkShared,
        bool barkDurationByText = default,
        float distance = default)
    {
      ValidateParam(unit);
      ValidateParam(whatToBarkShared);
    
      var component = new EtudeBracketOverrideBark();
      component.Unit = unit;
      component.WhatToBarkShared = whatToBarkShared;
      component.BarkDurationByText = barkDurationByText;
      component.m_Distance = distance;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketOverrideDialog"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="dialog"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintDialog"/></param>
    [Generated]
    [Implements(typeof(EtudeBracketOverrideDialog))]
    public ComponentListConfigurator AddEtudeBracketOverrideDialog(
        UnitEvaluator unit,
        string? dialog = null,
        float distance = default)
    {
      ValidateParam(unit);
    
      var component = new EtudeBracketOverrideDialog();
      component.Unit = unit;
      component.Dialog = BlueprintTool.GetRef<BlueprintDialogReference>(dialog);
      component.m_Distance = distance;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketOverrideWeatherInclemency"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketOverrideWeatherInclemency))]
    public ComponentListConfigurator AddEtudeBracketOverrideWeatherInclemency(
        EtudeBracketGameModeWaiter gameModeWaiter,
        InclemencyType inclemency = default)
    {
      ValidateParam(gameModeWaiter);
    
      var component = new EtudeBracketOverrideWeatherInclemency();
      component.Inclemency = inclemency;
      component.m_GameModeWaiter = gameModeWaiter;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketOverrideWeatherProfile"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketOverrideWeatherProfile))]
    public ComponentListConfigurator AddEtudeBracketOverrideWeatherProfile(
        WeatherProfileExtended weatherProfile,
        EtudeBracketGameModeWaiter gameModeWaiter)
    {
      ValidateParam(weatherProfile);
      ValidateParam(gameModeWaiter);
    
      var component = new EtudeBracketOverrideWeatherProfile();
      component.m_WeatherProfile = weatherProfile;
      component.m_GameModeWaiter = gameModeWaiter;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketPinCompanionInParty"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketPinCompanionInParty))]
    public ComponentListConfigurator AddEtudeBracketPinCompanionInParty(
        UnitEvaluator unit)
    {
      ValidateParam(unit);
    
      var component = new EtudeBracketPinCompanionInParty();
      component.Unit = unit;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketPreventDirectControl"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketPreventDirectControl))]
    public ComponentListConfigurator AddEtudeBracketPreventDirectControl(
        UnitEvaluator unit)
    {
      ValidateParam(unit);
    
      var component = new EtudeBracketPreventDirectControl();
      component.Unit = unit;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketProgressBar"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketProgressBar))]
    public ComponentListConfigurator AddEtudeBracketProgressBar(
        int maxProgress = default,
        LocalizedString? title = null)
    {
      ValidateParam(title);
    
      var component = new EtudeBracketProgressBar();
      component.MaxProgress = maxProgress;
      component.Title = title ?? Constants.Empty.String;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketSetCompanionPosition"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="companion"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(EtudeBracketSetCompanionPosition))]
    public ComponentListConfigurator AddEtudeBracketSetCompanionPosition(
        EntityReference locator,
        string? companion = null,
        bool shouldRelease = default)
    {
      ValidateParam(locator);
    
      var component = new EtudeBracketSetCompanionPosition();
      component.m_Companion = BlueprintTool.GetRef<BlueprintUnitReference>(companion);
      component.m_Locator = locator;
      component.m_ShouldRelease = shouldRelease;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketShowObjects"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketShowObjects))]
    public ComponentListConfigurator AddEtudeBracketShowObjects(
        EntityReference[]? objects = null)
    {
      ValidateParam(objects);
    
      var component = new EtudeBracketShowObjects();
      component.Objects = objects;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketSummonpoolOverrideDialog"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="summonPool"><see cref="Kingmaker.Blueprints.BlueprintSummonPool"/></param>
    /// <param name="dialog"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintDialog"/></param>
    [Generated]
    [Implements(typeof(EtudeBracketSummonpoolOverrideDialog))]
    public ComponentListConfigurator AddEtudeBracketSummonpoolOverrideDialog(
        string? summonPool = null,
        string? dialog = null,
        float distance = default)
    {
      var component = new EtudeBracketSummonpoolOverrideDialog();
      component.m_SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(summonPool);
      component.Dialog = BlueprintTool.GetRef<BlueprintDialogReference>(dialog);
      component.m_Distance = distance;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketTriggerAction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketTriggerAction))]
    public ComponentListConfigurator AddEtudeBracketTriggerAction(
        ActionsBuilder? onActivated = null,
        ActionsBuilder? onDeactivated = null)
    {
      var component = new EtudeBracketTriggerAction();
      component.OnActivated = onActivated?.Build() ?? Constants.Empty.Actions;
      component.OnDeactivated = onDeactivated?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeIgnorePartyEncumbrance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeIgnorePartyEncumbrance))]
    public ComponentListConfigurator AddEtudeIgnorePartyEncumbrance()
    {
      return AddComponent(new EtudeIgnorePartyEncumbrance());
    }

    /// <summary>
    /// Adds <see cref="EtudeIgnorePersonalEncumbrance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeIgnorePersonalEncumbrance))]
    public ComponentListConfigurator AddEtudeIgnorePersonalEncumbrance()
    {
      return AddComponent(new EtudeIgnorePersonalEncumbrance());
    }

    /// <summary>
    /// Adds <see cref="EtudePeacefulZone"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudePeacefulZone))]
    public ComponentListConfigurator AddEtudePeacefulZone()
    {
      return AddComponent(new EtudePeacefulZone());
    }
  }
}
