using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints;
using Kingmaker.Blueprints;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintBrain"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintBrain))]
  public abstract class BaseBrainConfigurator<T, TBuilder>
      : BaseBlueprintConfigurator<T, TBuilder>
      where T : BlueprintBrain
      where TBuilder : BaseBrainConfigurator<T, TBuilder>
  {
    protected BaseBrainConfigurator(string name) : base(name) { }

    /// <summary>
    /// Sets <see cref="BlueprintBrain.m_Actions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="actions"><see cref="Kingmaker.AI.Blueprints.BlueprintAiAction"/></param>
    [Generated]
    public TBuilder SetActions(string[]? actions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Actions = actions.Select(name => BlueprintTool.GetRef<BlueprintAiActionReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintBrain.m_Actions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="actions"><see cref="Kingmaker.AI.Blueprints.BlueprintAiAction"/></param>
    [Generated]
    public TBuilder AddToActions(params string[] actions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Actions = CommonTool.Append(bp.m_Actions, actions.Select(name => BlueprintTool.GetRef<BlueprintAiActionReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintBrain.m_Actions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="actions"><see cref="Kingmaker.AI.Blueprints.BlueprintAiAction"/></param>
    [Generated]
    public TBuilder RemoveFromActions(params string[] actions)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = actions.Select(name => BlueprintTool.GetRef<BlueprintAiActionReference>(name));
            bp.m_Actions =
                bp.m_Actions
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }
  }

  /// <summary>
  /// Configurator for <see cref="BlueprintBrain"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintBrain))]
  public class BrainConfigurator : BaseBlueprintConfigurator<BlueprintBrain, BrainConfigurator>
  {
    private BrainConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static BrainConfigurator For(string name)
    {
      return new BrainConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static BrainConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintBrain>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintBrain.m_Actions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="actions"><see cref="Kingmaker.AI.Blueprints.BlueprintAiAction"/></param>
    [Generated]
    public BrainConfigurator SetActions(string[]? actions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Actions = actions.Select(name => BlueprintTool.GetRef<BlueprintAiActionReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintBrain.m_Actions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="actions"><see cref="Kingmaker.AI.Blueprints.BlueprintAiAction"/></param>
    [Generated]
    public BrainConfigurator AddToActions(params string[] actions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Actions = CommonTool.Append(bp.m_Actions, actions.Select(name => BlueprintTool.GetRef<BlueprintAiActionReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintBrain.m_Actions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="actions"><see cref="Kingmaker.AI.Blueprints.BlueprintAiAction"/></param>
    [Generated]
    public BrainConfigurator RemoveFromActions(params string[] actions)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = actions.Select(name => BlueprintTool.GetRef<BlueprintAiActionReference>(name));
            bp.m_Actions =
                bp.m_Actions
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }
  }
}
