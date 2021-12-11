using BlueprintCore.Utils;
using Kingmaker.Kingdom.Blueprints;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>
  /// Configurator for <see cref="BlueprintKingdomUpgrade"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintKingdomUpgrade))]
  public class KingdomUpgradeConfigurator : BaseKingdomProjectConfigurator<BlueprintKingdomUpgrade, KingdomUpgradeConfigurator>
  {
    private KingdomUpgradeConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static KingdomUpgradeConfigurator For(string name)
    {
      return new KingdomUpgradeConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static KingdomUpgradeConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintKingdomUpgrade>(name, guid);
      return For(name);
    }
  }
}
