using BlueprintCore.Utils;
using Kingmaker.AreaLogic.Capital;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Corruption;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Dungeon.Actions;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Persistence;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Localization;
using System.Linq;

#nullable enable
namespace BlueprintCore.Actions.Builder.AreaEx
{
  /// <summary>
  /// Extension to <see cref="ActionsBuilder"/> for actions involving the game map, dungeons, or locations. See also
  /// <see cref="KingdomEx.ActionsBuilderKingdomEx">KingdomEx</see>.
  /// </summary>
  /// <inheritdoc cref="ActionsBuilder"/>
  public static class ActionsBuilderAreaEx
  {
    //----- Kingmaker.Dungeon.Actions -----//

    /// <summary>
    /// Adds <see cref="ActionCreateImportedCompanion"/>
    /// </summary>
    [Implements(typeof(ActionCreateImportedCompanion))]
    public static ActionsBuilder CreateImportedCompanion(this ActionsBuilder builder, int index)
    {
      var createCompanion = ElementTool.Create<ActionCreateImportedCompanion>();
      createCompanion.Index = index;
      return builder.Add(createCompanion);
    }

    /// <summary>
    /// Adds <see cref="ActionEnterToDungeon"/>
    /// </summary>
    [Implements(typeof(ActionEnterToDungeon))]
    public static ActionsBuilder TeleportToLastDungeonStageEntrance(this ActionsBuilder builder, int minStage = 1)
    {
      var teleport = ElementTool.Create<ActionEnterToDungeon>();
      teleport.FirstStage = minStage;
      return builder.Add(teleport);
    }


    /// <summary>
    /// Adds <see cref="ActionGoDeeperIntoDungeon"/>
    /// </summary>
    [Implements(typeof(ActionGoDeeperIntoDungeon))]
    public static ActionsBuilder EnterNextDungeonStage(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ActionGoDeeperIntoDungeon>());
    }

    /// <summary>
    /// Adds <see cref="ActionIncreaseDungeonStage"/>
    /// </summary>
    [Implements(typeof(ActionIncreaseDungeonStage))]
    public static ActionsBuilder IncrementDungeonStage(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ActionIncreaseDungeonStage>());
    }

    /// <summary>
    /// Adds <see cref="ActionSetDungeonStage"/>
    /// </summary>
    [Implements(typeof(ActionSetDungeonStage))]
    public static ActionsBuilder SetDungeonStage(this ActionsBuilder builder, int stage = 1)
    {
      var setStage = ElementTool.Create<ActionSetDungeonStage>();
      setStage.Stage = stage;
      return builder.Add(setStage);
    }

    //----- Kingmaker.Designers.EventConditionActionSystem.Actions -----//

    /// <summary>
    /// Adds <see cref="AreaEntranceChange"/>
    /// </summary>
    /// 
    /// <param name="location"><see cref="BlueprintGlobalMapPoint"/></param>
    /// <param name="newLocation"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaEnterPoint">BlueprintAreaEnterPoint</see></param>
    [Implements(typeof(AreaEntranceChange))]
    public static ActionsBuilder ChangeAreaEntrance(
        this ActionsBuilder builder, string location, string newLocation)
    {
      var changeEntrance = ElementTool.Create<AreaEntranceChange>();
      changeEntrance.m_Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(location);
      changeEntrance.m_NewEntrance = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(newLocation);
      return builder.Add(changeEntrance);
    }

    /// <summary>
    /// Adds
    /// <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.ChangeCurrentAreaName">ChangeCurrentAreaName</see>
    /// </summary>
    [Implements(typeof(ChangeCurrentAreaName))]
    public static ActionsBuilder ChangeCurrentAreaName(this ActionsBuilder builder, LocalizedString name)
    {
      var changeName = ElementTool.Create<ChangeCurrentAreaName>();
      changeName.NewName = name;
      return builder.Add(changeName);
    }

    /// <summary>
    /// Adds
    /// <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.ChangeCurrentAreaName">ChangeCurrentAreaName</see>
    /// </summary>
    [Implements(typeof(ChangeCurrentAreaName))]
    public static ActionsBuilder ResetCurrentAreaName(this ActionsBuilder builder)
    {
      var changeName = ElementTool.Create<ChangeCurrentAreaName>();
      changeName.RestoreDefault = true;
      return builder.Add(changeName);
    }

    /// <summary>
    /// Adds
    /// <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.AddCampingEncounter">AddCampingEncounter</see>
    /// </summary>
    [Implements(typeof(AddCampingEncounter))]
    public static ActionsBuilder AddCampingEncounter(this ActionsBuilder builder, string encounter)
    {
      var addEncounter = ElementTool.Create<AddCampingEncounter>();
      addEncounter.m_Encounter = BlueprintTool.GetRef<BlueprintCampingEncounterReference>(encounter);
      return builder.Add(addEncounter);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.DestroyMapObject">DestroyMapObject</see>
    /// </summary>
    [Implements(typeof(DestroyMapObject))]
    public static ActionsBuilder DestroyMapObject(this ActionsBuilder builder, MapObjectEvaluator obj)
    {
      var destroy = ElementTool.Create<DestroyMapObject>();
      destroy.MapObject = obj;
      return builder.Add(destroy);
    }

    //----- Auto Generated -----//

    /// <summary>
    /// Adds <see cref="CapitalExit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="destination"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaEnterPoint"/></param>
    [Generated]
    [Implements(typeof(CapitalExit))]
    public static ActionsBuilder CapitalExit(
        this ActionsBuilder builder,
        string? destination = null,
        AutoSaveMode autoSaveMode = default)
    {
      var element = ElementTool.Create<CapitalExit>();
      element.m_Destination = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(destination);
      element.AutoSaveMode = autoSaveMode;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DecreaseCorruptionLevelAction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DecreaseCorruptionLevelAction))]
    public static ActionsBuilder DecreaseCorruptionLevelAction(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<DecreaseCorruptionLevelAction>());
    }

    /// <summary>
    /// Adds <see cref="AskPlayerForLocationName"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="location"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMapPoint"/></param>
    [Generated]
    [Implements(typeof(AskPlayerForLocationName))]
    public static ActionsBuilder AskPlayerForLocationName(
        this ActionsBuilder builder,
        string? location = null,
        bool obligatory = default,
        LocalizedString? title = null,
        LocalizedString? hint = null,
        LocalizedString? defaultValue = null)
    {
      builder.Validate(title);
      builder.Validate(hint);
      builder.Validate(defaultValue);
    
      var element = ElementTool.Create<AskPlayerForLocationName>();
      element.m_Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(location);
      element.Obligatory = obligatory;
      element.Title = title ?? Constants.Empty.String;
      element.Hint = hint ?? Constants.Empty.String;
      element.Default = defaultValue ?? Constants.Empty.String;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="GlobalMapTeleport"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(GlobalMapTeleport))]
    public static ActionsBuilder GlobalMapTeleport(
        this ActionsBuilder builder,
        LocationEvaluator destination,
        FloatEvaluator skipHours,
        bool updateLocationVisitedTime = default)
    {
      builder.Validate(destination);
      builder.Validate(skipHours);
    
      var element = ElementTool.Create<GlobalMapTeleport>();
      element.Destination = destination;
      element.SkipHours = skipHours;
      element.UpdateLocationVisitedTime = updateLocationVisitedTime;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="HideMapObject"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(HideMapObject))]
    public static ActionsBuilder HideMapObject(
        this ActionsBuilder builder,
        MapObjectEvaluator mapObject,
        bool unhide = default)
    {
      builder.Validate(mapObject);
    
      var element = ElementTool.Create<HideMapObject>();
      element.MapObject = mapObject;
      element.Unhide = unhide;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="LocalMapSetDirty"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LocalMapSetDirty))]
    public static ActionsBuilder LocalMapSetDirty(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<LocalMapSetDirty>());
    }

    /// <summary>
    /// Adds <see cref="MakeServiceCaster"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MakeServiceCaster))]
    public static ActionsBuilder MakeServiceCaster(
        this ActionsBuilder builder,
        UnitEvaluator unit)
    {
      builder.Validate(unit);
    
      var element = ElementTool.Create<MakeServiceCaster>();
      element.Unit = unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="MarkLocationClosed"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="location"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMapPoint"/></param>
    [Generated]
    [Implements(typeof(MarkLocationClosed))]
    public static ActionsBuilder MarkLocationClosed(
        this ActionsBuilder builder,
        string? location = null,
        bool closed = default)
    {
      var element = ElementTool.Create<MarkLocationClosed>();
      element.m_Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(location);
      element.Closed = closed;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="MarkLocationExplored"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="location"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMapPoint"/></param>
    [Generated]
    [Implements(typeof(MarkLocationExplored))]
    public static ActionsBuilder MarkLocationExplored(
        this ActionsBuilder builder,
        string? location = null,
        bool explored = default)
    {
      var element = ElementTool.Create<MarkLocationExplored>();
      element.m_Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(location);
      element.Explored = explored;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="MarkOnLocalMap"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MarkOnLocalMap))]
    public static ActionsBuilder MarkOnLocalMap(
        this ActionsBuilder builder,
        MapObjectEvaluator mapObject,
        bool hidden = default)
    {
      builder.Validate(mapObject);
    
      var element = ElementTool.Create<MarkOnLocalMap>();
      element.MapObject = mapObject;
      element.Hidden = hidden;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="OpenLootContainer"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(OpenLootContainer))]
    public static ActionsBuilder OpenLootContainer(
        this ActionsBuilder builder,
        MapObjectEvaluator mapObject)
    {
      builder.Validate(mapObject);
    
      var element = ElementTool.Create<OpenLootContainer>();
      element.MapObject = mapObject;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveAllAreasFromSave"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="except"><see cref="Kingmaker.Blueprints.Area.BlueprintArea"/></param>
    [Generated]
    [Implements(typeof(RemoveAllAreasFromSave))]
    public static ActionsBuilder RemoveAllAreasFromSave(
        this ActionsBuilder builder,
        string[]? except = null)
    {
      var element = ElementTool.Create<RemoveAllAreasFromSave>();
      element.m_Except = except.Select(name => BlueprintTool.GetRef<BlueprintAreaReference>(name)).ToArray();
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveAmbush"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RemoveAmbush))]
    public static ActionsBuilder RemoveAmbush(
        this ActionsBuilder builder,
        UnitEvaluator unit,
        bool exitStealth = default)
    {
      builder.Validate(unit);
    
      var element = ElementTool.Create<RemoveAmbush>();
      element.m_Unit = unit;
      element.m_ExitStealth = exitStealth;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveAreaFromSave"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="area"><see cref="Kingmaker.Blueprints.Area.BlueprintArea"/></param>
    /// <param name="specificMechanic"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaMechanics"/></param>
    [Generated]
    [Implements(typeof(RemoveAreaFromSave))]
    public static ActionsBuilder RemoveAreaFromSave(
        this ActionsBuilder builder,
        string? area = null,
        string? specificMechanic = null)
    {
      var element = ElementTool.Create<RemoveAreaFromSave>();
      element.m_Area = BlueprintTool.GetRef<BlueprintAreaReference>(area);
      element.SpecificMechanic = BlueprintTool.GetRef<BlueprintAreaMechanicsReference>(specificMechanic);
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveCampingEncounter"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="encounter"><see cref="Kingmaker.RandomEncounters.Settings.BlueprintCampingEncounter"/></param>
    [Generated]
    [Implements(typeof(RemoveCampingEncounter))]
    public static ActionsBuilder RemoveCampingEncounter(
        this ActionsBuilder builder,
        string? encounter = null)
    {
      var element = ElementTool.Create<RemoveCampingEncounter>();
      element.m_Encounter = BlueprintTool.GetRef<BlueprintCampingEncounterReference>(encounter);
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ResetLocationPerceptionCheck"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="location"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMapPoint"/></param>
    [Generated]
    [Implements(typeof(ResetLocationPerceptionCheck))]
    public static ActionsBuilder ResetLocationPerceptionCheck(
        this ActionsBuilder builder,
        string? location = null)
    {
      var element = ElementTool.Create<ResetLocationPerceptionCheck>();
      element.m_Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(location);
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RevealGlobalMap"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="points"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMapPoint"/></param>
    [Generated]
    [Implements(typeof(RevealGlobalMap))]
    public static ActionsBuilder RevealGlobalMap(
        this ActionsBuilder builder,
        string[]? points = null,
        bool revealEdges = default)
    {
      var element = ElementTool.Create<RevealGlobalMap>();
      element.Points = points.Select(name => BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(name)).ToArray();
      element.RevealEdges = revealEdges;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ScriptZoneActivate"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ScriptZoneActivate))]
    public static ActionsBuilder ScriptZoneActivate(
        this ActionsBuilder builder,
        EntityReference scriptZone)
    {
      builder.Validate(scriptZone);
    
      var element = ElementTool.Create<ScriptZoneActivate>();
      element.ScriptZone = scriptZone;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ScriptZoneDeactivate"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ScriptZoneDeactivate))]
    public static ActionsBuilder ScriptZoneDeactivate(
        this ActionsBuilder builder,
        EntityReference scriptZone)
    {
      builder.Validate(scriptZone);
    
      var element = ElementTool.Create<ScriptZoneDeactivate>();
      element.ScriptZone = scriptZone;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ScripZoneUnits"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ScripZoneUnits))]
    public static ActionsBuilder ScripZoneUnits(
        this ActionsBuilder builder,
        EntityReference scriptZone,
        ActionsBuilder? actions = null)
    {
      builder.Validate(scriptZone);
    
      var element = ElementTool.Create<ScripZoneUnits>();
      element.ScriptZone = scriptZone;
      element.Actions = actions?.Build() ?? Constants.Empty.Actions;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SetDeviceState"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SetDeviceState))]
    public static ActionsBuilder SetDeviceState(
        this ActionsBuilder builder,
        MapObjectEvaluator device,
        IntEvaluator state)
    {
      builder.Validate(device);
      builder.Validate(state);
    
      var element = ElementTool.Create<SetDeviceState>();
      element.Device = device;
      element.State = state;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SetDeviceTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SetDeviceTrigger))]
    public static ActionsBuilder SetDeviceTrigger(
        this ActionsBuilder builder,
        MapObjectEvaluator device,
        string trigger)
    {
      builder.Validate(device);
    
      var element = ElementTool.Create<SetDeviceTrigger>();
      element.Device = device;
      element.Trigger = trigger;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SetDisableDevice"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SetDisableDevice))]
    public static ActionsBuilder SetDisableDevice(
        this ActionsBuilder builder,
        MapObjectEvaluator mapObject,
        int overrideDC = default)
    {
      builder.Validate(mapObject);
    
      var element = ElementTool.Create<SetDisableDevice>();
      element.MapObject = mapObject;
      element.OverrideDC = overrideDC;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ShowMultiEntrance"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="map"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintMultiEntrance"/></param>
    [Generated]
    [Implements(typeof(ShowMultiEntrance))]
    public static ActionsBuilder ShowMultiEntrance(
        this ActionsBuilder builder,
        string? map = null)
    {
      var element = ElementTool.Create<ShowMultiEntrance>();
      element.m_Map = BlueprintTool.GetRef<BlueprintMultiEntranceReference>(map);
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SpotMapObject"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SpotMapObject))]
    public static ActionsBuilder SpotMapObject(
        this ActionsBuilder builder,
        MapObjectEvaluator target,
        UnitEvaluator spotter)
    {
      builder.Validate(target);
      builder.Validate(spotter);
    
      var element = ElementTool.Create<SpotMapObject>();
      element.Target = target;
      element.Spotter = spotter;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SpotUnit"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SpotUnit))]
    public static ActionsBuilder SpotUnit(
        this ActionsBuilder builder,
        UnitEvaluator target,
        UnitEvaluator spotter)
    {
      builder.Validate(target);
      builder.Validate(spotter);
    
      var element = ElementTool.Create<SpotUnit>();
      element.Target = target;
      element.Spotter = spotter;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="TeleportParty"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="exitPositon"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaEnterPoint"/></param>
    [Generated]
    [Implements(typeof(TeleportParty))]
    public static ActionsBuilder TeleportParty(
        this ActionsBuilder builder,
        string? exitPositon = null,
        AutoSaveMode autoSaveMode = default,
        bool forcePauseAfterTeleport = default,
        ActionsBuilder? afterTeleport = null)
    {
      var element = ElementTool.Create<TeleportParty>();
      element.m_exitPositon = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(exitPositon);
      element.AutoSaveMode = autoSaveMode;
      element.ForcePauseAfterTeleport = forcePauseAfterTeleport;
      element.AfterTeleport = afterTeleport?.Build() ?? Constants.Empty.Actions;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="TranslocatePlayer"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TranslocatePlayer))]
    public static ActionsBuilder TranslocatePlayer(
        this ActionsBuilder builder,
        EntityReference transolcatePosition,
        bool byFormationAndWithPets = default,
        bool scrollCameraToPlayer = default)
    {
      builder.Validate(transolcatePosition);
    
      var element = ElementTool.Create<TranslocatePlayer>();
      element.transolcatePosition = transolcatePosition;
      element.ByFormationAndWithPets = byFormationAndWithPets;
      element.ScrollCameraToPlayer = scrollCameraToPlayer;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="TranslocateUnit"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TranslocateUnit))]
    public static ActionsBuilder TranslocateUnit(
        this ActionsBuilder builder,
        UnitEvaluator unit,
        EntityReference translocatePosition,
        PositionEvaluator translocatePositionEvaluator,
        FloatEvaluator translocateOrientationEvaluator,
        bool copyRotation = default)
    {
      builder.Validate(unit);
      builder.Validate(translocatePosition);
      builder.Validate(translocatePositionEvaluator);
      builder.Validate(translocateOrientationEvaluator);
    
      var element = ElementTool.Create<TranslocateUnit>();
      element.Unit = unit;
      element.translocatePosition = translocatePosition;
      element.translocatePositionEvaluator = translocatePositionEvaluator;
      element.m_CopyRotation = copyRotation;
      element.translocateOrientationEvaluator = translocateOrientationEvaluator;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="TrapCastSpell"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spell"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(TrapCastSpell))]
    public static ActionsBuilder TrapCastSpell(
        this ActionsBuilder builder,
        MapObjectEvaluator trapObject,
        UnitEvaluator triggeringUnit,
        PositionEvaluator targetPoint,
        PositionEvaluator actorPosition,
        string? spell = null,
        bool disableBattleLog = default,
        bool overrideDC = default,
        int dC = default,
        bool overrideSpellLevel = default,
        int spellLevel = default)
    {
      builder.Validate(trapObject);
      builder.Validate(triggeringUnit);
      builder.Validate(targetPoint);
      builder.Validate(actorPosition);
    
      var element = ElementTool.Create<TrapCastSpell>();
      element.m_Spell = BlueprintTool.GetRef<BlueprintAbilityReference>(spell);
      element.TrapObject = trapObject;
      element.TriggeringUnit = triggeringUnit;
      element.TargetPoint = targetPoint;
      element.ActorPosition = actorPosition;
      element.DisableBattleLog = disableBattleLog;
      element.OverrideDC = overrideDC;
      element.DC = dC;
      element.OverrideSpellLevel = overrideSpellLevel;
      element.SpellLevel = spellLevel;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnlockCookingRecipe"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="recipe"><see cref="Kingmaker.Controllers.Rest.Cooking.BlueprintCookingRecipe"/></param>
    [Generated]
    [Implements(typeof(UnlockCookingRecipe))]
    public static ActionsBuilder UnlockCookingRecipe(
        this ActionsBuilder builder,
        string? recipe = null)
    {
      var element = ElementTool.Create<UnlockCookingRecipe>();
      element.m_Recipe = BlueprintTool.GetRef<BlueprintCookingRecipeReference>(recipe);
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnlockLocation"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="location"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMapPoint"/></param>
    [Generated]
    [Implements(typeof(UnlockLocation))]
    public static ActionsBuilder UnlockLocation(
        this ActionsBuilder builder,
        string? location = null,
        bool fakeDescription = default,
        bool hideInstead = default)
    {
      var element = ElementTool.Create<UnlockLocation>();
      element.m_Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(location);
      element.FakeDescription = fakeDescription;
      element.HideInstead = hideInstead;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnlockMapEdge"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="edge"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMapEdge"/></param>
    [Generated]
    [Implements(typeof(UnlockMapEdge))]
    public static ActionsBuilder UnlockMapEdge(
        this ActionsBuilder builder,
        string? edge = null,
        bool openEdges = default)
    {
      var element = ElementTool.Create<UnlockMapEdge>();
      element.m_Edge = BlueprintTool.GetRef<BlueprintGlobalMapEdge.Reference>(edge);
      element.OpenEdges = openEdges;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="GameActionSetIsleLock"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(GameActionSetIsleLock))]
    public static ActionsBuilder GameActionSetIsleLock(
        this ActionsBuilder builder,
        IsleEvaluator isle,
        bool isLock = default)
    {
      builder.Validate(isle);
    
      var element = ElementTool.Create<GameActionSetIsleLock>();
      element.m_Isle = isle;
      element.m_IsLock = isLock;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="GameActionSetIsleState"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(GameActionSetIsleState))]
    public static ActionsBuilder GameActionSetIsleState(
        this ActionsBuilder builder,
        IsleEvaluator isle,
        string stateName)
    {
      builder.Validate(isle);
    
      var element = ElementTool.Create<GameActionSetIsleState>();
      element.m_Isle = isle;
      element.m_StateName = stateName;
      return builder.Add(element);
    }
  }
}
