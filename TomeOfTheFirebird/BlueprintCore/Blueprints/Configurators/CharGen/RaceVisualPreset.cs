using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.CharGen;
using Kingmaker.Visual.CharacterSystem;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.CharGen
{
  /// <summary>
  /// Configurator for <see cref="BlueprintRaceVisualPreset"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintRaceVisualPreset))]
  public class RaceVisualPresetConfigurator : BaseBlueprintConfigurator<BlueprintRaceVisualPreset, RaceVisualPresetConfigurator>
  {
    private RaceVisualPresetConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static RaceVisualPresetConfigurator For(string name)
    {
      return new RaceVisualPresetConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static RaceVisualPresetConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintRaceVisualPreset>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRaceVisualPreset.RaceId"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RaceVisualPresetConfigurator SetRaceId(Race raceId)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.RaceId = raceId;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRaceVisualPreset.MaleSkeleton"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RaceVisualPresetConfigurator SetMaleSkeleton(Skeleton maleSkeleton)
    {
      ValidateParam(maleSkeleton);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.MaleSkeleton = maleSkeleton;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRaceVisualPreset.FemaleSkeleton"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RaceVisualPresetConfigurator SetFemaleSkeleton(Skeleton femaleSkeleton)
    {
      ValidateParam(femaleSkeleton);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.FemaleSkeleton = femaleSkeleton;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRaceVisualPreset.m_Skin"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="skin"><see cref="Kingmaker.Visual.CharacterSystem.KingmakerEquipmentEntity"/></param>
    [Generated]
    public RaceVisualPresetConfigurator SetSkin(string? skin)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Skin = BlueprintTool.GetRef<KingmakerEquipmentEntityReference>(skin);
          });
    }
  }
}
