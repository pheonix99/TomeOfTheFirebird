using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.DialogSystem.Blueprints;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintCueBase"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintCueBase))]
  public abstract class BaseCueBaseConfigurator<T, TBuilder>
      : BaseBlueprintConfigurator<T, TBuilder>
      where T : BlueprintCueBase
      where TBuilder : BaseCueBaseConfigurator<T, TBuilder>
  {
    protected BaseCueBaseConfigurator(string name) : base(name) { }

    /// <summary>
    /// Sets <see cref="BlueprintCueBase.ShowOnce"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetShowOnce(bool showOnce)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ShowOnce = showOnce;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCueBase.ShowOnceCurrentDialog"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetShowOnceCurrentDialog(bool showOnceCurrentDialog)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ShowOnceCurrentDialog = showOnceCurrentDialog;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCueBase.Conditions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetConditions(ConditionsBuilder? conditions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
          });
    }
  }
}
