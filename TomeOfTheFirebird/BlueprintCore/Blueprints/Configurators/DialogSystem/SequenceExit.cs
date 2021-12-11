using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem;
using Kingmaker.DialogSystem.Blueprints;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>
  /// Configurator for <see cref="BlueprintSequenceExit"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintSequenceExit))]
  public class SequenceExitConfigurator : BaseBlueprintConfigurator<BlueprintSequenceExit, SequenceExitConfigurator>
  {
    private SequenceExitConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static SequenceExitConfigurator For(string name)
    {
      return new SequenceExitConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static SequenceExitConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintSequenceExit>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintSequenceExit.Answers"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="answers"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintAnswerBase"/></param>
    [Generated]
    public SequenceExitConfigurator SetAnswers(string[]? answers)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Answers = answers.Select(name => BlueprintTool.GetRef<BlueprintAnswerBaseReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintSequenceExit.Answers"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="answers"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintAnswerBase"/></param>
    [Generated]
    public SequenceExitConfigurator AddToAnswers(params string[] answers)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Answers.AddRange(answers.Select(name => BlueprintTool.GetRef<BlueprintAnswerBaseReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintSequenceExit.Answers"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="answers"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintAnswerBase"/></param>
    [Generated]
    public SequenceExitConfigurator RemoveFromAnswers(params string[] answers)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = answers.Select(name => BlueprintTool.GetRef<BlueprintAnswerBaseReference>(name));
            bp.Answers =
                bp.Answers
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSequenceExit.Continue"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SequenceExitConfigurator SetContinue(CueSelection continueValue)
    {
      ValidateParam(continueValue);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Continue = continueValue;
          });
    }
  }
}
