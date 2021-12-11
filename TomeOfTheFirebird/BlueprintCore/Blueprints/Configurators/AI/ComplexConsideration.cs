using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Configurator for <see cref="ComplexConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(ComplexConsideration))]
  public class ComplexConsiderationConfigurator : BaseConsiderationConfigurator<ComplexConsideration, ComplexConsiderationConfigurator>
  {
    private ComplexConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ComplexConsiderationConfigurator For(string name)
    {
      return new ComplexConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ComplexConsiderationConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<ComplexConsideration>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="ComplexConsideration.m_Considerations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="considerations"><see cref="Kingmaker.AI.Blueprints.Considerations.Consideration"/></param>
    [Generated]
    public ComplexConsiderationConfigurator SetConsiderations(string[]? considerations)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Considerations = considerations.Select(name => BlueprintTool.GetRef<ConsiderationReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="ComplexConsideration.m_Considerations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="considerations"><see cref="Kingmaker.AI.Blueprints.Considerations.Consideration"/></param>
    [Generated]
    public ComplexConsiderationConfigurator AddToConsiderations(params string[] considerations)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Considerations = CommonTool.Append(bp.m_Considerations, considerations.Select(name => BlueprintTool.GetRef<ConsiderationReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="ComplexConsideration.m_Considerations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="considerations"><see cref="Kingmaker.AI.Blueprints.Considerations.Consideration"/></param>
    [Generated]
    public ComplexConsiderationConfigurator RemoveFromConsiderations(params string[] considerations)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = considerations.Select(name => BlueprintTool.GetRef<ConsiderationReference>(name));
            bp.m_Considerations =
                bp.m_Considerations
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }
  }
}
