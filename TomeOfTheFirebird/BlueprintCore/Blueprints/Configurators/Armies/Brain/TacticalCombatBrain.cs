using BlueprintCore.Blueprints.Configurators.AI;
using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Brain;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Armies.Brain
{
  /// <summary>
  /// Configurator for <see cref="BlueprintTacticalCombatBrain"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintTacticalCombatBrain))]
  public class TacticalCombatBrainConfigurator : BaseBrainConfigurator<BlueprintTacticalCombatBrain, TacticalCombatBrainConfigurator>
  {
    private TacticalCombatBrainConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static TacticalCombatBrainConfigurator For(string name)
    {
      return new TacticalCombatBrainConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static TacticalCombatBrainConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintTacticalCombatBrain>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatBrain.m_TacticalActions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="tacticalActions"><see cref="Kingmaker.Armies.TacticalCombat.Brain.BlueprintTacticalCombatAiAction"/></param>
    [Generated]
    public TacticalCombatBrainConfigurator SetTacticalActions(string[]? tacticalActions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_TacticalActions = tacticalActions.Select(name => BlueprintTool.GetRef<BlueprintTacticalCombatAiActionReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintTacticalCombatBrain.m_TacticalActions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="tacticalActions"><see cref="Kingmaker.Armies.TacticalCombat.Brain.BlueprintTacticalCombatAiAction"/></param>
    [Generated]
    public TacticalCombatBrainConfigurator AddToTacticalActions(params string[] tacticalActions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_TacticalActions = CommonTool.Append(bp.m_TacticalActions, tacticalActions.Select(name => BlueprintTool.GetRef<BlueprintTacticalCombatAiActionReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintTacticalCombatBrain.m_TacticalActions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="tacticalActions"><see cref="Kingmaker.Armies.TacticalCombat.Brain.BlueprintTacticalCombatAiAction"/></param>
    [Generated]
    public TacticalCombatBrainConfigurator RemoveFromTacticalActions(params string[] tacticalActions)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = tacticalActions.Select(name => BlueprintTool.GetRef<BlueprintTacticalCombatAiActionReference>(name));
            bp.m_TacticalActions =
                bp.m_TacticalActions
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }
  }
}
