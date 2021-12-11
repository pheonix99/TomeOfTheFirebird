using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom.Blueprints;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>
  /// Configurator for <see cref="BlueprintKingdomDeck"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintKingdomDeck))]
  public class KingdomDeckConfigurator : BaseBlueprintConfigurator<BlueprintKingdomDeck, KingdomDeckConfigurator>
  {
    private KingdomDeckConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static KingdomDeckConfigurator For(string name)
    {
      return new KingdomDeckConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static KingdomDeckConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintKingdomDeck>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomDeck.Events"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="events"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomEvent"/></param>
    [Generated]
    public KingdomDeckConfigurator SetEvents(string[]? events)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Events = events.Select(name => BlueprintTool.GetRef<BlueprintKingdomEventReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintKingdomDeck.Events"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="events"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomEvent"/></param>
    [Generated]
    public KingdomDeckConfigurator AddToEvents(params string[] events)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Events.AddRange(events.Select(name => BlueprintTool.GetRef<BlueprintKingdomEventReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintKingdomDeck.Events"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="events"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintKingdomEvent"/></param>
    [Generated]
    public KingdomDeckConfigurator RemoveFromEvents(params string[] events)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = events.Select(name => BlueprintTool.GetRef<BlueprintKingdomEventReference>(name));
            bp.Events =
                bp.Events
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomDeck.IsPriority"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomDeckConfigurator SetIsPriority(bool isPriority)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IsPriority = isPriority;
          });
    }
  }
}
