using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using System.Linq;
using UnityEngine;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Configurator for <see cref="BlueprintProjectileTrajectory"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintProjectileTrajectory))]
  public class ProjectileTrajectoryConfigurator : BaseBlueprintConfigurator<BlueprintProjectileTrajectory, ProjectileTrajectoryConfigurator>
  {
    private ProjectileTrajectoryConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ProjectileTrajectoryConfigurator For(string name)
    {
      return new ProjectileTrajectoryConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ProjectileTrajectoryConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintProjectileTrajectory>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectileTrajectory.UpDirection"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileTrajectoryConfigurator SetUpDirection(Vector3 upDirection)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.UpDirection = upDirection;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectileTrajectory.PlaneOffset"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileTrajectoryConfigurator SetPlaneOffset(TrajectoryOffset[]? planeOffset)
    {
      ValidateParam(planeOffset);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.PlaneOffset = planeOffset;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintProjectileTrajectory.PlaneOffset"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileTrajectoryConfigurator AddToPlaneOffset(params TrajectoryOffset[] planeOffset)
    {
      ValidateParam(planeOffset);
      return OnConfigureInternal(
          bp =>
          {
            bp.PlaneOffset = CommonTool.Append(bp.PlaneOffset, planeOffset ?? new TrajectoryOffset[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintProjectileTrajectory.PlaneOffset"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileTrajectoryConfigurator RemoveFromPlaneOffset(params TrajectoryOffset[] planeOffset)
    {
      ValidateParam(planeOffset);
      return OnConfigureInternal(
          bp =>
          {
            bp.PlaneOffset = bp.PlaneOffset.Where(item => !planeOffset.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectileTrajectory.UpOffset"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileTrajectoryConfigurator SetUpOffset(TrajectoryOffset[]? upOffset)
    {
      ValidateParam(upOffset);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.UpOffset = upOffset;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintProjectileTrajectory.UpOffset"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileTrajectoryConfigurator AddToUpOffset(params TrajectoryOffset[] upOffset)
    {
      ValidateParam(upOffset);
      return OnConfigureInternal(
          bp =>
          {
            bp.UpOffset = CommonTool.Append(bp.UpOffset, upOffset ?? new TrajectoryOffset[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintProjectileTrajectory.UpOffset"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileTrajectoryConfigurator RemoveFromUpOffset(params TrajectoryOffset[] upOffset)
    {
      ValidateParam(upOffset);
      return OnConfigureInternal(
          bp =>
          {
            bp.UpOffset = bp.UpOffset.Where(item => !upOffset.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectileTrajectory.AmplitudeScaleByLifetime"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileTrajectoryConfigurator SetAmplitudeScaleByLifetime(AnimationCurve amplitudeScaleByLifetime)
    {
      ValidateParam(amplitudeScaleByLifetime);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.AmplitudeScaleByLifetime = amplitudeScaleByLifetime;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectileTrajectory.AmplitudeScaleByFullDistance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileTrajectoryConfigurator SetAmplitudeScaleByFullDistance(AnimationCurve amplitudeScaleByFullDistance)
    {
      ValidateParam(amplitudeScaleByFullDistance);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.AmplitudeScaleByFullDistance = amplitudeScaleByFullDistance;
          });
    }
  }
}
