using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Credits;
using Kingmaker.Localization;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Credits
{
  /// <summary>
  /// Configurator for <see cref="BlueprintCreditsGroup"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintCreditsGroup))]
  public class CreditsGroupConfigurator : BaseBlueprintConfigurator<BlueprintCreditsGroup, CreditsGroupConfigurator>
  {
    private CreditsGroupConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CreditsGroupConfigurator For(string name)
    {
      return new CreditsGroupConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CreditsGroupConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintCreditsGroup>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCreditsGroup.TabIcon"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CreditsGroupConfigurator SetTabIcon(Sprite tabIcon)
    {
      ValidateParam(tabIcon);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.TabIcon = tabIcon;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCreditsGroup.HeaderText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CreditsGroupConfigurator SetHeaderText(LocalizedString? headerText)
    {
      ValidateParam(headerText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.HeaderText = headerText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCreditsGroup.LeftPageImage"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CreditsGroupConfigurator SetLeftPageImage(Sprite leftPageImage)
    {
      ValidateParam(leftPageImage);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.LeftPageImage = leftPageImage;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCreditsGroup.LeftPageText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CreditsGroupConfigurator SetLeftPageText(LocalizedString? leftPageText)
    {
      ValidateParam(leftPageText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.LeftPageText = leftPageText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCreditsGroup.m_RolesData"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="rolesData"><see cref="Kingmaker.Blueprints.Credits.BlueprintCreditsRoles"/></param>
    [Generated]
    public CreditsGroupConfigurator SetRolesData(string? rolesData)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_RolesData = BlueprintTool.GetRef<BlueprintCreditsRolesReference>(rolesData);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCreditsGroup.m_TeamsData"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="teamsData"><see cref="Kingmaker.Blueprints.Credits.BlueprintCreditsTeams"/></param>
    [Generated]
    public CreditsGroupConfigurator SetTeamsData(string? teamsData)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_TeamsData = BlueprintTool.GetRef<BlueprintCreditsTeamsReference>(teamsData);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCreditsGroup.OrderTeams"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CreditsGroupConfigurator SetOrderTeams(List<string>? orderTeams)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.OrderTeams = orderTeams;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintCreditsGroup.OrderTeams"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CreditsGroupConfigurator AddToOrderTeams(params string[] orderTeams)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.OrderTeams.AddRange(orderTeams.ToList() ?? new List<string>());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintCreditsGroup.OrderTeams"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CreditsGroupConfigurator RemoveFromOrderTeams(params string[] orderTeams)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.OrderTeams = bp.OrderTeams.Where(item => !orderTeams.Contains(item)).ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCreditsGroup.Persones"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CreditsGroupConfigurator SetPersones(List<CreditPerson>? persones)
    {
      ValidateParam(persones);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Persones = persones;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintCreditsGroup.Persones"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CreditsGroupConfigurator AddToPersones(params CreditPerson[] persones)
    {
      ValidateParam(persones);
      return OnConfigureInternal(
          bp =>
          {
            bp.Persones.AddRange(persones.ToList() ?? new List<CreditPerson>());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintCreditsGroup.Persones"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CreditsGroupConfigurator RemoveFromPersones(params CreditPerson[] persones)
    {
      ValidateParam(persones);
      return OnConfigureInternal(
          bp =>
          {
            bp.Persones = bp.Persones.Where(item => !persones.Contains(item)).ToList();
          });
    }
  }
}
