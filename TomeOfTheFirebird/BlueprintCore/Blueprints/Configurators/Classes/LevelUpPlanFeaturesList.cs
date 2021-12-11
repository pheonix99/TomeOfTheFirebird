using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>
  /// Configurator for <see cref="BlueprintLevelUpPlanFeaturesList"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintLevelUpPlanFeaturesList))]
  public class LevelUpPlanFeaturesListConfigurator : BaseFeatureConfigurator<BlueprintLevelUpPlanFeaturesList, LevelUpPlanFeaturesListConfigurator>
  {
    private LevelUpPlanFeaturesListConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static LevelUpPlanFeaturesListConfigurator For(string name)
    {
      return new LevelUpPlanFeaturesListConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static LevelUpPlanFeaturesListConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintLevelUpPlanFeaturesList>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintLevelUpPlanFeaturesList.Features"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LevelUpPlanFeaturesListConfigurator SetFeatures(BlueprintLevelUpPlanFeaturesList.FeatureWrapper[]? features)
    {
      ValidateParam(features);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Features = features;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintLevelUpPlanFeaturesList.Features"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LevelUpPlanFeaturesListConfigurator AddToFeatures(params BlueprintLevelUpPlanFeaturesList.FeatureWrapper[] features)
    {
      ValidateParam(features);
      return OnConfigureInternal(
          bp =>
          {
            bp.Features = CommonTool.Append(bp.Features, features ?? new BlueprintLevelUpPlanFeaturesList.FeatureWrapper[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintLevelUpPlanFeaturesList.Features"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LevelUpPlanFeaturesListConfigurator RemoveFromFeatures(params BlueprintLevelUpPlanFeaturesList.FeatureWrapper[] features)
    {
      ValidateParam(features);
      return OnConfigureInternal(
          bp =>
          {
            bp.Features = bp.Features.Where(item => !features.Contains(item)).ToArray();
          });
    }
  }
}
