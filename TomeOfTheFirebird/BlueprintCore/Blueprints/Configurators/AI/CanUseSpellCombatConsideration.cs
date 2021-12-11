using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Configurator for <see cref="CanUseSpellCombatConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(CanUseSpellCombatConsideration))]
  public class CanUseSpellCombatConsiderationConfigurator : BaseConsiderationConfigurator<CanUseSpellCombatConsideration, CanUseSpellCombatConsiderationConfigurator>
  {
    private CanUseSpellCombatConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CanUseSpellCombatConsiderationConfigurator For(string name)
    {
      return new CanUseSpellCombatConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CanUseSpellCombatConsiderationConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<CanUseSpellCombatConsideration>(name, guid);
      return For(name);
    }
  }
}
