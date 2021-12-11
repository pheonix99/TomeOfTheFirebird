using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Customization;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.UnitLogic.Customization
{
  /// <summary>
  /// Configurator for <see cref="UnitCustomizationPreset"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(UnitCustomizationPreset))]
  public class UnitCustomizationPresetConfigurator : BaseBlueprintConfigurator<UnitCustomizationPreset, UnitCustomizationPresetConfigurator>
  {
    private UnitCustomizationPresetConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static UnitCustomizationPresetConfigurator For(string name)
    {
      return new UnitCustomizationPresetConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static UnitCustomizationPresetConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<UnitCustomizationPreset>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="UnitCustomizationPreset.PresetObjects"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitCustomizationPresetConfigurator SetPresetObjects(List<PresetObject>? presetObjects)
    {
      ValidateParam(presetObjects);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.PresetObjects = presetObjects;
          });
    }

    /// <summary>
    /// Adds to <see cref="UnitCustomizationPreset.PresetObjects"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitCustomizationPresetConfigurator AddToPresetObjects(params PresetObject[] presetObjects)
    {
      ValidateParam(presetObjects);
      return OnConfigureInternal(
          bp =>
          {
            bp.PresetObjects.AddRange(presetObjects.ToList() ?? new List<PresetObject>());
          });
    }

    /// <summary>
    /// Removes from <see cref="UnitCustomizationPreset.PresetObjects"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitCustomizationPresetConfigurator RemoveFromPresetObjects(params PresetObject[] presetObjects)
    {
      ValidateParam(presetObjects);
      return OnConfigureInternal(
          bp =>
          {
            bp.PresetObjects = bp.PresetObjects.Where(item => !presetObjects.Contains(item)).ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="UnitCustomizationPreset.VariationsCount"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitCustomizationPresetConfigurator SetVariationsCount(int variationsCount)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.VariationsCount = variationsCount;
          });
    }

    /// <summary>
    /// Sets <see cref="UnitCustomizationPreset.m_Distribution"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="distribution"><see cref="Kingmaker.UnitLogic.Customization.RaceGenderDistribution"/></param>
    [Generated]
    public UnitCustomizationPresetConfigurator SetDistribution(string? distribution)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Distribution = BlueprintTool.GetRef<RaceGenderDistributionReference>(distribution);
          });
    }

    /// <summary>
    /// Sets <see cref="UnitCustomizationPreset.m_Units"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="units"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public UnitCustomizationPresetConfigurator SetUnits(string[]? units)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Units = units.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="UnitCustomizationPreset.m_Units"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="units"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public UnitCustomizationPresetConfigurator AddToUnits(params string[] units)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Units = CommonTool.Append(bp.m_Units, units.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="UnitCustomizationPreset.m_Units"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="units"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public UnitCustomizationPresetConfigurator RemoveFromUnits(params string[] units)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = units.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name));
            bp.m_Units =
                bp.m_Units
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="UnitCustomizationPreset.ClothesSelections"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitCustomizationPresetConfigurator SetClothesSelections(ClothesSelection[]? clothesSelections)
    {
      ValidateParam(clothesSelections);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.ClothesSelections = clothesSelections;
          });
    }

    /// <summary>
    /// Adds to <see cref="UnitCustomizationPreset.ClothesSelections"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitCustomizationPresetConfigurator AddToClothesSelections(params ClothesSelection[] clothesSelections)
    {
      ValidateParam(clothesSelections);
      return OnConfigureInternal(
          bp =>
          {
            bp.ClothesSelections = CommonTool.Append(bp.ClothesSelections, clothesSelections ?? new ClothesSelection[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="UnitCustomizationPreset.ClothesSelections"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitCustomizationPresetConfigurator RemoveFromClothesSelections(params ClothesSelection[] clothesSelections)
    {
      ValidateParam(clothesSelections);
      return OnConfigureInternal(
          bp =>
          {
            bp.ClothesSelections = bp.ClothesSelections.Where(item => !clothesSelections.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="UnitCustomizationPreset.UnitVariations"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitCustomizationPresetConfigurator SetUnitVariations(List<UnitVariations>? unitVariations)
    {
      ValidateParam(unitVariations);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.UnitVariations = unitVariations;
          });
    }

    /// <summary>
    /// Adds to <see cref="UnitCustomizationPreset.UnitVariations"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitCustomizationPresetConfigurator AddToUnitVariations(params UnitVariations[] unitVariations)
    {
      ValidateParam(unitVariations);
      return OnConfigureInternal(
          bp =>
          {
            bp.UnitVariations.AddRange(unitVariations.ToList() ?? new List<UnitVariations>());
          });
    }

    /// <summary>
    /// Removes from <see cref="UnitCustomizationPreset.UnitVariations"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitCustomizationPresetConfigurator RemoveFromUnitVariations(params UnitVariations[] unitVariations)
    {
      ValidateParam(unitVariations);
      return OnConfigureInternal(
          bp =>
          {
            bp.UnitVariations = bp.UnitVariations.Where(item => !unitVariations.Contains(item)).ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="UnitCustomizationPreset.MaleVoices"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="maleVoices"><see cref="Kingmaker.Visual.Sound.BlueprintUnitAsksList"/></param>
    [Generated]
    public UnitCustomizationPresetConfigurator SetMaleVoices(string[]? maleVoices)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MaleVoices = maleVoices.Select(name => BlueprintTool.GetRef<BlueprintUnitAsksListReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="UnitCustomizationPreset.MaleVoices"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="maleVoices"><see cref="Kingmaker.Visual.Sound.BlueprintUnitAsksList"/></param>
    [Generated]
    public UnitCustomizationPresetConfigurator AddToMaleVoices(params string[] maleVoices)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MaleVoices.AddRange(maleVoices.Select(name => BlueprintTool.GetRef<BlueprintUnitAsksListReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="UnitCustomizationPreset.MaleVoices"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="maleVoices"><see cref="Kingmaker.Visual.Sound.BlueprintUnitAsksList"/></param>
    [Generated]
    public UnitCustomizationPresetConfigurator RemoveFromMaleVoices(params string[] maleVoices)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = maleVoices.Select(name => BlueprintTool.GetRef<BlueprintUnitAsksListReference>(name));
            bp.MaleVoices =
                bp.MaleVoices
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="UnitCustomizationPreset.FemaleVoices"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="femaleVoices"><see cref="Kingmaker.Visual.Sound.BlueprintUnitAsksList"/></param>
    [Generated]
    public UnitCustomizationPresetConfigurator SetFemaleVoices(string[]? femaleVoices)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.FemaleVoices = femaleVoices.Select(name => BlueprintTool.GetRef<BlueprintUnitAsksListReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="UnitCustomizationPreset.FemaleVoices"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="femaleVoices"><see cref="Kingmaker.Visual.Sound.BlueprintUnitAsksList"/></param>
    [Generated]
    public UnitCustomizationPresetConfigurator AddToFemaleVoices(params string[] femaleVoices)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.FemaleVoices.AddRange(femaleVoices.Select(name => BlueprintTool.GetRef<BlueprintUnitAsksListReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="UnitCustomizationPreset.FemaleVoices"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="femaleVoices"><see cref="Kingmaker.Visual.Sound.BlueprintUnitAsksList"/></param>
    [Generated]
    public UnitCustomizationPresetConfigurator RemoveFromFemaleVoices(params string[] femaleVoices)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = femaleVoices.Select(name => BlueprintTool.GetRef<BlueprintUnitAsksListReference>(name));
            bp.FemaleVoices =
                bp.FemaleVoices
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="UnitCustomizationPreset.randomParameters"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="randomParameters"><see cref="Kingmaker.UnitLogic.Customization.RandomParameters"/></param>
    [Generated]
    public UnitCustomizationPresetConfigurator SetRandomParameters(string? randomParameters)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.randomParameters = BlueprintTool.GetRef<RandomParametersReference>(randomParameters);
          });
    }
  }
}
