using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>
  /// Configurator for <see cref="BlueprintCharacterClassGroup"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintCharacterClassGroup))]
  public class CharacterClassGroupConfigurator : BaseBlueprintConfigurator<BlueprintCharacterClassGroup, CharacterClassGroupConfigurator>
  {
    private CharacterClassGroupConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CharacterClassGroupConfigurator For(string name)
    {
      return new CharacterClassGroupConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CharacterClassGroupConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintCharacterClassGroup>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCharacterClassGroup.m_CharacterClasses"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClasses"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    [Generated]
    public CharacterClassGroupConfigurator SetCharacterClasses(string[]? characterClasses)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CharacterClasses = characterClasses.Select(name => BlueprintTool.GetRef<BlueprintCharacterClassReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintCharacterClassGroup.m_CharacterClasses"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClasses"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    [Generated]
    public CharacterClassGroupConfigurator AddToCharacterClasses(params string[] characterClasses)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CharacterClasses = CommonTool.Append(bp.m_CharacterClasses, characterClasses.Select(name => BlueprintTool.GetRef<BlueprintCharacterClassReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintCharacterClassGroup.m_CharacterClasses"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClasses"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    [Generated]
    public CharacterClassGroupConfigurator RemoveFromCharacterClasses(params string[] characterClasses)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = characterClasses.Select(name => BlueprintTool.GetRef<BlueprintCharacterClassReference>(name));
            bp.m_CharacterClasses =
                bp.m_CharacterClasses
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }
  }
}
