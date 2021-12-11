using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>
  /// Configurator for <see cref="BlueprintStatProgression"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintStatProgression))]
  public class StatProgressionConfigurator : BaseBlueprintConfigurator<BlueprintStatProgression, StatProgressionConfigurator>
  {
    private StatProgressionConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static StatProgressionConfigurator For(string name)
    {
      return new StatProgressionConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static StatProgressionConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintStatProgression>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintStatProgression.Bonuses"/> (Auto Generated)
    /// </summary>
    [Generated]
    public StatProgressionConfigurator SetBonuses(int[]? bonuses)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Bonuses = bonuses;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintStatProgression.Bonuses"/> (Auto Generated)
    /// </summary>
    [Generated]
    public StatProgressionConfigurator AddToBonuses(params int[] bonuses)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Bonuses = CommonTool.Append(bp.Bonuses, bonuses ?? new int[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintStatProgression.Bonuses"/> (Auto Generated)
    /// </summary>
    [Generated]
    public StatProgressionConfigurator RemoveFromBonuses(params int[] bonuses)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Bonuses = bp.Bonuses.Where(item => !bonuses.Contains(item)).ToArray();
          });
    }
  }
}
