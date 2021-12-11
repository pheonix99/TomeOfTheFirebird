using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints;
using Kingmaker.AI.Blueprints.Considerations;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Configurator for <see cref="CustomAiConsiderationsRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(CustomAiConsiderationsRoot))]
  public class CustomAiConsiderationsRootConfigurator : BaseBlueprintConfigurator<CustomAiConsiderationsRoot, CustomAiConsiderationsRootConfigurator>
  {
    private CustomAiConsiderationsRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CustomAiConsiderationsRootConfigurator For(string name)
    {
      return new CustomAiConsiderationsRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CustomAiConsiderationsRootConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<CustomAiConsiderationsRoot>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="CustomAiConsiderationsRoot.m_TargetConsiderations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="targetConsiderations"><see cref="Kingmaker.AI.Blueprints.Considerations.ConsiderationCustom"/></param>
    [Generated]
    public CustomAiConsiderationsRootConfigurator SetTargetConsiderations(string[]? targetConsiderations)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_TargetConsiderations = targetConsiderations.Select(name => BlueprintTool.GetRef<ConsiderationCustom.Reference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="CustomAiConsiderationsRoot.m_TargetConsiderations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="targetConsiderations"><see cref="Kingmaker.AI.Blueprints.Considerations.ConsiderationCustom"/></param>
    [Generated]
    public CustomAiConsiderationsRootConfigurator AddToTargetConsiderations(params string[] targetConsiderations)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_TargetConsiderations = CommonTool.Append(bp.m_TargetConsiderations, targetConsiderations.Select(name => BlueprintTool.GetRef<ConsiderationCustom.Reference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="CustomAiConsiderationsRoot.m_TargetConsiderations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="targetConsiderations"><see cref="Kingmaker.AI.Blueprints.Considerations.ConsiderationCustom"/></param>
    [Generated]
    public CustomAiConsiderationsRootConfigurator RemoveFromTargetConsiderations(params string[] targetConsiderations)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = targetConsiderations.Select(name => BlueprintTool.GetRef<ConsiderationCustom.Reference>(name));
            bp.m_TargetConsiderations =
                bp.m_TargetConsiderations
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="CustomAiConsiderationsRoot.m_ActorConsiderations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="actorConsiderations"><see cref="Kingmaker.AI.Blueprints.Considerations.ConsiderationCustom"/></param>
    [Generated]
    public CustomAiConsiderationsRootConfigurator SetActorConsiderations(string[]? actorConsiderations)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ActorConsiderations = actorConsiderations.Select(name => BlueprintTool.GetRef<ConsiderationCustom.Reference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="CustomAiConsiderationsRoot.m_ActorConsiderations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="actorConsiderations"><see cref="Kingmaker.AI.Blueprints.Considerations.ConsiderationCustom"/></param>
    [Generated]
    public CustomAiConsiderationsRootConfigurator AddToActorConsiderations(params string[] actorConsiderations)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ActorConsiderations = CommonTool.Append(bp.m_ActorConsiderations, actorConsiderations.Select(name => BlueprintTool.GetRef<ConsiderationCustom.Reference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="CustomAiConsiderationsRoot.m_ActorConsiderations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="actorConsiderations"><see cref="Kingmaker.AI.Blueprints.Considerations.ConsiderationCustom"/></param>
    [Generated]
    public CustomAiConsiderationsRootConfigurator RemoveFromActorConsiderations(params string[] actorConsiderations)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = actorConsiderations.Select(name => BlueprintTool.GetRef<ConsiderationCustom.Reference>(name));
            bp.m_ActorConsiderations =
                bp.m_ActorConsiderations
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }
  }
}
