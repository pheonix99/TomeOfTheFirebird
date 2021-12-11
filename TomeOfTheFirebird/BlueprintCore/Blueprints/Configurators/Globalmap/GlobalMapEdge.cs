using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Globalmap.Blueprints;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Globalmap
{
  /// <summary>
  /// Configurator for <see cref="BlueprintGlobalMapEdge"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintGlobalMapEdge))]
  public class GlobalMapEdgeConfigurator : BaseBlueprintConfigurator<BlueprintGlobalMapEdge, GlobalMapEdgeConfigurator>
  {
    private GlobalMapEdgeConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static GlobalMapEdgeConfigurator For(string name)
    {
      return new GlobalMapEdgeConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static GlobalMapEdgeConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintGlobalMapEdge>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapEdge.Type"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapEdgeConfigurator SetType(GlobalMapEdgeType type)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Type = type;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapEdge.Priority"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapEdgeConfigurator SetPriority(GlobalMapEdgePriority priority)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Priority = priority;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapEdge.m_Point1"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="point1"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMapPoint"/></param>
    [Generated]
    public GlobalMapEdgeConfigurator SetPoint1(string? point1)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Point1 = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(point1);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapEdge.m_Point2"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="point2"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMapPoint"/></param>
    [Generated]
    public GlobalMapEdgeConfigurator SetPoint2(string? point2)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Point2 = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(point2);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapEdge.LockCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapEdgeConfigurator SetLockCondition(ConditionsBuilder? lockCondition)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.LockCondition = lockCondition?.Build() ?? Constants.Empty.Conditions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapEdge.Length"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapEdgeConfigurator SetLength(float length)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Length = length;
          });
    }
  }
}
