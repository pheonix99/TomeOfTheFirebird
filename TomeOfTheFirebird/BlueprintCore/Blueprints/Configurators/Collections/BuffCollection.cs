using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Designers.Mechanics.Collections;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Collections
{
  /// <summary>
  /// Configurator for <see cref="BuffCollection"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BuffCollection))]
  public class BuffCollectionConfigurator : BaseBlueprintConfigurator<BuffCollection, BuffCollectionConfigurator>
  {
    private BuffCollectionConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static BuffCollectionConfigurator For(string name)
    {
      return new BuffCollectionConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static BuffCollectionConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BuffCollection>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BuffCollection.CheckHidden"/> (Auto Generated)
    /// </summary>
    [Generated]
    public BuffCollectionConfigurator SetCheckHidden(bool checkHidden)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CheckHidden = checkHidden;
          });
    }

    /// <summary>
    /// Sets <see cref="BuffCollection.m_BuffList"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buffList"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    [Generated]
    public BuffCollectionConfigurator SetBuffList(string[]? buffList)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_BuffList = buffList.Select(name => BlueprintTool.GetRef<BlueprintBuffReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BuffCollection.m_BuffList"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buffList"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    [Generated]
    public BuffCollectionConfigurator AddToBuffList(params string[] buffList)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_BuffList = CommonTool.Append(bp.m_BuffList, buffList.Select(name => BlueprintTool.GetRef<BlueprintBuffReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BuffCollection.m_BuffList"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buffList"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    [Generated]
    public BuffCollectionConfigurator RemoveFromBuffList(params string[] buffList)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = buffList.Select(name => BlueprintTool.GetRef<BlueprintBuffReference>(name));
            bp.m_BuffList =
                bp.m_BuffList
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }
  }
}
