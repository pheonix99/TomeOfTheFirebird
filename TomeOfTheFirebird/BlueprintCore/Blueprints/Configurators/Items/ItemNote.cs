using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Items
{
  /// <summary>
  /// Configurator for <see cref="BlueprintItemNote"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItemNote))]
  public class ItemNoteConfigurator : BaseItemConfigurator<BlueprintItemNote, ItemNoteConfigurator>
  {
    private ItemNoteConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ItemNoteConfigurator For(string name)
    {
      return new ItemNoteConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ItemNoteConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintItemNote>(name, guid);
      return For(name);
    }
  }
}
