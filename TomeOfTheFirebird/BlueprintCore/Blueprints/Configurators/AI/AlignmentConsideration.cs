using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Enums;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Configurator for <see cref="AlignmentConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(AlignmentConsideration))]
  public class AlignmentConsiderationConfigurator : BaseConsiderationConfigurator<AlignmentConsideration, AlignmentConsiderationConfigurator>
  {
    private AlignmentConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AlignmentConsiderationConfigurator For(string name)
    {
      return new AlignmentConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AlignmentConsiderationConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<AlignmentConsideration>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="AlignmentConsideration.Alignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AlignmentConsiderationConfigurator SetAlignment(AlignmentComponent alignment)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Alignment = alignment;
          });
    }

    /// <summary>
    /// Sets <see cref="AlignmentConsideration.SpecifiedAlignmentScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AlignmentConsiderationConfigurator SetSpecifiedAlignmentScore(float specifiedAlignmentScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.SpecifiedAlignmentScore = specifiedAlignmentScore;
          });
    }

    /// <summary>
    /// Sets <see cref="AlignmentConsideration.OtherAlignmentScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AlignmentConsiderationConfigurator SetOtherAlignmentScore(float otherAlignmentScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.OtherAlignmentScore = otherAlignmentScore;
          });
    }
  }
}
