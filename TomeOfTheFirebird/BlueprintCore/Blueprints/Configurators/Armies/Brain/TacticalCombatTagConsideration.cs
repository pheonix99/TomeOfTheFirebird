using BlueprintCore.Blueprints.Configurators.AI;
using BlueprintCore.Utils;
using Kingmaker.Armies.Components;
using Kingmaker.Armies.TacticalCombat.Brain.Considerations;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Armies.Brain
{
  /// <summary>
  /// Configurator for <see cref="TacticalCombatTagConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(TacticalCombatTagConsideration))]
  public class TacticalCombatTagConsiderationConfigurator : BaseConsiderationConfigurator<TacticalCombatTagConsideration, TacticalCombatTagConsiderationConfigurator>
  {
    private TacticalCombatTagConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static TacticalCombatTagConsiderationConfigurator For(string name)
    {
      return new TacticalCombatTagConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static TacticalCombatTagConsiderationConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<TacticalCombatTagConsideration>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="TacticalCombatTagConsideration.HasTagScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatTagConsiderationConfigurator SetHasTagScore(float hasTagScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.HasTagScore = hasTagScore;
          });
    }

    /// <summary>
    /// Sets <see cref="TacticalCombatTagConsideration.DoesNotHaveTagScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatTagConsiderationConfigurator SetDoesNotHaveTagScore(float doesNotHaveTagScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DoesNotHaveTagScore = doesNotHaveTagScore;
          });
    }

    /// <summary>
    /// Sets <see cref="TacticalCombatTagConsideration.Tag"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatTagConsiderationConfigurator SetTag(ArmyProperties tag)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Tag = tag;
          });
    }

    /// <summary>
    /// Sets <see cref="TacticalCombatTagConsideration.ShouldHaveAllTags"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatTagConsiderationConfigurator SetShouldHaveAllTags(bool shouldHaveAllTags)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ShouldHaveAllTags = shouldHaveAllTags;
          });
    }
  }
}
