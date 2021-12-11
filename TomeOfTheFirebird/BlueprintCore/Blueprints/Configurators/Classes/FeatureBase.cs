using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers.Mechanics.Facts;
using System;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintFeatureBase"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintFeatureBase))]
  public abstract class FeatureBaseConfigurator<T, TBuilder> : BaseUnitFactConfigurator<T, TBuilder>
      where T : BlueprintFeatureBase
      where TBuilder : FeatureBaseConfigurator<T, TBuilder>
  {
    protected FeatureBaseConfigurator(string name) : base(name) { }

#pragma warning disable CS1574 // XML comment has cref attribute that could not be resolved
    /// <summary>
    /// Sets <see cref="BlueprintFeatureBase.HideInUi"/>
    /// </summary>
    public TBuilder SetHideInUi(bool hide = true)
#pragma warning restore CS1574 // XML comment has cref attribute that could not be resolved
    {
      return OnConfigureInternal(blueprint => blueprint.HideInUI = hide);
    }

    /// <summary>
    /// Sets <see cref="BlueprintFeatureBase.HideInCharacterSheetAndLevelUp"/>
    /// </summary>
    public TBuilder SetHideInCharacterSheetAndLevelUp(bool hide = true)
    {
      return OnConfigureInternal(blueprint => blueprint.HideInCharacterSheetAndLevelUp = hide);
    }

    /// <summary>
    /// Sets <see cref="BlueprintFeatureBase.HideNotAvailibleInUI"/>
    /// </summary>
    public TBuilder SetHideNotAvailableInUI(bool hide = true)
    {
      return OnConfigureInternal(blueprint => blueprint.HideNotAvailibleInUI = hide);
    }


    /// <summary>
    /// Sets the contents of <see cref="FeatureTagsComponent"/>
    /// </summary>
    [Implements(typeof(FeatureTagsComponent))]
    public TBuilder SetFeatureTags(params FeatureTag[] tags)
    {
      return OnConfigureInternal(
          bp =>
          {
            var component = bp.GetComponent<FeatureTagsComponent>();
            if (component == null)
            {
              component = new FeatureTagsComponent();
              bp.AddComponents(component);
            }
            component.FeatureTags = 0;
            tags.ToList().ForEach(t => component.FeatureTags |= t);
          });
    }

    /// <summary>
    /// Adds to <see cref="FeatureTagsComponent"/>
    /// </summary>
    [Implements(typeof(FeatureTagsComponent))]
    public TBuilder AddToFeatureTags(params FeatureTag[] tags)
    {
      return OnConfigureInternal(
          bp =>
          {
            var component = bp.GetComponent<FeatureTagsComponent>();
            if (component == null)
            {
              component = new FeatureTagsComponent();
              bp.AddComponents(component);
            }
            tags.ToList().ForEach(t => component.FeatureTags |= t);
          });
    }

    /// <summary>
    /// Removes from <see cref="FeatureTagsComponent"/>
    /// </summary>
    [Implements(typeof(FeatureTagsComponent))]
    public TBuilder RemoveFromFeatureTags(params FeatureTag[] tags)
    {
      return OnConfigureInternal(
          bp =>
          {
            var component = bp.GetComponent<FeatureTagsComponent>();
            if (component == null) { return; }
            tags.ToList().ForEach(t => component.FeatureTags &= ~t);
          });
    }

    /// <summary>
    /// Adds <see cref="HideFeatureInInspect"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(HideFeatureInInspect))]
    public TBuilder AddHideFeatureInInspect(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new HideFeatureInInspect();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }
  }
}
