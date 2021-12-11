using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Configurator for <see cref="NotImpatientConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(NotImpatientConsideration))]
  public class NotImpatientConsiderationConfigurator : BaseConsiderationConfigurator<NotImpatientConsideration, NotImpatientConsiderationConfigurator>
  {
    private NotImpatientConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static NotImpatientConsiderationConfigurator For(string name)
    {
      return new NotImpatientConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static NotImpatientConsiderationConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<NotImpatientConsideration>(name, guid);
      return For(name);
    }
  }
}
