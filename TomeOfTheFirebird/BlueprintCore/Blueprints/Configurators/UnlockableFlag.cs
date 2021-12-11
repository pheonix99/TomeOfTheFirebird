using BlueprintCore.Utils;
using Kingmaker.Blueprints;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Configurator for <see cref="BlueprintUnlockableFlag"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintUnlockableFlag))]
  public class UnlockableFlagConfigurator : BaseBlueprintConfigurator<BlueprintUnlockableFlag, UnlockableFlagConfigurator>
  {
    private UnlockableFlagConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static UnlockableFlagConfigurator For(string name)
    {
      return new UnlockableFlagConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static UnlockableFlagConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintUnlockableFlag>(name, guid);
      return For(name);
    }
  }
}
