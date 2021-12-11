using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Configurator for <see cref="BuffsAroundConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BuffsAroundConsideration))]
  public class BuffsAroundConsiderationConfigurator : BaseUnitsAroundConsiderationConfigurator<BuffsAroundConsideration, BuffsAroundConsiderationConfigurator>
  {
    private BuffsAroundConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static BuffsAroundConsiderationConfigurator For(string name)
    {
      return new BuffsAroundConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static BuffsAroundConsiderationConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BuffsAroundConsideration>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BuffsAroundConsideration.m_Buffs"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buffs"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    [Generated]
    public BuffsAroundConsiderationConfigurator SetBuffs(string[]? buffs)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Buffs = buffs.Select(name => BlueprintTool.GetRef<BlueprintBuffReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BuffsAroundConsideration.m_Buffs"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buffs"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    [Generated]
    public BuffsAroundConsiderationConfigurator AddToBuffs(params string[] buffs)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Buffs = CommonTool.Append(bp.m_Buffs, buffs.Select(name => BlueprintTool.GetRef<BlueprintBuffReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BuffsAroundConsideration.m_Buffs"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buffs"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    [Generated]
    public BuffsAroundConsiderationConfigurator RemoveFromBuffs(params string[] buffs)
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
    /// Sets <see cref="BuffsAroundConsideration.CheckAbsence"/> (Auto Generated)
    /// </summary>
    [Generated]
    public BuffsAroundConsiderationConfigurator SetCheckAbsence(bool checkAbsence)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CheckAbsence = checkAbsence;
          });
    }
  }
}
