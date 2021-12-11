using BlueprintCore.Utils;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.Enums;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintAnswerBase"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintAnswerBase))]
  public abstract class BaseAnswerBaseConfigurator<T, TBuilder>
      : BaseBlueprintConfigurator<T, TBuilder>
      where T : BlueprintAnswerBase
      where TBuilder : BaseAnswerBaseConfigurator<T, TBuilder>
  {
    protected BaseAnswerBaseConfigurator(string name) : base(name) { }

    /// <summary>
    /// Sets <see cref="BlueprintAnswerBase.MythicRequirement"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetMythicRequirement(Mythic mythicRequirement)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MythicRequirement = mythicRequirement;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAnswerBase.AlignmentRequirement"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetAlignmentRequirement(AlignmentComponent alignmentRequirement)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AlignmentRequirement = alignmentRequirement;
          });
    }
  }
}
