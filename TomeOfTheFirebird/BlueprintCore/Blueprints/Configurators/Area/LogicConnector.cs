using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Area;
using Kingmaker.Designers.EventConditionActionSystem.Events;
using Kingmaker.Enums.Damage;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintLogicConnector"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintLogicConnector))]
  public abstract class BaseLogicConnectorConfigurator<T, TBuilder>
      : BaseFactConfigurator<T, TBuilder>
      where T : BlueprintLogicConnector
      where TBuilder : BaseLogicConnectorConfigurator<T, TBuilder>
  {
    protected BaseLogicConnectorConfigurator(string name) : base(name) { }

    /// <summary>
    /// Adds <see cref="DamageToMapObjectTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageToMapObjectTrigger))]
    public TBuilder AddDamageToMapObjectTrigger(
        ActionsBuilder? actions = null,
        bool checkEnergyType = default,
        DamageEnergyType energyType = default,
        bool checkPhysicalDamageForm = default,
        PhysicalDamageForm physicalDamageForm = default)
    {
      var component = new DamageToMapObjectTrigger();
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.CheckEnergyType = checkEnergyType;
      component.EnergyType = energyType;
      component.CheckPhysicalDamageForm = checkPhysicalDamageForm;
      component.PhysicalDamageForm = physicalDamageForm;
      return AddComponent(component);
    }
  }

  /// <summary>
  /// Configurator for <see cref="BlueprintLogicConnector"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintLogicConnector))]
  public class LogicConnectorConfigurator : BaseFactConfigurator<BlueprintLogicConnector, LogicConnectorConfigurator>
  {
    private LogicConnectorConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static LogicConnectorConfigurator For(string name)
    {
      return new LogicConnectorConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static LogicConnectorConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintLogicConnector>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Adds <see cref="DamageToMapObjectTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageToMapObjectTrigger))]
    public LogicConnectorConfigurator AddDamageToMapObjectTrigger(
        ActionsBuilder? actions = null,
        bool checkEnergyType = default,
        DamageEnergyType energyType = default,
        bool checkPhysicalDamageForm = default,
        PhysicalDamageForm physicalDamageForm = default)
    {
      var component = new DamageToMapObjectTrigger();
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.CheckEnergyType = checkEnergyType;
      component.EnergyType = energyType;
      component.CheckPhysicalDamageForm = checkPhysicalDamageForm;
      component.PhysicalDamageForm = physicalDamageForm;
      return AddComponent(component);
    }
  }
}
