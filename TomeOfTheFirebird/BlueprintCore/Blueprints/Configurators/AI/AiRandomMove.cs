using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Configurator for <see cref="BlueprintAiRandomMove"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintAiRandomMove))]
  public class AiRandomMoveConfigurator : BaseAiActionConfigurator<BlueprintAiRandomMove, AiRandomMoveConfigurator>
  {
    private AiRandomMoveConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AiRandomMoveConfigurator For(string name)
    {
      return new AiRandomMoveConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AiRandomMoveConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintAiRandomMove>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiRandomMove.RoamingRadiusInFeet"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AiRandomMoveConfigurator SetRoamingRadiusInFeet(int roamingRadiusInFeet)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.RoamingRadiusInFeet = roamingRadiusInFeet;
          });
    }
  }
}
