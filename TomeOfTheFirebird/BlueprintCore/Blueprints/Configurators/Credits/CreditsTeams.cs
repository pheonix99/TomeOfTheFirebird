using BlueprintCore.Utils;
using Kingmaker.Blueprints.Credits;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Credits
{
  /// <summary>
  /// Configurator for <see cref="BlueprintCreditsTeams"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintCreditsTeams))]
  public class CreditsTeamsConfigurator : BaseBlueprintConfigurator<BlueprintCreditsTeams, CreditsTeamsConfigurator>
  {
    private CreditsTeamsConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CreditsTeamsConfigurator For(string name)
    {
      return new CreditsTeamsConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CreditsTeamsConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintCreditsTeams>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCreditsTeams.Teams"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CreditsTeamsConfigurator SetTeams(List<CreditTeam>? teams)
    {
      ValidateParam(teams);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Teams = teams;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintCreditsTeams.Teams"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CreditsTeamsConfigurator AddToTeams(params CreditTeam[] teams)
    {
      ValidateParam(teams);
      return OnConfigureInternal(
          bp =>
          {
            bp.Teams.AddRange(teams.ToList() ?? new List<CreditTeam>());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintCreditsTeams.Teams"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CreditsTeamsConfigurator RemoveFromTeams(params CreditTeam[] teams)
    {
      ValidateParam(teams);
      return OnConfigureInternal(
          bp =>
          {
            bp.Teams = bp.Teams.Where(item => !teams.Contains(item)).ToList();
          });
    }
  }
}
