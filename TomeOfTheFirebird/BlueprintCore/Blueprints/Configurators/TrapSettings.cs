using BlueprintCore.Utils;
using Kingmaker.Blueprints;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Configurator for <see cref="BlueprintTrapSettings"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintTrapSettings))]
  public class TrapSettingsConfigurator : BaseBlueprintConfigurator<BlueprintTrapSettings, TrapSettingsConfigurator>
  {
    private TrapSettingsConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static TrapSettingsConfigurator For(string name)
    {
      return new TrapSettingsConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static TrapSettingsConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintTrapSettings>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTrapSettings.ActorLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrapSettingsConfigurator SetActorLevel(int actorLevel)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ActorLevel = actorLevel;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTrapSettings.ActorStatMod"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrapSettingsConfigurator SetActorStatMod(BlueprintTrapSettings.IntRange actorStatMod)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ActorStatMod = actorStatMod;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTrapSettings.TrapActor"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="trapActor"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public TrapSettingsConfigurator SetTrapActor(string? trapActor)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.TrapActor = BlueprintTool.GetRef<BlueprintUnitReference>(trapActor);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTrapSettings.DisableDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrapSettingsConfigurator SetDisableDC(BlueprintTrapSettings.IntRange disableDC)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DisableDC = disableDC;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTrapSettings.PerceptionDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrapSettingsConfigurator SetPerceptionDC(BlueprintTrapSettings.IntRange perceptionDC)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.PerceptionDC = perceptionDC;
          });
    }
  }
}
