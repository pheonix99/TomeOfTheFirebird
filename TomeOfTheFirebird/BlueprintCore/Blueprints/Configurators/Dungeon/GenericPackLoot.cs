using BlueprintCore.Utils;
using Kingmaker.Dungeon.Blueprints;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Dungeon
{
  /// <summary>
  /// Configurator for <see cref="BlueprintGenericPackLoot"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintGenericPackLoot))]
  public class GenericPackLootConfigurator : BaseBlueprintConfigurator<BlueprintGenericPackLoot, GenericPackLootConfigurator>
  {
    private GenericPackLootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static GenericPackLootConfigurator For(string name)
    {
      return new GenericPackLootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static GenericPackLootConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintGenericPackLoot>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintGenericPackLoot.Entries"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GenericPackLootConfigurator SetEntries(BlueprintGenericPackLoot.EntryType[]? entries)
    {
      ValidateParam(entries);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Entries = entries;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintGenericPackLoot.Entries"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GenericPackLootConfigurator AddToEntries(params BlueprintGenericPackLoot.EntryType[] entries)
    {
      ValidateParam(entries);
      return OnConfigureInternal(
          bp =>
          {
            bp.Entries = CommonTool.Append(bp.Entries, entries ?? new BlueprintGenericPackLoot.EntryType[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintGenericPackLoot.Entries"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GenericPackLootConfigurator RemoveFromEntries(params BlueprintGenericPackLoot.EntryType[] entries)
    {
      ValidateParam(entries);
      return OnConfigureInternal(
          bp =>
          {
            bp.Entries = bp.Entries.Where(item => !entries.Contains(item)).ToArray();
          });
    }
  }
}
