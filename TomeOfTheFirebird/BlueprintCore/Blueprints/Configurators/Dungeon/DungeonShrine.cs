using BlueprintCore.Blueprints.Configurators.RandomEncounters;
using BlueprintCore.Utils;
using Kingmaker.Dungeon.Blueprints;
using Kingmaker.ElementsSystem;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Dungeon
{
  /// <summary>
  /// Configurator for <see cref="BlueprintDungeonShrine"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintDungeonShrine))]
  public class DungeonShrineConfigurator : BaseSpawnableObjectConfigurator<BlueprintDungeonShrine, DungeonShrineConfigurator>
  {
    private DungeonShrineConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static DungeonShrineConfigurator For(string name)
    {
      return new DungeonShrineConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static DungeonShrineConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintDungeonShrine>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonShrine.UseCondition"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="useCondition"><see cref="Kingmaker.ElementsSystem.ConditionsHolder"/></param>
    [Generated]
    public DungeonShrineConfigurator SetUseCondition(string? useCondition)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.UseCondition = BlueprintTool.GetRef<ConditionsReference>(useCondition);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonShrine.CheckPassedActions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkPassedActions"><see cref="Kingmaker.ElementsSystem.ActionsHolder"/></param>
    [Generated]
    public DungeonShrineConfigurator SetCheckPassedActions(string? checkPassedActions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CheckPassedActions = BlueprintTool.GetRef<ActionsReference>(checkPassedActions);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonShrine.CheckFailedActions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkFailedActions"><see cref="Kingmaker.ElementsSystem.ActionsHolder"/></param>
    [Generated]
    public DungeonShrineConfigurator SetCheckFailedActions(string? checkFailedActions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CheckFailedActions = BlueprintTool.GetRef<ActionsReference>(checkFailedActions);
          });
    }
  }
}
