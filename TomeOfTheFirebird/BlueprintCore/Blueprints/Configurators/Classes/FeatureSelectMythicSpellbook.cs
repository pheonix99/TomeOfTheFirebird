using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>
  /// Configurator for <see cref="BlueprintFeatureSelectMythicSpellbook"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintFeatureSelectMythicSpellbook))]
  public class FeatureSelectMythicSpellbookConfigurator : BaseFeatureConfigurator<BlueprintFeatureSelectMythicSpellbook, FeatureSelectMythicSpellbookConfigurator>
  {
    private FeatureSelectMythicSpellbookConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static FeatureSelectMythicSpellbookConfigurator For(string name)
    {
      return new FeatureSelectMythicSpellbookConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static FeatureSelectMythicSpellbookConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintFeatureSelectMythicSpellbook>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintFeatureSelectMythicSpellbook.m_CachedItems"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FeatureSelectMythicSpellbookConfigurator SetCachedItems(List<IFeatureSelectionItem>? cachedItems)
    {
      ValidateParam(cachedItems);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedItems = cachedItems;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintFeatureSelectMythicSpellbook.m_CachedItems"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FeatureSelectMythicSpellbookConfigurator AddToCachedItems(params IFeatureSelectionItem[] cachedItems)
    {
      ValidateParam(cachedItems);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedItems.AddRange(cachedItems.ToList() ?? new List<IFeatureSelectionItem>());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintFeatureSelectMythicSpellbook.m_CachedItems"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FeatureSelectMythicSpellbookConfigurator RemoveFromCachedItems(params IFeatureSelectionItem[] cachedItems)
    {
      ValidateParam(cachedItems);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedItems = bp.m_CachedItems.Where(item => !cachedItems.Contains(item)).ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintFeatureSelectMythicSpellbook.m_AllowedSpellbooks"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="allowedSpellbooks"><see cref="Kingmaker.Blueprints.Classes.Spells.BlueprintSpellbook"/></param>
    [Generated]
    public FeatureSelectMythicSpellbookConfigurator SetAllowedSpellbooks(string[]? allowedSpellbooks)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AllowedSpellbooks = allowedSpellbooks.Select(name => BlueprintTool.GetRef<BlueprintSpellbookReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintFeatureSelectMythicSpellbook.m_AllowedSpellbooks"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="allowedSpellbooks"><see cref="Kingmaker.Blueprints.Classes.Spells.BlueprintSpellbook"/></param>
    [Generated]
    public FeatureSelectMythicSpellbookConfigurator AddToAllowedSpellbooks(params string[] allowedSpellbooks)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AllowedSpellbooks = CommonTool.Append(bp.m_AllowedSpellbooks, allowedSpellbooks.Select(name => BlueprintTool.GetRef<BlueprintSpellbookReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintFeatureSelectMythicSpellbook.m_AllowedSpellbooks"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="allowedSpellbooks"><see cref="Kingmaker.Blueprints.Classes.Spells.BlueprintSpellbook"/></param>
    [Generated]
    public FeatureSelectMythicSpellbookConfigurator RemoveFromAllowedSpellbooks(params string[] allowedSpellbooks)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = allowedSpellbooks.Select(name => BlueprintTool.GetRef<BlueprintSpellbookReference>(name));
            bp.m_AllowedSpellbooks =
                bp.m_AllowedSpellbooks
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintFeatureSelectMythicSpellbook.m_MythicSpellList"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="mythicSpellList"><see cref="Kingmaker.Blueprints.Classes.Spells.BlueprintSpellList"/></param>
    [Generated]
    public FeatureSelectMythicSpellbookConfigurator SetMythicSpellList(string? mythicSpellList)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_MythicSpellList = BlueprintTool.GetRef<BlueprintSpellListReference>(mythicSpellList);
          });
    }
  }
}
