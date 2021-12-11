using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.CharGen;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Enums;
using Kingmaker.View.Animation;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>
  /// Configurator for <see cref="BlueprintRace"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintRace))]
  public class RaceConfigurator : BaseFeatureConfigurator<BlueprintRace, RaceConfigurator>
  {
    private RaceConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static RaceConfigurator For(string name)
    {
      return new RaceConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static RaceConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintRace>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRace.SoundKey"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RaceConfigurator SetSoundKey(string soundKey)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.SoundKey = soundKey;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRace.RaceId"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RaceConfigurator SetRaceId(Race raceId)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.RaceId = raceId;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRace.SelectableRaceStat"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RaceConfigurator SetSelectableRaceStat(bool selectableRaceStat)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.SelectableRaceStat = selectableRaceStat;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRace.Size"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RaceConfigurator SetSize(Size size)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Size = size;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRace.m_Features"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="features"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeatureBase"/></param>
    [Generated]
    public RaceConfigurator SetFeatures(string[]? features)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Features = features.Select(name => BlueprintTool.GetRef<BlueprintFeatureBaseReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintRace.m_Features"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="features"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeatureBase"/></param>
    [Generated]
    public RaceConfigurator AddToFeatures(params string[] features)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Features = CommonTool.Append(bp.m_Features, features.Select(name => BlueprintTool.GetRef<BlueprintFeatureBaseReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintRace.m_Features"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="features"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeatureBase"/></param>
    [Generated]
    public RaceConfigurator RemoveFromFeatures(params string[] features)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = features.Select(name => BlueprintTool.GetRef<BlueprintFeatureBaseReference>(name));
            bp.m_Features =
                bp.m_Features
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRace.m_Presets"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="presets"><see cref="Kingmaker.Blueprints.CharGen.BlueprintRaceVisualPreset"/></param>
    [Generated]
    public RaceConfigurator SetPresets(string[]? presets)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Presets = presets.Select(name => BlueprintTool.GetRef<BlueprintRaceVisualPresetReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintRace.m_Presets"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="presets"><see cref="Kingmaker.Blueprints.CharGen.BlueprintRaceVisualPreset"/></param>
    [Generated]
    public RaceConfigurator AddToPresets(params string[] presets)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Presets = CommonTool.Append(bp.m_Presets, presets.Select(name => BlueprintTool.GetRef<BlueprintRaceVisualPresetReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintRace.m_Presets"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="presets"><see cref="Kingmaker.Blueprints.CharGen.BlueprintRaceVisualPreset"/></param>
    [Generated]
    public RaceConfigurator RemoveFromPresets(params string[] presets)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = presets.Select(name => BlueprintTool.GetRef<BlueprintRaceVisualPresetReference>(name));
            bp.m_Presets =
                bp.m_Presets
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRace.LinkHairAndSkinColors"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RaceConfigurator SetLinkHairAndSkinColors(bool linkHairAndSkinColors)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.LinkHairAndSkinColors = linkHairAndSkinColors;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRace.MaleOptions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RaceConfigurator SetMaleOptions(CustomizationOptions maleOptions)
    {
      ValidateParam(maleOptions);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.MaleOptions = maleOptions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRace.FemaleOptions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RaceConfigurator SetFemaleOptions(CustomizationOptions femaleOptions)
    {
      ValidateParam(femaleOptions);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.FemaleOptions = femaleOptions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRace.MaleSpeedSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RaceConfigurator SetMaleSpeedSettings(UnitAnimationSettings maleSpeedSettings)
    {
      ValidateParam(maleSpeedSettings);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.MaleSpeedSettings = maleSpeedSettings;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRace.FemaleSpeedSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RaceConfigurator SetFemaleSpeedSettings(UnitAnimationSettings femaleSpeedSettings)
    {
      ValidateParam(femaleSpeedSettings);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.FemaleSpeedSettings = femaleSpeedSettings;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRace.SpecialDollTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RaceConfigurator SetSpecialDollTypes(BlueprintRace.SpecialDollTypeEntry[]? specialDollTypes)
    {
      ValidateParam(specialDollTypes);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.SpecialDollTypes = specialDollTypes;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintRace.SpecialDollTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RaceConfigurator AddToSpecialDollTypes(params BlueprintRace.SpecialDollTypeEntry[] specialDollTypes)
    {
      ValidateParam(specialDollTypes);
      return OnConfigureInternal(
          bp =>
          {
            bp.SpecialDollTypes = CommonTool.Append(bp.SpecialDollTypes, specialDollTypes ?? new BlueprintRace.SpecialDollTypeEntry[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintRace.SpecialDollTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RaceConfigurator RemoveFromSpecialDollTypes(params BlueprintRace.SpecialDollTypeEntry[] specialDollTypes)
    {
      ValidateParam(specialDollTypes);
      return OnConfigureInternal(
          bp =>
          {
            bp.SpecialDollTypes = bp.SpecialDollTypes.Where(item => !specialDollTypes.Contains(item)).ToArray();
          });
    }
  }
}
