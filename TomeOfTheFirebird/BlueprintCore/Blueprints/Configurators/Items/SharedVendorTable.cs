using BlueprintCore.Blueprints.Configurators.Loot;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Items
{
  /// <summary>
  /// Configurator for <see cref="BlueprintSharedVendorTable"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintSharedVendorTable))]
  public class SharedVendorTableConfigurator : BaseUnitLootConfigurator<BlueprintSharedVendorTable, SharedVendorTableConfigurator>
  {
    private SharedVendorTableConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static SharedVendorTableConfigurator For(string name)
    {
      return new SharedVendorTableConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static SharedVendorTableConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintSharedVendorTable>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintSharedVendorTable.AutoIdentifyAllItems"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SharedVendorTableConfigurator SetAutoIdentifyAllItems(bool autoIdentifyAllItems)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AutoIdentifyAllItems = autoIdentifyAllItems;
          });
    }
  }
}
