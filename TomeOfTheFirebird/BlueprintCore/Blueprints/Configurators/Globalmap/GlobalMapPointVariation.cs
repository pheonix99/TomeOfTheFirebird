using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Kingdom;
using Kingmaker.Localization;
using System;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Globalmap
{
  /// <summary>
  /// Configurator for <see cref="BlueprintGlobalMapPointVariation"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintGlobalMapPointVariation))]
  public class GlobalMapPointVariationConfigurator : BaseBlueprintConfigurator<BlueprintGlobalMapPointVariation, GlobalMapPointVariationConfigurator>
  {
    private GlobalMapPointVariationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static GlobalMapPointVariationConfigurator For(string name)
    {
      return new GlobalMapPointVariationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static GlobalMapPointVariationConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintGlobalMapPointVariation>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPointVariation.Conditions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointVariationConfigurator SetConditions(ConditionsBuilder? conditions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPointVariation.Name"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointVariationConfigurator SetName(LocalizedString? name)
    {
      ValidateParam(name);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Name = name ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPointVariation.NameFromSettlement"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="nameFromSettlement"><see cref="Kingmaker.Kingdom.BlueprintSettlement"/></param>
    [Generated]
    public GlobalMapPointVariationConfigurator SetNameFromSettlement(string? nameFromSettlement)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.NameFromSettlement = BlueprintTool.GetRef<BlueprintSettlement.Reference>(nameFromSettlement);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPointVariation.Description"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointVariationConfigurator SetDescription(LocalizedString? description)
    {
      ValidateParam(description);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Description = description ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPointVariation.FakeName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointVariationConfigurator SetFakeName(LocalizedString? fakeName)
    {
      ValidateParam(fakeName);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.FakeName = fakeName ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPointVariation.FakeDescription"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GlobalMapPointVariationConfigurator SetFakeDescription(LocalizedString? fakeDescription)
    {
      ValidateParam(fakeDescription);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.FakeDescription = fakeDescription ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPointVariation.m_AreaEntrance"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="areaEntrance"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaEnterPoint"/></param>
    [Generated]
    public GlobalMapPointVariationConfigurator SetAreaEntrance(string? areaEntrance)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AreaEntrance = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(areaEntrance);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPointVariation.m_Entrances"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="entrances"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintMultiEntrance"/></param>
    [Generated]
    public GlobalMapPointVariationConfigurator SetEntrances(string? entrances)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Entrances = BlueprintTool.GetRef<BlueprintMultiEntranceReference>(entrances);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintGlobalMapPointVariation.m_BookEvent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="bookEvent"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintDialog"/></param>
    [Generated]
    public GlobalMapPointVariationConfigurator SetBookEvent(string? bookEvent)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_BookEvent = BlueprintTool.GetRef<BlueprintDialogReference>(bookEvent);
          });
    }

    /// <summary>
    /// Adds <see cref="LocationRestriction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="requiredCompanions"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(LocationRestriction))]
    public GlobalMapPointVariationConfigurator AddLocationRestriction(
        ConditionsBuilder? ignoreCondition = null,
        ConditionsBuilder? allowedCondition = null,
        string[]? requiredCompanions = null,
        LocalizedString? description = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(description);
    
      var component = new LocationRestriction();
      component.IgnoreCondition = ignoreCondition?.Build() ?? Constants.Empty.Conditions;
      component.AllowedCondition = allowedCondition?.Build() ?? Constants.Empty.Conditions;
      component.RequiredCompanions = requiredCompanions.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name)).ToList();
      component.Description = description ?? Constants.Empty.String;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }
  }
}
