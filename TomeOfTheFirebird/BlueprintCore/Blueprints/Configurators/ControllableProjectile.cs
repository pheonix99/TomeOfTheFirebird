using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.ResourceLinks;
using UnityEngine;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Configurator for <see cref="BlueprintControllableProjectile"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintControllableProjectile))]
  public class ControllableProjectileConfigurator : BaseBlueprintConfigurator<BlueprintControllableProjectile, ControllableProjectileConfigurator>
  {
    private ControllableProjectileConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ControllableProjectileConfigurator For(string name)
    {
      return new ControllableProjectileConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ControllableProjectileConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintControllableProjectile>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintControllableProjectile.m_OnCreatureCastPrefab"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ControllableProjectileConfigurator SetOnCreatureCastPrefab(PrefabLink? onCreatureCastPrefab)
    {
      ValidateParam(onCreatureCastPrefab);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_OnCreatureCastPrefab = onCreatureCastPrefab ?? Constants.Empty.PrefabLink;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintControllableProjectile.m_OnCreaturePrefab"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ControllableProjectileConfigurator SetOnCreaturePrefab(PrefabLink? onCreaturePrefab)
    {
      ValidateParam(onCreaturePrefab);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_OnCreaturePrefab = onCreaturePrefab ?? Constants.Empty.PrefabLink;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintControllableProjectile.m_HeightOffset"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ControllableProjectileConfigurator SetHeightOffset(float heightOffset)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_HeightOffset = heightOffset;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintControllableProjectile.m_RotationLifetime"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ControllableProjectileConfigurator SetRotationLifetime(float rotationLifetime)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_RotationLifetime = rotationLifetime;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintControllableProjectile.m_RotationCurve"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ControllableProjectileConfigurator SetRotationCurve(AnimationCurve rotationCurve)
    {
      ValidateParam(rotationCurve);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_RotationCurve = rotationCurve;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintControllableProjectile.m_PreparationStartSound"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ControllableProjectileConfigurator SetPreparationStartSound(string preparationStartSound)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_PreparationStartSound = preparationStartSound;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintControllableProjectile.m_PreparationEndSound"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ControllableProjectileConfigurator SetPreparationEndSound(string preparationEndSound)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_PreparationEndSound = preparationEndSound;
          });
    }
  }
}
