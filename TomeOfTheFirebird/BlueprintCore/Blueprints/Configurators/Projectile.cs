using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.ResourceLinks;
using Kingmaker.Visual.HitSystem;
using System;
using UnityEngine;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Configurator for <see cref="BlueprintProjectile"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintProjectile))]
  public class ProjectileConfigurator : BaseBlueprintConfigurator<BlueprintProjectile, ProjectileConfigurator>
  {
    private ProjectileConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ProjectileConfigurator For(string name)
    {
      return new ProjectileConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ProjectileConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintProjectile>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.Speed"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetSpeed(float speed)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Speed = speed;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.MinTime"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetMinTime(float minTime)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MinTime = minTime;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.View"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetView(ProjectileLink view)
    {
      ValidateParam(view);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.View = view;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.CastFx"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetCastFx(PrefabLink? castFx)
    {
      ValidateParam(castFx);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.CastFx = castFx ?? Constants.Empty.PrefabLink;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.CastEffectDuration"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetCastEffectDuration(float castEffectDuration)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CastEffectDuration = castEffectDuration;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.LifetimeParticlesAfterHit"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetLifetimeParticlesAfterHit(float lifetimeParticlesAfterHit)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.LifetimeParticlesAfterHit = lifetimeParticlesAfterHit;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.ProjectileHit"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetProjectileHit(ProjectileHitSettings projectileHit)
    {
      ValidateParam(projectileHit);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.ProjectileHit = projectileHit;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.DamageHit"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetDamageHit(DamageHitSettings damageHit)
    {
      ValidateParam(damageHit);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.DamageHit = damageHit;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.SourceBone"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetSourceBone(string sourceBone)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.SourceBone = sourceBone;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.SourceBoneOffsetAtTarget"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetSourceBoneOffsetAtTarget(bool sourceBoneOffsetAtTarget)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.SourceBoneOffsetAtTarget = sourceBoneOffsetAtTarget;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.UseSourceBoneScale"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetUseSourceBoneScale(bool useSourceBoneScale)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.UseSourceBoneScale = useSourceBoneScale;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.SourceBoneCorpulenceOffset"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetSourceBoneCorpulenceOffset(float sourceBoneCorpulenceOffset)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.SourceBoneCorpulenceOffset = sourceBoneCorpulenceOffset;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.TargetBone"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetTargetBone(string targetBone)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.TargetBone = targetBone;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.TargetBoneOnCrit"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetTargetBoneOnCrit(string targetBoneOnCrit)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.TargetBoneOnCrit = targetBoneOnCrit;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.TargetBoneOffsetMultiplier"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetTargetBoneOffsetMultiplier(float targetBoneOffsetMultiplier)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.TargetBoneOffsetMultiplier = targetBoneOffsetMultiplier;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.FallsOnMiss"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetFallsOnMiss(bool fallsOnMiss)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.FallsOnMiss = fallsOnMiss;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.MissMinRadius"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetMissMinRadius(float missMinRadius)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MissMinRadius = missMinRadius;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.MissMaxRadius"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetMissMaxRadius(float missMaxRadius)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MissMaxRadius = missMaxRadius;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.MissRaycastDistance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetMissRaycastDistance(float missRaycastDistance)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MissRaycastDistance = missRaycastDistance;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.AddRagdollImpulse"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetAddRagdollImpulse(float addRagdollImpulse)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AddRagdollImpulse = addRagdollImpulse;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.m_Trajectory"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="trajectory"><see cref="Kingmaker.Blueprints.BlueprintProjectileTrajectory"/></param>
    [Generated]
    public ProjectileConfigurator SetTrajectory(string? trajectory)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Trajectory = BlueprintTool.GetRef<BlueprintProjectileTrajectoryReference>(trajectory);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.FollowTerrain"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetFollowTerrain(bool followTerrain)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.FollowTerrain = followTerrain;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.StuckArrowPrefab"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetStuckArrowPrefab(GameObject stuckArrowPrefab)
    {
      ValidateParam(stuckArrowPrefab);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.StuckArrowPrefab = stuckArrowPrefab;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.DeflectedArrowPrefab"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetDeflectedArrowPrefab(GameObject deflectedArrowPrefab)
    {
      ValidateParam(deflectedArrowPrefab);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.DeflectedArrowPrefab = deflectedArrowPrefab;
          });
    }

    /// <summary>
    /// Adds <see cref="CannotSneakAttack"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CannotSneakAttack))]
    public ProjectileConfigurator AddCannotSneakAttack(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new CannotSneakAttack();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }
  }
}
