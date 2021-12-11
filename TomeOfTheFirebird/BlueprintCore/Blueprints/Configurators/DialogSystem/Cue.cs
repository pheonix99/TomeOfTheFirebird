using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Alignments;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>
  /// Configurator for <see cref="BlueprintCue"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintCue))]
  public class CueConfigurator : BaseCueBaseConfigurator<BlueprintCue, CueConfigurator>
  {
    private CueConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CueConfigurator For(string name)
    {
      return new CueConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CueConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintCue>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCue.Text"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CueConfigurator SetText(LocalizedString? text)
    {
      ValidateParam(text);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Text = text ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCue.Experience"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CueConfigurator SetExperience(DialogExperience experience)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Experience = experience;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCue.Speaker"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CueConfigurator SetSpeaker(DialogSpeaker speaker)
    {
      ValidateParam(speaker);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Speaker = speaker;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCue.TurnSpeaker"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CueConfigurator SetTurnSpeaker(bool turnSpeaker)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.TurnSpeaker = turnSpeaker;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCue.Animation"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CueConfigurator SetAnimation(DialogAnimation animation)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Animation = animation;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCue.m_Listener"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="listener"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public CueConfigurator SetListener(string? listener)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Listener = BlueprintTool.GetRef<BlueprintUnitReference>(listener);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCue.OnShow"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CueConfigurator SetOnShow(ActionsBuilder? onShow)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.OnShow = onShow?.Build() ?? Constants.Empty.Actions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCue.OnStop"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CueConfigurator SetOnStop(ActionsBuilder? onStop)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.OnStop = onStop?.Build() ?? Constants.Empty.Actions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCue.AlignmentShift"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CueConfigurator SetAlignmentShift(AlignmentShift alignmentShift)
    {
      ValidateParam(alignmentShift);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.AlignmentShift = alignmentShift;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCue.Answers"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="answers"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintAnswerBase"/></param>
    [Generated]
    public CueConfigurator SetAnswers(string[]? answers)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Answers = answers.Select(name => BlueprintTool.GetRef<BlueprintAnswerBaseReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintCue.Answers"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="answers"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintAnswerBase"/></param>
    [Generated]
    public CueConfigurator AddToAnswers(params string[] answers)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Answers.AddRange(answers.Select(name => BlueprintTool.GetRef<BlueprintAnswerBaseReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintCue.Answers"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="answers"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintAnswerBase"/></param>
    [Generated]
    public CueConfigurator RemoveFromAnswers(params string[] answers)
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
    /// Sets <see cref="BlueprintCue.Continue"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CueConfigurator SetContinue(CueSelection continueValue)
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
