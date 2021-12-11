using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Encyclopedia;
using Kingmaker.Blueprints.Encyclopedia.Blocks;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Encyclopedia
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintEncyclopediaPage"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintEncyclopediaPage))]
  public abstract class BaseEncyclopediaPageConfigurator<T, TBuilder>
      : BaseEncyclopediaNodeConfigurator<T, TBuilder>
      where T : BlueprintEncyclopediaPage
      where TBuilder : BaseEncyclopediaPageConfigurator<T, TBuilder>
  {
    protected BaseEncyclopediaPageConfigurator(string name) : base(name) { }

    /// <summary>
    /// Sets <see cref="BlueprintEncyclopediaPage.m_ParentAsset"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="parentAsset"><see cref="Kingmaker.Blueprints.Encyclopedia.BlueprintEncyclopediaNode"/></param>
    [Generated]
    public TBuilder SetParentAsset(string? parentAsset)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ParentAsset = BlueprintTool.GetRef<BlueprintEncyclopediaNodeReference>(parentAsset);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintEncyclopediaPage.Blocks"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetBlocks(List<BlueprintEncyclopediaBlock>? blocks)
    {
      ValidateParam(blocks);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Blocks = blocks;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintEncyclopediaPage.Blocks"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder AddToBlocks(params BlueprintEncyclopediaBlock[] blocks)
    {
      ValidateParam(blocks);
      return OnConfigureInternal(
          bp =>
          {
            bp.Blocks.AddRange(blocks.ToList() ?? new List<BlueprintEncyclopediaBlock>());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintEncyclopediaPage.Blocks"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder RemoveFromBlocks(params BlueprintEncyclopediaBlock[] blocks)
    {
      ValidateParam(blocks);
      return OnConfigureInternal(
          bp =>
          {
            bp.Blocks = bp.Blocks.Where(item => !blocks.Contains(item)).ToList();
          });
    }
  }

  /// <summary>
  /// Configurator for <see cref="BlueprintEncyclopediaPage"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintEncyclopediaPage))]
  public class EncyclopediaPageConfigurator : BaseEncyclopediaNodeConfigurator<BlueprintEncyclopediaPage, EncyclopediaPageConfigurator>
  {
    private EncyclopediaPageConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static EncyclopediaPageConfigurator For(string name)
    {
      return new EncyclopediaPageConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static EncyclopediaPageConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintEncyclopediaPage>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintEncyclopediaPage.m_ParentAsset"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="parentAsset"><see cref="Kingmaker.Blueprints.Encyclopedia.BlueprintEncyclopediaNode"/></param>
    [Generated]
    public EncyclopediaPageConfigurator SetParentAsset(string? parentAsset)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ParentAsset = BlueprintTool.GetRef<BlueprintEncyclopediaNodeReference>(parentAsset);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintEncyclopediaPage.Blocks"/> (Auto Generated)
    /// </summary>
    [Generated]
    public EncyclopediaPageConfigurator SetBlocks(List<BlueprintEncyclopediaBlock>? blocks)
    {
      ValidateParam(blocks);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Blocks = blocks;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintEncyclopediaPage.Blocks"/> (Auto Generated)
    /// </summary>
    [Generated]
    public EncyclopediaPageConfigurator AddToBlocks(params BlueprintEncyclopediaBlock[] blocks)
    {
      ValidateParam(blocks);
      return OnConfigureInternal(
          bp =>
          {
            bp.Blocks.AddRange(blocks.ToList() ?? new List<BlueprintEncyclopediaBlock>());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintEncyclopediaPage.Blocks"/> (Auto Generated)
    /// </summary>
    [Generated]
    public EncyclopediaPageConfigurator RemoveFromBlocks(params BlueprintEncyclopediaBlock[] blocks)
    {
      ValidateParam(blocks);
      return OnConfigureInternal(
          bp =>
          {
            bp.Blocks = bp.Blocks.Where(item => !blocks.Contains(item)).ToList();
          });
    }
  }
}
