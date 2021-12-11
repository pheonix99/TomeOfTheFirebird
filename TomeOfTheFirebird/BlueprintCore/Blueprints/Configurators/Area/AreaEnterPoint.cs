using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.RandomEncounters.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>
  /// Configurator for <see cref="BlueprintAreaEnterPoint"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintAreaEnterPoint))]
  public class AreaEnterPointConfigurator : BaseBlueprintConfigurator<BlueprintAreaEnterPoint, AreaEnterPointConfigurator>
  {
    private AreaEnterPointConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AreaEnterPointConfigurator For(string name)
    {
      return new AreaEnterPointConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AreaEnterPointConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintAreaEnterPoint>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaEnterPoint.m_Area"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="area"><see cref="Kingmaker.Blueprints.Area.BlueprintArea"/></param>
    [Generated]
    public AreaEnterPointConfigurator SetArea(string? area)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Area = BlueprintTool.GetRef<BlueprintAreaReference>(area);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaEnterPoint.m_AreaPart"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="areaPart"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaPart"/></param>
    [Generated]
    public AreaEnterPointConfigurator SetAreaPart(string? areaPart)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AreaPart = BlueprintTool.GetRef<BlueprintAreaPartReference>(areaPart);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaEnterPoint.m_TooltipList"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaEnterPointConfigurator SetTooltipList(List<LocalizedString>? tooltipList)
    {
      ValidateParam(tooltipList);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_TooltipList = tooltipList;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAreaEnterPoint.m_TooltipList"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaEnterPointConfigurator AddToTooltipList(params LocalizedString[] tooltipList)
    {
      ValidateParam(tooltipList);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_TooltipList.AddRange(tooltipList.ToList() ?? new List<LocalizedString>());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAreaEnterPoint.m_TooltipList"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaEnterPointConfigurator RemoveFromTooltipList(params LocalizedString[] tooltipList)
    {
      ValidateParam(tooltipList);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_TooltipList = bp.m_TooltipList.Where(item => !tooltipList.Contains(item)).ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaEnterPoint.m_Tooltip"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaEnterPointConfigurator SetTooltip(LocalizedString? tooltip)
    {
      ValidateParam(tooltip);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Tooltip = tooltip ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaEnterPoint.m_CanBeOutsideNavmesh"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaEnterPointConfigurator SetCanBeOutsideNavmesh(bool canBeOutsideNavmesh)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CanBeOutsideNavmesh = canBeOutsideNavmesh;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaEnterPoint.Icon"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaEnterPointConfigurator SetIcon(Sprite icon)
    {
      ValidateParam(icon);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Icon = icon;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaEnterPoint.HoverIcon"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaEnterPointConfigurator SetHoverIcon(Sprite hoverIcon)
    {
      ValidateParam(hoverIcon);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.HoverIcon = hoverIcon;
          });
    }

    /// <summary>
    /// Adds <see cref="AllowOnZoneSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AllowOnZoneSettings))]
    public AreaEnterPointConfigurator AddAllowOnZoneSettings(
        GlobalMapZone[]? allowedNaturalSettings = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AllowOnZoneSettings();
      component.m_AllowedNaturalSettings = allowedNaturalSettings;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }
  }
}
