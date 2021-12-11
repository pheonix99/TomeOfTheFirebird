using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.Mechanics.Components;
using System;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Facts
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintFact"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintFact))]
  public abstract class BaseFactConfigurator<T, TBuilder> : BaseBlueprintConfigurator<T, TBuilder>
      where T : BlueprintFact
      where TBuilder : BaseFactConfigurator<T, TBuilder>
  {
    protected BaseFactConfigurator(string name) : base(name) { }


    /// <summary>
    /// Adds <see cref="AddFactContextActions"/>
    /// </summary>
    /// 
    /// <remarks>Default Merge: Appends the given <see cref="Kingmaker.ElementsSystem.ActionList">ActionLists</see></remarks>
    [Implements(typeof(AddFactContextActions))]
    public TBuilder AddFactContextActions(
        ActionsBuilder? onActivated = null,
        ActionsBuilder? onDeactivated = null,
        ActionsBuilder? onNewRound = null,
        ComponentMerge behavior = ComponentMerge.Merge,
        Action<BlueprintComponent, BlueprintComponent>? merge = null)
    {
      if (onActivated == null && onDeactivated == null && onNewRound == null)
      {
        throw new InvalidOperationException("No actions provided.");
      }
      var contextActions = new AddFactContextActions
      {
        Activated = onActivated?.Build() ?? Constants.Empty.Actions,
        Deactivated = onDeactivated?.Build() ?? Constants.Empty.Actions,
        NewRound = onNewRound?.Build() ?? Constants.Empty.Actions
      };
      return AddUniqueComponent(contextActions, behavior, merge ?? MergeFactContextActions);
    }

    [Implements(typeof(AddFactContextActions))]
    private static void MergeFactContextActions(
        BlueprintComponent current, BlueprintComponent other)
    {
      var source = current as AddFactContextActions;
      var target = other as AddFactContextActions;
      source!.Activated.Actions = CommonTool.Append(source.Activated.Actions, target!.Activated.Actions);
      source.Deactivated.Actions = CommonTool.Append(source.Deactivated.Actions, target.Deactivated.Actions);
      source.NewRound.Actions = CommonTool.Append(source.NewRound.Actions, target.NewRound.Actions);
    }

    /// <summary>
    /// Adds <see cref="ComponentsList"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="list"><see cref="Kingmaker.Blueprints.BlueprintComponentList"/></param>
    [Generated]
    [Implements(typeof(ComponentsList))]
    public TBuilder AddComponentsList(
        string? list = null)
    {
      var component = new ComponentsList();
      component.m_List = BlueprintTool.GetRef<BlueprintComponentListReference>(list);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddBuffActions"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddBuffActions))]
    public TBuilder AddBuffActions(
        ActionsBuilder? activated = null,
        ActionsBuilder? deactivated = null,
        ActionsBuilder? newRound = null)
    {
      var component = new AddBuffActions();
      component.Activated = activated?.Build() ?? Constants.Empty.Actions;
      component.Deactivated = deactivated?.Build() ?? Constants.Empty.Actions;
      component.NewRound = newRound?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }
  }
}
