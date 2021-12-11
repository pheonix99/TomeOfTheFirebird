using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Configurator for <see cref="FactConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(FactConsideration))]
  public class FactConsiderationConfigurator : BaseConsiderationConfigurator<FactConsideration, FactConsiderationConfigurator>
  {
    private FactConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static FactConsiderationConfigurator For(string name)
    {
      return new FactConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static FactConsiderationConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<FactConsideration>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="FactConsideration.m_Fact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="fact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    public FactConsiderationConfigurator SetFact(string[]? fact)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Fact = fact.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="FactConsideration.m_Fact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="fact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    public FactConsiderationConfigurator AddToFact(params string[] fact)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Fact = CommonTool.Append(bp.m_Fact, fact.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="FactConsideration.m_Fact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="fact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    [Generated]
    public FactConsiderationConfigurator RemoveFromFact(params string[] fact)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = fact.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name));
            bp.m_Fact =
                bp.m_Fact
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="FactConsideration.HasFactScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FactConsiderationConfigurator SetHasFactScore(float hasFactScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.HasFactScore = hasFactScore;
          });
    }

    /// <summary>
    /// Sets <see cref="FactConsideration.NoFactScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FactConsiderationConfigurator SetNoFactScore(float noFactScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.NoFactScore = noFactScore;
          });
    }
  }
}
