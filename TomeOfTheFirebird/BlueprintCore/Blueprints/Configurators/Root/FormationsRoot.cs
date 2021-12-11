using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Root;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Root
{
  /// <summary>
  /// Configurator for <see cref="FormationsRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(FormationsRoot))]
  public class FormationsRootConfigurator : BaseBlueprintConfigurator<FormationsRoot, FormationsRootConfigurator>
  {
    private FormationsRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static FormationsRootConfigurator For(string name)
    {
      return new FormationsRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static FormationsRootConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<FormationsRoot>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="FormationsRoot.m_PredefinedFormations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="predefinedFormations"><see cref="Kingmaker.Formations.BlueprintPartyFormation"/></param>
    [Generated]
    public FormationsRootConfigurator SetPredefinedFormations(string[]? predefinedFormations)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_PredefinedFormations = predefinedFormations.Select(name => BlueprintTool.GetRef<BlueprintPartyFormationReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="FormationsRoot.m_PredefinedFormations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="predefinedFormations"><see cref="Kingmaker.Formations.BlueprintPartyFormation"/></param>
    [Generated]
    public FormationsRootConfigurator AddToPredefinedFormations(params string[] predefinedFormations)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_PredefinedFormations = CommonTool.Append(bp.m_PredefinedFormations, predefinedFormations.Select(name => BlueprintTool.GetRef<BlueprintPartyFormationReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="FormationsRoot.m_PredefinedFormations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="predefinedFormations"><see cref="Kingmaker.Formations.BlueprintPartyFormation"/></param>
    [Generated]
    public FormationsRootConfigurator RemoveFromPredefinedFormations(params string[] predefinedFormations)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = predefinedFormations.Select(name => BlueprintTool.GetRef<BlueprintPartyFormationReference>(name));
            bp.m_PredefinedFormations =
                bp.m_PredefinedFormations
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="FormationsRoot.m_FollowersFormation"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="followersFormation"><see cref="Kingmaker.Formations.FollowersFormation"/></param>
    [Generated]
    public FormationsRootConfigurator SetFollowersFormation(string? followersFormation)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_FollowersFormation = BlueprintTool.GetRef<BlueprintFollowersFormationReference>(followersFormation);
          });
    }

    /// <summary>
    /// Sets <see cref="FormationsRoot.FormationsScale"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FormationsRootConfigurator SetFormationsScale(float formationsScale)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.FormationsScale = formationsScale;
          });
    }

    /// <summary>
    /// Sets <see cref="FormationsRoot.MinSpaceFactor"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FormationsRootConfigurator SetMinSpaceFactor(float minSpaceFactor)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MinSpaceFactor = minSpaceFactor;
          });
    }

    /// <summary>
    /// Sets <see cref="FormationsRoot.AutoFormation"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FormationsRootConfigurator SetAutoFormation(FormationsRoot.AutoFormationSettings autoFormation)
    {
      ValidateParam(autoFormation);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.AutoFormation = autoFormation;
          });
    }
  }
}
