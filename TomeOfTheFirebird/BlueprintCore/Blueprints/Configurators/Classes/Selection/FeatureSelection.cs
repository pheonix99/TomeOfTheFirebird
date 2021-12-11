using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using System;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Classes.Selection
{
  /// <summary>Configurator for <see cref="BlueprintFeatureSelection"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintFeatureSelection))]
  public class FeatureSelectionConfigurator
      : BaseFeatureConfigurator<BlueprintFeatureSelection, FeatureSelectionConfigurator>
  {
    private FeatureSelectionConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static FeatureSelectionConfigurator For(string name)
    {
      return new FeatureSelectionConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static FeatureSelectionConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintFeatureSelection>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintFeatureSelection.IgnorePrerequisites"/>
    /// </summary>
    public FeatureSelectionConfigurator SetIgnorePrerequisites(bool ignore = true)
    {
      return OnConfigureInternal(blueprint => blueprint.IgnorePrerequisites = ignore);
    }

    /// <summary>
    /// Sets <see cref="BlueprintFeatureSelection.Mode"/>
    /// </summary>
    public FeatureSelectionConfigurator SetMode(SelectionMode mode)
    {
      return OnConfigureInternal(blueprint => blueprint.Mode = mode);
    }

    /// <summary>
    /// Sets <see cref="BlueprintFeatureSelection.Group"/>
    /// </summary>
    public FeatureSelectionConfigurator SetPrimaryGroup(FeatureGroup group)
    {
      return OnConfigureInternal(blueprint => blueprint.Group = group);
    }

    /// <summary>
    /// Sets <see cref="BlueprintFeatureSelection.Group2"/>
    /// </summary>
    public FeatureSelectionConfigurator SetSecondaryGroup(FeatureGroup group)
    {
      return OnConfigureInternal(blueprint => blueprint.Group2 = group);
    }

    /// <summary>
    /// Sets <see cref="BlueprintFeatureSelection.m_AllFeatures"/>
    /// </summary>
    /// 
    /// <param name="features"><see cref="BlueprintFeature"/></param>
    public FeatureSelectionConfigurator SetFeatures(params string[] features)
    {
      return OnConfigureInternal(
          blueprint =>
              blueprint.m_AllFeatures =
                  features.Select(feature => BlueprintTool.GetRef<BlueprintFeatureReference>(feature)).ToArray());
    }

    /// <summary>
    /// Adds to <see cref="BlueprintFeatureSelection.m_AllFeatures"/>
    /// </summary>
    /// 
    /// <param name="features"><see cref="BlueprintFeature"/></param>
    public FeatureSelectionConfigurator AddToFeatures(params string[] features)
    {
      return OnConfigureInternal(
          blueprint =>
          {
            blueprint.m_AllFeatures =
                CommonTool.Append(
                    blueprint.m_AllFeatures,
                    features.Select(feature => BlueprintTool.GetRef<BlueprintFeatureReference>(feature)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintFeatureSelection.m_AllFeatures"/>
    /// </summary>
    /// 
    /// <param name="features"><see cref="BlueprintFeature"/></param>
    public FeatureSelectionConfigurator RemoveFromFeatures(params string[] features)
    {
      return OnConfigureInternal(
          blueprint =>
          {
            var featureRefs = features.Select(feature => BlueprintTool.GetRef<BlueprintFeatureReference>(feature));
            blueprint.m_AllFeatures = blueprint.m_AllFeatures.Except(featureRefs).ToArray();
          });
    }


    /// <summary>
    /// Adds <see cref="Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteSelectionPossible">PrerequisiteSelectionPossible</see>
    /// </summary>
    /// 
    /// <remarks>
    /// <para>
    /// A feature selection with this component only shows up if the character is eligible for at least one feature.
    /// This is useful when a character has access to different feature selections based on some criteria.
    /// </para>
    /// 
    /// <para>
    /// See ExpandedDefense and WildTalentBonusFeatAir3 blueprints for example usages.
    /// </para>
    /// </remarks>
    [Implements(typeof(PrerequisiteSelectionPossible))]
    public FeatureSelectionConfigurator PrerequisiteSelectionPossible(
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var selectionPossible = PrereqTool.Create<PrerequisiteSelectionPossible>(group, checkInProgression, hideInUI);
      selectionPossible.m_ThisFeature = Blueprint.ToReference<BlueprintFeatureSelectionReference>();
      return AddComponent(selectionPossible);
    }

    /// <summary>
    /// Adds <see cref="NoSelectionIfAlreadyHasFeature"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="features"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(NoSelectionIfAlreadyHasFeature))]
    public FeatureSelectionConfigurator AddNoSelectionIfAlreadyHasFeature(
        bool anyFeatureFromSelection = default,
        string[]? features = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new NoSelectionIfAlreadyHasFeature();
      component.AnyFeatureFromSelection = anyFeatureFromSelection;
      component.m_Features = features.Select(name => BlueprintTool.GetRef<BlueprintFeatureReference>(name)).ToArray();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }
  }
}
