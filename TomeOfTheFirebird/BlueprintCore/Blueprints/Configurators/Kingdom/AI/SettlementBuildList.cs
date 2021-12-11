using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom.AI;
using Kingmaker.UI.Settlement;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Kingdom.AI
{
  /// <summary>
  /// Configurator for <see cref="SettlementBuildList"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(SettlementBuildList))]
  public class SettlementBuildListConfigurator : BaseBlueprintConfigurator<SettlementBuildList, SettlementBuildListConfigurator>
  {
    private SettlementBuildListConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static SettlementBuildListConfigurator For(string name)
    {
      return new SettlementBuildListConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static SettlementBuildListConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<SettlementBuildList>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="SettlementBuildList.m_BuildArea"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buildArea"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaEnterPoint"/></param>
    [Generated]
    public SettlementBuildListConfigurator SetBuildArea(string? buildArea)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_BuildArea = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(buildArea);
          });
    }

    /// <summary>
    /// Sets <see cref="SettlementBuildList.SlotSetupPrefab"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SettlementBuildListConfigurator SetSlotSetupPrefab(SettlementsBuildSlots slotSetupPrefab)
    {
      ValidateParam(slotSetupPrefab);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.SlotSetupPrefab = slotSetupPrefab;
          });
    }

    /// <summary>
    /// Sets <see cref="SettlementBuildList.List"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SettlementBuildListConfigurator SetList(List<SettlementBuildList.Entry>? list)
    {
      ValidateParam(list);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.List = list;
          });
    }

    /// <summary>
    /// Adds to <see cref="SettlementBuildList.List"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SettlementBuildListConfigurator AddToList(params SettlementBuildList.Entry[] list)
    {
      ValidateParam(list);
      return OnConfigureInternal(
          bp =>
          {
            bp.List.AddRange(list.ToList() ?? new List<SettlementBuildList.Entry>());
          });
    }

    /// <summary>
    /// Removes from <see cref="SettlementBuildList.List"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SettlementBuildListConfigurator RemoveFromList(params SettlementBuildList.Entry[] list)
    {
      ValidateParam(list);
      return OnConfigureInternal(
          bp =>
          {
            bp.List = bp.List.Where(item => !list.Contains(item)).ToList();
          });
    }
  }
}
