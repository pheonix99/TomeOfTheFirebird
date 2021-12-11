using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Enums;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>
  /// Configurator for <see cref="BlueprintClassAdditionalVisualSettings"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintClassAdditionalVisualSettings))]
  public class ClassAdditionalVisualSettingsConfigurator : BaseBlueprintConfigurator<BlueprintClassAdditionalVisualSettings, ClassAdditionalVisualSettingsConfigurator>
  {
    private ClassAdditionalVisualSettingsConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ClassAdditionalVisualSettingsConfigurator For(string name)
    {
      return new ClassAdditionalVisualSettingsConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ClassAdditionalVisualSettingsConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintClassAdditionalVisualSettings>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintClassAdditionalVisualSettings.m_Prerequisite"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="prerequisite"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude"/></param>
    [Generated]
    public ClassAdditionalVisualSettingsConfigurator SetPrerequisite(string? prerequisite)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Prerequisite = BlueprintTool.GetRef<BlueprintEtudeReference>(prerequisite);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintClassAdditionalVisualSettings.ColorRamps"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClassAdditionalVisualSettingsConfigurator SetColorRamps(BlueprintClassAdditionalVisualSettings.ColorRamp[]? colorRamps)
    {
      ValidateParam(colorRamps);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.ColorRamps = colorRamps;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintClassAdditionalVisualSettings.ColorRamps"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClassAdditionalVisualSettingsConfigurator AddToColorRamps(params BlueprintClassAdditionalVisualSettings.ColorRamp[] colorRamps)
    {
      ValidateParam(colorRamps);
      return OnConfigureInternal(
          bp =>
          {
            bp.ColorRamps = CommonTool.Append(bp.ColorRamps, colorRamps ?? new BlueprintClassAdditionalVisualSettings.ColorRamp[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintClassAdditionalVisualSettings.ColorRamps"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClassAdditionalVisualSettingsConfigurator RemoveFromColorRamps(params BlueprintClassAdditionalVisualSettings.ColorRamp[] colorRamps)
    {
      ValidateParam(colorRamps);
      return OnConfigureInternal(
          bp =>
          {
            bp.ColorRamps = bp.ColorRamps.Where(item => !colorRamps.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintClassAdditionalVisualSettings.OverrideFootprintType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClassAdditionalVisualSettingsConfigurator SetOverrideFootprintType(bool overrideFootprintType)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.OverrideFootprintType = overrideFootprintType;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintClassAdditionalVisualSettings.FootprintType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClassAdditionalVisualSettingsConfigurator SetFootprintType(FootprintType footprintType)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.FootprintType = footprintType;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintClassAdditionalVisualSettings.CommonSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClassAdditionalVisualSettingsConfigurator SetCommonSettings(BlueprintClassAdditionalVisualSettings.SettingsData commonSettings)
    {
      ValidateParam(commonSettings);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.CommonSettings = commonSettings;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintClassAdditionalVisualSettings.InGameSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClassAdditionalVisualSettingsConfigurator SetInGameSettings(BlueprintClassAdditionalVisualSettings.SettingsData inGameSettings)
    {
      ValidateParam(inGameSettings);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.InGameSettings = inGameSettings;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintClassAdditionalVisualSettings.DollRoomSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ClassAdditionalVisualSettingsConfigurator SetDollRoomSettings(BlueprintClassAdditionalVisualSettings.SettingsData dollRoomSettings)
    {
      ValidateParam(dollRoomSettings);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.DollRoomSettings = dollRoomSettings;
          });
    }
  }
}
