using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Configurator for <see cref="TargetClassConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(TargetClassConsideration))]
  public class TargetClassConsiderationConfigurator : BaseConsiderationConfigurator<TargetClassConsideration, TargetClassConsiderationConfigurator>
  {
    private TargetClassConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static TargetClassConsiderationConfigurator For(string name)
    {
      return new TargetClassConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static TargetClassConsiderationConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<TargetClassConsideration>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="TargetClassConsideration.m_FirstPriorityClasses"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="firstPriorityClasses"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    [Generated]
    public TargetClassConsiderationConfigurator SetFirstPriorityClasses(string[]? firstPriorityClasses)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_FirstPriorityClasses = firstPriorityClasses.Select(name => BlueprintTool.GetRef<BlueprintCharacterClassReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="TargetClassConsideration.m_FirstPriorityClasses"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="firstPriorityClasses"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    [Generated]
    public TargetClassConsiderationConfigurator AddToFirstPriorityClasses(params string[] firstPriorityClasses)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_FirstPriorityClasses = CommonTool.Append(bp.m_FirstPriorityClasses, firstPriorityClasses.Select(name => BlueprintTool.GetRef<BlueprintCharacterClassReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="TargetClassConsideration.m_FirstPriorityClasses"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="firstPriorityClasses"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    [Generated]
    public TargetClassConsiderationConfigurator RemoveFromFirstPriorityClasses(params string[] firstPriorityClasses)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = firstPriorityClasses.Select(name => BlueprintTool.GetRef<BlueprintCharacterClassReference>(name));
            bp.m_FirstPriorityClasses =
                bp.m_FirstPriorityClasses
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="TargetClassConsideration.FirstPriorityScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TargetClassConsiderationConfigurator SetFirstPriorityScore(float firstPriorityScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.FirstPriorityScore = firstPriorityScore;
          });
    }

    /// <summary>
    /// Sets <see cref="TargetClassConsideration.m_SecondPriorityClasses"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="secondPriorityClasses"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    [Generated]
    public TargetClassConsiderationConfigurator SetSecondPriorityClasses(string[]? secondPriorityClasses)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_SecondPriorityClasses = secondPriorityClasses.Select(name => BlueprintTool.GetRef<BlueprintCharacterClassReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="TargetClassConsideration.m_SecondPriorityClasses"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="secondPriorityClasses"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    [Generated]
    public TargetClassConsiderationConfigurator AddToSecondPriorityClasses(params string[] secondPriorityClasses)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_SecondPriorityClasses = CommonTool.Append(bp.m_SecondPriorityClasses, secondPriorityClasses.Select(name => BlueprintTool.GetRef<BlueprintCharacterClassReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="TargetClassConsideration.m_SecondPriorityClasses"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="secondPriorityClasses"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    [Generated]
    public TargetClassConsiderationConfigurator RemoveFromSecondPriorityClasses(params string[] secondPriorityClasses)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = secondPriorityClasses.Select(name => BlueprintTool.GetRef<BlueprintCharacterClassReference>(name));
            bp.m_SecondPriorityClasses =
                bp.m_SecondPriorityClasses
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="TargetClassConsideration.SecondPriorityScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TargetClassConsiderationConfigurator SetSecondPriorityScore(float secondPriorityScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.SecondPriorityScore = secondPriorityScore;
          });
    }

    /// <summary>
    /// Sets <see cref="TargetClassConsideration.NoPriorityScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TargetClassConsiderationConfigurator SetNoPriorityScore(float noPriorityScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.NoPriorityScore = noPriorityScore;
          });
    }
  }
}
