using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Configurator for <see cref="SpecificUnitBlueprintConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(SpecificUnitBlueprintConsideration))]
  public class SpecificUnitConsiderationConfigurator : BaseConsiderationConfigurator<SpecificUnitBlueprintConsideration, SpecificUnitConsiderationConfigurator>
  {
    private SpecificUnitConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static SpecificUnitConsiderationConfigurator For(string name)
    {
      return new SpecificUnitConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static SpecificUnitConsiderationConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<SpecificUnitBlueprintConsideration>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="SpecificUnitBlueprintConsideration.m_Unit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="unit"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public SpecificUnitConsiderationConfigurator SetUnit(string? unit)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(unit);
          });
    }

    /// <summary>
    /// Sets <see cref="SpecificUnitBlueprintConsideration.CorrectUnitScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpecificUnitConsiderationConfigurator SetCorrectUnitScore(float correctUnitScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CorrectUnitScore = correctUnitScore;
          });
    }

    /// <summary>
    /// Sets <see cref="SpecificUnitBlueprintConsideration.IncorrectUnitScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpecificUnitConsiderationConfigurator SetIncorrectUnitScore(float incorrectUnitScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IncorrectUnitScore = incorrectUnitScore;
          });
    }
  }
}
