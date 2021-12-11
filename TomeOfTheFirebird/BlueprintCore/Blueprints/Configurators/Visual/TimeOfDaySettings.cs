using BlueprintCore.Utils;
using Kingmaker.Visual.LightSelector;
using UnityEngine;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Visual
{
  /// <summary>
  /// Configurator for <see cref="BlueprintTimeOfDaySettings"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintTimeOfDaySettings))]
  public class TimeOfDaySettingsConfigurator : BaseBlueprintConfigurator<BlueprintTimeOfDaySettings, TimeOfDaySettingsConfigurator>
  {
    private TimeOfDaySettingsConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static TimeOfDaySettingsConfigurator For(string name)
    {
      return new TimeOfDaySettingsConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static TimeOfDaySettingsConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintTimeOfDaySettings>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTimeOfDaySettings.Morning"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TimeOfDaySettingsConfigurator SetMorning(GameObject morning)
    {
      ValidateParam(morning);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Morning = morning;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTimeOfDaySettings.Day"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TimeOfDaySettingsConfigurator SetDay(GameObject day)
    {
      ValidateParam(day);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Day = day;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTimeOfDaySettings.Evening"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TimeOfDaySettingsConfigurator SetEvening(GameObject evening)
    {
      ValidateParam(evening);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Evening = evening;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTimeOfDaySettings.Night"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TimeOfDaySettingsConfigurator SetNight(GameObject night)
    {
      ValidateParam(night);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Night = night;
          });
    }
  }
}
