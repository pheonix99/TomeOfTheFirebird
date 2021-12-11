using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Configurator for <see cref="TargetMainCharacter"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(TargetMainCharacter))]
  public class TargetMainCharacterConfigurator : BaseConsiderationConfigurator<TargetMainCharacter, TargetMainCharacterConfigurator>
  {
    private TargetMainCharacterConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static TargetMainCharacterConfigurator For(string name)
    {
      return new TargetMainCharacterConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static TargetMainCharacterConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<TargetMainCharacter>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="TargetMainCharacter.IsMainCharacterScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TargetMainCharacterConfigurator SetIsMainCharacterScore(float isMainCharacterScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IsMainCharacterScore = isMainCharacterScore;
          });
    }

    /// <summary>
    /// Sets <see cref="TargetMainCharacter.OthersScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TargetMainCharacterConfigurator SetOthersScore(float othersScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.OthersScore = othersScore;
          });
    }
  }
}
