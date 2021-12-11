using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>
  /// Configurator for <see cref="BlueprintBookPage"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintBookPage))]
  public class BookPageConfigurator : BaseCueBaseConfigurator<BlueprintBookPage, BookPageConfigurator>
  {
    private BookPageConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static BookPageConfigurator For(string name)
    {
      return new BookPageConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static BookPageConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintBookPage>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintBookPage.Cues"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="cues"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintCueBase"/></param>
    [Generated]
    public BookPageConfigurator SetCues(string[]? cues)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Cues = cues.Select(name => BlueprintTool.GetRef<BlueprintCueBaseReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintBookPage.Cues"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="cues"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintCueBase"/></param>
    [Generated]
    public BookPageConfigurator AddToCues(params string[] cues)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Cues.AddRange(cues.Select(name => BlueprintTool.GetRef<BlueprintCueBaseReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintBookPage.Cues"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="cues"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintCueBase"/></param>
    [Generated]
    public BookPageConfigurator RemoveFromCues(params string[] cues)
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
    /// Sets <see cref="BlueprintBookPage.Answers"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="answers"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintAnswerBase"/></param>
    [Generated]
    public BookPageConfigurator SetAnswers(string[]? answers)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Answers = answers.Select(name => BlueprintTool.GetRef<BlueprintAnswerBaseReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintBookPage.Answers"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="answers"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintAnswerBase"/></param>
    [Generated]
    public BookPageConfigurator AddToAnswers(params string[] answers)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Answers.AddRange(answers.Select(name => BlueprintTool.GetRef<BlueprintAnswerBaseReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintBookPage.Answers"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="answers"><see cref="Kingmaker.DialogSystem.Blueprints.BlueprintAnswerBase"/></param>
    [Generated]
    public BookPageConfigurator RemoveFromAnswers(params string[] answers)
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
    /// Sets <see cref="BlueprintBookPage.OnShow"/> (Auto Generated)
    /// </summary>
    [Generated]
    public BookPageConfigurator SetOnShow(ActionsBuilder? onShow)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.OnShow = onShow?.Build() ?? Constants.Empty.Actions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintBookPage.ImageLink"/> (Auto Generated)
    /// </summary>
    [Generated]
    public BookPageConfigurator SetImageLink(SpriteLink imageLink)
    {
      ValidateParam(imageLink);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.ImageLink = imageLink;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintBookPage.ForeImageLink"/> (Auto Generated)
    /// </summary>
    [Generated]
    public BookPageConfigurator SetForeImageLink(SpriteLink foreImageLink)
    {
      ValidateParam(foreImageLink);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.ForeImageLink = foreImageLink;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintBookPage.Title"/> (Auto Generated)
    /// </summary>
    [Generated]
    public BookPageConfigurator SetTitle(LocalizedString? title)
    {
      ValidateParam(title);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Title = title ?? Constants.Empty.String;
          });
    }
  }
}
