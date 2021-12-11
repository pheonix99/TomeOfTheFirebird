using BlueprintCore.Utils;
using Kingmaker.Kingdom.Blueprints;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>
  /// Configurator for <see cref="BlueprintKingdomEventTimeline"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintKingdomEventTimeline))]
  public class KingdomEventTimelineConfigurator : BaseBlueprintConfigurator<BlueprintKingdomEventTimeline, KingdomEventTimelineConfigurator>
  {
    private KingdomEventTimelineConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static KingdomEventTimelineConfigurator For(string name)
    {
      return new KingdomEventTimelineConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static KingdomEventTimelineConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintKingdomEventTimeline>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomEventTimeline.Entries"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomEventTimelineConfigurator SetEntries(BlueprintKingdomEventTimeline.EntryList entries)
    {
      ValidateParam(entries);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Entries = entries;
          });
    }
  }
}
