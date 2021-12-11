using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Brain;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Armies.Brain
{
  /// <summary>
  /// Configurator for <see cref="BlueprintTacticalCombatAiPostponeTurn"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintTacticalCombatAiPostponeTurn))]
  public class TacticalCombatAiPostponeTurnConfigurator : BaseTacticalCombatAiActionConfigurator<BlueprintTacticalCombatAiPostponeTurn, TacticalCombatAiPostponeTurnConfigurator>
  {
    private TacticalCombatAiPostponeTurnConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static TacticalCombatAiPostponeTurnConfigurator For(string name)
    {
      return new TacticalCombatAiPostponeTurnConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static TacticalCombatAiPostponeTurnConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintTacticalCombatAiPostponeTurn>(name, guid);
      return For(name);
    }
  }
}
