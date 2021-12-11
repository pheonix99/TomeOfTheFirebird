using BlueprintCore.Utils;
using Kingmaker.UnitLogic.Customization;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.UnitLogic.Customization
{
  /// <summary>
  /// Configurator for <see cref="RaceGenderDistribution"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(RaceGenderDistribution))]
  public class RaceGenderDistributionConfigurator : BaseBlueprintConfigurator<RaceGenderDistribution, RaceGenderDistributionConfigurator>
  {
    private RaceGenderDistributionConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static RaceGenderDistributionConfigurator For(string name)
    {
      return new RaceGenderDistributionConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static RaceGenderDistributionConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<RaceGenderDistribution>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="RaceGenderDistribution.Races"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RaceGenderDistributionConfigurator SetRaces(RaceEntry[]? races)
    {
      ValidateParam(races);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Races = races;
          });
    }

    /// <summary>
    /// Adds to <see cref="RaceGenderDistribution.Races"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RaceGenderDistributionConfigurator AddToRaces(params RaceEntry[] races)
    {
      ValidateParam(races);
      return OnConfigureInternal(
          bp =>
          {
            bp.Races = CommonTool.Append(bp.Races, races ?? new RaceEntry[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="RaceGenderDistribution.Races"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RaceGenderDistributionConfigurator RemoveFromRaces(params RaceEntry[] races)
    {
      ValidateParam(races);
      return OnConfigureInternal(
          bp =>
          {
            bp.Races = bp.Races.Where(item => !races.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="RaceGenderDistribution.LeftHandedChance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RaceGenderDistributionConfigurator SetLeftHandedChance(float leftHandedChance)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.LeftHandedChance = leftHandedChance;
          });
    }

    /// <summary>
    /// Sets <see cref="RaceGenderDistribution.MaleBaseWeight"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RaceGenderDistributionConfigurator SetMaleBaseWeight(float maleBaseWeight)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MaleBaseWeight = maleBaseWeight;
          });
    }

    /// <summary>
    /// Sets <see cref="RaceGenderDistribution.FemaleBaseWeight"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RaceGenderDistributionConfigurator SetFemaleBaseWeight(float femaleBaseWeight)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.FemaleBaseWeight = femaleBaseWeight;
          });
    }
  }
}
