using BlueprintCore.Utils;
using Kingmaker.Kingdom.Blueprints;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>
  /// Configurator for <see cref="BlueprintCrusadeEventTimeline"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintCrusadeEventTimeline))]
  public class CrusadeEventTimelineConfigurator : BaseBlueprintConfigurator<BlueprintCrusadeEventTimeline, CrusadeEventTimelineConfigurator>
  {
    private CrusadeEventTimelineConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CrusadeEventTimelineConfigurator For(string name)
    {
      return new CrusadeEventTimelineConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CrusadeEventTimelineConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintCrusadeEventTimeline>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCrusadeEventTimeline.Chapters"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CrusadeEventTimelineConfigurator SetChapters(BlueprintCrusadeEventTimeline.ChapterInfo[]? chapters)
    {
      ValidateParam(chapters);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Chapters = chapters;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintCrusadeEventTimeline.Chapters"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CrusadeEventTimelineConfigurator AddToChapters(params BlueprintCrusadeEventTimeline.ChapterInfo[] chapters)
    {
      ValidateParam(chapters);
      return OnConfigureInternal(
          bp =>
          {
            bp.Chapters = CommonTool.Append(bp.Chapters, chapters ?? new BlueprintCrusadeEventTimeline.ChapterInfo[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintCrusadeEventTimeline.Chapters"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CrusadeEventTimelineConfigurator RemoveFromChapters(params BlueprintCrusadeEventTimeline.ChapterInfo[] chapters)
    {
      ValidateParam(chapters);
      return OnConfigureInternal(
          bp =>
          {
            bp.Chapters = bp.Chapters.Where(item => !chapters.Contains(item)).ToArray();
          });
    }
  }
}
