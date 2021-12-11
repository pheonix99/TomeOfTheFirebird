using BlueprintCore.Utils;
using Kingmaker.Blueprints.Area;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>
  /// Configurator for <see cref="BlueprintAreaTransition"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintAreaTransition))]
  public class AreaTransitionConfigurator : BaseBlueprintConfigurator<BlueprintAreaTransition, AreaTransitionConfigurator>
  {
    private AreaTransitionConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AreaTransitionConfigurator For(string name)
    {
      return new AreaTransitionConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AreaTransitionConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintAreaTransition>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaTransition.m_Actions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaTransitionConfigurator SetActions(ConditionAction[]? actions)
    {
      ValidateParam(actions);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Actions = actions;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAreaTransition.m_Actions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaTransitionConfigurator AddToActions(params ConditionAction[] actions)
    {
      ValidateParam(actions);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Actions = CommonTool.Append(bp.m_Actions, actions ?? new ConditionAction[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAreaTransition.m_Actions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaTransitionConfigurator RemoveFromActions(params ConditionAction[] actions)
    {
      ValidateParam(actions);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Actions = bp.m_Actions.Where(item => !actions.Contains(item)).ToArray();
          });
    }
  }
}
