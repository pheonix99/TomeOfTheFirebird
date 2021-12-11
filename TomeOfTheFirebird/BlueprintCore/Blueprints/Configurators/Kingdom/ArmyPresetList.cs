using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom.Blueprints;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>
  /// Configurator for <see cref="BlueprintArmyPresetList"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintArmyPresetList))]
  public class ArmyPresetListConfigurator : BaseBlueprintConfigurator<BlueprintArmyPresetList, ArmyPresetListConfigurator>
  {
    private ArmyPresetListConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ArmyPresetListConfigurator For(string name)
    {
      return new ArmyPresetListConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ArmyPresetListConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintArmyPresetList>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmyPresetList.m_Presets"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="presets"><see cref="Kingmaker.Armies.Blueprints.BlueprintArmyPreset"/></param>
    [Generated]
    public ArmyPresetListConfigurator SetPresets(string[]? presets)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Presets = presets.Select(name => BlueprintTool.GetRef<BlueprintArmyPresetReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintArmyPresetList.m_Presets"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="presets"><see cref="Kingmaker.Armies.Blueprints.BlueprintArmyPreset"/></param>
    [Generated]
    public ArmyPresetListConfigurator AddToPresets(params string[] presets)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Presets = CommonTool.Append(bp.m_Presets, presets.Select(name => BlueprintTool.GetRef<BlueprintArmyPresetReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintArmyPresetList.m_Presets"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="presets"><see cref="Kingmaker.Armies.Blueprints.BlueprintArmyPreset"/></param>
    [Generated]
    public ArmyPresetListConfigurator RemoveFromPresets(params string[] presets)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = presets.Select(name => BlueprintTool.GetRef<BlueprintArmyPresetReference>(name));
            bp.m_Presets =
                bp.m_Presets
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }
  }
}
