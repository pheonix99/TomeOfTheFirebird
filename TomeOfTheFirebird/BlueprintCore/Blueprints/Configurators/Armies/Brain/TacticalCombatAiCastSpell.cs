using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Brain;
using Kingmaker.Blueprints;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Armies.Brain
{
  /// <summary>
  /// Configurator for <see cref="BlueprintTacticalCombatAiCastSpell"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintTacticalCombatAiCastSpell))]
  public class TacticalCombatAiCastSpellConfigurator : BaseTacticalCombatAiActionConfigurator<BlueprintTacticalCombatAiCastSpell, TacticalCombatAiCastSpellConfigurator>
  {
    private TacticalCombatAiCastSpellConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static TacticalCombatAiCastSpellConfigurator For(string name)
    {
      return new TacticalCombatAiCastSpellConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static TacticalCombatAiCastSpellConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintTacticalCombatAiCastSpell>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatAiCastSpell.m_Ability"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ability"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    [Generated]
    public TacticalCombatAiCastSpellConfigurator SetAbility(string? ability)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(ability);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatAiCastSpell.m_ForceTargetSelf"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatAiCastSpellConfigurator SetForceTargetSelf(bool forceTargetSelf)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ForceTargetSelf = forceTargetSelf;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatAiCastSpell.m_ForceTargetEnemy"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatAiCastSpellConfigurator SetForceTargetEnemy(bool forceTargetEnemy)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ForceTargetEnemy = forceTargetEnemy;
          });
    }
  }
}
