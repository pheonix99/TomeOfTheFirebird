using BlueprintCore.Utils;
using Kingmaker.Blueprints.Credits;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Credits
{
  /// <summary>
  /// Configurator for <see cref="BlueprintCreditsRoles"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintCreditsRoles))]
  public class CreditsRolesConfigurator : BaseBlueprintConfigurator<BlueprintCreditsRoles, CreditsRolesConfigurator>
  {
    private CreditsRolesConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CreditsRolesConfigurator For(string name)
    {
      return new CreditsRolesConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CreditsRolesConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintCreditsRoles>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCreditsRoles.Roles"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CreditsRolesConfigurator SetRoles(List<CreditRole>? roles)
    {
      ValidateParam(roles);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Roles = roles;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintCreditsRoles.Roles"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CreditsRolesConfigurator AddToRoles(params CreditRole[] roles)
    {
      ValidateParam(roles);
      return OnConfigureInternal(
          bp =>
          {
            bp.Roles.AddRange(roles.ToList() ?? new List<CreditRole>());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintCreditsRoles.Roles"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CreditsRolesConfigurator RemoveFromRoles(params CreditRole[] roles)
    {
      ValidateParam(roles);
      return OnConfigureInternal(
          bp =>
          {
            bp.Roles = bp.Roles.Where(item => !roles.Contains(item)).ToList();
          });
    }
  }
}
