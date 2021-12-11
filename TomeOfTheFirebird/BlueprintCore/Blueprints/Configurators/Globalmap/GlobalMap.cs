using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Kingdom.Blueprints;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Globalmap
{
  /// <summary>
  /// Configurator for <see cref="BlueprintGlobalMap"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintGlobalMap))]
  public class GlobalMapConfigurator : BaseBlueprintConfigurator<BlueprintGlobalMap, GlobalMapConfigurator>
  {
    private GlobalMapConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static GlobalMapConfigurator For(string name)
    {
      return new GlobalMapConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static GlobalMapConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintGlobalMap>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMap.m_StartLocation"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="startLocation"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMapPoint"/></param>
    [Generated]
    public GlobalMapConfigurator SetStartLocation(string? startLocation)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_StartLocation = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(startLocation);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMap.m_GlobalMapEnterPoint"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="globalMapEnterPoint"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaEnterPoint"/></param>
    [Generated]
    public GlobalMapConfigurator SetGlobalMapEnterPoint(string? globalMapEnterPoint)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_GlobalMapEnterPoint = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(globalMapEnterPoint);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMap.m_RegionsMask"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapConfigurator SetRegionsMask(RegionsMask regionsMask)
    {
      ValidateParam(regionsMask);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_RegionsMask = regionsMask;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMap.VisualSpeedBase"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapConfigurator SetVisualSpeedBase(float visualSpeedBase)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.VisualSpeedBase = visualSpeedBase;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMap.MechanicsSpeedBase"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapConfigurator SetMechanicsSpeedBase(float mechanicsSpeedBase)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MechanicsSpeedBase = mechanicsSpeedBase;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMap.ArmySpeedFactor"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapConfigurator SetArmySpeedFactor(float armySpeedFactor)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ArmySpeedFactor = armySpeedFactor;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMap.ArmyGoToPointSpeedMultiplier"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapConfigurator SetArmyGoToPointSpeedMultiplier(float armyGoToPointSpeedMultiplier)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ArmyGoToPointSpeedMultiplier = armyGoToPointSpeedMultiplier;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMap.RandomEncounterTimer"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapConfigurator SetRandomEncounterTimer(float randomEncounterTimer)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.RandomEncounterTimer = randomEncounterTimer;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMap.ExploreDistance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapConfigurator SetExploreDistance(float exploreDistance)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ExploreDistance = exploreDistance;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMap.RestrictTravelingToClosedLocations"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapConfigurator SetRestrictTravelingToClosedLocations(bool restrictTravelingToClosedLocations)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.RestrictTravelingToClosedLocations = restrictTravelingToClosedLocations;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMap.Points"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="points"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMapPoint"/></param>
    [Generated]
    public GlobalMapConfigurator SetPoints(string[]? points)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Points = points.Select(name => BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintGlobalMap.Points"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="points"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMapPoint"/></param>
    [Generated]
    public GlobalMapConfigurator AddToPoints(params string[] points)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Points = CommonTool.Append(bp.Points, points.Select(name => BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintGlobalMap.Points"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="points"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMapPoint"/></param>
    [Generated]
    public GlobalMapConfigurator RemoveFromPoints(params string[] points)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = points.Select(name => BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(name));
            bp.Points =
                bp.Points
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMap.Edges"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="edges"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMapEdge"/></param>
    [Generated]
    public GlobalMapConfigurator SetEdges(string[]? edges)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Edges = edges.Select(name => BlueprintTool.GetRef<BlueprintGlobalMapEdge.Reference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintGlobalMap.Edges"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="edges"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMapEdge"/></param>
    [Generated]
    public GlobalMapConfigurator AddToEdges(params string[] edges)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Edges.AddRange(edges.Select(name => BlueprintTool.GetRef<BlueprintGlobalMapEdge.Reference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintGlobalMap.Edges"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="edges"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMapEdge"/></param>
    [Generated]
    public GlobalMapConfigurator RemoveFromEdges(params string[] edges)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = edges.Select(name => BlueprintTool.GetRef<BlueprintGlobalMapEdge.Reference>(name));
            bp.Edges =
                bp.Edges
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMap.EnterWarCampAction"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapConfigurator SetEnterWarCampAction(ActionsBuilder? enterWarCampAction)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.EnterWarCampAction = enterWarCampAction?.Build() ?? Constants.Empty.Actions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMap.EnterAzataIslandAction"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapConfigurator SetEnterAzataIslandAction(ActionsBuilder? enterAzataIslandAction)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.EnterAzataIslandAction = enterAzataIslandAction?.Build() ?? Constants.Empty.Actions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMap.IsKenabres"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapConfigurator SetIsKenabres(bool isKenabres)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IsKenabres = isKenabres;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMap.CampLocation"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="campLocation"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMapPoint"/></param>
    [Generated]
    public GlobalMapConfigurator SetCampLocation(string? campLocation)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CampLocation = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(campLocation);
          });
    }
  }
}
