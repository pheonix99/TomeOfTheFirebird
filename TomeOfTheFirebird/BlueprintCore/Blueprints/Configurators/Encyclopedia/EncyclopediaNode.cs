using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Encyclopedia;
using Kingmaker.Localization;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Encyclopedia
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintEncyclopediaNode"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintEncyclopediaNode))]
  public abstract class BaseEncyclopediaNodeConfigurator<T, TBuilder>
      : BaseBlueprintConfigurator<T, TBuilder>
      where T : BlueprintEncyclopediaNode
      where TBuilder : BaseEncyclopediaNodeConfigurator<T, TBuilder>
  {
    protected BaseEncyclopediaNodeConfigurator(string name) : base(name) { }

    /// <summary>
    /// Sets <see cref="BlueprintEncyclopediaNode.Title"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetTitle(LocalizedString? title)
    {
      ValidateParam(title);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Title = title ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintEncyclopediaNode.m_Expanded"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetExpanded(bool expanded)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Expanded = expanded;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintEncyclopediaNode.ChildPages"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="childPages"><see cref="Kingmaker.Blueprints.Encyclopedia.BlueprintEncyclopediaPage"/></param>
    [Generated]
    public TBuilder SetChildPages(string[]? childPages)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ChildPages = childPages.Select(name => BlueprintTool.GetRef<BlueprintEncyclopediaPageReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintEncyclopediaNode.ChildPages"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="childPages"><see cref="Kingmaker.Blueprints.Encyclopedia.BlueprintEncyclopediaPage"/></param>
    [Generated]
    public TBuilder AddToChildPages(params string[] childPages)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ChildPages.AddRange(childPages.Select(name => BlueprintTool.GetRef<BlueprintEncyclopediaPageReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintEncyclopediaNode.ChildPages"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="childPages"><see cref="Kingmaker.Blueprints.Encyclopedia.BlueprintEncyclopediaPage"/></param>
    [Generated]
    public TBuilder RemoveFromChildPages(params string[] childPages)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = childPages.Select(name => BlueprintTool.GetRef<BlueprintEncyclopediaPageReference>(name));
            bp.ChildPages =
                bp.ChildPages
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }
  }
}
