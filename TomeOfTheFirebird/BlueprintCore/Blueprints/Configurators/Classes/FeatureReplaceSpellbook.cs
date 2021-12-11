using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>
  /// Configurator for <see cref="BlueprintFeatureReplaceSpellbook"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintFeatureReplaceSpellbook))]
  public class FeatureReplaceSpellbookConfigurator : BaseFeatureConfigurator<BlueprintFeatureReplaceSpellbook, FeatureReplaceSpellbookConfigurator>
  {
    private FeatureReplaceSpellbookConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static FeatureReplaceSpellbookConfigurator For(string name)
    {
      return new FeatureReplaceSpellbookConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static FeatureReplaceSpellbookConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintFeatureReplaceSpellbook>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintFeatureReplaceSpellbook.m_Spellbook"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellbook"><see cref="Kingmaker.Blueprints.Classes.Spells.BlueprintSpellbook"/></param>
    [Generated]
    public FeatureReplaceSpellbookConfigurator SetSpellbook(string? spellbook)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Spellbook = BlueprintTool.GetRef<BlueprintSpellbookReference>(spellbook);
          });
    }
  }
}
