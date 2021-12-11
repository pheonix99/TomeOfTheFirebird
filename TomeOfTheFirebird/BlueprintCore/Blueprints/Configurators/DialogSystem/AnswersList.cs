using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem.Blueprints;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>
  /// Configurator for <see cref="BlueprintAnswersList"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintAnswersList))]
  public class AnswersListConfigurator : BaseAnswerBaseConfigurator<BlueprintAnswersList, AnswersListConfigurator>
  {
    private AnswersListConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AnswersListConfigurator For(string name)
    {
      return new AnswersListConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AnswersListConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintAnswersList>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAnswersList.ShowOnce"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AnswersListConfigurator SetShowOnce(bool showOnce)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ShowOnce = showOnce;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAnswersList.Conditions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AnswersListConfigurator SetConditions(ConditionsBuilder? conditions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAnswersList.Answers"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="answers"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintAnswerBase"/></param>
    [Generated]
    public AnswersListConfigurator SetAnswers(string[]? answers)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Answers = answers.Select(name => BlueprintTool.GetRef<BlueprintAnswerBaseReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintAnswersList.Answers"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="answers"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintAnswerBase"/></param>
    [Generated]
    public AnswersListConfigurator AddToAnswers(params string[] answers)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Answers.AddRange(answers.Select(name => BlueprintTool.GetRef<BlueprintAnswerBaseReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintAnswersList.Answers"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="answers"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintAnswerBase"/></param>
    [Generated]
    public AnswersListConfigurator RemoveFromAnswers(params string[] answers)
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
  }
}
