using BlueprintCore.Utils;
using Kingmaker.Assets.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.Blueprints;
using Kingmaker.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Conditions;
#nullable enable
namespace BlueprintCore.Conditions.Builder.AreaEx
{
  /// <summary>
  /// Extension to <see cref="ConditionsBuilder"/> for conditions involving the game map, dungeons, or locations. See also
  /// <see cref="KingdomEx.ConditionsBuilderKingdomEx">KingdomEx</see>.
  /// </summary>
  /// <inheritdoc cref="ConditionsBuilder"/>
  public static class ConditionsBuilderAreaEx
  {
    //----- Auto Generated -----//

    /// <summary>
    /// Adds <see cref="ContextConditionDungeonStage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionDungeonStage))]
    public static ConditionsBuilder ContextConditionDungeonStage(
        this ConditionsBuilder builder,
        int minLevel = default,
        int maxLevel = default,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionDungeonStage>();
      element.MinLevel = minLevel;
      element.MaxLevel = maxLevel;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="InCapital"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(InCapital))]
    public static ConditionsBuilder InCapital(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<InCapital>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AreaVisited"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="area"><see cref="Kingmaker.Blueprints.Area.BlueprintArea"/></param>
    [Generated]
    [Implements(typeof(AreaVisited))]
    public static ConditionsBuilder AreaVisited(
        this ConditionsBuilder builder,
        string? area = null,
        bool negate = false)
    {
      var element = ElementTool.Create<AreaVisited>();
      element.m_Area = BlueprintTool.GetRef<BlueprintAreaReference>(area);
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CurrentAreaIs"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="area"><see cref="Kingmaker.Blueprints.Area.BlueprintArea"/></param>
    [Generated]
    [Implements(typeof(CurrentAreaIs))]
    public static ConditionsBuilder CurrentAreaIs(
        this ConditionsBuilder builder,
        string? area = null,
        bool negate = false)
    {
      var element = ElementTool.Create<CurrentAreaIs>();
      element.m_Area = BlueprintTool.GetRef<BlueprintAreaReference>(area);
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsLootEmpty"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IsLootEmpty))]
    public static ConditionsBuilder IsLootEmpty(
        this ConditionsBuilder builder,
        EntityReference lootObject,
        MapObjectEvaluator mapObject,
        bool evaluateMapObject = default,
        bool negate = false)
    {
      builder.Validate(lootObject);
      builder.Validate(mapObject);
    
      var element = ElementTool.Create<IsLootEmpty>();
      element.LootObject = lootObject;
      element.MapObject = mapObject;
      element.EvaluateMapObject = evaluateMapObject;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsPartyInNaturalSetting"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IsPartyInNaturalSetting))]
    public static ConditionsBuilder IsPartyInNaturalSetting(
        this ConditionsBuilder builder,
        GlobalMapZone setting = default,
        bool negate = false)
    {
      var element = ElementTool.Create<IsPartyInNaturalSetting>();
      element.Setting = setting;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="LocationRevealed"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="location"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMapPoint"/></param>
    [Generated]
    [Implements(typeof(LocationRevealed))]
    public static ConditionsBuilder LocationRevealed(
        this ConditionsBuilder builder,
        string? location = null,
        bool negate = false)
    {
      var element = ElementTool.Create<LocationRevealed>();
      element.m_Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(location);
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="MapObjectDestroyed"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MapObjectDestroyed))]
    public static ConditionsBuilder MapObjectDestroyed(
        this ConditionsBuilder builder,
        MapObjectEvaluator mapObject,
        bool negate = false)
    {
      builder.Validate(mapObject);
    
      var element = ElementTool.Create<MapObjectDestroyed>();
      element.MapObject = mapObject;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="MapObjectRevealed"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MapObjectRevealed))]
    public static ConditionsBuilder MapObjectRevealed(
        this ConditionsBuilder builder,
        MapObjectEvaluator mapObject,
        bool negate = false)
    {
      builder.Validate(mapObject);
    
      var element = ElementTool.Create<MapObjectRevealed>();
      element.MapObject = mapObject;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PartyInScriptZone"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PartyInScriptZone))]
    public static ConditionsBuilder PartyInScriptZone(
        this ConditionsBuilder builder,
        EntityReference scriptZone,
        PartyInScriptZone.CheckType check = default,
        bool negate = false)
    {
      builder.Validate(scriptZone);
    
      var element = ElementTool.Create<PartyInScriptZone>();
      element.m_Check = check;
      element.m_ScriptZone = scriptZone;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnitInScriptZone"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UnitInScriptZone))]
    public static ConditionsBuilder UnitInScriptZone(
        this ConditionsBuilder builder,
        UnitEvaluator unit,
        MapObjectEvaluator scriptZone,
        bool negate = false)
    {
      builder.Validate(unit);
      builder.Validate(scriptZone);
    
      var element = ElementTool.Create<UnitInScriptZone>();
      element.Unit = unit;
      element.ScriptZone = scriptZone;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnitIsInAreaPart"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="areaPart"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaPart"/></param>
    [Generated]
    [Implements(typeof(UnitIsInAreaPart))]
    public static ConditionsBuilder UnitIsInAreaPart(
        this ConditionsBuilder builder,
        UnitEvaluator unit,
        string? areaPart = null,
        bool negate = false)
    {
      builder.Validate(unit);
    
      var element = ElementTool.Create<UnitIsInAreaPart>();
      element.m_AreaPart = BlueprintTool.GetRef<BlueprintAreaPartReference>(areaPart);
      element.Unit = unit;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnitIsInFogOfWar"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UnitIsInFogOfWar))]
    public static ConditionsBuilder UnitIsInFogOfWar(
        this ConditionsBuilder builder,
        UnitEvaluator target,
        bool negate = false)
    {
      builder.Validate(target);
    
      var element = ElementTool.Create<UnitIsInFogOfWar>();
      element.Target = target;
      element.Not = negate;
      return builder.Add(element);
    }
  }
}
