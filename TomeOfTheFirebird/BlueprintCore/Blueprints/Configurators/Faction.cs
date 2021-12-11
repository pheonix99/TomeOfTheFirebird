using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Configurator for <see cref="BlueprintFaction"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintFaction))]
  public class FactionConfigurator : BaseBlueprintConfigurator<BlueprintFaction, FactionConfigurator>
  {
    private FactionConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static FactionConfigurator For(string name)
    {
      return new FactionConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static FactionConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintFaction>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintFaction.m_AttackFactions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="attackFactions"><see cref="Kingmaker.Blueprints.BlueprintFaction"/></param>
    [Generated]
    public FactionConfigurator SetAttackFactions(string[]? attackFactions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AttackFactions = attackFactions.Select(name => BlueprintTool.GetRef<BlueprintFactionReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintFaction.m_AttackFactions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="attackFactions"><see cref="Kingmaker.Blueprints.BlueprintFaction"/></param>
    [Generated]
    public FactionConfigurator AddToAttackFactions(params string[] attackFactions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AttackFactions = CommonTool.Append(bp.m_AttackFactions, attackFactions.Select(name => BlueprintTool.GetRef<BlueprintFactionReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintFaction.m_AttackFactions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="attackFactions"><see cref="Kingmaker.Blueprints.BlueprintFaction"/></param>
    [Generated]
    public FactionConfigurator RemoveFromAttackFactions(params string[] attackFactions)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = attackFactions.Select(name => BlueprintTool.GetRef<BlueprintFactionReference>(name));
            bp.m_AttackFactions =
                bp.m_AttackFactions
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintFaction.m_AllyFactions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="allyFactions"><see cref="Kingmaker.Blueprints.BlueprintFaction"/></param>
    [Generated]
    public FactionConfigurator SetAllyFactions(string[]? allyFactions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AllyFactions = allyFactions.Select(name => BlueprintTool.GetRef<BlueprintFactionReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintFaction.m_AllyFactions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="allyFactions"><see cref="Kingmaker.Blueprints.BlueprintFaction"/></param>
    [Generated]
    public FactionConfigurator AddToAllyFactions(params string[] allyFactions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AllyFactions = CommonTool.Append(bp.m_AllyFactions, allyFactions.Select(name => BlueprintTool.GetRef<BlueprintFactionReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintFaction.m_AllyFactions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="allyFactions"><see cref="Kingmaker.Blueprints.BlueprintFaction"/></param>
    [Generated]
    public FactionConfigurator RemoveFromAllyFactions(params string[] allyFactions)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = allyFactions.Select(name => BlueprintTool.GetRef<BlueprintFactionReference>(name));
            bp.m_AllyFactions =
                bp.m_AllyFactions
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintFaction.m_AllyFactionsBehaviour"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FactionConfigurator SetAllyFactionsBehaviour(BlueprintFaction.EAllyFactions allyFactionsBehaviour)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AllyFactionsBehaviour = allyFactionsBehaviour;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintFaction.Peaceful"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FactionConfigurator SetPeaceful(bool peaceful)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Peaceful = peaceful;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintFaction.AlwaysEnemy"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FactionConfigurator SetAlwaysEnemy(bool alwaysEnemy)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AlwaysEnemy = alwaysEnemy;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintFaction.EnemyForEveryone"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FactionConfigurator SetEnemyForEveryone(bool enemyForEveryone)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.EnemyForEveryone = enemyForEveryone;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintFaction.Neutral"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FactionConfigurator SetNeutral(bool neutral)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Neutral = neutral;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintFaction.IsDirectlyControllable"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FactionConfigurator SetIsDirectlyControllable(bool isDirectlyControllable)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IsDirectlyControllable = isDirectlyControllable;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintFaction.NeverJoinCombat"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FactionConfigurator SetNeverJoinCombat(bool neverJoinCombat)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.NeverJoinCombat = neverJoinCombat;
          });
    }
  }
}
