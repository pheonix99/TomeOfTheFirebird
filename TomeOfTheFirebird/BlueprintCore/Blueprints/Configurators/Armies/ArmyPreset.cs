using BlueprintCore.Utils;
using Kingmaker.Armies.Blueprints;
using Kingmaker.Blueprints;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Armies
{
  /// <summary>
  /// Configurator for <see cref="BlueprintArmyPreset"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintArmyPreset))]
  public class ArmyPresetConfigurator : BaseBlueprintConfigurator<BlueprintArmyPreset, ArmyPresetConfigurator>
  {
    private ArmyPresetConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ArmyPresetConfigurator For(string name)
    {
      return new ArmyPresetConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ArmyPresetConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintArmyPreset>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmyPreset.Morale"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyPresetConfigurator SetMorale(int morale)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Morale = morale;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmyPreset.Squads"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyPresetConfigurator SetSquads(BlueprintArmyPreset.UnitAndCount[]? squads)
    {
      ValidateParam(squads);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Squads = squads;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintArmyPreset.Squads"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyPresetConfigurator AddToSquads(params BlueprintArmyPreset.UnitAndCount[] squads)
    {
      ValidateParam(squads);
      return OnConfigureInternal(
          bp =>
          {
            bp.Squads = CommonTool.Append(bp.Squads, squads ?? new BlueprintArmyPreset.UnitAndCount[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintArmyPreset.Squads"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyPresetConfigurator RemoveFromSquads(params BlueprintArmyPreset.UnitAndCount[] squads)
    {
      ValidateParam(squads);
      return OnConfigureInternal(
          bp =>
          {
            bp.Squads = bp.Squads.Where(item => !squads.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmyPreset.m_Leader"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="leader"><see cref="Kingmaker.Armies.BlueprintArmyLeader"/></param>
    [Generated]
    public ArmyPresetConfigurator SetLeader(string? leader)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Leader = BlueprintTool.GetRef<BlueprintArmyLeaderReference>(leader);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmyPreset.m_ArmyType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyPresetConfigurator SetArmyType(ArmyType armyType)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ArmyType = armyType;
          });
    }
  }
}
