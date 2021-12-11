using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using UnityEngine;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Configurator for <see cref="BlueprintCompanionStory"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintCompanionStory))]
  public class CompanionStoryConfigurator : BaseBlueprintConfigurator<BlueprintCompanionStory, CompanionStoryConfigurator>
  {
    private CompanionStoryConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CompanionStoryConfigurator For(string name)
    {
      return new CompanionStoryConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CompanionStoryConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintCompanionStory>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCompanionStory.m_Companion"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="companion"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public CompanionStoryConfigurator SetCompanion(string? companion)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Companion = BlueprintTool.GetRef<BlueprintUnitReference>(companion);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCompanionStory.Title"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CompanionStoryConfigurator SetTitle(LocalizedString? title)
    {
      ValidateParam(title);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Title = title ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCompanionStory.Description"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CompanionStoryConfigurator SetDescription(LocalizedString? description)
    {
      ValidateParam(description);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Description = description ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCompanionStory.Image"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CompanionStoryConfigurator SetImage(Sprite image)
    {
      ValidateParam(image);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Image = image;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCompanionStory.Gender"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CompanionStoryConfigurator SetGender(Gender gender)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Gender = gender;
          });
    }
  }
}
