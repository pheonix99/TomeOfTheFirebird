using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.Settlements;
using Kingmaker.Localization;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>
  /// Configurator for <see cref="BlueprintSettlement"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintSettlement))]
  public class SettlementConfigurator : BaseBlueprintConfigurator<BlueprintSettlement, SettlementConfigurator>
  {
    private SettlementConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static SettlementConfigurator For(string name)
    {
      return new SettlementConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static SettlementConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintSettlement>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintSettlement.m_StartLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SettlementConfigurator SetStartLevel(SettlementState.LevelType startLevel)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_StartLevel = startLevel;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSettlement.m_MaxSettlementLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SettlementConfigurator SetMaxSettlementLevel(SettlementState.LevelType maxSettlementLevel)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_MaxSettlementLevel = maxSettlementLevel;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSettlement.m_HasWaterSlot"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SettlementConfigurator SetHasWaterSlot(bool hasWaterSlot)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_HasWaterSlot = hasWaterSlot;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSettlement.m_DefaultSettlementName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SettlementConfigurator SetDefaultSettlementName(LocalizedString? defaultSettlementName)
    {
      ValidateParam(defaultSettlementName);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DefaultSettlementName = defaultSettlementName ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSettlement.m_SettlementBuildArea"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="settlementBuildArea"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaEnterPoint"/></param>
    [Generated]
    public SettlementConfigurator SettlementBuildArea(string? settlementBuildArea)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_SettlementBuildArea = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(settlementBuildArea);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSettlement.m_SettlementBuildAreaWithWater"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="settlementBuildAreaWithWater"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaEnterPoint"/></param>
    [Generated]
    public SettlementConfigurator SettlementBuildAreaWithWater(string? settlementBuildAreaWithWater)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_SettlementBuildAreaWithWater = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(settlementBuildAreaWithWater);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSettlement.m_CustomSettlementEntrance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SettlementConfigurator SetCustomSettlementEntrance(bool customSettlementEntrance)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CustomSettlementEntrance = customSettlementEntrance;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSettlement.m_SettlementIsPrebuilt"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SettlementConfigurator SettlementIsPrebuilt(bool settlementIsPrebuilt)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_SettlementIsPrebuilt = settlementIsPrebuilt;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSettlement.m_SettlementEntrance"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="settlementEntrance"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaEnterPoint"/></param>
    [Generated]
    public SettlementConfigurator SettlementEntrance(string? settlementEntrance)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_SettlementEntrance = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(settlementEntrance);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSettlement.m_SettlementEntrances"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="settlementEntrances"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintMultiEntrance"/></param>
    [Generated]
    public SettlementConfigurator SettlementEntrances(string? settlementEntrances)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_SettlementEntrances = BlueprintTool.GetRef<BlueprintMultiEntrance.Reference>(settlementEntrances);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSettlement.m_CustomSiegeDurationDays"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SettlementConfigurator SetCustomSiegeDurationDays(int? customSiegeDurationDays)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CustomSiegeDurationDays = customSiegeDurationDays;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSettlement.m_NeedOwnMarker"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SettlementConfigurator SetNeedOwnMarker(bool needOwnMarker)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_NeedOwnMarker = needOwnMarker;
          });
    }
  }
}
