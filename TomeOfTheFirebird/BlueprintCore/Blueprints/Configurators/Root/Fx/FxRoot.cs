using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Root;
using Kingmaker.Blueprints.Root.Fx;
using System.Linq;
using UnityEngine;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Root.Fx
{
  /// <summary>
  /// Configurator for <see cref="FxRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(FxRoot))]
  public class FxRootConfigurator : BaseBlueprintConfigurator<FxRoot, FxRootConfigurator>
  {
    private FxRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static FxRootConfigurator For(string name)
    {
      return new FxRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static FxRootConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<FxRoot>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="FxRoot.m_SingleHandCasts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="singleHandCasts"><see cref="Kingmaker.Blueprints.Root.Fx.CastsGroup"/></param>
    [Generated]
    public FxRootConfigurator SetSingleHandCasts(string? singleHandCasts)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_SingleHandCasts = BlueprintTool.GetRef<CastsGroup.Reference>(singleHandCasts);
          });
    }

    /// <summary>
    /// Sets <see cref="FxRoot.m_DoubleHandCasts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="doubleHandCasts"><see cref="Kingmaker.Blueprints.Root.Fx.CastsGroup"/></param>
    [Generated]
    public FxRootConfigurator SetDoubleHandCasts(string? doubleHandCasts)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DoubleHandCasts = BlueprintTool.GetRef<CastsGroup.Reference>(doubleHandCasts);
          });
    }

    /// <summary>
    /// Sets <see cref="FxRoot.m_HeadCasts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="headCasts"><see cref="Kingmaker.Blueprints.Root.Fx.CastsGroup"/></param>
    [Generated]
    public FxRootConfigurator SetHeadCasts(string? headCasts)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_HeadCasts = BlueprintTool.GetRef<CastsGroup.Reference>(headCasts);
          });
    }

    /// <summary>
    /// Sets <see cref="FxRoot.m_TorsoCasts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="torsoCasts"><see cref="Kingmaker.Blueprints.Root.Fx.CastsGroup"/></param>
    [Generated]
    public FxRootConfigurator SetTorsoCasts(string? torsoCasts)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_TorsoCasts = BlueprintTool.GetRef<CastsGroup.Reference>(torsoCasts);
          });
    }

    /// <summary>
    /// Sets <see cref="FxRoot.FallEventStrings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator SetFallEventStrings(string[]? fallEventStrings)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.FallEventStrings = fallEventStrings;
          });
    }

    /// <summary>
    /// Adds to <see cref="FxRoot.FallEventStrings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator AddToFallEventStrings(params string[] fallEventStrings)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.FallEventStrings = CommonTool.Append(bp.FallEventStrings, fallEventStrings ?? new string[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="FxRoot.FallEventStrings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator RemoveFromFallEventStrings(params string[] fallEventStrings)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.FallEventStrings = bp.FallEventStrings.Where(item => !fallEventStrings.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="FxRoot.DustOnFallPrefab"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator SetDustOnFallPrefab(GameObject dustOnFallPrefab)
    {
      ValidateParam(dustOnFallPrefab);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.DustOnFallPrefab = dustOnFallPrefab;
          });
    }

    /// <summary>
    /// Sets <see cref="FxRoot.PoolEntries"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator SetPoolEntries(PoolEntry[]? poolEntries)
    {
      ValidateParam(poolEntries);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.PoolEntries = poolEntries;
          });
    }

    /// <summary>
    /// Adds to <see cref="FxRoot.PoolEntries"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator AddToPoolEntries(params PoolEntry[] poolEntries)
    {
      ValidateParam(poolEntries);
      return OnConfigureInternal(
          bp =>
          {
            bp.PoolEntries = CommonTool.Append(bp.PoolEntries, poolEntries ?? new PoolEntry[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="FxRoot.PoolEntries"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator RemoveFromPoolEntries(params PoolEntry[] poolEntries)
    {
      ValidateParam(poolEntries);
      return OnConfigureInternal(
          bp =>
          {
            bp.PoolEntries = bp.PoolEntries.Where(item => !poolEntries.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="FxRoot.OverrideDeathPrefabsFromEnergy"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator SetOverrideDeathPrefabsFromEnergy(DeathFxFromEnergyEntry[]? overrideDeathPrefabsFromEnergy)
    {
      ValidateParam(overrideDeathPrefabsFromEnergy);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.OverrideDeathPrefabsFromEnergy = overrideDeathPrefabsFromEnergy;
          });
    }

    /// <summary>
    /// Adds to <see cref="FxRoot.OverrideDeathPrefabsFromEnergy"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator AddToOverrideDeathPrefabsFromEnergy(params DeathFxFromEnergyEntry[] overrideDeathPrefabsFromEnergy)
    {
      ValidateParam(overrideDeathPrefabsFromEnergy);
      return OnConfigureInternal(
          bp =>
          {
            bp.OverrideDeathPrefabsFromEnergy = CommonTool.Append(bp.OverrideDeathPrefabsFromEnergy, overrideDeathPrefabsFromEnergy ?? new DeathFxFromEnergyEntry[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="FxRoot.OverrideDeathPrefabsFromEnergy"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator RemoveFromOverrideDeathPrefabsFromEnergy(params DeathFxFromEnergyEntry[] overrideDeathPrefabsFromEnergy)
    {
      ValidateParam(overrideDeathPrefabsFromEnergy);
      return OnConfigureInternal(
          bp =>
          {
            bp.OverrideDeathPrefabsFromEnergy = bp.OverrideDeathPrefabsFromEnergy.Where(item => !overrideDeathPrefabsFromEnergy.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="FxRoot.IntensityMultiplierMorning"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator SetIntensityMultiplierMorning(float intensityMultiplierMorning)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IntensityMultiplierMorning = intensityMultiplierMorning;
          });
    }

    /// <summary>
    /// Sets <see cref="FxRoot.IntensityMultiplierDay"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator SetIntensityMultiplierDay(float intensityMultiplierDay)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IntensityMultiplierDay = intensityMultiplierDay;
          });
    }

    /// <summary>
    /// Sets <see cref="FxRoot.IntensityMultiplierEvening"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator SetIntensityMultiplierEvening(float intensityMultiplierEvening)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IntensityMultiplierEvening = intensityMultiplierEvening;
          });
    }

    /// <summary>
    /// Sets <see cref="FxRoot.IntensityMultiplierNight"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator SetIntensityMultiplierNight(float intensityMultiplierNight)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IntensityMultiplierNight = intensityMultiplierNight;
          });
    }

    /// <summary>
    /// Sets <see cref="FxRoot.RangeMultiplierMorning"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator SetRangeMultiplierMorning(float rangeMultiplierMorning)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.RangeMultiplierMorning = rangeMultiplierMorning;
          });
    }

    /// <summary>
    /// Sets <see cref="FxRoot.RangeMultiplierDay"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator SetRangeMultiplierDay(float rangeMultiplierDay)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.RangeMultiplierDay = rangeMultiplierDay;
          });
    }

    /// <summary>
    /// Sets <see cref="FxRoot.RangeMultiplierEvening"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator SetRangeMultiplierEvening(float rangeMultiplierEvening)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.RangeMultiplierEvening = rangeMultiplierEvening;
          });
    }

    /// <summary>
    /// Sets <see cref="FxRoot.RangeMultiplierNight"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator SetRangeMultiplierNight(float rangeMultiplierNight)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.RangeMultiplierNight = rangeMultiplierNight;
          });
    }

    /// <summary>
    /// Sets <see cref="FxRoot.RaceFxSnapMapScaleSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator SetRaceFxSnapMapScaleSettings(RaceFxScaleSettings raceFxSnapMapScaleSettings)
    {
      ValidateParam(raceFxSnapMapScaleSettings);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.RaceFxSnapMapScaleSettings = raceFxSnapMapScaleSettings;
          });
    }

    /// <summary>
    /// Sets <see cref="FxRoot.RaceFxSnapToLocatorScaleSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator SetRaceFxSnapToLocatorScaleSettings(RaceFxScaleSettings raceFxSnapToLocatorScaleSettings)
    {
      ValidateParam(raceFxSnapToLocatorScaleSettings);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.RaceFxSnapToLocatorScaleSettings = raceFxSnapToLocatorScaleSettings;
          });
    }

    /// <summary>
    /// Sets <see cref="FxRoot.RaceFxFluidFogInteractionScaleSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator SetRaceFxFluidFogInteractionScaleSettings(RaceFxScaleSettings raceFxFluidFogInteractionScaleSettings)
    {
      ValidateParam(raceFxFluidFogInteractionScaleSettings);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.RaceFxFluidFogInteractionScaleSettings = raceFxFluidFogInteractionScaleSettings;
          });
    }

    /// <summary>
    /// Sets <see cref="FxRoot.DefaultLifetimeSeconds"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator SetDefaultLifetimeSeconds(float defaultLifetimeSeconds)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DefaultLifetimeSeconds = defaultLifetimeSeconds;
          });
    }

    /// <summary>
    /// Sets <see cref="FxRoot.FadeOutTimeSeconds"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator SetFadeOutTimeSeconds(float fadeOutTimeSeconds)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.FadeOutTimeSeconds = fadeOutTimeSeconds;
          });
    }

    /// <summary>
    /// Sets <see cref="FxRoot.MaxFootprintsCountPerUnit"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator SetMaxFootprintsCountPerUnit(int maxFootprintsCountPerUnit)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MaxFootprintsCountPerUnit = maxFootprintsCountPerUnit;
          });
    }

    /// <summary>
    /// Sets <see cref="FxRoot.MinDistanceBetweenFootprints"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator SetMinDistanceBetweenFootprints(float minDistanceBetweenFootprints)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MinDistanceBetweenFootprints = minDistanceBetweenFootprints;
          });
    }

    /// <summary>
    /// Sets <see cref="FxRoot.FootprintsReferences"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="footprintsReferences"><see cref="Kingmaker.Blueprints.Footrprints.BlueprintFootprintType"/></param>
    [Generated]
    public FxRootConfigurator SetFootprintsReferences(string[]? footprintsReferences)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.FootprintsReferences = footprintsReferences.Select(name => BlueprintTool.GetRef<BlueprintFootprintTypeReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="FxRoot.FootprintsReferences"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="footprintsReferences"><see cref="Kingmaker.Blueprints.Footrprints.BlueprintFootprintType"/></param>
    [Generated]
    public FxRootConfigurator AddToFootprintsReferences(params string[] footprintsReferences)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.FootprintsReferences = CommonTool.Append(bp.FootprintsReferences, footprintsReferences.Select(name => BlueprintTool.GetRef<BlueprintFootprintTypeReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="FxRoot.FootprintsReferences"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="footprintsReferences"><see cref="Kingmaker.Blueprints.Footrprints.BlueprintFootprintType"/></param>
    [Generated]
    public FxRootConfigurator RemoveFromFootprintsReferences(params string[] footprintsReferences)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = footprintsReferences.Select(name => BlueprintTool.GetRef<BlueprintFootprintTypeReference>(name));
            bp.FootprintsReferences =
                bp.FootprintsReferences
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="FxRoot.FootprintsLocators"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator SetFootprintsLocators(FxRoot.FootprintLocators[]? footprintsLocators)
    {
      ValidateParam(footprintsLocators);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.FootprintsLocators = footprintsLocators;
          });
    }

    /// <summary>
    /// Adds to <see cref="FxRoot.FootprintsLocators"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator AddToFootprintsLocators(params FxRoot.FootprintLocators[] footprintsLocators)
    {
      ValidateParam(footprintsLocators);
      return OnConfigureInternal(
          bp =>
          {
            bp.FootprintsLocators = CommonTool.Append(bp.FootprintsLocators, footprintsLocators ?? new FxRoot.FootprintLocators[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="FxRoot.FootprintsLocators"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator RemoveFromFootprintsLocators(params FxRoot.FootprintLocators[] footprintsLocators)
    {
      ValidateParam(footprintsLocators);
      return OnConfigureInternal(
          bp =>
          {
            bp.FootprintsLocators = bp.FootprintsLocators.Where(item => !footprintsLocators.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="FxRoot.m_DeathFxsInitialized"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator SetDeathFxsInitialized(bool deathFxsInitialized)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DeathFxsInitialized = deathFxsInitialized;
          });
    }

    /// <summary>
    /// Sets <see cref="FxRoot.m_CachedOverrideDeathPrefabsFromEnergy"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator SetCachedOverrideDeathPrefabsFromEnergy(DeathFxFromEnergyEntry[]? cachedOverrideDeathPrefabsFromEnergy)
    {
      ValidateParam(cachedOverrideDeathPrefabsFromEnergy);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedOverrideDeathPrefabsFromEnergy = cachedOverrideDeathPrefabsFromEnergy;
          });
    }

    /// <summary>
    /// Adds to <see cref="FxRoot.m_CachedOverrideDeathPrefabsFromEnergy"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator AddToCachedOverrideDeathPrefabsFromEnergy(params DeathFxFromEnergyEntry[] cachedOverrideDeathPrefabsFromEnergy)
    {
      ValidateParam(cachedOverrideDeathPrefabsFromEnergy);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedOverrideDeathPrefabsFromEnergy = CommonTool.Append(bp.m_CachedOverrideDeathPrefabsFromEnergy, cachedOverrideDeathPrefabsFromEnergy ?? new DeathFxFromEnergyEntry[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="FxRoot.m_CachedOverrideDeathPrefabsFromEnergy"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator RemoveFromCachedOverrideDeathPrefabsFromEnergy(params DeathFxFromEnergyEntry[] cachedOverrideDeathPrefabsFromEnergy)
    {
      ValidateParam(cachedOverrideDeathPrefabsFromEnergy);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedOverrideDeathPrefabsFromEnergy = bp.m_CachedOverrideDeathPrefabsFromEnergy.Where(item => !cachedOverrideDeathPrefabsFromEnergy.Contains(item)).ToArray();
          });
    }
  }
}
