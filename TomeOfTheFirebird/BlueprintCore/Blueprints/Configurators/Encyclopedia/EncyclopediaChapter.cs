using BlueprintCore.Utils;
using Kingmaker.Blueprints.Encyclopedia;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Encyclopedia
{
  /// <summary>
  /// Configurator for <see cref="BlueprintEncyclopediaChapter"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintEncyclopediaChapter))]
  public class EncyclopediaChapterConfigurator : BaseEncyclopediaPageConfigurator<BlueprintEncyclopediaChapter, EncyclopediaChapterConfigurator>
  {
    private EncyclopediaChapterConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static EncyclopediaChapterConfigurator For(string name)
    {
      return new EncyclopediaChapterConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static EncyclopediaChapterConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintEncyclopediaChapter>(name, guid);
      return For(name);
    }
  }
}
