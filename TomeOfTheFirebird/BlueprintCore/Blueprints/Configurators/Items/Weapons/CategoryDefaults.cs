using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items.Weapons;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Items.Weapons
{
  /// <summary>
  /// Configurator for <see cref="BlueprintCategoryDefaults"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintCategoryDefaults))]
  public class CategoryDefaultsConfigurator : BaseBlueprintConfigurator<BlueprintCategoryDefaults, CategoryDefaultsConfigurator>
  {
    private CategoryDefaultsConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CategoryDefaultsConfigurator For(string name)
    {
      return new CategoryDefaultsConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CategoryDefaultsConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintCategoryDefaults>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCategoryDefaults.Entries"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CategoryDefaultsConfigurator SetEntries(BlueprintCategoryDefaults.CategoryDefaultEntry[]? entries)
    {
      ValidateParam(entries);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Entries = entries;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintCategoryDefaults.Entries"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CategoryDefaultsConfigurator AddToEntries(params BlueprintCategoryDefaults.CategoryDefaultEntry[] entries)
    {
      ValidateParam(entries);
      return OnConfigureInternal(
          bp =>
          {
            bp.Entries = CommonTool.Append(bp.Entries, entries ?? new BlueprintCategoryDefaults.CategoryDefaultEntry[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintCategoryDefaults.Entries"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CategoryDefaultsConfigurator RemoveFromEntries(params BlueprintCategoryDefaults.CategoryDefaultEntry[] entries)
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
