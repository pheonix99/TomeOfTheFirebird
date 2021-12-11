using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Configurator for <see cref="BuffNotFromCasterConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BuffNotFromCasterConsideration))]
  public class BuffNotFromCasterConsiderationConfigurator : BaseConsiderationConfigurator<BuffNotFromCasterConsideration, BuffNotFromCasterConsiderationConfigurator>
  {
    private BuffNotFromCasterConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static BuffNotFromCasterConsiderationConfigurator For(string name)
    {
      return new BuffNotFromCasterConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static BuffNotFromCasterConsiderationConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BuffNotFromCasterConsideration>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BuffNotFromCasterConsideration.m_Buffs"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buffs"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    [Generated]
    public BuffNotFromCasterConsiderationConfigurator SetBuffs(string[]? buffs)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Buffs = buffs.Select(name => BlueprintTool.GetRef<BlueprintBuffReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BuffNotFromCasterConsideration.m_Buffs"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buffs"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    [Generated]
    public BuffNotFromCasterConsiderationConfigurator AddToBuffs(params string[] buffs)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Buffs = CommonTool.Append(bp.m_Buffs, buffs.Select(name => BlueprintTool.GetRef<BlueprintBuffReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BuffNotFromCasterConsideration.m_Buffs"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buffs"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    [Generated]
    public BuffNotFromCasterConsiderationConfigurator RemoveFromBuffs(params string[] buffs)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = buffs.Select(name => BlueprintTool.GetRef<BlueprintBuffReference>(name));
            bp.m_Buffs =
                bp.m_Buffs
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BuffNotFromCasterConsideration.HasBuffNotFromCasterScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public BuffNotFromCasterConsiderationConfigurator SetHasBuffNotFromCasterScore(float hasBuffNotFromCasterScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.HasBuffNotFromCasterScore = hasBuffNotFromCasterScore;
          });
    }

    /// <summary>
    /// Sets <see cref="BuffNotFromCasterConsideration.ElseScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public BuffNotFromCasterConsiderationConfigurator SetElseScore(float elseScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ElseScore = elseScore;
          });
    }
  }
}
