using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Loot;
using Kingmaker.Enums;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Loot
{
  /// <summary>
  /// Configurator for <see cref="BlueprintLoot"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintLoot))]
  public class LootConfigurator : BaseBlueprintConfigurator<BlueprintLoot, LootConfigurator>
  {
    private LootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static LootConfigurator For(string name)
    {
      return new LootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static LootConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintLoot>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintLoot.Type"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LootConfigurator SetType(LootType type)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Type = type;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintLoot.IsSuperTrash"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LootConfigurator SetIsSuperTrash(bool isSuperTrash)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IsSuperTrash = isSuperTrash;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintLoot.Identify"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LootConfigurator SetIdentify(bool identify)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Identify = identify;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintLoot.Setting"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LootConfigurator Setting(LootSetting setting)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Setting = setting;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintLoot.m_Area"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="area"><see cref="Kingmaker.Blueprints.Area.BlueprintArea"/></param>
    [Generated]
    public LootConfigurator SetArea(string? area)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Area = BlueprintTool.GetRef<BlueprintAreaReference>(area);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintLoot.ContainerName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LootConfigurator SetContainerName(string containerName)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ContainerName = containerName;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintLoot.Items"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LootConfigurator SetItems(LootEntry[]? items)
    {
      ValidateParam(items);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Items = items;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintLoot.Items"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LootConfigurator AddToItems(params LootEntry[] items)
    {
      ValidateParam(items);
      return OnConfigureInternal(
          bp =>
          {
            bp.Items = CommonTool.Append(bp.Items, items ?? new LootEntry[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintLoot.Items"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LootConfigurator RemoveFromItems(params LootEntry[] items)
    {
      ValidateParam(items);
      return OnConfigureInternal(
          bp =>
          {
            bp.Items = bp.Items.Where(item => !items.Contains(item)).ToArray();
          });
    }
  }
}
