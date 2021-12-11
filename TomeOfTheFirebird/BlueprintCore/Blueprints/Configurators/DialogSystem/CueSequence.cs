using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem.Blueprints;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>
  /// Configurator for <see cref="BlueprintCueSequence"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintCueSequence))]
  public class CueSequenceConfigurator : BaseCueBaseConfigurator<BlueprintCueSequence, CueSequenceConfigurator>
  {
    private CueSequenceConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CueSequenceConfigurator For(string name)
    {
      return new CueSequenceConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CueSequenceConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintCueSequence>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCueSequence.Cues"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="cues"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintCueBase"/></param>
    [Generated]
    public CueSequenceConfigurator SetCues(string[]? cues)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Cues = cues.Select(name => BlueprintTool.GetRef<BlueprintCueBaseReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintCueSequence.Cues"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="cues"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintCueBase"/></param>
    [Generated]
    public CueSequenceConfigurator AddToCues(params string[] cues)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Cues.AddRange(cues.Select(name => BlueprintTool.GetRef<BlueprintCueBaseReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintCueSequence.Cues"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="cues"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintCueBase"/></param>
    [Generated]
    public CueSequenceConfigurator RemoveFromCues(params string[] cues)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = cues.Select(name => BlueprintTool.GetRef<BlueprintCueBaseReference>(name));
            bp.Cues =
                bp.Cues
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCueSequence.m_Exit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="exit"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintSequenceExit"/></param>
    [Generated]
    public CueSequenceConfigurator SetExit(string? exit)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Exit = BlueprintTool.GetRef<BlueprintSequenceExitReference>(exit);
          });
    }
  }
}
