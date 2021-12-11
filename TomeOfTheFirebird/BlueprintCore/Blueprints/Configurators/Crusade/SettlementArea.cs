using BlueprintCore.Blueprints.Configurators.Area;
using BlueprintCore.Utils;
using Kingmaker.Crusade;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Crusade
{
  /// <summary>
  /// Configurator for <see cref="SettlementBlueprintArea"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(SettlementBlueprintArea))]
  public class SettlementAreaConfigurator : BaseAreaConfigurator<SettlementBlueprintArea, SettlementAreaConfigurator>
  {
    private SettlementAreaConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static SettlementAreaConfigurator For(string name)
    {
      return new SettlementAreaConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static SettlementAreaConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<SettlementBlueprintArea>(name, guid);
      return For(name);
    }
  }
}
