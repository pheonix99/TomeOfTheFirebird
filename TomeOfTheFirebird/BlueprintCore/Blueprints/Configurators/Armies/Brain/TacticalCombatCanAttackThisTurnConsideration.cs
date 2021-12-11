using BlueprintCore.Blueprints.Configurators.AI;
using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Brain.Considerations;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Armies.Brain
{
  /// <summary>
  /// Configurator for <see cref="TacticalCombatCanAttackThisTurnConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(TacticalCombatCanAttackThisTurnConsideration))]
  public class TacticalCombatCanAttackThisTurnConsiderationConfigurator : BaseConsiderationConfigurator<TacticalCombatCanAttackThisTurnConsideration, TacticalCombatCanAttackThisTurnConsiderationConfigurator>
  {
    private TacticalCombatCanAttackThisTurnConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static TacticalCombatCanAttackThisTurnConsiderationConfigurator For(string name)
    {
      return new TacticalCombatCanAttackThisTurnConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static TacticalCombatCanAttackThisTurnConsiderationConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<TacticalCombatCanAttackThisTurnConsideration>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="TacticalCombatCanAttackThisTurnConsideration.CanAttackScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatCanAttackThisTurnConsiderationConfigurator SetCanAttackScore(float canAttackScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CanAttackScore = canAttackScore;
          });
    }

    /// <summary>
    /// Sets <see cref="TacticalCombatCanAttackThisTurnConsideration.CanNotAttackScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatCanAttackThisTurnConsiderationConfigurator SetCanNotAttackScore(float canNotAttackScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CanNotAttackScore = canNotAttackScore;
          });
    }
  }
}
