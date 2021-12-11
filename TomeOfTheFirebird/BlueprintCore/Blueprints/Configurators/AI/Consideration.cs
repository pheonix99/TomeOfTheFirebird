using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="Consideration"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(Consideration))]
  public abstract class BaseConsiderationConfigurator<T, TBuilder>
      : BaseBlueprintConfigurator<T, TBuilder>
      where T : Consideration
      where TBuilder : BaseConsiderationConfigurator<T, TBuilder>
  {
    protected BaseConsiderationConfigurator(string name) : base(name) { }

    /// <summary>
    /// Sets <see cref="Consideration.BaseScoreModifier"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetBaseScoreModifier(float baseScoreModifier)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.BaseScoreModifier = baseScoreModifier;
          });
    }
  }
}
