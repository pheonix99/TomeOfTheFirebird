using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Items
{
  /// <summary>
  /// Configurator for <see cref="BlueprintHiddenItem"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintHiddenItem))]
  public class HiddenItemConfigurator : BaseItemConfigurator<BlueprintHiddenItem, HiddenItemConfigurator>
  {
    private HiddenItemConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static HiddenItemConfigurator For(string name)
    {
      return new HiddenItemConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static HiddenItemConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintHiddenItem>(name, guid);
      return For(name);
    }
  }
}
