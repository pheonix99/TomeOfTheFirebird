using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Configurator for <see cref="BlueprintAiRunAway"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintAiRunAway))]
  public class AiRunAwayConfigurator : BaseAiActionConfigurator<BlueprintAiRunAway, AiRunAwayConfigurator>
  {
    private AiRunAwayConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AiRunAwayConfigurator For(string name)
    {
      return new AiRunAwayConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AiRunAwayConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintAiRunAway>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiRunAway.BecameStalker"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AiRunAwayConfigurator SetBecameStalker(bool becameStalker)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.BecameStalker = becameStalker;
          });
    }
  }
}
