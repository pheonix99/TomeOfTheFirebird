using BlueprintCore.Utils;
using Kingmaker.Formations;
using Kingmaker.Localization;
using System.Linq;
using UnityEngine;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Formations
{
  /// <summary>
  /// Configurator for <see cref="BlueprintPartyFormation"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintPartyFormation))]
  public class PartyFormationConfigurator : BaseBlueprintConfigurator<BlueprintPartyFormation, PartyFormationConfigurator>
  {
    private PartyFormationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static PartyFormationConfigurator For(string name)
    {
      return new PartyFormationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static PartyFormationConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintPartyFormation>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintPartyFormation.Positions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public PartyFormationConfigurator SetPositions(Vector2[]? positions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Positions = positions;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintPartyFormation.Positions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public PartyFormationConfigurator AddToPositions(params Vector2[] positions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Positions = CommonTool.Append(bp.Positions, positions ?? new Vector2[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintPartyFormation.Positions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public PartyFormationConfigurator RemoveFromPositions(params Vector2[] positions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Positions = bp.Positions.Where(item => !positions.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintPartyFormation.Type"/> (Auto Generated)
    /// </summary>
    [Generated]
    public PartyFormationConfigurator SetType(PartyFormationType type)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Type = type;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintPartyFormation.Name"/> (Auto Generated)
    /// </summary>
    [Generated]
    public PartyFormationConfigurator SetName(LocalizedString? name)
    {
      ValidateParam(name);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Name = name ?? Constants.Empty.String;
          });
    }
  }
}
