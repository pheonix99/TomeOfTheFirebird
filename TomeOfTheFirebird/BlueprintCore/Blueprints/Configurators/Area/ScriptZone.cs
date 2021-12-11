using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Area;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>
  /// Configurator for <see cref="BlueprintScriptZone"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintScriptZone))]
  public class ScriptZoneConfigurator : BaseMapObjectConfigurator<BlueprintScriptZone, ScriptZoneConfigurator>
  {
    private ScriptZoneConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ScriptZoneConfigurator For(string name)
    {
      return new ScriptZoneConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ScriptZoneConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintScriptZone>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintScriptZone.TriggerConditions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ScriptZoneConfigurator SetTriggerConditions(ConditionsBuilder? triggerConditions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.TriggerConditions = triggerConditions?.Build() ?? Constants.Empty.Conditions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintScriptZone.EnterActions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ScriptZoneConfigurator SetEnterActions(ActionsBuilder? enterActions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.EnterActions = enterActions?.Build() ?? Constants.Empty.Actions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintScriptZone.ExitActions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ScriptZoneConfigurator SetExitActions(ActionsBuilder? exitActions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ExitActions = exitActions?.Build() ?? Constants.Empty.Actions;
          });
    }
  }
}
