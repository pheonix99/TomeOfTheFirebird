using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using System;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Configurator for <see cref="BlueprintPortrait"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintPortrait))]
  public class PortraitConfigurator : BaseBlueprintConfigurator<BlueprintPortrait, PortraitConfigurator>
  {
    private PortraitConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static PortraitConfigurator For(string name)
    {
      return new PortraitConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static PortraitConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintPortrait>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintPortrait.Data"/> (Auto Generated)
    /// </summary>
    [Generated]
    public PortraitConfigurator SetData(PortraitData data)
    {
      ValidateParam(data);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Data = data;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintPortrait.m_BackupPortrait"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="backupPortrait"><see cref="Kingmaker.Blueprints.BlueprintPortrait"/></param>
    [Generated]
    public PortraitConfigurator SetBackupPortrait(string? backupPortrait)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_BackupPortrait = BlueprintTool.GetRef<BlueprintPortraitReference>(backupPortrait);
          });
    }

    /// <summary>
    /// Adds <see cref="PortraitDollSettings"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="race"><see cref="Kingmaker.Blueprints.Classes.BlueprintRace"/></param>
    [Generated]
    [Implements(typeof(PortraitDollSettings))]
    public PortraitConfigurator AddPortraitDollSettings(
        Gender gender = default,
        string? race = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new PortraitDollSettings();
      component.Gender = gender;
      component.m_Race = BlueprintTool.GetRef<BlueprintRaceReference>(race);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }
  }
}
