using BlueprintCore.Utils;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using UnityEngine;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.UnitLogic.Abilities
{
  /// <summary>
  /// Configurator for <see cref="BlueprintAreaEffectPitVisualSettings"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintAreaEffectPitVisualSettings))]
  public class AreaEffectPitVisualSettingsConfigurator : BaseBlueprintConfigurator<BlueprintAreaEffectPitVisualSettings, AreaEffectPitVisualSettingsConfigurator>
  {
    private AreaEffectPitVisualSettingsConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AreaEffectPitVisualSettingsConfigurator For(string name)
    {
      return new AreaEffectPitVisualSettingsConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AreaEffectPitVisualSettingsConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintAreaEffectPitVisualSettings>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaEffectPitVisualSettings.DepthMeters"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaEffectPitVisualSettingsConfigurator SetDepthMeters(float depthMeters)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DepthMeters = depthMeters;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaEffectPitVisualSettings.HoleEdgeMeters"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaEffectPitVisualSettingsConfigurator SetHoleEdgeMeters(float holeEdgeMeters)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.HoleEdgeMeters = holeEdgeMeters;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaEffectPitVisualSettings.UnitDisappearFx"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaEffectPitVisualSettingsConfigurator SetUnitDisappearFx(GameObject unitDisappearFx)
    {
      ValidateParam(unitDisappearFx);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.UnitDisappearFx = unitDisappearFx;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaEffectPitVisualSettings.UnitAppearFx"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaEffectPitVisualSettingsConfigurator SetUnitAppearFx(GameObject unitAppearFx)
    {
      ValidateParam(unitAppearFx);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.UnitAppearFx = unitAppearFx;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaEffectPitVisualSettings.FallXZCurve"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaEffectPitVisualSettingsConfigurator SetFallXZCurve(AnimationCurve fallXZCurve)
    {
      ValidateParam(fallXZCurve);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.FallXZCurve = fallXZCurve;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaEffectPitVisualSettings.FallYCurve"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaEffectPitVisualSettingsConfigurator SetFallYCurve(AnimationCurve fallYCurve)
    {
      ValidateParam(fallYCurve);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.FallYCurve = fallYCurve;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaEffectPitVisualSettings.ClimbXZCurve"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaEffectPitVisualSettingsConfigurator SetClimbXZCurve(AnimationCurve climbXZCurve)
    {
      ValidateParam(climbXZCurve);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.ClimbXZCurve = climbXZCurve;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaEffectPitVisualSettings.ClimbYCurve"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaEffectPitVisualSettingsConfigurator SetClimbYCurve(AnimationCurve climbYCurve)
    {
      ValidateParam(climbYCurve);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.ClimbYCurve = climbYCurve;
          });
    }
  }
}
