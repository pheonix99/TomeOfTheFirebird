using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Localization;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Globalmap
{
  /// <summary>
  /// Configurator for <see cref="BlueprintMultiEntrance"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintMultiEntrance))]
  public class MultiEntranceConfigurator : BaseBlueprintConfigurator<BlueprintMultiEntrance, MultiEntranceConfigurator>
  {
    private MultiEntranceConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static MultiEntranceConfigurator For(string name)
    {
      return new MultiEntranceConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static MultiEntranceConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintMultiEntrance>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintMultiEntrance.Map"/> (Auto Generated)
    /// </summary>
    [Generated]
    public MultiEntranceConfigurator SetMap(BlueprintMultiEntrance.BlueprintMultiEntranceMap map)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Map = map;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintMultiEntrance.Name"/> (Auto Generated)
    /// </summary>
    [Generated]
    public MultiEntranceConfigurator SetName(LocalizedString? name)
    {
      ValidateParam(name);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Name = name ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintMultiEntrance.m_Entries"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="entries"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintMultiEntranceEntry"/></param>
    [Generated]
    public MultiEntranceConfigurator SetEntries(string[]? entries)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Entries = entries.Select(name => BlueprintTool.GetRef<BlueprintMultiEntranceEntryReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintMultiEntrance.m_Entries"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="entries"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintMultiEntranceEntry"/></param>
    [Generated]
    public MultiEntranceConfigurator AddToEntries(params string[] entries)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Entries = CommonTool.Append(bp.m_Entries, entries.Select(name => BlueprintTool.GetRef<BlueprintMultiEntranceEntryReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintMultiEntrance.m_Entries"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="entries"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintMultiEntranceEntry"/></param>
    [Generated]
    public MultiEntranceConfigurator RemoveFromEntries(params string[] entries)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = entries.Select(name => BlueprintTool.GetRef<BlueprintMultiEntranceEntryReference>(name));
            bp.m_Entries =
                bp.m_Entries
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }
  }
}
