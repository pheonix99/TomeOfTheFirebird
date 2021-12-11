using BlueprintCore.Utils;
using Kingmaker.Formations;
using System.Linq;
using UnityEngine;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Formations
{
  /// <summary>
  /// Configurator for <see cref="FollowersFormation"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(FollowersFormation))]
  public class FollowersFormationConfigurator : BaseBlueprintConfigurator<FollowersFormation, FollowersFormationConfigurator>
  {
    private FollowersFormationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static FollowersFormationConfigurator For(string name)
    {
      return new FollowersFormationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static FollowersFormationConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<FollowersFormation>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="FollowersFormation.m_PlayerOffset"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FollowersFormationConfigurator SetPlayerOffset(Vector2 playerOffset)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_PlayerOffset = playerOffset;
          });
    }

    /// <summary>
    /// Sets <see cref="FollowersFormation.m_Formation"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FollowersFormationConfigurator SetFormation(Vector2[]? formation)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Formation = formation;
          });
    }

    /// <summary>
    /// Adds to <see cref="FollowersFormation.m_Formation"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FollowersFormationConfigurator AddToFormation(params Vector2[] formation)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Formation = CommonTool.Append(bp.m_Formation, formation ?? new Vector2[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="FollowersFormation.m_Formation"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FollowersFormationConfigurator RemoveFromFormation(params Vector2[] formation)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Formation = bp.m_Formation.Where(item => !formation.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="FollowersFormation.m_RepathDistance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FollowersFormationConfigurator SetRepathDistance(float repathDistance)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_RepathDistance = repathDistance;
          });
    }

    /// <summary>
    /// Sets <see cref="FollowersFormation.m_RepathCooldownSec"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FollowersFormationConfigurator SetRepathCooldownSec(float repathCooldownSec)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_RepathCooldownSec = repathCooldownSec;
          });
    }

    /// <summary>
    /// Sets <see cref="FollowersFormation.m_LookAngleRandomSpread"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FollowersFormationConfigurator SetLookAngleRandomSpread(float lookAngleRandomSpread)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_LookAngleRandomSpread = lookAngleRandomSpread;
          });
    }
  }
}
