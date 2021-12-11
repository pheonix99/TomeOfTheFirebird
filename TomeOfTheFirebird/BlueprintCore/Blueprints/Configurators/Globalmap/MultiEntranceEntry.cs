using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Localization;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Globalmap
{
  /// <summary>
  /// Configurator for <see cref="BlueprintMultiEntranceEntry"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintMultiEntranceEntry))]
  public class MultiEntranceEntryConfigurator : BaseBlueprintConfigurator<BlueprintMultiEntranceEntry, MultiEntranceEntryConfigurator>
  {
    private MultiEntranceEntryConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static MultiEntranceEntryConfigurator For(string name)
    {
      return new MultiEntranceEntryConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static MultiEntranceEntryConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintMultiEntranceEntry>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintMultiEntranceEntry.Name"/> (Auto Generated)
    /// </summary>
    [Generated]
    public MultiEntranceEntryConfigurator SetName(LocalizedString? name)
    {
      ValidateParam(name);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Name = name ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintMultiEntranceEntry.m_Condition"/> (Auto Generated)
    /// </summary>
    [Generated]
    public MultiEntranceEntryConfigurator SetCondition(ConditionsBuilder? condition)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Condition = condition?.Build() ?? Constants.Empty.Conditions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintMultiEntranceEntry.m_Actions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public MultiEntranceEntryConfigurator SetActions(ActionsBuilder? actions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Actions = actions?.Build() ?? Constants.Empty.Actions;
          });
    }
  }
}
