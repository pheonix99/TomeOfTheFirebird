using BlueprintCore.Utils;
using Kingmaker.Blueprints.Loot;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Loot
{
  /// <summary>
  /// Configurator for <see cref="TrashLootSettings"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(TrashLootSettings))]
  public class TrashLootSettingsConfigurator : BaseBlueprintConfigurator<TrashLootSettings, TrashLootSettingsConfigurator>
  {
    private TrashLootSettingsConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static TrashLootSettingsConfigurator For(string name)
    {
      return new TrashLootSettingsConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static TrashLootSettingsConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<TrashLootSettings>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="TrashLootSettings.CRToCost"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrashLootSettingsConfigurator SetCRToCost(int[]? cRToCost)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CRToCost = cRToCost;
          });
    }

    /// <summary>
    /// Adds to <see cref="TrashLootSettings.CRToCost"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrashLootSettingsConfigurator AddToCRToCost(params int[] cRToCost)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CRToCost = CommonTool.Append(bp.CRToCost, cRToCost ?? new int[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="TrashLootSettings.CRToCost"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrashLootSettingsConfigurator RemoveFromCRToCost(params int[] cRToCost)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CRToCost = bp.CRToCost.Where(item => !cRToCost.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="TrashLootSettings.ChanceToIncreaseItemsCount"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrashLootSettingsConfigurator SetChanceToIncreaseItemsCount(int[]? chanceToIncreaseItemsCount)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ChanceToIncreaseItemsCount = chanceToIncreaseItemsCount;
          });
    }

    /// <summary>
    /// Adds to <see cref="TrashLootSettings.ChanceToIncreaseItemsCount"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrashLootSettingsConfigurator AddToChanceToIncreaseItemsCount(params int[] chanceToIncreaseItemsCount)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ChanceToIncreaseItemsCount = CommonTool.Append(bp.ChanceToIncreaseItemsCount, chanceToIncreaseItemsCount ?? new int[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="TrashLootSettings.ChanceToIncreaseItemsCount"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrashLootSettingsConfigurator RemoveFromChanceToIncreaseItemsCount(params int[] chanceToIncreaseItemsCount)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ChanceToIncreaseItemsCount = bp.ChanceToIncreaseItemsCount.Where(item => !chanceToIncreaseItemsCount.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="TrashLootSettings.Types"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrashLootSettingsConfigurator SetTypes(List<TrashLootSettings.TypeSettings>? types)
    {
      ValidateParam(types);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Types = types;
          });
    }

    /// <summary>
    /// Adds to <see cref="TrashLootSettings.Types"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrashLootSettingsConfigurator AddToTypes(params TrashLootSettings.TypeSettings[] types)
    {
      ValidateParam(types);
      return OnConfigureInternal(
          bp =>
          {
            bp.Types.AddRange(types.ToList() ?? new List<TrashLootSettings.TypeSettings>());
          });
    }

    /// <summary>
    /// Removes from <see cref="TrashLootSettings.Types"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrashLootSettingsConfigurator RemoveFromTypes(params TrashLootSettings.TypeSettings[] types)
    {
      ValidateParam(types);
      return OnConfigureInternal(
          bp =>
          {
            bp.Types = bp.Types.Where(item => !types.Contains(item)).ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="TrashLootSettings.Table"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrashLootSettingsConfigurator SetTable(TrashLootSettings.TypeChance[]? table)
    {
      ValidateParam(table);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Table = table;
          });
    }

    /// <summary>
    /// Adds to <see cref="TrashLootSettings.Table"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrashLootSettingsConfigurator AddToTable(params TrashLootSettings.TypeChance[] table)
    {
      ValidateParam(table);
      return OnConfigureInternal(
          bp =>
          {
            bp.Table = CommonTool.Append(bp.Table, table ?? new TrashLootSettings.TypeChance[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="TrashLootSettings.Table"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrashLootSettingsConfigurator RemoveFromTable(params TrashLootSettings.TypeChance[] table)
    {
      ValidateParam(table);
      return OnConfigureInternal(
          bp =>
          {
            bp.Table = bp.Table.Where(item => !table.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="TrashLootSettings.SuperTrashLoot"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrashLootSettingsConfigurator SetSuperTrashLoot(TrashLootSettings.SettingAndItems[]? superTrashLoot)
    {
      ValidateParam(superTrashLoot);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.SuperTrashLoot = superTrashLoot;
          });
    }

    /// <summary>
    /// Adds to <see cref="TrashLootSettings.SuperTrashLoot"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrashLootSettingsConfigurator AddToSuperTrashLoot(params TrashLootSettings.SettingAndItems[] superTrashLoot)
    {
      ValidateParam(superTrashLoot);
      return OnConfigureInternal(
          bp =>
          {
            bp.SuperTrashLoot = CommonTool.Append(bp.SuperTrashLoot, superTrashLoot ?? new TrashLootSettings.SettingAndItems[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="TrashLootSettings.SuperTrashLoot"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrashLootSettingsConfigurator RemoveFromSuperTrashLoot(params TrashLootSettings.SettingAndItems[] superTrashLoot)
    {
      ValidateParam(superTrashLoot);
      return OnConfigureInternal(
          bp =>
          {
            bp.SuperTrashLoot = bp.SuperTrashLoot.Where(item => !superTrashLoot.Contains(item)).ToArray();
          });
    }
  }
}
