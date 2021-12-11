using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Items
{
  /// <summary>
  /// Configurator for <see cref="BlueprintItemsList"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItemsList))]
  public class ItemsListConfigurator : BaseBlueprintConfigurator<BlueprintItemsList, ItemsListConfigurator>
  {
    private ItemsListConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ItemsListConfigurator For(string name)
    {
      return new ItemsListConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ItemsListConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintItemsList>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemsList.m_Items"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="items"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    public ItemsListConfigurator SetItems(string[]? items)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Items = items.Select(name => BlueprintTool.GetRef<BlueprintItemReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintItemsList.m_Items"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="items"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    public ItemsListConfigurator AddToItems(params string[] items)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Items = CommonTool.Append(bp.m_Items, items.Select(name => BlueprintTool.GetRef<BlueprintItemReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintItemsList.m_Items"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="items"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    public ItemsListConfigurator RemoveFromItems(params string[] items)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = items.Select(name => BlueprintTool.GetRef<BlueprintItemReference>(name));
            bp.m_Items =
                bp.m_Items
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }
  }
}
