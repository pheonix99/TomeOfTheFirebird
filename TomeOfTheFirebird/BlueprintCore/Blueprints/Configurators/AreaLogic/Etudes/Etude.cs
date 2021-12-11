using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.AreaLogic.Capital;
using Kingmaker.AreaLogic.Etudes;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Controllers.Rest;
using Kingmaker.Corruption;
using Kingmaker.Crusade.GlobalMagic;
using Kingmaker.Designers.EventConditionActionSystem.Events;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Kingdom.Buffs;
using Kingmaker.Localization;
using Kingmaker.Sound;
using Kingmaker.Tutorial;
using Kingmaker.Tutorial.Etudes;
using Owlcat.Runtime.Visual.Effects.WeatherSystem;
using System;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.AreaLogic.Etudes
{
  /// <summary>
  /// Configurator for <see cref="BlueprintEtude"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintEtude))]
  public class EtudeConfigurator : BaseFactConfigurator<BlueprintEtude, EtudeConfigurator>
  {
    private EtudeConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static EtudeConfigurator For(string name)
    {
      return new EtudeConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static EtudeConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintEtude>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintEtude.m_Parent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="parent"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude"/></param>
    [Generated]
    public EtudeConfigurator SetParent(string? parent)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Parent = BlueprintTool.GetRef<BlueprintEtudeReference>(parent);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintEtude.ActivationCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    public EtudeConfigurator SetActivationCondition(ConditionsBuilder? activationCondition)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ActivationCondition = activationCondition?.Build() ?? Constants.Empty.Conditions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintEtude.CompletionCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    public EtudeConfigurator SetCompletionCondition(ConditionsBuilder? completionCondition)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CompletionCondition = completionCondition?.Build() ?? Constants.Empty.Conditions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintEtude.m_Synchronized"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="synchronized"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude"/></param>
    [Generated]
    public EtudeConfigurator SetSynchronized(string[]? synchronized)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Synchronized = synchronized.Select(name => BlueprintTool.GetRef<BlueprintEtudeReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintEtude.m_Synchronized"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="synchronized"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude"/></param>
    [Generated]
    public EtudeConfigurator AddToSynchronized(params string[] synchronized)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Synchronized.AddRange(synchronized.Select(name => BlueprintTool.GetRef<BlueprintEtudeReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintEtude.m_Synchronized"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="synchronized"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude"/></param>
    [Generated]
    public EtudeConfigurator RemoveFromSynchronized(params string[] synchronized)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = synchronized.Select(name => BlueprintTool.GetRef<BlueprintEtudeReference>(name));
            bp.m_Synchronized =
                bp.m_Synchronized
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintEtude.m_AllowActionStart"/> (Auto Generated)
    /// </summary>
    [Generated]
    public EtudeConfigurator SetAllowActionStart(bool allowActionStart)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AllowActionStart = allowActionStart;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintEtude.m_LinkedAreaPart"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="linkedAreaPart"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaPart"/></param>
    [Generated]
    public EtudeConfigurator SetLinkedAreaPart(string? linkedAreaPart)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_LinkedAreaPart = BlueprintTool.GetRef<BlueprintAreaPartReference>(linkedAreaPart);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintEtude.m_IncludeAreaParts"/> (Auto Generated)
    /// </summary>
    [Generated]
    public EtudeConfigurator SetIncludeAreaParts(bool includeAreaParts)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_IncludeAreaParts = includeAreaParts;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintEtude.m_AddedAreaMechanics"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="addedAreaMechanics"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaMechanics"/></param>
    [Generated]
    public EtudeConfigurator SetAddedAreaMechanics(string[]? addedAreaMechanics)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AddedAreaMechanics = addedAreaMechanics.Select(name => BlueprintTool.GetRef<BlueprintAreaMechanicsReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintEtude.m_AddedAreaMechanics"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="addedAreaMechanics"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaMechanics"/></param>
    [Generated]
    public EtudeConfigurator AddToAddedAreaMechanics(params string[] addedAreaMechanics)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AddedAreaMechanics.AddRange(addedAreaMechanics.Select(name => BlueprintTool.GetRef<BlueprintAreaMechanicsReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintEtude.m_AddedAreaMechanics"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="addedAreaMechanics"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaMechanics"/></param>
    [Generated]
    public EtudeConfigurator RemoveFromAddedAreaMechanics(params string[] addedAreaMechanics)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = addedAreaMechanics.Select(name => BlueprintTool.GetRef<BlueprintAreaMechanicsReference>(name));
            bp.m_AddedAreaMechanics =
                bp.m_AddedAreaMechanics
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintEtude.m_StartsWith"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="startsWith"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude"/></param>
    [Generated]
    public EtudeConfigurator SetStartsWith(string[]? startsWith)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_StartsWith = startsWith.Select(name => BlueprintTool.GetRef<BlueprintEtudeReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintEtude.m_StartsWith"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="startsWith"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude"/></param>
    [Generated]
    public EtudeConfigurator AddToStartsWith(params string[] startsWith)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_StartsWith.AddRange(startsWith.Select(name => BlueprintTool.GetRef<BlueprintEtudeReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintEtude.m_StartsWith"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="startsWith"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude"/></param>
    [Generated]
    public EtudeConfigurator RemoveFromStartsWith(params string[] startsWith)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = startsWith.Select(name => BlueprintTool.GetRef<BlueprintEtudeReference>(name));
            bp.m_StartsWith =
                bp.m_StartsWith
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintEtude.m_StartsOnComplete"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="startsOnComplete"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude"/></param>
    [Generated]
    public EtudeConfigurator SetStartsOnComplete(string[]? startsOnComplete)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_StartsOnComplete = startsOnComplete.Select(name => BlueprintTool.GetRef<BlueprintEtudeReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintEtude.m_StartsOnComplete"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="startsOnComplete"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude"/></param>
    [Generated]
    public EtudeConfigurator AddToStartsOnComplete(params string[] startsOnComplete)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_StartsOnComplete.AddRange(startsOnComplete.Select(name => BlueprintTool.GetRef<BlueprintEtudeReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintEtude.m_StartsOnComplete"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="startsOnComplete"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude"/></param>
    [Generated]
    public EtudeConfigurator RemoveFromStartsOnComplete(params string[] startsOnComplete)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = startsOnComplete.Select(name => BlueprintTool.GetRef<BlueprintEtudeReference>(name));
            bp.m_StartsOnComplete =
                bp.m_StartsOnComplete
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintEtude.m_StartsParent"/> (Auto Generated)
    /// </summary>
    [Generated]
    public EtudeConfigurator SetStartsParent(bool startsParent)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_StartsParent = startsParent;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintEtude.m_CompletesParent"/> (Auto Generated)
    /// </summary>
    [Generated]
    public EtudeConfigurator SetCompletesParent(bool completesParent)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CompletesParent = completesParent;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintEtude.m_ConflictingGroups"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="conflictingGroups"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtudeConflictingGroup"/></param>
    [Generated]
    public EtudeConfigurator SetConflictingGroups(string[]? conflictingGroups)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ConflictingGroups = conflictingGroups.Select(name => BlueprintTool.GetRef<BlueprintEtudeConflictingGroupReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintEtude.m_ConflictingGroups"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="conflictingGroups"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtudeConflictingGroup"/></param>
    [Generated]
    public EtudeConfigurator AddToConflictingGroups(params string[] conflictingGroups)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ConflictingGroups.AddRange(conflictingGroups.Select(name => BlueprintTool.GetRef<BlueprintEtudeConflictingGroupReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintEtude.m_ConflictingGroups"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="conflictingGroups"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtudeConflictingGroup"/></param>
    [Generated]
    public EtudeConfigurator RemoveFromConflictingGroups(params string[] conflictingGroups)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = conflictingGroups.Select(name => BlueprintTool.GetRef<BlueprintEtudeConflictingGroupReference>(name));
            bp.m_ConflictingGroups =
                bp.m_ConflictingGroups
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintEtude.Priority"/> (Auto Generated)
    /// </summary>
    [Generated]
    public EtudeConfigurator SetPriority(int priority)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Priority = priority;
          });
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketEnableTutorialSingle"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="tutorial"><see cref="Kingmaker.Tutorial.BlueprintTutorial"/></param>
    [Generated]
    [Implements(typeof(EtudeBracketEnableTutorialSingle))]
    public EtudeConfigurator AddEtudeBracketEnableTutorialSingle(
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
    public EtudeConfigurator AddEtudeBracketEnableTutorials(
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
    public EtudeConfigurator AddEtudeCorruptionFreeZone(
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
    public EtudeConfigurator AddEtudeDisableCooking()
    {
      return AddComponent(new EtudeDisableCooking());
    }

    /// <summary>
    /// Adds <see cref="EtudeDisableCraft"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeDisableCraft))]
    public EtudeConfigurator AddEtudeDisableCraft()
    {
      return AddComponent(new EtudeDisableCraft());
    }

    /// <summary>
    /// Adds <see cref="EtudeOverrideCorruptionGrowth"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeOverrideCorruptionGrowth))]
    public EtudeConfigurator AddEtudeOverrideCorruptionGrowth(
        int corruptionGrowth = default)
    {
      var component = new EtudeOverrideCorruptionGrowth();
      component.m_CorruptionGrowth = corruptionGrowth;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BirthdayTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BirthdayTrigger))]
    public EtudeConfigurator AddBirthdayTrigger(
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
    public EtudeConfigurator AddEveryDayTrigger(
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
    public EtudeConfigurator AddEveryWeekTrigger(
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
    /// Adds <see cref="EtudeCompleteTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeCompleteTrigger))]
    public EtudeConfigurator AddEtudeCompleteTrigger(
        ActionsBuilder? actions = null)
    {
      var component = new EtudeCompleteTrigger();
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeInvokeActionsDelayed"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeInvokeActionsDelayed))]
    public EtudeConfigurator AddEtudeInvokeActionsDelayed(
        int days = default,
        ActionsBuilder? actionList = null)
    {
      var component = new EtudeInvokeActionsDelayed();
      component.m_Days = days;
      component.m_ActionList = actionList?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudePlayTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudePlayTrigger))]
    public EtudeConfigurator AddEtudePlayTrigger(
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
    /// Adds <see cref="DisableMountRiding"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DisableMountRiding))]
    public EtudeConfigurator AddDisableMountRiding(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new DisableMountRiding();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketAudioEvents"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketAudioEvents))]
    public EtudeConfigurator AddEtudeBracketAudioEvents(
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
    public EtudeConfigurator AddEtudeBracketAudioObjects(
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
    public EtudeConfigurator AddEtudeBracketCampingAction(
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
    public EtudeConfigurator AddEtudeBracketDetachPet(
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
    public EtudeConfigurator AddEtudeBracketDisablePlayerRespec()
    {
      return AddComponent(new EtudeBracketDisablePlayerRespec());
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketDisableRandomEncounters"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketDisableRandomEncounters))]
    public EtudeConfigurator AddEtudeBracketDisableRandomEncounters()
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
    public EtudeConfigurator AddEtudeBracketEnableAzataIsland(
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
    public EtudeConfigurator AddEtudeBracketEnableWarcamp(
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
    public EtudeConfigurator AddEtudeBracketFollowUnit(
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
    public EtudeConfigurator AddEtudeBracketForceCombatMode()
    {
      return AddComponent(new EtudeBracketForceCombatMode());
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketIgnoreGameover"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketIgnoreGameover))]
    public EtudeConfigurator AddEtudeBracketIgnoreGameover(
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
    public EtudeConfigurator AddEtudeBracketMakePassive(
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
    public EtudeConfigurator AddEtudeBracketMarkUnitEssential(
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
    public EtudeConfigurator AddEtudeBracketMusic(
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
    public EtudeConfigurator AddEtudeBracketOverrideActionsOnClick(
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
    public EtudeConfigurator AddEtudeBracketOverrideBark(
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
    public EtudeConfigurator AddEtudeBracketOverrideDialog(
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
    public EtudeConfigurator AddEtudeBracketOverrideWeatherInclemency(
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
    public EtudeConfigurator AddEtudeBracketOverrideWeatherProfile(
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
    public EtudeConfigurator AddEtudeBracketPinCompanionInParty(
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
    public EtudeConfigurator AddEtudeBracketPreventDirectControl(
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
    public EtudeConfigurator AddEtudeBracketProgressBar(
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
    /// Adds <see cref="EtudeBracketRestPhase"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeBracketRestPhase))]
    public EtudeConfigurator AddEtudeBracketRestPhase(
        bool multiplePhases = default,
        RestPhase phase = default,
        RestPhase firstPhase = default,
        RestPhase lastPhase = default,
        ActionsBuilder? onStart = null,
        ActionsBuilder? onStop = null,
        bool hasStarted = default)
    {
      var component = new EtudeBracketRestPhase();
      component.MultiplePhases = multiplePhases;
      component.Phase = phase;
      component.FirstPhase = firstPhase;
      component.LastPhase = lastPhase;
      component.OnStart = onStart?.Build() ?? Constants.Empty.Actions;
      component.OnStop = onStop?.Build() ?? Constants.Empty.Actions;
      component.HasStarted = hasStarted;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketSetCompanionPosition"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="companion"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(EtudeBracketSetCompanionPosition))]
    public EtudeConfigurator AddEtudeBracketSetCompanionPosition(
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
    public EtudeConfigurator AddEtudeBracketShowObjects(
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
    public EtudeConfigurator AddEtudeBracketSummonpoolOverrideDialog(
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
    public EtudeConfigurator AddEtudeBracketTriggerAction(
        ActionsBuilder? onActivated = null,
        ActionsBuilder? onDeactivated = null)
    {
      var component = new EtudeBracketTriggerAction();
      component.OnActivated = onActivated?.Build() ?? Constants.Empty.Actions;
      component.OnDeactivated = onDeactivated?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeGameOverTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeGameOverTrigger))]
    public EtudeConfigurator AddEtudeGameOverTrigger(
        ActionsBuilder? onGameOver = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new EtudeGameOverTrigger();
      component.OnGameOver = onGameOver?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="EtudeIgnorePartyEncumbrance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeIgnorePartyEncumbrance))]
    public EtudeConfigurator AddEtudeIgnorePartyEncumbrance()
    {
      return AddComponent(new EtudeIgnorePartyEncumbrance());
    }

    /// <summary>
    /// Adds <see cref="EtudeIgnorePersonalEncumbrance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudeIgnorePersonalEncumbrance))]
    public EtudeConfigurator AddEtudeIgnorePersonalEncumbrance()
    {
      return AddComponent(new EtudeIgnorePersonalEncumbrance());
    }

    /// <summary>
    /// Adds <see cref="EtudePeacefulZone"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EtudePeacefulZone))]
    public EtudeConfigurator AddEtudePeacefulZone()
    {
      return AddComponent(new EtudePeacefulZone());
    }

    /// <summary>
    /// Adds <see cref="HideAllPets"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(HideAllPets))]
    public EtudeConfigurator AddHideAllPets(
        bool leaveAzataDragon = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new HideAllPets();
      component.LeaveAzataDragon = leaveAzataDragon;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="CapitalCompanionLogic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CapitalCompanionLogic))]
    public EtudeConfigurator AddCapitalCompanionLogic(
        bool restAllRemoteCompanions = default)
    {
      var component = new CapitalCompanionLogic();
      component.m_RestAllRemoteCompanions = restAllRemoteCompanions;
      return AddComponent(component);
    }
  }
}
