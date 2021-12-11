using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Configurator for <see cref="BlueprintTrapSettingsRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintTrapSettingsRoot))]
  public class TrapSettingsRootConfigurator : BaseBlueprintConfigurator<BlueprintTrapSettingsRoot, TrapSettingsRootConfigurator>
  {
    private TrapSettingsRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static TrapSettingsRootConfigurator For(string name)
    {
      return new TrapSettingsRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static TrapSettingsRootConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintTrapSettingsRoot>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTrapSettingsRoot.m_DefaultPerceptionRadius"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrapSettingsRootConfigurator SetDefaultPerceptionRadius(float defaultPerceptionRadius)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DefaultPerceptionRadius = defaultPerceptionRadius;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTrapSettingsRoot.m_DisableDCMargin"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrapSettingsRootConfigurator SetDisableDCMargin(int disableDCMargin)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DisableDCMargin = disableDCMargin;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTrapSettingsRoot.m_Settings"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="settings"><see cref="Kingmaker.Blueprints.BlueprintTrapSettings"/></param>
    [Generated]
    public TrapSettingsRootConfigurator Settings(string[]? settings)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Settings = settings.Select(name => BlueprintTool.GetRef<BlueprintTrapSettingsReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintTrapSettingsRoot.m_Settings"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="settings"><see cref="Kingmaker.Blueprints.BlueprintTrapSettings"/></param>
    [Generated]
    public TrapSettingsRootConfigurator AddToSettings(params string[] settings)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Settings = CommonTool.Append(bp.m_Settings, settings.Select(name => BlueprintTool.GetRef<BlueprintTrapSettingsReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintTrapSettingsRoot.m_Settings"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="settings"><see cref="Kingmaker.Blueprints.BlueprintTrapSettings"/></param>
    [Generated]
    public TrapSettingsRootConfigurator RemoveFromSettings(params string[] settings)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = settings.Select(name => BlueprintTool.GetRef<BlueprintTrapSettingsReference>(name));
            bp.m_Settings =
                bp.m_Settings
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTrapSettingsRoot.EasyDisableDCDelta"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrapSettingsRootConfigurator SetEasyDisableDCDelta(int easyDisableDCDelta)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.EasyDisableDCDelta = easyDisableDCDelta;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTrapSettingsRoot.HardDisableDCDelta"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrapSettingsRootConfigurator SetHardDisableDCDelta(int hardDisableDCDelta)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.HardDisableDCDelta = hardDisableDCDelta;
          });
    }
  }
}
